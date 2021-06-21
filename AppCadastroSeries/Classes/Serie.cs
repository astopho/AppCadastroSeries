using System;


namespace AppCadastroSeries
{
    public class Serie : EntidadeBase
    {
         //Atributos
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private int Nota { get; set; }

        private bool Excluido {get ; set;}

        //Métodos

        public Serie(int id, Genero genero, string titulo, string descricao, int ano, int nota)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Nota = nota;
            this.Excluido = false;
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero :" + this.Genero + Environment.NewLine;
            retorno += "Título :" + this.Titulo + Environment.NewLine;
            retorno += "Descrição :" + this.Descricao + Environment.NewLine;
            retorno += "Ano de início :" + this.Ano + Environment.NewLine;
            retorno += "Excluído :" + this.Excluido + Environment.NewLine;
            retorno += "Nota :" + this.Nota;
            return retorno;
        }
        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public int retornaId()
        {
            return this.Id;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        public void Excluir() {
            this.Excluido = true;
        }
    }
}