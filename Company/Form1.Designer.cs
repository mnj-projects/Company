namespace Company
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
            this.components = new System.ComponentModel.Container();
            this.ctxNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxNodeAddChild = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxNodeDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblNodeText = new System.Windows.Forms.ToolStripStatusLabel();
            this.picTree = new System.Windows.Forms.PictureBox();
            this.ctxNode.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTree)).BeginInit();
            this.SuspendLayout();
            // 
            // ctxNode
            // 
            this.ctxNode.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxNodeAddChild,
            this.ctxNodeDelete});
            this.ctxNode.Name = "ctxNode";
            this.ctxNode.Size = new System.Drawing.Size(212, 52);
            // 
            // ctxNodeAddChild
            // 
            this.ctxNodeAddChild.Name = "ctxNodeAddChild";
            this.ctxNodeAddChild.Size = new System.Drawing.Size(211, 24);
            this.ctxNodeAddChild.Text = "&Add Employee...";
            this.ctxNodeAddChild.Click += new System.EventHandler(this.ctxNodeAddChild_Click);
            // 
            // ctxNodeDelete
            // 
            this.ctxNodeDelete.Name = "ctxNodeDelete";
            this.ctxNodeDelete.Size = new System.Drawing.Size(211, 24);
            this.ctxNodeDelete.Text = "&Remove Employee...";
            this.ctxNodeDelete.Click += new System.EventHandler(this.ctxNodeDelete_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.statusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblNodeText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.MinimumSize = new System.Drawing.Size(0, 110);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1060, 110);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblNodeText
            // 
            this.lblNodeText.Name = "lblNodeText";
            this.lblNodeText.Size = new System.Drawing.Size(0, 105);
            // 
            // picTree
            // 
            this.picTree.ContextMenuStrip = this.ctxNode;
            this.picTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picTree.Location = new System.Drawing.Point(0, 0);
            this.picTree.Margin = new System.Windows.Forms.Padding(4);
            this.picTree.Name = "picTree";
            this.picTree.Size = new System.Drawing.Size(1060, 431);
            this.picTree.TabIndex = 2;
            this.picTree.TabStop = false;
            this.picTree.Paint += new System.Windows.Forms.PaintEventHandler(this.picTree_Paint);
            this.picTree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picTree_Click);
            this.picTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picTree_MouseDown);
            this.picTree.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picTree_MouseMove);
            this.picTree.Resize += new System.EventHandler(this.picTree_Resize);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 541);
            this.Controls.Add(this.picTree);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Company and Employees";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.picTree_Resize);
            this.ctxNode.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ctxNode;
        private System.Windows.Forms.ToolStripMenuItem ctxNodeAddChild;
        private System.Windows.Forms.ToolStripMenuItem ctxNodeDelete;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblNodeText;
        private System.Windows.Forms.PictureBox picTree;
    }
}

