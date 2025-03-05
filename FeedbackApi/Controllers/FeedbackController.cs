using FeedbackApi.Dtos;
using FeedbackApi.Models;
using FeedbackApi.Services;
using FeedbackApi.Utils;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Text.Json;

namespace FeedbackApi.Controllers
{
    [ApiController]
    [Route("fbmsapi/v1")]
    [ServiceFilter(typeof(HttpResponseExceptionFilter))]

    public class FeedbackController : ControllerBase
    {

        private readonly FdBkConfigService _feedbackConfigService;
        private readonly OrderService _orderService;
        


        public FeedbackController(FdBkConfigService feedbackConfigService, OrderService orderService)
        {
            _feedbackConfigService = feedbackConfigService;
            _orderService = orderService;
        }

        [HttpOptions("orders/{TordHdId}/SaveFeedback")]
        public IActionResult Options()
        {
            Response.Headers.Add("Access-Control-Allow-Methods", "PUT, POST, OPTIONS");
            Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");
            return Ok();
        }

        [HttpGet(Name = "businesses")]
        public IActionResult GetAllBusinesses()
        {
            return Ok(_feedbackConfigService.GetAll());
        }

        //[HttpGet("orders/{id}")]
        //public IActionResult GetOrder(string id)
        //{
        //    OrderDetailsDto ordHead = _orderService.GetOrder(id);

        //    if (ordHead == null)
        //    {
        //        return NotFound("There is no order with id " + id);
        //    }
        //    return Ok(ordHead);
        //}



        [HttpPost]
        [Route("orders/{TordHdId}/SaveFeedback")]
        public IActionResult SaveFeedback(int TordHdId, [FromBody] OrderUpdateDto orderUpdateDto)
        {
            try
            {
                Console.WriteLine($"? SaveFeedback called for OrderId: {TordHdId}");
                Console.WriteLine($"?? Received Data: {JsonSerializer.Serialize(orderUpdateDto)}");

                _orderService.SaveFeedback(TordHdId, orderUpdateDto);

                // ? Debug Response
                return Ok(new
                {
                    message = "Feedback submitted successfully",
                    receivedData = orderUpdateDto
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"? ERROR: {ex.Message}");
                return StatusCode(500, new { error = "Internal Server Error", details = ex.Message });
            }
        }

        [ServiceFilter(typeof(HttpResponseExceptionFilter))]
        [HttpGet("order/{OrderId}")]
        [SwaggerOperation(Summary = "Get order by ID", Description = "Fetches an order using the order ID.")]
        [SwaggerResponse(200, "Success", typeof(FdBkConfigAndOrderDto))]
        public IActionResult GetOrderDetail(String OrderId)
        {
            try
            {
                var result = _orderService.GetOrderDetails(OrderId);
                if (result == null)
                {
                    return NotFound(new { message = "Order not found" }); //  Handle missing order gracefully
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error", error = ex.Message });
            }
        }

    }

}