namespace ApiHookerDestination
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnWindowOperateInUI = new System.Windows.Forms.Button();
            this.btnWindowOperateInBackground = new System.Windows.Forms.Button();
            this.btnFileOperateInUI = new System.Windows.Forms.Button();
            this.btnFileOperateInBackground = new System.Windows.Forms.Button();
            this.btnWebOperateInUi = new System.Windows.Forms.Button();
            this.btnWebOperateInBackground = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNewUi = new System.Windows.Forms.Button();
            this.btnShowModelWindow = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.btnWindowOperateInUI);
            this.flowLayoutPanel1.Controls.Add(this.btnWindowOperateInBackground);
            this.flowLayoutPanel1.Controls.Add(this.btnFileOperateInUI);
            this.flowLayoutPanel1.Controls.Add(this.btnFileOperateInBackground);
            this.flowLayoutPanel1.Controls.Add(this.btnWebOperateInUi);
            this.flowLayoutPanel1.Controls.Add(this.btnWebOperateInBackground);
            this.flowLayoutPanel1.Controls.Add(this.textBox1);
            this.flowLayoutPanel1.Controls.Add(this.btnNewUi);
            this.flowLayoutPanel1.Controls.Add(this.btnShowModelWindow);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(145, 479);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnWindowOperateInUI
            // 
            this.btnWindowOperateInUI.AutoSize = true;
            this.btnWindowOperateInUI.Location = new System.Drawing.Point(3, 3);
            this.btnWindowOperateInUI.Name = "btnWindowOperateInUI";
            this.btnWindowOperateInUI.Size = new System.Drawing.Size(117, 23);
            this.btnWindowOperateInUI.TabIndex = 2;
            this.btnWindowOperateInUI.Text = "UI操作-在UI线程";
            this.btnWindowOperateInUI.UseVisualStyleBackColor = true;
            this.btnWindowOperateInUI.Click += new System.EventHandler(this.btnWindowOperateInUi_Click);
            // 
            // btnWindowOperateInBackground
            // 
            this.btnWindowOperateInBackground.AutoSize = true;
            this.btnWindowOperateInBackground.Location = new System.Drawing.Point(3, 32);
            this.btnWindowOperateInBackground.Name = "btnWindowOperateInBackground";
            this.btnWindowOperateInBackground.Size = new System.Drawing.Size(129, 23);
            this.btnWindowOperateInBackground.TabIndex = 1;
            this.btnWindowOperateInBackground.Text = "UI操作-在后台线程";
            this.btnWindowOperateInBackground.UseVisualStyleBackColor = true;
            this.btnWindowOperateInBackground.Click += new System.EventHandler(this.btnWindowOperateInBackground_Click);
            // 
            // btnFileOperateInUI
            // 
            this.btnFileOperateInUI.AutoSize = true;
            this.btnFileOperateInUI.Location = new System.Drawing.Point(3, 61);
            this.btnFileOperateInUI.Name = "btnFileOperateInUI";
            this.btnFileOperateInUI.Size = new System.Drawing.Size(117, 23);
            this.btnFileOperateInUI.TabIndex = 3;
            this.btnFileOperateInUI.Text = "IO操作-在UI线程";
            this.btnFileOperateInUI.UseVisualStyleBackColor = true;
            this.btnFileOperateInUI.Click += new System.EventHandler(this.btnFileOperateInUI_Click);
            // 
            // btnFileOperateInBackground
            // 
            this.btnFileOperateInBackground.AutoSize = true;
            this.btnFileOperateInBackground.Location = new System.Drawing.Point(3, 90);
            this.btnFileOperateInBackground.Name = "btnFileOperateInBackground";
            this.btnFileOperateInBackground.Size = new System.Drawing.Size(129, 23);
            this.btnFileOperateInBackground.TabIndex = 0;
            this.btnFileOperateInBackground.Text = "IO操作-在后台线程";
            this.btnFileOperateInBackground.UseVisualStyleBackColor = true;
            this.btnFileOperateInBackground.Click += new System.EventHandler(this.btnFileOperateInBackground_Click);
            // 
            // btnWebOperateInUi
            // 
            this.btnWebOperateInUi.AutoSize = true;
            this.btnWebOperateInUi.Location = new System.Drawing.Point(3, 119);
            this.btnWebOperateInUi.Name = "btnWebOperateInUi";
            this.btnWebOperateInUi.Size = new System.Drawing.Size(111, 23);
            this.btnWebOperateInUi.TabIndex = 4;
            this.btnWebOperateInUi.Text = "Web操作-在UI线程";
            this.btnWebOperateInUi.UseVisualStyleBackColor = true;
            this.btnWebOperateInUi.Click += new System.EventHandler(this.btnWebOperateInUi_Click);
            // 
            // btnWebOperateInBackground
            // 
            this.btnWebOperateInBackground.AutoSize = true;
            this.btnWebOperateInBackground.Location = new System.Drawing.Point(3, 148);
            this.btnWebOperateInBackground.Name = "btnWebOperateInBackground";
            this.btnWebOperateInBackground.Size = new System.Drawing.Size(123, 23);
            this.btnWebOperateInBackground.TabIndex = 5;
            this.btnWebOperateInBackground.Text = "Web操作-在后台线程";
            this.btnWebOperateInBackground.UseVisualStyleBackColor = true;
            this.btnWebOperateInBackground.Click += new System.EventHandler(this.btnWebOperateInBackground_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 177);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(151, 485);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnNewUi
            // 
            this.btnNewUi.Location = new System.Drawing.Point(3, 204);
            this.btnNewUi.Name = "btnNewUi";
            this.btnNewUi.Size = new System.Drawing.Size(75, 23);
            this.btnNewUi.TabIndex = 7;
            this.btnNewUi.Text = "新UI线程";
            this.btnNewUi.UseVisualStyleBackColor = true;
            this.btnNewUi.Click += new System.EventHandler(this.btnNewUi_Click);
            // 
            // btnShowModelWindow
            // 
            this.btnShowModelWindow.Location = new System.Drawing.Point(3, 233);
            this.btnShowModelWindow.Name = "btnShowModelWindow";
            this.btnShowModelWindow.Size = new System.Drawing.Size(75, 23);
            this.btnShowModelWindow.TabIndex = 8;
            this.btnShowModelWindow.Text = "弹模态窗口";
            this.btnShowModelWindow.UseVisualStyleBackColor = true;
            this.btnShowModelWindow.Click += new System.EventHandler(this.btnShowModelWindow_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(151, 485);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "注入目标";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnFileOperateInBackground;
        private System.Windows.Forms.Button btnWindowOperateInBackground;
        private System.Windows.Forms.Button btnWindowOperateInUI;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnFileOperateInUI;
        private System.Windows.Forms.Button btnWebOperateInUi;
        private System.Windows.Forms.Button btnWebOperateInBackground;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnNewUi;
        private System.Windows.Forms.Button btnShowModelWindow;

    }
}