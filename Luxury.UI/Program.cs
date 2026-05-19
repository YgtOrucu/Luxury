var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("LuxuryApi", client =>
{
    var getaddress = builder.Configuration["ApıAddress:BaseUrl"];
    if (getaddress == null)
        throw new InvalidOperationException("Apı adresi bulunamadı.");
    client.BaseAddress = new Uri(getaddress);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Luxury}/{action=Index}/{id?}");

app.Run();
