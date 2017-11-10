namespace PreobrCalc
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ElementLineBox = new System.Windows.Forms.FlowLayoutPanel();
            this.ElementsSourceBox = new System.Windows.Forms.FlowLayoutPanel();
            this.FinPanelSource = new System.Windows.Forms.PictureBox();
            this.AttPanelSource = new System.Windows.Forms.PictureBox();
            this.MixerPanelSource = new System.Windows.Forms.PictureBox();
            this.FiltPanelSource = new System.Windows.Forms.PictureBox();
            this.CalcBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BaseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadFilterBaseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InstrumentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFilterEditorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingLineBox = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ElementsSourceBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FinPanelSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttPanelSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MixerPanelSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FiltPanelSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ElementLineBox
            // 
            this.ElementLineBox.AllowDrop = true;
            this.ElementLineBox.AutoSize = true;
            this.ElementLineBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ElementLineBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ElementLineBox.Location = new System.Drawing.Point(12, 158);
            this.ElementLineBox.MinimumSize = new System.Drawing.Size(70, 70);
            this.ElementLineBox.Name = "ElementLineBox";
            this.ElementLineBox.Size = new System.Drawing.Size(70, 70);
            this.ElementLineBox.TabIndex = 2;
            this.ElementLineBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.ElementLineBox_DragDrop);
            this.ElementLineBox.DragOver += new System.Windows.Forms.DragEventHandler(this.ElementLineBox_DragOver);
            // 
            // ElementsSourceBox
            // 
            this.ElementsSourceBox.AutoSize = true;
            this.ElementsSourceBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ElementsSourceBox.Controls.Add(this.FinPanelSource);
            this.ElementsSourceBox.Controls.Add(this.AttPanelSource);
            this.ElementsSourceBox.Controls.Add(this.MixerPanelSource);
            this.ElementsSourceBox.Controls.Add(this.FiltPanelSource);
            this.ElementsSourceBox.Location = new System.Drawing.Point(12, 40);
            this.ElementsSourceBox.Name = "ElementsSourceBox";
            this.ElementsSourceBox.Size = new System.Drawing.Size(288, 72);
            this.ElementsSourceBox.TabIndex = 3;
            this.ElementsSourceBox.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.ElementsSourceBox_QueryContinueDrag);
            // 
            // FinPanelSource
            // 
            this.FinPanelSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FinPanelSource.Image = ((System.Drawing.Image)(resources.GetObject("FinPanelSource.Image")));
            this.FinPanelSource.Location = new System.Drawing.Point(3, 3);
            this.FinPanelSource.Name = "FinPanelSource";
            this.FinPanelSource.Size = new System.Drawing.Size(66, 66);
            this.FinPanelSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.FinPanelSource.TabIndex = 0;
            this.FinPanelSource.TabStop = false;
            this.FinPanelSource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownAction);
            this.FinPanelSource.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveAction);
            this.FinPanelSource.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpAction);
            // 
            // AttPanelSource
            // 
            this.AttPanelSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AttPanelSource.Image = ((System.Drawing.Image)(resources.GetObject("AttPanelSource.Image")));
            this.AttPanelSource.Location = new System.Drawing.Point(75, 3);
            this.AttPanelSource.Name = "AttPanelSource";
            this.AttPanelSource.Size = new System.Drawing.Size(66, 66);
            this.AttPanelSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.AttPanelSource.TabIndex = 1;
            this.AttPanelSource.TabStop = false;
            this.AttPanelSource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownAction);
            this.AttPanelSource.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveAction);
            this.AttPanelSource.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpAction);
            // 
            // MixerPanelSource
            // 
            this.MixerPanelSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MixerPanelSource.Image = ((System.Drawing.Image)(resources.GetObject("MixerPanelSource.Image")));
            this.MixerPanelSource.Location = new System.Drawing.Point(147, 3);
            this.MixerPanelSource.Name = "MixerPanelSource";
            this.MixerPanelSource.Size = new System.Drawing.Size(66, 66);
            this.MixerPanelSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.MixerPanelSource.TabIndex = 1;
            this.MixerPanelSource.TabStop = false;
            this.MixerPanelSource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownAction);
            this.MixerPanelSource.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveAction);
            this.MixerPanelSource.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpAction);
            // 
            // FiltPanelSource
            // 
            this.FiltPanelSource.BackColor = System.Drawing.SystemColors.Control;
            this.FiltPanelSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FiltPanelSource.Image = ((System.Drawing.Image)(resources.GetObject("FiltPanelSource.Image")));
            this.FiltPanelSource.Location = new System.Drawing.Point(219, 3);
            this.FiltPanelSource.Name = "FiltPanelSource";
            this.FiltPanelSource.Size = new System.Drawing.Size(66, 66);
            this.FiltPanelSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.FiltPanelSource.TabIndex = 1;
            this.FiltPanelSource.TabStop = false;
            this.FiltPanelSource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownAction);
            this.FiltPanelSource.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveAction);
            this.FiltPanelSource.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpAction);
            // 
            // CalcBtn
            // 
            this.CalcBtn.Location = new System.Drawing.Point(485, 69);
            this.CalcBtn.Name = "CalcBtn";
            this.CalcBtn.Size = new System.Drawing.Size(75, 23);
            this.CalcBtn.TabIndex = 5;
            this.CalcBtn.Text = "Расчет";
            this.CalcBtn.UseVisualStyleBackColor = true;
            this.CalcBtn.Click += new System.EventHandler(this.CalcBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.BaseMenuItem,
            this.InstrumentMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(899, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // BaseMenuItem
            // 
            this.BaseMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadFilterBaseMenuItem});
            this.BaseMenuItem.Name = "BaseMenuItem";
            this.BaseMenuItem.Size = new System.Drawing.Size(46, 20);
            this.BaseMenuItem.Text = "Базы";
            // 
            // LoadFilterBaseMenuItem
            // 
            this.LoadFilterBaseMenuItem.Name = "LoadFilterBaseMenuItem";
            this.LoadFilterBaseMenuItem.Size = new System.Drawing.Size(221, 22);
            this.LoadFilterBaseMenuItem.Text = "Загрузить базу фильтров...";
            // 
            // InstrumentMenuItem
            // 
            this.InstrumentMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFilterEditorMenuItem});
            this.InstrumentMenuItem.Name = "InstrumentMenuItem";
            this.InstrumentMenuItem.Size = new System.Drawing.Size(95, 20);
            this.InstrumentMenuItem.Text = "Инструменты";
            // 
            // OpenFilterEditorMenuItem
            // 
            this.OpenFilterEditorMenuItem.Name = "OpenFilterEditorMenuItem";
            this.OpenFilterEditorMenuItem.Size = new System.Drawing.Size(181, 22);
            this.OpenFilterEditorMenuItem.Text = "Редактор фильтров";
            this.OpenFilterEditorMenuItem.Click += new System.EventHandler(this.OpenFilterEditorBtn_Click);
            // 
            // SettingLineBox
            // 
            this.SettingLineBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SettingLineBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SettingLineBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SettingLineBox.Location = new System.Drawing.Point(0, 234);
            this.SettingLineBox.Name = "SettingLineBox";
            this.SettingLineBox.Size = new System.Drawing.Size(899, 181);
            this.SettingLineBox.TabIndex = 7;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(591, 45);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(485, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 415);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.SettingLineBox);
            this.Controls.Add(this.CalcBtn);
            this.Controls.Add(this.ElementsSourceBox);
            this.Controls.Add(this.ElementLineBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ElementsSourceBox.ResumeLayout(false);
            this.ElementsSourceBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FinPanelSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttPanelSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MixerPanelSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FiltPanelSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel ElementLineBox;
        private System.Windows.Forms.FlowLayoutPanel ElementsSourceBox;
        private System.Windows.Forms.PictureBox FinPanelSource;
        private System.Windows.Forms.PictureBox FiltPanelSource;
        private System.Windows.Forms.PictureBox AttPanelSource;
        private System.Windows.Forms.Button CalcBtn;
        private System.Windows.Forms.PictureBox MixerPanelSource;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BaseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadFilterBaseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InstrumentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFilterEditorMenuItem;
        private System.Windows.Forms.FlowLayoutPanel SettingLineBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

