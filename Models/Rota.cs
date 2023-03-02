namespace Models
{
    public class Rota
    {
        public int Id { get; set; }
        public Caminhao Caminhao { get; set; }
        public Cidade Partida { get; set; }
        public Cidade Chegada { get; set; }
        public DateTime Data { get; set; }

        public double Frete { get; set; }

        public Rota(RotaBuilder builder)
        {
            Id = 0;
            Caminhao = builder.Caminhao;
            Partida = builder.Partida;
            Chegada = builder.Chegada;
            Data = builder.Data;
            Frete = builder.Frete;
        }

        public static RotaBuilder Builder()
        {
            return new RotaBuilder();
        }

        public RotaForm Update()
        {
            return new RotaForm(form =>
            {
                Caminhao = form.Caminhao;
                Partida = form.Partida;
                Chegada = form.Chegada;
                Data = form.Data;
                Frete = form.Frete;
            });
        }
    }

    public interface RotaProps
    {
        public RotaProps ComCaminhao(Caminhao caminhao);
        public RotaProps SaindoDe(Cidade partida);
        public RotaProps ChegandoEm(Cidade chegada);
        public RotaProps Quando(DateTime data);
        public RotaProps ComFreteDe(double frete);
    }

    public interface RotaPropsUpdate : RotaProps
    {
        public void Update();
    }

    public interface RotaPropsBuild : RotaProps
    {
        public Rota Build();
    }

    public class RotaForm : RotaPropsUpdate
    {
        public Caminhao Caminhao { get; set; }
        public Cidade Partida { get; set; }
        public Cidade Chegada { get; set; }
        public DateTime Data { get; set; }
        public double Frete { get; set; }
        public Action<RotaForm> Action;

        public RotaForm(Action<RotaForm> action)
        {
            Action = action;
        }

        public RotaProps ComCaminhao(Caminhao caminhao)
        {
            Caminhao = caminhao;
            return this;
        }

        public RotaProps SaindoDe(Cidade partida)
        {
            Partida = partida;
            return this;
        }

        public RotaProps ChegandoEm(Cidade chegada)
        {
            Chegada = chegada;
            return this;
        }


        public RotaProps ComFreteDe(double frete)
        {
            Frete = frete;
            return this;
        }


        public RotaProps Quando(DateTime data)
        {
            Data = data;
            return this;
        }

        public void Update()
        {
            Action.Invoke(this);
        }
    }

    //Classe construtora (Builder Pattern)
    public class RotaBuilder : RotaPropsBuild
    {
        public Caminhao Caminhao { get; set; }
        public Cidade Partida { get; set; }
        public Cidade Chegada { get; set; }
        public DateTime Data { get; set; }

        public double Frete { get; set; }

        public RotaProps ComCaminhao(Caminhao caminhao)
        {
            Caminhao = caminhao;
            return this;
        }

        public RotaProps SaindoDe(Cidade partida)
        {
            Partida = partida;
            return this;
        }

        public RotaProps ChegandoEm(Cidade chegada)
        {
            Chegada = chegada;
            return this;
        }

        public RotaProps ComFreteDe(double frete)
        {
            Frete = frete;
            return this;
        }

        public RotaProps Quando(DateTime data)
        {
            Data = data;
            return this;
        }

        public Rota Build()
        {
            return new Rota(this);
        }
    }
}