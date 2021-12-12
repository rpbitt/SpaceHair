using System;

namespace SpaceHair.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public int Colaborador { get; set; }
        public string Nome { get; set; }
        public string Setor { get; set; }
        public int Preco { get; set; }
        public string Unidade { get; set; }
        public DateTime DataServico { get; set; }

    }

}