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
            this.button1 = new System.Windows.Forms.Button();
            this.ElementLineBox = new System.Windows.Forms.FlowLayoutPanel();
            this.ElementsSourceBox = new System.Windows.Forms.FlowLayoutPanel();
            this.FinPanelSource = new System.Windows.Forms.PictureBox();
            this.AttPanelSource = new System.Windows.Forms.PictureBox();
            this.FiltPanelSource = new System.Windows.Forms.PictureBox();
            this.CalcBtn = new System.Windows.Forms.Button();
            this.ElementsSourceBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FinPanelSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttPanelSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FiltPanelSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(511, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Редактор фильтров";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ElementLineBox
            // 
            this.ElementLineBox.AllowDrop = true;
            this.ElementLineBox.AutoSize = true;
            this.ElementLineBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ElementLineBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ElementLineBox.Location = new System.Drawing.Point(12, 128);
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
            this.ElementsSourceBox.Controls.Add(this.FiltPanelSource);
            this.ElementsSourceBox.Location = new System.Drawing.Point(12, 12);
            this.ElementsSourceBox.Name = "ElementsSourceBox";
            this.ElementsSourceBox.Size = new System.Drawing.Size(216, 72);
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
            // FiltPanelSource
            // 
            this.FiltPanelSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FiltPanelSource.Image = ((System.Drawing.Image)(resources.GetObject("FiltPanelSource.Image")));
            this.FiltPanelSource.Location = new System.Drawing.Point(147, 3);
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
            this.CalcBtn.Location = new System.Drawing.Point(511, 128);
            this.CalcBtn.Name = "CalcBtn";
            this.CalcBtn.Size = new System.Drawing.Size(75, 23);
            this.CalcBtn.TabIndex = 5;
            this.CalcBtn.Text = "Расчет";
            this.CalcBtn.UseVisualStyleBackColor = true;
            this.CalcBtn.Click += new System.EventHandler(this.CalcBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 560);
            this.Controls.Add(this.CalcBtn);
            this.Controls.Add(this.ElementsSourceBox);
            this.Controls.Add(this.ElementLineBox);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ElementsSourceBox.ResumeLayout(false);
            this.ElementsSourceBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FinPanelSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttPanelSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FiltPanelSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel ElementLineBox;
        private System.Windows.Forms.FlowLayoutPanel ElementsSourceBox;
        private System.Windows.Forms.PictureBox FinPanelSource;
        private System.Windows.Forms.PictureBox FiltPanelSource;
        private System.Windows.Forms.PictureBox AttPanelSource;
        private System.Windows.Forms.Button CalcBtn;
    }
}

