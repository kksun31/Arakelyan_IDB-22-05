using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Stopwatch stopwatch = new Stopwatch();//время обработки
        var client = new HttpClient();//создаем клиента
        client.DefaultRequestHeaders.Add("User-Agent", "MyApp");

        // Запрос вакансий по ключевому слову "3d designer"
        HttpResponseMessage response1 = await client.GetAsync("https://api.hh.ru/vacancies?text=3d+designer");

        var json1 = await response1.Content.ReadAsStringAsync();
        //перекидываем результат поиска в строку
        File.WriteAllText("vacancies_3d_designer.json", json1);


        // Запрос вакансий по зп от 300к в рублях в месяц
        HttpResponseMessage response2 = await client.GetAsync("https://api.hh.ru/vacancies?salary>=300000&only_with_salary=true&currency=RUR&order_by=salary_desc");
        string json2 = await response2.Content.ReadAsStringAsync();
        File.WriteAllText("vacancies_salary.json", json2);

         // Запрос вакансий по компании "Яндекс"
        HttpResponseMessage response3 = await client.GetAsync("https://api.hh.ru/vacancies?employer_id=1740");
        string json3 = await response3.Content.ReadAsStringAsync();
        File.WriteAllText("vacancies_yandex.json", json3);

        Thread.Sleep(1000);
        stopwatch.Stop();//останавливаем наш таймер
        Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");
    }
}