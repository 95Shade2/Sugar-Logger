namespace WindowsFormsApp1
{
        partial class EditText
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
                        this.NewText_TextBox = new System.Windows.Forms.TextBox();
                        this.ConfirmText_Button = new System.Windows.Forms.Button();
                        this.SuspendLayout();
                        // 
                        // NewText_TextBox
                        // 
                        this.NewText_TextBox.Location = new System.Drawing.Point(12, 12);
                        this.NewText_TextBox.Name = "NewText_TextBox";
                        this.NewText_TextBox.Size = new System.Drawing.Size(209, 20);
                        this.NewText_TextBox.TabIndex = 4;
                        this.NewText_TextBox.TextChanged += new System.EventHandler(this.NewText_TextBox_TextChanged);
                        this.NewText_TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewText_TextBox_KeyDown);
                        // 
                        // ConfirmText_Button
                        // 
                        this.ConfirmText_Button.Location = new System.Drawing.Point(81, 38);
                        this.ConfirmText_Button.Name = "ConfirmText_Button";
                        this.ConfirmText_Button.Size = new System.Drawing.Size(75, 23);
                        this.ConfirmText_Button.TabIndex = 5;
                        this.ConfirmText_Button.Text = "Confirm";
                        this.ConfirmText_Button.UseVisualStyleBackColor = true;
                        this.ConfirmText_Button.Click += new System.EventHandler(this.ConfirmText_Button_Click);
                        // 
                        // EditText
                        // 
                        this.AcceptButton = this.ConfirmText_Button;
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(238, 72);
                        this.Controls.Add(this.ConfirmText_Button);
                        this.Controls.Add(this.NewText_TextBox);
                        this.Name = "EditText";
                        this.Text = "EditText";
                        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditText_FormClosing);
                        this.Load += new System.EventHandler(this.EditText_Load);
                        this.Shown += new System.EventHandler(this.EditText_Shown);
                        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditText_KeyDown);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion
                private System.Windows.Forms.Button ConfirmText_Button;
                public System.Windows.Forms.TextBox NewText_TextBox;
        }
}