namespace Views
{

    public class Rota
    {
        Controllers.Rota controller;

        public Rota(Controllers.Rota controller)
        {
            this.controller = controller;
        }

        public void Show()
        {
            int opt = 0;
            do
            {
                Console.WriteLine("--- Rotas ---");
                Console.WriteLine("1 - Cadastrar");
                Console.WriteLine("2 - Atualizar");
                Console.WriteLine("3 - Remover");
                Console.WriteLine("4 - Ver todos");
                Console.WriteLine("0 - Voltar ao Menu Principal");
                Console.WriteLine("Informe a opção desejada:");
                opt = int.Parse(Console.ReadLine());
                switch (opt)
                {
                    case 0:
                        break;
                    case 1:
                        controller.Novo();

                        Console.WriteLine("Insira o id do caminhão");
                        int idCaminhao = Int32.Parse(Console.ReadLine());
                        controller.SetCaminhao(idCaminhao);

                        Console.WriteLine("Insira o id da cidade de partida");
                        int idPartida = Int32.Parse(Console.ReadLine());
                        controller.SetPartida(idPartida);

                        Console.WriteLine("Insira o id da cidade de chegada");
                        int idChegada = Int32.Parse(Console.ReadLine());
                        controller.SetChegada(idChegada);

                        Console.WriteLine("Insira o dia da rota");
                        string data = Console.ReadLine();
                        controller.Quando(data);

                        controller.Inserir();
                        break;
                    case 2:
                        Console.WriteLine("Insira o id da rota");
                        int id = Int32.Parse(Console.ReadLine());
                        controller.Atualizar(id);

                        Console.WriteLine("Insira o id do caminhão");
                        idCaminhao = Int32.Parse(Console.ReadLine());
                        controller.SetCaminhao(idCaminhao);

                        Console.WriteLine("Insira o id da cidade de partida");
                        idPartida = Int32.Parse(Console.ReadLine());
                        controller.SetPartida(idPartida);

                        Console.WriteLine("Insira o id da cidade de chegada");
                        idChegada = Int32.Parse(Console.ReadLine());
                        controller.SetChegada(idChegada);

                        Console.WriteLine("Insira o dia da rota");
                        data = Console.ReadLine();
                        controller.Quando(data);

                        controller.Update();
                        break;
                    case 3:
                        Console.WriteLine("Insira o id da rota");
                        id = Int32.Parse(Console.ReadLine());
                        controller.Remover(id);

                        break;
                    case 4:
                        controller.FindAll().Select(rota => $"{rota.Id} - {rota.Caminhao.Placa.valor} - {rota.Partida.Nome.Valor} - {rota.Chegada.Nome.Valor} - {rota.Data}").ToList().ForEach(cidade => Console.WriteLine(cidade));
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (opt != 0);
        }
    }

}