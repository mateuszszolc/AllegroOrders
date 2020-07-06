using AllegroOrders.Helpers;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AllegroOrders
{
    class Program
    {
     
        static void Main(string[] args)
        {

            Task.Run(async () =>
            {
                Model.Authorization authorization = await Model.Authorization.GetAuthorizationData();

                System.Diagnostics.Process.Start(authorization.VerificationUriComplete);
                Console.Write("Wciśnij '1', by kontynuować i pobrać Token: ");
                int n = int.Parse(Console.ReadLine());
                if (n == 1)
                {
                    try
                    {
                        Console.WriteLine("Pobieranie Tokenu...");
                        Model.Token token = await Model.Token.GetTokenData(authorization);
                        Console.WriteLine("Pobieranie Tokenu zakończone powodzeniem");
                        SD.Test(token);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                
                
            }).GetAwaiter().GetResult();

            Console.ReadKey();
        }
                         
    }
}
