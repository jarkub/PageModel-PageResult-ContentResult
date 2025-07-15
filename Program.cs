//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using System;
//using System.Messaging;
using web_my;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var i2m = new Index2Model(app.Configuration);
Console.WriteLine($"-----{nameof(Index2Model.PageModelToString)}-----");
Console.WriteLine(i2m.PageModelToString());

Console.WriteLine($"-----{nameof(Index2Model.ContentResultToString)}-----");
Console.WriteLine(i2m.ContentResultToString());
Console.WriteLine();

Console.WriteLine($"-----{nameof(Index2Model.PageResultToString)}-----");
Console.WriteLine(i2m.PageResultToString());
Console.WriteLine();

const string root =
    """
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <!-- Meta, title, CSS, favicons, etc. -->
        <meta charset="utf-8" /><meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1 user-scalable=no" />
        <title>Index2Model</title>
    </head>
    <body>
        <div>
            <meta name="viewport" content="width=device-width, user-scalable=no" />
            <div><a href='/Index2Model'>Index2Model</a></div>
            <div><a href='/Index2Model/Message'>Index2Model/Message</a></div>

            <div><a href='/Index2Model/PageModel'>Index2Model/PageModel</a></div>
            <div><a href='/Index2Model/PageModelToString'>Index2Model/PageModelToString</a></div>

            <div><a href='/Index2Model/ContentResult'>Index2Model/ContentResult</a></div>
            <div><a href='/Index2Model/ContentResultToString'>Index2Model/ContentResultToString</a></div>

            <div><a href='/Index2Model/PageResult'>Index2Model/PageResult</a></div>
            <div><a href='/Index2Model/PageResultToString'>Index2Model/PageResultToString</a></div>
        </div>
    </body>
</html>
""";
app.MapGet("/", () =>
{
    //Microsoft.AspNetCore.Http.Results.Content
    //var res = new ContentResult();
    //res.Content = root;
    //var res = new Microsoft.AspNetCore.Http.Results.Ok(root);
    //return Microsoft.AspNetCore.Http.Results.Ok(root);
    return new HtmlResult(root);
});
app.MapGet("/Index2Model", () => 
    new Index2Model(app.Configuration)
);
app.MapGet("/Index2Model/Message", () =>
{
    var index2Model = new Index2Model(app.Configuration);
    return index2Model.Message;
});

app.MapGet("/Index2Model/PageModel", () =>
{
    var index2Model = new Index2Model(app.Configuration);
    if (index2Model is Microsoft.AspNetCore.Mvc.RazorPages.PageModel pageModel)
    {
        return pageModel;
    }
    else
    {
        return index2Model;
    }
    //var index2Model = new Index2Model(app.Configuration);
    //return index2Model;
});
app.MapGet("/Index2Model/PageModelToString", () =>
{
    var index2Model = new Index2Model(app.Configuration);
    return index2Model.PageModelToString();
});

app.MapGet("/Index2Model/ContentResult", () =>
{
    var index2Model = new Index2Model(app.Configuration);
    var index2ModelResult = index2Model.OnGetContent();
    if (index2ModelResult is Microsoft.AspNetCore.Mvc.ContentResult contentResult)
    {
        return contentResult;
    }
    else
    {
        return index2ModelResult;
    }
});
app.MapGet("/Index2Model/ContentResultToString", () =>
{
    var index2Model = new Index2Model(app.Configuration);
    return index2Model.ContentResultToString();
});

app.MapGet("/Index2Model/PageResult", () =>
{
    var index2Model = new Index2Model(app.Configuration);
    var index2ModelResult = index2Model.OnGetPage();
    if (index2ModelResult is Microsoft.AspNetCore.Mvc.RazorPages.PageResult pageResult)
    {
        return pageResult;
    }
    else
    {
        return index2ModelResult;
    }
});
app.MapGet("/Index2Model/PageResultToString", () =>
{
    var index2Model = new Index2Model(app.Configuration);
    return index2Model.PageResultToString();
});

//app.MapGet("/Index2Model", () =>
//{
//    new Index2Model(app.Configuration);
//});
//app.MapGet("/hello", () => Results.Ok(new Message() { Text = "Hello World!" }))
//    .Produces<Message>();

app.Run();
