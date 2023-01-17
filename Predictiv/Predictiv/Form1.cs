using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Predictiv
{
    public partial class Form1 : Form
    {
        Bitmap originalImg, errorImg, decodedImg;
        int[,] originalMatrix, predictionMatrix, errorMatrix, originalMatrixDecoded, predictionMatrixDecoded, errorMatrixDecoded;
        int[] headerBytes;
        int predictorDecoded;
        string pathOriginalImage, pathEncodedImage, outputPath;

        public Form1()
        {
            InitializeComponent();
            originalMatrix = new int[256, 256];
            predictionMatrix = new int[256, 256];
            errorMatrix = new int[256, 256];
            originalMatrixDecoded = new int[256, 256];
            predictionMatrixDecoded = new int[256, 256];
            errorMatrixDecoded = new int[256, 256];
            errorImg = new Bitmap(256, 256);
            decodedImg = new Bitmap(256, 256);

            headerBytes = new int[1078];
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
                pathOriginalImage = imageFile;

                Console.WriteLine(headerBytes.Length);
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

        private void btnPredict_Click(object sender, EventArgs e)
        {
            predictionMatrix = Matrix.ComputePredictionMatrix(originalMatrix, comboBoxPredictor.SelectedIndex);
            errorMatrix = Matrix.ComputeErrorMatrix(originalMatrix, predictionMatrix);
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            string fileName = pathOriginalImage.Split('\\').Last();
            string path = fileName + "[" + comboBoxPredictor.SelectedIndex.ToString() + "].pre";
            BitWriter bitWriter = new BitWriter(path);

            byte[] allBytes = File.ReadAllBytes(pathOriginalImage);

            //header
            for (int i = 0; i < 1078; i++)
            {
                headerBytes[i] = allBytes[i];
                bitWriter.WriteNBits(8, allBytes[i]);
            }

            //predictor pe 4b
            bitWriter.WriteNBits(4, (uint)comboBoxPredictor.SelectedIndex);

            //valorile matricii de eroare
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    bitWriter.WriteNBits(9, (uint)(errorMatrix[i, j] + 255));
                }
            }

            //empty the buffer
            bitWriter.WriteNBits(7, 1);
            bitWriter.Dispose();
        }

        //------------------------------------DISPLAY BUTTONS------------------------------------------------
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
                }
            }
                
            pictureBoxErrorMatrix.Image = errorImg;
        }

        private void btnShowHistogram_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            int[] values = new int[511];

            for(int i = 0; i < 256; i++)
            {
                for(int j = 0; j < 256; j++)
                {
                    Console.WriteLine(originalMatrix[i,j] + "-" + errorMatrix[i,j]);
                }
            }

            switch (comboBoxHistogramImage.SelectedIndex)
            {
                case 0:
                    values = Matrix.GetPixelAppearances(originalMatrix);
                    break;
                case 1:
                    values = Matrix.GetPixelAppearances(errorMatrix);
                    break;
                case 2:
                    values = Matrix.GetPixelAppearances(originalMatrixDecoded);
                    break;
            }

            chart1.Series.Add("Histograma");
            double histogramScaleFactor = GetScaleFactor(textBoxHistogramScaleFactor);
            for (int i = 0; i < values.Length; i++)
            {
                chart1.Series["Histograma"].Points.AddXY(i - 255, (int)(values[i] * histogramScaleFactor));
            }

        }


        //-----------------------------------DECODE BUTTONS--------------------------------------------------

        private void btnLoadEncoded_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pre files (*.pre)|*.pre";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathEncodedImage = openFileDialog.FileName;
            }
        }


        private void btnDecode_Click(object sender, EventArgs e)
        {
            BitReader bitReader = new BitReader(pathEncodedImage);

            for (int i = 0; i < 1078; i++)
            {
                headerBytes[i] = bitReader.ReadNBits(8);
            }

            predictorDecoded = bitReader.ReadNBits(4);

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    int value = bitReader.ReadNBits(9);
                    errorMatrixDecoded[i,j] = value - 255;
                }
            }

            Matrix.ComputePredictionAndOriginalMatrixAfterDecoding(errorMatrixDecoded, predictionMatrixDecoded, originalMatrixDecoded, predictorDecoded);

            
            //display image on third picturebox
            for (int i = 0; i < originalMatrixDecoded.GetLength(0); i++)
            {
                for (int j = 0; j < originalMatrixDecoded.GetLength(1); j++)
                {
                    int value = originalMatrixDecoded[i,j];
                    if (value < 0) value = 0;
                    else if (value > 255) value = 255;
                    Color color = Color.FromArgb(255, value, value, value);

                    decodedImg.SetPixel(i, j, color);
                }
            }

            pictureBoxDecodedImage.Image = decodedImg;
        }

        private void btnSaveDecoded_Click(object sender, EventArgs e)
        {
            outputPath = pathEncodedImage.Split('\\').Last() + ".decoded.bmp";

            BitWriter bitWriter = new BitWriter(outputPath);

            for (int i = 0; i < headerBytes.Length; i++)
            {
                bitWriter.WriteNBits(8, (uint)headerBytes[i]);
            }

            for (int i = 0; i < originalMatrixDecoded.GetLength(0); i++)
            {
                for (int j = 0; j < originalMatrixDecoded.GetLength(1); j++)
                {
                    bitWriter.WriteNBits(8, (uint)(originalMatrixDecoded[i, j]));
                }
            }

            bitWriter.WriteNBits(7, 1);
            bitWriter.Dispose();
        }
    }
}
