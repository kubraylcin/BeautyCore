using BeautyCore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Domain.Entities
{
    public class ImageFile : BaseEntity
    {
        public string FileName { get; set; } = string.Empty; // Kaydedilen benzersiz isim (GUID.jpg gibi)
        public string OriginalName { get; set; } = string.Empty; // Kullanıcının yüklediği isim
        public string FileExtension { get; set; } = string.Empty; // .jpg, .png
        public string ContentType { get; set; } = string.Empty; // image/jpeg
        public long FileSize { get; set; } // Byte cinsinden
        public string StoragePath { get; set; } = string.Empty; // Fiziksel yol veya URL
    }
}
