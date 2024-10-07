using AutoMapper;
using Cafe_Delight.BLL.DTOs.Request;
using Cafe_Delight.BLL.DTOs.Response;
using Cafe_Delight.DAL.Entities;
using Cafe_Delight.DAL.Repositories;


namespace Cafe_Delight.BLL.Services
{
    
    

        public interface IAddressService : IBaseService<AddressRequestDTO, AddressResponseDTO>
        {
        }

        public class AddressService : IAddressService
        {
            private readonly IRepositoryWrapper repositoryWrapper;
            private readonly IMapper mapper;

            public AddressService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
            {
                this.repositoryWrapper = repositoryWrapper;
                this.mapper = mapper;
            }

            public async Task<AddressResponseDTO> Add(AddressRequestDTO requestDTO)
            {
                var address = mapper.Map<Address>(requestDTO);
                var responseAddress = await this.repositoryWrapper.AddressRepository.CreateAsync(address);
                await this.repositoryWrapper.SaveAsync();
                var result = mapper.Map<AddressResponseDTO>(responseAddress);
                return result;
            }

        public async Task<bool> Delete(int id)
        {
            var addresstodelete = await this.repositoryWrapper.AddressRepository.GetById(id);
            if (addresstodelete == null)
            {
                return false;
            }
            await this.repositoryWrapper.AddressRepository.DeleteAsync(addresstodelete);
            await this.repositoryWrapper.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<AddressResponseDTO>> GetAll()
            {
                var addresses = await this.repositoryWrapper.AddressRepository.GetAllAsync();
                var result = mapper.Map<IEnumerable<AddressResponseDTO>>(addresses);
                return result;
            }

        public async Task<AddressResponseDTO> GetById(int id)
        {
            var address = await this.repositoryWrapper.AddressRepository.GetById(id);
            var result = mapper.Map<AddressResponseDTO>(address);
            return result;
        }

       

        public async Task<AddressResponseDTO> Update(int id, AddressRequestDTO requestDTO)
        {
            var f = mapper.Map<Address>(requestDTO);
            f.Id = id;
            var v = await repositoryWrapper.AddressRepository.UpdateAsync(id, f);
            await repositoryWrapper.SaveAsync();
            var k = mapper.Map<AddressResponseDTO>(v);
            return k;
        }

        public Task<AddressResponseDTO> Update(AddressRequestDTO requestDTO)
        {
            throw new NotImplementedException();
        }
    }

    
}
