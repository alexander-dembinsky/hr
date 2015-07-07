using HR.Infrastructure;
using HR.Models;
using NHibernate;
using Ninject;
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
        public HttpResponseMessage GetImage(Guid id)
        {
            ISessionFactory sessionFactory = HibernateUtil.GetSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                Image image = session.Get<Image>(id);
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
}
