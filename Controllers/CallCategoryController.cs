using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalCall.Managers.Interfaces;
using RentalCall.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace RentalCall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallCategoryController : ControllerBase
    {
        private readonly ICallCategoryManager _callCategoryManager;

        public CallCategoryController(ICallCategoryManager callCategoryManager)
        {
            _callCategoryManager = callCategoryManager;
        }

        /// <summary>
        /// Endpoint to return the list of all categories
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("List")]
        [SwaggerOperation(OperationId = nameof(List))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CallCategoryModel))]
        public async Task<List<CallCategoryModel>> List()
        {
            return await _callCategoryManager.List();
        }
    }
}
