namespace Fundamentos
{
    partial class FormDateTime
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
            groupBox1 = new GroupBox();
            comboBox1 = new ComboBox();
            button2 = new Button();
            textBox2 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            checkBox1 = new CheckBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Location = new Point(75, 160);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(333, 100);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Dia", "Mes", "Año" });
            comboBox1.Location = new Point(6, 22);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 7;
            // 
            // button2
            // 
            button2.Location = new Point(155, 57);
            button2.Name = "button2";
            button2.Size = new Size(100, 23);
            button2.TabIndex = 2;
            button2.Text = "Incrementar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(155, 22);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Ravie", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker1.Font = new Font("Snap ITC", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker1.Location = new Point(75, 73);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(295, 23);
            dateTimePicker1.TabIndex = 5;
            dateTimePicker1.Value = new DateTime(2023, 12, 19, 10, 30, 55, 0);
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CalendarFont = new Font("Ravie", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker2.Font = new Font("Snap ITC", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker2.Location = new Point(75, 286);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(295, 23);
            dateTimePicker2.TabIndex = 6;
            dateTimePicker2.Value = new DateTime(2023, 12, 19, 10, 30, 55, 0);
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(75, 113);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(83, 19);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // FormDateTime
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(checkBox1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(groupBox1);
            Name = "FormDateTime";
            Text = "FormDateTime";
            Load += FormDateTime_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
        private Button button2;
        private TextBox textBox2;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private ComboBox comboBox1;
        private CheckBox checkBox1;
    }
}