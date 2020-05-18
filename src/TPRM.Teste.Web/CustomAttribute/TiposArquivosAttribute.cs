using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace TPRM.SAP.Web.CustomAttribute
{
    public class TiposArquivosAttribute : ValidationAttribute
    {
        private readonly List<string> _listaTipos;

        public TiposArquivosAttribute(string tipo)
        {
            _listaTipos = tipo.Split(',').Select(x => x.Trim()).ToList();
        }

        public override bool IsValid(object value)
        {
            if (value is IEnumerable<HttpPostedFileBase>)
            {
                foreach (var arquivo in (IEnumerable<HttpPostedFileBase>)value)
                {
                    if (arquivo == null)
                    {
                        return false;
                    }

                    var extensaoArquivo = Path.GetExtension((arquivo as HttpPostedFileBase).FileName).Substring(1);

                    if (_listaTipos.Contains(extensaoArquivo, StringComparer.OrdinalIgnoreCase) != true)
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

                var extensaoArquivo = Path.GetExtension((value as HttpPostedFileBase).FileName).Substring(1);

                return _listaTipos.Contains(extensaoArquivo, StringComparer.OrdinalIgnoreCase);
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(@"Tipo de arquivo inválido. Somente os seguintes tipos ""{0}"" são suportados.", string.Join(", ", _listaTipos));
        }
    }
}
