using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
       Task<List<ResultProductImageDto>> GetAllProductImagesAsync();

        Task CreateProductImageAsync(CreateProductImageDto createProductImageeDto);

        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageeDto);

        Task DeleteProductImageAsync(string id);

        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
    }
}
