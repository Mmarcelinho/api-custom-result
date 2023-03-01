var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ILivroRepository, LivroRepository>();

builder.Services.AddDbContext<Context>(x => x.UseInMemoryDatabase("Database"));

builder.Services.AddSwaggerGen(c =>
 {
     var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
     var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
     c.IncludeXmlComments(xmlPath);
 });


builder.Services.AddElmah<SqlErrorLog>(options =>
  {
      options.ConnectionString = builder.Configuration.GetSection($"ConnectionStrings:ElmahConnection").Value;
      options.Path = "/elmah";
  });


var app = builder.Build();


app.UseWhen(context => context.Request.Path.StartsWithSegments("/elmah", StringComparison.OrdinalIgnoreCase), appBuilder =>
{
    appBuilder.Use(next =>
    {
        return async ctx =>
        {
            ctx.Features.Get<IHttpBodyControlFeature>().AllowSynchronousIO = true;
            await next(ctx);
        };
    });
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseElmah();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
