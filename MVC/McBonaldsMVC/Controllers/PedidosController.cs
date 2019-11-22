using System;
using McBonaldsMVC.Models;
using McBonaldsMVC.Repositories;
using McBonaldsMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McBonaldsMVC.Controllers {
    public class PedidosController : AbstractController {

        ClienteRepository clienteRepository = new ClienteRepository();
        PedidoRepository pedidoRepository = new PedidoRepository();
        HamburguerRepository hamburguerRepository = new HamburguerRepository();
        ShakeRepository shakeRepository = new ShakeRepository();
        public IActionResult Index () {
            
            var hamburgueres = hamburguerRepository.ObterTodos();
            var shakes = shakeRepository.ObterTodos();

            PedidoViewModel pedido = new PedidoViewModel();
            pedido.Hamburgueres = hamburgueres;
            pedido.Shakes = shakes;
            
            var emailCliente = ObterUsuarioSession();

            if (!string.IsNullOrEmpty(emailCliente)) {
                clienteRepository.ObterPor(emailCliente);
            }

            var nomeUsuario = ObterUsuarioNomeSession();
            if (!string.IsNullOrEmpty(nomeUsuario)) {
                pedido.NomeCliente = nomeUsuario;
            }

            return View (pedido );   
        }
        public IActionResult Registrar (IFormCollection form) {

            ViewData["Action"] = "Pedidos";
            try {  
                PedidoRepository pedidoRepository = new PedidoRepository ();

                Pedido pedido = new Pedido ();

                var nomeShake = form["shake"];
                Shake shake = new Shake (
                nomeShake,
                shakeRepository.ObterPrecoDe(nomeShake));
                pedido.Shake = shake;

                var nomeHamburguer = form["hamburguer"];
                Hamburguer hamburguer = new Hamburguer (
                nomeHamburguer,
                hamburguerRepository.ObterPrecoDe(nomeHamburguer));
                pedido.Hamburguer = hamburguer;

                Cliente cliente = new Cliente () {
                    Nome = form["nome"],
                    Endereco = form["endereco"],
                    Telefone = form["telefone"],
                    Email = form["email"]
                };

                pedido.Cliente = cliente;

                pedido.DataDoPedido = DateTime.Now;

                pedido.PrecoTotal = hamburguer.Preco + shake.Preco;

                pedidoRepository.Inserir(pedido);
                return View ("Sucesso");
            } catch (Exception e) {
                System.Console.WriteLine(e.StackTrace);
                return View ("Error");
            }

        }
    }
}