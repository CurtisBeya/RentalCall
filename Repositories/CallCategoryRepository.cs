using RentalCall.Models;
using RentalCall.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RentalCall.Repositories
{
    public class CallCategoryRepository: ICallCategoryRepository
    {
        private readonly RentalCallDbContext _RentalCallDbContext;
        private readonly ILogger<CallCategoryRepository> _logger;

        public CallCategoryRepository(RentalCallDbContext RentalCallDbContext, ILogger<CallCategoryRepository> logger)
        {
            _RentalCallDbContext = RentalCallDbContext;
            _logger = logger;
        }

        // Return the list of all call categories
        public async Task<List<CallCategoryModel>> List()
        {
            try
            {
                return await _RentalCallDbContext.CallCategories.ToListAsync();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving an call category list");
                throw new KeyNotFoundException($"Unable to return the list");
            }
        }

        // Return a specific call category details
        public async Task<CallCategoryModel?> Details(long CallCategoryId)
        {
            try
            {
                return await _RentalCallDbContext.CallCategories.FindAsync(CallCategoryId);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving a call category with the ID: {CallCategoryId}");
                throw new KeyNotFoundException($"Unable to query the database");
            }
        }

        public async Task<CallCategoryModel?> DetailsGivenCallCategoryName(String CallCategoryName)
        {
            try
            {
                return await _RentalCallDbContext.CallCategories
                    .Where(x => x.Name == CallCategoryName)
                    .FirstOrDefaultAsync();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving a call category with the name: {CallCategoryName}");
                throw new KeyNotFoundException($"Unable to query the database");
            }
        }
    }
}
