using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Core.Logging
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Loglama işlemleri burada gerçekleştirilir.
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Hata durumunda loglama işlemleri burada gerçekleştirilir.
                LogException(ex);
                throw;
            }
        }

        private void LogException(Exception ex)
        {
            // Exception'ı log dosyasına yazdırma işlemleri burada gerçekleştirilir
            string logMessage = $"[{DateTime.UtcNow}] Exception: {ex.ToString()}";
            string logFilePath = "logs/appLogs.txt";

            //C altında logs dosyası var onun altındaki txt de tutuyor ve appsettingsten dosya yolunu belirtiyorum.
            Log.Logger.Write(LogEventLevel.Error, ex.ToString());


            // Log dosyasına yazdırma işlemi
            using (StreamWriter writer = new StreamWriter(logFilePath, true, Encoding.UTF8))
            {

                writer.WriteLine(logMessage);
            }
        }
    }

    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LoggingMiddleware>();
        }
    }

}
