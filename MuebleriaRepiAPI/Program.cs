using Microsoft.EntityFrameworkCore;
using MuebleriaRepiAPI.DTO;
using MuebleriaRepiAPI.Interfaces;
using MuebleriaRepiAPI.Models;
using MuebleriaRepiAPI.Models.DTO;
using MuebleriaRepiAPI.Perfiles;
using MuebleriaRepiAPI.Services;

var builder = WebApplication.CreateBuilder(args);
var devCorsPolicy = "devCorsPolicy";
// Add services to the container.

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers().AddNewtonsoftJson(
    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );

builder.Services.AddDbContext<dbMuebleriaRepiContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});

builder.Services.AddScoped<IDataRepository<Producto, ProductoDTO>, ProductoServices>();
builder.Services.AddScoped <IDataRepository<Categorium, CategoriumDTO>, CategoriaServices>();
builder.Services.AddScoped<IDataRepository<Marca, MarcaDTO>, MarcaServices>();
builder.Services.AddScoped<IDataRepositoryV2<Reclamacione>, ReclamacionesServices>();
builder.Services.AddScoped<IDataRepositoryV2<Solicitar>, SolicitarServices>();
builder.Services.AddScoped<IDataRepositoryV2<SolicitudEmpleado>, SolicitarEmpleadoServices>(); 
builder.Services.AddScoped<IRegistrar<Registrar, Login>,  RegistrarServices>();
builder.Services.AddScoped <IDataRepositoryV2<FormularioCompra>, CompraServices>();
builder.Services.AddScoped<IDataRepositoryV3<Vacante>, VacanteServices>();

builder.Services.AddSingleton<EnviarCorreo>();


builder.Services.AddCors(options => options.AddPolicy(name:devCorsPolicy, policy =>
{
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors(devCorsPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
