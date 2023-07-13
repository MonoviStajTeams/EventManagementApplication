using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.Concrete;
using EventManagementApplication.Business.ValidationRules.FluentValidation;
using EventManagementApplication.DataAccess.Concrete;
using EventManagementApplication.Entities.Concrete;
using FluentValidation;
using log4net;
using log4net.Config;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));


builder.Services.AddDbContext<EventManagementDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});


#region Business Classes

builder.Services.AddTransient(typeof(IEventService), typeof(EventService));
builder.Services.AddTransient(typeof(ILocationService), typeof(LocationService));
builder.Services.AddTransient(typeof(INotificationService), typeof(NotificationService));
builder.Services.AddTransient(typeof(IRoleService), typeof(RoleService));
builder.Services.AddTransient(typeof(IUserDetailService), typeof(UserDetailService));
builder.Services.AddTransient(typeof(IUserInvitationMappingService), typeof(UserInvitationMapping));
builder.Services.AddTransient(typeof(IUserService), typeof(UserService));
builder.Services.AddTransient(typeof(IInvitationService), typeof(InvitationService));

#endregion


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
