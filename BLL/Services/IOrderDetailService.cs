using AutoMapper;
using Cafe_Delight.BLL.DTOs.Request;
using Cafe_Delight.BLL.DTOs.Response;
using Cafe_Delight.DAL.Entities;
using Cafe_Delight.DAL.Repositories;

namespace Cafe_Delight.BLL.Services
{
    

        public interface IOrderDetailService : IBaseService<OrderDetailRequestDTO, OrderDetailResponseDTO>
        {
        }

        public class OrderDetailService : IOrderDetailService

    {
            private readonly IRepositoryWrapper repositoryWrapper;
            private readonly IMapper mapper;

            public OrderDetailService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
            {
                this.repositoryWrapper = repositoryWrapper;
                this.mapper = mapper;
            }

            public async Task<OrderDetailResponseDTO> Add(OrderDetailRequestDTO requestDTO)
            {
                var orderdetail = mapper.Map<OrderDetail>(requestDTO);
                var responseOrderDetail = await this.repositoryWrapper.OrderDetailRepository.CreateAsync(orderdetail);
                await this.repositoryWrapper.SaveAsync();
            var result = mapper.Map<OrderDetailResponseDTO>(responseOrderDetail);
                return result;
            }

        public async Task<bool> Delete(int id)
        {
            var orderdetailtodelete = await this.repositoryWrapper.OrderDetailRepository.GetById(id);
            if (orderdetailtodelete == null)
            {
                return false;
            }
            await this.repositoryWrapper.OrderDetailRepository.DeleteAsync(orderdetailtodelete);
            await this.repositoryWrapper.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<OrderDetailResponseDTO>> GetAll()
            {
                var orderdetails = await this.repositoryWrapper.OrderDetailRepository.GetAllAsync();
                var result = mapper.Map<IEnumerable<OrderDetailResponseDTO>>(orderdetails);
                return result;
            }

           


        public async Task<OrderDetailResponseDTO> GetById(int id)
        {
            var order = await this.repositoryWrapper.OrderDetailRepository.GetById(id);
            var result = mapper.Map<OrderDetailResponseDTO>(order);
            return result;
        }



        public async Task<OrderDetailResponseDTO> Update(int id, OrderDetailRequestDTO requestDTO)
        {
            var f = mapper.Map<OrderDetail>(requestDTO);
            f.Id = id;
            var v = await repositoryWrapper.OrderDetailRepository.UpdateAsync(id, f);
            await repositoryWrapper.SaveAsync();
            var k = mapper.Map<OrderDetailResponseDTO>(v);
            return k;
        }
    }

    
}
