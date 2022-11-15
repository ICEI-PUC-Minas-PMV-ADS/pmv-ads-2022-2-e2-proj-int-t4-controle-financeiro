using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZCaixaV5.Models
{
    public class Lancamento
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "Informe uma Data")]
        public string Data { get; set; }

        [Required(ErrorMessage = "Informe uma Data de Lançamento")]
        public string DataLancamento { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "Obrigatório um tipo (Débito ou Crédito)")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Informe um valor")]
        public string Valor { get; set; }

        public string Conciliado { get; set; }

        public string Username { get; set; }

        [Required(ErrorMessage = "Informe uma Categoria")]
        public string CatId { get; set; }
    }
}
