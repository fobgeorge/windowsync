using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowSync
{
    public class KeyboardHook
    {

        //取消钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern bool UnhookWindowsHookEx(int idHook);
        
        [DllImport("user32.dll")] private static extern int CallNextHookEx(int idHook, int nCode, int wParam, nint lParam);//调用下一个钩子

        [DllImport("kernel32.dll")] private static extern int GetCurrentThreadId();
        
        [DllImport("kernel32.dll")] private static extern nint GetModuleHandle(string name);
        [DllImport("user32.dll")]  private static extern int SetWindowsHookEx(int idHook, HookHandle lpfn, nint hInstance, int threadId);//设置钩子

        private const int WH_KEYBOARD_LL = 13; //键盘

        //键盘处理事件
        public delegate void ProcessHandle(HookStruct param, out bool handle);
        //外部调用的键盘处理事件
        private static ProcessHandle? clientMethod;

        //键盘处理事件委托
        private delegate int HookHandle(int nCode, int wParam, nint lParam);        
        private HookHandle? keyBoardHookProcedure;

        

        //SetWindowsHookEx返回值，失败返回0
        private static int hookSetSuccess = 0;
        private nint hookWindowPtr = nint.Zero;

        /// <summary>
        /// 连接监听钩子
        /// </summary>
        public void Connect(ProcessHandle handle)           
        {
            clientMethod = handle;
            // 安装键盘钩子
            if (hookSetSuccess == 0)
            {
                keyBoardHookProcedure = new HookHandle(OnHookProcedure);
                hookWindowPtr = GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);

                hookSetSuccess = SetWindowsHookEx(WH_KEYBOARD_LL,keyBoardHookProcedure,hookWindowPtr,0);
                                
                if (hookSetSuccess == 0) Disconnect(); //如果设置钩子失败
            }
        }
        /// <summary>
        /// 断开监听钩子
        /// </summary>
        public void Disconnect() {
            if (hookSetSuccess != 0)
            {
                var ret = UnhookWindowsHookEx(hookSetSuccess);
                if (ret) hookSetSuccess = 0;
            }
        }

        //钩子事件内部调用
        private static int OnHookProcedure(int nCode, int wParam, nint lParam)
        {
            if (nCode >= 0)
            {
                //转换结构
                var hookStruct = (HookStruct)Marshal.PtrToStructure(lParam, typeof(HookStruct));
                hookStruct!.wParam = wParam;
                if (clientMethod != null)
                {
                    var handle = false;
                    //调用客户提供的事件处理程序。
                    clientMethod(hookStruct, out handle);
                    if (handle) return 1; //1:表示拦截键盘,return 退出
                }
            }
            return CallNextHookEx(hookSetSuccess, nCode, wParam, lParam);
        }

        /// <summary>
        /// 等获取一个输入键
        /// </summary>
        /// <returns></returns>
        public static void WaitForKeyPress(Button button,Action<int,string> callback)
        {
            button.Text = "请按键...";
            button.Enabled = false;
            var hook = new KeyboardHook();
            hook.Connect((KeyboardHook.HookStruct hookStruct, out bool handle) =>
            {
                handle = false;
                Keys key = (Keys)hookStruct.vkCode;
                callback.Invoke(hookStruct.vkCode,key.ToString());
                hook.Disconnect();
                button.Enabled = true;
                button.Text = "添加";
                
            });
        }

        //钩子结构
        [StructLayout(LayoutKind.Sequential)]
        public class HookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
            //此参数可以是以下消息之一： WM_KEYDOWN、 WM_KEYUP、 WM_SYSKEYDOWN或 WM_SYSKEYUP。 https://learn.microsoft.com/zh-cn/windows/win32/winmsg/lowlevelkeyboardproc
            public int wParam; 
        }
    }
}
