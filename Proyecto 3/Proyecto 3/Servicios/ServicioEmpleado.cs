using Newtonsoft.Json;
using Proyecto_3.Models;
using System.Text;

namespace Proyecto_3.Servicios
{
    public class ServicioEmpleado : IServicioEmpleado
    {
        private string _baseurl;

        public ServicioEmpleado()
        {

            _baseurl = "http://localhost:5135/";
        }

        public async Task<List<Empleado>> Get()
        {
            List<Empleado> lista = new List<Empleado>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync("api/Empleados");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Empleado>>(json_respuesta);
                lista = resultado;
            }
            return lista;
        }

        public async Task<bool> Crear(Empleado obj_empleado)
        {
            bool Respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_empleado), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"api/Empleados/Create", contenido);

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }

        public async Task<Empleado> ObtenerEmpleado(int id)
        {
            Empleado V_Empleado = new Empleado();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Empleados/ObtenerEmpleado/{id}?");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Empleado>(json_respuesta);
                V_Empleado = resultado;
            }
            return V_Empleado;
        }

        public async Task<bool> Put(int id, Empleado obj_empleado)
        {
            bool Respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_empleado), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"api/Empleados/{id}", contenido);

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

            var response = await cliente.DeleteAsync($"api/Empleados/{id}");

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }


    }
}
