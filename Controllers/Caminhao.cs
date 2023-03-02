using Models;

namespace Controllers
{
    public class Caminhao
    {
        private Models.Dao.Caminhao dao;
        private Models.Dao.Rota RotaDao;
        public Caminhao(Models.Dao.Caminhao dao, Models.Dao.Rota rotaDao)
        {
            this.dao = dao;
            this.RotaDao = rotaDao;
        }

        public void Nova(string nomeMotorista, string placa)
        {
            Placa numeroPlaca = new Placa(placa);
            Motorista motorista = new Motorista(nomeMotorista);
            Models.Caminhao caminhao = new Models.Caminhao(numeroPlaca, motorista);
            dao.Insert(caminhao);
        }

        public void Atualizar(string id, string nomeMotorista)
        {
            Motorista motorista = new Motorista(nomeMotorista);
            Models.Caminhao caminhao = dao.GetById(IdConvert.Convert(id));
            caminhao.Motorista = motorista;
            dao.Update(caminhao);
        }

        public void Remover(string id)
        {
            dao.Delete(IdConvert.Convert(id));
        }

        public IList<Models.Caminhao> FindAll()
        {
            return dao.GetAll();
        }

        public int TotalDeRotas(int idCaminhao)
        {
            Models.Caminhao caminhao = dao.GetById(idCaminhao);
            int totalRotas = RotaDao.GetAll()
                   .Where(rota => rota.Caminhao == caminhao)
                   .Count();
            return totalRotas;
        }

        public double TotalDeFrete(int idCaminhao)
        {
            Models.Caminhao caminhao = dao.GetById(idCaminhao);
            double totalFrete = RotaDao.GetAll()
                   .Where(rota => rota.Caminhao == caminhao)
                   .Select(rota => rota.Frete)
                   .Sum();
            return totalFrete;
        }
    }
}