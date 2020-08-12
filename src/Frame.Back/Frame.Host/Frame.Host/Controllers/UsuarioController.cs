using Frame.Models.Front;
using Frame.Orq;
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
        public IActionResult CriarUsuario([FromBody] RequisicaoCriarUsuario dadosRequisicao)
        {
            try
            {
                _usuarioOrq.CriarUsuario(dadosRequisicao.Nome, dadosRequisicao.Senha);

                return Ok(new RetornoPadrao<string>()
                {
                    Sucesso = true,
                    Mensagem = "Usuário criado com sucesso!"
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult ObterUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
