using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Player
{
    public partial class ucPlayerControl : UserControl
    {
        string url_string = "";
        bool reconnect = false;
        bool recording = false;
        string ffmpeg_path = "";
        string ffmpeg_params = "";
        string record_path = "";        
        ratelist videorate = new ratelist();       
        
        public Process proc = new Process();

        public ucPlayerControl()
        {
            InitializeComponent();
            videorate = ratelist.OriginalRate;
            streamPlayerControl1.StreamFailed += StreamPlayerControl1_StreamFailed;
            streamPlayerControl1.StreamStopped += StreamPlayerControl1_StreamStopped;
            tsbRate.SelectedIndex = 0;

            foreach (var process in Process.GetProcessesByName("ffmpeg"))
            {
                process.Kill();
            }
        }
        
        /// <summary>
        /// Try to auto reconnet to source
        /// </summary>
        public bool AutoRecconect { get { return reconnect; } set { reconnect = value; } }
        /// <summary>
        /// File save path
        /// </summary>
        public string RecordPath { get { return record_path; } set { record_path = value; } }
        /// <summary>
        /// ffmpeg full path (with ffmpeg.exe)
        /// </summary>
        public string ffmegPath { get { return ffmpeg_path; } set { ffmpeg_path = value; } }
        /// <summary>
        /// ffmpeg full paramether path (file name doesn't working than)
        /// </summary>
        public string ffmegParams { get { return ffmpeg_params; } set { ffmpeg_params = value; } }

        public bool VisibleStatus { get { return status.Visible; } set { status.Visible = value; } }
        public bool VisiblePlayerMenu{ get { return playmenu.Visible; } set { playmenu.Visible = value; } }

        private void StreamPlayerControl1_StreamStopped(object sender, EventArgs e)
        {
            if (reconnect) { this.Play(); statuslabel.Text = "Reconnecting..."; }
            else statuslabel.Text = "Stopped";
        }

        private void StreamPlayerControl1_StreamFailed(object sender, StreamFailedEventArgs e)
        {
            statuslabel.Text = "Filed: "+ e.Error;
        }

        public enum ratelist {
            OriginalRate = 0,
            WideScreen =1,
            StretchToScreen =2
        };

        public ratelist VideoRate
        {
            get { return videorate; }
            set { videorate = value; }
        }

        /// <summary>
        /// Source
        /// </summary>
        public string MediaUrl
        {
            get { return url_string; }
            set { url_string = value;
            }
        }

        private bool IsRTSP()
        {
            bool retBool = false;

            Uri url_media = new Uri(url_string);
            if (url_media.Scheme.ToUpper() == "RTSP")
            {
                retBool = true;
            }


            return retBool;
        }

        /// <summary>
        /// Is recording
        /// </summary>
        public bool IsRecording
        {
            get { return recording; }
        }

        /// <summary>
        /// Play
        /// </summary>
        public void Play()
        {
           
            streamPlayerControl1.StartPlay(new Uri (url_string));
            statuslabel.Text = "Connect";
            streamPlayerControl1.StreamStarted += StreamPlayerControl1_StreamStarted;           
            timer1.Enabled = true;
        }

        private void StreamPlayerControl1_StreamStarted(object sender, EventArgs e)
        {
            //if it need
            videorate = (ratelist)tsbRate.SelectedIndex;
            panel1_Resize(this, null);
        }

        public Bitmap MakeSnapshot()
        {
            statuslabel.Text = "Snapshot";

            return streamPlayerControl1.GetCurrentFrame();
        }

        /// <summary>
        /// Stop playing
        /// </summary>
        public void Stop()
        {
            streamPlayerControl1.Stop();
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (streamPlayerControl1.IsPlaying) statuslabel.Text = "Playing";
            else { if (reconnect) { this.Play(); statuslabel.Text = "Reconnecting..."; } }
            if (recording) statuslabel.Text = "Recording";
        }
        
        
        /// <summary>
        /// Start recoding
        /// </summary>
        public void StartRecording()
        {

            string rtsp_param = IsRTSP() ? " -rtsp_transport tcp" : "";
            if (ffmpeg_params == "")
            {
                ffmpeg_params = rtsp_param + " -i " + url_string + " -f segment -segment_time 10 -segment_format mp4 -reset_timestamps 1 -c copy -map 0 -strftime 1 " + record_path + "rec_%Y%m%d_%H%M%S.mp4 ";
            }

            foreach (var process in Process.GetProcessesByName("ffmpeg"))
            {
                process.Kill();
            }
            proc.StartInfo.FileName = ffmpeg_path == "" ? "ffmpeg" : ffmpeg_path + "\\ffmpeg.exe";
            proc.StartInfo.Arguments = ffmpeg_params;
            proc.StartInfo.RedirectStandardError = false;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            recording = true;
        }

        /// <summary>
        /// Start recording
        /// </summary>
        /// <param name="path">File destination path</param>
        public void StartRecording(string path)
        {

            string rtsp_param = IsRTSP() ? " -rtsp_transport tcp" : "";
            if (ffmpeg_params == "")
            {
                ffmpeg_params = rtsp_param + " -i " + url_string + " -c copy -map 0 -strftime 1 " + path  + "rec_%Y%m%d_%H%M%S.mp4 ";
            }

            foreach (var process in Process.GetProcessesByName("ffmpeg"))
            {
                process.Kill();
            }
            proc.StartInfo.FileName = ffmpeg_path == "" ? "ffmpeg" : ffmpeg_path + "\\ffmpeg.exe";
            proc.StartInfo.Arguments = ffmpeg_params;
            proc.StartInfo.RedirectStandardError = false;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            recording = true;
        }

        /// <summary>
        /// Start recording
        /// </summary>
        /// <param name="path">File destination path</param>
        /// <param name="prefix">File name</param>
        /// <param name="fragmented">Fragmented or one file</param>
        /// <param name="fragmenttime">Fragmentation time (sec)</param>
        /// <param name="filetype">File type string(mp4,avi,asf,mpg)</param>
        public void StartRecording(string path, string prefix, bool fragmented=true, int fragmenttime = 30, string filetype="mp4")
        {
            string param = "";

            string rtsp_param = IsRTSP() ? " -rtsp_transport tcp" : "";
            
            foreach (var process in Process.GetProcessesByName("ffmpeg"))
            {
                process.Kill();
            }
            proc.StartInfo.FileName = ffmpeg_path == "" ? "ffmpeg" : ffmpeg_path + "\\ffmpeg.exe";


            if (ffmpeg_params == "")
            {
                param = rtsp_param + " -i " + url_string;
            }

            if (fragmented)
            {
                param += " -f segment -segment_time "+ fragmenttime.ToString() + " -segment_format "+ filetype + " -reset_timestamps 1 ";
            }

            param += "-c copy -map 0 -strftime 1 " + path + "\\" + prefix + "_%Y%m%d_%H%M%S.mp4 ";


            if (ffmegParams=="") proc.StartInfo.Arguments = param; else proc.StartInfo.Arguments = ffmegParams;
            

            proc.StartInfo.RedirectStandardError = false;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            recording = true;
        }

        public void StopRecording()
        {

            try
            {
                StreamWriter sw = proc.StandardInput;
                sw.WriteLine("q");
                proc.Close();
                sw.Close();
            }
            catch { }
            
            //foreach (var process in Process.GetProcessesByName("ffmpeg"))
            //{
            //    process.Kill();
            //}
            recording = false;
        }

        private void tsbReconnect_Click(object sender, EventArgs e)
        {
            Stop();
            Play();
        }

      
        

        private void panel1_Resize(object sender, EventArgs e)
        {
            if (streamPlayerControl1.IsPlaying)
            {
                //Stop();

                Size orig_size = streamPlayerControl1.VideoSize;
                Size parent_size = panel1.Size;

                double orig_rate = 4.0/3.0;
                if (videorate == ratelist.OriginalRate)
                {
                    orig_rate = (double)orig_size.Width / (double)orig_size.Height;
                }
                else if (videorate == ratelist.WideScreen)
                {
                    orig_rate = 16.0 / 9.0;
                }
                else
                {
                    orig_rate = (double)parent_size.Width / (double)parent_size.Height;
                }

                double height_rate = (double)parent_size.Height / (double)orig_size.Height;
                double width_rate = (double)parent_size.Width / (double)orig_size.Width;


                if ((int)(orig_size.Width * width_rate / orig_rate) <= parent_size.Height)
                {
                    streamPlayerControl1.Width = (int)(orig_size.Width * width_rate);
                    streamPlayerControl1.Height = (int)(orig_size.Width * width_rate / orig_rate);

                }
                else if ((int)(orig_size.Height * height_rate / orig_rate) <= parent_size.Width)
                {
                    streamPlayerControl1.Height = (int)(orig_size.Height * height_rate);
                    streamPlayerControl1.Width = (int)(orig_size.Height * height_rate * orig_rate);
                }
                streamPlayerControl1.Left = (int)((panel1.Width - streamPlayerControl1.Width) / 2);
                streamPlayerControl1.Top = (int)((panel1.Height - streamPlayerControl1.Height) / 2);


                //Play();
            }
        }

        

        private void tsbRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            videorate = (ratelist)tsbRate.SelectedIndex;
            panel1_Resize(this, null);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (!recording) { StartRecording();
                //tsbRecording.Image = WebEye.Properties.Resources.media_pause_512;
                blink_timer.Enabled = true; }
            else { StopRecording(); tsbRecording.Image = Player.Properties.Resources.record_512; blink_timer.Enabled = false; }
        }

        private void tsbPlay_Click(object sender, EventArgs e)
        {
            Play();
        }
               

        private void tsbStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        bool tick = false;
        private void blink_timer_Tick(object sender, EventArgs e)
        {
            if (tick)
            { tsbRecording.Image = Player.Properties.Resources.record_5121; tick = false; }
            else { tsbRecording.Image = Player.Properties.Resources.record_512; tick = true; }
        }
    }
}
