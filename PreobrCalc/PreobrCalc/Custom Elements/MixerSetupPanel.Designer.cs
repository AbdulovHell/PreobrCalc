namespace PreobrCalc.Custom_Elements
{
    partial class MixerSetupPanel
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FgetEdit = new System.Windows.Forms.TextBox();
            this.FprEdit = new System.Windows.Forms.TextBox();
            this.OrderNumEdit = new System.Windows.Forms.NumericUpDown();
            this.FinFgetPosChk = new System.Windows.Forms.CheckBox();
            this.MainGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderNumEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // MainGroupBox
            // 
            this.MainGroupBox.Controls.Add(this.label2);
            this.MainGroupBox.Controls.Add(this.label3);
            this.MainGroupBox.Controls.Add(this.label1);
            this.MainGroupBox.Controls.Add(this.FgetEdit);
            this.MainGroupBox.Controls.Add(this.FprEdit);
            this.MainGroupBox.Controls.Add(this.OrderNumEdit);
            this.MainGroupBox.Controls.Add(this.FinFgetPosChk);
            this.MainGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainGroupBox.Location = new System.Drawing.Point(0, 0);
            this.MainGroupBox.Name = "MainGroupBox";
            this.MainGroupBox.Size = new System.Drawing.Size(227, 107);
            this.MainGroupBox.TabIndex = 0;
            this.MainGroupBox.TabStop = false;
            this.MainGroupBox.Text = "Type[]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Порядок";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fget, MHz";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fpr, MHz";
            // 
            // FgetEdit
            // 
            this.FgetEdit.Location = new System.Drawing.Point(10, 77);
            this.FgetEdit.Name = "FgetEdit";
            this.FgetEdit.ReadOnly = true;
            this.FgetEdit.Size = new System.Drawing.Size(100, 20);
            this.FgetEdit.TabIndex = 2;
            // 
            // FprEdit
            // 
            this.FprEdit.Location = new System.Drawing.Point(10, 36);
            this.FprEdit.Name = "FprEdit";
            this.FprEdit.Size = new System.Drawing.Size(100, 20);
            this.FprEdit.TabIndex = 2;
            this.FprEdit.TextChanged += new System.EventHandler(this.FprEdit_TextChanged);
            // 
            // OrderNumEdit
            // 
            this.OrderNumEdit.Location = new System.Drawing.Point(176, 36);
            this.OrderNumEdit.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.OrderNumEdit.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.OrderNumEdit.Name = "OrderNumEdit";
            this.OrderNumEdit.Size = new System.Drawing.Size(38, 20);
            this.OrderNumEdit.TabIndex = 1;
            this.OrderNumEdit.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.OrderNumEdit.ValueChanged += new System.EventHandler(this.OrderNumEdit_ValueChanged);
            // 
            // FinFgetPosChk
            // 
            this.FinFgetPosChk.AutoSize = true;
            this.FinFgetPosChk.Location = new System.Drawing.Point(122, 79);
            this.FinFgetPosChk.Name = "FinFgetPosChk";
            this.FinFgetPosChk.Size = new System.Drawing.Size(67, 17);
            this.FinFgetPosChk.TabIndex = 0;
            this.FinFgetPosChk.Text = "Fin>Fget";
            this.FinFgetPosChk.UseVisualStyleBackColor = true;
            this.FinFgetPosChk.CheckedChanged += new System.EventHandler(this.FinFgetPosChk_CheckedChanged);
            // 
            // MixerSetupPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.MainGroupBox);
            this.Name = "MixerSetupPanel";
            this.Size = new System.Drawing.Size(227, 107);
            this.MainGroupBox.ResumeLayout(false);
            this.MainGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderNumEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MainGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FprEdit;
        private System.Windows.Forms.NumericUpDown OrderNumEdit;
        private System.Windows.Forms.CheckBox FinFgetPosChk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FgetEdit;
    }
}
