using System;
using System.Windows.Forms;
using System.Drawing;

namespace OMR_Test
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void downloadClick(object sender, EventArgs e)
        {
            if (exception.Text != "")
            {
                exception.Text = "";
            }

            try
            {
                ImageConverter ic = new ImageConverter(path.Text);
            
                OMRLogic ol = new OMRLogic();

                original.Image = Image.FromFile(Path.OriginalPath);

                var image = ic.ConvertImage();

                double totalPoints;

                test.Image = ol.DetectCircles(image, ic.Image, out totalPoints).Bitmap;

                testResult.Text = totalPoints.ToString();

                Blanc blanc = new Blanc(name.Text, surname.Text, group.Text, subject.Text, totalPoints);

                DatabaseClient client = new DatabaseClient();

                client.SendData(blanc);
            }
            catch (Exception exc)
            {
                exception.Text = exc.Message + " image not found";
            }
        }
    }
}
