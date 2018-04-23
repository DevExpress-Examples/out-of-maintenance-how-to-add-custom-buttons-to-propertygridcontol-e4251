using System;
namespace GridControlWithBar
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
            this.propertyGridControlDescendant1 = new GridControlWithBar.PropertyGridControlDescendant();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControlDescendant1)).BeginInit();
            this.SuspendLayout();
            // 
            // propertyGridControlDescendant1
            // 
            this.propertyGridControlDescendant1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridControlDescendant1.Location = new System.Drawing.Point(0, 0);
            this.propertyGridControlDescendant1.Name = "propertyGridControlDescendant1";
            this.propertyGridControlDescendant1.Size = new System.Drawing.Size(703, 442);
            this.propertyGridControlDescendant1.TabIndex = 0;
            this.propertyGridControlDescendant1.Tag = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 442);
            this.Controls.Add(this.propertyGridControlDescendant1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControlDescendant1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PropertyGridControlDescendant propertyGridControlDescendant1;









    }
}

