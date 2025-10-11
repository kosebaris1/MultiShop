using Dapper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos.CouponDtos;

namespace MultiShop.Discount.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;
        public DiscountService(DapperContext context)
        {
            _context = context;
        }
        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            string query = "INSERT INTO Coupons (Code, Rate, IsActive, ValidDate) VALUES (@Code, @Rate, @IsActive, @ValidDate)";

            var parameters = new DynamicParameters();

            parameters.Add("@Code", createCouponDto.Code);
            parameters.Add("@Rate", createCouponDto.Rate);
            parameters.Add("@IsActive", createCouponDto.IsActive);
            parameters.Add("@ValidDate", createCouponDto.ValidDate);

            using (var connection = _context.CreateConnection())
            {
              await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task DeleteDiscountCouponAsync(int couponId)
        {
            string query = "DELETE FROM Coupons WHERE CouponId = @CouponId";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponId", couponId);
            using (var connection = _context.CreateConnection())
            {
              await  connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
             string query = "SELECT * FROM Coupons";
            using(var connection = _context.CreateConnection())
            {
                var values =await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList(); 
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int couponId)
        {
            string query = "SELECT * FROM Coupons WHERE CouponId = @CouponId";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponId", couponId);
            using(var connection = _context.CreateConnection())
            {
                var value =await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query,parameters);
                return value;
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "UPDATE Coupons SET Code = @Code, Rate = @Rate, IsActive = @IsActive, ValidDate = @ValidDate WHERE CouponId = @CouponId";

            var parameters = new DynamicParameters();

            parameters.Add("@CouponId", updateCouponDto.CouponId);
            parameters.Add("@Code", updateCouponDto.Code);
            parameters.Add("@Rate", updateCouponDto.Rate);
            parameters.Add("@IsActive", updateCouponDto.IsActive);
            parameters.Add("@ValidDate", updateCouponDto.ValidDate);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
