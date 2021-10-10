
namespace FactoryMethod {
    partial class MainForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TxtCreateDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PngCreateDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TxtOpenDocumentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.PngOpenDocumentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1435, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TxtCreateDocumentToolStripMenuItem,
            this.PngCreateDocumentToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.newToolStripMenuItem.Text = "New";
            // 
            // TxtCreateDocumentToolStripMenuItem
            // 
            this.TxtCreateDocumentToolStripMenuItem.Name = "TxtCreateDocumentToolStripMenuItem";
            this.TxtCreateDocumentToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.TxtCreateDocumentToolStripMenuItem.Text = "TXT document";
            this.TxtCreateDocumentToolStripMenuItem.Click += new System.EventHandler(this.TxtCreateDocumentToolStripMenuItem_Click);
            // 
            // PngCreateDocumentToolStripMenuItem
            // 
            this.PngCreateDocumentToolStripMenuItem.Name = "PngCreateDocumentToolStripMenuItem";
            this.PngCreateDocumentToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.PngCreateDocumentToolStripMenuItem.Text = "PNG document";
            this.PngCreateDocumentToolStripMenuItem.Click += new System.EventHandler(this.PngCreateDocumentToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TxtOpenDocumentToolStripMenuItem1,
            this.PngOpenDocumentToolStripMenuItem1});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // TxtOpenDocumentToolStripMenuItem1
            // 
            this.TxtOpenDocumentToolStripMenuItem1.Name = "TxtOpenDocumentToolStripMenuItem1";
            this.TxtOpenDocumentToolStripMenuItem1.Size = new System.Drawing.Size(192, 26);
            this.TxtOpenDocumentToolStripMenuItem1.Text = "TXT document";
            this.TxtOpenDocumentToolStripMenuItem1.Click += new System.EventHandler(this.TxtOpenDocumentToolStripMenuItem1_Click);
            // 
            // PngOpenDocumentToolStripMenuItem1
            // 
            this.PngOpenDocumentToolStripMenuItem1.Name = "PngOpenDocumentToolStripMenuItem1";
            this.PngOpenDocumentToolStripMenuItem1.Size = new System.Drawing.Size(192, 26);
            this.PngOpenDocumentToolStripMenuItem1.Text = "PNG document";
            this.PngOpenDocumentToolStripMenuItem1.Click += new System.EventHandler(this.PngOpenDocumentToolStripMenuItem1_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1435, 730);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Main";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TxtCreateDocumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PngCreateDocumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TxtOpenDocumentToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem PngOpenDocumentToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
    }
}

