using System.Collections.Generic;
using System.Linq;
using TPRM.SAP.Modelo.Entidades.Sistema;
using TPRM.SAP.Modelo.Enums;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Sistema;
using TPRM.SAP.Modelo.Interfaces.Servicos.Sistema;

namespace TPRM.SAP.Negocio.Servicos.Sistema
{
    public class PermissaoServico : ServicoBase<Permissao, int, IPermissaoRepositorio>, IPermissaoServico
    {
        public List<Permissao> SelecionarTodasPeloPerfilId(int perfilId)
        {
            return this.RepositorioBase.SelecionarPor(x => x.Funcionalidade.Status == Status.Ativo && x.Funcionalidade.Modulo.Status == Status.Ativo &&
                x.PerfilId.Equals(perfilId), new string[] { "Funcionalidade", "Acao" }).ToList();
        }
    }
}
