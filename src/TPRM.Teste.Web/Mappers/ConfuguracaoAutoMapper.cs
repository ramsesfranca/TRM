using AutoMapper;

namespace TPRM.SAP.Web.Mappers
{
    public class ConfuguracaoAutoMapper
    {
        /// <summary>
        /// 
        /// </summary>
        public static void RegistrarMapeamentos()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<MapeamentoDominioParaViewModel>();
                x.AddProfile<MapeamentoViewModelParaDominio>();
            });
        }
    }
}
