using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace TPRM.SAP.Web.CustomAttribute
{
    public class TamanhoArquivoAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly int _tamanhoMaximo;

        /// <summary>
        /// Tamanho máximo em MB.
        /// </summary>
        /// <param name="tamanhoMaximo"></param>
        public TamanhoArquivoAttribute(int tamanhoMaximo)
        {
            _tamanhoMaximo = tamanhoMaximo;
        }

        public override bool IsValid(object value)
        {
            if (value is IEnumerable<HttpPostedFileBase>)
            {
                foreach (var arquivo in (IEnumerable<HttpPostedFileBase>)value)
                {
                    if (value == null)
                    {
                        return false;
                    }

                    if ((arquivo as HttpPostedFileBase).ContentLength <= (_tamanhoMaximo * 1024 * 1024) != true)
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (value == null)
                {
                    return true;
                }

                return (value as HttpPostedFileBase).ContentLength <= (_tamanhoMaximo * 1024 * 1024);
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("O tamanho do arquivo não deve exceder {0} MB.", _tamanhoMaximo);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = this.FormatErrorMessage(_tamanhoMaximo.ToString()),
                ValidationType = "filesize"
            };

            rule.ValidationParameters["maxsize"] = _tamanhoMaximo;

            yield return rule;
        }
    }
}