using Microservice.Test.Application.Common.Models;
using Microservice.Test.Application.Entities.EjeMuro.Commands;
using Microservice.Test.Application.Entities.PuntoEjeMuro.Commands;
using Microservice.Test.Application.Entities.PuntoEjeMuro.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Test.WebApi.Controllers
{
    public class PuntoEjeMuro : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<PuntoEjeMuroDto>>> GetPuntoEjeMuroWithPagination([FromQuery] GetPuntoEjeMuroWithPaginationQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<PuntoEjeMuroRecord>> Create(CreatePuntoEjeMuroCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PuntoEjeMuroRecord>> Update(int id, UpdatePuntoEjeMuroCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PuntoEjeMuroRecord>> Delete(int id)
        {
            return await Mediator.Send(new DeletePuntoEjeMuroCommand { Id = id });
        }
    }
}