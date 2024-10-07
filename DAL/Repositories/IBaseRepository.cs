using Cafe_Delight.DAL.DBContext;
using Cafe_Delight.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cafe_Delight.DAL.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(int id, T entity);

        Task<bool> DeleteAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync(params string[] navsToInclude);

        Task<T?> GetById(int id);

        Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> condition);
    }

    public abstract class RepositoryBase<T> : IBaseRepository<T> where T: class
    {
        private readonly CafeDContext dbContext;
        private readonly DbSet<T> dbSet;

        public RepositoryBase(CafeDContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
        {
            var result = await this.dbSet.AddAsync(entity);
            return result.Entity;
        }

        public Task<bool> DeleteAsync(T entity)
        {
            var result = this.dbSet.Remove(entity);
            return Task.FromResult(result.Entity is not null);
        }

        public async Task<IEnumerable<T>> GetAllAsync(params string[] navsToInclude)
        {
            IQueryable<T> query = this.dbSet;
            if (navsToInclude.Length > 0)
            {
                foreach(var item in  navsToInclude)
                {
                    query = query.Include(item);
                }
            }


            var result = query.AsEnumerable();
            return await Task.FromResult(result);

        }

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> condition)
        {
            var result = this.dbSet.Where(condition);
            return await Task.FromResult(result.AsEnumerable());
        }

        public async Task<T?> GetById(int id)
        {
            return await this.dbSet.FindAsync(id);
        }

       
public async Task<T> UpdateAsync(int id, T entity)

        {

            var dbEntity = await this.dbSet.FindAsync(id);

            if (dbEntity == null)

                throw new KeyNotFoundException($"Resource with Id:{id} not Found");

            dbContext.Entry(dbEntity).CurrentValues.SetValues(entity);
            

            return entity;

        }
    }

    public interface ICategoryRepository : IBaseRepository<Category> { }

    public class CategoryRepository: RepositoryBase<Category> , ICategoryRepository  
    {
        public CategoryRepository(CafeDContext dbContext): base(dbContext)
        {

        }
    }

    public interface IAddressRepository : IBaseRepository<Address> { }

    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(CafeDContext dbContext) : base(dbContext)
        {

        }
    }

    public interface ICartRepository : IBaseRepository<Cart> { }

    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(CafeDContext dbContext) : base(dbContext)
        {

        }
    }


    public interface ICustomerRepository : IBaseRepository<Customer> { }

    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(CafeDContext dbContext) : base(dbContext)
        {

        }
    }

    public interface IFoodItemRepository : IBaseRepository<FoodItem> {

        Task<IEnumerable<FoodItem>> GetFooditemByCategoryId(int CategoryId );
    }

    public class FoodItemRepository : RepositoryBase<FoodItem>, IFoodItemRepository
    {

        private readonly CafeDContext dbContext;
        public FoodItemRepository(CafeDContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<FoodItem>> GetFooditemByCategoryId(int categoryId)
        {
            var result = await dbContext.FoodItems.Where(model => model.CategoryId == categoryId).ToListAsync();
            return result;
        }


    }

    public interface IOrderRepository : IBaseRepository<Order> { }

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(CafeDContext dbContext) : base(dbContext)
        {

        }
    }

    public interface IOrderDetailRepository : IBaseRepository<OrderDetail> { }

    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(CafeDContext dbContext) : base(dbContext)
        {

        }
    }


    public interface ILogInRepository : IBaseRepository<Customer>
    {
        Task<Customer?> ValidateUser(string email, string password);
    }

    public class LogInRepository : RepositoryBase<Customer>, ILogInRepository
    {
        private readonly CafeDContext dbContext;

        public LogInRepository(CafeDContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Customer?> ValidateUser(string email, string password)
        {
            var customer = await dbContext.Customers
            //.Include(x => x.IsAdmin)
            .FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
            if (customer is not null) return customer;
            return null;

        }
    }

    public interface IRepositoryWrapper
    {
        public ICategoryRepository CategoryRepository { get; set; }

        public IAddressRepository AddressRepository { get; set; } 

        public ICartRepository CartRepository { get; set; }   

        public ICustomerRepository CustomerRepository { get; set; }

        public IFoodItemRepository FoodItemRepository { get; set; }


        public IOrderRepository OrderRepository { get; set; }

        public IOrderDetailRepository OrderDetailRepository { get; set; }

        public ILogInRepository LogInRepository { get; set; }

        Task<int> SaveAsync();

    }

    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly CafeDContext dbContext;

        public ICategoryRepository CategoryRepository { get; set ; }
        public IAddressRepository AddressRepository { get; set; }
        public ICartRepository CartRepository { get ; set ; }
        public ICustomerRepository CustomerRepository { get; set ; }
        public IFoodItemRepository FoodItemRepository { get ; set ; }
        public IOrderRepository OrderRepository { get ; set ; }
        public IOrderDetailRepository OrderDetailRepository { get ; set ; }

        public ILogInRepository LogInRepository { get; set; }

        public RepositoryWrapper(CafeDContext dbContext)
        {
            this.dbContext = dbContext;

            CategoryRepository = new CategoryRepository(dbContext);
            AddressRepository = new AddressRepository(dbContext);  
            CartRepository = new CartRepository(dbContext); 
            CustomerRepository = new CustomerRepository(dbContext); 
            FoodItemRepository = new FoodItemRepository(dbContext); 
            OrderRepository = new OrderRepository(dbContext);
            OrderDetailRepository = new OrderDetailRepository(dbContext);
            LogInRepository = new LogInRepository(dbContext);

        }

        public async Task<int> SaveAsync()
        {
            return await this.dbContext.SaveChangesAsync();
        }
    }
}
