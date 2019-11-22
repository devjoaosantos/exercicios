using System;
using McBonaldsMVC.Repositories;
using McBonaldsMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McBonaldsMVC.Controllers {
    public class ClienteController : AbstractController {
        
        private ClienteRepository clienteRepository = new ClienteRepository();
        private PedidoRepository pedidoRepository = new PedidoRepository();
        [HttpGet]
        public IActionResult Login () {
            return View ();
        }
        [HttpPost]
        public IActionResult Login (IFormCollection form) {
            ViewData["Action"] = "Login";
            try
            {
                System.Console.WriteLine("===================");
                System.Console.WriteLine(form["email"]);
                System.Console.WriteLine(form["senha"]);
                System.Console.WriteLine("===================");

                var usuario = form["email"];
                var senha = form["senha"];

                var cliente = clienteRepository.ObterPor(usuario);

                if(cliente != null) {
                    if(cliente.Senha.Equals(senha)) {
                        HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                        return RedirectToAction("Historico","Cliente");
                    } else {
                        return View ("Error", new RespostaViewModel("Senha Incorreta!"));
                    }
                } else {
                    return View("Error", new RespostaViewModel($"Usuário {usuario} não encontrado!"));
                    
                }

                

            } 
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Error");
            }

        }

        public IActionResult Historico () {
            var emailCliente = HttpContext.Session.GetString(SESSION_CLIENTE_EMAIL);
            var pedidosCliente = pedidoRepository.ObterTodosPorCliente(emailCliente);

            return View (new HistoricoViewModel() 
            {
                Pedidos = pedidosCliente
            });

            
        }
        
    }
}

