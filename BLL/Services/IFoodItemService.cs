using AutoMapper;
using Cafe_Delight.BLL.DTOs.Request;
using Cafe_Delight.BLL.DTOs.Response;
using Cafe_Delight.DAL.Entities;
using Cafe_Delight.DAL.Repositories;

namespace Cafe_Delight.BLL.Services
{
    

        public interface IFoodItemService : IBaseService<FoodItemRequestDTO, FoodItemResponseDTO>
        {

        Task<IEnumerable<FoodItemResponseDTO>> GetByCategoryId(int categoryId);

    }

        public class FoodItemService : IFoodItemService

    {
            private readonly IRepositoryWrapper repositoryWrapper;
            private readonly IMapper mapper;

            public FoodItemService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
            {
                this.repositoryWrapper = repositoryWrapper;
                this.mapper = mapper;
            }

            public async Task<FoodItemResponseDTO> Add(FoodItemRequestDTO requestDTO)
            {
                var fooditem = mapper.Map<FoodItem>(requestDTO);
                var responseFoodItem = await this.repositoryWrapper.FoodItemRepository.CreateAsync(fooditem);
                await this.repositoryWrapper.SaveAsync();
                var result = mapper.Map<FoodItemResponseDTO>(responseFoodItem);
                return result;
            }

        public async Task<bool> Delete(int id)
        {
            var fooditemtodelete = await this.repositoryWrapper.FoodItemRepository.GetById(id);
            if (fooditemtodelete == null)
            {
                return false;
            }
            await this.repositoryWrapper.FoodItemRepository.DeleteAsync(fooditemtodelete);
            await this.repositoryWrapper.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<FoodItemResponseDTO>> GetAll()
            {
                var fooditems = await this.repositoryWrapper.FoodItemRepository.GetAllAsync();
                var result = mapper.Map<IEnumerable<FoodItemResponseDTO>>(fooditems);
                return result;
            }

        public async Task<FoodItemResponseDTO> GetById(int id)
        {
            var fooditem = await this.repositoryWrapper.FoodItemRepository.GetById(id);
            var result = mapper.Map<FoodItemResponseDTO>(fooditem);
            return result;
        }


        public async Task<FoodItemResponseDTO> Update(int id, FoodItemRequestDTO requestDTO)
        {
            var f = mapper.Map<FoodItem>(requestDTO);
            f.ItemId = id;
            var v = await repositoryWrapper.FoodItemRepository.UpdateAsync(id, f);
            await repositoryWrapper.SaveAsync();
            var k = mapper.Map<FoodItemResponseDTO>(v);
            return k;
        }

        public async Task<IEnumerable<FoodItemResponseDTO>> GetByCategoryId(int categoryId)
        {
            var products = await this.repositoryWrapper.FoodItemRepository.GetFooditemByCategoryId(categoryId);
            var response = mapper.Map<IEnumerable<FoodItemResponseDTO>>(products);
            return response;


        }
    }


    
}
