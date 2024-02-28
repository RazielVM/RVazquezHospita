using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class HospitalController : Controller
    {
        public IActionResult GetAll()
        {
            Dictionary<string, object> resultado = BL.Hospital.GetAll();
            bool result = (bool)resultado["Resultado"];

            if (result)
            {
                ML.Hospital hospital = (ML.Hospital)resultado["Hospital"];
                return View(hospital);
            }
            else
            {
                string excepcion = (string)resultado["Excepcion"];
                return View(excepcion);
            }
        }
        public IActionResult Delete(int idHospital)
        {
            Dictionary<string, object> resultado = BL.Hospital.Delete(idHospital);
            bool result = (bool)resultado["Resultado"];

            if (result)
            {
                ML.Hospital hospital = (ML.Hospital)resultado["Hospital"];
                return View(hospital);
            }
            else
            {
                string excepcion = (string)resultado["Excepcion"];
                return View(excepcion);
            }
        }
    }
}
