using Microsoft.AspNetCore.Mvc;
using BackendApi.DataServices;
using System.Threading.Tasks;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BigQueryController : ControllerBase
    {
        private readonly DataQueryService _dataQueryService;

        public BigQueryController(DataQueryService dataQueryService)
        {
            _dataQueryService = dataQueryService;
        }

        [HttpGet("query")]
        public async Task<IActionResult> Query(string sql)
        {
            var results = await _dataQueryService.QueryData(sql);
            return Ok(results);
        }
    }
}
