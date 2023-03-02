namespace Views
{
    public class Menu
    {
        public static void Show()
        {
            
            Models.Dao.Rota rotaDao = new Models.Dao.Rota();
            Models.Dao.Cidade cidadeDao = new Models.Dao.Cidade();
            Models.Dao.Caminhao caminhaoDao = new Models.Dao.Caminhao();

            Controllers.Cidade controllerCidade = new Controllers.Cidade(cidadeDao);
            Controllers.Caminhao controllerCaminhao = new Controllers.Caminhao(caminhaoDao, rotaDao);
            Controllers.Rota controllerRota = new Controllers.Rota(cidadeDao, caminhaoDao, rotaDao);

            Cidade cidade = new Cidade(controllerCidade);
            Caminhao caminhao = new Caminhao(controllerCaminhao);
            Rota rota = new Rota(controllerRota);

            int opt = 0;
            do {
                Console.WriteLine("Gerenciamento de Rota");
                Console.WriteLine("1 - Cidade");
                Console.WriteLine("2 - Caminhão");
                Console.WriteLine("3 - Rota");
                opt = int.Parse(Console.ReadLine());
                switch (opt)
                {
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    case 1:
                        cidade.Show();
                        break;
                    case 2:
                        caminhao.Show();
                        break;
                    case 3:
                        rota.Show();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while(opt != 0);
        }
    }
}