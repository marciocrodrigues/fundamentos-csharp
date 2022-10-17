using System;
using System.Threading;

namespace FundamentosCronometro
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("S = Segundos => 10s = 10 segundos");
            Console.WriteLine("M = Minuto => 1m = 1 minuto");
            Console.WriteLine("0 = Sair");
            Console.WriteLine("Quanto tempo deseja contar?");

            string data = Console.ReadLine().ToLower();
            char tipo = char.Parse(data.Substring(data.Length - 1, 1));
            int tempo = data.Length > 1
                ? int.Parse(data.Substring(0, data.Length - 1))
                : int.Parse(data);
            SelecionarOpcao(tipo, tempo);
        }

        static void SelecionarOpcao(char tipo, int tempo)
        {

            switch (tipo)
            {
                case 'm':
                    PreStart(tempo * 60);
                    break;
                case 's':
                    PreStart(tempo);
                    break;
                case '0':
                    Environment.Exit(0);
                    break;
                default:
                    Menu();
                    break;
            }
        }

        static void PreStart(int tempo)
        {
            Console.Clear();
            Console.WriteLine("Preparar...");
            Thread.Sleep(1000);
            Console.WriteLine("Preparar...");
            Thread.Sleep(1000);
            Console.WriteLine("Começar...");
            Thread.Sleep(2500);

            Start(tempo);
        }

        static void Start(int time)
        {
            int currentTime = 0;

            while (currentTime != time)
            {
                Console.Clear();
                currentTime++;
                Console.WriteLine(currentTime);
                Thread.Sleep(1000);
            }

            Console.Clear();
            Console.WriteLine("Cronômetro finalizado");
            Thread.Sleep(2500);
            Menu();
        }
    }
}