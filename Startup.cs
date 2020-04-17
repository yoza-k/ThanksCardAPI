using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using ThanksCardAPI.Models;

namespace ThanksCardAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // EntityFramework DbContext で PostgreSQL を使うように設定。
            // DB接続情報は appsettings.Development.json, appsettings.json に記載されている。
            services.AddDbContext<ApplicationContext>(opt =>
            {
                opt.UseNpgsql(Configuration.GetConnectionString("ApplicationContext"));
            });

            // JSONシリアル化で循環参照を無視
            //services.AddMvc().AddJsonOptions(options => {
            //    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //                }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddControllers();

            // API を一覧表示する Swagger の設定
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "ThanksCard API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            // SwaggerドキュメントをJSONとして出力する設定
            app.UseSwagger();

            // Swagger UIを表示する設定
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "ThanksCard API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
