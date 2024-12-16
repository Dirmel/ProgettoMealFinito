using Newtonsoft.Json;
using RestSharp;

public class MealServices{
    public Meal retrieveMeal(string mealReceived){

        var client = new RestClient($"http://www.themealdb.com/api/json/v1/1/search.php?s={mealReceived}");
       
        var request = new RestRequest("",Method.Get);

        var response = client.Execute(request);

        if (response.IsSuccessful)
        {
            Meal meal = JsonConvert.DeserializeObject<Meal>(response.Content);

            return meal;

        }
        else
        {
            return null;
        }
   

    }
}