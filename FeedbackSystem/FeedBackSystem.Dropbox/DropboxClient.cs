namespace DropboxUpload
{
    using System;
    using System.Linq;
    class DropboxClient
    {
        static void Main()
        {
            var droboxManager = new DropboxManager();
            var imageName = droboxManager.LoadImage("../../smile-coffee.jpg");
            Console.WriteLine("File {0} uploaded", imageName);
        }
    }
}
