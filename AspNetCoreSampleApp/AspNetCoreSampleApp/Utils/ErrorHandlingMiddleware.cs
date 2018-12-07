//using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace AspNetCoreSampleApp.Utils
{
    public class ErrorHandlingMiddleware
    {
        private readonly Microsoft.AspNetCore.Http.RequestDelegate next;
        private IHostingEnvironment _hostingEnv;
        
        public ErrorHandlingMiddleware(Microsoft.AspNetCore.Http.RequestDelegate next, IHostingEnvironment hostingEnv)
        {
            this.next = next;
            this._hostingEnv = hostingEnv;
        }

        public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                HandleExceptionAsync(context, ex,_hostingEnv);
            }
        }

        public static Task HandleExceptionAsync(Microsoft.AspNetCore.Http.HttpContext context, Exception exception,IHostingEnvironment pathenv)
        {
            string newfilepath = pathenv.WebRootPath.ToString() + "/logger.txt";

            //System.IO.File.WriteAllText(filepath + "/logger.txt", result.ToString());
            using (StreamWriter sw = File.AppendText(newfilepath))
            {
                sw.WriteLine("----------------------------"+DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt") +"-----------------------------------------");
                sw.WriteLine("Error" + exception.Message);
                sw.WriteLine("Error" + exception.StackTrace);
            }

            //throw exception;
            return null;
            //return context.Response.WriteAsync(result);
        }
    }
}