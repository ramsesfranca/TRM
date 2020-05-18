using System.Collections.Generic;
using TPRM.SAP.Modelo.Entidades.Cadastro;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Cadastro;

namespace TPRM.SAP.Modelo.Interfaces.Servicos.Cadastro
{
    public interface ICancelaServico : IServicoBase<Cancela, int, ICancelaRepositorio>
    {
        List<Cancela> SelecionarPorEstacionamento(int estacionamentoId);
    }
}
