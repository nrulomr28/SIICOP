using SIICOP_V1._2.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIICOP_V1._2.Handlers
{
    /// <summary>
    /// Descripción breve de ArchivoEvidencia
    /// </summary>
    public class ArchivoEvidencia : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string id = context.Request.QueryString["id"];

            int idFotografia;

            if (!int.TryParse(id, out idFotografia))
            {
                context.Response.StatusCode = 400;
                return;
            }

            using (var ctx = new SIICOPEntities())
            {
                var archivo = ctx.tb_fotografia
                    .FirstOrDefault(x => x.idfotgrafia == idFotografia);

                if (archivo == null)
                {
                    context.Response.StatusCode = 404;
                    return;
                }

                if (string.IsNullOrWhiteSpace(archivo.ImgBase64))
                {
                    context.Response.StatusCode = 404;
                    return;
                }

                byte[] bytes;

                try
                {
                    bytes = Convert.FromBase64String(archivo.ImgBase64);
                }
                catch
                {
                    context.Response.StatusCode = 400;
                    context.Response.Write("El contenido del archivo no es Base64 válido.");
                    return;
                }

                string extension = archivo.ImagenExtencion
                    .Trim()
                    .ToLowerInvariant();

                string contentType;

                switch (extension)
                {
                    case ".pdf":
                        contentType = "application/pdf";
                        break;

                    case ".jpg":
                    case ".jpeg":
                        contentType = "image/jpeg";
                        break;

                    case ".png":
                        contentType = "image/png";
                        break;

                    default:
                        contentType = "application/octet-stream";
                        break;
                }

                context.Response.Clear();
                context.Response.ContentType = contentType;

                context.Response.AddHeader(
                    "Content-Disposition",
                    "inline; filename=evidencia_" + idFotografia + extension
                );

                context.Response.BinaryWrite(bytes);
                context.Response.End();
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}