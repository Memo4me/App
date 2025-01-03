using Memo4me.UI.Components;
using Memo4me.UI.Extensions;

var builder = WebApplication.CreateBuilder(args); 

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAuthOpenId(builder.Configuration);

builder.Services.AddHttpContextAccessor();


var app = builder.Build(); 

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseAuthentication();
app.UseAuthorization();
    
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();