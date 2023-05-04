
namespace Proiect_Teste_Cultura_Generala
{
    partial class Map
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
            this.svgButton1 = new Proiect_Teste_Cultura_Generala.SvgButton();
            this.SuspendLayout();
            // 
            // svgButton1
            // 
            this.svgButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.svgButton1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.svgButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.svgButton1.BorderSize = 0;
            this.svgButton1.FlatAppearance.BorderSize = 0;
            this.svgButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.svgButton1.ForeColor = System.Drawing.Color.White;
            this.svgButton1.Location = new System.Drawing.Point(130, 59);
            this.svgButton1.Name = "svgButton1";
            this.svgButton1.Size = new System.Drawing.Size(176, 152);
            this.svgButton1.TabIndex = 0;
            this.svgButton1.Text = "svgButton1";
            this.svgButton1.TextColor = System.Drawing.Color.White;
            this.svgButton1.UseVisualStyleBackColor = false;
            this.svgButton1.Click += new System.EventHandler(this.svgButton1_Click);
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.svgButton1);
            this.Name = "Map";
            this.Text = "Map";
            this.Load += new System.EventHandler(this.Map_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SvgButton svgButton1;
    }
}