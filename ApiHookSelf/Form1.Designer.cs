namespace ApiHookSelf
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFileOperate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnWindowOperate = new System.Windows.Forms.Button();
            this.btnSafeWindowOperate = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFileOperate
            // 
            this.btnFileOperate.Location = new System.Drawing.Point(3, 3);
            this.btnFileOperate.Name = "btnFileOperate";
            this.btnFileOperate.Size = new System.Drawing.Size(112, 34);
            this.btnFileOperate.TabIndex = 0;
            this.btnFileOperate.Text = "文件操作";
            this.btnFileOperate.UseVisualStyleBackColor = true;
            this.btnFileOperate.Click += new System.EventHandler(this.btnFileOperate_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtResult, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(629, 479);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnFileOperate);
            this.flowLayoutPanel1.Controls.Add(this.btnWindowOperate);
            this.flowLayoutPanel1.Controls.Add(this.btnSafeWindowOperate);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(119, 473);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnWindowOperate
            // 
            this.btnWindowOperate.Location = new System.Drawing.Point(3, 43);
            this.btnWindowOperate.Name = "btnWindowOperate";
            this.btnWindowOperate.Size = new System.Drawing.Size(112, 35);
            this.btnWindowOperate.TabIndex = 1;
            this.btnWindowOperate.Text = "窗体操作";
            this.btnWindowOperate.UseVisualStyleBackColor = true;
            this.btnWindowOperate.Click += new System.EventHandler(this.btnWindowOperate_Click);
            // 
            // btnSafeWindowOperate
            // 
            this.btnSafeWindowOperate.Location = new System.Drawing.Point(3, 84);
            this.btnSafeWindowOperate.Name = "btnSafeWindowOperate";
            this.btnSafeWindowOperate.Size = new System.Drawing.Size(112, 29);
            this.btnSafeWindowOperate.TabIndex = 2;
            this.btnSafeWindowOperate.Text = "安全窗体操作";
            this.btnSafeWindowOperate.UseVisualStyleBackColor = true;
            this.btnSafeWindowOperate.Click += new System.EventHandler(this.btnSafeWindowOperate_Click);
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(128, 3);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(498, 473);
            this.txtResult.TabIndex = 1;
            this.txtResult.Text = "结果";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 479);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "注入目标";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFileOperate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnWindowOperate;
        private System.Windows.Forms.Button btnSafeWindowOperate;
        private System.Windows.Forms.TextBox txtResult;
    }
}

