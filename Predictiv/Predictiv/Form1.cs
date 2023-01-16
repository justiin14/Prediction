using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Predictiv
{
    public partial class Form1 : Form
    {
        Bitmap originalImage;
        string pathEncodedImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeDropdowns();
        }

        private void InitializeDropdowns()
        {
            comboBoxHistogramImage.Items.Add("Original");
            comboBoxHistogramImage.Items.Add("Error prediction");
            comboBoxHistogramImage.Items.Add("Decoded");
            comboBoxHistogramImage.SelectedIndex = 0;

            comboBoxPredictor.Items.Add("128");
            comboBoxPredictor.Items.Add("A");
            comboBoxPredictor.Items.Add("B");
            comboBoxPredictor.Items.Add("C");
            comboBoxPredictor.Items.Add("A+B-C");
            comboBoxPredictor.Items.Add("A+(B-C)/2");
            comboBoxPredictor.Items.Add("B+(A-C)/2");
            comboBoxPredictor.Items.Add("(A+B)/2");
            comboBoxPredictor.Items.Add("JPEG LS");
            comboBoxPredictor.SelectedIndex = 0;
        }

        private double GetScaleFactor(TextBox textbox)
        {
            double number;
            if (Double.TryParse(textbox.Text, out number))
            {
                return number;
            }

            return -1;
        }

        private void btnLoadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Bitmap files (*.bmp)|*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imageFile = openFileDialog.FileName;
                pictureBoxOriginalImage.Image = Image.FromFile(imageFile);
                originalImage = new Bitmap(imageFile);
            }

            for(int i = 0; i < originalImage.Height; i++)
            {
                for(int j = 0; j < originalImage.Width; j++)
                {
                    var pixel = originalImage.GetPixel(i, j);
                    var value = (int)((pixel.R * 0.3) + (pixel.G * 0.59) + (pixel.B * 0.11));
                    Console.Write(value + " ");
                }
                
                Console.WriteLine();
            }
        }

        private void btnLoadEncoded_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pre files (*.pre)|*.pre";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathEncodedImage = openFileDialog.FileName;
                ReadEncodedFileContent(pathEncodedImage);
            }
        }

        private void ReadEncodedFileContent(string pathEncodedImage)
        {
            throw new NotImplementedException();
        }
    }
}
