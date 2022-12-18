using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZCaixaV5.Models
{
    public class CodigoSeguranca
    {
        public string Username { get; set; }
        public int CodEmail { get; set; }
        public int Digitado { get; set; }
        public string Senha { get; set; }
    }
}
