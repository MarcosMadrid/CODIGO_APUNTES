﻿namespace Fundamentos
{
    partial class NumerosRandomList
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
            GenerarNum = new Button();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // GenerarNum
            // 
            GenerarNum.Location = new Point(376, 47);
            GenerarNum.Name = "GenerarNum";
            GenerarNum.Size = new Size(75, 23);
            GenerarNum.TabIndex = 0;
            GenerarNum.Text = "button1";
            GenerarNum.UseVisualStyleBackColor = true;
            GenerarNum.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(91, 47);
            listBox1.Name = "listBox1";
            listBox1.SelectionMode = SelectionMode.MultiExtended;
            listBox1.Size = new Size(164, 154);
            listBox1.TabIndex = 1;
            // 
            // NumerosRandomList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBox1);
            Controls.Add(GenerarNum);
            Name = "NumerosRandomList";
            Text = "NumerosRandomList";
            ResumeLayout(false);
        }

        #endregion

        private Button GenerarNum;
        private ListBox listBox1;
    }
}