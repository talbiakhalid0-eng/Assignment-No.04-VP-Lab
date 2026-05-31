using Assignment_No._04_VP_LAB.Application_05;
using Assignment_No._04_VP_LAB.Application_06;
using Assignment_No._04_VP_LAB.Application_08;
using Assignment_No._04_VP_LAB.Components;
using static Assignment_No._04_VP_LAB.Application_06.NotificationService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var notificationSettings = new NotificationConfig
{
	DefaultNumberOfNotifications = 5 // Sets the loop limit for your engine broadcasts
};
builder.Services.AddSingleton(notificationSettings);
builder.Services.AddScoped<TodoDatabaseService>();
builder.Services.AddScoped<NotificationService>(); 
builder.Services.AddScoped<AuthenticationStateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
