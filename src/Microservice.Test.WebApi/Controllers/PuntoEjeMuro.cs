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
        public async Task<ActionResult<PaginatedList<PuntoEjeMuroMap>>> GetPuntoEjeMuroWithPagination([FromQuery] GetPuntoEjeMuroWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePuntoEjeMuroCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateEjeMuroCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeletePuntoEjeMuroCommand { Id = id });

            return NoContent();
        }
    }
}