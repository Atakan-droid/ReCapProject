using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CORE.Utilities.FileHelper
{
   public class Filehelper
    {
        
        public static string AddAsync(IFormFile file)
        {

            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                    file.CopyTo(stream);


            var newGuidName = newGuid(file);

            var imagePathResult = newPath(newGuidName);

            File.Move(sourcepath, imagePathResult);

            var result = newPathForImage(newGuidName);

            return result;
        }

        public static string UpdateAsync(string sourcePath, IFormFile file)
        {
            var newGuidName = newGuid(file);

            var imagePathResult = newPath(newGuidName);

            File.Move(sourcePath, imagePathResult);

            var result = newPathForImage(newGuidName);

            //File.Copy(sourcePath,result);

            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            File.Delete(sourcePath);

            return result;
        }

        public static void DeleteAsync(string path)
        {
            File.Delete(path);
        }

        public static string newPath(string guid)
        {

            string path = @"wwwroot/Images";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string result = $@"{path}\{guid}";

            return result;
        }
        public static string newPathForImage(string guid)
        {
            string path = @"Images";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string result = $@"{path}\{guid}";

            return result;
        }
        public static string newGuid(IFormFile file)
        {
            System.IO.FileInfo ff = new System.IO.FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            var creatingUniqueFilename = Guid.NewGuid().ToString("N")
               + "_" + DateTime.Now.Month + "_"
               + DateTime.Now.Day + "_"
               + DateTime.Now.Year + fileExtension;
            return creatingUniqueFilename;
        }



    }
}
