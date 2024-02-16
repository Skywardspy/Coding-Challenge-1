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
        /// <returns></returns>
        public static string Process(List<string> inputs)
        {
            List<int> resultQueue = new List<int>();
            bool successfullOperation;

            for (int cont = 0; cont < inputs.Count; cont++)
            {
                switch (inputs[cont])
                {
                    case "PUSH": 
                        successfullOperation = Push(resultQueue, inputs[cont + 1]);
                        cont = successfullOperation ? cont + 1 : cont;
                        break;
                }
            }

            return String.Join(' ', resultQueue);
        }

        /// <summary>
        /// Operação PUSH - adiciona o valor recebido ao final da lista de resultados
        /// </summary>
        /// <param name="resultQueue"> Lista de resultados </param>
        /// <param name="value"> Valor a adicionar à lista </param>
        private static bool Push(List<int> resultQueue, string value)
        {
            int treatedValue;

            bool success = int.TryParse(value, out treatedValue);

            if (success)
            {
                resultQueue.Add(treatedValue);
            }

            return success;
        }

        /// <summary>
        /// Operação ADD - soma os dois ultimos valores da lista 
        /// </summary>
        /// <param name="resultQueue"> Lista de resultados </param>
        private static void Add(int[] resultQueue)
        {
            
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
