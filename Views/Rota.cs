using System.Globalization;

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
                Console.WriteLine("5 - Ver media de frete");
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
                        string idCaminhao = Console.ReadLine();
                        controller.SetCaminhao(idCaminhao);

                        Console.WriteLine("Insira o id da cidade de partida");
                        string idPartida = Console.ReadLine();
                        controller.SetPartida(idPartida);

                        Console.WriteLine("Insira o id da cidade de chegada");
                       string idChegada = Console.ReadLine();
                        controller.SetChegada(idChegada);

                        Console.WriteLine("Insira o dia da rota");
                        string data = Console.ReadLine();
                        controller.Quando(data);

                        Console.WriteLine("Insira o valor do frete");
                        double frete = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
                        controller.ComFreteDe(frete);

                        controller.Inserir();
                        break;
                    case 2:
                        Console.WriteLine("Insira o id da rota");
                        string id = Console.ReadLine();
                        controller.Atualizar(id);

                        Console.WriteLine("Insira o id do caminhão");
                        idCaminhao = Console.ReadLine();
                        controller.SetCaminhao(idCaminhao);

                        Console.WriteLine("Insira o id da cidade de partida");
                        idPartida = Console.ReadLine();
                        controller.SetPartida(idPartida);

                        Console.WriteLine("Insira o id da cidade de chegada");
                        idChegada = Console.ReadLine();
                        controller.SetChegada(idChegada);

                        Console.WriteLine("Insira o dia da rota");
                        data = Console.ReadLine();
                        controller.Quando(data);

                        Console.WriteLine("Insira o valor do frete");
                        frete = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
                        controller.ComFreteDe(frete);

                        controller.Update();
                        break;
                    case 3:
                        Console.WriteLine("Insira o id da rota");
                        id = Console.ReadLine();
                        controller.Remover(id);

                        break;
                    case 4:
                        controller.FindAll()
                                  .Select(rota => $"{rota.Id} - {rota.Caminhao.Placa.valor} - {rota.Partida.Nome.Valor} - {rota.Chegada.Nome.Valor} - {rota.Data} - {rota.Frete.ToString("F2", CultureInfo.InvariantCulture)}")
                                  .ToList()
                                  .ForEach(cidade => Console.WriteLine(cidade));
                        break;
                    case 5:
                        Console.WriteLine(controller.MediaDeFrete().ToString("F2", CultureInfo.InvariantCulture));
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (opt != 0);
        }
    }

}