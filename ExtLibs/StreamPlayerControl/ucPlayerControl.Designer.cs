using System.Diagnostics;

namespace Player
{
    partial class ucPlayerControl
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
                foreach (var process in Process.GetProcessesByName("ffmpeg"))
                {
                    process.Kill();
                }
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.popupmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startRecordingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopRecordingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.statuslabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.playmenu = new System.Windows.Forms.ToolStrip();
            this.tsbReconnect = new System.Windows.Forms.ToolStripButton();
            this.tsbPlay = new System.Windows.Forms.ToolStripButton();
            this.tsbStop = new System.Windows.Forms.ToolStripButton();
            this.tsbRecording = new System.Windows.Forms.ToolStripButton();
            this.tsbRate = new System.Windows.Forms.ToolStripComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.streamPlayerControl1 = new StreamPlayerControl();
            this.blink_timer = new System.Windows.Forms.Timer(this.components);
            this.popupmenu.SuspendLayout();
            this.status.SuspendLayout();
            this.playmenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // popupmenu
            // 
            this.popupmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startRecordingToolStripMenuItem,
            this.stopRecordingToolStripMenuItem,
            this.reconnectToolStripMenuItem});
            this.popupmenu.Name = "popupmenu";
            this.popupmenu.Size = new System.Drawing.Size(153, 70);
            // 
            // startRecordingToolStripMenuItem
            // 
            this.startRecordingToolStripMenuItem.Name = "startRecordingToolStripMenuItem";
            this.startRecordingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startRecordingToolStripMenuItem.Text = "Start recording";
            // 
            // stopRecordingToolStripMenuItem
            // 
            this.stopRecordingToolStripMenuItem.Name = "stopRecordingToolStripMenuItem";
            this.stopRecordingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.stopRecordingToolStripMenuItem.Text = "Stop recording";
            // 
            // reconnectToolStripMenuItem
            // 
            this.reconnectToolStripMenuItem.Name = "reconnectToolStripMenuItem";
            this.reconnectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.reconnectToolStripMenuItem.Text = "Reconnect";
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statuslabel});
            this.status.Location = new System.Drawing.Point(0, 278);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(483, 22);
            this.status.TabIndex = 1;
            this.status.Text = "statusStrip1";
            // 
            // statuslabel
            // 
            this.statuslabel.BackColor = System.Drawing.SystemColors.Menu;
            this.statuslabel.Name = "statuslabel";
            this.statuslabel.Size = new System.Drawing.Size(48, 17);
            this.statuslabel.Text = "Status...";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // playmenu
            // 
            this.playmenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.playmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbReconnect,
            this.tsbPlay,
            this.tsbStop,
            this.tsbRecording,
            this.tsbRate});
            this.playmenu.Location = new System.Drawing.Point(0, 253);
            this.playmenu.Name = "playmenu";
            this.playmenu.Size = new System.Drawing.Size(483, 25);
            this.playmenu.TabIndex = 4;
            this.playmenu.Text = "toolStrip1";
            // 
            // tsbReconnect
            // 
            this.tsbReconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbReconnect.Image = global::Player.Properties.Resources.refresh_512;
            this.tsbReconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReconnect.Name = "tsbReconnect";
            this.tsbReconnect.Size = new System.Drawing.Size(23, 22);
            this.tsbReconnect.Text = "toolStripButton5";
            this.tsbReconnect.ToolTipText = "Reconnect";
            this.tsbReconnect.Click += new System.EventHandler(this.tsbReconnect_Click);
            // 
            // tsbPlay
            // 
            this.tsbPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPlay.Image = global::Player.Properties.Resources.play_512;
            this.tsbPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPlay.Name = "tsbPlay";
            this.tsbPlay.Size = new System.Drawing.Size(23, 22);
            this.tsbPlay.Text = "tsbPlay";
            this.tsbPlay.ToolTipText = "Play";
            this.tsbPlay.Click += new System.EventHandler(this.tsbPlay_Click);
            // 
            // tsbStop
            // 
            this.tsbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStop.Image = global::Player.Properties.Resources.stop_512;
            this.tsbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStop.Name = "tsbStop";
            this.tsbStop.Size = new System.Drawing.Size(23, 22);
            this.tsbStop.Text = "tsbStop";
            this.tsbStop.ToolTipText = "Stop";
            this.tsbStop.Click += new System.EventHandler(this.tsbStop_Click);
            // 
            // tsbRecording
            // 
            this.tsbRecording.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbRecording.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRecording.Image = global::Player.Properties.Resources.record_512;
            this.tsbRecording.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRecording.Name = "tsbRecording";
            this.tsbRecording.Size = new System.Drawing.Size(23, 22);
            this.tsbRecording.ToolTipText = "Start / Stop Recording";
            this.tsbRecording.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // tsbRate
            // 
            this.tsbRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsbRate.Items.AddRange(new object[] {
            "Original ratio",
            "16:9",
            "Stretch"});
            this.tsbRate.Name = "tsbRate";
            this.tsbRate.Size = new System.Drawing.Size(121, 25);
            this.tsbRate.ToolTipText = "Video rate";
            this.tsbRate.SelectedIndexChanged += new System.EventHandler(this.tsbRate_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.streamPlayerControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(483, 253);
            this.panel1.TabIndex = 5;
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // streamPlayerControl1
            // 
            this.streamPlayerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.streamPlayerControl1.ContextMenuStrip = this.popupmenu;
            this.streamPlayerControl1.Location = new System.Drawing.Point(0, 1);
            this.streamPlayerControl1.Name = "streamPlayerControl1";
            this.streamPlayerControl1.Size = new System.Drawing.Size(483, 250);
            this.streamPlayerControl1.TabIndex = 6;
            // 
            // blink_timer
            // 
            this.blink_timer.Interval = 1000;
            this.blink_timer.Tick += new System.EventHandler(this.blink_timer_Tick);
            // 
            // ucPlayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.playmenu);
            this.Controls.Add(this.status);
            this.Name = "ucPlayerControl";
            this.Size = new System.Drawing.Size(483, 300);
            this.popupmenu.ResumeLayout(false);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.playmenu.ResumeLayout(false);
            this.playmenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip popupmenu;
        private System.Windows.Forms.ToolStripMenuItem startRecordingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopRecordingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reconnectToolStripMenuItem;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel statuslabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStrip playmenu;
        private System.Windows.Forms.ToolStripButton tsbPlay;
        private System.Windows.Forms.ToolStripButton tsbStop;
        private System.Windows.Forms.ToolStripButton tsbRecording;
        private System.Windows.Forms.ToolStripButton tsbReconnect;
        private System.Windows.Forms.Panel panel1;
        private StreamPlayerControl streamPlayerControl1;
        private System.Windows.Forms.ToolStripComboBox tsbRate;
        private System.Windows.Forms.Timer blink_timer;
    }
}
