using AssesswatchAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace AssesswatchAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdiController : Controller
    {
        private readonly Prodi _prodirepository;
        ResponseModel response = new ResponseModel();


        public ProdiController(IConfiguration configuration)
        {
            _prodirepository = new Prodi(configuration);
        }
        [HttpGet("/GetAllProdi", Name = "GetAllProdi")]
        public IActionResult GetAllProdi()
        {
            try
            {
                response.status = 200;
                response.message = "Succes";
                response.data = _prodirepository.getAllData;
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }


        [HttpGet("/GetProdi", Name = "GetProdi")]
        public IActionResult GetProdi(int id)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _prodirepository.getData(id);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed, " + ex;
            }
            return Ok(response);
        }


        [HttpPost("/InsertProdi", Name = "InsertProdi")]
        public IActionResult InsertProdi([FromBody] ProdiModel prodiModel)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                _prodirepository.insertData(prodiModel);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed, " + ex;
            }
            return Ok(response);
        }



        [HttpPut("/UpdateProdi", Name = "UpdateProdi")]
        public IActionResult UpdateProdi([FromBody] ProdiModel prodiModel)
        {
            ProdiModel prodi = new ProdiModel();
            prodi.id = prodiModel.id;
            prodi.Nama_prodi = prodiModel.Nama_prodi;

            try
            {
                response.status = 200;
                response.message = "Success";
                _prodirepository.updateData(prodi);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed, " + ex;
            }
            return Ok(response);
        }

        [HttpDelete("/DeleteProdi", Name = "DeleteProdi")]
        public IActionResult DeleteProdi(int id)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                _prodirepository.deleteData(id);
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
       


    

