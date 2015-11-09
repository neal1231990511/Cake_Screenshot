using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cake_Screenshot
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        enum Direction
        {
            Vertical,
            Horizontal

        };

        private void Form1_Load(object sender, EventArgs e)
        {
            Load_Deivce();//讀取裝置
        }

        private class HotKey //Import HotKey lib
        {
            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool RegisterHotKey(
                 IntPtr hWnd,
                 int id,
                 KeyModifiers fsModifiers,
                 Keys vk
                 );

            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool UnregisterHotKey(
                IntPtr hWnd,
                int id
                );

            [Flags()]
            public enum KeyModifiers
            {
                None = 0,
                Alt = 1,
                Ctrl = 2,
                Shift = 4,
                WindowsKey = 8
            }
        }

        //讀取裝置
        private void Load_Deivce() 
        {
            ConsoleHelper console = new ConsoleHelper();
            string sCMD_Deivce = "adb devices";
            string sCMD_Kill = "adb kill-server";
            string sCMD_Start = "adb start-server";

            string sDevices_Kill = console.DoCmdWork(sCMD_Kill, Environment.CurrentDirectory, false); // kill adb server
            string sDevices_Start = console.DoCmdWork(sCMD_Start, Environment.CurrentDirectory, false); // start adb server
            string sDevices_check = console.DoCmdWork(sCMD_Deivce, Environment.CurrentDirectory, false); // adb device
            //若未安裝ADB Tool
            if (sDevices_check.Contains("不是內部或外部命令、可執行的程式或批次檔。"))
            {

                Form2 testDialog = new Form2();
                testDialog.ShowDialog();
            }

            cmbDeviceList.Items.Clear(); // clear combobox 

            string[] lines = Regex.Split(sDevices_check, "\r\n"); // articles row
            List<string> slistAnswer = new List<string>();

            for (int i = 0; i < lines.Length; i++)
            {

                string[] sarryWord = Regex.Split(lines.ElementAt(i), "\t"); 
                if ((sarryWord.Length != 2))
                    continue;
                //Get Device number
                string sFirstWord = sarryWord[0].Trim();
                slistAnswer.Add(sFirstWord);
            }

                for (int i = 0; i < slistAnswer.Count; i++)
                {
                    cmbDeviceList.Items.Add(slistAnswer.ElementAt(i)); // add device bumber to combobox

                }
            //default selecte frist device
                if (cmbDeviceList.Items.Count > 0)
                    cmbDeviceList.SelectedIndex = 0;
        }

        //Take screenshot
        private void btnScreenshot_Click(object sender, EventArgs e)
        {
            
            String sDevices ;
            if (cmbDeviceList.SelectedItem == null) 
            {
                MessageBox.Show("請選擇裝置");
                sDevices = "";   
            }
            else {
                sDevices = cmbDeviceList.SelectedItem.ToString();
            }

            //Detected device
            if (sDevices != "") 
            {

                string sTmppath = System.IO.Path.GetTempPath();
                string sPullreply;
                string sCMD_screenshot = String.Format(@"adb -s {0} shell /system/bin/screencap -p /sdcard/screenshot.png", sDevices); 
                string sCMD_pull = String.Format(@"adb -s {0} pull /sdcard/screenshot.png {1}", sDevices, sTmppath.TrimEnd('\\'));
          

                ConsoleHelper console = new ConsoleHelper();
                //screenshot
                console.DoCmdWork(sCMD_screenshot, Environment.CurrentDirectory, false);

                //pull to Windows tmpfolder
                sPullreply = console.DoCmdWork(sCMD_pull, Environment.CurrentDirectory, false);

                //為True檔案不存在
                Boolean bIspulled = sPullreply.Contains("does not exist");

                if (bIspulled)
                {
                    MessageBox.Show("請重新連結您的裝置");
                }

                //getImage from Windows tmpfolder
                System.Drawing.Image imgtmp = System.Drawing.Image.FromFile(sTmppath + "screenshot.png");
                System.Drawing.Image img = null;

                //Analyzing direction
                string sOrientation = GetDeviceProperty_SurfaceOrientation(sDevices); // 手機頂部 朝上:0 朝左:1 朝下:2 朝右:3

                if (sOrientation == "0" || sOrientation == "1")
                {
                    //resize Image
                    img = ImageResize(imgtmp, Direction.Vertical);
                    ptbPhotoPreview.Padding = new Padding(120, 0, 0, 0);//設定垂直圖片在picturebox的位置
                }
                else
                {
                    img = ImageResize(imgtmp, Direction.Horizontal);
                    ptbPhotoPreview.Padding = new Padding(0, 150, 0, 0);//設定水平圖片在picturebox的位置
                }

                //Get Device Property
                Dictionary<string, string> dicGetprop = GetDeviceProperty(sDevices);
                //Get SDK version
                //int sSdkver = 0;
                //int.TryParse(dicGetprop["ro.build.version.sdk"].ToString(), out sSdkver);
                int sSdkver = int.Parse(dicGetprop["ro.build.version.sdk"].ToString());

                if (sSdkver < 23)
                {

                    // 手機頂部 朝上:0 朝左:1 朝下:2 朝右:3
                    switch (sOrientation)
                    {
                        case "0":
                            break;
                        case "1":
                            img.RotateFlip(RotateFlipType.Rotate270FlipNone);//轉270度
                            break;
                        case "2":
                            img.RotateFlip(RotateFlipType.Rotate180FlipNone);//轉180度
                            break;
                        case "3":
                            img.RotateFlip(RotateFlipType.Rotate90FlipNone);//轉90度
                            break;

                        default:
                            break;

                    }
                }
                //放到剪貼簿及picturebox
                Clipboard.SetImage(img);
                ptbPhotoPreview.Image = img;

                imgtmp.Dispose();//設放imgtmp
            }
            

        }

        //Image Resize
        private Image ImageResize(Image in_img, Direction in_direction) 
        {
            if (in_direction == Direction.Vertical)
            {
                //計算圖片比例
                double dWidth_scale = (360f / in_img.Width);
                double dHeight_scale = (600f / in_img.Height);
                double iHeight = in_img.Height * dHeight_scale;
                double iWeight = in_img.Width * dWidth_scale;
                //設定成360*600
                Bitmap imageResize = new Bitmap(in_img, (int)iWeight, (int)iHeight);
                return imageResize;
            }else 
            {
                double dWidth_scale = (600f / in_img.Width);
                double dHeight_scale = (360f / in_img.Height);
                double iHeight = in_img.Height * dHeight_scale;
                double iWeight = in_img.Width * dWidth_scale;
                //設定成600*360
                Bitmap imageResize = new Bitmap(in_img, (int)iWeight, (int)iHeight);
                return imageResize;


            }
       
        }


        
        private string GetDeviceProperty_SurfaceOrientation(String sDevice)
        {
            //System.IO.Path.Combine(GLB_pg7settings.sPC_Application_TempFolderPath, "dumpsys.txt");
            string sDumpsysFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "dumpsys.txt");
            string sCommand = String.Format(@"adb -s {0} shell dumpsys input > {1}",sDevice, sDumpsysFilePath);

            ConsoleHelper console = new ConsoleHelper();
            string sDevices_check = console.DoCmdWork(sCommand, Environment.CurrentDirectory, false);//get Devices prop

            string[] sarrysDumpsys = File.ReadAllLines(sDumpsysFilePath);
            string sTargetLine = "";

            //Analyzing prop
            foreach (string EachLine in sarrysDumpsys)
            {
                
                if (EachLine.Contains("orientation=")) 
                {
                    string[] sEachWord = null;
                    for (int i = 0; i < EachLine.Length; i++) {
                        sEachWord = EachLine.Split(',');
                    }
                    //get Device orientation
                    sTargetLine = sEachWord.ElementAt(1).Replace("orientation=", ""); 
                    return sTargetLine.Trim();
                }
            }
            return "";
        }

        private Dictionary<string, string> GetDeviceProperty(String sDevice)
        {
            Dictionary<string, string> dictNew = new Dictionary<string, string>();
            string sGetpropFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "getprop.txt");
            string sCommand = String.Format(@"adb -s {0} shell getprop > {1}", sDevice, sGetpropFilePath);
            ConsoleHelper console = new ConsoleHelper();
            string sDevices_check = console.DoCmdWork(sCommand, Environment.CurrentDirectory, false);//get Devices prop

            string[] sarrysGetprop = File.ReadAllLines(sGetpropFilePath);
            string sAnswer = "";
            foreach (string EachLine in sarrysGetprop)
            {
                if (EachLine.Contains("[ro.build.version.release]:"))
                {
                    sAnswer = EachLine.Replace("[ro.build.version.release]:", "").Trim();
                    sAnswer = sAnswer.Replace("[", "").Replace("]", "");
                    dictNew.Add("ro.build.version.release", sAnswer);
                }
                else if (EachLine.Contains("[ro.build.version.sdk]:"))
                {
                    sAnswer = EachLine.Replace("[ro.build.version.sdk]:", "").Trim();
                    sAnswer = sAnswer.Replace("[", "").Replace("]", "");
                    dictNew.Add("ro.build.version.sdk", sAnswer);
                }
                else if (EachLine.Contains("[dhcp.wlan0.ipaddress]:"))
                {
                    sAnswer = EachLine.Replace("[dhcp.wlan0.ipaddress]:", "").Trim();
                    sAnswer = sAnswer.Replace("[", "").Replace("]", "");
                    dictNew.Add("dhcp.wlan0.ipaddress", sAnswer);
                }



            }

            return dictNew;
        }


        //按下打開ComboBox Device reload
        private void ReloadDevice_DropDown(object sender, EventArgs e)
        {
            //record selected Device
            string sNowSelectDevice = "";
            if (cmbDeviceList.SelectedItem != null)
                sNowSelectDevice = cmbDeviceList.SelectedItem.ToString();

            ConsoleHelper console = new ConsoleHelper();
            string sDevices_check = console.DoCmdWork("adb devices", Environment.CurrentDirectory, false);//Detected Device

            cmbDeviceList.Items.Clear(); // Clear comboobx

            string[] lines = Regex.Split(sDevices_check, "\r\n");
            List<string> slistAnswer = new List<string>();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] sarryWord = Regex.Split(lines.ElementAt(i), "\t");
                if ((sarryWord.Length != 2))
                    continue;
                //Get Device number
                string sFirstWord = sarryWord[0].Trim();
                slistAnswer.Add(sFirstWord);
            }

            if (slistAnswer.Count != 0)
            {
                for (int i = 0; i < slistAnswer.Count; i++)
                {
                    cmbDeviceList.Items.Add(slistAnswer.ElementAt(i));

                    //如果沒有選擇,設為先前選擇的Deivce
                    if (cmbDeviceList.Items[i].ToString() == sNowSelectDevice)
                        cmbDeviceList.SelectedIndex = i;

                }
                label1.Text = "";
            }
            else
            {

                MessageBox.Show("請重新連結您的裝置");
            }
        
        }

        //Registet hotkey
        private void Form_Activated(object sender, EventArgs e)
        {
            //Registet hotkey Ctrl+B 
             HotKey.RegisterHotKey(Handle, 101, HotKey.KeyModifiers.Ctrl, Keys.B); 
        }

        //Receive Windows Message
        protected override void WndProc(ref Message m) 
        { 
             const int WM_HOTKEY = 0x0312; 
             switch (m.Msg) 
             { 
                 case WM_HOTKEY: 
                     switch (m.WParam.ToInt32()) 
                     { 
                         case 101:    //Ctrl+B
                             btnScreenshot.PerformClick();
                             break; 
                     } 
                     break; 
            } 
  
             base.WndProc(ref m);
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //開啟瀏覽器
            System.Diagnostics.Process.Start("http://www.caketech.com.tw/");
        }

      
    }
}
