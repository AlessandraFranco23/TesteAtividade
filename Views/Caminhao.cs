namespace Views
{

    public class Caminhao
    {
        Controllers.Caminhao controller;

        public Caminhao(Controllers.Caminhao controller)
        {
            this.controller = controller;
        }

        public void Show()
        {
            int opt = 0;
            do
            {
                Console.WriteLine("--- Caminhão ---");
                Console.WriteLine("1 - Cadastrar");
                Console.WriteLine("2 - Atualizar");
                Console.WriteLine("3 - Remover");
                Console.WriteLine("4 - Ver todos");
                Console.WriteLine("5 - Total dos Fretes");
                Console.WriteLine("6 - Total das Rotas");
                Console.WriteLine("0 - Voltar ao Menu Principal");
                Console.WriteLine("Informe a opção desejada:");
                opt = int.Parse(Console.ReadLine());
                switch (opt)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("Informe a placa:");
                        string placa = Console.ReadLine();

                        Console.WriteLine("Informe o Motorista:");
                        string motorista = Console.ReadLine();

                        controller.Nova(motorista, placa);
                        break;
                    case 2:
                        Console.WriteLine("Insira o id do caminhão");
                        string id = Console.ReadLine();

                        Console.WriteLine("Insira o novo motorista");
                        motorista = Console.ReadLine();

                        controller.Atualizar(id, motorista);
                        break;
                    case 3:
                        Console.WriteLine("Insira o id do caminhao");
                        id = Console.ReadLine();
                        controller.Remover(id);

                        break;
                    case 4:
                        controller.FindAll()
                            .Select(caminhao => $"{caminhao.Id} - {caminhao.Placa.valor} - {caminhao.Motorista.Nome}")
                            .ToList()
                            .ForEach(caminhao => Console.WriteLine(caminhao));
                        break;
                    case 5:
                        controller.FindAll()
                            .Select(caminhao => $"{caminhao.Id} - {controller.TotalDeFrete(caminhao.Id)}")
                            .ToList()
                            .ForEach(caminhao => Console.WriteLine(caminhao));
                        break;
                    case 6:
                        controller.FindAll()
                            .Select(caminhao => $"{caminhao.Id} - {controller.TotalDeRotas(caminhao.Id)}")
                            .ToList()
                            .ForEach(caminhao => Console.WriteLine(caminhao));
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (opt != 0);
        }
    }

}