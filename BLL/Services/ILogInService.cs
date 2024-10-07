using AutoMapper;
using Cafe_Delight.BLL.DTOs.Request;
using Cafe_Delight.BLL.DTOs.Response;
using Cafe_Delight.DAL.Repositories;

namespace Cafe_Delight.BLL.Services
{
   
    public interface ILogInService
    {
        Task<LogInResponseDTO?> IsValidUser(LogInRequestDTO LogInRequestDTO);
    }
    public class LogInService : ILogInService
    {

        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public LogInService(IRepositoryWrapper repositoryWrapper, IConfiguration configuration, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.configuration = configuration;
            this.mapper = mapper;
        }


        public async Task<LogInResponseDTO?> IsValidUser(LogInRequestDTO LogInRequestDTO)
        {
            var customer = await this.repositoryWrapper.LogInRepository.ValidateUser(LogInRequestDTO.Email, LogInRequestDTO.Password);
            if (customer is not null)
            {
               
                return new LogInResponseDTO
                {
                    Customerid = customer.Customerid,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    Password = customer.Password,
                    PhoneNo = customer.PhoneNo,
                    

                };
            }
            return null;
        }
    }


}
