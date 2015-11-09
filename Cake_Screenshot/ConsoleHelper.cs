using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace Cake_Screenshot
{
    public class ConsoleHelper
    {
        public ConsoleHelper()
        {
        }
        public virtual String DoCmdWork(List<String> sListCMD, String strWorkingDir,bool blVisible)
        {
            try
            {
                string sRTN_Screen_Message = "";
                System.Diagnostics.Process newProcess = new System.Diagnostics.Process();
                newProcess.StartInfo = new ProcessStartInfo("cmd.exe");
                newProcess.StartInfo.WorkingDirectory = strWorkingDir;
                newProcess.StartInfo.UseShellExecute = false;
                newProcess.StartInfo.RedirectStandardInput = true;
                newProcess.StartInfo.RedirectStandardOutput = true;
                newProcess.StartInfo.RedirectStandardError = true;
                newProcess.StartInfo.StandardOutputEncoding = Encoding.Default;
                newProcess.StartInfo.StandardErrorEncoding = Encoding.Default;
                if (blVisible==false)
                {
                    newProcess.StartInfo.CreateNoWindow = true;
                    newProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                }

                for (int i = 0; i < sListCMD.Count; i++)
                {
                    newProcess.Start();
                    newProcess.StandardInput.WriteLine(sListCMD[i]);
                    newProcess.StandardInput.Flush();
                    newProcess.StandardInput.Close();                                  
                    
                    //正常Log輸出到螢幕
                    sRTN_Screen_Message += newProcess.StandardOutput.ReadToEnd();
                    //發生錯誤之Log輸出到螢幕
                    sRTN_Screen_Message += newProcess.StandardError.ReadToEnd();
                    newProcess.Close();
                }
                return sRTN_Screen_Message;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public virtual String DoCmdWork(String strInput, String strWorkingDir, bool blVisible)
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new ProcessStartInfo("cmd.exe");
                p.StartInfo.WorkingDirectory = strWorkingDir;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                if (blVisible == false)
                {
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                }

                p.Start();
                StreamWriter swInput = p.StandardInput;
                StreamReader srOutput = p.StandardOutput;
                StreamReader srError = p.StandardError;
                swInput.AutoFlush = true;

                swInput.Write(strInput + System.Environment.NewLine);

                swInput.Write("exit" + System.Environment.NewLine);
                string strResponse = srOutput.ReadToEnd() + System.Environment.NewLine + srError.ReadToEnd();
                swInput.Close();
                srOutput.Close();
                srError.Close();

                p.Close();
                return strResponse;
            }
            catch (Exception ex)
            {
                string sMessage = "ERROR,"+ex.Message;
                return sMessage;
            }
        }
        public virtual void DoCmdWork_without_output(String strInput, String strWorkingDir, bool blVisible)
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new ProcessStartInfo("cmd.exe");
                p.StartInfo.WorkingDirectory = strWorkingDir;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                //p.StartInfo.RedirectStandardOutput = true;
                //p.StartInfo.RedirectStandardError = true;
                if (blVisible == false)
                {
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                }

                p.Start();
                StreamWriter swInput = p.StandardInput;
                //StreamReader srOutput = p.StandardOutput;
                //StreamReader srError = p.StandardError;
                swInput.AutoFlush = true;

                swInput.Write(strInput + System.Environment.NewLine);

                swInput.Write("exit" + System.Environment.NewLine);
                //string strResponse = srOutput.ReadToEnd() + System.Environment.NewLine + srError.ReadToEnd();
                swInput.Close();
                //srOutput.Close();
                //srError.Close();

                p.Close();
                //return strResponse;
            }
            catch (Exception ex)
            {                
                //return null;
                throw ex;
            }
        }        
        public virtual bool DoWork(String aExecutable, String aArguments, String aWorkingDir, bool bSync, bool bVisible)
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo(aExecutable, aArguments);
                if (aWorkingDir != null && aWorkingDir.Length > 0)
                {
                    info.WorkingDirectory = aWorkingDir;
                }
                if (!bVisible)
                {
                    info.CreateNoWindow = true;
                    info.WindowStyle = ProcessWindowStyle.Hidden;
                }

                Process p = new Process();
                p.StartInfo = info;
                p.Start();

                if (!bSync)
                {
                    return true;
                }

                //Timeout value
                int nTimeOut = 1000 * 60 * 30;

                //Wait for the process to end
                bool bExit = p.WaitForExit(nTimeOut);

                if (bExit)
                {
                    return true;
                }
                else
                {
                    p.Kill();
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public virtual int DoWork_WithoutOutput(String aExecutable, String aArguments, String aWorkingDir, bool bSync, bool bVisible)
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo(aExecutable, aArguments);
                if (aWorkingDir != null && aWorkingDir.Length > 0)
                {
                    info.WorkingDirectory = aWorkingDir;
                }
                if (!bVisible)
                {
                    info.CreateNoWindow = true;
                    info.WindowStyle = ProcessWindowStyle.Hidden;
                }

                Process p = new Process();
                p.StartInfo = info;
                p.Start();

                //if (!bSync)
                //{
                //    return p.Id;
                //}
                return p.Id;
                ////Timeout value
                //int nTimeOut = 1000 * 60 * 30;

                ////Wait for the process to end
                //bool bExit = p.WaitForExit(nTimeOut);

                //if (bExit)
                //{
                //    return true;
                //}
                //else
                //{
                //    p.Kill();
                //    return false;
                //}
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public int ExecuteBAT(string in_BAT_Location, string command, string in_WorkingDirectory)
        {
            //int ExitCode;
            ProcessStartInfo ProcessInfo;
            Process process;

            ProcessInfo = new ProcessStartInfo(in_BAT_Location, command);
            ProcessInfo.CreateNoWindow = false;
            ProcessInfo.WindowStyle = ProcessWindowStyle.Normal;
            ProcessInfo.UseShellExecute = false;
            ProcessInfo.WorkingDirectory = in_WorkingDirectory;// @"C:\Users\Administrator\Desktop";
            // *** Redirect the output ***
            //ProcessInfo.RedirectStandardError = true;
            ProcessInfo.RedirectStandardOutput = true;

            process = Process.Start(ProcessInfo);
            //process.WaitForExit();
            return process.Id;
            // *** Read the streams ***
            //string output = process.StandardOutput.ReadToEnd();
            //string error = process.StandardError.ReadToEnd();

            //ExitCode = process.ExitCode;

            //MessageBox.Show("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            //MessageBox.Show("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            //MessageBox.Show("ExitCode: " + ExitCode.ToString(), "ExecuteCommand");
            //process.Close();
        }
        //=========== CODE SAMPLE
        //private string UnZip(string strZIP)
        //{
        //    string strTempFolder = Path.Combine(Path.GetTempPath(), CSystem.BaseClass.GetTimeStamp());
        //    if (!Directory.Exists(strTempFolder))
        //    {
        //        Directory.CreateDirectory(strTempFolder);
        //    }
        //    String str7zPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Bin" + Path.DirectorySeparatorChar + "7z.exe";
        //    ConsoleHelper helper = new ConsoleHelper();
        //    String strArgument = String.Format("x -o\"{0}\" \"{1}\" -y ", strTempFolder, strZIP);
        //    helper.DoWork(str7zPath, strArgument, strTempFolder, true, false);
        //    strTempFolder = Path.Combine(strTempFolder, "User_Data");
        //    return strTempFolder;
        //}
    }
}