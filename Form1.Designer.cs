namespace Woodoku_App
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
            this.round_label = new System.Windows.Forms.Label();
            this.space_score_label = new System.Windows.Forms.Label();
            this.score_label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.best_Move_Button = new System.Windows.Forms.Button();
            this.bestMoveText = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.go_to_game_screen = new System.Windows.Forms.Button();
            this.go_to_smart_screen = new System.Windows.Forms.Button();
            this.AI_clear = new System.Windows.Forms.Button();
            this.home_button = new System.Windows.Forms.Button();
            this.Ok_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // round_label
            // 
            this.round_label.AutoSize = true;
            this.round_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.round_label.Location = new System.Drawing.Point(10, 10);
            this.round_label.Name = "round_label";
            this.round_label.Size = new System.Drawing.Size(91, 25);
            this.round_label.TabIndex = 0;
            this.round_label.Text = "Round: 0";
            // 
            // space_score_label
            // 
            this.space_score_label.AutoSize = true;
            this.space_score_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.space_score_label.Location = new System.Drawing.Point(398, 10);
            this.space_score_label.Name = "space_score_label";
            this.space_score_label.Size = new System.Drawing.Size(165, 25);
            this.space_score_label.TabIndex = 1;
            this.space_score_label.Text = "SpaceScore: 165";
            this.space_score_label.Visible = false;
            // 
            // score_label
            // 
            this.score_label.AutoSize = true;
            this.score_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.score_label.Location = new System.Drawing.Point(235, 10);
            this.score_label.Name = "score_label";
            this.score_label.Size = new System.Drawing.Size(86, 25);
            this.score_label.TabIndex = 2;
            this.score_label.Text = "Score: 0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(118, 449);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 100);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(228, 449);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 100);
            this.button2.TabIndex = 4;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(338, 449);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 100);
            this.button3.TabIndex = 5;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // best_Move_Button
            // 
            this.best_Move_Button.Location = new System.Drawing.Point(444, 509);
            this.best_Move_Button.Name = "best_Move_Button";
            this.best_Move_Button.Size = new System.Drawing.Size(102, 40);
            this.best_Move_Button.TabIndex = 6;
            this.best_Move_Button.Text = "Show Moves";
            this.best_Move_Button.UseVisualStyleBackColor = true;
            // 
            // bestMoveText
            // 
            this.bestMoveText.Location = new System.Drawing.Point(444, 449);
            this.bestMoveText.Name = "bestMoveText";
            this.bestMoveText.Size = new System.Drawing.Size(102, 54);
            this.bestMoveText.TabIndex = 7;
            this.bestMoveText.Text = "";
            // 
            // go_to_game_screen
            // 
            this.go_to_game_screen.Location = new System.Drawing.Point(118, 329);
            this.go_to_game_screen.Name = "go_to_game_screen";
            this.go_to_game_screen.Size = new System.Drawing.Size(150, 75);
            this.go_to_game_screen.TabIndex = 10;
            this.go_to_game_screen.Text = "Play Woodoku";
            this.go_to_game_screen.UseVisualStyleBackColor = true;
            this.go_to_game_screen.Click += new System.EventHandler(this.go_to_game_screen_Click);
            // 
            // go_to_smart_screen
            // 
            this.go_to_smart_screen.Location = new System.Drawing.Point(288, 329);
            this.go_to_smart_screen.Name = "go_to_smart_screen";
            this.go_to_smart_screen.Size = new System.Drawing.Size(150, 75);
            this.go_to_smart_screen.TabIndex = 11;
            this.go_to_smart_screen.Text = "Use AI Tool";
            this.go_to_smart_screen.UseVisualStyleBackColor = true;
            this.go_to_smart_screen.Click += new System.EventHandler(this.go_to_smart_screen_Click);
            // 
            // AI_clear
            // 
            this.AI_clear.Location = new System.Drawing.Point(15, 449);
            this.AI_clear.Name = "AI_clear";
            this.AI_clear.Size = new System.Drawing.Size(56, 100);
            this.AI_clear.TabIndex = 12;
            this.AI_clear.Text = "Clear";
            this.AI_clear.UseVisualStyleBackColor = true;
            this.AI_clear.Click += new System.EventHandler(this.AI_clear_Click);
            // 
            // home_button
            // 
            this.home_button.Location = new System.Drawing.Point(403, 7);
            this.home_button.Name = "home_button";
            this.home_button.Size = new System.Drawing.Size(143, 36);
            this.home_button.TabIndex = 13;
            this.home_button.Text = "Home";
            this.home_button.UseVisualStyleBackColor = true;
            this.home_button.Click += new System.EventHandler(this.home_button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.Font = new System.Drawing.Font("Calibri", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ok_Button.Location = new System.Drawing.Point(807, 449);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(165, 100);
            this.Ok_Button.TabIndex = 14;
            this.Ok_Button.Text = "OK";
            this.Ok_Button.UseVisualStyleBackColor = true;
            this.Ok_Button.Visible = false;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.home_button);
            this.Controls.Add(this.AI_clear);
            this.Controls.Add(this.go_to_smart_screen);
            this.Controls.Add(this.go_to_game_screen);
            this.Controls.Add(this.bestMoveText);
            this.Controls.Add(this.best_Move_Button);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.score_label);
            this.Controls.Add(this.space_score_label);
            this.Controls.Add(this.round_label);
            this.Name = "Form1";
            this.Text = "Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label round_label;
        private System.Windows.Forms.Label space_score_label;
        private System.Windows.Forms.Label score_label;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button best_Move_Button;
        private System.Windows.Forms.RichTextBox bestMoveText;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button go_to_game_screen;
        private System.Windows.Forms.Button go_to_smart_screen;
        private System.Windows.Forms.Button AI_clear;
        private System.Windows.Forms.Button home_button;
        private System.Windows.Forms.Button Ok_Button;
    }
}

