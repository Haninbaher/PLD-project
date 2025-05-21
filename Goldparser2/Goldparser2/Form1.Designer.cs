namespace Goldparser2
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
            textBox1 = new TextBox();
            Syntac = new ListBox();
            Lexical = new ListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 22);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(331, 359);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Syntac
            // 
            Syntac.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            Syntac.FormattingEnabled = true;
            Syntac.ItemHeight = 17;
            Syntac.Location = new Point(371, 22);
            Syntac.Name = "Syntac";
            Syntac.Size = new Size(417, 89);
            Syntac.TabIndex = 1;
            // 
            // Lexical
            // 
            Lexical.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            Lexical.FormattingEnabled = true;
            Lexical.ItemHeight = 17;
            Lexical.Location = new Point(371, 143);
            Lexical.Name = "Lexical";
            Lexical.Size = new Size(417, 276);
            Lexical.TabIndex = 2;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            button1.Location = new Point(113, 402);
            button1.Name = "button1";
            button1.Size = new Size(92, 30);
            button1.TabIndex = 3;
            button1.Text = "Parseing";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(Lexical);
            Controls.Add(Syntac);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private ListBox Syntac;
        private ListBox Lexical;
        private Button button1;
    }
}
