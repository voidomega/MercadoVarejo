using Ma.Domain.Entities;
using Ma.MercadoAssistente.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ma.MercadoAssistente.Api.Controllers
{

    // [Authorize(Policy = "mvapi")]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommandController : ControllerBase    
    {

        string httpSrv = null;
        public CommandController(IHttpContextAccessor httpContextAccessor)
        {
            httpSrv = httpContextAccessor.HttpContext.Request.Host.Host;
        }

        [HttpPost(Name = "ExecCommand")]
        public IActionResult ExecCommand([FromBody] string command)
        {
           CommandClass comm = JsonConvert.DeserializeObject<CommandClass>(command);

            
            ApiClient apiClient = new ApiClient(comm.ControllerName, httpSrv);

            //string className = 
            //Type type = Type.GetType($"ByteOn.FourFleet.Domain.Entities.{className}, ByteOn.4Fleet.Domain, Version=4.0.4.0, Culture=neutral, PublicKeyToken=null", false, false);
            //BaseEntity instance = (BaseEntity)Activator.CreateInstance(type);

            var tipo = comm.Tipo[0];

            switch (tipo)
            {
                case 'G':
                    return new ObjectResult(apiClient.executeGetAsync(comm.Method, comm.DataParam));
                    break;
                case 'P':
                    return new ObjectResult(apiClient.executePostAsync(comm.Method, comm.DataParam));
                case 'U':
                    return new ObjectResult(apiClient.executePutAsync(comm.Method, comm.DataParam));

                case 'D':
                    return new ObjectResult(apiClient.executeDeleteAsync(comm.Method, comm.DataParam));
                default:
                    return new ObjectResult("Não encontrado.");
                    break;
            }

        }
    }
}
