using System.IO;

namespace FlickrClient.Upload.Data
{
    internal class UploadItem
    {
        public UploadItem(string filePath)
        {
            Location = new FileInfo(filePath);
        }

        public string Header { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public bool IsPublic { get; set; }
        public FileInfo Location { get; }
    }
}