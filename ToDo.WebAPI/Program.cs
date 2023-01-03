using DevIO.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ToDo.Business.Intefaces;
using ToDo.Business.Notificacoes;
using ToDo.Business.Services;
using ToDo.Data.Context;
using ToDo.Data.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

// Adicionando suporte a User Secrets
if (builder.Environment.IsProduction())
{
    builder.Configuration.AddUserSecrets<Program>();
}

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<MeuDbContext>(options =>
{
    options
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), 
                    b => b.MigrationsAssembly("ToDo.WebAPI"));
}
);

builder.Services.AddMvc();
// Retira da aplicação a validação default dos modelos -> coloca nas nossas mãos a validação
builder.Services.Configure<ApiBehaviorOptions>
(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddScoped<INotificador, Notificador>();
builder.Services.AddScoped<MeuDbContext>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
builder.Services.AddScoped<ILogPontuacaoRepository, LogPontuacaoRepository>();
builder.Services.AddScoped<IDificuldadeRepository, DificuldadeRepository>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ITarefaService, TarefaService>();
builder.Services.AddScoped<ILogPontuacaoService, LogPontuacaoService>();
builder.Services.AddScoped<IDificuldadeService, DificuldadeService>();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/erro/500");
    app.UseStatusCodePagesWithRedirects("/erro/{0}");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Adicionando suporte a rota
app.UseRouting();

app.UseAuthorization();

// Rota padrão
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

// Mapeando componentes Razor Pages (ex: Identity)
app.MapRazorPages();

app.Run();
