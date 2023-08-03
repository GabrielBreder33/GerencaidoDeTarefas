using System;
using System.Collections.Generic;

namespace GerenciadorTarefas
{
    class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
    }

    enum Priority
    {
        Low,
        Medium,
        High
    }

    class Program
    {
        static List<Task> tasks = new List<Task>();
        static int taskIdCounter = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao Gerenciador de Tarefas!");

            while (true)
            {
                Console.WriteLine("\nSelecione uma opção:");
                Console.WriteLine("1. Listar tarefas");
                Console.WriteLine("2. Adicionar tarefa");
                Console.WriteLine("3. Editar tarefa");
                Console.WriteLine("4. Excluir tarefa");
                Console.WriteLine("5. Sair");

                int opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        ListarTarefas();
                        break;
                    case 2:
                        AdicionarTarefa();
                        break;
                    case 3:
                        EditarTarefa();
                        break;
                    case 4:
                        ExcluirTarefa();
                        break;
                    case 5:
                        Console.WriteLine("Obrigado por usar o Gerenciador de Tarefas. Até logo!");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void ListarTarefas()
        {
            Console.WriteLine("\nTarefas:");

            if (tasks.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa encontrada.");
            }
            else
            {
                foreach (var task in tasks)
                {
                    Console.WriteLine($"ID: {task.Id}, Descrição: {task.Description}, Data de Vencimento: {task.DueDate.ToString("dd/MM/yyyy")}, Prioridade: {task.Priority}");
                }
            }
        }

        static void AdicionarTarefa()
        {
            Console.WriteLine("\nAdicionar Tarefa:");

            Console.WriteLine("Digite a descrição da tarefa:");
            string description = Console.ReadLine();

            Console.WriteLine("Digite a data de vencimento da tarefa (dd/mm/aaaa):");
            DateTime dueDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Console.WriteLine("Digite a prioridade da tarefa (Low, Medium, High):");
            Priority priority = (Priority)Enum.Parse(typeof(Priority), Console.ReadLine(), true);

            tasks.Add(new Task
            {
                Id = taskIdCounter++,
                Description = description,
                DueDate = dueDate,
                Priority = priority
            });

            Console.WriteLine("Tarefa adicionada com sucesso!");
        }

        static void EditarTarefa()
        {
            Console.WriteLine("\nEditar Tarefa:");

            Console.WriteLine("Digite o ID da tarefa que deseja editar:");
            int id = Convert.ToInt32(Console.ReadLine());

            Task taskToEdit = tasks.Find(task => task.Id == id);

            if (taskToEdit == null)
            {
                Console.WriteLine("Tarefa não encontrada.");
            }
            else
            {
                Console.WriteLine("Digite a nova descrição da tarefa:");
                taskToEdit.Description = Console.ReadLine();

                Console.WriteLine("Digite a nova data de vencimento da tarefa (dd/mm/aaaa):");
                taskToEdit.DueDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                Console.WriteLine("Digite a nova prioridade da tarefa (Low, Medium, High):");
                taskToEdit.Priority = (Priority)Enum.Parse(typeof(Priority), Console.ReadLine(), true);

                Console.WriteLine("Tarefa editada com sucesso!");
            }
        }

        static void ExcluirTarefa()
        {
            Console.WriteLine("\nExcluir Tarefa:");

            Console.WriteLine("Digite o ID da tarefa que deseja excluir:");
            int id = Convert.ToInt32(Console.ReadLine());

            Task taskToDelete = tasks.Find(task => task.Id == id);

            if (taskToDelete == null)
            {
                Console.WriteLine("Tarefa não encontrada.");
            }
            else
            {
                tasks.Remove(taskToDelete);
                Console.WriteLine("Tarefa excluída com sucesso!");
            }
        }
    }
}