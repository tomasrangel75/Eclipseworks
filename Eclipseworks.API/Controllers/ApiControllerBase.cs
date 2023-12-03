using Eclipseworks.Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eclipseworks.API.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected ErrorDto CreateObjectError(string message)
        {
            return new ErrorDto()
            {
                Message = message
            };
        }

        protected void ObjectValid<T>(T obj)
        {
            if (obj == null || obj.Equals((object)null))
                throw new Exception("Objeto inválido.");
        }
    }
}
