using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrClient.Upload.Data
{
    internal class UploadItem
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public bool IsPublic { get; set; }
        public FileInfo Location { get; set; }
    }
}
