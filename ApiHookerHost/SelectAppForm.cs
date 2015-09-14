using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;


namespace ApiHookerHost
{
    public partial class SelectAppForm : Form
    {
        private readonly SynchronizationContext _sc;

        private readonly Dictionary<string, Action> _actions;

        public SelectAppForm()
        {
            InitializeComponent();

            processInfoBindingSource.DataSource = new BindingCollection<ProcessInfo>();

            _sc = SynchronizationContext.Current;

            _actions = new Dictionary<string, Action>
            {
                {"复制选中内容",CopySelectedCell},
                {"打开程序目录",ExplorerSelectedProcess},
                {"监视",Hook},
                {"监视新程序...",StartNew},
            };

            ThreadPool.QueueUserWorkItem(aa =>
            {
                while (!IsDisposed)
                {
                    Thread.Sleep(1000);
                    lock (dgProcesses)
                    {
                        RefreshProcesses();
                    }
                }
            });
        }

        private void SelectAppForm_Load(object sender, EventArgs e)
        {
            contextMenuStrip1.Items.AddRange(_actions
                .Select(p => new ToolStripButton(p.Key, null, (a, b) => p.Value()))
                .OfType<ToolStripItem>()
                .ToArray());
            contextMenuStrip1.Width = 10;

            flowLayoutPanel1.Controls.AddRange(_actions
                .Select(p =>
                {
                    var button = new Button { Text = p.Key, AutoSize = true };
                    button.Click += (a, b) => p.Value();
                    return button;
                })
                .OfType<Control>()
                .ToArray());
        }

        private void RefreshProcesses()
        {
            var processes = Process.GetProcesses().Select(p =>
            {
                var info = new ProcessInfo();
                try
                {
                    info.标识 = p.Id;
                }
                catch
                {
                    info.标识 = null;
                }
                try
                {
                    info.标题 = p.MainWindowTitle;
                }
                catch
                {
                    info.标题 = null;
                }
                try
                {
                    info.进程名 = p.ProcessName;
                }
                catch
                {
                    info.进程名 = null;
                }
                try
                {
                    info.路径 = p.MainModule.FileName;
                }
                catch
                {
                    info.路径 = null;
                }

                return info;
            }).ToList();

            var oldProcesses = processInfoBindingSource.OfType<ProcessInfo>().ToArray();
            var deadItems = oldProcesses.Where(q => processes.All(p => q.标识 != p.标识)).ToList();
            var newItems = processes.Where(p => oldProcesses.All(q => q.标识 != p.标识)).ToList();
            processes.Except(newItems).ToList().ForEach(newItem =>
            {
                //处理属性有更新的实体
                var oldItem = oldProcesses.FirstOrDefault(q => q.标识 == newItem.标识);
                if (oldItem != null && newItem.GetHashCode() != oldItem.GetHashCode())
                {
                    deadItems.Add(oldItem);
                    newItems.Add(newItem);
                }
            });

            if (deadItems.Any())
            {
                _sc.Post(d => deadItems.ForEach(i => processInfoBindingSource.Remove(i)), null);
            }

            if (newItems.Any())
            {
                _sc.Post(d => newItems.ForEach(i => processInfoBindingSource.Add(i)), null);
            }
        }

        private DataGridViewCell GetSelectedCell()
        {
            return dgProcesses.SelectedCells.OfType<DataGridViewCell>().FirstOrDefault();
        }

        private ProcessInfo GetSelectedProcess()
        {
            var cell = GetSelectedCell();
            if (cell != null)
            {
                var row = cell.OwningRow;
                if (row != null)
                {
                    return row.DataBoundItem as ProcessInfo;
                }
            }
            return null;
        }

        private void CopySelectedCell()
        {
            var cell = GetSelectedCell();
            if (cell != null)
            {
                Clipboard.SetDataObject(cell.Value, true);
            }
        }

        private void ExplorerSelectedProcess()
        {
            var processInfo = GetSelectedProcess();
            if (processInfo != null)
            {
                Process.Start("Explorer.exe", string.Format("/Select, {0}", processInfo.路径));
            }
        }

        private void Hook()
        {
            var processInfo = GetSelectedProcess();
            if (processInfo != null)
            {
                if (processInfo.标识.HasValue)
                {
                    ThreadPool.QueueUserWorkItem(d =>
                    {
                        var appDomain = AppDomain.CreateDomain(processInfo.标识 + processInfo.标题 + processInfo.路径);
                        var program = appDomain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, typeof(Program).FullName) as Program;
                        if (program != null)
                        {
                            program.Start(new[] { processInfo.标识.ToString() });
                        }
                        AppDomain.Unload(appDomain);
                    });
                }
            }
        }

        private static void StartNew()
        {
            using (var dialog = new OpenFileDialog())
            {
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK && dialog.CheckFileExists)
                {
                    var name = dialog.FileName;
                    ThreadPool.QueueUserWorkItem(d =>
                    {
                        var appDomain = AppDomain.CreateDomain(name);
                        appDomain.ExecuteAssembly(Assembly.GetExecutingAssembly().Location, new[] { "" + name + "" });
                    });
                }
            }
        }

        private void dgProcesses_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            var dg = sender as DataGridView;
            if (dg != null)
            {
                dg[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Red;
            }
        }

        private void dgProcesses_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition);
            }
        }

        private void dgProcesses_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgProcesses.SortedColumn != null && dgProcesses.SortOrder != SortOrder.None)
            {
                dgProcesses.Sort(dgProcesses.SortedColumn, dgProcesses.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
            }
        }
    }
}
