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
                        Push(resultQueue, inputs[cont+1]);
                        cont++;
                        break;

                    case "ADD":

                        accumulator = Add(resultQueue);

                        break;
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
            int resultLastIndex = resultQueue.Count - 1;

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
        /// Operação SUB - subtrai os dois ultimos valores da lista
        /// </summary>
        /// <param name="resultQueue"> Lista de resultados </param>
        private static void Subtract(int[] resultQueue)
        {
            
        }

        /// <summary>
        /// Operação MUL - multiplica os dois ultimos valores da lista
        /// </summary>
        /// <param name="resultQueue"> Lista de resultados </param>
        private static void Multiply(int[] resultQueue)
        {
            
        }

        /// <summary>
        /// Operação DIV - divide os dois ultimos valores da lista
        /// </summary>
        /// <param name="resultQueue"> Lista de resultados </param>
        private static void Divide(int[] resultQueue)
        {
            
        }

        /// <summary>
        /// Operação DUP - duplica o ultimo valor da lista
        /// </summary>
        /// <param name="resultQueue"> Lista de resultados </param>
        private static void Duplicate(int[] resultQueue)
        {
            
        }

        /// <summary>
        /// Operação POP - remove o ultimo valor da lista
        /// </summary>
        /// <param name="resultQueue"> Lista de resultados </param>
        private static void Pop(int[] resultQueue)
        {
            
        }

        /// <summary>
        /// Operação SWAP - inverte a posição dos dois últimos valores da lista
        /// </summary>
        /// <param name="resultQueue"> Lista de resultados </param>
        private static void Swap(int[] resultQueue)
        {
            
        }
    }

}
