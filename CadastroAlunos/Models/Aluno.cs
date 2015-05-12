using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastroAlunos.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name="Nome do Aluno")]
        public string Nome { get; set; }
        
        

        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Email { get; set; }
        public string Ra { get; set; }
        public string Curso { get; set; }
        public string Semestre { get; set; }
        public string Periodo { get; set; }
        public DateTime DtCadastro { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

    }
}