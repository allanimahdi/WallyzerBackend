using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TableauxApi.Models;
using Microsoft.EntityFrameworkCore;
using TableauxApi.Services;

namespace TableauxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableauController : ControllerBase
    {
        public readonly TableauService _tableauService;

        public TableauController(TableauService tableauService)
        {
            _tableauService = tableauService;
        }
        // GET: api/Todo
        [HttpGet]
        public ActionResult<List<Tableau>> Get()
        {
            return _tableauService.Get();
        }


    }
}
