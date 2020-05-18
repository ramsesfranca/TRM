using Microsoft.Practices.Unity;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Cadastro;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Gestao;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Sistema;
using TPRM.SAP.Modelo.Interfaces.Servicos.Cadastro;
using TPRM.SAP.Modelo.Interfaces.Servicos.Gestao;
using TPRM.SAP.Modelo.Interfaces.Servicos.Sistema;
using TPRM.SAP.Negocio.Servicos.Cadastro;
using TPRM.SAP.Negocio.Servicos.Gestao;
using TPRM.SAP.Negocio.Servicos.Sistema;
using TPRM.SAP.Repositorio;
using TPRM.SAP.Repositorio.Repositorios.Cadastro;
using TPRM.SAP.Repositorio.Repositorios.Gestao;
using TPRM.SAP.Repositorio.Repositorios.Sistema;

namespace TPRM.SAP.Negocio
{
    public static class ConfiguradorContainer
    {
        public static IUnityContainer CarregarConfiguracoes(this IUnityContainer container)
        {
            container
                .RegistrarTipo<SAPContexto>()
                .RegistrarTipo<IPerfilRepositorio, PerfilRepositorio>()
                .RegistrarTipo<IFuncionalidadeRepositorio, FuncionalidadeRepositorio>()
                .RegistrarTipo<IAcaoRepositorio, AcaoRepositorio>()
                .RegistrarTipo<IPermissaoRepositorio, PermissaoRepositorio>()
                .RegistrarTipo<IUsuarioRepositorio, UsuarioRepositorio>()
                .RegistrarTipo<IClienteRepositorio, ClienteRepositorio>()
                .RegistrarTipo<IEstacionamentoRepositorio, EstacionamentoRepositorio>()
                .RegistrarTipo<ICancelaRepositorio, CancelaRepositorio>()
                .RegistrarTipo<ICompetenciaRepositorio, CompetenciaRepositorio>()
                .RegistrarTipo<IMovimentacaoRepositorio, MovimentacaoRepositorio>()
                .RegistrarTipo<IModuloRepositorio, ModuloRepositorio>();

            container
                .RegistrarTipo<IPerfilServico, PerfilServico>()
                .RegistrarTipo<IFuncionalidadeServico, FuncionalidadeServico>()
                .RegistrarTipo<IAcaoServico, AcaoServico>()
                .RegistrarTipo<IPermissaoServico, PermissaoServico>()
                .RegistrarTipo<IUsuarioServico, UsuarioServico>()
                .RegistrarTipo<IClienteServico, ClienteServico>()
                .RegistrarTipo<IEstacionamentoServico, EstacionamentoServico>()
                .RegistrarTipo<ICancelaServico, CancelaServico>()
                .RegistrarTipo<ICompetenciaServico, CompetenciaServico>()
                .RegistrarTipo<IMovimentacaoServico, MovimentacaoServico>()
                .RegistrarTipo<IModuloServico, ModuloServico>();

            return container;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TipoClasse"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        internal static IUnityContainer RegistrarTipo<TipoClasse>(this IUnityContainer container)
            where TipoClasse : class
        {
            return container.RegisterType<TipoClasse>(new PerResolveLifetimeManager());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TipoInterface"></typeparam>
        /// <typeparam name="TipoClasse"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        internal static IUnityContainer RegistrarTipo<TipoInterface, TipoClasse>(this IUnityContainer container)
            where TipoClasse : TipoInterface
        {
            return container.RegisterType<TipoInterface, TipoClasse>(new PerResolveLifetimeManager());
        }
    }
}
