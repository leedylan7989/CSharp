namespace HeonLee_Assignment1
{
    partial class Form1
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
            this.txtRuns = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioIntelligent = new System.Windows.Forms.RadioButton();
            this.radioNonIntelligent = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtKnightMoves = new System.Windows.Forms.Label();
            this.Chessboard = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRuns
            // 
            this.txtRuns.Location = new System.Drawing.Point(15, 45);
            this.txtRuns.Name = "txtRuns";
            this.txtRuns.Size = new System.Drawing.Size(100, 20);
            this.txtRuns.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioIntelligent);
            this.groupBox1.Controls.Add(this.radioNonIntelligent);
            this.groupBox1.Location = new System.Drawing.Point(161, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 58);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Which method?";
            // 
            // radioIntelligent
            // 
            this.radioIntelligent.AutoSize = true;
            this.radioIntelligent.Location = new System.Drawing.Point(127, 29);
            this.radioIntelligent.Name = "radioIntelligent";
            this.radioIntelligent.Size = new System.Drawing.Size(70, 17);
            this.radioIntelligent.TabIndex = 1;
            this.radioIntelligent.TabStop = true;
            this.radioIntelligent.Text = "Intelligent";
            this.radioIntelligent.UseVisualStyleBackColor = true;
            // 
            // radioNonIntelligent
            // 
            this.radioNonIntelligent.AutoSize = true;
            this.radioNonIntelligent.Location = new System.Drawing.Point(15, 29);
            this.radioNonIntelligent.Name = "radioNonIntelligent";
            this.radioNonIntelligent.Size = new System.Drawing.Size(93, 17);
            this.radioNonIntelligent.TabIndex = 0;
            this.radioNonIntelligent.TabStop = true;
            this.radioNonIntelligent.Text = "Non Intelligent";
            this.radioNonIntelligent.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "How many runs?";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(389, 42);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtKnightMoves
            // 
            this.txtKnightMoves.AutoSize = true;
            this.txtKnightMoves.Location = new System.Drawing.Point(12, 95);
            this.txtKnightMoves.Name = "txtKnightMoves";
            this.txtKnightMoves.Size = new System.Drawing.Size(69, 13);
            this.txtKnightMoves.TabIndex = 4;
            this.txtKnightMoves.Text = "KnightMoves";
            this.txtKnightMoves.Visible = false;
            // 
            // Chessboard
            // 
            this.Chessboard.AutoSize = true;
            this.Chessboard.Location = new System.Drawing.Point(456, 86);
            this.Chessboard.Name = "Chessboard";
            this.Chessboard.Size = new System.Drawing.Size(63, 13);
            this.Chessboard.TabIndex = 5;
            this.Chessboard.Text = "Chessboard";
            this.Chessboard.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Chessboard);
            this.Controls.Add(this.txtKnightMoves);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtRuns);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRuns;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioIntelligent;
        private System.Windows.Forms.RadioButton radioNonIntelligent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label txtKnightMoves;
        private System.Windows.Forms.Label Chessboard;
    }
}

