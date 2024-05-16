using System;
using System.IO;
using System.Net.Http;
using System.Diagnostics;
using System.Threading;
class Program1
{
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "MyApp");

        // Запрос вакансий по компании "Яндекс"
        HttpResponseMessage response1 = client.GetAsync("https://api.hh.ru/vacancies?employer_id=1740").Result;
        string json1 = response1.Content.ReadAsStringAsync().Result;
        File.WriteAllText("vacancies_yandex.json", json1);

        // Запрос вакансий по ключевому слову "3d designer"
        HttpResponseMessage response2 = client.GetAsync("https://api.hh.ru/vacancies?text=3d+designer").Result;
        string json2 = response2.Content.ReadAsStringAsync().Result;
        File.WriteAllText("vacancies_3d_designer.json", json2);

        // Запрос вакансий по зп от 300к в рублях в месяц
        HttpResponseMessage response3 = client.GetAsync("https://api.hh.ru/vacancies?salary>=300000&only_with_salary=true&currency=RUR&order_by=salary_desc").Result;
        string json3 = response3.Content.ReadAsStringAsync().Result;
        File.WriteAllText("vacancies_salary.json", json3);


        Thread.Sleep(5000);
        stopwatch.Stop();
        Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");
    }
}