using Series.Enum;

namespace Series.Classes
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero;
            retorno += "\nTítulo: " + this.Titulo;
            retorno += "\nDescrição: " + this.Descricao;
            retorno += "\nAno de lançamento: " + this.Ano;
            retorno += "\nExluido: " + this.Excluido;
            return retorno;
        }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public int RetornaID()
        {
            return this.Id;
        }
        public void Excluindo()
        {
            this.Excluido = true;
        }
    }
}