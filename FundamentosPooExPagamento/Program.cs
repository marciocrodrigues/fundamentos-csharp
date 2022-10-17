using System;
using System.Collections.Generic;
using System.Linq;
using FundamentosPooProjPratico.ContentContext;
using FundamentosPooProjPratico.SubscriptionContext;

namespace FundamentosPooProjPratico
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void ShowArticles()
        {
            var articles = new List<Article>();
            articles.Add(new Article("Desvendando SOLID", "SOLID"));
            articles.Add(new Article("Novidades di .NET 7", ".NET"));

            foreach (var article in articles)
            {
                Console.WriteLine(article.Id);
                Console.WriteLine(article.Title);
                Console.WriteLine(article.Url);
            }
        }

        static void ShowCoreers()
        {
            var courses = new List<Course>();
            var courseFundamentos = new Course("Fundamentos de .net", "www.teste.com.br");
            var courseCSharp = new Course("C#", "www.teste.com.br");
            courses.Add(courseFundamentos);
            courses.Add(courseCSharp);


            var careers = new List<Career>();
            var careerDotnet = new Career(".NET", "www.net.com.br");
            var careeItem2 = new CareerItem(2, ".NET Comece aqui", "Inicio de dotnet", courseFundamentos);
            var careeItem = new CareerItem(1, "C#", "Iniciando com csharp", null);
            careerDotnet.Items.Add(careeItem2);
            careerDotnet.Items.Add(careeItem);
            careers.Add(careerDotnet);

            foreach(var career in careers)
            {
                Console.WriteLine(career.Title);
                foreach(var item in career.Items.OrderBy(x => x.Order))
                {
                    Console.WriteLine($"{item.Order} - {item.Title}");
                    Console.WriteLine(item.Course?.Title);
                    Console.WriteLine(item.Course?.Level);

                    foreach(var notification in item.Notifications)
                    {
                        Console.WriteLine($"{notification.Property} - {notification.Message}");
                    }
                }
            }
        }

        static void ShowSubscription()
        {
            var paypalSubscription = new PaypalSubscription();
            var student = new Student();

            student.CreateSubscription(paypalSubscription);
        }
    }
}

