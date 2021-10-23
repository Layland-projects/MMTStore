using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;

namespace Store.Demo
{
    class Program
    {
        const string url = "https://localhost:44343/";
        static void Main()
        {
            DisplayOptions();
            while(true) 
            {
                var client = new WebClient();
                client.Headers.Add("Content-Type: application/json");
                var input = Console.ReadLine();
                if (input == "!")
                    break;
                if (string.IsNullOrEmpty(input))
                {
                    DisplayOptions();
                    continue;
                }
                var args = input.Split(" ");
                switch (args[0])
                {
                    case "1":
                        var res = client.DownloadString(url + "products/featured");
                        Console.WriteLine(res);
                        break;
                    case "2":
                        res = client.DownloadString(url + "productCategories");
                        Console.WriteLine(res);
                        break;
                    case "3":
                        if (args.Length < 2)
                        {
                            Console.WriteLine("A second argument is required for this operation <categoryId>");
                        }
                        else
                        {
                            res = client.DownloadString(url + $"products/categoryId/{args[1]}");
                            Console.WriteLine(res);
                        }
                        break;
                    case "4":
                        if (args.Length < 2)
                        {
                            Console.WriteLine("A second argument is required for this operation <categoryId>");
                        }
                        else
                        {
                            var model = new { categoryId = args[1], validFromUtc = DateTime.UtcNow, validUntilUtc = DateTime.UtcNow.AddMinutes(1) };
                            byte[] bytes = null;
                            try
                            {
                                bytes = client.UploadData(url + "featuredProductCategory", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model)));
                            }
                            catch(WebException e)
                            {
                                if (e.Message.Contains("400"))
                                    bytes = Encoding.UTF8.GetBytes("Bad request, CategoryId not found");
                            }
                            res = Encoding.UTF8.GetString(bytes);
                            Console.WriteLine(res);
                        }
                        break;
                    default:
                        break;
                }
                DisplayOptions();
            }
        }
        static void DisplayOptions() => Console.WriteLine($"Please select a demonstration to run:\n" +
            $"1 - GetFeaturedProducts\n" +
            $"2 - GetAvailableCategories\n" +
            $"3 <categoryId> - GetProductsByCategoryId\n" +
            $"4 <categoryId> - AddNewFeaturedCategory (as this is a demo the new featured category will only be active for 60 seconds)\n" +
            $"! - Exit");
    }
}
