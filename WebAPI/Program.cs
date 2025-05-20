
using LogicaAccesoDatos.Repositorios;
using LogicaAccesoDatos;
using LogicaAplicacion.ImplementacionCasosUso.AgenciaCU;
using LogicaAplicacion.ImplementacionCasosUso.EnvioCU;
using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using LogicaAplicacion.InterfacesCasosUso.InterfacesAgencia;
using LogicaAplicacion.InterfacesCasosUso.InterfacesEnvio;
using LogicaAplicacion.InterfacesCasosUso.InterfacesUsuario;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvioEF>();
            builder.Services.AddScoped<IAltaEnvioComun, AltaEnvioComun>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
            builder.Services.AddScoped<IAltaUsuario, AltaUsuario>();
            builder.Services.AddScoped<IListadoUsuario, ListadoUsuario>();
            builder.Services.AddScoped<IListadoClientes, ListadoClientes>();
            builder.Services.AddScoped<IEliminarUsuario, EliminarUsuario>();
            builder.Services.AddScoped<IBuscarUsuario, BuscarUsuario>();
            builder.Services.AddScoped<IModificarUsuario, ModificarUsuario>();
            builder.Services.AddScoped<IRepositorioAgencia, RepositorioAgenciaEF>();
            builder.Services.AddScoped<IListadoAgencias, ListadoAgencias>();
            builder.Services.AddScoped<IAltaEnvioUrgente, AltaEnvioUrgente>();
            builder.Services.AddScoped<IListadoEnvios, ListadoEnvio>();
            builder.Services.AddScoped<IEnvioPorTracking, EnvioPorTracking>();


            //builder.Services.AddSession();

            string cadenaConexion = builder.Configuration.GetConnectionString("CadenaConexion");
            builder.Services.AddDbContext<SistemaContext>(
                option => option.UseSqlServer(cadenaConexion));
            builder.Services.AddControllers();
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
