namespace SnakeWinForms
{
    partial class OptionsForm
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
            this.BehaviorCHB = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OK_button = new System.Windows.Forms.Button();
            this.Cancel_button2 = new System.Windows.Forms.Button();
            this.LevelsBox = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BehaviorCHB
            // 
            this.BehaviorCHB.AutoSize = true;
            this.BehaviorCHB.Location = new System.Drawing.Point(6, 19);
            this.BehaviorCHB.Name = "BehaviorCHB";
            this.BehaviorCHB.Size = new System.Drawing.Size(153, 17);
            this.BehaviorCHB.TabIndex = 0;
            this.BehaviorCHB.Text = "Проходить сквозь стены";
            this.BehaviorCHB.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BehaviorCHB);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 45);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поведение";
            // 
            // OK_button
            // 
            this.OK_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_button.Location = new System.Drawing.Point(101, 153);
            this.OK_button.Name = "OK_button";
            this.OK_button.Size = new System.Drawing.Size(76, 30);
            this.OK_button.TabIndex = 2;
            this.OK_button.Text = "OK";
            this.OK_button.UseVisualStyleBackColor = true;
            this.OK_button.Click += new System.EventHandler(this.OK_button_Click);
            // 
            // Cancel_button2
            // 
            this.Cancel_button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_button2.Location = new System.Drawing.Point(12, 153);
            this.Cancel_button2.Name = "Cancel_button2";
            this.Cancel_button2.Size = new System.Drawing.Size(73, 30);
            this.Cancel_button2.TabIndex = 3;
            this.Cancel_button2.Text = "Отмена";
            this.Cancel_button2.UseVisualStyleBackColor = true;
            this.Cancel_button2.Click += new System.EventHandler(this.Cancel_button2_Click);
            // 
            // LevelsBox
            // 
            this.LevelsBox.FormattingEnabled = true;
            this.LevelsBox.Location = new System.Drawing.Point(12, 64);
            this.LevelsBox.Name = "LevelsBox";
            this.LevelsBox.Size = new System.Drawing.Size(165, 82);
            this.LevelsBox.TabIndex = 4;
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.OK_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_button2;
            this.ClientSize = new System.Drawing.Size(189, 195);
            this.Controls.Add(this.LevelsBox);
            this.Controls.Add(this.Cancel_button2);
            this.Controls.Add(this.OK_button);
            this.Controls.Add(this.groupBox1);
            this.Name = "OptionsForm";
            this.Text = "Настройки";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox BehaviorCHB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button OK_button;
        private System.Windows.Forms.Button Cancel_button2;
        private System.Windows.Forms.ListBox LevelsBox;
    }
}