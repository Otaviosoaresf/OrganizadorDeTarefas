using ConsoleApp1.Banco;
using ConsoleApp1.Contextos;
using ConsoleApp1.Menu;

var context = new TarefasContext();
var tarefaDAL = new TarefaDAL(context);
Menu menu = new Menu();


while (true)
{
    Console.WriteLine("==========================");
    Console.WriteLine("= Organizador de tarefas =");
    Console.WriteLine("==========================\n\n");

    Thread.Sleep(1000);
    Console.WriteLine("Seja bem-vindo!");
    Console.WriteLine("Selecione a opção abaixo desejada..\n\n");
    Console.WriteLine("Opção 1: Adicionar nova tarefa para a lista...");
    Console.WriteLine("Opção 2: Listar tarefas...");
    Console.WriteLine("Opção 3: Remover tarefa...");
    Console.WriteLine("Opção 4: Marcar tarefa como concluida...");
    Console.WriteLine("Opção 5: Sair do sistema...");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1": menu.Opcao1(tarefaDAL);
            break;

        case "2": menu.Opcao2(tarefaDAL);
            break;

        case "3": menu.Opcao3(tarefaDAL);
            break;

        case "4": menu.Opcao4(tarefaDAL);
            break;

        case "5":
            Console.WriteLine("Saindo do sistema... até uma próxima!");
            Thread.Sleep(3000);
            return;

        default:
            Console.WriteLine("Digite uma opção válida...");
            Thread.Sleep(2000);
            Console.Clear();
            break;

    }
}

