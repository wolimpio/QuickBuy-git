using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuyckBuy.Dominio.contrato;
using QuyckBuy.Dominio.Entidades;
using System;
using System.IO;
using System.Linq;

namespace QuickBuy.Web.Controllers
{
	[Route("api/[controller]")]
	public class ProdutoController : Controller
	{
		private readonly IProdutoRepositorio _produtoRepositorio;

		// Utilizado para pegar o contexto da requisição http - Configuração também realizada no arquivo startup.cs.
		private IHttpContextAccessor _httpContextAccessor;
		// Utilizado para poder pegar o endereço da pasta raiz que o site está sendo rodado e onde será salvo o arquivo que será enviado pelo usuário
		private IHostingEnvironment _hostingEnvironment;

		public ProdutoController(IProdutoRepositorio produtoRepositorio,
								 IHttpContextAccessor httpContextAccessor,
								 IHostingEnvironment hostingEnvironment)
		{
			_produtoRepositorio = produtoRepositorio;
			_httpContextAccessor = httpContextAccessor;
			_hostingEnvironment = hostingEnvironment;
		}

		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				return Json(_produtoRepositorio.ObterTodos());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		[HttpPost]
		public IActionResult Post([FromBody]Produto produto)
		{
			try
			{
				produto.Validate();
				if (!produto.EhValidado)
				{
					return BadRequest(produto.ObterMensagemValidacao());
				}
				if (produto.Id > 0)
				{
					_produtoRepositorio.Atualizar(produto);
				}
				else
				{
					_produtoRepositorio.Adicionar(produto);
				}

				return Created("api/produto", produto);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		[HttpPost("Deletar")]
		public IActionResult Deletar([FromBody]Produto produto)
		{
			try
			{
				_produtoRepositorio.Remover(produto);
				return Json(_produtoRepositorio.ObterTodos());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		[HttpPost("EnviarArquivo")]
		public IActionResult EnviarArquivo()
		{
			try
			{
				var formFile = _httpContextAccessor.HttpContext.Request.Form.Files["arquivoEnviado"];

				var nomeArquivo = formFile.FileName;
				string novoNomeArquivo = GerarNovoNomeArquivo(nomeArquivo);

				var pastaArquivos = _hostingEnvironment.WebRootPath + "\\arquivos\\";
				var nomeCompleto = pastaArquivos + novoNomeArquivo;

				using (var streamArquivo = new FileStream(nomeCompleto, FileMode.Create))
				{
					formFile.CopyTo(streamArquivo);
				}

				return Json(novoNomeArquivo);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		private static string GerarNovoNomeArquivo(string nomeArquivo)
		{
			var extencao = nomeArquivo.Split(".").Last();
			var arrayNomeCompacto = Path.GetFileNameWithoutExtension(nomeArquivo).Take(10).ToArray();
			var novoNomeArquivo = new String(arrayNomeCompacto).Replace(" ", "-");
			novoNomeArquivo = $"{novoNomeArquivo}_{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.{extencao}";
			return novoNomeArquivo;
		}
	}
}
