using AutoMapper;
using Cafe_Delight.BLL.DTOs.Request;
using Cafe_Delight.BLL.DTOs.Response;
using Cafe_Delight.DAL.Entities;
using Cafe_Delight.DAL.Repositories;

namespace Cafe_Delight.BLL.Services
{
    

        public interface ICustomerService : IBaseService<CustomerRequestDTO, CustomerResponseDTO>
        {
        }

        public class CustomerService : ICustomerService

        {
            private readonly IRepositoryWrapper repositoryWrapper;
            private readonly IMapper mapper;

            public CustomerService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
            {
                this.repositoryWrapper = repositoryWrapper;
                this.mapper = mapper;
            }

            public async Task<CustomerResponseDTO> Add(CustomerRequestDTO requestDTO)
            {
                var customer = mapper.Map<Customer>(requestDTO);
                var responseCustomer = await this.repositoryWrapper.CustomerRepository.CreateAsync(customer);
                await this.repositoryWrapper.SaveAsync();
                var result = mapper.Map<CustomerResponseDTO>(responseCustomer);
                return result;
            }

        public async Task<bool> Delete(int id)
        {
            var customertodelete = await this.repositoryWrapper.CustomerRepository.GetById(id);
            if (customertodelete == null)
            {
                return false;
            }
            await this.repositoryWrapper.CustomerRepository.DeleteAsync(customertodelete);
            await this.repositoryWrapper.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<CustomerResponseDTO>> GetAll()
            {
                var customers = await this.repositoryWrapper.CustomerRepository.GetAllAsync();
                var result = mapper.Map<IEnumerable<CustomerResponseDTO>>(customers);
                return result;
            }

        public async Task<CustomerResponseDTO> GetById(int id)
        {
            var customer = await this.repositoryWrapper.CustomerRepository.GetById(id);
            var result = mapper.Map<CustomerResponseDTO>(customer);
            return result;
        }


        public async Task<CustomerResponseDTO> Update(int id, CustomerRequestDTO requestDTO)
        {
            var f = mapper.Map<Customer>(requestDTO);
            f.Customerid = id;
            var v = await repositoryWrapper.CustomerRepository.UpdateAsync(id, f);
            await repositoryWrapper.SaveAsync();
            var k = mapper.Map<CustomerResponseDTO>(v);
            return k;
        }
    }

    
}
