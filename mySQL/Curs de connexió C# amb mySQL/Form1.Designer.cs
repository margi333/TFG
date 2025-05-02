namespace Curs_de_connexió_C__amb_mySQL
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
            txtServidor = new TextBox();
            label2 = new Label();
            txtPuerto = new TextBox();
            txtUsuario = new TextBox();
            label4 = new Label();
            txtPassword = new TextBox();
            label5 = new Label();
            txtBd = new TextBox();
            label6 = new Label();
            btnConectar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 26);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 0;
            label1.Text = "Servidor:";
            label1.Click += label1_Click;
            // 
            // txtServidor
            // 
            txtServidor.Location = new Point(126, 23);
            txtServidor.Name = "txtServidor";
            txtServidor.Size = new Size(125, 27);
            txtServidor.TabIndex = 1;
            txtServidor.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 68);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 2;
            label2.Text = "Puerto:";
            // 
            // txtPuerto
            // 
            txtPuerto.Location = new Point(126, 68);
            txtPuerto.Name = "txtPuerto";
            txtPuerto.Size = new Size(125, 27);
            txtPuerto.TabIndex = 3;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(126, 114);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(125, 27);
            txtUsuario.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(37, 114);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 6;
            label4.Text = "Usuario:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(126, 162);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(125, 27);
            txtPassword.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(37, 162);
            label5.Name = "label5";
            label5.Size = new Size(73, 20);
            label5.TabIndex = 8;
            label5.Text = "Password:";
            // 
            // txtBd
            // 
            txtBd.Location = new Point(126, 210);
            txtBd.Name = "txtBd";
            txtBd.Size = new Size(125, 27);
            txtBd.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(37, 210);
            label6.Name = "label6";
            label6.Size = new Size(30, 20);
            label6.TabIndex = 10;
            label6.Text = "Bd:";
            // 
            // btnConectar
            // 
            btnConectar.Location = new Point(189, 253);
            btnConectar.Name = "btnConectar";
            btnConectar.Size = new Size(94, 29);
            btnConectar.TabIndex = 12;
            btnConectar.Text = "Conectar";
            btnConectar.UseVisualStyleBackColor = true;
            btnConectar.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 294);
            Controls.Add(btnConectar);
            Controls.Add(txtBd);
            Controls.Add(label6);
            Controls.Add(txtPassword);
            Controls.Add(label5);
            Controls.Add(txtUsuario);
            Controls.Add(label4);
            Controls.Add(txtPuerto);
            Controls.Add(label2);
            Controls.Add(txtServidor);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Cliente MySQL";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtServidor;
        private Label label2;
        private TextBox txtPuerto;
        private TextBox txtUsuario;
        private Label label4;
        private TextBox txtPassword;
        private Label label5;
        private TextBox txtBd;
        private Label label6;
        private Button btnConectar;
    }
}
