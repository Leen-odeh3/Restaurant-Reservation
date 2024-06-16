using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Base;
using RestaurantReservation.Core.Features.Tables.Commands.Models;
using RestaurantReservation.Core.Features.Tables.Queries.Models;
using RestaurantReservation.Domain.AppMetaData;

namespace RestaurantReservation.API.Controllers
{
    [ApiController]
    public class TableController : AppControllerBase
    {
        public TableController()
        {
        }

       [HttpGet(Router.TableRouting.List)]
        public async Task<IActionResult> GetAllTables()
        {
            var response = await Mediator.Send(new GetTableListQuery());
            return Ok(response);
        } 

      /*  [HttpGet(Router.TableRouting.GetByID)]
        public async Task<IActionResult> GetByIDTable([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetTableByIDQuery(id));
            return NewResult(response);
        }*/

        [HttpPost(Router.TableRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddTableCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut(Router.TableRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditTableCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

     /*   [HttpDelete(Router.TableRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteTableCommand(id)));
        }*/
    }
}
