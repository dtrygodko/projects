using System.Collections.Generic;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;

namespace OMR_Test
{
    class OMRLogic
    {
        static Image<Gray, byte> original = new Image<Bgr, byte>((Bitmap)Bitmap.FromFile(Path.OriginalPath)).Convert<Gray, byte>();

        static Dictionary<Point, bool> centers = new Dictionary<Point, bool>() { { new Point(61, 37), true}, { new Point(110, 37), false }, { new Point(159, 37), false }, { new Point(209, 36), false }, { new Point(260, 35), false },
                                                                                 { new Point(62, 81), false}, { new Point(111, 81), true }, { new Point(159, 81), false }, { new Point(208, 80), false }, { new Point(259, 80), false },
                                                                                 { new Point(63, 125), false}, { new Point(111, 125), false }, { new Point(159, 125), true }, { new Point(208, 125), false }, { new Point(259, 125), false },
                                                                                 { new Point(64, 168), false}, { new Point(112, 168), true }, { new Point(159, 168), false }, { new Point(208, 168), false }, { new Point(259, 168), false },
                                                                                 { new Point(64, 211), false}, { new Point(112, 211), false }, { new Point(160, 211), false }, { new Point(208, 211), true }, { new Point(258, 210), false },
                                                                                 { new Point(64, 253), false}, { new Point(112, 253), false }, { new Point(160, 253), true }, { new Point(208, 253), true }, { new Point(258, 253), false },
                                                                                 { new Point(64, 295), false}, { new Point(112, 295), true }, { new Point(159, 295), false }, { new Point(207, 295), false }, { new Point(258, 295), false },
                                                                                 { new Point(64, 336), false}, { new Point(112, 336), false }, { new Point(159, 336), false }, { new Point(206, 337), true }, { new Point(258, 337), false },
                                                                                 { new Point(64, 378), false}, { new Point(112, 379), false }, { new Point(159, 379), false }, { new Point(207, 379), false }, { new Point(257, 380), true },
                                                                                 { new Point(64, 420), false}, { new Point(112, 421), false }, { new Point(158, 421), false }, { new Point(207, 421), true }, { new Point(257, 422), false },
                                                                                 { new Point(63, 463), false}, { new Point(110, 463), false }, { new Point(158, 464), true }, { new Point(206, 464), false }, { new Point(257, 464), false },
                                                                                 { new Point(64, 504), false}, { new Point(111, 505), true }, { new Point(158, 506), false }, { new Point(206, 507), false }, { new Point(256, 507), false },
                                                                                 { new Point(63, 547), false}, { new Point(110, 547), false }, { new Point(157, 548), true }, { new Point(206, 549), false }, { new Point(256, 550), false },
                                                                                 { new Point(64, 588), false}, { new Point(111, 588), false }, { new Point(158, 589), false }, { new Point(205, 591), true }, { new Point(256, 593), false }};

        public Image<Bgr, byte> DetectCircles(Image<Gray, byte> image, Image<Bgr, byte> imageColor, out double totalPoints)
        {
            Matrix<int> matrixOriginal = new Matrix<int>(original.Height, original.Width);
            CvInvoke.cvConvertScale(original, matrixOriginal, 1, 0);

            Matrix<int> matrixTest = new Matrix<int>(image.Height, image.Width);
            CvInvoke.cvConvertScale(image, matrixTest, 1, 0);

            totalPoints = 0;
            float radius = 16;
            double correctAnsPoints = 0.2;

            Bgr green = new Bgr(0, 255, 0), red = new Bgr(0, 0, 255);

            foreach (var c in centers)
            {
                bool colorInBounds = matrixTest[c.Key.Y, c.Key.X] <= matrixOriginal[c.Key.Y, c.Key.X] + 10 && matrixTest[c.Key.Y, c.Key.X] >= matrixOriginal[c.Key.Y, c.Key.X] - 10;

                if (colorInBounds)
                {
                    if (c.Value)
                    {
                        imageColor.Draw(new CircleF(new PointF(c.Key.X, c.Key.Y), radius), green, 0);

                        totalPoints += correctAnsPoints;
                    }
                    else
                    {
                        imageColor.Draw(new CircleF(new PointF(c.Key.X, c.Key.Y), radius), green);

                        totalPoints += correctAnsPoints;
                    }
                }
                else
                {
                    if (c.Value)
                    {
                        imageColor.Draw(new CircleF(new PointF(c.Key.X, c.Key.Y), radius), red);
                    }
                    else
                    {
                        imageColor.Draw(new CircleF(new PointF(c.Key.X, c.Key.Y), radius), red, 0);
                    }
                }
            }

            return imageColor;
        }
    }
}
