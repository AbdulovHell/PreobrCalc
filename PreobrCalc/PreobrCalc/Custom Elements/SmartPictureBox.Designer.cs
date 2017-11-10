namespace PreobrCalc
{
    partial class SmartPictureBox
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmartPictureBox));
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.LeftBtn = new System.Windows.Forms.Button();
            this.MidBtn = new System.Windows.Forms.Button();
            this.RightBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageBox
            // 
            this.ImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageBox.Location = new System.Drawing.Point(1, 1);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(60, 60);
            this.ImageBox.TabIndex = 0;
            this.ImageBox.TabStop = false;
            // 
            // LeftBtn
            // 
            this.LeftBtn.Image = ((System.Drawing.Image)(resources.GetObject("LeftBtn.Image")));
            this.LeftBtn.Location = new System.Drawing.Point(4, 44);
            this.LeftBtn.MaximumSize = new System.Drawing.Size(16, 16);
            this.LeftBtn.MinimumSize = new System.Drawing.Size(16, 16);
            this.LeftBtn.Name = "LeftBtn";
            this.LeftBtn.Size = new System.Drawing.Size(16, 16);
            this.LeftBtn.TabIndex = 1;
            this.LeftBtn.TabStop = false;
            this.LeftBtn.UseVisualStyleBackColor = true;
            // 
            // MidBtn
            // 
            this.MidBtn.Image = ((System.Drawing.Image)(resources.GetObject("MidBtn.Image")));
            this.MidBtn.Location = new System.Drawing.Point(24, 44);
            this.MidBtn.MaximumSize = new System.Drawing.Size(16, 16);
            this.MidBtn.MinimumSize = new System.Drawing.Size(16, 16);
            this.MidBtn.Name = "MidBtn";
            this.MidBtn.Size = new System.Drawing.Size(16, 16);
            this.MidBtn.TabIndex = 1;
            this.MidBtn.TabStop = false;
            this.MidBtn.UseVisualStyleBackColor = true;
            // 
            // RightBtn
            // 
            this.RightBtn.Image = ((System.Drawing.Image)(resources.GetObject("RightBtn.Image")));
            this.RightBtn.Location = new System.Drawing.Point(44, 44);
            this.RightBtn.MaximumSize = new System.Drawing.Size(16, 16);
            this.RightBtn.MinimumSize = new System.Drawing.Size(16, 16);
            this.RightBtn.Name = "RightBtn";
            this.RightBtn.Size = new System.Drawing.Size(16, 16);
            this.RightBtn.TabIndex = 1;
            this.RightBtn.TabStop = false;
            this.RightBtn.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // SmartPictureBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.LeftBtn);
            this.Controls.Add(this.RightBtn);
            this.Controls.Add(this.MidBtn);
            this.Controls.Add(this.ImageBox);
            this.MaximumSize = new System.Drawing.Size(64, 64);
            this.MinimumSize = new System.Drawing.Size(64, 64);
            this.Name = "SmartPictureBox";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(62, 62);
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ImageBox;
        private System.Windows.Forms.Button LeftBtn;
        private System.Windows.Forms.Button MidBtn;
        private System.Windows.Forms.Button RightBtn;
        private System.Windows.Forms.Timer timer1;
    }
}
