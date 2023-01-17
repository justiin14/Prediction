using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Predictiv
{
    public partial class Form1 : Form
    {
        Bitmap originalImg, errorImg;
        int[,] originalMatrix, predictionMatrix, errorMatrix;
        string pathEncodedImage;

        public Form1()
        {
            InitializeComponent();
            originalMatrix = new int[256, 256];
            predictionMatrix = new int[256, 256];
            errorMatrix = new int[256, 256];
            errorImg = new Bitmap(256, 256);
        }

        //-------------------------VISUAL THINGS------------------------------------------
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

        //------------------------BUTTONS FUNCTIONALITY---------------------------------------
        private void btnLoadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Bitmap files (*.bmp)|*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imageFile = openFileDialog.FileName;
                pictureBoxOriginalImage.Image = Image.FromFile(imageFile);
                originalImg = new Bitmap(imageFile);

                Color pixel;
                int value;
                for (int i = 0; i < originalImg.Height; i++)
                {
                    for (int j = 0; j < originalImg.Width; j++)
                    {
                        pixel = originalImg.GetPixel(i, j);
                        value = (int)((pixel.R * 0.3) + (pixel.G * 0.59) + (pixel.B * 0.11));
                        originalMatrix[i, j] = value;
                    }
                }
            }
        }

        private void btnShowErrorMatrix_Click(object sender, EventArgs e)
        {
            int value;
            double scaleFactor = GetScaleFactor(textBoxErrorScaleFactor);
            for(int i=0;i< errorMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < errorMatrix.GetLength(1); j++)
                {
                    value = (int)(128 + errorMatrix[i, j] * scaleFactor);
                    if (value < 0) value = 0;
                    else if (value > 255) value = 255;
                    Color color = Color.FromArgb(255, value, value, value);

                    errorImg.SetPixel(i, j, color);
                    Console.Write(color+" ");
                }
                Console.WriteLine();
            }
                
            pictureBoxErrorMatrix.Image = errorImg;
            pictureBoxErrorMatrix.Refresh();
        }

        private void btnShowHistogram_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            int[] values = new int[511];

            switch (comboBoxHistogramImage.SelectedIndex)
            {
                case 0:
                    values = Matrix.GetPixelAppearances(originalMatrix);
                    break;
                case 1:
                    values = Matrix.GetPixelAppearances(predictionMatrix);
                    break;
                case 2:
                    values = Matrix.GetPixelAppearances(errorMatrix);
                    break;
            }

            chart1.Series.Add("Histograma");
            double histogramScaleFactor = GetScaleFactor(textBoxHistogramScaleFactor);
            for (int i = 0; i < values.Length; i++)
            {
                chart1.Series["Histograma"].Points.AddXY(i-255, (int)(values[i]*histogramScaleFactor));
            }
            
        }

        private void btnStore_Click(object sender, EventArgs e)
        {

        }

        private void btnPredict_Click(object sender, EventArgs e)
        {
            predictionMatrix = Matrix.ComputePredictionMatrix(originalMatrix, comboBoxPredictor.SelectedIndex);
            errorMatrix = Matrix.ComputeErrorMatrix(originalMatrix, predictionMatrix);

            //for(int i = 0; i < originalMatrix.GetLength(0); i++)
            //{
            //    for(int j=0; j<originalMatrix.GetLength(1); j++)
            //    {
            //        Console.WriteLine(originalMatrix[i,j] +"-"+predictionMatrix[i,j]+"="+errorMatrix[i,j]);
            //    }
            //}
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
