using System;
using Microsoft.AspNetCore.Mvc;
using DevIO.UI.Site.Data;

namespace DevIO.UI.Site.Models
{
    public class HomeController : Controller
    {
        // Respeitando o SOLID:
        private IPedidoRepository _pedidoRepository;

        public HomeController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }


        public IActionResult Index()
        {
            /* Respeitando os princípios do SOLID, não devemos instanciar objetos dentro de uma classe, mas já receber os objetos já instanciados usando injeção de dependência.
            var repositorio = new PedidoRepository();
            var pedido = repositorio.ObterPedido();
             */
            var pedido = _pedidoRepository.ObterPedido();

            return View();
        }
    }
}

