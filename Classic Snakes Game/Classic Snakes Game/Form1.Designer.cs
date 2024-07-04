namespace Classic_Snakes_Game
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
            this.components = new System.ComponentModel.Container();
            this.startButton = new System.Windows.Forms.Button();
            this.snapButton = new System.Windows.Forms.Button();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.txtScore = new System.Windows.Forms.Label();
            this.txtHighScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            //
            // startButton
            //
            this.startButton.BackColor = System.Drawing.Color.SkyBlue;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(596, 36);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(138, 85);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.button1_Click);
            //
            // snapButton
            //
            this.snapButton.BackColor = System.Drawing.Color.LightGreen;
            this.snapButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.snapButton.Location = new System.Drawing.Point(596, 127);
            this.snapButton.Name = "snapButton";
            this.snapButton.Size = new System.Drawing.Size(138, 85);
            this.snapButton.TabIndex = 0;
            this.snapButton.Text = "Snap";
            this.snapButton.UseVisualStyleBackColor = false;
            this.snapButton.Click += new System.EventHandler(this.snapButton_Click); // Corrigido para chamar o método correto
            //
            // picCanvas
            //
            this.picCanvas.BackColor = System.Drawing.Color.Silver;
            this.picCanvas.Location = new System.Drawing.Point(10, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(580, 680);
            this.picCanvas.TabIndex = 1;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdatePictureBoxGraphics); // Adiciona o evento Paint para o canvas
            //
            // txtScore
            //
            this.txtScore.AutoSize = true;
            this.txtScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.Location = new System.Drawing.Point(596, 250);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(94, 25);
            this.txtScore.TabIndex = 2;
            this.txtScore.Text = "Score: 0";
            //
            // txtHighScore
            //
            this.txtHighScore.AutoSize = true;
            this.txtHighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHighScore.Location = new System.Drawing.Point(596, 299);
            this.txtHighScore.Name = "txtHighScore";
            this.txtHighScore.Size = new System.Drawing.Size(119, 25);
            this.txtHighScore.TabIndex = 2;
            this.txtHighScore.Text = "High Score";
            //
            // gameTimer
            //
            this.gameTimer.Interval = 40;
            this.gameTimer.Tick += new System.EventHandler(this.GameTimerEvent); // Adiciona o evento Tick para o timer
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 717);
            this.Controls.Add(this.txtHighScore);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.snapButton);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Classic Snake Game";
            this.Load += new System.EventHandler(this.Form1_Load); // Adiciona o evento Load para o form
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button snapButton;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Label txtHighScore;
        private System.Windows.Forms.Timer gameTimer;
    }
}