namespace PreobrCalc.Custom_Elements
{
    partial class FilterSetupPanel
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.MainGroupBox = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.FIltersList = new System.Windows.Forms.ComboBox();
            this.FiltersMultNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.MainGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FiltersMultNum)).BeginInit();
            this.SuspendLayout();
            // 
            // MainGroupBox
            // 
            this.MainGroupBox.Controls.Add(this.label1);
            this.MainGroupBox.Controls.Add(this.FiltersMultNum);
            this.MainGroupBox.Controls.Add(this.chart1);
            this.MainGroupBox.Controls.Add(this.FIltersList);
            this.MainGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainGroupBox.Location = new System.Drawing.Point(0, 0);
            this.MainGroupBox.Name = "MainGroupBox";
            this.MainGroupBox.Size = new System.Drawing.Size(330, 118);
            this.MainGroupBox.TabIndex = 0;
            this.MainGroupBox.TabStop = false;
            this.MainGroupBox.Text = "Type[]";
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Location = new System.Drawing.Point(100, 10);
            this.chart1.Name = "chart1";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(225, 102);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // FIltersList
            // 
            this.FIltersList.FormattingEnabled = true;
            this.FIltersList.Location = new System.Drawing.Point(6, 19);
            this.FIltersList.Name = "FIltersList";
            this.FIltersList.Size = new System.Drawing.Size(92, 21);
            this.FIltersList.TabIndex = 0;
            this.FIltersList.SelectedIndexChanged += new System.EventHandler(this.FIltersList_SelectedIndexChanged);
            // 
            // FiltersMultNum
            // 
            this.FiltersMultNum.Location = new System.Drawing.Point(6, 68);
            this.FiltersMultNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FiltersMultNum.Name = "FiltersMultNum";
            this.FiltersMultNum.Size = new System.Drawing.Size(57, 20);
            this.FiltersMultNum.TabIndex = 2;
            this.FiltersMultNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FiltersMultNum.ValueChanged += new System.EventHandler(this.FIltersList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Количество:";
            // 
            // FilterSetupPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.MainGroupBox);
            this.Name = "FilterSetupPanel";
            this.Size = new System.Drawing.Size(330, 118);
            this.MainGroupBox.ResumeLayout(false);
            this.MainGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FiltersMultNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MainGroupBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox FIltersList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown FiltersMultNum;
    }
}
