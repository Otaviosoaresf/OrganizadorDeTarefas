using ConsoleApp1.Contextos;
using ConsoleApp1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Banco
{
    // Aqui ficam os métodos que interagem com o banco de dados...

    internal class TarefaDAL
    {
        protected readonly TarefasContext context;

        public TarefaDAL(TarefasContext context)
        {
            this.context = context;
        }

        public IEnumerable<Tarefa> ListarTarefas()
        {
            return context.Tarefas.ToList();
        }

        public void AdicionarTarefa(Tarefa objeto)
        {
            context.Tarefas.Add(objeto);
            context.SaveChanges();
        }

        public void RemoverTarefa(Tarefa objeto)
        {
            context.Tarefas.Remove(objeto);
            context.SaveChanges();
        }

        public Tarefa? EncontraTarefaPorID(int id)
        {
            var tarefa = context.Tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null)
            {
                return null;
            }

            return tarefa;
        }

        public void ConcluirTarefa(Tarefa objeto)
        {
            objeto.TarefaFinalizada = true;

            context.Tarefas.Update(objeto);
            context.SaveChanges();
        }

    }
}
