
namespace Proiect_Teste_Cultura_Generala
{
    partial class GridQuestions
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
            this.components = new System.ComponentModel.Container();
            this.QuestTextBox = new System.Windows.Forms.TextBox();
            this.answer1 = new System.Windows.Forms.Button();
            this.answer2 = new System.Windows.Forms.Button();
            this.answer3 = new System.Windows.Forms.Button();
            this.answer4 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // QuestTextBox
            // 
            this.QuestTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.QuestTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestTextBox.Location = new System.Drawing.Point(107, 48);
            this.QuestTextBox.Multiline = true;
            this.QuestTextBox.Name = "QuestTextBox";
            this.QuestTextBox.ReadOnly = true;
            this.QuestTextBox.Size = new System.Drawing.Size(550, 150);
            this.QuestTextBox.TabIndex = 0;
            this.QuestTextBox.Text = "Question";
            this.QuestTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.QuestTextBox.TextChanged += new System.EventHandler(this.QuestTextBox_TextChanged);
            // 
            // answer1
            // 
            this.answer1.Location = new System.Drawing.Point(107, 231);
            this.answer1.Name = "answer1";
            this.answer1.Size = new System.Drawing.Size(250, 60);
            this.answer1.TabIndex = 1;
            this.answer1.Text = "Answer1";
            this.answer1.UseVisualStyleBackColor = true;
            this.answer1.Click += new System.EventHandler(this.answear1_Click);
            // 
            // answer2
            // 
            this.answer2.Location = new System.Drawing.Point(407, 231);
            this.answer2.Name = "answer2";
            this.answer2.Size = new System.Drawing.Size(250, 60);
            this.answer2.TabIndex = 2;
            this.answer2.Text = "Answer2";
            this.answer2.UseVisualStyleBackColor = true;
            this.answer2.Click += new System.EventHandler(this.answear2_Click);
            // 
            // answer3
            // 
            this.answer3.Location = new System.Drawing.Point(107, 320);
            this.answer3.Name = "answer3";
            this.answer3.Size = new System.Drawing.Size(250, 60);
            this.answer3.TabIndex = 3;
            this.answer3.Text = "Answer3";
            this.answer3.UseVisualStyleBackColor = true;
            this.answer3.Click += new System.EventHandler(this.answer3_Click);
            // 
            // answer4
            // 
            this.answer4.Location = new System.Drawing.Point(407, 320);
            this.answer4.Name = "answer4";
            this.answer4.Size = new System.Drawing.Size(250, 60);
            this.answer4.TabIndex = 4;
            this.answer4.Text = "Answer4";
            this.answer4.UseVisualStyleBackColor = true;
            this.answer4.Click += new System.EventHandler(this.answer4_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // GridQuestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.answer4);
            this.Controls.Add(this.answer3);
            this.Controls.Add(this.answer2);
            this.Controls.Add(this.answer1);
            this.Controls.Add(this.QuestTextBox);
            this.Name = "GridQuestions";
            this.Text = "GridQuestionWindow";
            this.Load += new System.EventHandler(this.GridQuestionWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox QuestTextBox;
        private System.Windows.Forms.Button answer1;
        private System.Windows.Forms.Button answer2;
        private System.Windows.Forms.Button answer3;
        private System.Windows.Forms.Button answer4;
        private System.Windows.Forms.Timer timer1;
    }
}

