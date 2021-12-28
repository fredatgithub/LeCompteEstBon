namespace LeMotLePlusLong
{
    partial class FormMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonGenerateLetters = new System.Windows.Forms.Button();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.comboBoxNumberOfVoyelles = new System.Windows.Forms.ComboBox();
            this.labelNombreDeVoyelles = new System.Windows.Forms.Label();
            this.buttonNumbers = new System.Windows.Forms.Button();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.textBoxNumbersAvailable = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonGenerateLetters
            // 
            this.buttonGenerateLetters.Location = new System.Drawing.Point(275, 65);
            this.buttonGenerateLetters.Name = "buttonGenerateLetters";
            this.buttonGenerateLetters.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerateLetters.TabIndex = 0;
            this.buttonGenerateLetters.Text = "Generate";
            this.buttonGenerateLetters.UseVisualStyleBackColor = true;
            this.buttonGenerateLetters.Click += new System.EventHandler(this.ButtonGenerateLetters_Click);
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(384, 65);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(100, 22);
            this.textBoxResult.TabIndex = 1;
            // 
            // comboBoxNumberOfVoyelles
            // 
            this.comboBoxNumberOfVoyelles.FormattingEnabled = true;
            this.comboBoxNumberOfVoyelles.Location = new System.Drawing.Point(193, 62);
            this.comboBoxNumberOfVoyelles.Name = "comboBoxNumberOfVoyelles";
            this.comboBoxNumberOfVoyelles.Size = new System.Drawing.Size(76, 24);
            this.comboBoxNumberOfVoyelles.TabIndex = 2;
            this.comboBoxNumberOfVoyelles.Text = "1";
            // 
            // labelNombreDeVoyelles
            // 
            this.labelNombreDeVoyelles.AutoSize = true;
            this.labelNombreDeVoyelles.Location = new System.Drawing.Point(36, 65);
            this.labelNombreDeVoyelles.Name = "labelNombreDeVoyelles";
            this.labelNombreDeVoyelles.Size = new System.Drawing.Size(135, 16);
            this.labelNombreDeVoyelles.TabIndex = 3;
            this.labelNombreDeVoyelles.Text = "Nombre de voyelles :";
            // 
            // buttonNumbers
            // 
            this.buttonNumbers.Location = new System.Drawing.Point(39, 145);
            this.buttonNumbers.Name = "buttonNumbers";
            this.buttonNumbers.Size = new System.Drawing.Size(75, 23);
            this.buttonNumbers.TabIndex = 4;
            this.buttonNumbers.Text = "Generate";
            this.buttonNumbers.UseVisualStyleBackColor = true;
            this.buttonNumbers.Click += new System.EventHandler(this.ButtonNumbers_Click);
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotal.Location = new System.Drawing.Point(178, 146);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.Size = new System.Drawing.Size(100, 26);
            this.textBoxTotal.TabIndex = 5;
            this.textBoxTotal.Text = "0";
            // 
            // textBoxNumbersAvailable
            // 
            this.textBoxNumbersAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumbersAvailable.Location = new System.Drawing.Point(384, 146);
            this.textBoxNumbersAvailable.Name = "textBoxNumbersAvailable";
            this.textBoxNumbersAvailable.Size = new System.Drawing.Size(222, 26);
            this.textBoxNumbersAvailable.TabIndex = 6;
            this.textBoxNumbersAvailable.Text = "100,25,50,";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxNumbersAvailable);
            this.Controls.Add(this.textBoxTotal);
            this.Controls.Add(this.buttonNumbers);
            this.Controls.Add(this.labelNombreDeVoyelles);
            this.Controls.Add(this.comboBoxNumberOfVoyelles);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.buttonGenerateLetters);
            this.Name = "FormMain";
            this.Text = "Le mot le plus long et le compte est bon";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerateLetters;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.ComboBox comboBoxNumberOfVoyelles;
        private System.Windows.Forms.Label labelNombreDeVoyelles;
        private System.Windows.Forms.Button buttonNumbers;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.TextBox textBoxNumbersAvailable;
    }
}

