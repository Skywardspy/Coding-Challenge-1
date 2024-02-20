using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Challenge_1
{
    internal class Operations
    {
        

        /// <summary>
        /// Função que trata e processa os inputs
        /// </summary>
        /// <param name="inputs"> Operações enviadas pelo utilizador </param>
        /// <returns> Devolve o acumulador final </returns>
        public static double Process(List<string> inputs)
        {
            double accumulator = 0;
            List<double> resultQueue = new List<double>();
            bool successfullOperation;

            for (int cont = 0; cont < inputs.Count; cont++)
            {
                switch (inputs[cont])
                {
                    case "PUSH": 
                        if (cont == inputs.Count - 1)
                        {
                            throw new Exception("Operação PUSH não pode ser a ultima operação");
                        }
                        accumulator = Push(resultQueue, inputs[cont+1]);
                        cont++;
                        break;

                    case "ADD":
                        accumulator = Add(resultQueue);
                        break;

                    case "SUB":
                        accumulator = Subtract(resultQueue);
                        break;

                    case "MUL":
                        accumulator = Multiply(resultQueue);
                        break;

                    case "DIV":
                        accumulator = Divide(resultQueue);
                        break;

                    case "DUP":
                        Duplicate(resultQueue);
                        break;

                    case "POP":
                        Pop(resultQueue);
                        break;

                    case "SWAP":
                        Swap(resultQueue);
                        break;

                    default:
                        throw new Exception($"{inputs[cont]} não é uma operação válida");
                }
            }

            return accumulator;
        }

        /// <summary>
        /// Operação PUSH - adiciona o valor recebido ao final da lista de resultados
        /// </summary>
        /// <param name="resultQueue"> Lista de resultados </param>
        /// <param name="value"> Valor a adicionar à lista </param>
        /// <returns> Devolve o acumulador </returns>
        private static double Push(List<double> resultQueue, string value)
        {
            double treatedValue;

            // Tenta converter a string enviada para um double e caso não consiga atira uma exceção
            if (!double.TryParse(value, out treatedValue))
            {
                throw new Exception("Operação PUSH tem de ser seguida por um número");
            }

            resultQueue.Add(treatedValue);
            
            // Guarda o valor adicionado no acumulador
            return treatedValue;
        }

        /// <summary>
        /// Operação ADD - soma os dois ultimos valores da lista 
        /// </summary>
        /// <param name="resultQueue"> Lista de resultados </param>
        /// <returns> Devolve o valor do acumulador </returns>
        private static double Add(List<double> resultQueue)
        {
            double addResult;
            int resultLastIndex = resultQueue.Count - 1; // Guarda o último index da lista (para só se aceder á contagem da lista uma vez)

            // Valida se a lista tem 2 ou mais números para poder fazer a soma
            if (resultQueue.Count < 2)
            {
                throw new Exception("Operação ADD requer dois ou mais números na fila");
            }

            // Soma os ultimos valores da lista
            addResult = resultQueue[resultLastIndex] + resultQueue[resultLastIndex - 1];

            // Remove os valores usados na soma
            resultQueue.RemoveRange(resultLastIndex - 1, 2);

            // Adiciona o valor da soma ao final da lista
            resultQueue.Add(addResult);

            // Guarda o valor da soma no acumulador
            return addResult;
        }

        /// <summary>
        /// Operação SUB - subtrai os dois ultimos valores da lista (a começar pelo último valor)
        /// </summary>
        /// <param name="resultQueue"> Lista de resultados </param>
        private static double Subtract(List<double> resultQueue)
        {
            double subResult;
            int resultLastIndex = resultQueue.Count - 1; // Guarda o último index da lista (para só se aceder á contagem da lista uma vez)

            // Valida se a lista tem 2 ou mais números para poder fazer a subtração
            if (resultQueue.Count < 2)
            {
                throw new Exception("Operação SUB requer dois ou mais números na fila");
            }

            // Subtrai os ultimos valores da lista
            subResult = resultQueue[resultLastIndex] - resultQueue[resultLastIndex - 1];

            // Remove os valores usados na subtração
            resultQueue.RemoveRange(resultLastIndex - 1, 2);

            // Adiciona o valor da subtração ao final da lista
            resultQueue.Add(subResult);

            // Guarda o valor da subtração no acumulador
            return subResult;
        }

        /// <summary>
        /// Operação MUL - multiplica os dois ultimos valores da lista
        /// </summary>
        /// <param name="resultQueue"> Lista de resultados </param>
        private static double Multiply(List<double> resultQueue)
        {
            double mulResult;
            int resultLastIndex = resultQueue.Count - 1; // Guarda o último index da lista (para só se aceder á contagem da lista uma vez)

            // Valida se a lista tem 2 ou mais números para poder fazer a multiplicação
            if (resultQueue.Count < 2)
            {
                throw new Exception("Operação MUL requer dois ou mais números na fila");
            }

            // Multiplica os ultimos valores da lista
            mulResult = resultQueue[resultLastIndex] * resultQueue[resultLastIndex - 1];

            // Remove os valores usados na multiplicação
            resultQueue.RemoveRange(resultLastIndex - 1, 2);

            // Adiciona o valor da multiplicação ao final da lista
            resultQueue.Add(mulResult);

            // Guarda o valor da multiplicação no acumulador
            return mulResult;
        }

        /// <summary>
        /// Operação DIV - divide os dois ultimos valores da lista (a começar pelo último valor)
        /// </summary>
        /// <param name="resultQueue"> Lista de resultados </param>
        private static double Divide(List<double> resultQueue)
        {
            double divResult;
            int resultLastIndex = resultQueue.Count - 1; // Guarda o último index da lista (para só se aceder á contagem da lista uma vez)

            // Valida se a lista tem 2 ou mais números para poder fazer a divisão
            if (resultQueue.Count < 2)
            {
                throw new Exception("Operação MUL requer dois ou mais números na fila");
            }

            // Divide os ultimos valores da lista
            divResult = resultQueue[resultLastIndex] / resultQueue[resultLastIndex - 1];

            // Remove os valores usados na divisão
            resultQueue.RemoveRange(resultLastIndex - 1, 2);

            // Adiciona o valor da divisão ao final da lista
            resultQueue.Add(divResult);

            // Guarda o valor da divisão no acumulador
            return divResult;
        }

        /// <summary>
        /// Operação DUP - duplica o ultimo valor da lista
        /// </summary>
        /// <param name="resultQueue"> Lista de resultados </param>
        private static void Duplicate(List<double> resultQueue)
        {
            // Valida se a lista tem 1 ou mais números
            if (resultQueue.Count < 1)
            {
                throw new Exception("Operação DUP requer pelo menos um número na fila");
            }

            // Adiciona ao final da lista o último valor da lista
            resultQueue.Add(resultQueue.Last());
        }

        /// <summary>
        /// Operação POP - remove o ultimo valor da lista
        /// </summary>
        /// <param name="resultQueue"> Lista de resultados </param>
        private static void Pop(List<double> resultQueue)
        {
            // Valida se a lista tem 1 ou mais números
            if (resultQueue.Count < 1)
            {
                throw new Exception("Operação POP requer pelo menos um número na fila");
            }

            // Remove o último valor da lista
            resultQueue.RemoveAt(resultQueue.Count - 1);
        }

        /// <summary>
        /// Operação SWAP - inverte a posição dos dois últimos valores da lista
        /// </summary>
        /// <param name="resultQueue"> Lista de resultados </param>
        private static void Swap(List<double> resultQueue)
        {
            double aux = 0;
            int resultLastIndex = resultQueue.Count - 1; // Guarda o último index da lista (para só se aceder á contagem da lista uma vez)

            // Valida se a lista tem 2 ou mais números para poder realizar a inversão
            if (resultQueue.Count < 2)
            {
                throw new Exception("Operação SWAP requer dois ou mais números na fila");
            }

            // Guarda o último valor da lista numa variável auxiliar
            aux = resultQueue.Last();

            // Insere o penúltimo valor no último lugar e depois insere o valor auxiliar no penúltimo lugar
            resultQueue[resultLastIndex] = resultQueue[resultLastIndex - 1];
            resultQueue[resultLastIndex - 1] = aux;
        }
    }

}
