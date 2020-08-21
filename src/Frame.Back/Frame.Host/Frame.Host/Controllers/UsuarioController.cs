using Frame.Models.Front;
using Frame.Orq;
using Frame.Util.Excecoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Frame.Host.Controllers
{
    [Route("usuario")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioOrq _usuarioOrq;

        public UsuarioController(IUsuarioOrq usuarioOrq)
        {
            _usuarioOrq = usuarioOrq;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CriarUsuario([FromBody] RequisicaoUsuario dadosRequisicao)
        {
            try
            {
                return Ok(new RetornoPadrao<RetornoAutenticacao>()
                {
                    Sucesso = true,
                    Mensagem = "Usuário criado com sucesso!",
                    Resultado = _usuarioOrq.CriarUsuario(dadosRequisicao.Nome, dadosRequisicao.Senha)
                });
            }
            catch (ErroCriarUsuarioComMesmoNomeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("autenticar")]
        [AllowAnonymous]
        public IActionResult Autenticar([FromBody] RequisicaoUsuario dados)
        {
            try
            {
                return Ok(new RetornoPadrao<RetornoAutenticacao>()
                {
                    Sucesso = true,
                    Mensagem = "Login realizado com sucesso.",
                    Resultado = _usuarioOrq.AutenticarUsuario(dados.Nome, dados.Senha)
                });
            }
            catch (UsuarioOuSenhaInvalidosException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
