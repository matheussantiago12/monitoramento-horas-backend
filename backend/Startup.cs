using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Infra.Data.Context;
using backend.Infra.Data.Repository;
using backend.Service;
using backend.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MonitoramentoHorasContext>(options => options.UseMySQL(Configuration.GetConnectionString("MonitoramentoHorasConnection")));

            services.AddControllers();

            services.AddSwaggerGen();

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });



            services.AddScoped<IRepository<TipoPessoa>, TipoPessoaRepository>();
            services.AddTransient<IService<TipoPessoa>, TipoPessoaService>();

            services.AddScoped<IRepository<Pessoa>, PessoaRepository>();
            services.AddTransient<IService<Pessoa>, PessoaService>();

            services.AddScoped<IRepository<Usuario>, UsuarioRepository>();
            services.AddTransient<IService<Usuario>, UsuarioService>();

            services.AddScoped<IRepository<Rastreamento>, RastreamentoRepository>();
            services.AddTransient<IService<Rastreamento>, RastreamentoService>();

            services.AddScoped<RastreamentoRepository, RastreamentoRepository>();
            services.AddTransient<RastreamentoService, RastreamentoService>();

            services.AddScoped<IRepository<Setor>, SetorRepository>();
            services.AddTransient<IService<Setor>, SetorService>();

            services.AddScoped<IRepository<Equipe>, EquipeRepository>();
            services.AddTransient<IService<Equipe>, EquipeService>();

            services.AddScoped<IRepository<IntegranteEquipe>, IntegranteEquipeRepository>();
            services.AddTransient<IService<IntegranteEquipe>, IntegranteEquipeService>();

            services.AddScoped<IRepository<Configuracao>, ConfiguracaoRepository>();
            services.AddTransient<IService<Configuracao>, ConfiguracaoService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Monitoramento de Horas.");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true));

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
