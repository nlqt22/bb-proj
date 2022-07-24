namespace CovidTrackerApplication
{
    partial class MainWindow
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
            this.updateButton = new System.Windows.Forms.Button();
            this.totalInternalCasesBT = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.casesChart = new LiveCharts.Wpf.CartesianChart();
            this.showCasesBT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(13, 13);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(250, 30);
            this.updateButton.TabIndex = 0;
            this.updateButton.Text = "button1";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // totalInternalCasesBT
            // 
            this.totalInternalCasesBT.AutoSize = true;
            this.totalInternalCasesBT.Location = new System.Drawing.Point(13, 72);
            this.totalInternalCasesBT.Name = "totalInternalCasesBT";
            this.totalInternalCasesBT.Size = new System.Drawing.Size(35, 13);
            this.totalInternalCasesBT.TabIndex = 1;
            this.totalInternalCasesBT.Text = "label1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 111);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(311, 315);
            this.dataGridView1.TabIndex = 2;
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(364, 111);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(415, 315);
            this.elementHost1.TabIndex = 3;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.casesChart;
            // 
            // showCasesBT
            // 
            this.showCasesBT.Location = new System.Drawing.Point(364, 19);
            this.showCasesBT.Name = "showCasesBT";
            this.showCasesBT.Size = new System.Drawing.Size(75, 23);
            this.showCasesBT.TabIndex = 4;
            this.showCasesBT.Text = "Số ca nhiễm";
            this.showCasesBT.UseVisualStyleBackColor = true;
            this.showCasesBT.Click += new System.EventHandler(this.showCasesBT_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.showCasesBT);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.totalInternalCasesBT);
            this.Controls.Add(this.updateButton);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label totalInternalCasesBT;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private LiveCharts.Wpf.CartesianChart casesChart;
        private System.Windows.Forms.Button showCasesBT;
    }
}