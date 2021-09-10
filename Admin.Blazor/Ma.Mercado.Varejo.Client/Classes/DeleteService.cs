using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ma.Mercado.Varejo.Client.Classes
{
    public static class DeleteService
    {

        public static bool Execute(string Controller,string parameter, IHttpClientFactory httpClient)
        {
            try
            {
                var client = httpClient.CreateClient("api");

                var response = client.DeleteAsync($"{Controller}/Delete{Controller}?{parameter}");
                response.Wait();

                var apiResponse = response.Result.Content.ReadAsStringAsync();

                return response.Result.StatusCode == System.Net.HttpStatusCode.OK;
            }catch(Exception exx)
            {
                Console.WriteLine($"DeleteService falha: {exx.Message}");
                return false;
            }

            
        }
             
    }
}
