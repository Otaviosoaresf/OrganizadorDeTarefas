using ConsoleApp1.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Contextos
{
    internal class TarefasContext: DbContext
    {
        string stringDeConexaoDb = "Data Source=(localdb)" +
            "\\MSSQLLocalDB;Initial Catalog=Tarefas;Integrated Security=True;" +
            "Encrypt=False;Trust Server Certificate=False;" +
            "Application Intent=ReadWrite;Multi Subnet Failover=False";

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(stringDeConexaoDb);
        }
    }
}
