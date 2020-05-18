using System;
using System.Globalization;
using System.Web.Mvc;

namespace TPRM.SAP.Web.CustomModelBinder
{
    public class DecimalModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ValueProviderResult resultadoValor = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            ModelState modeloDeEstado = new ModelState { Value = resultadoValor };

            object valorAtual = null;

            try
            {
                valorAtual = Convert.ToDecimal(resultadoValor.AttemptedValue, CultureInfo.CurrentCulture);
            }
            catch (FormatException ex)
            {
                modeloDeEstado.Errors.Add(ex);
            }
            catch (OverflowException ex)
            {
                modeloDeEstado.Errors.Add(ex);
            }

            bindingContext.ModelState.Add(bindingContext.ModelName, modeloDeEstado);

            return valorAtual;
        }
    }
}