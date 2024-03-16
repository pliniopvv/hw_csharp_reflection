using hw_attributes;
using hw_attributes.Attributes;
using hw_attributes.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ######################################################################################################
// #                                                                                                    #
// # Injeção de dependências                                                                            #
// #                                                                                                    #

Startup.Configure(builder.Services);

var assembly = Assembly.GetExecutingAssembly(); // Ou substitua pelo assembly desejado

var types = assembly.GetTypes();

Dictionary<Type, Object> interfaces = new Dictionary<Type, Object>();
Dictionary<Type, Object> services = new Dictionary<Type, Object>();
foreach (var type in types)
{
    Console.Write(type.GetCustomAttributes(typeof(HelpAttribute), true).Length);
    Console.Write(" ");
    Console.WriteLine(type.Name);
    if (type.GetCustomAttributes(typeof(IgicServiceAttribute), true).Length > 0)
    {
        var attr = type.GetCustomAttribute<IgicServiceAttribute>().serviceType;
        if (attr == ServiceType.INTERFACE)
        {
            interfaces.Add(type, type);
        } else
        {
            services.Add(type, type);
        }
    }
}

foreach (var type in interfaces)
{
    Console.Write(interfaces[type.Key].GetType().Name);
    Console.Write(" ");
    Console.WriteLine(services[type.Key].GetType().Name);
}


Console.Write("Interfaces: ");
Console.WriteLine(interfaces.Count);
Console.Write("Services: ");
Console.WriteLine(services.Count);


//builder.Services.AddTransient<IService1, Service1>();

// #                                                                                                    #
// #                                                                                                    #
// #                                                                                                    #
// ######################################################################################################


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
