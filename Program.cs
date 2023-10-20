using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using SchoolSearch.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<DataAccess>(_=> new DataAccess(builder.Configuration));
builder.Services.AddScoped<ISchoolSearchResultService, SchoolSearchResultService>();
builder.Services.AddScoped<IClassroomGenerator, ClassroomGenerator>();

builder.Services.AddHttpClient();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});



var app = builder.Build();

//Try to stop JSON from serializing to camelCase
/*builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DictionaryKeyPolicy = null;
});*/

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapRazorPages();
//app.MapBlazorHub();

app.MapGet("/api/schoolSearchTerms", async (string filter, [FromServices] ISchoolSearchResultService manager) => 
    Results.Ok(await manager.GetSchoolSearchResultsAsync(filter))
);
app.MapGet("/api/schoolSearchSuggestions", async (string filter, [FromServices] ISchoolSearchResultService manager) => 
    Results.Ok(await manager.GetSearchSuggestionsAsync(filter))
);
app.MapGet("/api/classroomGenerator", async (int schoolId, int size, string grade, [FromServices] IClassroomGenerator manager) => 
    Results.Ok(await manager.GetClassroomAsync(schoolId, size, grade))
);

app.Run();
