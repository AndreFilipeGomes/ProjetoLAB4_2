using System;
using System.Collections.Generic;

namespace ProjetoLAB4_2.Models
{
    public partial class Administrador
    {
        public Administrador()
        {
            AdministrarUtilizador = new HashSet<AdministrarUtilizador>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }

        public virtual ICollection<AdministrarUtilizador> AdministrarUtilizador { get; set; }
    }
}
