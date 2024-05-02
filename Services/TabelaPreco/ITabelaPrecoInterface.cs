using Estacionamento.Models;
using System.Data;

namespace Estacionamento.Services.TabelaPreco
{
    public interface ITabelaPrecoInterface
    {
        TabelaPrecoModel Get(DateTime dateTime);

        TabelaPrecoModel Add(TabelaPrecoModel model);

        List<TabelaPrecoModel> GetAll();

        void Delete(int id);

    }
}
