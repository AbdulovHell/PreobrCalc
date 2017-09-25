namespace PreobrCalc
{
    partial class FilterConstruct
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button2 = new System.Windows.Forms.Button();
            this.FilterPointGrid = new System.Windows.Forms.DataGridView();
            this.Freq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Att = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToFileBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadBaseAndOverride = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadBaseAndSum = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveBaseDialog = new System.Windows.Forms.SaveFileDialog();
            this.FiltNameEdit = new System.Windows.Forms.TextBox();
            this.FiltersList = new System.Windows.Forms.ComboBox();
            this.LoadBaseDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveFiltBtn = new System.Windows.Forms.Button();
            this.DeleteFilterBtn = new System.Windows.Forms.Button();
            this.ClearPointsTableBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterPointGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.Maximum = 50D;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Cursor = System.Windows.Forms.Cursors.Default;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(281, 118);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "Series2";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.Legend = "Legend1";
            series3.MarkerSize = 10;
            series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Diamond;
            series3.Name = "Series3";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(812, 280);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(911, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 21);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FilterPointGrid
            // 
            this.FilterPointGrid.AllowUserToOrderColumns = true;
            this.FilterPointGrid.AllowUserToResizeColumns = false;
            this.FilterPointGrid.AllowUserToResizeRows = false;
            this.FilterPointGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FilterPointGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Freq,
            this.Att});
            this.FilterPointGrid.Location = new System.Drawing.Point(12, 53);
            this.FilterPointGrid.MultiSelect = false;
            this.FilterPointGrid.Name = "FilterPointGrid";
            this.FilterPointGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.FilterPointGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.FilterPointGrid.Size = new System.Drawing.Size(243, 345);
            this.FilterPointGrid.TabIndex = 3;
            this.FilterPointGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.FilterPointGrid_CellValueChanged);
            this.FilterPointGrid.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // Freq
            // 
            this.Freq.Frozen = true;
            this.Freq.HeaderText = "Freq";
            this.Freq.Name = "Freq";
            this.Freq.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Freq.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Att
            // 
            this.Att.Frozen = true;
            this.Att.HeaderText = "Att";
            this.Att.Name = "Att";
            this.Att.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Att.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1105, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveToFileBtn,
            this.LoadBaseAndOverride,
            this.LoadBaseAndSum});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // SaveToFileBtn
            // 
            this.SaveToFileBtn.Name = "SaveToFileBtn";
            this.SaveToFileBtn.Size = new System.Drawing.Size(357, 22);
            this.SaveToFileBtn.Text = "Сохранить базу в файл...";
            this.SaveToFileBtn.Click += new System.EventHandler(this.SaveToFileBtn_Click);
            // 
            // LoadBaseAndOverride
            // 
            this.LoadBaseAndOverride.Name = "LoadBaseAndOverride";
            this.LoadBaseAndOverride.Size = new System.Drawing.Size(357, 22);
            this.LoadBaseAndOverride.Text = "Загрузить базу из файла и перезаписать текущую...";
            this.LoadBaseAndOverride.Click += new System.EventHandler(this.LoadBaseAndOverride_Click);
            // 
            // LoadBaseAndSum
            // 
            this.LoadBaseAndSum.Name = "LoadBaseAndSum";
            this.LoadBaseAndSum.Size = new System.Drawing.Size(357, 22);
            this.LoadBaseAndSum.Text = "Загрузить базу из файла и обьеденить с текущей...";
            this.LoadBaseAndSum.Click += new System.EventHandler(this.LoadBaseAndSum_Click);
            // 
            // SaveBaseDialog
            // 
            this.SaveBaseDialog.Filter = "База фильтров|*.dat";
            this.SaveBaseDialog.SupportMultiDottedExtensions = true;
            this.SaveBaseDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveBaseDialog_FileOk);
            // 
            // FiltNameEdit
            // 
            this.FiltNameEdit.Location = new System.Drawing.Point(12, 27);
            this.FiltNameEdit.Name = "FiltNameEdit";
            this.FiltNameEdit.Size = new System.Drawing.Size(243, 20);
            this.FiltNameEdit.TabIndex = 5;
            // 
            // FiltersList
            // 
            this.FiltersList.FormattingEnabled = true;
            this.FiltersList.Location = new System.Drawing.Point(394, 29);
            this.FiltersList.Name = "FiltersList";
            this.FiltersList.Size = new System.Drawing.Size(121, 21);
            this.FiltersList.TabIndex = 6;
            this.FiltersList.SelectedIndexChanged += new System.EventHandler(this.FiltersList_SelectedIndexChanged);
            // 
            // LoadBaseDialog
            // 
            this.LoadBaseDialog.AddExtension = false;
            this.LoadBaseDialog.Filter = "База фильтров|*.dat";
            this.LoadBaseDialog.ReadOnlyChecked = true;
            this.LoadBaseDialog.ShowReadOnly = true;
            this.LoadBaseDialog.SupportMultiDottedExtensions = true;
            this.LoadBaseDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.LoadBaseDialog_FileOk);
            // 
            // SaveFiltBtn
            // 
            this.SaveFiltBtn.Location = new System.Drawing.Point(261, 27);
            this.SaveFiltBtn.Name = "SaveFiltBtn";
            this.SaveFiltBtn.Size = new System.Drawing.Size(70, 20);
            this.SaveFiltBtn.TabIndex = 7;
            this.SaveFiltBtn.Text = "Сохранить";
            this.SaveFiltBtn.UseVisualStyleBackColor = true;
            this.SaveFiltBtn.Click += new System.EventHandler(this.SaveFiltBtn_Click);
            // 
            // DeleteFilterBtn
            // 
            this.DeleteFilterBtn.Location = new System.Drawing.Point(521, 29);
            this.DeleteFilterBtn.Name = "DeleteFilterBtn";
            this.DeleteFilterBtn.Size = new System.Drawing.Size(75, 21);
            this.DeleteFilterBtn.TabIndex = 8;
            this.DeleteFilterBtn.Text = "Удалить";
            this.DeleteFilterBtn.UseVisualStyleBackColor = true;
            this.DeleteFilterBtn.Click += new System.EventHandler(this.DeleteFilterBtn_Click);
            // 
            // ClearPointsTableBtn
            // 
            this.ClearPointsTableBtn.Location = new System.Drawing.Point(261, 53);
            this.ClearPointsTableBtn.Name = "ClearPointsTableBtn";
            this.ClearPointsTableBtn.Size = new System.Drawing.Size(70, 21);
            this.ClearPointsTableBtn.TabIndex = 9;
            this.ClearPointsTableBtn.Text = "Очистить";
            this.ClearPointsTableBtn.UseVisualStyleBackColor = true;
            this.ClearPointsTableBtn.Click += new System.EventHandler(this.ClearPointsTableBtn_Click);
            // 
            // FilterConstruct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 408);
            this.Controls.Add(this.ClearPointsTableBtn);
            this.Controls.Add(this.DeleteFilterBtn);
            this.Controls.Add(this.SaveFiltBtn);
            this.Controls.Add(this.FiltersList);
            this.Controls.Add(this.FiltNameEdit);
            this.Controls.Add(this.FilterPointGrid);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FilterConstruct";
            this.Text = "FilterConstruct";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterPointGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView FilterPointGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Freq;
        private System.Windows.Forms.DataGridViewTextBoxColumn Att;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToFileBtn;
        private System.Windows.Forms.SaveFileDialog SaveBaseDialog;
        private System.Windows.Forms.TextBox FiltNameEdit;
        private System.Windows.Forms.ComboBox FiltersList;
        private System.Windows.Forms.ToolStripMenuItem LoadBaseAndOverride;
        private System.Windows.Forms.ToolStripMenuItem LoadBaseAndSum;
        private System.Windows.Forms.OpenFileDialog LoadBaseDialog;
        private System.Windows.Forms.Button SaveFiltBtn;
        private System.Windows.Forms.Button DeleteFilterBtn;
        private System.Windows.Forms.Button ClearPointsTableBtn;
    }
}