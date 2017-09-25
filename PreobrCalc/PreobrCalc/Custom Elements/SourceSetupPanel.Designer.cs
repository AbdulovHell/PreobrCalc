namespace PreobrCalc.Custom_Elements
{
    partial class SourceSetupPanel
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
            this.MainGroupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.StepEdit = new System.Windows.Forms.TextBox();
            this.BandEdit = new System.Windows.Forms.TextBox();
            this.AttEdit = new System.Windows.Forms.TextBox();
            this.FreqEdit = new System.Windows.Forms.TextBox();
            this.MainGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainGroupBox
            // 
            this.MainGroupBox.Controls.Add(this.label4);
            this.MainGroupBox.Controls.Add(this.label3);
            this.MainGroupBox.Controls.Add(this.label2);
            this.MainGroupBox.Controls.Add(this.label1);
            this.MainGroupBox.Controls.Add(this.StepEdit);
            this.MainGroupBox.Controls.Add(this.BandEdit);
            this.MainGroupBox.Controls.Add(this.AttEdit);
            this.MainGroupBox.Controls.Add(this.FreqEdit);
            this.MainGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainGroupBox.Location = new System.Drawing.Point(0, 0);
            this.MainGroupBox.Name = "MainGroupBox";
            this.MainGroupBox.Size = new System.Drawing.Size(224, 107);
            this.MainGroupBox.TabIndex = 0;
            this.MainGroupBox.TabStop = false;
            this.MainGroupBox.Text = "Source[0]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Шаг, МГц";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Полоса, МГц";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Уровень сигнала, dB";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Частота, МГц";
            // 
            // StepEdit
            // 
            this.StepEdit.Location = new System.Drawing.Point(112, 80);
            this.StepEdit.Name = "StepEdit";
            this.StepEdit.Size = new System.Drawing.Size(100, 20);
            this.StepEdit.TabIndex = 11;
            this.StepEdit.TextChanged += new System.EventHandler(this.StepEdit_TextChanged);
            // 
            // BandEdit
            // 
            this.BandEdit.Location = new System.Drawing.Point(6, 80);
            this.BandEdit.Name = "BandEdit";
            this.BandEdit.Size = new System.Drawing.Size(100, 20);
            this.BandEdit.TabIndex = 10;
            this.BandEdit.TextChanged += new System.EventHandler(this.BandEdit_TextChanged);
            // 
            // AttEdit
            // 
            this.AttEdit.Location = new System.Drawing.Point(112, 35);
            this.AttEdit.Name = "AttEdit";
            this.AttEdit.Size = new System.Drawing.Size(100, 20);
            this.AttEdit.TabIndex = 9;
            this.AttEdit.TextChanged += new System.EventHandler(this.AttEdit_TextChanged);
            // 
            // FreqEdit
            // 
            this.FreqEdit.Location = new System.Drawing.Point(6, 35);
            this.FreqEdit.Name = "FreqEdit";
            this.FreqEdit.Size = new System.Drawing.Size(100, 20);
            this.FreqEdit.TabIndex = 8;
            this.FreqEdit.TextChanged += new System.EventHandler(this.FreqEdit_TextChanged);
            // 
            // SourceSetupPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.MainGroupBox);
            this.Name = "SourceSetupPanel";
            this.Size = new System.Drawing.Size(224, 107);
            this.MainGroupBox.ResumeLayout(false);
            this.MainGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MainGroupBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox StepEdit;
        private System.Windows.Forms.TextBox BandEdit;
        private System.Windows.Forms.TextBox AttEdit;
        private System.Windows.Forms.TextBox FreqEdit;
    }
}
