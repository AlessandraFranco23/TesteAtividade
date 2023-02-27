using Models;

namespace Controllers
{
    public class Caminhao
    {
        private Models.Dao.Caminhao dao;

        public Caminhao(Models.Dao.Caminhao dao)
        {
            this.dao = dao;
        }

        public void Nova(string nomeMotorista, string placa ) {
            Placa numeroPlaca = new Placa(placa);
            Motorista motorista = new Motorista(nomeMotorista);
            Models.Caminhao caminhao = new Models.Caminhao(numeroPlaca, motorista);
            dao.Insert(caminhao);
        }

        public void Atualizar(int id, string nomeMotorista) {
            Motorista motorista = new Motorista(nomeMotorista);
            Models.Caminhao caminhao = dao.GetById(id);
            caminhao.Motorista = motorista;
            dao.Update(caminhao);
        }

        public void Remover(int id) {
            dao.Delete(id);
        }

        public IList<Models.Caminhao> FindAll() {
            return dao.GetAll();
        }
    }
}