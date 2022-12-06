using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZCaixaV5.Models
{
    public class CategoriaListaValor
    {
        public int Tipo { get; set; }
        public string Categoria { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valor { get; set; }

        public List<CategoriaListaValor> ListaCategoriasValor()
        {
            return new List<CategoriaListaValor>
            {
            };
        }
    }
}
