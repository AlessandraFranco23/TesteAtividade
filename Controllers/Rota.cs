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

        public void Atualizar(int id)
        {
            Model = dao.GetById(id);
            Form = Model.Update();
        }

        public void SetCaminhao(int idCaminhao)
        {
            Models.Caminhao caminhao = daoCaminhao.GetById(idCaminhao);
            Form.ComCaminhao(caminhao);
        }

        public void SetPartida(int idCidade)
        {
            Models.Cidade cidade = daoCidade.GetById(idCidade);
            Form.SaindoDe(cidade);
        }

        public void SetChegada(int idCidade)
        {
            Models.Cidade cidade = daoCidade.GetById(idCidade);
            Form.ChegandoEm(cidade);
        }

        public void Quando(string data)
        {
            Form.Quando(Convert.ToDateTime(data));
        }

        public void Inserir()
        {
            Models.Rota rota = Form.Build();
            dao.Insert(rota);
        }

        public void Update() {
            Form.Update();
            dao.Update(Model);
        }

         public void Remover(int id) {
            dao.Delete(id);
        }

        public IList<Models.Rota> FindAll() {
            return dao.GetAll();
        }
    }
}