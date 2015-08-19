using HR.Infrastructure;
using HR.Infrastructure.Repository;
using HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HR.Controllers
{
    public class ImageController : ApiController
    {
        private IHRRepository repository;

        public ImageController(IHRRepository repository)
        {
            this.repository = repository;
        }

        public HttpResponseMessage GetImage(Guid id)
        {
            Image image = repository.GetAllImage.Where(_ => _.Id == id).FirstOrDefault();
            if (image == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);

            response.Content = new ByteArrayContent(image.Content);
            response.Content.Headers.Add("Content-Length", image.ContentLength.ToString());
            response.Content.Headers.Add("Content-Type", image.ContentType.ToString());

            return response;
        }
    }
}
