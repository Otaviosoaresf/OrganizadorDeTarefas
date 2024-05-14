using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Modelos
{
    internal class Tarefa
    {
        public int Id { get; set; }
        public string NomeTarefa { get; set; }
        public string Descricao { get; set; }

        public bool TarefaFinalizada { get; set; }

        public Tarefa(string nomeTarefa, string descricao, bool tarefaFinalizada)
        {
            NomeTarefa = nomeTarefa;
            Descricao = descricao;
            TarefaFinalizada = tarefaFinalizada;
        }
    }
}
