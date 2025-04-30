namespace WinFormsApp1
{
    partial class Form1
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
            label1 = new Label();
            txtNum1 = new TextBox();
            txtNum2 = new TextBox();
            ComboBox = new ComboBox();
            btnOperacio = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 35);
            label1.Name = "label1";
            label1.Size = new Size(279, 23);
            label1.TabIndex = 0;
            label1.Text = "Introdueix la operació que vols fer: ";
            // 
            // txtNum1
            // 
            txtNum1.Location = new Point(23, 138);
            txtNum1.Name = "txtNum1";
            txtNum1.Size = new Size(125, 27);
            txtNum1.TabIndex = 1;
            // 
            // txtNum2
            // 
            txtNum2.Location = new Point(245, 138);
            txtNum2.Name = "txtNum2";
            txtNum2.Size = new Size(125, 27);
            txtNum2.TabIndex = 2;
            // 
            // ComboBox
            // 
            ComboBox.FormattingEnabled = true;
            ComboBox.Items.AddRange(new object[] { "+", "-" });
            ComboBox.Location = new Point(171, 139);
            ComboBox.Name = "ComboBox";
            ComboBox.Size = new Size(58, 28);
            ComboBox.TabIndex = 3;
            // 
            // btnOperacio
            // 
            btnOperacio.Location = new Point(138, 271);
            btnOperacio.Name = "btnOperacio";
            btnOperacio.Size = new Size(135, 27);
            btnOperacio.TabIndex = 4;
            btnOperacio.Text = "Fer operació";
            btnOperacio.UseVisualStyleBackColor = true;
            btnOperacio.Click += btnOperacio_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 328);
            Controls.Add(btnOperacio);
            Controls.Add(ComboBox);
            Controls.Add(txtNum2);
            Controls.Add(txtNum1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Suma/Resta";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNum1;
        private TextBox txtNum2;
        private ComboBox ComboBox;
        private Button btnOperacio;
    }
}
