using ConsoleApp1.Banco;
using ConsoleApp1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Menu
{

    // Aqui ficam as opções do menu....

    internal class Menu
    {
        public void Opcao1(TarefaDAL tarefaDAL)
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("= Adicionar nova tarefa... =");
            Console.WriteLine("============================\n\n");

            Console.WriteLine("Bora adicionar uma nova tarefa...\n");
            Console.WriteLine("Digite primeiro o titulo da tarefa...");
            string nomeTarefa = Console.ReadLine();
            Console.WriteLine("\nAgora adicione a descrição da tarefa...");
            string descricao = Console.ReadLine();
            bool tarefaFinalizada = false;
            Tarefa novaTarefa = new Tarefa(nomeTarefa, descricao, tarefaFinalizada);
            Thread.Sleep(2000);


            Console.WriteLine("\n..... tarefa sendo adicionada .....\n");
            tarefaDAL.AdicionarTarefa(novaTarefa);
            Console.WriteLine("\nTarefa adicionada com sucesso ao BD...");
            Thread.Sleep(2000);
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal...");
            Console.ReadKey();
            Console.Clear();
        }

        public void Opcao2(TarefaDAL tarefaDAL)
        {
            Console.Clear();
            Console.WriteLine("=====================");
            Console.WriteLine("= Listar tarefas... =");
            Console.WriteLine("=====================\n\n");

            var listaTarefas = tarefaDAL.ListarTarefas();
            foreach (var item in listaTarefas)
            {
                Console.WriteLine("=========================================================");
                Console.WriteLine($"Nome Tarefa: {item.NomeTarefa}"); 
                Console.WriteLine($"Descrição: {item.Descricao}");
                Console.WriteLine($"Id da tarefa: {item.Id}");
                Console.WriteLine("=========================================================\n");
            }
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
        }

        public void Opcao3(TarefaDAL tarefaDAL)
        {
            while(true)
            {

                Console.Clear();
                Console.WriteLine("======================");
                Console.WriteLine("= Remover tarefas... =");
                Console.WriteLine("======================\n\n");

                Console.WriteLine("Digite o ID da tarefa que deseja apagar...");
                string idString = Console.ReadLine();
                int idInt;
                int.TryParse(idString, out idInt);

                if (idInt == 0)
                {
                    Console.WriteLine("Dgite um Id válido...");
                    Thread.Sleep(2000);
                    continue;
                }

                Console.WriteLine("\n...Buscando tarefa no banco de dados, aguarde...");
                var listaTarefas = tarefaDAL.ListarTarefas();
                
                foreach (var item in listaTarefas)
                {  
                    if(item.Id == idInt)
                    {
                        Console.WriteLine("Deseja excluir a tarefa abaixo ?\n");
                        Console.WriteLine("=========================================================");
                        Console.WriteLine($"Nome Tarefa: {item.NomeTarefa}");
                        Console.WriteLine($"Descrição: {item.Descricao}");
                        Console.WriteLine("=========================================================\n");

                        Console.WriteLine("Digite 1 para excluir e qualquer outro caracter para voltar...");
                        string exclui = Console.ReadLine();

                        if(exclui == "1")
                        {
                            Console.WriteLine("Removendo tarefa, aguarde....");
                            tarefaDAL.RemoverTarefa(item);
                            Console.WriteLine("Tarefa removida com sucesso...");
                            Thread.Sleep(2000);
                            Console.Clear();
                            return;
                        }
                        Console.Clear();
                        return;
                    }   
                }

                Console.WriteLine("Tarefa não encontrada...");
                Console.WriteLine("\nPara voltar ao menu principal, digite 0...");
                string opcao = Console.ReadLine();
                if (opcao == "0")
                {
                    Console.WriteLine("...Voltando ao menu principal...");
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;
                }
                continue;

            }

        }

        public void Opcao4(TarefaDAL tarefaDAL)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("================================");
                Console.WriteLine("= Marcar tarefas concluidas... =");
                Console.WriteLine("================================\n\n");

                Console.WriteLine("Digite o id da tarefa que deseja concluir...");
                string idString = Console.ReadLine();
                int idInt;
                int.TryParse(idString, out idInt);

                if (idInt == 0)
                {
                    Console.WriteLine("Dgite um Id válido...");
                    Thread.Sleep(2000);
                    continue;
                }

                Console.WriteLine("\n\nBuscando tarefa no banco de dados, aguarde.....");
                var tarefaBuscada = tarefaDAL.EncontraTarefaPorID(idInt);

                if (tarefaBuscada == null)
                {
                    Console.WriteLine("\nTarefa não encontrada...");
                    Thread.Sleep(2000);
                    continue;
                }

                Console.WriteLine("\nDeseja marcar a tarefa abaixo como concluida ?\n");
                Console.WriteLine("=========================================================");
                Console.WriteLine($"Nome Tarefa: {tarefaBuscada.NomeTarefa}");
                Console.WriteLine($"Descrição: {tarefaBuscada.Descricao}");
                Console.WriteLine("=========================================================\n");
                Console.WriteLine("Digite 1 para concluir...");
                Console.WriteLine("Ou qualquer outro caracter para voltar...");
                string opcao = Console.ReadLine();
                if(opcao == "1")
                {
                    tarefaDAL.ConcluirTarefa(tarefaBuscada);
                    Console.WriteLine("\n\nTarefa concluida com sucesso...");
                    Thread.Sleep(3000);
                    Console.Clear();
                    break;
                }
                continue;
            }
            
        }

    }
}
