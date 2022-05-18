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
            return await Mediator.Send(new GetAllEjeMuroQuery());
        }

        // [HttpGet("{id}")]
        // public async Task<FileResult> Get(int id)
        // {
        //     var vm = await Mediator.Send(new ExportTodosQuery { ListId = id });
        //
        //     return File(vm.Content, vm.ContentType, vm.FileName);
        // }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateEjeMuroCommand command)
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
            await Mediator.Send(new DeleteEjeMuroCommand() { Id = id });

            return NoContent();
        }
    }
}