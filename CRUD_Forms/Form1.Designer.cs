namespace CRUD_Forms
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Dgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.IdTb = new System.Windows.Forms.TextBox();
            this.NameTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CpfTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UpTb = new System.Windows.Forms.Button();
            this.AddBt = new System.Windows.Forms.Button();
            this.RemoveTb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Dgv
            // 
            this.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Location = new System.Drawing.Point(12, 156);
            this.Dgv.Name = "Dgv";
            this.Dgv.Size = new System.Drawing.Size(561, 150);
            this.Dgv.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // IdTb
            // 
            this.IdTb.Location = new System.Drawing.Point(16, 30);
            this.IdTb.Name = "IdTb";
            this.IdTb.Size = new System.Drawing.Size(196, 20);
            this.IdTb.TabIndex = 2;
            // 
            // NameTb
            // 
            this.NameTb.Location = new System.Drawing.Point(16, 74);
            this.NameTb.Name = "NameTb";
            this.NameTb.Size = new System.Drawing.Size(196, 20);
            this.NameTb.TabIndex = 4;
            this.NameTb.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // CpfTb
            // 
            this.CpfTb.Location = new System.Drawing.Point(16, 121);
            this.CpfTb.Name = "CpfTb";
            this.CpfTb.Size = new System.Drawing.Size(196, 20);
            this.CpfTb.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "CPF";
            // 
            // UpTb
            // 
            this.UpTb.Location = new System.Drawing.Point(412, 27);
            this.UpTb.Name = "UpTb";
            this.UpTb.Size = new System.Drawing.Size(124, 23);
            this.UpTb.TabIndex = 7;
            this.UpTb.Text = "Edit";
            this.UpTb.UseVisualStyleBackColor = true;
            // 
            // AddBt
            // 
            this.AddBt.Location = new System.Drawing.Point(313, 27);
            this.AddBt.Name = "AddBt";
            this.AddBt.Size = new System.Drawing.Size(79, 67);
            this.AddBt.TabIndex = 8;
            this.AddBt.Text = "Add";
            this.AddBt.UseVisualStyleBackColor = true;
            this.AddBt.Click += new System.EventHandler(this.AddBt_Click);
            // 
            // RemoveTb
            // 
            this.RemoveTb.Location = new System.Drawing.Point(412, 71);
            this.RemoveTb.Name = "RemoveTb";
            this.RemoveTb.Size = new System.Drawing.Size(124, 23);
            this.RemoveTb.TabIndex = 9;
            this.RemoveTb.Text = "Remove";
            this.RemoveTb.UseVisualStyleBackColor = true;
            this.RemoveTb.Click += new System.EventHandler(this.RemoveTb_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 318);
            this.Controls.Add(this.RemoveTb);
            this.Controls.Add(this.AddBt);
            this.Controls.Add(this.UpTb);
            this.Controls.Add(this.CpfTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NameTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IdTb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Dgv);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Dgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IdTb;
        private System.Windows.Forms.TextBox NameTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CpfTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button UpTb;
        private System.Windows.Forms.Button AddBt;
        private System.Windows.Forms.Button RemoveTb;
    }
}

