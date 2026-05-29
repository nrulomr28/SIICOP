using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SIICOP_V1._2.Validaciones
{
    public class Imagenes
    {
     public bool ValidateVideoExtension(string nombreImg)
        {
            FileInfo info = new FileInfo(nombreImg);
            switch (info.Extension.ToLower())
            {
                case ".png":
                case ".PNG":
                case ".jpg":
                case ".JPG":
                case ".JPEG":
                case ".jpeg":
                case ".bmp":
                    return true;
                default:
                    return false;
            }
        }
    }
}