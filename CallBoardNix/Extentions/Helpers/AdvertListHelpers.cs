using CallBoardNix.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CallBoardNix.Extentions.Helpers
{
    internal static class AdvertListHelpers
    {
        public static HtmlString CreateList(this IHtmlHelper html, List<AdvertView> advert)
        {
            string result = "<ul>";
            foreach(var item in advert)
            {
                result = $"{result}<li class='border mb-3 overflow - scroll' style='margin-right:26px; max - height: 150px; overflow - x:hidden'>";
                result = $"{result}<div class='row p-2'> <div class='col'> <a href='~/Views/Home/Privacy'>{item.NameAdvert}</a> </div>";
                result = $"{result}<div class='col'> <h5>{item.Salary}</h5> </div> </div>";
                result = $"{result}<div class='row'> <div class='col'> <h6 class='p - 2'>{item.Description}</h6> </div> </div> </li>";
                   
            }
            result = $"{result}</ul>";
            return new HtmlString(result.ToString());
        }
    }
}