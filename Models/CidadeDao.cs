namespace Models.Dao
{

    public class Cidade
    {
        public IList<Models.Cidade> cidades = new List<Models.Cidade>();

        public void Insert(Models.Cidade cidade)
        {
            cidade.Id = NextId();
            cidades.Add(cidade);
        }

        public void Update(Models.Cidade cidade)
        {
            cidades[cidade.Id - 1] = cidade;
        }

        public void Delete(int id)
        {
            cidades.Remove(GetById(id));
        }

        public Models.Cidade GetById(int id)
        {
            return cidades.Where(cidade => cidade.Id == id).First();
        }

        public IList<Models.Cidade> GetAll()
        {
            return cidades;
        }


        public int NextId()
        {
            int id = 0;
            if (cidades.Any())
            {
                int ultimaCidade = cidades.Max(cidade => cidade.Id);
                if (id < ultimaCidade) id = ultimaCidade;
            }
            return id + 1;
        }
    }

}