namespace Coding_Challenge_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] treatedInput;

            // Valida se o programa foi iniciado com ou sem parametros de entrada
            if (args.Length == 0)
            {
                string? userInput;

                Console.WriteLine("Insira a string de operações");
                userInput = Console.ReadLine();

                treatedInput = userInput.Split(' ');
            } 
            else
            {
                treatedInput = args;
            }

            // Processa as operações
            Operations.Process(treatedInput);
        }
        
    }

}

