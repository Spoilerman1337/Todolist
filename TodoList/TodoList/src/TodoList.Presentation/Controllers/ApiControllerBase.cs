﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace TodoList.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiControllerBase : ControllerBase 
    {
        private ISender _sender = null;
        protected ISender Sender => _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
