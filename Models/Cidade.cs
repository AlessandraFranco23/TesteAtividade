namespace Models
{
    public class Cidade
    {
        public int Id { get; set; }
        public Nome Nome { get; set; }

        public Cidade(Nome nome) {
            Nome = nome;
        }
    }

    public class Nome
    {
        public string Valor { get; set; }
        public Nome(string nome)
        {
            Valor = nome;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            return Valor == ((Nome)obj).Valor;
        }
    }
}