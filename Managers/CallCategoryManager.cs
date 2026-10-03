using AutoMapper;
using RentalCall.Managers.Interfaces;
using RentalCall.Models;
using RentalCall.Repositories;
using RentalCall.Repositories.Interfaces;

namespace RentalCall.Managers
{
    public class CallCategoryManager: ICallCategoryManager
    {
        private readonly ICallCategoryRepository _callCategoryRepository;

        public CallCategoryManager(ICallCategoryRepository callCategoryrepository)
        {
            _callCategoryRepository = callCategoryrepository;
        }

        //Return the list of all call categories
        public async Task<List<CallCategoryModel>> List()
        {
            return await _callCategoryRepository.List();
        }
    }
}
