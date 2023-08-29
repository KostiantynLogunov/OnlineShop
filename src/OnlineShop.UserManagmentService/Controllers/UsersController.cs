using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Library.Constants;
using OnlineShop.Library.UserManagmentService.Models;
using OnlineShop.Library.UserManagmentService.Requests;

namespace OnlineShop.UserManagmentService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost(RepoActions.Add)]
        public Task<IdentityResult> Add(CreateUserRequest request)
        {
            var result = _userManager.CreateAsync(request.User, request.Password);
            return result;
        }

        [HttpPost(RepoActions.Update)]
        public async Task<IActionResult> Update(ApplicationUser user)
        {
            var userToBeUpdated = await _userManager.FindByNameAsync(user.UserName);
            if (userToBeUpdated == null)
                return BadRequest(IdentityResult.Failed(new IdentityError() { Description = $"User {user.UserName} was not found." }));

            userToBeUpdated.FirstName = user.FirstName;
            userToBeUpdated.LastName = user.LastName;
            userToBeUpdated.DefaultAddress = user.DefaultAddress;
            userToBeUpdated.DeliveryAddress = user.DeliveryAddress;
            userToBeUpdated.PhoneNumber = user.PhoneNumber;
            userToBeUpdated.Email = user.Email;

            var result = await _userManager.UpdateAsync(userToBeUpdated);
            return Ok(result);
        }

        [HttpPost(RepoActions.Remove)]
        public async Task<IActionResult> Remove(ApplicationUser user)
        {
            var result = await _userManager.DeleteAsync(user);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var result = await _userManager.FindByNameAsync(name);
            return Ok(result);
           
        }

        [HttpGet(RepoActions.GetAll)]
        public IActionResult Get()
        {
                /*_logger.LogInformation(new LogEntry()
                   .WithClass(nameof(UsersController))
                   .WithMethod(nameof(Get))
                   .WithComment("Getting all users")
                   .WithOperation(RepoActions.GetAll)
                   .WithParameters(LoggingConstants.NoParameters)
                   .ToString()
                   );*/

                //throw new Exception("Ku-ku!");

                var result = _userManager.Users.AsEnumerable();

               /*_logger.LogInformation(new LogEntry()
                  .WithClass(nameof(UsersController))
                  .WithMethod(nameof(Get))
                  .WithComment($"Got {result.Count()} users")
                  .WithOperation(RepoActions.GetAll)
                  .WithParameters(LoggingConstants.NoParameters)
                  .ToString()
                  );*/

                return Ok(result);
        }

        [HttpPost(UsersControllerRoutes.ChangePassword)]
        public async Task<IActionResult> ChangePassword(UserPasswordChangeRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                var description = $"User {request.UserName} was not found.";

                /*_logger.LogWarning(new LogEntry()
                    .WithClass(nameof(UsersController))
                    .WithMethod(nameof(ChangePassword))
                    .WithComment(description)
                    .WithParameters($"{nameof(request.UserName)}: {request.UserName}")
                    .ToString()
                    );*/

                return BadRequest(IdentityResult.Failed(new IdentityError() { Description = description }));
            }

            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            return Ok(result);           
        }

        [HttpPost(UsersControllerRoutes.AddToRole)]
        public async Task<IActionResult> AddToRole(AddRemoveRoleRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                var description = $"User {request.UserName} was not found.";

                /*_logger.LogWarning(new LogEntry()
                    .WithClass(nameof(UsersController))
                    .WithMethod(nameof(AddToRole))
                    .WithComment(description)
                    .WithParameters($"{nameof(request.UserName)}: {request.UserName}")
                    .ToString()
                    );*/

                return BadRequest(IdentityResult.Failed(new IdentityError() { Description = description }));
            }

            var result = await _userManager.AddToRoleAsync(user, request.RoleName);
            return Ok(result);
        }

        [HttpPost(UsersControllerRoutes.AddToRoles)]
        public async Task<IActionResult> AddToRoles(AddRemoveRolesRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                var description = $"User {request.UserName} was not found.";

               /* _logger.LogWarning(new LogEntry()
                    .WithClass(nameof(UsersController))
                    .WithMethod(nameof(AddToRoles))
                    .WithComment(description)
                    .WithParameters($"{nameof(request.UserName)}: {request.UserName}")
                    .ToString()
                    );*/

                return BadRequest(IdentityResult.Failed(new IdentityError() { Description = description }));
            }

            var result = await _userManager.AddToRolesAsync(user, request.RoleNames);
            return Ok(result);
        }

        [HttpPost(UsersControllerRoutes.RemoveFromRole)]
        public async Task<IActionResult> RemoveFromRole(AddRemoveRoleRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                var description = $"User {request.UserName} was not found.";

                /*_logger.LogWarning(new LogEntry()
                    .WithClass(nameof(UsersController))
                    .WithMethod(nameof(RemoveFromRole))
                    .WithComment(description)
                    .WithParameters($"{nameof(request.UserName)}: {request.UserName}")
                    .ToString()
                    );*/

                return BadRequest(IdentityResult.Failed(new IdentityError() { Description = description }));
            }

            var result = await _userManager.RemoveFromRoleAsync(user, request.RoleName);
            return Ok(result);
            
        }

        [HttpPost(UsersControllerRoutes.RemoveFromRoles)]
        public async Task<IActionResult> RemoveFromRoles(AddRemoveRolesRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                var description = $"User {request.UserName} was not found.";

                /*_logger.LogWarning(new LogEntry()
                    .WithClass(nameof(UsersController))
                    .WithMethod(nameof(RemoveFromRole))
                    .WithComment(description)
                    .WithParameters($"{nameof(request.UserName)}: {request.UserName}")
                    .ToString()
                    );
*/
                return BadRequest(IdentityResult.Failed(new IdentityError() { Description = description }));
            }

            var result = await _userManager.RemoveFromRolesAsync(user, request.RoleNames);
            return Ok(result);
        }
    }
}
