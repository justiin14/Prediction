namespace Predictiv
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnLoadImg = new System.Windows.Forms.Button();
            this.btnPredict = new System.Windows.Forms.Button();
            this.btnStore = new System.Windows.Forms.Button();
            this.btnShowErrorMatrix = new System.Windows.Forms.Button();
            this.btnLoadEncoded = new System.Windows.Forms.Button();
            this.btnDecode = new System.Windows.Forms.Button();
            this.btnSaveDecoded = new System.Windows.Forms.Button();
            this.textBoxErrorScaleFactor = new System.Windows.Forms.TextBox();
            this.btnShowHistogram = new System.Windows.Forms.Button();
            this.textBoxHistogramScaleFactor = new System.Windows.Forms.TextBox();
            this.comboBoxHistogramImage = new System.Windows.Forms.ComboBox();
            this.comboBoxPredictor = new System.Windows.Forms.ComboBox();
            this.labelPredictor = new System.Windows.Forms.Label();
            this.labelHistogramImage = new System.Windows.Forms.Label();
            this.labelHistogramScaleFactor = new System.Windows.Forms.Label();
            this.pictureBoxOriginalImage = new System.Windows.Forms.PictureBox();
            this.pictureBoxErrorMatrix = new System.Windows.Forms.PictureBox();
            this.pictureBoxDecodedImage = new System.Windows.Forms.PictureBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxErrorMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDecodedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadImg
            // 
            this.btnLoadImg.Location = new System.Drawing.Point(43, 297);
            this.btnLoadImg.Name = "btnLoadImg";
            this.btnLoadImg.Size = new System.Drawing.Size(113, 28);
            this.btnLoadImg.TabIndex = 0;
            this.btnLoadImg.Text = "Load image";
            this.btnLoadImg.UseVisualStyleBackColor = true;
            this.btnLoadImg.Click += new System.EventHandler(this.btnLoadImg_Click);
            // 
            // btnPredict
            // 
            this.btnPredict.Location = new System.Drawing.Point(162, 297);
            this.btnPredict.Name = "btnPredict";
            this.btnPredict.Size = new System.Drawing.Size(113, 28);
            this.btnPredict.TabIndex = 1;
            this.btnPredict.Text = "Predict";
            this.btnPredict.UseVisualStyleBackColor = true;
            this.btnPredict.Click += new System.EventHandler(this.btnPredict_Click);
            // 
            // btnStore
            // 
            this.btnStore.Location = new System.Drawing.Point(281, 297);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(113, 28);
            this.btnStore.TabIndex = 2;
            this.btnStore.Text = "Store";
            this.btnStore.UseVisualStyleBackColor = true;
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            // 
            // btnShowErrorMatrix
            // 
            this.btnShowErrorMatrix.Location = new System.Drawing.Point(539, 297);
            this.btnShowErrorMatrix.Name = "btnShowErrorMatrix";
            this.btnShowErrorMatrix.Size = new System.Drawing.Size(132, 28);
            this.btnShowErrorMatrix.TabIndex = 3;
            this.btnShowErrorMatrix.Text = "Show error matrix";
            this.btnShowErrorMatrix.UseVisualStyleBackColor = true;
            this.btnShowErrorMatrix.Click += new System.EventHandler(this.btnShowErrorMatrix_Click);
            // 
            // btnLoadEncoded
            // 
            this.btnLoadEncoded.Location = new System.Drawing.Point(760, 297);
            this.btnLoadEncoded.Name = "btnLoadEncoded";
            this.btnLoadEncoded.Size = new System.Drawing.Size(113, 28);
            this.btnLoadEncoded.TabIndex = 4;
            this.btnLoadEncoded.Text = "Load encoded";
            this.btnLoadEncoded.UseVisualStyleBackColor = true;
            this.btnLoadEncoded.Click += new System.EventHandler(this.btnLoadEncoded_Click);
            // 
            // btnDecode
            // 
            this.btnDecode.Location = new System.Drawing.Point(879, 297);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(113, 28);
            this.btnDecode.TabIndex = 5;
            this.btnDecode.Text = "Decode";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // btnSaveDecoded
            // 
            this.btnSaveDecoded.Location = new System.Drawing.Point(998, 297);
            this.btnSaveDecoded.Name = "btnSaveDecoded";
            this.btnSaveDecoded.Size = new System.Drawing.Size(113, 28);
            this.btnSaveDecoded.TabIndex = 6;
            this.btnSaveDecoded.Text = "Save decoded";
            this.btnSaveDecoded.UseVisualStyleBackColor = true;
            this.btnSaveDecoded.Click += new System.EventHandler(this.btnSaveDecoded_Click);
            // 
            // textBoxErrorScaleFactor
            // 
            this.textBoxErrorScaleFactor.Location = new System.Drawing.Point(476, 300);
            this.textBoxErrorScaleFactor.Name = "textBoxErrorScaleFactor";
            this.textBoxErrorScaleFactor.Size = new System.Drawing.Size(57, 22);
            this.textBoxErrorScaleFactor.TabIndex = 7;
            this.textBoxErrorScaleFactor.Text = "1.5";
            this.textBoxErrorScaleFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnShowHistogram
            // 
            this.btnShowHistogram.Location = new System.Drawing.Point(261, 490);
            this.btnShowHistogram.Name = "btnShowHistogram";
            this.btnShowHistogram.Size = new System.Drawing.Size(133, 28);
            this.btnShowHistogram.TabIndex = 8;
            this.btnShowHistogram.Text = "Show histogram";
            this.btnShowHistogram.UseVisualStyleBackColor = true;
            this.btnShowHistogram.Click += new System.EventHandler(this.btnShowHistogram_Click);
            // 
            // textBoxHistogramScaleFactor
            // 
            this.textBoxHistogramScaleFactor.Location = new System.Drawing.Point(261, 451);
            this.textBoxHistogramScaleFactor.Name = "textBoxHistogramScaleFactor";
            this.textBoxHistogramScaleFactor.Size = new System.Drawing.Size(133, 22);
            this.textBoxHistogramScaleFactor.TabIndex = 10;
            this.textBoxHistogramScaleFactor.Text = "0.3";
            this.textBoxHistogramScaleFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboBoxHistogramImage
            // 
            this.comboBoxHistogramImage.FormattingEnabled = true;
            this.comboBoxHistogramImage.Location = new System.Drawing.Point(261, 396);
            this.comboBoxHistogramImage.Name = "comboBoxHistogramImage";
            this.comboBoxHistogramImage.Size = new System.Drawing.Size(133, 24);
            this.comboBoxHistogramImage.TabIndex = 11;
            // 
            // comboBoxPredictor
            // 
            this.comboBoxPredictor.FormattingEnabled = true;
            this.comboBoxPredictor.Location = new System.Drawing.Point(43, 396);
            this.comboBoxPredictor.Name = "comboBoxPredictor";
            this.comboBoxPredictor.Size = new System.Drawing.Size(113, 24);
            this.comboBoxPredictor.TabIndex = 12;
            // 
            // labelPredictor
            // 
            this.labelPredictor.AutoSize = true;
            this.labelPredictor.Location = new System.Drawing.Point(40, 377);
            this.labelPredictor.Name = "labelPredictor";
            this.labelPredictor.Size = new System.Drawing.Size(64, 16);
            this.labelPredictor.TabIndex = 13;
            this.labelPredictor.Text = "Predictor:";
            // 
            // labelHistogramImage
            // 
            this.labelHistogramImage.AutoSize = true;
            this.labelHistogramImage.Location = new System.Drawing.Point(270, 373);
            this.labelHistogramImage.Name = "labelHistogramImage";
            this.labelHistogramImage.Size = new System.Drawing.Size(113, 16);
            this.labelHistogramImage.TabIndex = 14;
            this.labelHistogramImage.Text = "Histogram image:";
            // 
            // labelHistogramScaleFactor
            // 
            this.labelHistogramScaleFactor.AutoSize = true;
            this.labelHistogramScaleFactor.Location = new System.Drawing.Point(289, 432);
            this.labelHistogramScaleFactor.Name = "labelHistogramScaleFactor";
            this.labelHistogramScaleFactor.Size = new System.Drawing.Size(81, 16);
            this.labelHistogramScaleFactor.TabIndex = 15;
            this.labelHistogramScaleFactor.Text = "Scale factor:";
            // 
            // pictureBoxOriginalImage
            // 
            this.pictureBoxOriginalImage.Location = new System.Drawing.Point(98, 26);
            this.pictureBoxOriginalImage.Name = "pictureBoxOriginalImage";
            this.pictureBoxOriginalImage.Size = new System.Drawing.Size(256, 256);
            this.pictureBoxOriginalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxOriginalImage.TabIndex = 16;
            this.pictureBoxOriginalImage.TabStop = false;
            // 
            // pictureBoxErrorMatrix
            // 
            this.pictureBoxErrorMatrix.Location = new System.Drawing.Point(443, 26);
            this.pictureBoxErrorMatrix.Name = "pictureBoxErrorMatrix";
            this.pictureBoxErrorMatrix.Size = new System.Drawing.Size(256, 256);
            this.pictureBoxErrorMatrix.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxErrorMatrix.TabIndex = 17;
            this.pictureBoxErrorMatrix.TabStop = false;
            // 
            // pictureBoxDecodedImage
            // 
            this.pictureBoxDecodedImage.Location = new System.Drawing.Point(797, 26);
            this.pictureBoxDecodedImage.Name = "pictureBoxDecodedImage";
            this.pictureBoxDecodedImage.Size = new System.Drawing.Size(256, 256);
            this.pictureBoxDecodedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDecodedImage.TabIndex = 18;
            this.pictureBoxDecodedImage.TabStop = false;
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(443, 349);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Histograma";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(752, 304);
            this.chart1.TabIndex = 19;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 665);
            this.Controls.Add(this.pictureBoxDecodedImage);
            this.Controls.Add(this.pictureBoxErrorMatrix);
            this.Controls.Add(this.pictureBoxOriginalImage);
            this.Controls.Add(this.labelHistogramScaleFactor);
            this.Controls.Add(this.labelHistogramImage);
            this.Controls.Add(this.labelPredictor);
            this.Controls.Add(this.comboBoxPredictor);
            this.Controls.Add(this.comboBoxHistogramImage);
            this.Controls.Add(this.textBoxHistogramScaleFactor);
            this.Controls.Add(this.btnShowHistogram);
            this.Controls.Add(this.textBoxErrorScaleFactor);
            this.Controls.Add(this.btnSaveDecoded);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.btnLoadEncoded);
            this.Controls.Add(this.btnShowErrorMatrix);
            this.Controls.Add(this.btnStore);
            this.Controls.Add(this.btnPredict);
            this.Controls.Add(this.btnLoadImg);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Prediction";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxErrorMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDecodedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadImg;
        private System.Windows.Forms.Button btnPredict;
        private System.Windows.Forms.Button btnStore;
        private System.Windows.Forms.Button btnShowErrorMatrix;
        private System.Windows.Forms.Button btnLoadEncoded;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.Button btnSaveDecoded;
        private System.Windows.Forms.TextBox textBoxErrorScaleFactor;
        private System.Windows.Forms.Button btnShowHistogram;
        private System.Windows.Forms.TextBox textBoxHistogramScaleFactor;
        private System.Windows.Forms.ComboBox comboBoxHistogramImage;
        private System.Windows.Forms.ComboBox comboBoxPredictor;
        private System.Windows.Forms.Label labelPredictor;
        private System.Windows.Forms.Label labelHistogramImage;
        private System.Windows.Forms.Label labelHistogramScaleFactor;
        private System.Windows.Forms.PictureBox pictureBoxOriginalImage;
        private System.Windows.Forms.PictureBox pictureBoxErrorMatrix;
        private System.Windows.Forms.PictureBox pictureBoxDecodedImage;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

