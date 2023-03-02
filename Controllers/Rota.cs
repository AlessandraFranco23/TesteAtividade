using Models;
using Models.Dao;

namespace Controllers
{
    public class Rota
    {
        public Models.Dao.Cidade daoCidade;
        public Models.Dao.Caminhao daoCaminhao;
        public Models.Dao.Rota dao;
        public RotaProps Form;
        Models.Rota Model;

        public Rota(Models.Dao.Cidade daoCidade, Models.Dao.Caminhao daoCaminhao, Models.Dao.Rota dao)
        {
            this.daoCidade = daoCidade;
            this.daoCaminhao = daoCaminhao;
            this.dao = dao;
        }

        public void Novo()
        {
            Form = Models.Rota.Builder();
        }

        public void Atualizar(string id)
        {
            Model = dao.GetById(IdConvert.Convert(id));
            Form = Model.Update();
        }

        public void SetCaminhao(string idCaminhao)
        {
            Models.Caminhao caminhao = daoCaminhao.GetById(IdConvert.Convert(idCaminhao));
            Form.ComCaminhao(caminhao);
        }

        public void SetPartida(string idCidade)
        {
            Models.Cidade cidade = daoCidade.GetById(IdConvert.Convert(idCidade));
            Form.SaindoDe(cidade);
        }

        public void SetChegada(string idCidade)
        {
            Models.Cidade cidade = daoCidade.GetById(IdConvert.Convert(idCidade));
            Form.ChegandoEm(cidade);
        }

        public void ComFreteDe(double frete)
        {
            Form.ComFreteDe(frete);
        }
        public void Quando(string data)
        {
            Form.Quando(Convert.ToDateTime(data));
        }

        public void Inserir()
        {
            Models.Rota rota = ((RotaPropsBuild)Form).Build();
            dao.Insert(rota);
        }

        public void Update()
        {
            ((RotaPropsUpdate)Form).Update();
            dao.Update(Model);
        }

        public void Remover(string id)
        {
            dao.Delete(IdConvert.Convert(id));
        }

        public IList<Models.Rota> FindAll()
        {
            return dao.GetAll();
        }

        
        public double MediaDeFrete()
        {
            double totalFrete = dao.GetAll()
                   .Select(rota => rota.Frete)
                   .Average();
            return totalFrete;
        }

        
    }
}