using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Ma.MercadoAssistente.Api.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Newtonsoft.Json;

namespace Ma.MercadoAssistente.Api
{
    public class ApiClient
    {

        private HttpClient client = null;

        private string mediaType = string.Empty;

        public string ControlerName { get; set; }

        private string _ServerName { get; set; }

        public ApiClient(string Controller, string ServerName)
        {
            ControlerName = Controller;
            _ServerName = ServerName;
        }

        public Boolean StartClient(string MediaType = "application/json")
        {
            mediaType = MediaType;


             //  ConfigurationManager.AppSettings["BOAPIDICIONARIO"];

            if (string.IsNullOrEmpty(_ServerName))
                throw new Exception("Url da API Dicionário de Dados não definida.");

            client = new HttpClient();
            client.BaseAddress = new Uri(_ServerName);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));
           

            return true;

        }

        private StringContent CreateJsonStringContent(Object Data)
        {
            return  new StringContent(JsonConvert.SerializeObject(Data), Encoding.UTF8, mediaType);
        }



        public string executePostAsync(string ApiMethodUrl, string content)
        {

            if (client == null) { StartClient(); }

            //ControlerName = NomeController<T>();

            //var PostContent = JsonConvert.SerializeObject(content);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //var task = client.PostAsync("", byteContent);
            //task.Wait();
            //var resultStr = task.Result.Content.ReadAsStringAsync();
            try
            {
                var response = client.PostAsync(client.BaseAddress + ControlerName + ApiMethodUrl, byteContent);
                response.Wait();
                var apiResponse = response.Result.Content.ReadAsStringAsync();
                return apiResponse.Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao conectar a API em: " + ex.Message);

            }


        }

        public T executePostAsync<T>(string ApiMethodUrl, Object content)
        {

            if (client == null) { StartClient(); }

            //ControlerName = NomeController<T>();

            var PostContent = JsonConvert.SerializeObject(content);
            var buffer = System.Text.Encoding.UTF8.GetBytes(PostContent);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //var task = client.PostAsync("", byteContent);
            //task.Wait();
            //var resultStr = task.Result.Content.ReadAsStringAsync();
            try
            {
                var response = client.PostAsync(client.BaseAddress + ControlerName + ApiMethodUrl, byteContent);
                response.Wait();
                var apiResponse = response.Result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(apiResponse.Result);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao conectar a API em: " + ex.Message);

            }


        }


        public string executePutAsync(string ApiMethodUrl, string content)
        {
            if (client == null) { StartClient(); }

            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            try
            {
                var response = client.PutAsync(client.BaseAddress + ControlerName + ApiMethodUrl, byteContent);
                response.Wait();
                var apiResponse = response.Result.Content.ReadAsStringAsync();
                return apiResponse.Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao conectar a API em: " + ex.Message);

            }

        }

        public T executePutAsync<T>(string ApiMethodUrl, Object content)
        {
            if (client == null) { StartClient(); }

           // ControlerName = NomeController<T>();

            var PostContent = JsonConvert.SerializeObject(content);
            var buffer = System.Text.Encoding.UTF8.GetBytes(PostContent);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //var task = client.PostAsync("", byteContent);
            //task.Wait();
            //var resultStr = task.Result.Content.ReadAsStringAsync();
            try
            {
                var response = client.PutAsync(client.BaseAddress + ControlerName + ApiMethodUrl, byteContent);
                response.Wait();
                var apiResponse = response.Result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(apiResponse.Result);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao conectar a API em: " + ex.Message);

            }

        }



        private string NomeController<T>()
        {
            Type classsType = typeof(T);

            return classsType.Name;
        }

        public T executeGetAsync<T>(string ApiMethodUrl, string QueryString)
        {
            if (client == null) { StartClient(); }

            //// *******************************************************************************************
            ////      os parametros abaixo são obrigatorios em qualquer chamada as APIs do FourFleet
            ////      salvo se a tabela nao tiver os campos IdEmpresa ou IdUsrUltEdicao
            //// *******************************************************************************************
            //// exemplo passando o IdEmpresa
            //int IdEmpresa = 100;
            //client.DefaultRequestHeaders.Add("IdEmpresa", IdEmpresa.ToString());

            //// exemplo passando o IdUsrUltEdicao

            //int IdUsrUltEdicao = 10;
            //client.DefaultRequestHeaders.Add("IdUsrUltEdicao", IdUsrUltEdicao.ToString());
            try
            {
                using (var response = client.GetAsync(client.BaseAddress + ControlerName + ApiMethodUrl + "?" + QueryString))
                {
                    response.Wait();
                    var apiResponse = response.Result.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(apiResponse.Result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao conectar a API em: " + ex.Message);

            }
        }

        public string executeGetAsync(string ApiMethodUrl, string QueryString)
        {
            if (client == null) { StartClient(); }

            //// *******************************************************************************************
            ////      os parametros abaixo são obrigatorios em qualquer chamada as APIs do FourFleet
            ////      salvo se a tabela nao tiver os campos IdEmpresa ou IdUsrUltEdicao
            //// *******************************************************************************************
            //// exemplo passando o IdEmpresa
            //int IdEmpresa = 100;
            //client.DefaultRequestHeaders.Add("IdEmpresa", IdEmpresa.ToString());

            //// exemplo passando o IdUsrUltEdicao

            //int IdUsrUltEdicao = 10;
            //client.DefaultRequestHeaders.Add("IdUsrUltEdicao", IdUsrUltEdicao.ToString());
            try
            {
                using (var response = client.GetAsync(client.BaseAddress + ControlerName + ApiMethodUrl + "?" + QueryString))
                {
                    response.Wait();
                    var apiResponse = response.Result.Content.ReadAsStringAsync();
                    return apiResponse.Result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao conectar a API em: " + ex.Message);

            }
        }


        public string executeDeleteAsync(string ApiMethodUrl, string QueryString)
        {
            if (client == null) { StartClient(); }
            try
            {
                using (var response = client.DeleteAsync(client.BaseAddress + ControlerName + ApiMethodUrl + "?" + QueryString))
                {
                    response.Wait();
                    var apiResponse = response.Result.Content.ReadAsStringAsync();
                    return apiResponse.Result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao conectar a API em: " + ex.Message);
            }
        }


        public T executeDeleteAsync<T>(string ApiMethodUrl, string QueryString)
        {
            if (client == null) { StartClient(); }

            // ControlerName = NomeController<T>();

            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Delete,
            //    RequestUri = new Uri(client.BaseAddress + ControlerName + ApiMethodUrl + "?" + QueryString)               
            //};

            //using (var response = client.SendAsync(request))
            //{
            //    response.Wait();
            //    var apiResponse = response.Result.Content.ReadAsStringAsync();
            //    return JsonConvert.DeserializeObject<T>(apiResponse.Result);
            //}
            try
            {
                using (var response = client.DeleteAsync(client.BaseAddress + ControlerName + ApiMethodUrl + "?" + QueryString))
                {
                    response.Wait();
                    var apiResponse = response.Result.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(apiResponse.Result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao conectar a API em: " + ex.Message);
            }
        }
    }
}
