using Proyecto_3.Models;

namespace Proyecto_3.Servicios
{
    public interface IServicioParqueo
    {
        public Task<List<Parqueo>> Get();

        public Task<bool> Crear(Parqueo obj_parqueo);

        public Task<Parqueo> ObtenerParqueo(int id);

        public Task<bool> Put(int id, Parqueo obj_parqueo);

        public Task<bool> Delete(int id);
    }
}
