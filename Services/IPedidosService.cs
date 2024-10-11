using RoticeriaBlazor.Modelos;
using System.Threading.Tasks;

namespace RoticeriaBlazor.Services
{
    public interface IPedidosService
    {
        Task<List<Pedido>?> Get();               // Obtener la lista de pedidos
        Task<Pedido?> GetById(int id);            // Obtener un pedido por ID
        Task Add(Pedido pedido);                  // Agregar un nuevo pedido
        Task Update(Pedido pedido);               // Actualizar un pedido existente
        Task Delete(int id);
    }
}