﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using TableauxApi.Models;
using TableauxApi.Services;

namespace TableauxApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        string[] origins = new string[] { "http://localhost:4200" }; 
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            
            services.AddCors(options =>
            {

                options.AddPolicy("AllowOrigin",
                builder => builder.WithOrigins("http://localhost:4200/cart"));
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("localhost:4200",
                                        "localhost:4200/cart")
                                        .AllowAnyHeader()
                            .AllowAnyMethod(); ;
                });
            });

            services.AddScoped<TableauService>();
            services.AddScoped<OrderService>();

            services.AddDbContext<TableauContext>(opt =>
            opt.UseInMemoryDatabase("TableauList"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(builder =>
    builder.WithOrigins("http://localhost:4200"));
            
            app.UseHttpsRedirection();
            app.UseCors(b => b.AllowAnyMethod().AllowAnyHeader().WithOrigins(origins));
            app.UseMvc();
            app.UseCookiePolicy();
            app.UseAuthentication();
            
        }
    }
}