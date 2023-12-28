using Proyecto_3.Models;

namespace Proyecto_3.Servicios
{
    public interface IServicioTiquete
    {
        public Task<List<Tiquete>> Get();

        public Task<bool> Crear(Tiquete obj_tiquete);

        public Task<Tiquete> ObtenerTiquete(int id);

        public Task<bool> Put(int id, Tiquete obj_tiquete);

        public Task<bool> Delete(int id);
    }
}
