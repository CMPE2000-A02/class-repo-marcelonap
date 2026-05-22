namespace BounceBall
{
    partial class MainForm
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
            this.UI_Tim_Main = new System.Windows.Forms.Timer(this.components);
            this._btnEngage = new System.Windows.Forms.Button();
            this._btnThread = new System.Windows.Forms.Button();
            this.UI_TextBox_1 = new System.Windows.Forms.TextBox();
            this.UI_BirdButton = new System.Windows.Forms.Button();
            this.SortButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UI_Tim_Main
            // 
            this.UI_Tim_Main.Enabled = true;
            this.UI_Tim_Main.Interval = 20;
            // 
            // _btnEngage
            // 
            this._btnEngage.Location = new System.Drawing.Point(31, 21);
            this._btnEngage.Name = "_btnEngage";
            this._btnEngage.Size = new System.Drawing.Size(75, 23);
            this._btnEngage.TabIndex = 0;
            this._btnEngage.Text = "Engage !";
            this._btnEngage.UseVisualStyleBackColor = true;
            // 
            // _btnThread
            // 
            this._btnThread.Location = new System.Drawing.Point(31, 62);
            this._btnThread.Name = "_btnThread";
            this._btnThread.Size = new System.Drawing.Size(75, 23);
            this._btnThread.TabIndex = 1;
            this._btnThread.Text = "Thread Me";
            this._btnThread.UseVisualStyleBackColor = true;
            // 
            // UI_TextBox_1
            // 
            this.UI_TextBox_1.Location = new System.Drawing.Point(44, 169);
            this.UI_TextBox_1.Name = "UI_TextBox_1";
            this.UI_TextBox_1.Size = new System.Drawing.Size(100, 20);
            this.UI_TextBox_1.TabIndex = 2;
            // 
            // UI_BirdButton
            // 
            this.UI_BirdButton.Location = new System.Drawing.Point(164, 167);
            this.UI_BirdButton.Name = "UI_BirdButton";
            this.UI_BirdButton.Size = new System.Drawing.Size(75, 23);
            this.UI_BirdButton.TabIndex = 3;
            this.UI_BirdButton.Text = "Display Bird Info";
            this.UI_BirdButton.UseVisualStyleBackColor = true;
            // 
            // SortButton
            // 
            this.SortButton.Location = new System.Drawing.Point(271, 53);
            this.SortButton.Name = "SortButton";
            this.SortButton.Size = new System.Drawing.Size(75, 23);
            this.SortButton.TabIndex = 4;
            this.SortButton.Text = "Sort Balls";
            this.SortButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 242);
            this.Controls.Add(this.SortButton);
            this.Controls.Add(this.UI_BirdButton);
            this.Controls.Add(this.UI_TextBox_1);
            this.Controls.Add(this._btnThread);
            this.Controls.Add(this._btnEngage);
            this.Name = "MainForm";
            this.Text = "Bounce Ball";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer UI_Tim_Main;
    private System.Windows.Forms.Button _btnEngage;
    private System.Windows.Forms.Button _btnThread;
        private System.Windows.Forms.TextBox UI_TextBox_1;
    private System.Windows.Forms.Button UI_BirdButton;
        private System.Windows.Forms.Button SortButton;
    }
}

