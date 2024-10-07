using AutoMapper;
using Cafe_Delight.BLL.DTOs.Request;
using Cafe_Delight.BLL.DTOs.Response;
using Cafe_Delight.DAL.Entities;
using Cafe_Delight.DAL.Repositories;

namespace Cafe_Delight.BLL.Services
{
    
    

        public interface IOrderService : IBaseService<OrderRequestDTO, OrderResponseDTO>
        {
        }

        public class OrderService : IOrderService

    {
            private readonly IRepositoryWrapper repositoryWrapper;
            private readonly IMapper mapper;

            public OrderService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
            {
                this.repositoryWrapper = repositoryWrapper;
                this.mapper = mapper;
            }

            public async Task<OrderResponseDTO> Add(OrderRequestDTO requestDTO)
            {
                var order = mapper.Map<Order>(requestDTO);
                var responseOrder = await this.repositoryWrapper.OrderRepository.CreateAsync(order);
                await this.repositoryWrapper.SaveAsync();
            var result = mapper.Map<OrderResponseDTO>(responseOrder);
                return result;
            }

        public async Task<bool> Delete(int id)
        {
            var ordertodelete = await this.repositoryWrapper.OrderRepository.GetById(id);
            if (ordertodelete == null)
            {
                return false;
            }
            await this.repositoryWrapper.OrderRepository.DeleteAsync(ordertodelete);
            await this.repositoryWrapper.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<OrderResponseDTO>> GetAll()
            {
                var orders = await this.repositoryWrapper.OrderRepository.GetAllAsync();
                var result = mapper.Map<IEnumerable<OrderResponseDTO>>(orders);
                return result;
            }

        public async Task<OrderResponseDTO> GetById(int id)
        {
            var order = await this.repositoryWrapper.OrderRepository.GetById(id);
            var result = mapper.Map<OrderResponseDTO>(order);
            return result;
        }



        public async Task<OrderResponseDTO> Update(int id, OrderRequestDTO requestDTO)
        {
            var f = mapper.Map<Order>(requestDTO);
            f.Id = id;
            var v = await repositoryWrapper.OrderRepository.UpdateAsync(id, f);
            await repositoryWrapper.SaveAsync();
            var k = mapper.Map<OrderResponseDTO>(v);
            return k;
        }
    }

    
}
