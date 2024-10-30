using RoticeriaBlazor.Modelos;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace RoticeriaBlazor.Services
{
    public class PedidosService : IPedidosService
    {
        private readonly HttpClient client;
        private readonly JsonSerializerOptions options;

        public PedidosService(HttpClient client)
        {
            this.client = client;
            options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<Pedido>?> Get()
        {
            var response = await client.GetAsync("https://roticeriaback.azurewebsites.net/api/pedidos"); // Asegúrate de que la API retorne también el Cliente
            response.EnsureSuccessStatusCode();
            return await JsonSerializer.DeserializeAsync<List<Pedido>>(await response.Content.ReadAsStreamAsync(), options);
        }

        public async Task<Pedido?> GetById(int id)
        {
            var response = await client.GetAsync($"https://roticeriaback.azurewebsites.net/api/pedidos/{id}");
            response.EnsureSuccessStatusCode();
            return await JsonSerializer.DeserializeAsync<Pedido>(await response.Content.ReadAsStreamAsync(), options);
        }

        public async Task Add(Pedido pedido)
        {
            // Crear una copia de 'Pedido' sin la referencia a 'Cliente' para evitar problemas de serialización
            var pedidoSinCliente = new Pedido
            {
                Id = pedido.Id,
                ClienteId = pedido.ClienteId,
                ProductoId = pedido.ProductoId, // Agregar ProductoId
                Fecha = pedido.Fecha,
                Estado = pedido.Estado
            };

            var content = new StringContent(JsonSerializer.Serialize(pedidoSinCliente), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://roticeriaback.azurewebsites.net/api/pedidos", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(Pedido pedido)
        {
            // Crear una copia de 'Pedido' sin la referencia a 'Cliente' para evitar problemas de serialización
            var pedidoSinCliente = new Pedido
            {
                Id = pedido.Id,
                ClienteId = pedido.ClienteId,
                ProductoId = pedido.ProductoId, // Agregar ProductoId
                Fecha = pedido.Fecha,
                Estado = pedido.Estado
            };

            var content = new StringContent(JsonSerializer.Serialize(pedidoSinCliente), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://roticeriaback.azurewebsites.net/api/pedidos/{pedido.Id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var response = await client.DeleteAsync($"https://roticeriaback.azurewebsites.net/api/pedidos/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
