namespace AdoNet
{
    partial class Form01PrimerAdo
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
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_disconnet = new System.Windows.Forms.Button();
            this.btn_read = new System.Windows.Forms.Button();
            this.lst_apellidos = new System.Windows.Forms.ListBox();
            this.lst_columnas = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lst_datos = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(67, 36);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(87, 23);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.Text = "Conectar";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_disconnet
            // 
            this.btn_disconnet.Location = new System.Drawing.Point(67, 65);
            this.btn_disconnet.Name = "btn_disconnet";
            this.btn_disconnet.Size = new System.Drawing.Size(87, 23);
            this.btn_disconnet.TabIndex = 1;
            this.btn_disconnet.Text = "Desconectar";
            this.btn_disconnet.UseVisualStyleBackColor = true;
            this.btn_disconnet.Click += new System.EventHandler(this.btn_disconnet_Click);
            // 
            // btn_read
            // 
            this.btn_read.Location = new System.Drawing.Point(67, 94);
            this.btn_read.Name = "btn_read";
            this.btn_read.Size = new System.Drawing.Size(87, 23);
            this.btn_read.TabIndex = 2;
            this.btn_read.Text = "Leer ";
            this.btn_read.UseVisualStyleBackColor = true;
            this.btn_read.Click += new System.EventHandler(this.btn_read_Click);
            // 
            // lst_apellidos
            // 
            this.lst_apellidos.FormattingEnabled = true;
            this.lst_apellidos.Location = new System.Drawing.Point(181, 36);
            this.lst_apellidos.Name = "lst_apellidos";
            this.lst_apellidos.Size = new System.Drawing.Size(173, 303);
            this.lst_apellidos.TabIndex = 3;
            // 
            // lst_columnas
            // 
            this.lst_columnas.FormattingEnabled = true;
            this.lst_columnas.Location = new System.Drawing.Point(440, 36);
            this.lst_columnas.Name = "lst_columnas";
            this.lst_columnas.Size = new System.Drawing.Size(167, 303);
            this.lst_columnas.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(437, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Columnas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Apellidos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(654, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tipo Dato";
            // 
            // lst_datos
            // 
            this.lst_datos.FormattingEnabled = true;
            this.lst_datos.Location = new System.Drawing.Point(657, 36);
            this.lst_datos.Name = "lst_datos";
            this.lst_datos.Size = new System.Drawing.Size(120, 303);
            this.lst_datos.TabIndex = 9;
            // 
            // Form01PrimerAdo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lst_datos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lst_columnas);
            this.Controls.Add(this.lst_apellidos);
            this.Controls.Add(this.btn_read);
            this.Controls.Add(this.btn_disconnet);
            this.Controls.Add(this.btn_connect);
            this.Name = "Form01PrimerAdo";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_disconnet;
        private System.Windows.Forms.Button btn_read;
        private System.Windows.Forms.ListBox lst_apellidos;
        private System.Windows.Forms.ListBox lst_columnas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lst_datos;
    }
}

