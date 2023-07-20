using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.Concrete;
using EventManagementApplication.Business.ValidationRules.FluentValidation;
using EventManagementApplication.Core.Utilities.Security.Encrypton;
using EventManagementApplication.Core.Utilities.Security.JWT;
using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.DataAccess.Concrete;
using EventManagementApplication.Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EventManagementDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});



builder.Services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));



#region JWT Options

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("http://localhost:3000"));
});

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });


#endregion

#region Business Classes

builder.Services.AddTransient(typeof(IEventService), typeof(EventService));
builder.Services.AddTransient(typeof(ILocationService), typeof(LocationService));
builder.Services.AddTransient(typeof(INotificationService), typeof(NotificationService));
builder.Services.AddTransient(typeof(IRoleService), typeof(RoleService));
builder.Services.AddTransient(typeof(IUserDetailService), typeof(UserDetailService));
builder.Services.AddTransient(typeof(IUserService), typeof(UserService));
builder.Services.AddTransient(typeof(IInvitationService), typeof(InvitationService));
builder.Services.AddTransient(typeof(IUserInvitationMappingService), typeof(UserInvitationMappingService));
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

