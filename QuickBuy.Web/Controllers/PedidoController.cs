﻿using Microsoft.AspNetCore.Mvc;
using QuyckBuy.Dominio.contrato;
using QuyckBuy.Dominio.Entidades;
using System;

namespace QuickBuy.Web.Controllers
{
	[Route("api/[controller]")]
	public class PedidoController: Controller
	{
		private readonly IPedidoRepositorio _pedidoRepositorio;

		public PedidoController(IPedidoRepositorio pedidoRepositorio)
		{
			this._pedidoRepositorio = pedidoRepositorio;
		}

		[HttpPost]
		public IActionResult Post([FromBody] Pedido pedido)
		{
			try
			{
				_pedidoRepositorio.Adicionar(pedido);
				return Ok(pedido.Id);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
			
		}
	}
}
