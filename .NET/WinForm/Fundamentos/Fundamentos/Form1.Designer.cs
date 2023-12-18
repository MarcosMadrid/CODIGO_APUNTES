namespace Fundamentos
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
            BotonNombre = new Button();
            textBox1 = new TextBox();
            LabelNombre = new Label();
            SuspendLayout();
            // 
            // BotonNombre
            // 
            BotonNombre.Location = new Point(43, 117);
            BotonNombre.Name = "BotonNombre";
            BotonNombre.Size = new Size(209, 33);
            BotonNombre.TabIndex = 0;
            BotonNombre.Text = "Click";
            BotonNombre.UseVisualStyleBackColor = true;
            BotonNombre.Click += BtnNombre_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(43, 79);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(209, 32);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // LabelNombre
            // 
            LabelNombre.AutoSize = true;
            LabelNombre.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            LabelNombre.Location = new Point(43, 45);
            LabelNombre.Name = "LabelNombre";
            LabelNombre.Size = new Size(98, 31);
            LabelNombre.TabIndex = 2;
            LabelNombre.Text = "Nombre";
            LabelNombre.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LabelNombre);
            Controls.Add(textBox1);
            Controls.Add(BotonNombre);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BotonNombre;
        private TextBox textBox1;
        private Label LabelNombre;
    }
}
