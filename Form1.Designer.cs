namespace kiemtra
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.pictureBoxMaze = new System.Windows.Forms.PictureBox();
            this.btnBfs = new System.Windows.Forms.Button();
            this.btnDfs = new System.Windows.Forms.Button();
            this.txtTimer = new System.Windows.Forms.TextBox();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHybridSearch = new System.Windows.Forms.Button(); // ĐỔI TÊN Ở ĐÂY
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMaze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerate.Location = new System.Drawing.Point(12, 638);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(121, 29);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Tạo Mê Cung";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtWidth
            // 
            this.txtWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtWidth.Location = new System.Drawing.Point(12, 605);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(99, 27);
            this.txtWidth.TabIndex = 0;
            this.txtWidth.Text = "30";
            // 
            // txtHeight
            // 
            this.txtHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtHeight.Location = new System.Drawing.Point(117, 605);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(99, 27);
            this.txtHeight.TabIndex = 1;
            this.txtHeight.Text = "20";
            // 
            // pictureBoxMaze
            // 
            this.pictureBoxMaze.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxMaze.BackColor = System.Drawing.Color.White;
            this.pictureBoxMaze.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxMaze.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxMaze.Name = "pictureBoxMaze";
            this.pictureBoxMaze.Size = new System.Drawing.Size(1075, 587);
            this.pictureBoxMaze.TabIndex = 3;
            this.pictureBoxMaze.TabStop = false;
            this.pictureBoxMaze.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMaze_Paint);
            // 
            // btnBfs
            // 
            this.btnBfs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBfs.Location = new System.Drawing.Point(139, 638);
            this.btnBfs.Name = "btnBfs";
            this.btnBfs.Size = new System.Drawing.Size(121, 29);
            this.btnBfs.TabIndex = 3;
            this.btnBfs.Text = "Giải bằng BFS";
            this.btnBfs.UseVisualStyleBackColor = true;
            this.btnBfs.Click += new System.EventHandler(this.btnBfs_Click);
            // 
            // btnDfs
            // 
            this.btnDfs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDfs.Location = new System.Drawing.Point(266, 638);
            this.btnDfs.Name = "btnDfs";
            this.btnDfs.Size = new System.Drawing.Size(121, 29);
            this.btnDfs.TabIndex = 4;
            this.btnDfs.Text = "Giải bằng DFS";
            this.btnDfs.UseVisualStyleBackColor = true;
            this.btnDfs.Click += new System.EventHandler(this.btnDfs_Click);
            // 
            // txtTimer
            // 
            this.txtTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTimer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTimer.Location = new System.Drawing.Point(535, 642);
            this.txtTimer.Name = "txtTimer";
            this.txtTimer.ReadOnly = true;
            this.txtTimer.Size = new System.Drawing.Size(200, 20);
            this.txtTimer.TabIndex = 5;
            this.txtTimer.Text = "Thời gian: 0 ms";
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarSpeed.Location = new System.Drawing.Point(893, 638);
            this.trackBarSpeed.Maximum = 100;
            this.trackBarSpeed.Minimum = 1;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(194, 56);
            this.trackBarSpeed.TabIndex = 6;
            this.trackBarSpeed.TickFrequency = 10;
            this.trackBarSpeed.Value = 50;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(829, 642);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tốc độ:";
            // 
            // btnHybridSearch
            // 
            this.btnHybridSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHybridSearch.Location = new System.Drawing.Point(393, 638);
            this.btnHybridSearch.Name = "btnHybridSearch";
            this.btnHybridSearch.Size = new System.Drawing.Size(136, 29);
            this.btnHybridSearch.TabIndex = 8;
            this.btnHybridSearch.Text = "Giải Lai (BFS+DFS)";
            this.btnHybridSearch.UseVisualStyleBackColor = true;
            this.btnHybridSearch.Click += new System.EventHandler(this.btnHybridSearch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 679);
            this.Controls.Add(this.btnHybridSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarSpeed);
            this.Controls.Add(this.txtTimer);
            this.Controls.Add(this.btnDfs);
            this.Controls.Add(this.btnBfs);
            this.Controls.Add(this.pictureBoxMaze);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.btnGenerate);
            this.Name = "Form1";
            this.Text = "Maze Generator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMaze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.PictureBox pictureBoxMaze;
        private System.Windows.Forms.Button btnBfs;
        private System.Windows.Forms.Button btnDfs;
        private System.Windows.Forms.TextBox txtTimer;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHybridSearch;
    }
}