using System;
using System.Globalization;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleAppFundamentos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
        }

        static void FundamentosMoeda()
        {
            Console.Clear();

            decimal valor = 10.25m;

            // Formatando moedas
            // C: Currency -> vai formatar com os simbolos da moeda como R$ do real, baseado na cultura
            // E04: Formatação para número muito grande
            // G: é um formato generico, mesma coisa que não colocar uma formatação
            // P: Para formatar para porcentagem
            Console.WriteLine(valor.ToString(
                "C",
                CultureInfo.CreateSpecificCulture("pt-BR")
                ));

            // Math -> classe para calculos matematicos
            // Round: Arredonda o valor na média, vai tirar os valores após o separador
            // Ceiling: Arredonda sempre para cima
            // Floor: Arredonda sempre para baixo
            Console.WriteLine(
                Math.Round(valor)
                );
        }

        static void FundamentosData()
        {
            Console.Clear();

            // formatando datas
            var data = DateTime.Now;
            var data2 = DateTime.Now;

            // ano-mes-dia
            // dia-mes-ano
            // M: Mês, yyyy: Ano, d: Dia, hh: Hora, mm: Minutos: ss: Segundos, f: Fração de segundos, z: Fuzo horario
            // pode trocar o - por /
            var formatada = String.Format("{0:dd-MM-yyyy}", data);

            Console.WriteLine(formatada);

            //Comparando datas
            if (data.Date == data2.Date)
                Console.WriteLine("É igual");

            // CultureInfo
            // Globalização e Localização
            var pt = new CultureInfo("pt-pt");
            var br = new CultureInfo("pt-BR");
            var en = new CultureInfo("en-US");
            var atual = CultureInfo.CurrentCulture; // pega a cultura atual da maquina

            Console.WriteLine(DateTime.Now.ToString("D", br));

            // Fuso horario
            // Pega o horario global
            Console.WriteLine(DateTime.UtcNow);
            Console.WriteLine(DateTime.Now.ToLocalTime());

            // Para pegar o fuso horario
            var timezoneAustraliza = TimeZoneInfo.FindSystemTimeZoneById("Pacific/Auckland");
            Console.WriteLine(timezoneAustraliza);
            //Colocando o fuso horario de um lugar especifico
            var horaAustralia = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timezoneAustraliza); 
            Console.WriteLine(horaAustralia);

            // Para pegar todos fusos horarios
            var timezones = TimeZoneInfo.GetSystemTimeZones();
            foreach (var timezone in timezones)
            {
                Console.WriteLine(timezone.Id);
                Console.WriteLine(timezone);
            }

            //Timespan
            var timeSpan = new TimeSpan();
            Console.WriteLine(timeSpan);
        }

        static void FundamentosString()
        {
            Console.Clear();

            // Guids
            var id = Guid.NewGuid();
            id.ToString();
            id = new Guid("0344c880-7811-4feb-b515-55e5120ffb36");
            Console.WriteLine(id);

            // Interpolação
            var preco = 10.2;
            var texto = $"O preço do produto é {preco}";
            var texto2 = string.Format("O preço do produto é {0}", preco);
            var texto3 = "O preço do produto é " + preco;

            // Comparação
            var texto4 = "Testando";
            Console.WriteLine(texto4.CompareTo("Testando")); // pouco usado pelo tipo de retorno
            Console.WriteLine(texto4.Contains("Testando", StringComparison.OrdinalIgnoreCase)); // Segundo parametro para ignorar case sensitive

            //StartsWith/EndsWith -> Para ver se começa ou termina
            var texto5 = "Este texto é um teste";
            Console.WriteLine(texto5.StartsWith("Este", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(texto5.EndsWith("teste", StringComparison.OrdinalIgnoreCase));

            //Equals
            Console.WriteLine(texto5.Equals("Este texto é um teste"));

            //Indice
            var index = texto5.IndexOf("Este");
            var lastIndex = texto5.LastIndexOf("e");

            //Manipulação
            Console.WriteLine(texto5.Replace("Este", "Isto"));

            var divisaoTexto = texto5.Split(" ");
            Console.WriteLine(texto5.Substring(5, 5));

            //StringBuilder
            var textoBuilder = new StringBuilder();
            textoBuilder.Append("Este");
            textoBuilder.Append("texto");
            Console.WriteLine(textoBuilder.ToString());
        }

        static void FundamentosStructEnum()
        {
            var product = new Product(1, "Teclado", 250.00, EProductType.Product);
            var servico = new Product(2, "Reparo impressora", 150.50, EProductType.Service);

            Console.WriteLine(product.Id);
            Console.WriteLine(product.Name);
            Console.WriteLine(product.Price);
            Console.WriteLine($@"{(int)product.Type} - {product.Type}");
            Console.WriteLine($@"{(int)servico.Type} - {servico.Type}");
        }
    }

    // Exemplo de struct
    struct Product
    {
        public Product(int id, string name, double price, EProductType type)
        {
            Id = id;
            Name = name;
            Price = price;
            Type = type;
        }

        public int Id;
        public string Name;
        public double Price;
        public EProductType Type;

        public double PriceInDolar(double dolar)
        {
            return Price * dolar;
        }
    }

    // Exemplo de enum
    enum EProductType
    {
        Product = 1,
        Service = 2
    }
}

