namespace KB.Utils
{
    public static class FileUploader
    {
        public static async Task<string> UploadAsync(IWebHostEnvironment hostEnvironment, IFormFile img)
        {
            string wwwRootPath = hostEnvironment.WebRootPath;
            string fileName = FileNameControl(Path
                .GetFileNameWithoutExtension(img.FileName));
            string extension = Path.GetExtension(img.FileName);
            fileName = fileName + DateTime.Now.ToString("yyyyMMddhhmmss") + Guid.NewGuid().ToString().ToLower().Replace("-","") + extension;

            string path = Path.Combine(wwwRootPath + "/uploads/", fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await img.CopyToAsync(fileStream);
            }

            return "/uploads/" + fileName;
        }

        public static async Task<bool> DeleteAsync(IWebHostEnvironment hostEnvironment, string? path)
        {
            try
            {
                if (!string.IsNullOrEmpty(path))
                {
                    string wwwRootPath = hostEnvironment.WebRootPath;
                    string filePath = Path.Combine(wwwRootPath + path);
                    FileInfo fileInfo = new FileInfo(filePath);
                    if (fileInfo.Exists)
                    {
                        fileInfo.Delete();
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static string FileNameControl(string filename)
        {
            filename = filename.Replace("ş", "s");
            filename = filename.Replace("ç", "c");
            filename = filename.Replace("ü", "u");
            filename = filename.Replace("ğ", "g");
            filename = filename.Replace("ı", "i");
            filename = filename.Replace("ö", "o");
            filename = filename.Replace("Ş", "S");
            filename = filename.Replace("Ç", "C");
            filename = filename.Replace("Ü", "U");
            filename = filename.Replace("Ğ", "G");
            filename = filename.Replace("İ", "I");
            filename = filename.Replace("Ö", "O");
            filename = filename.Replace("-", "");
            filename = filename.Replace("_", "");
            filename = filename.Replace("?", "");
            filename = filename.Replace("!", "");
            filename = filename.Replace("#", "");
            filename = filename.Replace("*", "");
            filename = filename.Replace("/", "");
            filename = filename.Replace("&", "");
            filename = filename.Replace("%", "");
            filename = filename.Replace("$", "");
            filename = filename.Replace("^", "");
            filename = filename.Replace("{", "");
            filename = filename.Replace("}", "");
            filename = filename.Replace("[", "");
            filename = filename.Replace("]", "");
            filename = filename.Replace(")", "");
            filename = filename.Replace("(", "");
            filename = filename.Replace(":", "");
            filename = filename.Replace(" ", "");

            return filename;
        }
    }
}
