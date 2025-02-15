﻿using Frame.Models;
using Frame.Models.Front;
using Frame.Orq.Interfaces;
using Frame.Util.Excecoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Frame.Host.Controllers
{
    [Route("post")]
    public class PostController : Controller
    {
        private readonly IPostOrq _postOrq;

        public PostController(IPostOrq postOrq)
        {
            _postOrq = postOrq;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult CriarPost([FromBody] RequisicaoCriarPost requisicao)
        {
            try
            {
                _postOrq.CriarPost(requisicao.Imagens, requisicao.Texto, requisicao.Titulo, requisicao.Link, User.FindFirst(ClaimTypes.PrimarySid).Value);

                return Ok(new RetornoPadrao<string>()
                {
                    Sucesso = true,
                    Mensagem = "Post criado com sucesso!"
                });
            }
            catch (ErroCriarPostSemTituloException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ErroConteudoVazioException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult ObterPosts()
        {
            try
            {
                return Ok(new RetornoPadrao<List<PostFront>>()
                {
                    Sucesso = true,
                    Resultado = _postOrq.ObterPosts()
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("{idPost}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult ExcluirPost([FromRoute]int idPost)
        {
            try
            {
                _postOrq.ExcluirPost(int.Parse(User.FindFirst(ClaimTypes.PrimarySid).Value), idPost);

                return Ok(new RetornoPadrao<string>()
                {
                    Sucesso = true,
                    Mensagem = "Post excluído com sucesso!",
                    Resultado = String.Empty
                });
            }
            catch (ErroExcluirPostDeOutroUsuarioException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
