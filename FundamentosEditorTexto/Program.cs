using System;
using System.IO;

namespace FundamentosEditorTexto
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
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar um novo arquivo");
            Console.WriteLine("0 - Sair");
            short opcao = short.Parse(Console.ReadLine());

            SelecionarOpcao(opcao);
        }

        static void SelecionarOpcao(short opcao)
        {
            switch (opcao)
            {
                case 0: Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }
        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual caminho do arquivo?");
            string caminho = Console.ReadLine();

            using (var arquivo = new StreamReader(caminho))
            {
                string texto = arquivo.ReadToEnd();
                Console.WriteLine(texto);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();

        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("---------------");
            string texto = "";

            do
            {
                texto += Console.ReadLine();
                texto += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(texto);
        }

        static void Salvar(string texto)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            var caminho = Console.ReadLine();

            using (var arquivo = new StreamWriter(caminho))
            {
                arquivo.Write(texto);
            }

            Console.WriteLine($"Arquivo {caminho} salvo com sucesso");
            Console.ReadLine();
            Menu();
        }
    }
}

