using System;

namespace POO_CRUD.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DtNascimento { get; set; }
        public string CPF { get; set; }
    }
}
