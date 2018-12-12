using System;
using System.Collections.Generic;

namespace ProjetoLAB4_2.Models
{
    public partial class AdministrarUtilizador
    {
        public int Id { get; set; }
        public int IdAdministrador { get; set; }
        public int IdUtilizador { get; set; }
        public string Motivo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        public virtual Administrador IdAdministradorNavigation { get; set; }
        public virtual Utilizador IdUtilizadorNavigation { get; set; }
    }
}
