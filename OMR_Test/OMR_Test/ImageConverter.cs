using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;

namespace OMR_Test
{
    class ImageConverter
    {
        Image<Bgr, byte> image; 

        public ImageConverter(string path)
        {
            image = new Image<Bgr, byte>((Bitmap)Bitmap.FromFile($@"{path}"));
        }

        public Image<Gray, byte> ConvertImage()
        {
            return image.Convert<Gray, byte>();
        }

        public Image<Bgr, byte> Image
        {
            get
            {
                return image;
            }
        }
    }
}
