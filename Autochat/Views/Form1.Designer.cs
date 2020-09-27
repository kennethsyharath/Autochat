namespace Autochat
{
    partial class Form1
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
            this.OpenYAMLStartNode = new System.Windows.Forms.OpenFileDialog();
            this.LoadYAMLStartNodeBtn = new System.Windows.Forms.Button();
            this.InitateHotkeyObservationBtn = new System.Windows.Forms.Button();
            this.PreviewList = new System.Windows.Forms.ListView();
            this.Shortcut = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContentPreview = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // OpenYAMLStartNode
            // 
            this.OpenYAMLStartNode.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenYAMLStartNode_FileOk);
            // 
            // LoadYAMLStartNodeBtn
            // 
            this.LoadYAMLStartNodeBtn.Location = new System.Drawing.Point(12, 12);
            this.LoadYAMLStartNodeBtn.Name = "LoadYAMLStartNodeBtn";
            this.LoadYAMLStartNodeBtn.Size = new System.Drawing.Size(97, 23);
            this.LoadYAMLStartNodeBtn.TabIndex = 0;
            this.LoadYAMLStartNodeBtn.Text = "Load Start Node";
            this.LoadYAMLStartNodeBtn.UseVisualStyleBackColor = true;
            this.LoadYAMLStartNodeBtn.Click += new System.EventHandler(this.LoadYAMLStartNodeBtn_Click);
            // 
            // InitateHotkeyObservationBtn
            // 
            this.InitateHotkeyObservationBtn.Location = new System.Drawing.Point(12, 41);
            this.InitateHotkeyObservationBtn.Name = "InitateHotkeyObservationBtn";
            this.InitateHotkeyObservationBtn.Size = new System.Drawing.Size(97, 23);
            this.InitateHotkeyObservationBtn.TabIndex = 1;
            this.InitateHotkeyObservationBtn.Text = "Load Hotkeys";
            this.InitateHotkeyObservationBtn.UseVisualStyleBackColor = true;
            this.InitateHotkeyObservationBtn.Click += new System.EventHandler(this.InitateHotkeyObservationBtn_Click);
            // 
            // PreviewList
            // 
            this.PreviewList.AutoArrange = false;
            this.PreviewList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Shortcut,
            this.ContentPreview});
            this.PreviewList.GridLines = true;
            this.PreviewList.HideSelection = false;
            this.PreviewList.Location = new System.Drawing.Point(138, 12);
            this.PreviewList.MultiSelect = false;
            this.PreviewList.Name = "PreviewList";
            this.PreviewList.Size = new System.Drawing.Size(650, 426);
            this.PreviewList.TabIndex = 2;
            this.PreviewList.UseCompatibleStateImageBehavior = false;
            this.PreviewList.View = System.Windows.Forms.View.Details;
            // 
            // Shortcut
            // 
            this.Shortcut.Text = "Shortcut";
            // 
            // ContentPreview
            // 
            this.ContentPreview.Text = "Content Preview";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PreviewList);
            this.Controls.Add(this.InitateHotkeyObservationBtn);
            this.Controls.Add(this.LoadYAMLStartNodeBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog OpenYAMLStartNode;
        private System.Windows.Forms.Button LoadYAMLStartNodeBtn;
        private System.Windows.Forms.Button InitateHotkeyObservationBtn;
        private System.Windows.Forms.ListView PreviewList;
        private System.Windows.Forms.ColumnHeader Shortcut;
        private System.Windows.Forms.ColumnHeader ContentPreview;
    }
}

