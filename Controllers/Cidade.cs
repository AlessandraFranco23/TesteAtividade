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

        public void Atualizar(string id, string nome) 
        {
            
            Nome nomeCidade = new Nome(nome);
            Models.Cidade cidade = dao.GetById(IdConvert.Convert(id));
            cidade.Nome = nomeCidade;
            dao.Update(cidade);
        }

        public void Remover(string id) {
            dao.Delete(IdConvert.Convert(id));
        }

        public IList<Models.Cidade> FindAll() {
            return dao.GetAll();
        }
    }

}