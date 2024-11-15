WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(

                      builder =>
                      {
                          builder
                                .AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});
builder.Services.AddControllers();
builder.Services.AddApplicationService();
builder.Services.AddInfrastructureService(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseExceptionHandling();
app.UseHttpsRedirection();

app.UseRouting();
app.MapControllers();
app.UseCors();
app.Run();