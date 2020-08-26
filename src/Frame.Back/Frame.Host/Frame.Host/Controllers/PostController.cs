using Frame.Models;
using Frame.Models.Front;
using Frame.Orq.Interfaces;
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
    }
}
