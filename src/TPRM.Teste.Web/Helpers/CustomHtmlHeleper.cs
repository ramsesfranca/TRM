using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace TPRM.SAP.Web.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class CustomHtmlHeleper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="coidgo"></param>
        /// <returns></returns>
        public static string Descricao<TEnum>(this TEnum coidgo)
        {
            FieldInfo fieldInfo = coidgo.GetType().GetField(coidgo.ToString());
            DescriptionAttribute[] atributos = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return atributos != null && atributos.Length > 0 ? atributos[0].Description : coidgo.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TipoModelo"></typeparam>
        /// <typeparam name="TipoEnum"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expressao"></param>
        /// <param name="etiquetaOpcional"></param>
        /// <param name="atributosHtml"></param>
        /// <param name="itensRemover"></param>
        /// <returns></returns>
        public static MvcHtmlString DropDownListForEnum<TipoModelo, TipoEnum>(this HtmlHelper<TipoModelo> htmlHelper, Expression<Func<TipoModelo, TipoEnum>> expressao,
            string etiquetaOpcional = null, object atributosHtml = null, string itensRemover = null)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expressao, htmlHelper.ViewData);
            var nonNullableType = metadata.ModelType;
            var underlyingType = Nullable.GetUnderlyingType(nonNullableType);

            if (underlyingType != null)
            {
                nonNullableType = underlyingType;
            }

            var items = (from item in Enum.GetValues(nonNullableType).Cast<TipoEnum>()
                         select new SelectListItem
                         {
                             Text = item.Descricao(),
                             Value = item.ToString(),
                             Selected = item.Equals(metadata.Model)
                         }).ToList();

            if (!string.IsNullOrEmpty(itensRemover))
            {
                var arrayASerRemovido = itensRemover.Split(',');

                foreach (var itemASerRemovido in arrayASerRemovido)
                {
                    items = items.Where(x => x.Value != itemASerRemovido.Trim()).ToList();
                }
            }

            if (!string.IsNullOrEmpty(etiquetaOpcional))
            {
                items.Insert(0, new SelectListItem { Text = etiquetaOpcional, Value = string.Empty });
            }

            return htmlHelper.DropDownListFor(expressao, items, atributosHtml);
        }
    }
}
