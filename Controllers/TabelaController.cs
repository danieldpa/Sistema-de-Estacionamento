using Estacionamento.Models;
using Estacionamento.Services.TabelaPreco;
using Estacionamento.Services.Veiculo;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Controllers
{
    public class TabelaController : Controller
    {
        private readonly ITabelaPrecoInterface _tabelaPrecoInterface;

        public TabelaController(ITabelaPrecoInterface pTabelaPrecoService) 
        {
            _tabelaPrecoInterface = pTabelaPrecoService;
        }

        public IActionResult Lista()
        {
            List<TabelaPrecoModel> precos = _tabelaPrecoInterface.GetAll();
            return View(precos);
        }
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(TabelaPrecoModel pPreco)
        {
            _tabelaPrecoInterface.Add(pPreco);
            return RedirectToAction("Lista");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _tabelaPrecoInterface.Delete(id);
            return RedirectToAction("lista");
        }
    }
}
