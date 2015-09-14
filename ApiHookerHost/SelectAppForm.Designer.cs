namespace ApiHookerHost
{
    partial class SelectAppForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgProcesses = new System.Windows.Forms.DataGridView();
            this.标识DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.进程名DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.标题DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.路径DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.processInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProcesses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgProcesses, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(769, 573);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 546);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(763, 24);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // dgProcesses
            // 
            this.dgProcesses.AllowUserToAddRows = false;
            this.dgProcesses.AllowUserToDeleteRows = false;
            this.dgProcesses.AllowUserToOrderColumns = true;
            this.dgProcesses.AutoGenerateColumns = false;
            this.dgProcesses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgProcesses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProcesses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.标识DataGridViewTextBoxColumn,
            this.进程名DataGridViewTextBoxColumn,
            this.标题DataGridViewTextBoxColumn,
            this.路径DataGridViewTextBoxColumn});
            this.dgProcesses.DataSource = this.processInfoBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProcesses.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgProcesses.Location = new System.Drawing.Point(3, 3);
            this.dgProcesses.MultiSelect = false;
            this.dgProcesses.Name = "dgProcesses";
            this.dgProcesses.ReadOnly = true;
            this.dgProcesses.RowHeadersVisible = false;
            this.dgProcesses.RowTemplate.Height = 23;
            this.dgProcesses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgProcesses.Size = new System.Drawing.Size(763, 537);
            this.dgProcesses.TabIndex = 6;
            this.dgProcesses.VirtualMode = true;
            this.dgProcesses.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProcesses_CellMouseClick);
            this.dgProcesses.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgProcesses_DataError);
            this.dgProcesses.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgProcesses_RowsAdded);
            // 
            // 标识DataGridViewTextBoxColumn
            // 
            this.标识DataGridViewTextBoxColumn.DataPropertyName = "标识";
            this.标识DataGridViewTextBoxColumn.HeaderText = "标识";
            this.标识DataGridViewTextBoxColumn.Name = "标识DataGridViewTextBoxColumn";
            this.标识DataGridViewTextBoxColumn.ReadOnly = true;
            this.标识DataGridViewTextBoxColumn.Width = 54;
            // 
            // 进程名DataGridViewTextBoxColumn
            // 
            this.进程名DataGridViewTextBoxColumn.DataPropertyName = "进程名";
            this.进程名DataGridViewTextBoxColumn.HeaderText = "进程名";
            this.进程名DataGridViewTextBoxColumn.Name = "进程名DataGridViewTextBoxColumn";
            this.进程名DataGridViewTextBoxColumn.ReadOnly = true;
            this.进程名DataGridViewTextBoxColumn.Width = 66;
            // 
            // 标题DataGridViewTextBoxColumn
            // 
            this.标题DataGridViewTextBoxColumn.DataPropertyName = "标题";
            this.标题DataGridViewTextBoxColumn.HeaderText = "标题";
            this.标题DataGridViewTextBoxColumn.Name = "标题DataGridViewTextBoxColumn";
            this.标题DataGridViewTextBoxColumn.ReadOnly = true;
            this.标题DataGridViewTextBoxColumn.Width = 54;
            // 
            // 路径DataGridViewTextBoxColumn
            // 
            this.路径DataGridViewTextBoxColumn.DataPropertyName = "路径";
            this.路径DataGridViewTextBoxColumn.HeaderText = "路径";
            this.路径DataGridViewTextBoxColumn.Name = "路径DataGridViewTextBoxColumn";
            this.路径DataGridViewTextBoxColumn.ReadOnly = true;
            this.路径DataGridViewTextBoxColumn.Width = 54;
            // 
            // processInfoBindingSource
            // 
            this.processInfoBindingSource.DataSource = typeof(ApiHookerHost.ProcessInfo);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(36, 4);
            // 
            // SelectAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 573);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SelectAppForm";
            this.ShowIcon = false;
            this.Text = "当前运行的进程";
            this.Load += new System.EventHandler(this.SelectAppForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgProcesses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgProcesses;
        private System.Windows.Forms.BindingSource processInfoBindingSource;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 标识DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 进程名DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 标题DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 路径DataGridViewTextBoxColumn;
    }
}

