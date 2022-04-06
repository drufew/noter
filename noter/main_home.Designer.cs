namespace noter
{
    partial class main_home
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
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_home));
            this.pnlSide = new System.Windows.Forms.Panel();
            this.pbExpand = new System.Windows.Forms.PictureBox();
            this.pbSearchAll = new System.Windows.Forms.PictureBox();
            this.lblSearchAll = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblSettings = new System.Windows.Forms.Label();
            this.pbSettings = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmMenuItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbMain = new System.Windows.Forms.TabControl();
            this.pbForward = new System.Windows.Forms.PictureBox();
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.pbMinimise = new System.Windows.Forms.PictureBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExpand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbForward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimise)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlSide.Controls.Add(this.pbExpand);
            this.pnlSide.Controls.Add(this.pbSearchAll);
            this.pnlSide.Controls.Add(this.lblSearchAll);
            this.pnlSide.Controls.Add(this.pictureBox1);
            this.pnlSide.Controls.Add(this.lblSettings);
            this.pnlSide.Controls.Add(this.pbSettings);
            this.pnlSide.Controls.Add(this.lblTitle);
            this.pnlSide.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlSide.Location = new System.Drawing.Point(-11, -7);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(223, 475);
            this.pnlSide.TabIndex = 0;
            // 
            // pbExpand
            // 
            this.pbExpand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbExpand.Image = ((System.Drawing.Image)(resources.GetObject("pbExpand.Image")));
            this.pbExpand.Location = new System.Drawing.Point(204, 438);
            this.pbExpand.Name = "pbExpand";
            this.pbExpand.Size = new System.Drawing.Size(16, 17);
            this.pbExpand.TabIndex = 1;
            this.pbExpand.TabStop = false;
            this.pbExpand.Click += new System.EventHandler(this.pbExpand_Click);
            this.pbExpand.MouseEnter += new System.EventHandler(this.pbExpand_MouseEnter);
            this.pbExpand.MouseLeave += new System.EventHandler(this.pbExpand_MouseLeave);
            // 
            // pbSearchAll
            // 
            this.pbSearchAll.Image = ((System.Drawing.Image)(resources.GetObject("pbSearchAll.Image")));
            this.pbSearchAll.Location = new System.Drawing.Point(23, 59);
            this.pbSearchAll.Name = "pbSearchAll";
            this.pbSearchAll.Size = new System.Drawing.Size(18, 17);
            this.pbSearchAll.TabIndex = 6;
            this.pbSearchAll.TabStop = false;
            // 
            // lblSearchAll
            // 
            this.lblSearchAll.AutoSize = true;
            this.lblSearchAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSearchAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSearchAll.Location = new System.Drawing.Point(42, 60);
            this.lblSearchAll.Name = "lblSearchAll";
            this.lblSearchAll.Size = new System.Drawing.Size(59, 15);
            this.lblSearchAll.TabIndex = 5;
            this.lblSearchAll.Text = "Search All";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 34);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // lblSettings
            // 
            this.lblSettings.AutoSize = true;
            this.lblSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSettings.Location = new System.Drawing.Point(42, 83);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(81, 15);
            this.lblSettings.TabIndex = 3;
            this.lblSettings.Text = "Configuration";
            this.lblSettings.Click += new System.EventHandler(this.lblSettings_Click);
            // 
            // pbSettings
            // 
            this.pbSettings.Image = ((System.Drawing.Image)(resources.GetObject("pbSettings.Image")));
            this.pbSettings.Location = new System.Drawing.Point(23, 82);
            this.pbSettings.Name = "pbSettings";
            this.pbSettings.Size = new System.Drawing.Size(18, 17);
            this.pbSettings.TabIndex = 2;
            this.pbSettings.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTitle.Location = new System.Drawing.Point(46, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(62, 25);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Noter";
            // 
            // cmMenuItems
            // 
            this.cmMenuItems.Name = "cmMenuItems";
            this.cmMenuItems.Size = new System.Drawing.Size(61, 4);
            // 
            // tbMain
            // 
            this.tbMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tbMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMain.ItemSize = new System.Drawing.Size(0, 1);
            this.tbMain.Location = new System.Drawing.Point(213, 31);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(835, 417);
            this.tbMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbMain.TabIndex = 2;
            // 
            // pbForward
            // 
            this.pbForward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbForward.Image = ((System.Drawing.Image)(resources.GetObject("pbForward.Image")));
            this.pbForward.Location = new System.Drawing.Point(243, 5);
            this.pbForward.Name = "pbForward";
            this.pbForward.Size = new System.Drawing.Size(19, 16);
            this.pbForward.TabIndex = 3;
            this.pbForward.TabStop = false;
            this.pbForward.MouseEnter += new System.EventHandler(this.pbForward_MouseEnter);
            this.pbForward.MouseLeave += new System.EventHandler(this.pbForward_MouseLeave);
            // 
            // pbBack
            // 
            this.pbBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBack.Image = ((System.Drawing.Image)(resources.GetObject("pbBack.Image")));
            this.pbBack.Location = new System.Drawing.Point(222, 5);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(19, 16);
            this.pbBack.TabIndex = 4;
            this.pbBack.TabStop = false;
            this.pbBack.MouseEnter += new System.EventHandler(this.pbBack_MouseEnter);
            this.pbBack.MouseLeave += new System.EventHandler(this.pbBack_MouseLeave);
            // 
            // pbClose
            // 
            this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClose.Image = ((System.Drawing.Image)(resources.GetObject("pbClose.Image")));
            this.pbClose.Location = new System.Drawing.Point(1015, 5);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(19, 16);
            this.pbClose.TabIndex = 5;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            this.pbClose.MouseEnter += new System.EventHandler(this.pbClose_MouseEnter);
            this.pbClose.MouseLeave += new System.EventHandler(this.pbClose_MouseLeave);
            // 
            // pbMinimise
            // 
            this.pbMinimise.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMinimise.Image = ((System.Drawing.Image)(resources.GetObject("pbMinimise.Image")));
            this.pbMinimise.Location = new System.Drawing.Point(996, 10);
            this.pbMinimise.Name = "pbMinimise";
            this.pbMinimise.Size = new System.Drawing.Size(19, 16);
            this.pbMinimise.TabIndex = 6;
            this.pbMinimise.TabStop = false;
            this.pbMinimise.Click += new System.EventHandler(this.pbMinimise_Click);
            this.pbMinimise.MouseEnter += new System.EventHandler(this.pbMinimise_MouseEnter);
            this.pbMinimise.MouseLeave += new System.EventHandler(this.pbMinimise_MouseLeave);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Tab 1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // main_home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 450);
            this.Controls.Add(this.pbMinimise);
            this.Controls.Add(this.pbClose);
            this.Controls.Add(this.pbBack);
            this.Controls.Add(this.pbForward);
            this.Controls.Add(this.tbMain);
            this.Controls.Add(this.pnlSide);
            this.Name = "main_home";
            this.Text = "main_home";
            this.Load += new System.EventHandler(this.main_home_Load);
            this.pnlSide.ResumeLayout(false);
            this.pnlSide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExpand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbForward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimise)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbSettings;
        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbSearchAll;
        private System.Windows.Forms.Label lblSearchAll;
        private System.Windows.Forms.PictureBox pbExpand;
        private System.Windows.Forms.ContextMenuStrip cmMenuItems;
        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.PictureBox pbForward;
        private System.Windows.Forms.PictureBox pbBack;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.PictureBox pbMinimise;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}