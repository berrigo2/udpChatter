namespace chatter
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
            this.convoBox = new System.Windows.Forms.TextBox();
            this.typingBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ipBox = new System.Windows.Forms.TextBox();
            this.portBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.portBox)).BeginInit();
            this.SuspendLayout();
            // 
            // convoBox
            // 
            this.convoBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.convoBox.Location = new System.Drawing.Point(12, 35);
            this.convoBox.Multiline = true;
            this.convoBox.Name = "convoBox";
            this.convoBox.ReadOnly = true;
            this.convoBox.Size = new System.Drawing.Size(511, 260);
            this.convoBox.TabIndex = 0;
            // 
            // typingBox
            // 
            this.typingBox.Location = new System.Drawing.Point(12, 301);
            this.typingBox.Multiline = true;
            this.typingBox.Name = "typingBox";
            this.typingBox.Size = new System.Drawing.Size(511, 142);
            this.typingBox.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(448, 449);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "I.P.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Port";
            // 
            // ipBox
            // 
            this.ipBox.Location = new System.Drawing.Point(46, 3);
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size(235, 20);
            this.ipBox.TabIndex = 8;
            this.ipBox.TextChanged += new System.EventHandler(this.sendToInfoChanged);
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(319, 3);
            this.portBox.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(204, 20);
            this.portBox.TabIndex = 9;
            this.portBox.ValueChanged += new System.EventHandler(this.portBox_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 484);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.ipBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.typingBox);
            this.Controls.Add(this.convoBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.portBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox convoBox;
        private System.Windows.Forms.TextBox typingBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ipBox;
        private System.Windows.Forms.NumericUpDown portBox;
    }
}

