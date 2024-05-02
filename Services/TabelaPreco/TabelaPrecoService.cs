using Estacionamento.Data;
using Estacionamento.Models;

namespace Estacionamento.Services.TabelaPreco
{
    public class TabelaPrecoService : ITabelaPrecoInterface
    {
        private readonly ApplicationDbContext _context;

        public TabelaPrecoService(ApplicationDbContext bancoContext)
        {
            _context = bancoContext;
        }

        public TabelaPrecoModel Add(TabelaPrecoModel pPreco)
        {
            _context.TabelasPreco.Add(pPreco);
            _context.SaveChanges();
            return pPreco;
        }

        public TabelaPrecoModel Get(DateTime dateTime)
        {
            var tabelaPreco = _context.TabelasPreco
    .Where(p => p.InicioVigencia.Date <= dateTime.Date && p.FinalVigencia.Date >= dateTime.Date)
    .FirstOrDefault();


            return tabelaPreco;

        }

        public List<TabelaPrecoModel> GetAll()
        {
            return _context.TabelasPreco.ToList();
        }

        public void Delete(int id)
        {
            var tabelaPreco = _context.TabelasPreco.Find(id);

           _context.TabelasPreco.Remove(tabelaPreco);
            _context.SaveChanges();
        }
    }
}
