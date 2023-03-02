namespace Models
{

    //Entidades: Imutavel, Final, Unica(ID), Equal
    // caminhao1 == caminhao2 (id == id) true
    public class Caminhao
    {
        public int Id { get; set; }
        public Placa Placa { get; set; }
        public Motorista Motorista { get; set; }

        public Caminhao(Placa placa, Motorista motorista)
        {
            Id = 0;
            Placa = placa;
            Motorista = motorista;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            Caminhao other = (Caminhao)obj;
            return Id == other.Id && Placa == other.Placa;
        }

    }

    public class Motorista
    {
        public string Nome { get; set; }
        public Motorista(string nome)
        {
            Nome = nome;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            return Nome == ((Motorista)obj).Nome;
        }
    }

    //Objetos de valor: Imutavel, final, Equal
    public class Placa
    {
        public string valor { get; set; }

        public Placa(string valor)
        {
            ValidaPlaca(valor);
            this.valor = valor;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            return valor == ((Placa)obj).valor;
        }

        private void ValidaPlaca(string placa)
        {
            string[] placaSplit = placa.Split('-');
            if (placaSplit.Length != 2 &&
                placaSplit[0].Length != 3 &&
                placaSplit[1].Length != 4)
            {
                throw new PlacaInvalida();
            }

            string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numeros = "0123456789";

            if (placaSplit[0].Except(letras).Any() &&
                placaSplit[1].Except(numeros).Any())
            {
                throw new PlacaInvalida();
            }
        }
    }

    public class PlacaInvalida : Exception
    {
        public PlacaInvalida() : base("Placa inválida")
        {
        }
    }
}