namespace TrackerUI
{
    partial class TournamentDashboardForm
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
            createTeamLabel = new Label();
            loadExcistingTouurnamentValue = new ComboBox();
            loadExcistingTournamentLabel = new Label();
            loadTournamentButton = new Button();
            createTournamentButton = new Button();
            SuspendLayout();
            // 
            // createTeamLabel
            // 
            createTeamLabel.AutoSize = true;
            createTeamLabel.Font = new Font("Segoe UI Light", 28.2F, FontStyle.Regular, GraphicsUnit.Point);
            createTeamLabel.ForeColor = SystemColors.MenuHighlight;
            createTeamLabel.Location = new Point(256, 53);
            createTeamLabel.Name = "createTeamLabel";
            createTeamLabel.Size = new Size(488, 62);
            createTeamLabel.TabIndex = 14;
            createTeamLabel.Text = "Tournament Dashboard";
            // 
            // loadExcistingTouurnamentValue
            // 
            loadExcistingTouurnamentValue.FormattingEnabled = true;
            loadExcistingTouurnamentValue.Location = new Point(229, 227);
            loadExcistingTouurnamentValue.Name = "loadExcistingTouurnamentValue";
            loadExcistingTouurnamentValue.Size = new Size(542, 45);
            loadExcistingTouurnamentValue.TabIndex = 26;
            // 
            // loadExcistingTournamentLabel
            // 
            loadExcistingTournamentLabel.AutoSize = true;
            loadExcistingTournamentLabel.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            loadExcistingTournamentLabel.ForeColor = SystemColors.MenuHighlight;
            loadExcistingTournamentLabel.Location = new Point(298, 164);
            loadExcistingTournamentLabel.Name = "loadExcistingTournamentLabel";
            loadExcistingTournamentLabel.Size = new Size(405, 46);
            loadExcistingTournamentLabel.TabIndex = 25;
            loadExcistingTournamentLabel.Text = "Load Existing Tournament";
            // 
            // loadTournamentButton
            // 
            loadTournamentButton.FlatAppearance.BorderColor = Color.Silver;
            loadTournamentButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            loadTournamentButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(242, 242, 242);
            loadTournamentButton.FlatStyle = FlatStyle.Flat;
            loadTournamentButton.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            loadTournamentButton.ForeColor = SystemColors.MenuHighlight;
            loadTournamentButton.Location = new Point(364, 316);
            loadTournamentButton.Name = "loadTournamentButton";
            loadTournamentButton.Size = new Size(272, 70);
            loadTournamentButton.TabIndex = 29;
            loadTournamentButton.Text = "Load Tournament";
            loadTournamentButton.UseVisualStyleBackColor = true;
            // 
            // createTournamentButton
            // 
            createTournamentButton.FlatAppearance.BorderColor = Color.Silver;
            createTournamentButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            createTournamentButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(242, 242, 242);
            createTournamentButton.FlatStyle = FlatStyle.Flat;
            createTournamentButton.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            createTournamentButton.ForeColor = SystemColors.MenuHighlight;
            createTournamentButton.Location = new Point(339, 431);
            createTournamentButton.Name = "createTournamentButton";
            createTournamentButton.Size = new Size(322, 132);
            createTournamentButton.TabIndex = 30;
            createTournamentButton.Text = "Create Tournament";
            createTournamentButton.UseVisualStyleBackColor = true;
            // 
            // TournamentDashboardForm
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1010, 610);
            Controls.Add(createTournamentButton);
            Controls.Add(loadTournamentButton);
            Controls.Add(loadExcistingTouurnamentValue);
            Controls.Add(loadExcistingTournamentLabel);
            Controls.Add(createTeamLabel);
            Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(6, 6, 6, 6);
            Name = "TournamentDashboardForm";
            Text = "Tournament Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createTeamLabel;
        private ComboBox loadExcistingTouurnamentValue;
        private Label loadExcistingTournamentLabel;
        private Button loadTournamentButton;
        private Button createTournamentButton;
    }
}