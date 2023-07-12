using EventManagementApplication.Business.ValidationRules.FluentValidation;
using EventManagementApplication.Entities.Concrete;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();








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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
