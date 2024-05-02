using Estacionamento.Data;
using Estacionamento.Models;
using Estacionamento.Services.TabelaPreco;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Estacionamento.Services.Veiculo
{
    public class VeiculoService : IVeiculoInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly ITabelaPrecoInterface _tabelaPrecoInterface;

        public VeiculoService(ApplicationDbContext bancoContext, ITabelaPrecoInterface tabelaPrecoService)
        {
            _context = bancoContext;
            _tabelaPrecoInterface = tabelaPrecoService;
        }

        public VeiculoModel Add(VeiculoModel pVeiculo)
        {
            pVeiculo.Placa = pVeiculo.Placa.ToUpper();
            pVeiculo.Estacionado = true;
            pVeiculo.HorarioChegada = DateTime.Now;

            _context.Veiculos.Add(pVeiculo);
            _context.SaveChanges();
            return pVeiculo;
        }

        public void ConfirmarSaida(VeiculoModel pVeiculo)
        {
            pVeiculo.Estacionado = false;
            _context.Veiculos.Update(pVeiculo);
            _context.SaveChanges();
            
        }

        public List<VeiculoModel> GetAllHistoricoSaida()
        {
            return _context.Veiculos.Where(v => v.Estacionado == false).ToList();
        }

        public List<VeiculoModel> GetAllEstacionados()
        {
            return _context.Veiculos.Where(v => v.Estacionado == true).ToList();
        }

        public VeiculoModel GetById(int id)
        {
            return _context.Veiculos.FirstOrDefault(x => x.Id == id);
        }

        public VeiculoModel SaidaConfirmacao(int id)
        {
            VeiculoModel veiculo = GetById(id);

            // Registro do horário de saída
            veiculo.HorarioSaida = DateTime.Now;
            veiculo.Duracao = veiculo.HorarioSaida - veiculo.HorarioChegada;

            // Busca na tabela de preco
            TabelaPrecoModel tabelaPreco = _tabelaPrecoInterface.Get(veiculo.HorarioChegada);
            if (tabelaPreco != null)
            {
                CalcularTempoCobrado(veiculo, tabelaPreco);
            }

            return veiculo;
        }

        private VeiculoModel CalcularTempoCobrado(VeiculoModel veiculo, TabelaPrecoModel tabelaPreco)
        {
            int totalMinutos = (int)veiculo.Duracao.Value.TotalMinutes;
            decimal precoPorHora = tabelaPreco.PrecoPorHora;
            decimal precoHoraAdicional = tabelaPreco.ValorHoraAdicional;
            int MinutosTolerancia = tabelaPreco.MinutoTolerancia;

            decimal valorAPagar = 0;  
            int horasCobradas = 0;    

            if (totalMinutos <= 30)
            {
                valorAPagar = precoPorHora / 2;  
            }
            else
            {
                valorAPagar = precoPorHora; 
                horasCobradas = 1;          // A primeira hora é sempre cobrada
                int horaJaCobrada = MinutosTolerancia + 60;

                if (totalMinutos > horaJaCobrada) 
                {   

                    int minutosExcedentes = totalMinutos - horaJaCobrada;
                    int horasAdicionaisCompletas = minutosExcedentes / 60;
                    int minutosRestantes = minutosExcedentes % 60;

                    
                    valorAPagar += horasAdicionaisCompletas * precoHoraAdicional;
                    horasCobradas += horasAdicionaisCompletas; 

                    if (minutosRestantes > 0)
                    {
                        valorAPagar += precoHoraAdicional;
                        horasCobradas++; // Adiciona mais uma hora completa
                    }
                }
            }

            veiculo.Preco = precoPorHora;
            veiculo.ValorAPagar = valorAPagar;
            veiculo.TempoCobrado = horasCobradas; 

            return veiculo;
        }



    }

}
