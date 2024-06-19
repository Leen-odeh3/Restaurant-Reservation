using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Base;
using RestaurantReservation.Core.Features.Reservations.Commands.Models;
using RestaurantReservation.Core.Features.Reservations.Queries.Models;
using RestaurantReservation.Core.FeaturesReservations.Commands.Models;
using RestaurantReservation.Domain.AppMetaData;

namespace RestaurantReservation.API.Controllers
{
    [ApiController]
    public class ReservationController : AppControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ReservationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet(Router.ReservationRouting.List)]
        public async Task<IActionResult> GetAllReservations()
        {
            var response = await _mediator.Send(new GetReservationListQuery());
            return Ok(response);
        }

        [HttpPost(Router.ReservationRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddReservationCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut(Router.ReservationRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditReservationCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.ReservationRouting.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteReservationCommand(id));
            return NewResult(response);
        }
    }
}
