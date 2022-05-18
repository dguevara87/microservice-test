using Microservice.Test.Application.Entities.EjeMuro.Commands;
using Microservice.Test.Application.Entities.EjeMuro.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Test.WebApi.Controllers
{
    public class EjeMuroController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<TodosEjes>> Get()
        {
            return Ok(await Mediator.Send(new GetAllEjeMuroQuery()));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<EjeMuroRecord>> GetEjeMuroById(int id)
        {
            var query = new GetEjeMuroByIdQuery {Id = id}; 
            return  Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<EjeMuroRecord>> Create(CreateEjeMuroCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EjeMuroRecord>> Update(int id, UpdateEjeMuroCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EjeMuroRecord>> Delete(int id)
        {
            return await Mediator.Send(new DeleteEjeMuroCommand() { Id = id });
        }
    }
}