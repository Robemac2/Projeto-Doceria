using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Projeto_Brigadeiro.Class
{
    public class ClientHttp
    {
        public static HttpClient Client { get; private set; }

        public ClientHttp()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://192.168.68.12:8080/api/v1/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
