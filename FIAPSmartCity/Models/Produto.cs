using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAPSmartCity.Models
{

    [Table("PRODUTO")]
    public class Produto
    {
        [Key]
        [Column("IDPRODUTO")]
        public int IdProduto { get; set; }

        [Column("NOMEPRODUTO")]
        public String NomeProduto { get; set; }

        [Column("CARACTERISTICAS")]
        public String Caracteristicas { get; set; }

        [Column("PRECOMEDIO")]
        public decimal PrecoMedio { get; set; }

        [Column("LOGOTIPO")]
        public String Logotipo { get; set; }

        [Column("ATIVO")]
        public int Ativo { get; set; }

        //Foreing Key
        [Column("IDTIPO")]
        public int IdTipo { get; set; }
    }
}
