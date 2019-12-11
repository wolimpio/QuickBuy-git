using Microsoft.AspNetCore.Mvc;
using QuyckBuy.Dominio.contrato;
using QuyckBuy.Dominio.Entidades;
using System;

namespace QuickBuy.Web.Controllers
{
	[Route("api/[controller]")]
	public class UsuarioController : Controller
	{
		private readonly IUsuarioRepositorio _usuarioRepositorio;

		public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
		{
			_usuarioRepositorio = usuarioRepositorio;
		}

		[HttpPost]
		public IActionResult Post([FromBody]Usuario usuario)
		{
			try
			{
				_usuarioRepositorio.Adicionar(usuario);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		[HttpPost("VerificarUsuario")]
		public IActionResult VerificarUsuario([FromBody] Usuario usuario)
		{
			try
			{
				var usuarioRetorno = _usuarioRepositorio.Obter(usuario.Email, usuario.Senha);

				if (usuarioRetorno != null)
				{
					return Ok(usuarioRetorno);
				}
				return BadRequest("usuário ou senha inválidos");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}
	}
}
