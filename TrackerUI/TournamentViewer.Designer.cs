namespace TrackerUI
{
    partial class TournamentViewer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            headerLabel = new Label();
            tournamentName = new Label();
            roundLabel = new Label();
            roundDropDown = new ComboBox();
            unplayedOnlyCheckBox = new CheckBox();
            matchupListBox = new ListBox();
            teamOneName = new Label();
            teamOneScoreLabel = new Label();
            teamOneScoreValue = new TextBox();
            teamTwoScoreText = new TextBox();
            teamTwoScoreLabel = new Label();
            teamTwoName = new Label();
            versusLabel = new Label();
            scoreButton = new Button();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI Light", 28.2F, FontStyle.Regular, GraphicsUnit.Point);
            headerLabel.ForeColor = SystemColors.MenuHighlight;
            headerLabel.Location = new Point(48, 39);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(271, 62);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "Tournament:";
            // 
            // tournamentName
            // 
            tournamentName.AutoSize = true;
            tournamentName.Font = new Font("Segoe UI Light", 28.2F, FontStyle.Regular, GraphicsUnit.Point);
            tournamentName.ForeColor = SystemColors.MenuHighlight;
            tournamentName.Location = new Point(315, 39);
            tournamentName.Name = "tournamentName";
            tournamentName.Size = new Size(208, 62);
            tournamentName.TabIndex = 2;
            tournamentName.Text = "<Name>";
            tournamentName.Click += label2_Click;
            // 
            // roundLabel
            // 
            roundLabel.AutoSize = true;
            roundLabel.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            roundLabel.ForeColor = SystemColors.MenuHighlight;
            roundLabel.Location = new Point(48, 142);
            roundLabel.Name = "roundLabel";
            roundLabel.Size = new Size(117, 46);
            roundLabel.TabIndex = 3;
            roundLabel.Text = "Round";
            // 
            // roundDropDown
            // 
            roundDropDown.FormattingEnabled = true;
            roundDropDown.Location = new Point(171, 143);
            roundDropDown.Name = "roundDropDown";
            roundDropDown.Size = new Size(257, 45);
            roundDropDown.TabIndex = 4;
            // 
            // unplayedOnlyCheckBox
            // 
            unplayedOnlyCheckBox.AutoSize = true;
            unplayedOnlyCheckBox.FlatStyle = FlatStyle.Flat;
            unplayedOnlyCheckBox.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            unplayedOnlyCheckBox.ForeColor = SystemColors.MenuHighlight;
            unplayedOnlyCheckBox.Location = new Point(171, 203);
            unplayedOnlyCheckBox.Name = "unplayedOnlyCheckBox";
            unplayedOnlyCheckBox.Size = new Size(257, 50);
            unplayedOnlyCheckBox.TabIndex = 5;
            unplayedOnlyCheckBox.Text = "Unplayed Only";
            unplayedOnlyCheckBox.UseVisualStyleBackColor = true;
            unplayedOnlyCheckBox.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // matchupListBox
            // 
            matchupListBox.BorderStyle = BorderStyle.FixedSingle;
            matchupListBox.FormattingEnabled = true;
            matchupListBox.ItemHeight = 37;
            matchupListBox.Location = new Point(48, 301);
            matchupListBox.Name = "matchupListBox";
            matchupListBox.Size = new Size(380, 372);
            matchupListBox.TabIndex = 6;
            // 
            // teamOneName
            // 
            teamOneName.AutoSize = true;
            teamOneName.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            teamOneName.ForeColor = SystemColors.MenuHighlight;
            teamOneName.Location = new Point(503, 304);
            teamOneName.Name = "teamOneName";
            teamOneName.Size = new Size(208, 46);
            teamOneName.TabIndex = 7;
            teamOneName.Text = "<team one>";
            // 
            // teamOneScoreLabel
            // 
            teamOneScoreLabel.AutoSize = true;
            teamOneScoreLabel.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            teamOneScoreLabel.ForeColor = SystemColors.MenuHighlight;
            teamOneScoreLabel.Location = new Point(503, 371);
            teamOneScoreLabel.Name = "teamOneScoreLabel";
            teamOneScoreLabel.Size = new Size(104, 46);
            teamOneScoreLabel.TabIndex = 8;
            teamOneScoreLabel.Text = "Score";
            // 
            // teamOneScoreValue
            // 
            teamOneScoreValue.Location = new Point(636, 374);
            teamOneScoreValue.Name = "teamOneScoreValue";
            teamOneScoreValue.Size = new Size(125, 43);
            teamOneScoreValue.TabIndex = 9;
            // 
            // teamTwoScoreText
            // 
            teamTwoScoreText.Location = new Point(636, 612);
            teamTwoScoreText.Name = "teamTwoScoreText";
            teamTwoScoreText.Size = new Size(125, 43);
            teamTwoScoreText.TabIndex = 16;
            // 
            // teamTwoScoreLabel
            // 
            teamTwoScoreLabel.AutoSize = true;
            teamTwoScoreLabel.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            teamTwoScoreLabel.ForeColor = SystemColors.MenuHighlight;
            teamTwoScoreLabel.Location = new Point(503, 609);
            teamTwoScoreLabel.Name = "teamTwoScoreLabel";
            teamTwoScoreLabel.Size = new Size(104, 46);
            teamTwoScoreLabel.TabIndex = 15;
            teamTwoScoreLabel.Text = "Score";
            // 
            // teamTwoName
            // 
            teamTwoName.AutoSize = true;
            teamTwoName.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            teamTwoName.ForeColor = SystemColors.MenuHighlight;
            teamTwoName.Location = new Point(503, 542);
            teamTwoName.Name = "teamTwoName";
            teamTwoName.Size = new Size(208, 46);
            teamTwoName.TabIndex = 14;
            teamTwoName.Text = "<team two>";
            // 
            // versusLabel
            // 
            versusLabel.AutoSize = true;
            versusLabel.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            versusLabel.ForeColor = SystemColors.MenuHighlight;
            versusLabel.Location = new Point(596, 462);
            versusLabel.Name = "versusLabel";
            versusLabel.Size = new Size(87, 46);
            versusLabel.TabIndex = 17;
            versusLabel.Text = "-VS-";
            // 
            // scoreButton
            // 
            scoreButton.FlatAppearance.BorderColor = Color.Silver;
            scoreButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            scoreButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(242, 242, 242);
            scoreButton.FlatStyle = FlatStyle.Flat;
            scoreButton.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            scoreButton.ForeColor = SystemColors.MenuHighlight;
            scoreButton.Location = new Point(805, 452);
            scoreButton.Name = "scoreButton";
            scoreButton.Size = new Size(145, 68);
            scoreButton.TabIndex = 18;
            scoreButton.Text = "Score";
            scoreButton.UseVisualStyleBackColor = true;
            // 
            // TournamentViewer
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 730);
            Controls.Add(scoreButton);
            Controls.Add(versusLabel);
            Controls.Add(teamTwoScoreText);
            Controls.Add(teamTwoScoreLabel);
            Controls.Add(teamTwoName);
            Controls.Add(teamOneScoreValue);
            Controls.Add(teamOneScoreLabel);
            Controls.Add(teamOneName);
            Controls.Add(matchupListBox);
            Controls.Add(unplayedOnlyCheckBox);
            Controls.Add(roundDropDown);
            Controls.Add(roundLabel);
            Controls.Add(tournamentName);
            Controls.Add(headerLabel);
            Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.White;
            Margin = new Padding(6, 6, 6, 6);
            Name = "TournamentViewer";
            Text = "Tournament Viewer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLabel;
        private Label tournamentName;
        private Label roundLabel;
        private ComboBox roundDropDown;
        private CheckBox unplayedOnlyCheckBox;
        private ListBox matchupListBox;
        private Label teamOneName;
        private Label teamOneScoreLabel;
        private TextBox teamOneScoreValue;
        private TextBox teamTwoScoreText;
        private Label teamTwoScoreLabel;
        private Label teamTwoName;
        private Label versusLabel;
        private Button scoreButton;
    }
}