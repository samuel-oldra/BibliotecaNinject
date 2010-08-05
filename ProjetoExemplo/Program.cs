using Ninject;
using System;

namespace ProjetoExemplo
{
    public interface ILogger
    {
        void Write(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public ConsoleLogger(DatabaseLogger data)
        {
            data.Write("Instanciou por mágica!");
        }

        public void Write(string message)
        {
            Console.WriteLine(String.Format("Message: {0}", message));
            Console.WriteLine("Target: ConsoleLogger");
        }
    }

    public class DatabaseLogger : ILogger
    {
        public void Write(string message)
        {
            Console.WriteLine(String.Format("Message: {0}", message));
            Console.WriteLine("Target: DatabaseLogger");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();

            ILogger logger_d = kernel.Get<DatabaseLogger>();
            logger_d.Write("Teste Write DatabaseLogger");

            Console.WriteLine();

            ILogger logger_c = kernel.Get<ConsoleLogger>();
            logger_c.Write("Teste Write ConsoleLogger");

            Console.Read();
        }
    }
}