namespace Coding_Challenge_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Muda o encoding da consola para mostrar caracteres especiais
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<string> treatedInput = new List<string>();

            try
            {
                Console.WriteLine("Operações disponíveis:\n" +
                    " PUSH X: Empurra o valor X para a queue\n" +
                    " ADD: Adiciona os dois valores no topo da queue e empurra o resultado de volta\n" +
                    " SUB: Subtrai o valor no topo da queue do próximo valor e empurra o resultado de volta\n" +
                    " MUL: Multiplica os dois valores no topo da queue e empurra o resultado de volta\n" +
                    " DIV: Divide o valor no topo da queue pelo próximo valor e empurra o resultado de volta\n" +
                    " DUP: Duplica o valor no topo da queue.\n" +
                    " POP: Remove o valor no topo da queue\n" +
                    " SWAP: Inverte a posição dos dois valores no topo da queue\n\n");

                while (true)
                {
                    bool hasLog = false;

                    if (treatedInput.Count == 0)
                    {
                        Console.WriteLine("Insira a string de operações: ");

                        string? userInput = Console.ReadLine();

                        // Caso o utilizador não insira texto nenhum ou só espaços o programa vai fechar
                        if (String.IsNullOrWhiteSpace(userInput))
                        {
                            break;
                        }

                        // Valida se o utilizador quer apresentar o log desta string de operações
                        hasLog = userInput.Contains("LOG");

                        // Limpa a string de input e separa as operações para uma lista
                        treatedInput = userInput.Trim().Split(' ').ToList();

                        if (hasLog)
                        {
                            // Remove a palavra LOG para não interferir nas outras operações
                            treatedInput.Remove("LOG");
                        }
                    }

                    // Processa as operações
                    double result = Operations.Process(treatedInput);

                    // Escreve o log de todas as operações caso tenha sido gerada uma lista de logs e o utilizador a queira visualizar
                    if (Operations.logList.Count > 0 && hasLog)
                    {
                        Console.WriteLine("\nLOG: ");
                        for (int cont = 0; cont < Operations.logList.Count; cont++)
                        {
                            Operations.logList[cont].PrintLog();
                        }
                    }
                    
                    Console.WriteLine($"\nResultado Final:\n {result}");

                    treatedInput = new List<string>();
                    Console.WriteLine("\n------------------------------------------------------------------------------");
                    
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                Console.WriteLine("Pressione qualquer tecla para fechar o programa...");
                Console.ReadKey(true);
            }
           
        }
        
    }

}

