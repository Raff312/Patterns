
namespace MusicEditor {
    partial class EditorForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnWholeNote = new System.Windows.Forms.ToolStripButton();
            this.btnHalfNote = new System.Windows.Forms.ToolStripButton();
            this.btnQuarterNote = new System.Windows.Forms.ToolStripButton();
            this.btnEighthNote = new System.Windows.Forms.ToolStripButton();
            this.btnSixteenthNote = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAbove = new System.Windows.Forms.ToolStripButton();
            this.btnRotate = new System.Windows.Forms.ToolStripButton();
            this.btnDelNote = new System.Windows.Forms.ToolStripButton();
            this.btnUnMark = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPlay = new System.Windows.Forms.ToolStripButton();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.scoreSheetPanel = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnWholeNote,
            this.btnHalfNote,
            this.btnQuarterNote,
            this.btnEighthNote,
            this.btnSixteenthNote,
            this.toolStripSeparator1,
            this.btnAbove,
            this.btnRotate,
            this.btnDelNote,
            this.btnUnMark,
            this.toolStripSeparator2,
            this.btnPlay,
            this.btnClear});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1024, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnWholeNote
            // 
            this.btnWholeNote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnWholeNote.Image = ((System.Drawing.Image)(resources.GetObject("btnWholeNote.Image")));
            this.btnWholeNote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnWholeNote.Name = "btnWholeNote";
            this.btnWholeNote.Size = new System.Drawing.Size(29, 24);
            this.btnWholeNote.Text = "Whole Note";
            this.btnWholeNote.Click += new System.EventHandler(this.btnWholeNote_Click);
            // 
            // btnHalfNote
            // 
            this.btnHalfNote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHalfNote.Image = ((System.Drawing.Image)(resources.GetObject("btnHalfNote.Image")));
            this.btnHalfNote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHalfNote.Name = "btnHalfNote";
            this.btnHalfNote.Size = new System.Drawing.Size(29, 24);
            this.btnHalfNote.Text = "Half Note";
            this.btnHalfNote.Click += new System.EventHandler(this.btnHalfNote_Click);
            // 
            // btnQuarterNote
            // 
            this.btnQuarterNote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnQuarterNote.Image = global::MusicEditor.Properties.Resources.QuarterNote;
            this.btnQuarterNote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuarterNote.Name = "btnQuarterNote";
            this.btnQuarterNote.Size = new System.Drawing.Size(29, 24);
            this.btnQuarterNote.Text = "Quarter Note";
            this.btnQuarterNote.Click += new System.EventHandler(this.btnQuarterNote_Click);
            // 
            // btnEighthNote
            // 
            this.btnEighthNote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEighthNote.Image = global::MusicEditor.Properties.Resources.EighthNote;
            this.btnEighthNote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEighthNote.Name = "btnEighthNote";
            this.btnEighthNote.Size = new System.Drawing.Size(29, 24);
            this.btnEighthNote.Text = "Eighth Note";
            this.btnEighthNote.Click += new System.EventHandler(this.btnEighthNote_Click);
            // 
            // btnSixteenthNote
            // 
            this.btnSixteenthNote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSixteenthNote.Image = global::MusicEditor.Properties.Resources.SixteenthNote;
            this.btnSixteenthNote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSixteenthNote.Name = "btnSixteenthNote";
            this.btnSixteenthNote.Size = new System.Drawing.Size(29, 24);
            this.btnSixteenthNote.Text = "Sixteenth Note";
            this.btnSixteenthNote.Click += new System.EventHandler(this.btnSixteenthNote_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnAbove
            // 
            this.btnAbove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAbove.Image = global::MusicEditor.Properties.Resources.Up;
            this.btnAbove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbove.Name = "btnAbove";
            this.btnAbove.Size = new System.Drawing.Size(29, 24);
            this.btnAbove.Text = "Up Note";
            this.btnAbove.Click += new System.EventHandler(this.btnAbove_Click);
            // 
            // btnRotate
            // 
            this.btnRotate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRotate.Image = global::MusicEditor.Properties.Resources.Rotate;
            this.btnRotate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(29, 24);
            this.btnRotate.Text = "Rotate Note";
            this.btnRotate.Click += new System.EventHandler(this.btnRotate_Click);
            // 
            // btnDelNote
            // 
            this.btnDelNote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelNote.Enabled = false;
            this.btnDelNote.Image = global::MusicEditor.Properties.Resources.erase;
            this.btnDelNote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelNote.Name = "btnDelNote";
            this.btnDelNote.Size = new System.Drawing.Size(29, 24);
            this.btnDelNote.Text = " Delete Note";
            this.btnDelNote.Click += new System.EventHandler(this.btnDelNote_Click);
            // 
            // btnUnMark
            // 
            this.btnUnMark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUnMark.Image = global::MusicEditor.Properties.Resources.deselect_16;
            this.btnUnMark.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnMark.Name = "btnUnMark";
            this.btnUnMark.Size = new System.Drawing.Size(29, 24);
            this.btnUnMark.Text = "Deselect All";
            this.btnUnMark.Click += new System.EventHandler(this.btnUnMark_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnPlay
            // 
            this.btnPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPlay.Enabled = false;
            this.btnPlay.Image = global::MusicEditor.Properties.Resources.Play;
            this.btnPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(29, 24);
            this.btnPlay.Text = "Play Melody";
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnClear
            // 
            this.btnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClear.Image = global::MusicEditor.Properties.Resources.Clear;
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(29, 24);
            this.btnClear.Text = "Clear Sheet";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.scoreSheetPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 500);
            this.panel1.TabIndex = 1;
            // 
            // scoreSheetPanel
            // 
            this.scoreSheetPanel.AutoSize = true;
            this.scoreSheetPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.scoreSheetPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scoreSheetPanel.Location = new System.Drawing.Point(0, 0);
            this.scoreSheetPanel.Margin = new System.Windows.Forms.Padding(25);
            this.scoreSheetPanel.Name = "scoreSheetPanel";
            this.scoreSheetPanel.Size = new System.Drawing.Size(1024, 500);
            this.scoreSheetPanel.TabIndex = 0;
            this.scoreSheetPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.scoreSheetPanel_ControlAdded);
            this.scoreSheetPanel.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.scoreSheetPanel_ControlRemoved);
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1024, 527);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.MinimumSize = new System.Drawing.Size(663, 433);
            this.Name = "EditorForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "EditorForm";
            this.ResizeEnd += new System.EventHandler(this.EditorForm_ResizeEnd);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnWholeNote;
        private System.Windows.Forms.ToolStripButton btnHalfNote;
        private System.Windows.Forms.ToolStripButton btnQuarterNote;
        private System.Windows.Forms.ToolStripButton btnEighthNote;
        private System.Windows.Forms.ToolStripButton btnSixteenthNote;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAbove;
        private System.Windows.Forms.ToolStripButton btnRotate;
        private System.Windows.Forms.ToolStripButton btnDelNote;
        private System.Windows.Forms.ToolStripButton btnUnMark;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnPlay;
        private System.Windows.Forms.ToolStripButton btnClear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel scoreSheetPanel;
    }
}