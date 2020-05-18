using TPRM.SAP.Modelo.Entidades.Gestao;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Gestao;

namespace TPRM.SAP.Modelo.Interfaces.Servicos.Gestao
{
    public interface ICompetenciaServico : IServicoBase<Competencia, int, ICompetenciaRepositorio>
    {
        void Pagar(int clienteId);
        void EnviarEmailCobranca(int clienteId, int mes, int ano);
    }
}
