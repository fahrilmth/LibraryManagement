namespace LibraryManagement
{
    partial class MainMenu
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
            this.dgvLoanData = new System.Windows.Forms.DataGridView();
            this.buttonNewBorr = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBook = new System.Windows.Forms.Button();
            this.buttonCat = new System.Windows.Forms.Button();
            this.buttonUsers = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanData)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLoanData
            // 
            this.dgvLoanData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoanData.Location = new System.Drawing.Point(12, 49);
            this.dgvLoanData.Name = "dgvLoanData";
            this.dgvLoanData.RowHeadersWidth = 62;
            this.dgvLoanData.RowTemplate.Height = 33;
            this.dgvLoanData.Size = new System.Drawing.Size(854, 521);
            this.dgvLoanData.TabIndex = 0;
            // 
            // buttonNewBorr
            // 
            this.buttonNewBorr.Location = new System.Drawing.Point(12, 591);
            this.buttonNewBorr.Name = "buttonNewBorr";
            this.buttonNewBorr.Size = new System.Drawing.Size(156, 34);
            this.buttonNewBorr.TabIndex = 1;
            this.buttonNewBorr.Text = "New Borrowing";
            this.buttonNewBorr.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(153, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(713, 31);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "QUICK SEARCH";
            // 
            // buttonBook
            // 
            this.buttonBook.Location = new System.Drawing.Point(185, 591);
            this.buttonBook.Name = "buttonBook";
            this.buttonBook.Size = new System.Drawing.Size(156, 34);
            this.buttonBook.TabIndex = 4;
            this.buttonBook.Text = "Books";
            this.buttonBook.UseVisualStyleBackColor = true;
            this.buttonBook.Click += new System.EventHandler(this.buttonBook_Click);
            // 
            // buttonCat
            // 
            this.buttonCat.Location = new System.Drawing.Point(360, 591);
            this.buttonCat.Name = "buttonCat";
            this.buttonCat.Size = new System.Drawing.Size(156, 34);
            this.buttonCat.TabIndex = 5;
            this.buttonCat.Text = "Categories";
            this.buttonCat.UseVisualStyleBackColor = true;
            // 
            // buttonUsers
            // 
            this.buttonUsers.Location = new System.Drawing.Point(536, 591);
            this.buttonUsers.Name = "buttonUsers";
            this.buttonUsers.Size = new System.Drawing.Size(156, 34);
            this.buttonUsers.TabIndex = 7;
            this.buttonUsers.Text = "Users";
            this.buttonUsers.UseVisualStyleBackColor = true;
            this.buttonUsers.Click += new System.EventHandler(this.buttonUserData_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(710, 591);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(156, 34);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Location = new System.Drawing.Point(872, 163);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 350);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NEW BORROWING";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "QUICK SEARCH";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Location = new System.Drawing.Point(149, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(318, 31);
            this.textBox2.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LibraryManagement.Properties.Resources.profile;
            this.pictureBox1.Location = new System.Drawing.Point(880, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(135, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelName.Location = new System.Drawing.Point(1021, 110);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(86, 38);
            this.labelName.TabIndex = 11;
            this.labelName.Text = "name";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 647);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonUsers);
            this.Controls.Add(this.buttonCat);
            this.Controls.Add(this.buttonBook);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonNewBorr);
            this.Controls.Add(this.dgvLoanData);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvLoanData;
        private Button buttonNewBorr;
        private TextBox textBox1;
        private Label label1;
        private Button buttonBook;
        private Button buttonCat;
        private Button buttonUsers;
        private Button buttonDelete;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox textBox2;
        private PictureBox pictureBox1;
        private Label labelName;
    }
}