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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
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
            // 
            // button1
            // 
            button1.Location = new Point(640, 53);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(640, 117);
            button2.Name = "button2";
            button2.Size = new Size(106, 23);
            button2.TabIndex = 4;
            button2.Text = "FormColores";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(640, 183);
            button3.Name = "button3";
            button3.Size = new Size(106, 23);
            button3.TabIndex = 5;
            button3.Text = "FormDiaSemana";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(640, 251);
            button4.Name = "button4";
            button4.Size = new Size(148, 23);
            button4.TabIndex = 6;
            button4.Text = "FormIncrementarDate";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(640, 328);
            button5.Name = "button5";
            button5.Size = new Size(148, 23);
            button5.TabIndex = 7;
            button5.Text = "FormIncrementarDate";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(640, 399);
            button6.Name = "button6";
            button6.Size = new Size(148, 23);
            button6.TabIndex = 8;
            button6.Text = "FormValidas ISBN";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(437, 399);
            button7.Name = "button7";
            button7.Size = new Size(148, 23);
            button7.TabIndex = 9;
            button7.Text = "Form Validar DNI";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(401, 328);
            button8.Name = "button8";
            button8.Size = new Size(184, 23);
            button8.TabIndex = 10;
            button8.Text = "Form Random Numeros List";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(510, 273);
            button9.Name = "button9";
            button9.Size = new Size(75, 23);
            button9.TabIndex = 11;
            button9.Text = "button9";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
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
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
    }
}
