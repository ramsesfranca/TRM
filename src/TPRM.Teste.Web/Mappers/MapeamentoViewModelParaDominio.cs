using AutoMapper;
using TPRM.SAP.Modelo.Entidades.Cadastro;
using TPRM.SAP.Modelo.Entidades.Gestao;
using TPRM.SAP.Modelo.Entidades.Sistema;
using TPRM.SAP.Web.Areas.Cadastro.Models;
using TPRM.SAP.Web.Areas.Gestao.Models;
using TPRM.SAP.Web.Areas.Sistema.Models;
using TPRM.SAP.Web.Models;

namespace TPRM.SAP.Web.Mappers
{
    public class MapeamentoViewModelParaDominio : Profile
    {
        public override string ProfileName
        {
            get { return "MapeamentoViewModelParaDominio"; }
        }

        protected override void Configure()
        {
            #region Cadastro

            Mapper.CreateMap<ListaClienteViewModel, Cliente>();
            Mapper.CreateMap<InserirClienteViewModel, Cliente>();
            Mapper.CreateMap<AlterarClienteViewModel, Cliente>();
            Mapper.CreateMap<ListaEstacionamentoViewModel, Estacionamento>();
            Mapper.CreateMap<InserirEstacionamentoViewModel, Estacionamento>();
            Mapper.CreateMap<AlterarEstacionamentoViewModel, Estacionamento>();
            Mapper.CreateMap<ListaCancelaViewModel, Cancela>();
            Mapper.CreateMap<InserirCancelaViewModel, Cancela>();
            Mapper.CreateMap<AlterarCancelaViewModel, Cancela>();

            #endregion

            #region Geral

            Mapper.CreateMap<EntradaMovimentacaoViewModel, Movimentacao>()
                .ForMember(x => x.Modelo, opt => opt.ResolveUsing(y => y.ModeloCarro));

            #endregion

            #region Gestão

            Mapper.CreateMap<ListaCompetenciaViewModel, Competencia>();

            #endregion

            //Mapper.CreateMap<Models.LoginViewModel, Login>();
            //Mapper.CreateMap<Areas.Sistema.Models.LoginViewModel, Login>();
            Mapper.CreateMap<PermissaoViewModel, Permissao>();
            Mapper.CreateMap<InserirUsuarioViewModel, Usuario>();
            Mapper.CreateMap<AlterarUsuarioViewModel, Usuario>();
            Mapper.CreateMap<ListaUsuarioViewModel, Usuario>();
            Mapper.CreateMap<AlterarPerfilViewModel, Perfil>();
            Mapper.CreateMap<ListaPerfilViewModel, Perfil>();
            //Mapper.CreateMap<NovaTransacaoViewModel, Transacao>()
            //    .ForMember(x => x.Arquivo, opt => opt.ResolveUsing(y => y.Arquivo.LerArquivo().ArquivoByte))
            //    .ForMember(x => x.NomeArquivo, opt => opt.ResolveUsing(y => y.Arquivo.LerArquivo().NomeOriginal));
            //Mapper.CreateMap<AvaliarTransacaoViewModel, Transacao>();
            //Mapper.CreateMap<ListaClienteViewModel, Cliente>();
        }
    }
}
