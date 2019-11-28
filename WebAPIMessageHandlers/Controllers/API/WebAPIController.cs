using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Net.Http.Headers;

namespace WebAPIMessageHandlers.Controllers.API
{
    public class WebAPIController : ApiController
    {
        public IHttpActionResult GetApiProcessLifeCycle()
        {
            //return Ok(File.ReadAllBytes(@"D:\GitHUB\WebAPIMessageHandlers\WebAPIMessageHandlers\Content\Images\aspnet-web-api-poster.pdf"));//Returns the bytes as string

            //byte[] bytes = File.ReadAllBytes(@"D:\GitHUB\WebAPIMessageHandlers\WebAPIMessageHandlers\Content\Images\aspnet-web-api-poster.pdf");
            //HttpRequestMessage response = new HttpRequestMessage();

            //response.Content.Headers.ContentType = new MediaTypeHeaderValue()
            //return Ok(response);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            string localfilepath = @"D:\GitHUB\WebAPIMessageHandlers\WebAPIMessageHandlers\Content\Images\aspnet-web-api-poster.pdf";

            byte[] bytes = File.ReadAllBytes(localfilepath);

            response.Content = new ByteArrayContent(bytes);

            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment"); //For Download, if not not needed , this line and below can be commented so that browsers PDF viewer displays the PDF

            response.Content.Headers.ContentDisposition.FileName = "Web API Process Life Cycle.pdf";

            return ResponseMessage(response);
        }
    }
}
