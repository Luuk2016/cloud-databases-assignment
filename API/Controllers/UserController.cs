using System.Net;
using AutoMapper;
using LKenselaar.CloudDatabases.Models;
using LKenselaar.CloudDatabases.Models.DTO;
using LKenselaar.CloudDatabases.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace LKenselaar.CloudDatabases.API.Controllers
{
    public class UserController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> log, IUserService userService, IMapper mapper)
        {
            _logger = log ?? throw new ArgumentNullException(nameof(log));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [Function("CreateUser")]
        [OpenApiOperation(operationId: "CreateUser", tags: new[] { "CreateUser" }, Summary = "Create a new user", Description = "This endpoint allows the creation of a new user.")]
        [OpenApiRequestBody("application/json", typeof(CreateUserRequestDTO), Description = "The user data.")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.Created, contentType: "application/json", bodyType: typeof(CreateUserResponseDTO), Description = "The CREATED response")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "application/json", bodyType: typeof(CreateUserResponseDTO), Description = "The BAD REQUEST response")]
        public async Task<IActionResult> CreateUser([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "user")] HttpRequestData req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            try
            {
                // Serialize the JSON to a DTO
                var requestBodyData = JsonConvert.DeserializeObject<CreateUserRequestDTO>(requestBody);

                // Map DTO to Entity
                User user = _mapper.Map<User>(requestBodyData);

                var createdUser = await _userService.Create(user);

                // Map Entity to response DTO
                var response = _mapper.Map<CreateUserResponseDTO>(createdUser);

                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
