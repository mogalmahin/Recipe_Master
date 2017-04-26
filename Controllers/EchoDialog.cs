using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
namespace Recipe_Master.Controllers
{
    [Serializable]
    public class EchoDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            string msg = message.Text;
            if (msg.ToLower().Contains("hi"))
            {
                await context.PostAsync("Hi! I'm your Recipe Master. I can send you delicious recipes. Just send atleast one ingredient or more.");
        
                context.Wait(MessageReceivedAsync);
            }
            else if (msg.ToLower().Contains("banana and chocolate powder") || msg.ToLower().Contains("thank") || msg.ToLower().Contains("thx"))
            {
                await context.PostAsync("recommended recipes are");
                await context.PostAsync("banana pancakes and the procedure is http://allrecipes.com/recipe/20334/banana-pancakes-i/");
                await context.PostAsync("banana boat and the procedure is http://www.foodnetwork.com/recipes/ree-drummond/campfire-banana-boats-recipe");
                await context.PostAsync("Dark Chocolate and cocoa muffins, the procedure is http://www.yummly.co/#recipe/Dark-Cocoa-Banana-Muffins-1680756da");
                await context.PostAsync("Banana and Chocolate Icecream, the procedure is https://aseasyasapplepie.com/chocolate-banana-ice-cream/");
                context.Wait(MessageReceivedAsync);
            }
            else if (msg.ToLower().Contains("banana pancakes") || msg.ToLower().Contains("thank") || msg.ToLower().Contains("thx"))
            {
                await context.PostAsync("here are the famous locations for you");
                await context.PostAsync("http://www.neworleansrestaurants.com/new-orleans-recipes/recipes_brennans.php ");
                await context.PostAsync("https://www.tripadvisor.in/ShowUserReviews-g298309-d11680795-r444792442-Vee_Vilas_Authentic_South_Indian_Banana_Leaf_Cuisine-Kuching_Sarawak.html");
                await context.PostAsync("https://www.tripadvisor.in/Restaurant_Review-g187786-d4260164-Reviews-Banana_Republics-Pompeii_Province_of_Naples_Campania.html");

               context.Wait(MessageReceivedAsync);
            }
           
            
            
            
            else
            {
                await context.PostAsync("Please check your input");
                context.Wait(MessageReceivedAsync);
            }
        }
    }
}





