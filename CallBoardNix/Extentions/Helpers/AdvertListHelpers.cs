using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CallBoardNix.Extentions.Helpers
{
    internal static class AdvertListHelpers
    {
        public static HtmlString CreateList(this IHtmlHelper html, string[] name, string[] salary, string[] desc)
        {
            string result = "<ul>";
            int lenght = name.Length;
            int count = 0;
            while(lenght != 0)
            {
                result = $"{result}<li class='border mb-3 overflow - scroll' style='margin - right:26px; max - height: 150px; overflow - x:hidden'>";
                result = $"{result}<div class='row p-2'> <div class='col'> <h5>{name.GetValue(count)}</h5> </div>";
                result = $"{result}<div class='col'> <h5>{salary.GetValue(count)}</h5> </div> </div>";
                result = $"{result}<div class='row'> <div class='col'> <h6 class='p - 2'>{desc.GetValue(count)}</h6> </div> </div> </li>";
                count++;
                lenght--;
            }
           

            result = $"{result}</ul>";
            return new HtmlString(result.ToString());
        }
    }
}