using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZCaixaV5.Models
{
    public class Usuario
    {
        public string Username { get; set; }

        public string Nome { get; set; }

        public string UltimoNome { get; set; }

        public string Senha { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public DateTime DataNascimento { get; set; }

    }
}
