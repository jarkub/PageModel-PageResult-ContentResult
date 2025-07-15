using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace web_my;

/*
 * Application configuration providers
 * The following code displays the enabled configuration providers in the order they were added:
 * The preceding list of highest to lowest priority default configuration sources shows the providers in the opposite order 
 * they are added to template generated application. For example, the JSON configuration provider is added before the Command-line configuration provider.
 * Configuration providers that are added later have higher priority and override previous key settings. For example, if MyKey is set in both 
 * appsettings.json and the environment, the environment value is used. 
 * Using the default configuration providers, the Command-line configuration provider overrides all other providers.
 * For more information on CreateBuilder, see Default builder settings.
 */
public class Index2Model : PageModel
{
    private IConfigurationRoot ConfigRoot;
    public string Message = string.Empty;

    public Index2Model(IConfiguration configRoot)
    {
        ConfigRoot = (IConfigurationRoot)configRoot;

        string str = "";
        foreach (var provider in ConfigRoot.Providers.ToList())
        {
            str += provider.ToString() + "\n";
        }

        Message = str;
    }

    //public IActionResult OnGet()
    //{
    //    string str = "";
    //    foreach (var provider in ConfigRoot.Providers.ToList())
    //    {
    //        str += provider.ToString() + "\n";
    //    }

    //    return Content(str);
    //}

    //public IActionResult OnGetMessage()
    //{
    //    return Message;
    //}

    public IActionResult OnGetContent()
    {
        return Content(Message);
    }

    public IActionResult OnGetPage()
    {
        return Page();
    }

    public string ContentResultToString()
    {
        string str = string.Empty;

        var content = this.OnGetContent();
        if (content is ContentResult contentResult)
        {
            //Console.WriteLine("(content is ContentResult) ", contentResult.Content);
            str += "content is a Microsoft.AspNetCore.Mvc.ContentResult \n";
            str += $"contentResult.Type=[{contentResult.GetType()}] \n";
            str += $"contentResult.Content=[{contentResult.Content}] \n";
            str += $"contentResult.ContentType=[{contentResult.ContentType}] \n";
            str += $"contentResult.StatusCode=[{contentResult.StatusCode}] \n";
        }
        else if (content is ObjectResult objectResult)
        {
            //Console.WriteLine("(content is ObjectResult) ", objectResult.Value?.ToString() ?? string.Empty);
            str += "content is a Microsoft.AspNetCore.Mvc.ObjectResult \n";
            str += $"objectResult.Type=[{objectResult.GetType()}] \n";
            str += $"objectResult=[{objectResult}] \n";
        }
        else
        {
            //Console.WriteLine("Not a ContentResult or ObjectResult");
            str += $"content is Not a ContentResult or ObjectResult \n";
            str += $"content.Type=[{content.GetType()}] \n";
        }

        return str;
    }

    public string PageResultToString()
    {
        string str = string.Empty;

        var page = this.OnGetPage();
        if (page is PageResult pageResult)
        {
            //Console.WriteLine("(page is PageResult) ", pageResult.ViewData?.ToString() ?? string.Empty);
            str += "Type=[Microsoft.AspNetCore.Mvc.RazorPages.PageResult] \n";
            str += $"pageResult.ContentType=[{pageResult.ContentType}] \n";
            str += $"pageResult.Model=[{pageResult.Model}] \n";
            str += $"pageResult.Page=[{pageResult.Page}] \n";
            str += $"pageResult.StatusCode=[{pageResult.StatusCode}] \n";
            str += $"pageResult.ViewData=[{pageResult.ViewData}] \n";
        }
        else if (page is ObjectResult objectResult)
        {
            //Console.WriteLine("(page is ObjectResult) ", objectResult.Value?.ToString() ?? string.Empty);
            str += "page is a Microsoft.AspNetCore.Mvc.ObjectResult \n";
            str += $"objectResult.Type=[{objectResult.GetType()}] \n";
            str += $"objectResult=[{objectResult}] \n";
        }
        else
        {
            //Console.WriteLine("Not a PageResult or ObjectResult");
            str += $"page is Not a PageResult or ObjectResult \n";
            str += $"page.Type=[{page.GetType()}] \n";
        }

        return str;
    }

    public string PageModelToString()
    {
        //var pageModel = this as PageModel;
        string str = string.Empty;

        if (this is PageModel pageModel)
        {
            str += "Type=[Microsoft.AspNetCore.Mvc.RazorPages.PageModel] \n";
            str += $"pageModel.PageContext.ActionDescriptor=[{pageModel.PageContext.ActionDescriptor}] \n";
            str += $"pageModel.PageContext.ValueProviderFactories=[{pageModel.PageContext.ValueProviderFactories}] \n";
            str += $"pageModel.PageContext.ViewData=[{pageModel.PageContext.ViewData}] \n";
            str += $"pageModel.PageContext.ViewStartFactories=[{pageModel.PageContext.ViewStartFactories}] \n";
            str += $"pageModel.PageContext.HttpContext=[{pageModel.PageContext.HttpContext}] \n";
            str += $"pageModel.PageContext.ModelState=[{pageModel.PageContext.ModelState}] \n";
            str += $"pageModel.PageContext.RouteData=[{pageModel.PageContext.RouteData}] \n";
            str += $"pageModel.HttpContext=[{pageModel.HttpContext}] \n";
            str += $"pageModel.Request=[{pageModel.Request}] \n";
            str += $"pageModel.Response=[{pageModel.Response}] \n";
            str += $"pageModel.RouteData=[{pageModel.RouteData}] \n";
            str += $"pageModel.ModelState=[{pageModel.ModelState}] \n";
            str += $"pageModel.User=[{pageModel.User}] \n";
            str += $"pageModel.TempData=[{pageModel.TempData}] \n";
            str += $"pageModel.Url=[{pageModel.Url}] \n";
            str += $"pageModel.MetadataProvider=[{pageModel.MetadataProvider}] \n";
            str += $"pageModel.ViewData=[{pageModel.ViewData}] \n";
        }
        else
        {
            str = "Not a PageModel";
        }

        return str;
    }
}