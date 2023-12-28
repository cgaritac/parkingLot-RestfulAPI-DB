using Newtonsoft.Json;
using Proyecto_3.Models;
using System.Text;

namespace Proyecto_3.Servicios
{
    public class ServicioParqueo : IServicioParqueo
    {
        private string _baseurl;

        public ServicioParqueo()
        {

            _baseurl = "http://localhost:5135/";
        }

        public async Task<List<Parqueo>> Get()
        {
            List<Parqueo> lista = new List<Parqueo>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync("api/Parqueos");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Parqueo>>(json_respuesta);
                lista = resultado;
            }
            return lista;
        }

        public async Task<bool> Crear(Parqueo obj_parqueo)
        {
            bool Respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_parqueo), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"api/Parqueos/Create", contenido);

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }

        public async Task<Parqueo> ObtenerParqueo(int id)
        {
            Parqueo V_Parqueo = new Parqueo();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Parqueos/ObtenerParqueo/{id}?");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Parqueo>(json_respuesta);
                V_Parqueo = resultado;
            }
            return V_Parqueo;
        }

        public async Task<bool> Put(int id, Parqueo obj_parqueo)
        {
            bool Respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_parqueo), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"api/Parqueos/{id}", contenido);

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

            var response = await cliente.DeleteAsync($"api/Parqueos/{id}");

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }
    }
}
