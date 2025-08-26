namespace ObjectTK.Net.Examples
{
    partial class ExampleBrowser
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
            treeViewExamples = new TreeView();
            label1 = new Label();
            SuspendLayout();
            // 
            // treeViewExamples
            // 
            treeViewExamples.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeViewExamples.Location = new Point(14, 29);
            treeViewExamples.Margin = new Padding(4, 3, 4, 3);
            treeViewExamples.Name = "treeViewExamples";
            treeViewExamples.Size = new Size(401, 342);
            treeViewExamples.TabIndex = 1;
            treeViewExamples.NodeMouseDoubleClick += TreeViewExamples_NodeMouseDoubleClick;
            treeViewExamples.KeyDown += TreeViewExamples_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 7);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(213, 15);
            label1.TabIndex = 0;
            label1.Text = "Example projects: Double-click to run.";
            // 
            // ExampleBrowser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(429, 385);
            Controls.Add(label1);
            Controls.Add(treeViewExamples);
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "ExampleBrowser";
            Text = "ObjectTK example projects";
            Load += ExampleBrowser_Load;
            KeyDown += ExampleBrowser_KeyDown;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewExamples;
        private System.Windows.Forms.Label label1;
    }
}