using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;

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
            Console.WriteLine("Target: Database");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            ILogger logger = kernel.Get<DatabaseLogger>();
            logger.Write("teste");
            Console.Read();
        }
    }
}
