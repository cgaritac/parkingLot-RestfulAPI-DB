using Newtonsoft.Json;
using Proyecto_3.Models;
using System.Text;

namespace Proyecto_3.Servicios
{
    public class ServicioTiquete : IServicioTiquete
    {
        private string _baseurl;

        public ServicioTiquete()
        {

            _baseurl = "http://localhost:5135/";
        }

        public async Task<List<Tiquete>> Get()
        {
            List<Tiquete> lista = new List<Tiquete>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync("api/Tiquetes");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Tiquete>>(json_respuesta);
                lista = resultado;
            }
            return lista;
        }

        public async Task<bool> Crear(Tiquete obj_tiquete)
        {
            bool Respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_tiquete), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"api/Tiquetes/Create", contenido);

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }

        public async Task<Tiquete> ObtenerTiquete(int id)
        {
            Tiquete V_Tiquete = new Tiquete();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Tiquetes/ObtenerTiquete/{id}?");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Tiquete>(json_respuesta);
                V_Tiquete = resultado;
            }
            return V_Tiquete;
        }

        public async Task<bool> Put(int id, Tiquete obj_tiquete)
        {
            bool Respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_tiquete), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"api/Tiquetes/{id}", contenido);

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }

        public async Task<bool> Delete(int id)
        {
            bool Respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.DeleteAsync($"api/Tiquetes/{id}");

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }


    }
}
