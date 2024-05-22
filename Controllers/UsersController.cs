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
        1. Zwracanym typem powinno byæ IActionResult, w celu ³atwiejszej obs³ugi mo¿liwych odpowiedzi akcji.
        2. Kod powinien byæ odporny na potencjalne nieodnalezienie u¿ytkownika poprzez sprawdzenie i wys³anie odpowiedzi NotFound.
        3. Kod powinien byæ odporny na mo¿liwe b³êdy podczas usuwania u¿ytkownika i w ich przypadku powinien zwróciæ b³¹d 500.
        4. Kod powinien dodaæ log wraz z wiadomoœci¹ z wyj¹tku, który mo¿e wyst¹piæ.
        5. Ka¿de pole obiektów powinno zaczynaæ siê z wielkiej litery (zamiast user.login, to user.Login).
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