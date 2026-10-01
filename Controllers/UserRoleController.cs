using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalCall.Managers.Interfaces;
using RentalCall.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace RentalCall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleManager _userRoleManager;
        public UserRoleController(IUserRoleManager userRoleManager)
        {
            _userRoleManager = userRoleManager;
        }

        /// <summary>
        /// Endpoint to return the list of all user roles
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet]
        [Route("List")]
        [SwaggerOperation(OperationId = nameof(List))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserRoleModel))]
        public async Task<List<UserRoleModel>> List()
        {
            return await _userRoleManager.List();
        }
    }
}
