using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MediCsharp2
{
    public class Usuario
    {

        public string email { get; set; }
        public string password { get; set; }



        public static async Task<bool> login(Usuario p)
        {
            //Muy parecido con el anterior, varia el metodo "PutAsJsonAsync", ademas de la URI se le pasa como pareametro el objeto Persona.
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62052/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage respuesta = await client.PostAsJsonAsync("Account/LoginWpf", p); //Aqui va el Endpoint api/Personas, junto con el Objeto Persona (p), ya que el objeto tiene en los valores de sus atributos, los valores para crear un nuevo recurso Persona.
                
                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
