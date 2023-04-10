namespace GeoLocations.PL.Win.Forms
{
    partial class frmCapitals
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
            this.lblCapitalsQuiz = new System.Windows.Forms.Label();
            this.lblQuizQuestion = new System.Windows.Forms.Label();
            this.lblQuizQuestionHolder = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblScoreHolder = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCapitalsQuiz
            // 
            this.lblCapitalsQuiz.AutoSize = true;
            this.lblCapitalsQuiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapitalsQuiz.Location = new System.Drawing.Point(12, 18);
            this.lblCapitalsQuiz.Name = "lblCapitalsQuiz";
            this.lblCapitalsQuiz.Size = new System.Drawing.Size(208, 37);
            this.lblCapitalsQuiz.TabIndex = 0;
            this.lblCapitalsQuiz.Text = "Capitals Quiz";
            // 
            // lblQuizQuestion
            // 
            this.lblQuizQuestion.AutoSize = true;
            this.lblQuizQuestion.Location = new System.Drawing.Point(16, 68);
            this.lblQuizQuestion.Name = "lblQuizQuestion";
            this.lblQuizQuestion.Size = new System.Drawing.Size(110, 13);
            this.lblQuizQuestion.TabIndex = 1;
            this.lblQuizQuestion.Text = "What is the capital of:";
            // 
            // lblQuizQuestionHolder
            // 
            this.lblQuizQuestionHolder.AutoSize = true;
            this.lblQuizQuestionHolder.Location = new System.Drawing.Point(132, 68);
            this.lblQuizQuestionHolder.Name = "lblQuizQuestionHolder";
            this.lblQuizQuestionHolder.Size = new System.Drawing.Size(111, 13);
            this.lblQuizQuestionHolder.TabIndex = 2;
            this.lblQuizQuestionHolder.Text = "lblQuizQuestionHolder";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(25, 343);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(38, 13);
            this.lblScore.TabIndex = 3;
            this.lblScore.Text = "Score:";
            // 
            // lblScoreHolder
            // 
            this.lblScoreHolder.AutoSize = true;
            this.lblScoreHolder.Location = new System.Drawing.Point(81, 342);
            this.lblScoreHolder.Name = "lblScoreHolder";
            this.lblScoreHolder.Size = new System.Drawing.Size(76, 13);
            this.lblScoreHolder.TabIndex = 4;
            this.lblScoreHolder.Text = "lblScoreHolder";
            // 
            // frmCapitals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 450);
            this.Controls.Add(this.lblScoreHolder);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblQuizQuestionHolder);
            this.Controls.Add(this.lblQuizQuestion);
            this.Controls.Add(this.lblCapitalsQuiz);
            this.Name = "frmCapitals";
            this.Text = "Capitals Quiz";
            this.Load += new System.EventHandler(this.frmCapitals_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCapitalsQuiz;
        private System.Windows.Forms.Label lblQuizQuestion;
        private System.Windows.Forms.Label lblQuizQuestionHolder;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblScoreHolder;
    }
}