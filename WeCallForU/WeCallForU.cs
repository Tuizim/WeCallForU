using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeCallForU
{
    public class WeCallForU
    {
        /// <summary>
        /// Envia uma requisição HTTP POST para a URL especificada no contexto e retorna a resposta como uma string.
        /// </summary>
        /// <param name="context">Objeto que contém o corpo da requisição, cabeçalhos personalizados e URL.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona, contendo a resposta da requisição como uma string.</returns>
        /// <exception cref="HttpRequestException">Lançada quando ocorre um erro durante a requisição HTTP.</exception>
        public async Task<string> Execute(Context context)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(context.Body, Encoding.UTF8, "text/xml");

                if (context.Header != null) {
                    foreach (var item in context.Header)
                    {
                        content.Headers.Add(item.Key, item.Value);
                    } 
                }
                try
                {
                    HttpResponseMessage response = await client.PostAsync(context.Url, content);
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();

                }catch(HttpRequestException e)
                {
                    return "Erro na requisição HTTP: " + e.Message;
                }

            }
        }
    }
    /// <summary>
    /// Representa um contexto de requisição HTTP.
    /// </summary>
    /// <param name="Url">A URL da requisição. (Tipo: string)</param>
    /// <param name="Body">O corpo da requisição. (Tipo: string)</param>
    /// <param name="Header">Os cabeçalhos da requisição. (Tipo: Dictionary&lt;string, string&gt;)</param>
    /// <param name="RequestType">O tipo da requisição (GET ou POST). (Tipo: Context.Type)</param>
    public class Context{
        public string Url { get; set; }
        public string Body { get; set; }
        public Dictionary<string,string> Header { get; set; }
        public Type RequestType { get; set; }
        public enum Type
        {
            Get,
            Post
        }
    }

}
