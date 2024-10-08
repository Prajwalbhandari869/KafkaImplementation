using KafkaServer.KafkaServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IBuilderService, BuilderService>();
builder.Services.AddTransient<IProducerService, ProducerService>();
builder.Services.AddTransient<IConsumerService, ConsumerService>();

builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
