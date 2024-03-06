namespace Prototype2
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnOpenCSV = new Button();
            DisplayBox = new TextBox();
            BtnGenerate = new Button();
            SuspendLayout();
            // 
            // BtnOpenCSV
            // 
            BtnOpenCSV.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            BtnOpenCSV.Location = new Point(41, 36);
            BtnOpenCSV.Name = "BtnOpenCSV";
            BtnOpenCSV.Size = new Size(135, 65);
            BtnOpenCSV.TabIndex = 0;
            BtnOpenCSV.Text = "Open CSV";
            BtnOpenCSV.UseVisualStyleBackColor = true;
            BtnOpenCSV.Click += BtnOpenCSV_Click;
            // 
            // DisplayBox
            // 
            DisplayBox.Location = new Point(316, 36);
            DisplayBox.Multiline = true;
            DisplayBox.Name = "DisplayBox";
            DisplayBox.ScrollBars = ScrollBars.Both;
            DisplayBox.Size = new Size(405, 333);
            DisplayBox.TabIndex = 1;
            // 
            // BtnGenerate
            // 
            BtnGenerate.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            BtnGenerate.Location = new Point(41, 107);
            BtnGenerate.Name = "BtnGenerate";
            BtnGenerate.Size = new Size(135, 65);
            BtnGenerate.TabIndex = 2;
            BtnGenerate.Text = "Generate";
            BtnGenerate.UseVisualStyleBackColor = true;
            BtnGenerate.Click += BtnGenerate_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnGenerate);
            Controls.Add(DisplayBox);
            Controls.Add(BtnOpenCSV);
            Name = "Main";
            Text = "Main Menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnOpenCSV;
        private TextBox DisplayBox;
        private Button BtnGenerate;
    }
}
