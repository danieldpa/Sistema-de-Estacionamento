using Estacionamento.Models;

namespace Estacionamento.Services.Veiculo
{
    public interface IVeiculoInterface
    {
        VeiculoModel Add(VeiculoModel pVeiculo);

        List<VeiculoModel> GetAllEstacionados();

        VeiculoModel GetById(int id);

        VeiculoModel SaidaConfirmacao(int  id);

        void ConfirmarSaida(VeiculoModel pVeiculo);
        List<VeiculoModel> GetAllHistoricoSaida();
    }
}
