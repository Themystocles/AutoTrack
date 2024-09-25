using AutoTrackApi.DataContext;
using AutoTrackApi.Interface;
using AutoTrackApi.Persistencia;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do DbContext para usar SQLite com a string de conexão do appsettings.json
builder.Services.AddDbContext<ConnectionContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registre suas interfaces e implementações
builder.Services.AddScoped<IGeralPersist, GeralPersist>();
builder.Services.AddScoped<IClientePersist, ClientePersist>();
builder.Services.AddScoped<IVeiculoPersist, VeiculoPersist>();
builder.Services.AddScoped<IServicoPersist, ServicoPersist>();
builder.Services.AddScoped<IMontagemPersist, MontagemPersist>();
builder.Services.AddScoped<IRelatorioFinanceiroPersist, RelatorioFinanceiroPersist>();
builder.Services.AddScoped<IEstoquePersist, EstoquePersist>();
builder.Services.AddScoped<IOrcamentoFuncionarioPersist, OrcamentoFuncionarioPersist>();
builder.Services.AddScoped<IOrcamentoPersist, OrcamentoPersist>();

// Adiciona serviços ao contêiner
builder.Services.AddControllers()
      .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura CORS para permitir solicitações de outras fontes
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Usa o CORS configurado
app.UseCors("AllowAll");

// Configura o middleware para servir arquivos estáticos da pasta wwwroot
app.UseStaticFiles(); // Para servir arquivos da pasta wwwroot

// Remove a redireção para HTTPS no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.Use(async (context, next) =>
    {
        context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
        await next();
    });
}
else
{
    app.UseHttpsRedirection();
}

// Mapeia as rotas de controle da API
app.UseAuthorization();
app.MapControllers(); // Isso deve estar antes do fallback

// Adiciona fallback para que as rotas do Angular sejam tratadas corretamente
app.MapFallbackToFile("index.html"); // Faz com que qualquer rota não-API vá para o Angular

app.Run();
