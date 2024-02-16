namespace Coding_Challenge_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> treatedInput = new List<string>();

            // Valida se o programa foi iniciado com ou sem parametros de entrada
            if (args.Length == 0)
            {
                Console.WriteLine("Insira a string de operações");

                string userInput = Console.ReadLine() ?? "";

                treatedInput = userInput.Split(' ').ToList();
            } 
            else
            {
                treatedInput = args.ToList();
            }

            try
            {
                // Processa as operações
                string result = Operations.Process(treatedInput);

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
        
    }

}

