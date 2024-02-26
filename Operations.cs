using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Challenge_1
{
    public class Operations
    {
        public static List<Log> logList = new List<Log>();
        private static double _accumulator = 0;
        public static List<double> resultQueue = new List<double>();

        /// <summary>
        /// Função que trata e processa os inputs
        /// </summary>
        /// <param name="inputs"> Operações enviadas pelo utilizador </param>
        /// <returns> Devolve o acumulador final </returns>
        public static double Process(List<string> inputs)
        {
            logList.Clear();
            resultQueue.Clear();
            _accumulator = 0;
            
            bool successfullOperation;

            for (int cont = 0; cont < inputs.Count; cont++)
            {
                switch (inputs[cont])
                {
                    case "PUSH": 
                        if (cont == inputs.Count - 1)
                        {
                            string error = "Operação PUSH tem de ser seguida por um número";
                            logList.Add(new Log("PUSH", LogType.Warning, error, _accumulator));
                            break;
                        }
                        double? aux = Push(inputs[cont+1]);

                        // No caso do PUSH é preciso validar se o PUSH foi feito com sucesso para saber se o contador salta um digito para a frente (para saltar o index do número)
                        if (aux.HasValue)
                        {
                            _accumulator = aux.Value;
                            cont++;
                        }
                        
                        break;
                    // Caso haja erro é devolvido um null e o ternário garante que o acumulador mantém o seu valor (Aplica-se a todas as operações que alteram o acumulador)
                    case "ADD":
                        _accumulator = Add() ?? _accumulator;
                        break;

                    case "SUB":
                        _accumulator = Subtract() ?? _accumulator;
                        break;

                    case "MUL":
                        _accumulator = Multiply() ?? _accumulator;
                        break;

                    case "DIV":
                        _accumulator = Divide() ?? _accumulator;
                        break;

                    case "DUP":
                        _accumulator = Duplicate() ?? _accumulator;
                        break;

                    case "POP":
                        Pop();
                        break;

                    case "SWAP":
                        Swap();
                        break;

                    default:
                        // Adiciona o erro à lista de logs
                        logList.Add(new Log($"{inputs[cont]}", LogType.Error, "Não é uma operação válida", _accumulator));
                        break;
                }
            }

            return _accumulator;
        }

        /// <summary>
        /// Operação PUSH - adiciona o valor recebido ao final da lista de resultados
        /// </summary>
        /// <param name="value"> Valor a adicionar à lista </param>
        /// <returns> Devolve o acumulador </returns>
        private static double? Push(string value)
        {
            double treatedValue;

            // Tenta converter a string enviada para um double e caso não consiga atira uma exceção
            if (!double.TryParse(value, out treatedValue))
            {
                string error = "Operação PUSH tem de ser seguida por um número";
                logList.Add(new Log($"PUSH {value}", LogType.Warning, error, _accumulator));
                return null;
            }

            resultQueue.Add(treatedValue);

            logList.Add(new Log($"PUSH {value}", LogType.Regular, null, null, String.Join(' ', resultQueue), treatedValue));

            // Guarda o valor adicionado no acumulador
            return treatedValue;
        }

        /// <summary>
        /// Operação ADD - soma os dois ultimos valores da lista 
        /// </summary>
        /// <returns> Devolve o valor do acumulador </returns>
        private static double? Add()
        {
            double addResult;
            int resultLastIndex = resultQueue.Count - 1; // Guarda o último index da lista (para só se aceder á contagem da lista uma vez)

            // Valida se a lista tem 2 ou mais números para poder fazer a soma
            if (resultQueue.Count < 2)
            {
                string error = "Operação ADD requer dois ou mais números na fila";
                logList.Add(new Log("ADD", LogType.Warning, error, _accumulator));
                return null;
            }

            // Soma os ultimos valores da lista
            addResult = resultQueue[resultLastIndex] + resultQueue[resultLastIndex - 1];

            // Guarda a descrição do processo da operação para efeitos de log
            string logOp = $"{resultQueue[resultLastIndex]} + {resultQueue[resultLastIndex - 1]} = {addResult}";
            
            // Remove os valores usados na soma
            resultQueue.RemoveRange(resultLastIndex - 1, 2);

            // Adiciona o valor da soma ao final da lista
            resultQueue.Add(addResult);

            logList.Add(new Log("ADD", LogType.Regular, null, logOp, String.Join(' ', resultQueue), addResult));

            // Guarda o valor da soma no acumulador
            return addResult;
        }

        /// <summary>
        /// Operação SUB - subtrai os dois ultimos valores da lista (a começar pelo último valor)
        /// </summary>
        private static double? Subtract()
        {
            double subResult;
            int resultLastIndex = resultQueue.Count - 1; // Guarda o último index da lista (para só se aceder á contagem da lista uma vez)

            // Valida se a lista tem 2 ou mais números para poder fazer a subtração
            if (resultQueue.Count < 2)
            {
                string error = "Operação SUB requer dois ou mais números na fila";
                logList.Add(new Log("SUB", LogType.Warning, error, _accumulator));
                return null;
            }

            // Subtrai os ultimos valores da lista
            subResult = resultQueue[resultLastIndex] - resultQueue[resultLastIndex - 1];

            // Guarda a descrição do processo da operação para efeitos de log
            string logOp = $"{resultQueue[resultLastIndex]} - {resultQueue[resultLastIndex - 1]} = {subResult}";
            
            // Remove os valores usados na subtração
            resultQueue.RemoveRange(resultLastIndex - 1, 2);

            // Adiciona o valor da subtração ao final da lista
            resultQueue.Add(subResult);

            logList.Add(new Log("SUB", LogType.Regular, null, logOp, String.Join(' ', resultQueue), subResult));

            // Guarda o valor da subtração no acumulador
            return subResult;
        }

        /// <summary>
        /// Operação MUL - multiplica os dois ultimos valores da lista
        /// </summary>
        private static double? Multiply()
        {
            double mulResult;
            int resultLastIndex = resultQueue.Count - 1; // Guarda o último index da lista (para só se aceder á contagem da lista uma vez)

            // Valida se a lista tem 2 ou mais números para poder fazer a multiplicação
            if (resultQueue.Count < 2)
            {
                string error = "Operação MUL requer dois ou mais números na fila";
                logList.Add(new Log("MUL", LogType.Warning, error, _accumulator));
                return null;
            }

            // Multiplica os ultimos valores da lista
            mulResult = resultQueue[resultLastIndex] * resultQueue[resultLastIndex - 1];

            // Guarda a descrição do processo da operação para efeitos de log
            string logOp = $"{resultQueue[resultLastIndex]} * {resultQueue[resultLastIndex - 1]} = {mulResult}";

            // Remove os valores usados na multiplicação
            resultQueue.RemoveRange(resultLastIndex - 1, 2);

            // Adiciona o valor da multiplicação ao final da lista
            resultQueue.Add(mulResult);

            logList.Add(new Log("MUL", LogType.Regular, null, logOp, String.Join(' ', resultQueue), mulResult));

            // Guarda o valor da multiplicação no acumulador
            return mulResult;
        }

        /// <summary>
        /// Operação DIV - divide os dois ultimos valores da lista (a começar pelo último valor)
        /// </summary>
        private static double? Divide()
        {
            double divResult;
            int resultLastIndex = resultQueue.Count - 1; // Guarda o último index da lista (para só se aceder á contagem da lista uma vez)

            // Valida se a lista tem 2 ou mais números para poder fazer a divisão
            if (resultQueue.Count < 2)
            {
                string error = "Operação DIV requer dois ou mais números na fila";
                logList.Add(new Log("DIV", LogType.Warning, error, _accumulator));
                return null;
            }

            // Valida se está a fazer um divisão por 0
            if (resultQueue[resultLastIndex-1] == 0)
            {
                string error = "Operação DIV não pode dividir por 0";
                logList.Add(new Log("DIV", LogType.Warning, error, _accumulator));
                return null;
            }

            // Divide os ultimos valores da lista
            divResult = resultQueue[resultLastIndex] / resultQueue[resultLastIndex - 1];

            // Guarda a descrição do processo da operação para efeitos de log
            string logOp = $"{resultQueue[resultLastIndex]} / {resultQueue[resultLastIndex - 1]} = {divResult}";

            // Remove os valores usados na divisão
            resultQueue.RemoveRange(resultLastIndex - 1, 2);

            // Adiciona o valor da divisão ao final da lista
            resultQueue.Add(divResult);

            logList.Add(new Log("DIV", LogType.Regular, null, logOp, String.Join(' ', resultQueue), divResult));

            // Guarda o valor da divisão no acumulador
            return divResult;
        }

        /// <summary>
        /// Operação DUP - duplica o ultimo valor da lista
        /// </summary>
        private static double? Duplicate()
        {
            // Valida se a lista tem 1 ou mais números
            if (resultQueue.Count < 1)
            {
                string error = "Operação DUP requer pelo menos um número na fila";
                logList.Add(new Log("DUP", LogType.Warning, error, _accumulator));
                return null;
            }

            // Guarda o ultimo valor da lista
            double valueToDup = resultQueue.Last();

            // Adiciona o valor a duplicar ao final da lista
            resultQueue.Add(valueToDup);

            logList.Add(new Log("DUP", LogType.Regular, null, null, String.Join(' ', resultQueue), valueToDup));

            return valueToDup;
        }

        /// <summary>
        /// Operação POP - remove o ultimo valor da lista
        /// </summary>
        private static void Pop()
        {
            // Valida se a lista tem 1 ou mais números
            if (resultQueue.Count < 1)
            {
                string error = "Operação POP requer pelo menos um número na fila";
                logList.Add(new Log("POP", LogType.Warning, error, _accumulator));
                return;
            }

            // Remove o último valor da lista
            resultQueue.RemoveAt(resultQueue.Count - 1);

            logList.Add(new Log("POP", LogType.Regular, null, null, String.Join(' ', resultQueue), _accumulator));
            return;
        }

        /// <summary>
        /// Operação SWAP - inverte a posição dos dois últimos valores da lista
        /// </summary>
        private static void Swap()
        {
            double aux = 0;
            int resultLastIndex = resultQueue.Count - 1; // Guarda o último index da lista (para só se aceder á contagem da lista uma vez)

            // Valida se a lista tem 2 ou mais números para poder realizar a inversão
            if (resultQueue.Count < 2)
            {
                string error = "Operação SWAP requer dois ou mais números na fila";
                logList.Add(new Log("SWAP", LogType.Warning, error, _accumulator));
                return;
            }

            // Guarda o último valor da lista numa variável auxiliar
            aux = resultQueue.Last();

            // Guarda a descrição do processo da operação para efeitos de log
            string logOp = $"{resultQueue[resultLastIndex]} <-> {resultQueue[resultLastIndex - 1]}";

            // Insere o penúltimo valor no último lugar e depois insere o valor auxiliar no penúltimo lugar
            resultQueue[resultLastIndex] = resultQueue[resultLastIndex - 1];
            resultQueue[resultLastIndex - 1] = aux;

            logList.Add(new Log("SWAP", LogType.Regular, null, logOp, String.Join(' ', resultQueue), _accumulator));
            return;
        }
    }

}
