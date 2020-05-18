using System.Collections.Generic;
using System.Linq;
using TPRM.SAP.Modelo.Entidades.Sistema;
using TPRM.SAP.Modelo.Enums;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Sistema;
using TPRM.SAP.Modelo.Interfaces.Servicos.Sistema;

namespace TPRM.SAP.Negocio.Servicos.Sistema
{
    public class FuncionalidadeServico : ServicoBase<Funcionalidade, int, IFuncionalidadeRepositorio>, IFuncionalidadeServico
    {
        public List<Funcionalidade> SelecionarTodasAtivas()
        {
            return this.RepositorioBase.SelecionarPor(x => x.Status == Status.Ativo && x.Modulo.Status == Status.Ativo)
                .OrderBy(x => x.Nome).ToList();
        }
    }
}
