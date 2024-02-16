namespace Coding_Challenge_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> treatedInput;

            // Valida se o programa foi iniciado com ou sem parametros de entrada
            if (args.Length == 0)
            {
                string? userInput;

                Console.WriteLine("Insira a string de operações");
                userInput = Console.ReadLine();

                treatedInput = userInput.Split(' ').ToList();
            } 
            else
            {
                treatedInput = args.ToList();
            }

            try
            {
                // Processa as operações
                double result = Operations.Process(treatedInput);

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
        
    }

}

