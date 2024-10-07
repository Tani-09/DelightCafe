using AutoMapper;
using Cafe_Delight.BLL.DTOs.Request;
using Cafe_Delight.BLL.DTOs.Response;
using Cafe_Delight.DAL.Entities;
using Cafe_Delight.DAL.Repositories;

namespace Cafe_Delight.BLL.Services
{
   
    
        public interface ICategoryService : IBaseService<CategoryRequestDTO, CategoryResponseDTO>
    {
    }

    public class CategoryService : ICategoryService

    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public CategoryService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        public async Task<CategoryResponseDTO> Add(CategoryRequestDTO requestDTO)
        {
            var category = mapper.Map<Category>(requestDTO);
            var responseCategory = await this.repositoryWrapper.CategoryRepository.CreateAsync(category);
            await this.repositoryWrapper.SaveAsync();
            var result = mapper.Map<CategoryResponseDTO>(responseCategory);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var categorytodelete = await this.repositoryWrapper.CategoryRepository.GetById(id);
            if (categorytodelete == null)
            {
                return false;
            }
            await this.repositoryWrapper.CategoryRepository.DeleteAsync(categorytodelete);
            await this.repositoryWrapper.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<CategoryResponseDTO>> GetAll()
        {
            var categories = await this.repositoryWrapper.CategoryRepository.GetAllAsync();
            var result = mapper.Map<IEnumerable<CategoryResponseDTO>>(categories);
            return result;
        }

        public async Task<CategoryResponseDTO> GetById(int id)
        {
            var category = await this.repositoryWrapper.CategoryRepository.GetById(id);
            var result = mapper.Map<CategoryResponseDTO>(category);
            return result;
        }


        public async Task<CategoryResponseDTO> Update(int id, CategoryRequestDTO requestDTO)
        {
            var f = mapper.Map<Category>(requestDTO);
            f.Id = id;
            var v = await repositoryWrapper.CategoryRepository.UpdateAsync(id, f);
            await repositoryWrapper.SaveAsync();
            var k = mapper.Map<CategoryResponseDTO>(v);
            return k;
        }
    }


}

    

