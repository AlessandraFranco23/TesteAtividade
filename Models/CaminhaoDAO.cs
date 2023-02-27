namespace Models.Dao
{

    public class Caminhao
    {
        public IList<Models.Caminhao> caminhoes = new List<Models.Caminhao>();

        public void Insert(Models.Caminhao caminhao)
        {
            caminhao.Id = NextId();
            caminhoes.Add(caminhao);
        }

        public void Update(Models.Caminhao caminhao)
        {
            caminhoes[caminhao.Id - 1] = caminhao;
        }

        public void Delete(int id)
        {
            caminhoes.Remove(GetById(id));
        }

        public Models.Caminhao GetById(int id)
        {
            return caminhoes.Where(caminhao => caminhao.Id == id).First();
        }

        public IList<Models.Caminhao> GetAll()
        {
            return caminhoes;
        }


        public int NextId()
        {
            int id = 0;
            if (caminhoes.Any())
            {
                int ultimoCaminhao = caminhoes.Max(caminhao => caminhao.Id);
                if (id < ultimoCaminhao) id = ultimoCaminhao;
            }
            return id + 1;
        }
    }

}