using CadastroCliente.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroCliente.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClientesDAL cli;

        public HomeController(ILogger<HomeController> logger, IClientesDAL cliente)
        {
            _logger = logger;            
            cli = cliente;
        }
               

        public IActionResult Index()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            listaClientes = cli.GetAllDbClientes().ToList();
            return View(new IndexViewModel()
            {
                Clientes  = listaClientes
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(CriarViewModel model)
        {
            Cliente cliente = new Cliente();

            cliente.ClienteId = model.Id;
            cliente.Nome = model.Nome;
            cliente.RG = model.RG;
            cliente.CPF = model.CPF;
            cliente.Telefone = model.Telefone;
            cliente.NomeMae = model.NomeMae;
            cliente.NomePai = model.NomePai;
            cliente.Email = model.Email;

            cli.AddCliente(cliente);

            return View(model);
        }
        public ActionResult Editar(int id)
        {
            Cliente cliente = cli.GetCliente(id);
            if (cliente != null)
            {
                return View(new EditarViewModel()
                {
                    Id = cliente.ClienteId,
                    Nome = cliente.Nome,
                    RG = cliente.RG,
                    CPF = cliente.CPF,
                    Telefone = cliente.Telefone,
                    NomeMae = cliente.NomeMae,
                    NomePai = cliente.NomePai,
                    Email = cliente.Email
                }) ;
            }
            else
            {
                return View(new EditarViewModel()
                {       


                });
            }

        }
        
        [HttpPost]
        public ActionResult Editar(EditarViewModel model)
        {                           
            Cliente cliente = new Cliente();            

            cliente.ClienteId = model.Id;
            cliente.Nome = model.Nome;
            cliente.RG = model.RG;
            cliente.CPF = model.CPF;
            cliente.Telefone = model.Telefone;
            cliente.NomeMae = model.NomeMae;
            cliente.NomePai = model.NomePai;
            cliente.Email = model.Email;

            cli.UpdateCliente(cliente);

            return View(model);
        }
        
        [HttpDelete("Delete")]
        public ActionResult Delete(int id)
        {                 
            Cliente cliente = cli.GetCliente(id);
            if (cliente != null)
            {
                cli.DeleteCliente(cliente.ClienteId);
                return Json("Registro excluído com Sucesso!");
            }
            else
            {
                return NotFound("Cliente não encontrado");
            }
            
        }
    }
}
