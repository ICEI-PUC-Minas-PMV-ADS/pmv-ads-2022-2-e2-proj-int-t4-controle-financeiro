using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZCaixaV5.Models
{
    public class CategoriaLista
    {
        public string CatListaId { get;  set; }
        public string CatListaNome { get; set; }    
        public List<CategoriaLista> ListaCategorias()
        {
            return new List<CategoriaLista>
            {
            };
        }
    }
}
