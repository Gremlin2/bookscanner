namespace Gremlin.FB2Librarian.Import
{
    partial class BookFilterEditor
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
            this.filterControl = new DevExpress.XtraEditors.FilterControl();
            this.btSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // filterControl
            // 
            this.filterControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filterControl.Location = new System.Drawing.Point(12, 12);
            this.filterControl.Name = "filterControl";
            this.filterControl.Size = new System.Drawing.Size(411, 239);
            this.filterControl.TabIndex = 0;
            this.filterControl.Text = "filterControl";
            // 
            // btSearch
            // 
            this.btSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSearch.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btSearch.Location = new System.Drawing.Point(267, 262);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 25);
            this.btSearch.TabIndex = 18;
            this.btSearch.Text = "OK";
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(348, 262);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 25);
            this.btCancel.TabIndex = 19;
            this.btCancel.Text = "Cancel";
            // 
            // BookFilterEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 296);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.filterControl);
            this.Name = "BookFilterEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BookFilterEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.FilterControl filterControl;
        private DevExpress.XtraEditors.SimpleButton btSearch;
        private DevExpress.XtraEditors.SimpleButton btCancel;
    }
}