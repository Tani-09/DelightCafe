using AutoMapper;
using Cafe_Delight.BLL.DTOs.Request;
using Cafe_Delight.BLL.DTOs.Response;
using Cafe_Delight.DAL.Entities;
using Cafe_Delight.DAL.Repositories;


namespace Cafe_Delight.BLL.Services
{
    
    

        public interface ICartService : IBaseService<CartRequestDTO, CartResponseDTO>
        {
        }

        public class CartService : ICartService

        {
            private readonly IRepositoryWrapper repositoryWrapper;
            private readonly IMapper mapper;

            public CartService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
            {
                this.repositoryWrapper = repositoryWrapper;
                this.mapper = mapper;
            }

            public async Task<CartResponseDTO> Add(CartRequestDTO requestDTO)
            {
                var cart = mapper.Map<Cart>(requestDTO);
                var responseCart = await this.repositoryWrapper.CartRepository.CreateAsync(cart);
                await this.repositoryWrapper.SaveAsync();
                var result = mapper.Map<CartResponseDTO>(responseCart);
                return result;
            }

        public async Task<bool> Delete(int id)
        {
            var carttodelete = await this.repositoryWrapper.CartRepository.GetById(id);
            if (carttodelete == null)
            {
                return false;
            }
            await this.repositoryWrapper.CartRepository.DeleteAsync(carttodelete);
            await this.repositoryWrapper.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<CartResponseDTO>> GetAll()
            {
                var carts = await this.repositoryWrapper.CartRepository.GetAllAsync();
                var result = mapper.Map<IEnumerable<CartResponseDTO>>(carts);
                return result;
            }

        public async Task<CartResponseDTO> GetById(int id)
        {
            var cart = await this.repositoryWrapper.CartRepository.GetById(id);
            var result = mapper.Map<CartResponseDTO>(cart);
            return result;
        }


        public async Task<CartResponseDTO> Update(int id, CartRequestDTO requestDTO)
        {
            var f = mapper.Map<Cart>(requestDTO);
            f.Id = id;
            var v = await repositoryWrapper.CartRepository.UpdateAsync(id, f);
            await repositoryWrapper.SaveAsync();
            var k = mapper.Map<CartResponseDTO>(v);
            return k;
        }

       
    }


    
}
