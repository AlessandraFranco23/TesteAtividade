
namespace Views
{

    public class Cidade
    {
        Controllers.Cidade controller;

        public Cidade(Controllers.Cidade controller)
        {
            this.controller = controller;
        }

        public void Show()
        {
            int opt = 0;
            do
            {
                Console.WriteLine("--- Cidades ---");
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
                        Console.WriteLine("Insira o nome da cidade");
                        string nome = Console.ReadLine();
                        controller.Nova(nome);
                        break;
                    case 2:
                        Console.WriteLine("Insira o id da cidade");
                        int id = Int32.Parse(Console.ReadLine());
                        
                        Console.WriteLine("Insira o novo nome da cidade");
                        nome = Console.ReadLine();

                        controller.Atualizar(id, nome);
                        break;
                    case 3:
                        Console.WriteLine("Insira o id da cidade");
                        id = Int32.Parse(Console.ReadLine());
                        controller.Remover(id);
                        
                        break;
                    case 4:
                        controller.FindAll().Select(cidade => $"{cidade.Id} - {cidade.Nome.Valor}").ToList().ForEach(cidade => Console.WriteLine(cidade));
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (opt != 0);
        }
    }

}