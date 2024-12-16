
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

[Route("api/[controller]")]
[ApiController]

public class MealController : ControllerBase
{
    static AddDbContext context = new AddDbContext();
    static MealServices mealService = new MealServices();

    static Meal meal = new Meal();

    [HttpPost]
    public ActionResult<Meal> Get(string request)
    {
        var reque = context.Requests.FirstOrDefault(t => t.requestUser == request);
        if (reque == null)
        {
            Request c = new Request(request);
            Meal temp = mealService.retrieveMeal(c.requestUser);

            if(!(temp.meals == null)){
                context.Requests.Add(c);
                context.SaveChanges();
                return base.Ok(temp);}
            else
            {
                return BadRequest("Richiesta non riuscita");
            }
        }
        else
        {
            if (mealService.retrieveMeal(reque.requestUser) != null)
            {
                return base.Ok(mealService.retrieveMeal(reque.requestUser));
            }
            else
            {
                return NotFound("error");
            }

        }
    }


}