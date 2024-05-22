using Dataedo_Zadanie.Context;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dataedo_Zadanie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public UsersController(ApplicationContext context)
        {
            _context = context;
        }

        /*
        1. Zwracanym typem powinno by� IActionResult, w celu �atwiejszej obs�ugi mo�liwych odpowiedzi akcji.
        2. Kod powinien by� odporny na potencjalne nieodnalezienie u�ytkownika poprzez sprawdzenie i wys�anie odpowiedzi NotFound.
        3. Kod powinien by� odporny na mo�liwe b��dy podczas usuwania u�ytkownika i w ich przypadku powinien zwr�ci� b��d 500.
        4. Kod powinien doda� log wraz z wiadomo�ci� z wyj�tku, kt�ry mo�e wyst�pi�.
        5. Ka�de pole obiekt�w powinno zaczyna� si� z wielkiej litery (zamiast user.login, to user.Login).
         */

        [HttpGet("delete/{id}")]
        public IActionResult Delete(uint id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null) 
                return NotFound("User was not found!");

            try
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception occurred while trying to remove user with Id:{user.Id}. Message={ex.Message}");
                return StatusCode(500, "Could not remove user, please try again.");
            }

            Debug.WriteLine($"The user with Login={user.Login} has been deleted.");
            return Ok("User was successfully removed!");
        }
    }
}