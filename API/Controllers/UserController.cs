using System.Net;
using AutoMapper;
using LKenselaar.CloudDatabases.Models.DTO;
using LKenselaar.CloudDatabases.Services;
using LKenselaar.CloudDatabases.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;

namespace cloud_databases_assignment.API.Controllers
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
        public async Task<IActionResult> CreateUser([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "user")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return new OkObjectResult(response);
        }
    }
}
