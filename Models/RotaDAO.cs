namespace Models.Dao
{

    public class Rota
    {
        public IList<Models.Rota> rotas = new List<Models.Rota>();

        public void Insert(Models.Rota rota)
        {
            rota.Id = NextId();
            rotas.Add(rota);
        }

        public void Update(Models.Rota rota)
        {
            rotas[rota.Id - 1] = rota;
        }

        public void Delete(int id)
        {
            rotas.Remove(GetById(id));
        }

        public Models.Rota GetById(int id)
        {
            return rotas.Where(rota => rota.Id == id).First();
        }

        public IList<Models.Rota> GetAll()
        {
            return rotas;
        }


        public int NextId()
        {
            int id = 0;
            if (rotas.Any())
            {
                int ultimaRota = rotas.Max(Rota => Rota.Id);
                if (id < ultimaRota) id = ultimaRota;
            }
            return id + 1;
        }
    }

}