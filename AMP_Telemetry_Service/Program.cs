namespace AMP_Telemetry_Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container via dependency injection.

            // The JsonOptions prevent the automatic adjustment of json properties to camelCase (this broke e.g. TOO_MANY_BITRATE_SWITCHES -> toO_MANY_BITRATE_SWITCHES).
            builder.Services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // Swagger is used for REST API testing during development.
                // Usually accessible through https://localhost:<port>/swagger, depending on configuration.
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}