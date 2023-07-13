using EventManagementApplication.Business.ValidationRules.FluentValidation;
using EventManagementApplication.DataAccess.Concrete;
using EventManagementApplication.Entities.Concrete;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<EventManagementDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});



#region FluentValidation
builder.Services.AddTransient<IValidator<Event>, EventValidator>();
builder.Services.AddTransient<IValidator<Invitation>, InvitationValidator>();
builder.Services.AddTransient<IValidator<Location>, LocationValidator>();
builder.Services.AddTransient<IValidator<Notification>, NotificationValidator>();
builder.Services.AddTransient<IValidator<Role>, RoleValidator>();
builder.Services.AddTransient<IValidator<UserDetail>, UserDetailValidator>();
builder.Services.AddTransient<IValidator<UserInvitationMapping>, UserInvitationMappingValidator>();
builder.Services.AddTransient<IValidator<User>, UserValidator>();

#endregion


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
