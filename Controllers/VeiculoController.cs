using Estacionamento.Models;
using Estacionamento.Services.TabelaPreco;
using Estacionamento.Services.Veiculo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Estacionamento.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly IVeiculoInterface _veiculoInterface;
        public VeiculoController(IVeiculoInterface pVeiculoService) 
        {
            _veiculoInterface = pVeiculoService;
        }
        public IActionResult Estacionados()
        {
            List<VeiculoModel> veiculos = _veiculoInterface.GetAllEstacionados();
            return View(veiculos);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult ListaSaida()
        {
            List<VeiculoModel> veiculos = _veiculoInterface.GetAllHistoricoSaida();
            return View(veiculos);
        }

        public IActionResult SaidaConfirmacao(int id)
        {
            VeiculoModel veiculo = _veiculoInterface.SaidaConfirmacao(id);
            return View(veiculo);
        }

        [HttpPost]
        public IActionResult ConfirmarSaida(VeiculoModel veiculo)
        {
            _veiculoInterface.ConfirmarSaida(veiculo);
            return RedirectToAction("Estacionados");
        }

        [HttpPost]
        public IActionResult Criar(VeiculoModel pVeiculo)
        {
            _veiculoInterface.Add(pVeiculo);
            return RedirectToAction("Estacionados");
        }

    }
}
