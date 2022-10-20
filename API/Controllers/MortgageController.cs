using System.Net;
using AutoMapper;
using LKenselaar.CloudDatabases.Models.DTO;
using LKenselaar.CloudDatabases.Services;
using LKenselaar.CloudDatabases.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;

namespace cloud_databases_assignment.API.Controllers
{
    public class MortgageController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public MortgageController(ILogger<UserController> log, IUserService userService, IMapper mapper)
        {
            _logger = log ?? throw new ArgumentNullException(nameof(log));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Function("GetMortgage")]
        [OpenApiOperation(operationId: "GetMortgage", tags: new[] { "GetMortgage" }, Summary = "Get a mortgage by id", Description = "This endpoint returns the mortgage by id")]
        [OpenApiRequestBody("application/json", typeof(CreateUserRequestDTO), Description = "The mortage data.")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(CreateUserResponseDTO), Description = "The OK response")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.NotFound, contentType: "application/json", bodyType: typeof(CreateUserResponseDTO), Description = "The NOT FOUND response")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "application/json", bodyType: typeof(CreateUserResponseDTO), Description = "The BAD REQUEST response")]
        public async Task<IActionResult> GetMortgageById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "mortgage/{mortgageId}")] HttpRequestData req, Guid mortageId)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return new OkObjectResult(response);
        }
    }
}
