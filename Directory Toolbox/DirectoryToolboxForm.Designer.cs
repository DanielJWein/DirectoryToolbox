
namespace Directory_Toolbox
{
    partial class DirectoryToolboxForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private readonly System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectoryToolboxForm));
            this.PanelScripts = new System.Windows.Forms.Panel();
            this.PanelScriptList = new System.Windows.Forms.Panel();
            this.HeaderScripts = new System.Windows.Forms.Label();
            this.PanelEditor = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.HeaderEditor = new System.Windows.Forms.Label();
            this.TextEditor = new System.Windows.Forms.RichTextBox();
            this.PanelOptions = new System.Windows.Forms.Panel();
            this.PanelOptionList = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.TextPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextMask = new System.Windows.Forms.TextBox();
            this.CheckMask = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CheckRecurse = new System.Windows.Forms.CheckBox();
            this.ButtonSeekDir = new System.Windows.Forms.Button();
            this.HeaderOptions = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.PanelScripts.SuspendLayout();
            this.PanelEditor.SuspendLayout();
            this.PanelOptions.SuspendLayout();
            this.PanelOptionList.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelScripts
            // 
            this.PanelScripts.BackColor = System.Drawing.Color.Gray;
            this.PanelScripts.Controls.Add(this.PanelScriptList);
            this.PanelScripts.Controls.Add(this.HeaderScripts);
            this.PanelScripts.Location = new System.Drawing.Point(12, 12);
            this.PanelScripts.Name = "PanelScripts";
            this.PanelScripts.Size = new System.Drawing.Size(200, 401);
            this.PanelScripts.TabIndex = 0;
            // 
            // PanelScriptList
            // 
            this.PanelScriptList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PanelScriptList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelScriptList.Location = new System.Drawing.Point(0, 31);
            this.PanelScriptList.Name = "PanelScriptList";
            this.PanelScriptList.Size = new System.Drawing.Size(200, 370);
            this.PanelScriptList.TabIndex = 4;
            // 
            // HeaderScripts
            // 
            this.HeaderScripts.AutoSize = true;
            this.HeaderScripts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderScripts.Location = new System.Drawing.Point(3, 4);
            this.HeaderScripts.Name = "HeaderScripts";
            this.HeaderScripts.Size = new System.Drawing.Size(66, 24);
            this.HeaderScripts.TabIndex = 3;
            this.HeaderScripts.Text = "Scripts";
            // 
            // PanelEditor
            // 
            this.PanelEditor.BackColor = System.Drawing.SystemColors.Highlight;
            this.PanelEditor.Controls.Add(this.label1);
            this.PanelEditor.Controls.Add(this.textBox1);
            this.PanelEditor.Controls.Add(this.ButtonSave);
            this.PanelEditor.Controls.Add(this.HeaderEditor);
            this.PanelEditor.Controls.Add(this.TextEditor);
            this.PanelEditor.Location = new System.Drawing.Point(218, 12);
            this.PanelEditor.Name = "PanelEditor";
            this.PanelEditor.Size = new System.Drawing.Size(334, 401);
            this.PanelEditor.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(22)))), ((int)(((byte)(56)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1, 381);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Title";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(34, 378);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(300, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "Example Script";
            // 
            // ButtonSave
            // 
            this.ButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonSave.Location = new System.Drawing.Point(302, 1);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(29, 28);
            this.ButtonSave.TabIndex = 2;
            this.ButtonSave.Text = "💾";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.clickSave);
            // 
            // HeaderEditor
            // 
            this.HeaderEditor.AutoSize = true;
            this.HeaderEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderEditor.Location = new System.Drawing.Point(3, 2);
            this.HeaderEditor.Name = "HeaderEditor";
            this.HeaderEditor.Size = new System.Drawing.Size(111, 24);
            this.HeaderEditor.TabIndex = 1;
            this.HeaderEditor.Text = "Script Editor";
            // 
            // TextEditor
            // 
            this.TextEditor.AcceptsTab = true;
            this.TextEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(22)))), ((int)(((byte)(56)))));
            this.TextEditor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextEditor.DetectUrls = false;
            this.TextEditor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TextEditor.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextEditor.ForeColor = System.Drawing.Color.White;
            this.TextEditor.Location = new System.Drawing.Point(0, 29);
            this.TextEditor.Name = "TextEditor";
            this.TextEditor.Size = new System.Drawing.Size(334, 372);
            this.TextEditor.TabIndex = 0;
            this.TextEditor.Text = resources.GetString("TextEditor.Text");
            this.TextEditor.TextChanged += new System.EventHandler(this.writeTextEditor);
            // 
            // PanelOptions
            // 
            this.PanelOptions.BackColor = System.Drawing.Color.LightCoral;
            this.PanelOptions.Controls.Add(this.PanelOptionList);
            this.PanelOptions.Controls.Add(this.HeaderOptions);
            this.PanelOptions.Location = new System.Drawing.Point(558, 12);
            this.PanelOptions.Name = "PanelOptions";
            this.PanelOptions.Size = new System.Drawing.Size(230, 401);
            this.PanelOptions.TabIndex = 2;
            // 
            // PanelOptionList
            // 
            this.PanelOptionList.BackColor = System.Drawing.Color.Maroon;
            this.PanelOptionList.Controls.Add(this.label4);
            this.PanelOptionList.Controls.Add(this.TextPath);
            this.PanelOptionList.Controls.Add(this.label3);
            this.PanelOptionList.Controls.Add(this.TextMask);
            this.PanelOptionList.Controls.Add(this.CheckMask);
            this.PanelOptionList.Controls.Add(this.label2);
            this.PanelOptionList.Controls.Add(this.CheckRecurse);
            this.PanelOptionList.Controls.Add(this.ButtonSeekDir);
            this.PanelOptionList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelOptionList.Location = new System.Drawing.Point(0, 29);
            this.PanelOptionList.Name = "PanelOptionList";
            this.PanelOptionList.Size = new System.Drawing.Size(230, 372);
            this.PanelOptionList.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 306);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Status";
            // 
            // TextPath
            // 
            this.TextPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextPath.Location = new System.Drawing.Point(3, 3);
            this.TextPath.Name = "TextPath";
            this.TextPath.Size = new System.Drawing.Size(190, 20);
            this.TextPath.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(2, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Processed XXXXXX Folders";
            // 
            // TextMask
            // 
            this.TextMask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextMask.Location = new System.Drawing.Point(61, 27);
            this.TextMask.Name = "TextMask";
            this.TextMask.Size = new System.Drawing.Size(132, 20);
            this.TextMask.TabIndex = 4;
            this.TextMask.Text = "*.*";
            this.TextMask.Visible = false;
            // 
            // CheckMask
            // 
            this.CheckMask.AutoSize = true;
            this.CheckMask.ForeColor = System.Drawing.Color.White;
            this.CheckMask.Location = new System.Drawing.Point(3, 29);
            this.CheckMask.Name = "CheckMask";
            this.CheckMask.Size = new System.Drawing.Size(52, 17);
            this.CheckMask.TabIndex = 3;
            this.CheckMask.Text = "Mask";
            this.CheckMask.UseVisualStyleBackColor = true;
            this.CheckMask.CheckedChanged += new System.EventHandler(this.changeCheckMask);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Processed XXXXXX Files";
            // 
            // CheckRecurse
            // 
            this.CheckRecurse.AutoSize = true;
            this.CheckRecurse.ForeColor = System.Drawing.Color.White;
            this.CheckRecurse.Location = new System.Drawing.Point(3, 52);
            this.CheckRecurse.Name = "CheckRecurse";
            this.CheckRecurse.Size = new System.Drawing.Size(66, 17);
            this.CheckRecurse.TabIndex = 5;
            this.CheckRecurse.Text = "Recurse";
            this.CheckRecurse.UseVisualStyleBackColor = true;
            // 
            // ButtonSeekDir
            // 
            this.ButtonSeekDir.Location = new System.Drawing.Point(195, 3);
            this.ButtonSeekDir.Name = "ButtonSeekDir";
            this.ButtonSeekDir.Size = new System.Drawing.Size(31, 20);
            this.ButtonSeekDir.TabIndex = 2;
            this.ButtonSeekDir.Text = "...";
            this.ButtonSeekDir.UseVisualStyleBackColor = true;
            this.ButtonSeekDir.Click += new System.EventHandler(this.clickSeek);
            // 
            // HeaderOptions
            // 
            this.HeaderOptions.AutoSize = true;
            this.HeaderOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderOptions.ForeColor = System.Drawing.Color.Black;
            this.HeaderOptions.Location = new System.Drawing.Point(3, 4);
            this.HeaderOptions.Name = "HeaderOptions";
            this.HeaderOptions.Size = new System.Drawing.Size(75, 24);
            this.HeaderOptions.TabIndex = 0;
            this.HeaderOptions.Text = "Options";
            // 
            // DirectoryToolboxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PanelOptions);
            this.Controls.Add(this.PanelEditor);
            this.Controls.Add(this.PanelScripts);
            this.Name = "DirectoryToolboxForm";
            this.Text = "Directory Toolbox";
            this.Load += new System.EventHandler(this.loadForm);
            this.SizeChanged += new System.EventHandler(this.sizeForm);
            this.PanelScripts.ResumeLayout(false);
            this.PanelScripts.PerformLayout();
            this.PanelEditor.ResumeLayout(false);
            this.PanelEditor.PerformLayout();
            this.PanelOptions.ResumeLayout(false);
            this.PanelOptions.PerformLayout();
            this.PanelOptionList.ResumeLayout(false);
            this.PanelOptionList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelScripts;
        private System.Windows.Forms.Panel PanelEditor;
        private System.Windows.Forms.Panel PanelOptions;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Label HeaderEditor;
        private System.Windows.Forms.RichTextBox TextEditor;
        private System.Windows.Forms.Button ButtonSeekDir;
        private System.Windows.Forms.TextBox TextPath;
        private System.Windows.Forms.Label HeaderOptions;
        private System.Windows.Forms.Panel PanelScriptList;
        private System.Windows.Forms.Label HeaderScripts;
        private System.Windows.Forms.CheckBox CheckMask;
        private System.Windows.Forms.TextBox TextMask;
        private System.Windows.Forms.CheckBox CheckRecurse;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel PanelOptionList;
    }
}

