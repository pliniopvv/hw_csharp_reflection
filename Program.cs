using hw_attributes;
using hw_attributes.Attributes;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        // ######################################################################################################
        // #                                                                                                    #
        // #              Injeção de dependências                                                               #
        // #                                                                                                    #

        Startup.Configure(builder.Services);

        var assembly = Assembly.GetExecutingAssembly(); // Ou substitua pelo assembly desejado

        var types = assembly.GetTypes();

        foreach (var type in types)
        {
            Console.Write(type.GetCustomAttributes(typeof(HelpAttribute), false).Length);
            Console.Write("\t");
            Console.Write(type.Name);
            Console.Write("\t");
            Console.Write(type.BaseType); // tipo da classe pai;
            Console.Write("\t");
            Console.Write(type);
            Console.WriteLine("");
        }
        Console.WriteLine("#################################################################");

        foreach (var type in types)
        {

            if (type.IsInterface)
            {
                Console.Write("INTERFACE INJETADA: ");
                Console.Write(type.Name + "  // ");
                foreach (var _type in types)
                {
                    if (_type.GetCustomAttributes(typeof(IgicServiceAttribute), true).Length > 0)
                        if (_type.IsClass && type.IsAssignableFrom(_type))
                        {
                            Console.Write("CLASSE INJETADA: ");
                            Console.WriteLine(_type.Name);
                            Startup.Configure(builder.Services, type, _type);
                        }
                }
            }
        }

        Console.WriteLine("#################################################################");

        // #                                                                                                    #
        // #                                                                                                    #
        // #                                                                                                    #
        // ######################################################################################################

        // Add services to the container.
        builder.Services.AddControllers();

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
    }
}