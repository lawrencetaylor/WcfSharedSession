namespace Client
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._sessionButtonThree = new System.Windows.Forms.Button();
            this._sessionButtonTwo = new System.Windows.Forms.Button();
            this._sessionButtonOne = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._sharedButtonThree = new System.Windows.Forms.Button();
            this._sharedButtonTwo = new System.Windows.Forms.Button();
            this._sharedButtonOne = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._sessionButtonThree);
            this.groupBox2.Controls.Add(this._sessionButtonTwo);
            this.groupBox2.Controls.Add(this._sessionButtonOne);
            this.groupBox2.Location = new System.Drawing.Point(21, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 116);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Standard Session";
            // 
            // _sessionButtonThree
            // 
            this._sessionButtonThree.Location = new System.Drawing.Point(16, 79);
            this._sessionButtonThree.Name = "_sessionButtonThree";
            this._sessionButtonThree.Size = new System.Drawing.Size(98, 23);
            this._sessionButtonThree.TabIndex = 2;
            this._sessionButtonThree.Text = "Proxy Three";
            this._sessionButtonThree.UseVisualStyleBackColor = true;
            this._sessionButtonThree.Click += new System.EventHandler(this._sessionButtonThree_Click);
            // 
            // _sessionButtonTwo
            // 
            this._sessionButtonTwo.Location = new System.Drawing.Point(16, 49);
            this._sessionButtonTwo.Name = "_sessionButtonTwo";
            this._sessionButtonTwo.Size = new System.Drawing.Size(98, 23);
            this._sessionButtonTwo.TabIndex = 1;
            this._sessionButtonTwo.Text = "Proxy Two";
            this._sessionButtonTwo.UseVisualStyleBackColor = true;
            this._sessionButtonTwo.Click += new System.EventHandler(this._sessionButtonTwo_Click);
            // 
            // _sessionButtonOne
            // 
            this._sessionButtonOne.Location = new System.Drawing.Point(16, 19);
            this._sessionButtonOne.Name = "_sessionButtonOne";
            this._sessionButtonOne.Size = new System.Drawing.Size(98, 23);
            this._sessionButtonOne.TabIndex = 0;
            this._sessionButtonOne.Text = "Proxy One";
            this._sessionButtonOne.UseVisualStyleBackColor = true;
            this._sessionButtonOne.Click += new System.EventHandler(this._sessionButtonOne_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._sharedButtonThree);
            this.groupBox1.Controls.Add(this._sharedButtonTwo);
            this.groupBox1.Controls.Add(this._sharedButtonOne);
            this.groupBox1.Location = new System.Drawing.Point(21, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 116);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shared Instance";
            // 
            // _sharedButtonThree
            // 
            this._sharedButtonThree.Location = new System.Drawing.Point(16, 79);
            this._sharedButtonThree.Name = "_sharedButtonThree";
            this._sharedButtonThree.Size = new System.Drawing.Size(98, 23);
            this._sharedButtonThree.TabIndex = 2;
            this._sharedButtonThree.Text = "Proxy Three";
            this._sharedButtonThree.UseVisualStyleBackColor = true;
            this._sharedButtonThree.Click += new System.EventHandler(this._sharedButtonThree_Click);
            // 
            // _sharedButtonTwo
            // 
            this._sharedButtonTwo.Location = new System.Drawing.Point(16, 49);
            this._sharedButtonTwo.Name = "_sharedButtonTwo";
            this._sharedButtonTwo.Size = new System.Drawing.Size(98, 23);
            this._sharedButtonTwo.TabIndex = 1;
            this._sharedButtonTwo.Text = "Proxy Two";
            this._sharedButtonTwo.UseVisualStyleBackColor = true;
            this._sharedButtonTwo.Click += new System.EventHandler(this._sharedButtonTwo_Click);
            // 
            // _sharedButtonOne
            // 
            this._sharedButtonOne.Location = new System.Drawing.Point(16, 19);
            this._sharedButtonOne.Name = "_sharedButtonOne";
            this._sharedButtonOne.Size = new System.Drawing.Size(98, 23);
            this._sharedButtonOne.TabIndex = 0;
            this._sharedButtonOne.Text = "Proxy One";
            this._sharedButtonOne.UseVisualStyleBackColor = true;
            this._sharedButtonOne.Click += new System.EventHandler(this._sharedButtonOne_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 318);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Shared Instance Client";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button _sessionButtonThree;
        private System.Windows.Forms.Button _sessionButtonTwo;
        private System.Windows.Forms.Button _sessionButtonOne;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _sharedButtonThree;
        private System.Windows.Forms.Button _sharedButtonTwo;
        private System.Windows.Forms.Button _sharedButtonOne;

    }
}

