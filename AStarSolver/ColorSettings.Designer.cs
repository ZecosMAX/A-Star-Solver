namespace AStarSolver
{
    partial class ColorSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pathColorPanel = new System.Windows.Forms.Panel();
            this.stepColorPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.startColorPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.endColorPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.wallColorPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Цвет найденного пути:";
            // 
            // pathColorPanel
            // 
            this.pathColorPanel.BackColor = System.Drawing.Color.Red;
            this.pathColorPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pathColorPanel.Location = new System.Drawing.Point(218, 12);
            this.pathColorPanel.Name = "pathColorPanel";
            this.pathColorPanel.Size = new System.Drawing.Size(54, 30);
            this.pathColorPanel.TabIndex = 1;
            this.pathColorPanel.Tag = "0";
            // 
            // stepColorPanel
            // 
            this.stepColorPanel.BackColor = System.Drawing.Color.Red;
            this.stepColorPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stepColorPanel.Location = new System.Drawing.Point(218, 48);
            this.stepColorPanel.Name = "stepColorPanel";
            this.stepColorPanel.Size = new System.Drawing.Size(54, 30);
            this.stepColorPanel.TabIndex = 3;
            this.stepColorPanel.Tag = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Цвет Шага:";
            // 
            // startColorPanel
            // 
            this.startColorPanel.BackColor = System.Drawing.Color.Red;
            this.startColorPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startColorPanel.Location = new System.Drawing.Point(218, 84);
            this.startColorPanel.Name = "startColorPanel";
            this.startColorPanel.Size = new System.Drawing.Size(54, 30);
            this.startColorPanel.TabIndex = 5;
            this.startColorPanel.Tag = "2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Цвет начальной точки:";
            // 
            // endColorPanel
            // 
            this.endColorPanel.BackColor = System.Drawing.Color.Red;
            this.endColorPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.endColorPanel.Location = new System.Drawing.Point(218, 120);
            this.endColorPanel.Name = "endColorPanel";
            this.endColorPanel.Size = new System.Drawing.Size(54, 30);
            this.endColorPanel.TabIndex = 7;
            this.endColorPanel.Tag = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Цвет конечной точки:";
            // 
            // wallColorPanel
            // 
            this.wallColorPanel.BackColor = System.Drawing.Color.Red;
            this.wallColorPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.wallColorPanel.Location = new System.Drawing.Point(218, 156);
            this.wallColorPanel.Name = "wallColorPanel";
            this.wallColorPanel.Size = new System.Drawing.Size(54, 30);
            this.wallColorPanel.TabIndex = 9;
            this.wallColorPanel.Tag = "4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Цвет препятствия:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(217, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 31);
            this.button1.TabIndex = 10;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ColorSettings
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 236);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.wallColorPanel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.endColorPanel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.startColorPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stepColorPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pathColorPanel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ColorSettings";
            this.Text = "Настройки цвета";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel pathColorPanel;
        private System.Windows.Forms.Panel stepColorPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel startColorPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel endColorPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel wallColorPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}