using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowSync
{
    public partial class MainForm : Form
    {

        [DllImport("user32.dll")] public static extern int GetCursorPos(ref Point lpPoint); //获取鼠标所在的屏幕坐标位置
        [DllImport("user32.dll")] public static extern int WindowFromPoint(int xPoint, int yPoint);  //获取坐标处窗体句柄
        [DllImport("user32.dll")] public static extern int GetWindowText(int hwnd, StringBuilder lpString, int nMaxCount);//获取窗体标题
        [DllImport("user32.dll", CharSet = CharSet.Auto)] private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")] public static extern int GetForegroundWindow(); //获取当前置顶窗口

        //const int WM_KEYDOWN = 0x0100;
        //const int WM_KEYUP = 0x0101;
        //const int VK_CONTROL = 0x11;
        //const int VK_CODE = 0x41; //为'A'的虚拟键码

        //const int WM_CLICK = 0x00F5;
        ///// <summary>
        ///// 鼠标按下
        ///// </summary>
        //const int WM_LBUTTONDOWN = 0x0201;
        ///// <summary>
        ///// 鼠标抬起
        ///// </summary>
        //const int WM_LBUTTONUP = 0x0202;

        //窗口同步是否运行中
        bool isRuning = false;

        KeyboardHook? keyboardHook;

        //主控窗体的句柄
        int? masterWindowHwnd;

        //忽略键集合
        List<int> lstIgroneKeys = new List<int>();

        public MainForm()
        {
            InitializeComponent();
        }

        void StatusChange(bool runing)
        {
            btnStart.Text = runing ? "停止" : "运行";
            btnGetHandle.Enabled = !runing;
            btnClear.Enabled = !runing;

        }

        /// <summary>
        /// 客户端键盘捕捉事件.
        /// </summary>
        /// <param name="hookStruct">由Hook程序发送的按键信息</param>
        /// <param name="handle">是否拦截</param>
        public void OnKeyPressProcessHandle(KeyboardHook.HookStruct hookStruct, out bool handle)
        {
            //不拦截任何键
            handle = false;

            Keys key = (Keys)hookStruct.vkCode;
            //label1.Text = "你按下:" + (key == Keys.None ? "" : key.ToString());
            Console.WriteLine(hookStruct.scanCode.ToString());
            Console.WriteLine(hookStruct.dwExtraInfo.ToString());
            SendKeyPress(hookStruct);
        }

        // 示例：模拟按键'A'的按下和释放
        private void SendKeyPress(KeyboardHook.HookStruct hookStruct)
        {
            var currentHwnd = GetForegroundWindow();
            if (masterWindowHwnd != currentHwnd) return; //确认是否为主控窗体键盘输入
            //Console.WriteLine(hookStruct.vkCode);
            if (lstIgroneKeys.Contains(hookStruct.vkCode)) return; //是否为忽略键

            for (int i = 0; i < lstWindows.Items.Count; i++)
            {
                ListViewItem item = lstWindows.Items[i];
                int hWnd = int.Parse(item.Text);
                if (hWnd == 0 || hWnd == masterWindowHwnd) continue;

                SendMessage(hWnd, hookStruct.wParam, hookStruct.vkCode, 0);
                //if (hookStruct.wParam == WM_KEYUP)
                //{
                //    if (lstKeyClick.Items.ContainsKey(hookStruct.vkCode.ToString()))
                //    {
                //        WindowClick(hWnd);
                //    }
                //    else if (lstKeyClickAttact.Items.ContainsKey(hookStruct.vkCode.ToString()))
                //    {
                //        WindowClick(hWnd);
                //        Task.Run(() =>
                //        {
                //            Thread.Sleep(300);
                //            SendMessage(hWnd, WM_KEYDOWN, (int)Keys.F8, 0);
                //            SendMessage(hWnd, WM_KEYUP, (int)Keys.F8, 0);
                //        });
                //    }
                //}

            }

            //if (hookStruct.wParam == WM_KEYUP)
            //{
            //    if (lstKeyClick.Items.ContainsKey(hookStruct.vkCode.ToString()))
            //    {
            //        WindowClick(mainHwnd, true); //点出就会失去目标
            //    }
            //    else if (lstKeyClickAttact.Items.ContainsKey(hookStruct.vkCode.ToString()))
            //    {
            //        WindowClick(mainHwnd, true);//点出就会失去目标 
            //    }
            //}
        }

        private void btnGetHandle_MouseDown(object sender, MouseEventArgs e)
        {
            //改变鼠标样式为十字
            Cursor = Cursors.Cross;
        }

        private void btnGetHandle_MouseUp(object sender, MouseEventArgs e)
        {
            //改变鼠标样式为默认
            Cursor = Cursors.Default;

            //获取鼠标坐标值
            var point = new Point();
            GetCursorPos(ref point);

            //获取坐标处窗体句柄
            int hwnd = WindowFromPoint(point.X, point.Y);

            //获取窗体标题
            var title = new StringBuilder(256);
            GetWindowText(hwnd, title, 256);



            //添加句柄到列表
            var item = lstWindows.Items.Add(new ListViewItem() { Text = hwnd.ToString() });
            item.SubItems.Add(title.ToString());
            item.SubItems.Add("--");

            //添加第一个窗体为主控窗体
            if (lstWindows.Items.Count == 1)
            {
                SetMasterWindow(item);
            }
        }

        void SetMasterWindow(ListViewItem master)
        {
            foreach (ListViewItem item in lstWindows.Items)
            {
                if (item == master)
                {
                    masterWindowHwnd = int.Parse(master.Text);
                    item.SubItems[2].Text = "V";
                }
                else
                {
                    item.SubItems[2].Text = "--";
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (lstWindows.Items.Count < 1 || !isRuning)
            {
                MessageBox.Show("需要至少两个窗口才能运行！");
                return;
            }
            isRuning = !isRuning;
            if (isRuning)
            {
                keyboardHook = new KeyboardHook();
                keyboardHook.Connect(this.OnKeyPressProcessHandle);
            }
            else
            {
                if (keyboardHook != null) keyboardHook.Disconnect();
            }
            StatusChange(isRuning);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstWindows.Items.Clear();
            masterWindowHwnd = null;
        }

        private void lstWindows_DoubleClick(object sender, EventArgs e)
        {
            if (lstWindows.SelectedItems.Count > 0)
            {
                SetMasterWindow(lstWindows.SelectedItems[0]);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            StatusChange(isRuning);
        }

        private void btnIgroneClear_Click(object sender, EventArgs e)
        {
            txtIgroneKeys.Text = "";
            lstIgroneKeys.Clear();
        }

        private void btnAddIgrone_Click(object sender, EventArgs e)
        {
            KeyboardHook.WaitForKeyPress(btnAddIgrone, (code, text) => {
                txtIgroneKeys.Text += (txtIgroneKeys.Text.Length>0?", ":"") +text;
                lstIgroneKeys.Add(code);
            });
        }
    }
}
