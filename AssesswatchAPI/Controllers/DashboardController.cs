using Microsoft.AspNetCore.Mvc;
using AssesswatchAPI.Model;

namespace AssesswatchAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : Controller
    {


        private readonly Dashboard _dashboardRepository;
        ResponseModel response = new ResponseModel();

        public DashboardController(IConfiguration configuration)
        {
            _dashboardRepository = new Dashboard(configuration);
        }

        [HttpGet("/GetAllDashboard", Name = "GetAllDashboard")]
        public IActionResult GetAllDashboard() 
        {
            try
            {
                response.status = 200;
                response.message = "Succes";
                response.data = _dashboardRepository.getAllData();
            }
            catch
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }

        [HttpGet("/GetDashboard", Name = "GetDashboard")]
        public IActionResult GetDashboard(int id) 
        {
            try
            {
                response.status = 200;
                response.message = "Succes";
                response.data = _dashboardRepository.getData(id);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed, " + ex ;
            }
            return Ok(response);
        }

        [HttpPost("InsertDashboard", Name = "InsertDashboard")]
        public IActionResult InsertDashboard([FromBody] DashboardModel dashboardModel) 
        {
            try
            {
                response.status = 200;
                response.message = "Succes";
                _dashboardRepository.insertData(dashboardModel);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed, " + ex;
            }
            return Ok(response);
        }

        [HttpPut("/UpdateDashboard", Name = "UpdateDashboard")]
        public IActionResult UpdateDashboard([FromBody] DashboardModel dashboardModel) 
        {
            DashboardModel dashboard = new DashboardModel();
            dashboard.id = dashboardModel.id;
            dashboard.nama = dashboardModel.nama;
            dashboard.kompeten = dashboardModel.kompeten;
            dashboard.tidak_kompeten = dashboardModel.tidak_kompeten;
            dashboard.tidak_hadir = dashboardModel.tidak_hadir;
            dashboard.total = dashboardModel.total;
            dashboard.nama_skema = dashboardModel.nama_skema;
            dashboard.unit = dashboardModel.unit;

            try
            {
                response.status = 200;
                response.message = "Succes";
                _dashboardRepository.updateData(dashboard);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed, " + ex;
            }
            return Ok(response);
        }

        [HttpDelete("/DeleteDashboard", Name = "DeleteDashboard")]
        public IActionResult DeleteDashboard(int id) 
        {
            try
            {
                response.status = 200;
                response.message = "Succes";
                _dashboardRepository.deleteData(id);
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
