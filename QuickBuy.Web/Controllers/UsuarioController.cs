using Microsoft.AspNetCore.Mvc;
using QuyckBuy.Dominio.contrato;
using QuyckBuy.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
		public ActionResult Post([FromBody] Usuario usuario)
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
		public ActionResult VerificarUsuario([FromBody] Usuario usuario)
		{
			try
			{
				if (usuario.Email == "wellington.olimpios@gmail.com" && usuario.Senha == "123")
				{
					//_usuarioRepositorio.Adicionar(usuario);
					return Ok(usuario);
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
