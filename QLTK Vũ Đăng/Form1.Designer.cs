using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace QLTK_Vũ_Đăng
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
		private Label lbRAM;

        // Token: 0x04000090 RID: 144
        private Label lbCPU;

        // Token: 0x04000091 RID: 145
        private PerformanceCounter pRAM;

        // Token: 0x04000092 RID: 146
        private PerformanceCounter pCPU;
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
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.panelDestkop = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnCloseApp = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnGunaMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panelMenu = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.lbRAM = new System.Windows.Forms.Label();
            this.btnInfo = new Guna.UI2.WinForms.Guna2Button();
            this.lbCPU = new System.Windows.Forms.Label();
            this.btnTutorial = new Guna.UI2.WinForms.Guna2Button();
            this.btnControlUp = new Guna.UI2.WinForms.Guna2Button();
            this.btnControlGame = new Guna.UI2.WinForms.Guna2Button();
            this.btnDashboard = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pRAM = new System.Diagnostics.PerformanceCounter();
            this.pCPU = new System.Diagnostics.PerformanceCounter();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pRAM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCPU)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 25;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2AnimateWindow1
            // 
            this.guna2AnimateWindow1.TargetForm = this;
            // 
            // panelDestkop
            // 
            this.panelDestkop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.panelDestkop.Location = new System.Drawing.Point(149, 36);
            this.panelDestkop.Name = "panelDestkop";
            this.panelDestkop.Size = new System.Drawing.Size(785, 445);
            this.panelDestkop.TabIndex = 0;
            // 
            // btnCloseApp
            // 
            this.btnCloseApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseApp.Animated = true;
            this.btnCloseApp.BorderRadius = 12;
            this.btnCloseApp.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCloseApp.IconColor = System.Drawing.Color.White;
            this.btnCloseApp.Location = new System.Drawing.Point(878, 3);
            this.btnCloseApp.Name = "btnCloseApp";
            this.btnCloseApp.Size = new System.Drawing.Size(45, 29);
            this.btnCloseApp.TabIndex = 3;
            this.btnCloseApp.Click += new System.EventHandler(this.btnCloseApp_Click);
            // 
            // btnGunaMinimize
            // 
            this.btnGunaMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGunaMinimize.Animated = true;
            this.btnGunaMinimize.BorderRadius = 12;
            this.btnGunaMinimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.btnGunaMinimize.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGunaMinimize.IconColor = System.Drawing.Color.White;
            this.btnGunaMinimize.Location = new System.Drawing.Point(827, 3);
            this.btnGunaMinimize.Name = "btnGunaMinimize";
            this.btnGunaMinimize.Size = new System.Drawing.Size(45, 29);
            this.btnGunaMinimize.TabIndex = 4;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Enabled = false;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(12, 6);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(284, 26);
            this.guna2HtmlLabel1.TabIndex = 5;
            this.guna2HtmlLabel1.Text = "A C C O U N T M A N A G E R ";
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.guna2Button1);
            this.panelMenu.Controls.Add(this.lbRAM);
            this.panelMenu.Controls.Add(this.btnInfo);
            this.panelMenu.Controls.Add(this.lbCPU);
            this.panelMenu.Controls.Add(this.btnTutorial);
            this.panelMenu.Controls.Add(this.btnControlUp);
            this.panelMenu.Controls.Add(this.btnControlGame);
            this.panelMenu.Controls.Add(this.btnDashboard);
            this.panelMenu.Location = new System.Drawing.Point(-1, 36);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(152, 570);
            this.panelMenu.TabIndex = 0;
            // 
            // guna2Button1
            // 
            this.guna2Button1.Animated = true;
            this.guna2Button1.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.BorderColor = System.Drawing.Color.Red;
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.Silver;
            this.guna2Button1.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.guna2Button1.Location = new System.Drawing.Point(0, 284);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(152, 45);
            this.guna2Button1.TabIndex = 28;
            this.guna2Button1.Text = "List Server IP";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // lbRAM
            // 
            this.lbRAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRAM.ForeColor = System.Drawing.Color.White;
            this.lbRAM.Location = new System.Drawing.Point(10, 44);
            this.lbRAM.Name = "lbRAM";
            this.lbRAM.Size = new System.Drawing.Size(121, 25);
            this.lbRAM.TabIndex = 27;
            this.lbRAM.Text = "RAM :";
            // 
            // btnInfo
            // 
            this.btnInfo.Animated = true;
            this.btnInfo.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnInfo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInfo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInfo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInfo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInfo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnInfo.ForeColor = System.Drawing.Color.White;
            this.btnInfo.HoverState.BorderColor = System.Drawing.Color.Red;
            this.btnInfo.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnInfo.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnInfo.Location = new System.Drawing.Point(0, 332);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(152, 45);
            this.btnInfo.TabIndex = 4;
            this.btnInfo.Text = "Infomation";
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // lbCPU
            // 
            this.lbCPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCPU.ForeColor = System.Drawing.Color.White;
            this.lbCPU.Location = new System.Drawing.Point(10, 9);
            this.lbCPU.Name = "lbCPU";
            this.lbCPU.Size = new System.Drawing.Size(121, 25);
            this.lbCPU.TabIndex = 0;
            this.lbCPU.Text = "CPU :";
            // 
            // btnTutorial
            // 
            this.btnTutorial.Animated = true;
            this.btnTutorial.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTutorial.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTutorial.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTutorial.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTutorial.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTutorial.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTutorial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTutorial.ForeColor = System.Drawing.Color.White;
            this.btnTutorial.HoverState.BorderColor = System.Drawing.Color.Red;
            this.btnTutorial.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnTutorial.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnTutorial.Location = new System.Drawing.Point(0, 236);
            this.btnTutorial.Name = "btnTutorial";
            this.btnTutorial.Size = new System.Drawing.Size(152, 45);
            this.btnTutorial.TabIndex = 3;
            this.btnTutorial.Text = "Tutorial";
            this.btnTutorial.Click += new System.EventHandler(this.btnTutorial_Click);
            // 
            // btnControlUp
            // 
            this.btnControlUp.Animated = true;
            this.btnControlUp.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnControlUp.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnControlUp.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnControlUp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnControlUp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnControlUp.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnControlUp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnControlUp.ForeColor = System.Drawing.Color.White;
            this.btnControlUp.HoverState.BorderColor = System.Drawing.Color.Red;
            this.btnControlUp.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnControlUp.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnControlUp.Location = new System.Drawing.Point(0, 188);
            this.btnControlUp.Name = "btnControlUp";
            this.btnControlUp.Size = new System.Drawing.Size(152, 45);
            this.btnControlUp.TabIndex = 2;
            this.btnControlUp.Text = "Control Account Up";
            this.btnControlUp.Click += new System.EventHandler(this.btnControlUp_Click);
            // 
            // btnControlGame
            // 
            this.btnControlGame.Animated = true;
            this.btnControlGame.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnControlGame.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnControlGame.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnControlGame.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnControlGame.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnControlGame.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnControlGame.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnControlGame.ForeColor = System.Drawing.Color.White;
            this.btnControlGame.HoverState.BorderColor = System.Drawing.Color.Red;
            this.btnControlGame.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnControlGame.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnControlGame.Location = new System.Drawing.Point(0, 140);
            this.btnControlGame.Name = "btnControlGame";
            this.btnControlGame.Size = new System.Drawing.Size(152, 45);
            this.btnControlGame.TabIndex = 1;
            this.btnControlGame.Text = "Control Game";
            this.btnControlGame.Click += new System.EventHandler(this.btnControlGame_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Animated = true;
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDashboard.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnDashboard.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDashboard.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDashboard.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDashboard.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDashboard.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDashboard.FocusedColor = System.Drawing.Color.Gray;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.HoverState.BorderColor = System.Drawing.Color.Red;
            this.btnDashboard.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnDashboard.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDashboard.Location = new System.Drawing.Point(-3, 92);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(155, 43);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(302, 6);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(3, 2);
            this.guna2HtmlLabel2.TabIndex = 6;
            this.guna2HtmlLabel2.Text = null;
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Enabled = false;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(302, 6);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(138, 26);
            this.guna2HtmlLabel3.TabIndex = 7;
            this.guna2HtmlLabel3.Text = "l BY VŨ ĐĂNG";
            // 
            // pRAM
            // 
            this.pRAM.CategoryName = "Memory";
            this.pRAM.CounterName = "% Committed Bytes In Use";
            // 
            // pCPU
            // 
            this.pCPU.CategoryName = "Processor";
            this.pCPU.CounterName = "% Processor Time";
            this.pCPU.InstanceName = "_Total";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(935, 481);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.panelDestkop);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.btnGunaMinimize);
            this.Controls.Add(this.btnCloseApp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QLTK By Vũ Đăng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pRAM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCPU)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2GradientPanel panelDestkop;
        private Guna.UI2.WinForms.Guna2ControlBox btnCloseApp;
        private Guna.UI2.WinForms.Guna2ControlBox btnGunaMinimize;
        private Guna.UI2.WinForms.Guna2Panel panelMenu;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2Button btnInfo;
        private Guna.UI2.WinForms.Guna2Button btnTutorial;
        private Guna.UI2.WinForms.Guna2Button btnControlUp;
        private Guna.UI2.WinForms.Guna2Button btnControlGame;
        private Guna.UI2.WinForms.Guna2Button btnDashboard;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}

