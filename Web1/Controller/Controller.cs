using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Web1.Data;
using Web1.Models;


namespace Web1.Controller
{
    [Route("api/controller")]
    [ApiController]
    public class Controller : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IList<Livre> Get()
        {
            _logger.LogInformation("execute.....");
            // string str="hello world";
            // return str;
            return data.Livres.ToList();
        }
        private readonly DataContext data;
        private readonly ILogger<Livre> _logger;

        public Controller(DataContext data, ILogger<Livre> logger) { this.data = data;
            _logger = logger;
        }

        
       

      
    }
}