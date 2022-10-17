using System;

namespace FundamentosPOO
{
    class Program
    {
        // Para usar delegate, a função que será chamada precisa ter a mesma assinatura, parametros e tipo retorno ou se não tem retorno
        // mas pode ter nomes diferentes
        static void RealizarPagamento(double valor)
        {
            Console.WriteLine($"Pago o valor de {valor}");
        }

        static void AoSalaCheia(object se, EventArgs e)
        {
            Console.WriteLine("Sala lotada");
        }

        static void Main(string[] args)
        {
            // usando using garante que a classe ira ser eliminada da memoria pelo garbage colector
            using (var pCartao = new PagamentoCartao())
            {
                pCartao.Pagar("123456678");
                // Com tipo generico limitando para a classe abstrata Pagamento
                // Todas as classes que herdam de Pagamento, podem ser usadas no metodo salvar
                // pois são Pagamentos tbm
                var dbContext = new DbContext<Pagamento>();
                dbContext.Salvar(pCartao);
            }

            var pessoa = new Pessoa();

            // Upcast tornar uma classe filha do tipo da classe pai
            var pessoaFisica = new PessoaFisica();
            var pessoa2 = (Pessoa)pessoaFisica;

            // Downcast tornar uma classe pai do tipo da classe filha
            pessoa = new PessoaFisica();
            pessoa = new PessoaJuridica();

            // Delegates => anonymous methods
            var pagar = new DelegatePagamento.Pagar(RealizarPagamento);
            pagar(25.00);

            //Events
            var sala = new Sala(2);
            // Liga o evento ao metodo
            sala.SalaCheiaEvent += AoSalaCheia;
            sala.ReservarAcento();
            sala.ReservarAcento();

            // Lista
            // IEnumerable, tipo mais basico
            // IList(List) quando precisa mexer com a lista, como adicionar, remover, alterar entre outros

            Console.WriteLine("Hello World!");
        }
    }


    //Modificadores de acesso
    // private: só é visivel para o escopo da classe
    // protected: só é visivel para o escopo da classe e as que herdam da mesma
    // internal: só é visivel para o escopo do assembly
    // public: é visivel para todas as outras classes
    // classes abstratas não podem ser instanciadas e só herdadas
    public abstract class Pagamento
    {
        // Propriedades
        //tipo complexo já que o Datetime é uma struct
        public DateTime Vencimento { get; set; }

        // tipo complexo
        // todas as classes são tipos complexos
        public Endereco endereco { get; set; }

        // Métodos
        // virtual para permitir a sobescrita do mesmo nas classes que herdarem dessa
        public virtual void Pagar(string numero) { }
    }

    public class PagamentoCartao : Pagamento, IDisposable
    {
        public PagamentoCartao()
        {
            Console.WriteLine("Iniciado a classe");
        }

        public void Dispose()
        {
            Console.WriteLine("Finalizando classe");
        }

        // sobescrita de metodo
        public override void Pagar(string numero)
        {
            Console.WriteLine(numero);
        }
    }
    
    // tipos genericos
    public class DbContext<T> where T : Pagamento
    {
        public void Salvar(T entity)
        {
            
        }
    }

    // Classes estaticas ficam disponiveis na memoria com o inicio da aplicação, por isso não podem ser instanciadas
    public static class Settings
    {
        public static string URL_API { get; set; }
    }


    // Partial class é quando quero dividir em mais de um arquivos para não ter uma classe muito grande
    public partial class Pessoa
    {
        public string Documento { get; set; }
    }

    public partial class Pessoa
    {
        public string Nome { get; set; }
    }

    public class PessoaFisica : Pessoa
    {
        public string Cpf { get; set; }
    }

    public class PessoaJuridica : Pessoa
    {
        public string Cnpj { get; set; }
    }

    public class DelegatePagamento
    {
        public delegate void Pagar(double valor);
    }

    // Tipo Complexo
    public class Endereco
    {
        string Cep;
    }

    // classe para exemplo de events
    public class Sala
    {
        public Sala(int assentos)
        {
            Assentos = assentos;
        }

        private int assentosEmUso = 0;

        public int Assentos { get; set; }

        public void ReservarAcento()
        {
            assentosEmUso++;

            if (assentosEmUso >= Assentos)
            {
                // Evento fechado!
                AoSalaCheia(EventArgs.Empty);
            }
            else
            {
                Console.WriteLine("Assento reservado");
            }
        }

        // Eventos são só assinaturas
        public event EventHandler SalaCheiaEvent;

        protected virtual void AoSalaCheia(EventArgs e)
        {
            EventHandler handler = SalaCheiaEvent;
            handler?.Invoke(this, e);
        }
    }
}