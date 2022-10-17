using System;

namespace FundamentosException
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[3];

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(arr[i]);
                }

                Salvar(null);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Não encontrei o indice na lista");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Falha ao cadastrar o texto");
            }
            catch (MinhaException ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.QuandoAconteceu);
                Console.WriteLine("Exceção customizada");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Deu erro");
            }
            finally
            {
                Console.WriteLine("Chegou ao fim");
            }
        }

        private static void Salvar(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                throw new MinhaException(DateTime.Now, "texto não pdoe ser nulo ou vazio");
        }
    }

    public class MinhaException : Exception
    {
        public MinhaException(DateTime data, string mensagem)
            : base(mensagem)
        {
            QuandoAconteceu = data;
        }

        public DateTime QuandoAconteceu { get; set; }
    }
}

 