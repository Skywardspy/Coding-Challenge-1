using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Challenge_1
{
    public class Log
    {
        private string? message { get; set; }
        private string operationType { get; set; }
        private LogType logType { get; set; }
        private string? operationDescription { get; set; }
        private string? listResult { get; set; }
        private double accumulator {  get; set; }

        public Log(string operationType, LogType logType, string? message, double accumulator)
        {
            this.message = message;
            this.operationType = operationType;
            this.logType = logType;
            this.accumulator = accumulator;
        }

        public Log(string operationType, LogType logType, string? message, string? operationDescription, string? listResult, double accumulator)
        {
            this.message = message;
            this.operationType = operationType;
            this.logType = logType;
            this.operationDescription = operationDescription;
            this.listResult = listResult;
            this.accumulator = accumulator;
        }

        /// <summary>
        /// Trata da formatação das strings e da consola para apresentar os logs
        /// </summary>
        public void PrintLog()
        {
            string formattedString = String.Empty;
            
            Console.Write($" Operação \"{operationType}\":");
            
            switch(this.logType)
            {
                // Se o tipo de log for de "Warning" muda a cor do texto para amarelo e mostra a mensagem do log
                case LogType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($" {message}");
                    break;

                // Se o tipo de log for de "Error" muda a cor do texto para vermelho e mostra a mensagem do log
                case LogType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" {message}");
                    break;

                // Se o tipo de log for de "Regular" apenas muda de linha
                case LogType.Regular:
                    Console.WriteLine();
                    break;
                
                default:
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Gray;

            // Se o log tiver a descrição da operação imprime-a na consola
            if (!String.IsNullOrWhiteSpace(operationDescription))
            {
                Console.WriteLine($"  Efeito: {operationDescription}");
            }

            // Se o log tiver a lista de resultados imprime-a na consola
            if (listResult?.Count() > 0)
            {
                Console.WriteLine($"  Fila: {listResult}");
            }
            
            Console.WriteLine($"  Acumulador: {accumulator}");
        }
    }

    public enum LogType { Warning, Error, Regular }
}
