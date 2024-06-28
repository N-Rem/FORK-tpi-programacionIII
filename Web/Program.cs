using Application.Interfaces;
using Application.Services;
using Domain.Interface;
using Infrastructure.Data;//Para que aceda al contexto. 
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using static Infrastructure.Data.AuthenticationService;

//Add - Migration InitialMigration - Context ApplicationContext
//comando para agregar una migracion inicial refiriendose al archivo exacto de contexto deseado

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(setupAction =>
{
    //Esto va a permitir usar swagger con el token.
    setupAction.AddSecurityDefinition("EcommerceApiBearerAuth", new OpenApiSecurityScheme() 
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Acá pegar el token generado al loguearse."
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "EcommerceApiBearerAuth" } //Tiene que coincidir con el id seteado arriba en la definición
                }, new List<string>() }
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Inyeccion para la cracion de la base de datos, Las migraciones se ensamblan en Infraestructura
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite(
builder.Configuration["ConnectionStrings:EcommerceDBConnectionString"], b => b.MigrationsAssembly("Infrastructure")));


//"Bearer" es el tipo de auntenticación que tenemos que elegir después en PostMan para pasarle el token
builder.Services.AddAuthentication("Bearer")
    //Acá definimos la configuración de la autenticación. le decimos qué cosas queremos comprobar. La fecha de expiración se valida por defecto.
    .AddJwtBearer(options => 
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["AuthenticationService:Issuer"],
            ValidAudience = builder.Configuration["AuthenticationService:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["AuthenticationService:SecretForKey"]))
        };
    }
);

//Inyeciones ----
builder.Services.AddScoped<IRepositorySneaker,RepositorySneaker>();
builder.Services.AddScoped<IRepositoryReservation,RepositoryReservation>();
builder.Services.AddScoped<IRepositoryUser,RepositoryUser>();

builder.Services.Configure<AuthenticationServiceOptions>(
    builder.Configuration.GetSection(AuthenticationServiceOptions.AuthenticationService));
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IReservationServices, ReservationServices>();
builder.Services.AddScoped<ISneakerServices, SneakerServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
//---

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();