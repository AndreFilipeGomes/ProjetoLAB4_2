using System;
using System.Collections.Generic;

namespace ProjetoLAB4_2.Models
{
    public partial class Vinho
    {
        public Vinho()
        {
            Comentario = new HashSet<Comentario>();
            VinhosDasGarrafeiras = new HashSet<VinhosDasGarrafeiras>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdRegiao { get; set; }
        public DateTime DateInsercao { get; set; }
        public int IdTipo { get; set; }
        public int IdProdutor { get; set; }
        public int TeorAlcool { get; set; }
        public string Fotografia { get; set; }
        public int Ano { get; set; }
        public string Categoria { get; set; }

        public virtual Produtor IdProdutorNavigation { get; set; }
        public virtual Regiao IdRegiaoNavigation { get; set; }
        public virtual Tipo IdTipoNavigation { get; set; }
        public virtual ICollection<Comentario> Comentario { get; set; }
        public virtual ICollection<VinhosDasGarrafeiras> VinhosDasGarrafeiras { get; set; }
    }
}
