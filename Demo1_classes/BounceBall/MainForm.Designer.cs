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
      this.UI_ApplyButton = new System.Windows.Forms.Button();
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
      // UI_ApplyButton
      // 
      this.UI_ApplyButton.Location = new System.Drawing.Point(164, 167);
      this.UI_ApplyButton.Name = "UI_ApplyButton";
      this.UI_ApplyButton.Size = new System.Drawing.Size(75, 23);
      this.UI_ApplyButton.TabIndex = 3;
      this.UI_ApplyButton.Text = "Apply";
      this.UI_ApplyButton.UseVisualStyleBackColor = true;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(398, 242);
      this.Controls.Add(this.UI_ApplyButton);
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
    private System.Windows.Forms.Button UI_ApplyButton;
  }
}

