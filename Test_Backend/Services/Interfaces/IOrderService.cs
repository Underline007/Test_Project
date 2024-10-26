using Test_Backend.Models.DTOs;

namespace Test_Backend.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDTO> CreateOrderAsync(OrderDTO orderDto);
        Task<OrderDTO> UpdateOrderAsync(string orderCode, OrderDTO orderDto);
        Task<OrderDTO> GetOrderAsync(string orderCode);
        Task<IEnumerable<OrderDTO>> GetOrdersAsync();
    }
}
