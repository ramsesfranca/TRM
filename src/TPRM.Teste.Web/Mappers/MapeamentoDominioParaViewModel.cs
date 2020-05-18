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
    public class MapeamentoDominioParaViewModel : Profile
    {
        public override string ProfileName
        {
            get { return "MapeamentoDominioParaViewModel"; }
        }

        protected override void Configure()
        {
            #region Cadastro

            Mapper.CreateMap<Cliente, AlterarClienteViewModel>();
            Mapper.CreateMap<Estacionamento, AlterarEstacionamentoViewModel>();
            Mapper.CreateMap<Cancela, AlterarCancelaViewModel>()
                .ForMember(x => x.ClienteId, opt => opt.ResolveUsing(y => y.Estacionamento != null ? y.Estacionamento.ClienteId : 0));

            #endregion

            #region Gestão

            Mapper.CreateMap<Competencia, AlterarCompetenciaViewModel>();

            #endregion

            Mapper.CreateMap<Acao, AcaoViewModel>();
            Mapper.CreateMap<Funcionalidade, FuncionalidadeViewModel>();
            Mapper.CreateMap<Modulo, ModuloViewModel>();
            Mapper.CreateMap<Permissao, PermissaoViewModel>();
            Mapper.CreateMap<Usuario, AlterarUsuarioViewModel>()
                .ForMember(x => x.ClienteId, opt => opt.ResolveUsing(y => y.Cancela != null ? y.Cancela.Estacionamento.ClienteId : 0))
                .ForMember(x => x.EstacionamentoId, opt => opt.ResolveUsing(y => y.Cancela != null ? y.Cancela.EstacionamentoId : 0))
                .ForMember(x => x.CancelaId, opt => opt.ResolveUsing(y => y != null ? y.CancelaId : 0));
            Mapper.CreateMap<Usuario, VisualizarUsuarioViewModel>();
            Mapper.CreateMap<Perfil, AlterarPerfilViewModel>();
            Mapper.CreateMap<Perfil, ListaPerfilViewModel>();
            //Mapper.CreateMap<Cliente, VisualizarClienteViewModel>()
            //    .ForMember(x => x.QqtTransacoesAvalida, opt => opt.MapFrom(y => y.Transacoes.Count))
            //    .ForMember(x => x.ValorTotalPorTrasancao, opt => opt.MapFrom(y => y.Transacoes.Count * 5));
        }
    }
}
