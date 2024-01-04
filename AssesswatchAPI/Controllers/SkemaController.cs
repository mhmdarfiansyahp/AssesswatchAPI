using AssesswatchAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace AssesswatchAPI.Controllers
{
    public class SkemaController : Controller
    {
        private readonly Skema _skemarepository;
        ResponseModel response = new ResponseModel();


        public SkemaController(IConfiguration configuration)
        {
            _skemarepository = new Skema(configuration);
        }

        [HttpGet("/GetAllBuku", Name = "GetAllSkema")]
        public IActionResult GetAllBuku()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _skemarepository.getAllData();
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


        [HttpPost("/InsertSkema", Name = "InsertSkema")]
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



        [HttpPut("/UpdateSkema", Name = "UpdateSkema")]
        public IActionResult UpdateSkema([FromBody] SkemaModel skemaModel)
        {
            SkemaModel skema = new SkemaModel();
            skema.id = skemaModel.id;
            skema.Nama_skema = skemaModel.Nama_skema;


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

        [HttpDelete("/DeleteSkema", Name = "DeleteSkema")]
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

        public IActionResult Index()
        {
            return View();
        }
    }
}
