using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CoreHomework1
{
    public class MeasureTimeMiddleware
    {
        private readonly RequestDelegate next;

        public MeasureTimeMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var timer = new Stopwatch();
            timer.Start();
            //
            timer.Stop();
            await context.Response.WriteAsync($"Middleware class: {timer.ElapsedMilliseconds} milliseconds\n");
            await next.Invoke(context);
        }
    }
}
