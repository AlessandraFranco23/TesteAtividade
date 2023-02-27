namespace Models
{
    public class Rota
    {
        public int Id { get; set; }
        public Caminhao Caminhao { get; set; }
        public Cidade Partida { get; set; }
        public Cidade Chegada { get; set; }
        public DateTime Data { get; set; }

        public Rota(RotaBuilder builder)
        {
            Id = 0;
            Caminhao = builder.Caminhao;
            Partida = builder.Partida;
            Chegada = builder.Chegada;
            Data = builder.Data;
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
            });
        }
    }

    public interface RotaProps
    {
        public RotaProps ComCaminhao(Caminhao caminhao);
        public RotaProps SaindoDe(Cidade partida);
        public RotaProps ChegandoEm(Cidade chegada);
        public RotaProps Quando(DateTime data);
        public void Update();
        public Rota Build();
    }

    public class RotaForm : RotaProps
    {
        public Caminhao Caminhao { get; set; }
        public Cidade Partida { get; set; }
        public Cidade Chegada { get; set; }
        public DateTime Data { get; set; }

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

        public RotaProps Quando(DateTime data)
        {
            Data = data;
            return this;
        }

        public void Update()
        {
            Action.Invoke(this);
        }

        public Rota Build()
        {
            throw new NotImplementedException();
        }
    }

    //Classe construtora (Builder Pattern)
    public class RotaBuilder: RotaProps
    {
        public Caminhao Caminhao { get; set; }
        public Cidade Partida { get; set; }
        public Cidade Chegada { get; set; }
        public DateTime Data { get; set; }

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

        public RotaProps Quando(DateTime data)
        {
            Data = data;
            return this;
        }

        public Rota Build()
        {
            return new Rota(this);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}