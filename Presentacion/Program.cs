
using LogicaAccesoDatos;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.ImplementacionCasosUso.EnvioCU;
using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using LogicaAplicacion.ImplementacionCasosUso.AgenciaCU;
using LogicaAplicacion.InterfacesCasosUso.InterfacesAgencia;
using LogicaAplicacion.InterfacesCasosUso.InterfacesEnvio;
using LogicaAplicacion.InterfacesCasosUso.InterfacesUsuario;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using LogicaAplicacion.ImplementacionCasosUso.AuditoriaCU;
using LogicaAplicacion.InterfacesCasosUso.InterfacesAuditoria;


namespace Presentacion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
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
            builder.Services.AddScoped<IBuscarEnvio, BuscarEnvio>();
            builder.Services.AddScoped<IFinalizarEnvio, FinalizarEnvio>();
            builder.Services.AddScoped<IAgregarComentario, AgregarComentario>();
            builder.Services.AddScoped<IAltaAuditoria, AltaAuditoria>();
            builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoriaEF>();



            builder.Services.AddSession();

            string cadenaConexion = builder.Configuration.GetConnectionString("CadenaConexion");
            builder.Services.AddDbContext<SistemaContext>(
                option => option.UseSqlServer(cadenaConexion));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //AGREGO SESION

            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
