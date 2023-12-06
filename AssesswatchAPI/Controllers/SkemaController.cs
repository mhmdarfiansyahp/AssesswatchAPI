using AssesswatchAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace AssesswatchAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkemaController : Controller
    {
        private readonly Skema _skemarepository;
        ResponseModel response = new ResponseModel();


        public SkemaController(IConfiguration configuration)
        {
            _skemarepository = new Skema(configuration);
        }

        [HttpGet("/GetAllSkema", Name = "GetAllSkema")]
        public IActionResult GetAllSkema()
        {
            try
            {
                response.status = 200;
                response.message = "Succes";
                response.data = _skemarepository.getAllData;
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }


        [HttpGet("/GetSkema", Name = "GetSkema")]
        public IActionResult GetSkema(int id)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _skemarepository.getData(id);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed, " + ex;
            }
            return Ok(response);
        }


        [HttpGet("/InsertSkema", Name = "InsertSkema")]
        public IActionResult InsertSkema([FromBody] SkemaModel skemaModel)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                _skemarepository.insertData(skemaModel);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed, " + ex;
            }
            return Ok(response);
        }



        [HttpGet("/UpdateSkema", Name = "UpdateSkema")]
        public IActionResult UpdateSkema([FromBody] SkemaModel skemaModel)
        {
            SkemaModel skema = new SkemaModel();
            skema.id = skemaModel.id;
            skema.Nama_skema = skemaModel.Nama_skema;
            skema.start_date = skemaModel.start_date;
            skema.end_date = skemaModel.end_date;

            try
            {
                response.status = 200;
                response.message = "Success";
                _skemarepository.updateData(skema);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed, " + ex;
            }
            return Ok(response);
        }

        [HttpGet("/DeleteSkema", Name = "DeleteSkema")]
        public IActionResult DeleteSkema(int id)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                _skemarepository.deleteData(id);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed, " + ex;
            }
            return Ok(response);
        }
    }
}
