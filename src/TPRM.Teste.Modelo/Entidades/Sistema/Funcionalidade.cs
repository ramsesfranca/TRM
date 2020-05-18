using System.Collections.Generic;
using TPRM.SAP.Modelo.Enums;

namespace TPRM.SAP.Modelo.Entidades.Sistema
{
    public class Funcionalidade : EntidadeBase<int>
    {
        public string Nome { get; set; }
        public string Texto { get; set; }
        public string Controlador { get; set; }
        public string Acao { get; set; }
        public int Ordem { get; set; }
        public Status Status { get; set; }

        public int ModuloId { get; set; }

        public virtual Modulo Modulo { get; set; }
        public virtual ICollection<Permissao> Permissoes { get; set; }
        public virtual ICollection<Acao> Acoes { get; set; }
    }
}
