using Models;
using Models.Dao;

namespace Controllers
{
    public class Cidade {
        public Models.Dao.Cidade dao;

        public Cidade(Models.Dao.Cidade dao)
        {
            this.dao = dao;
        }

        public void Nova(string nome) {
            Nome nomeCidade = new Nome(nome);
            Models.Cidade cidade = new Models.Cidade(nomeCidade);
            dao.Insert(cidade);
        }

        public void Atualizar(int id, string nome) {
            Nome nomeCidade = new Nome(nome);
            Models.Cidade cidade = dao.GetById(id);
            cidade.Nome = nomeCidade;
            dao.Update(cidade);
        }

        public void Remover(int id) {
            dao.Delete(id);
        }

        public IList<Models.Cidade> FindAll() {
            return dao.GetAll();
        }
    }

}