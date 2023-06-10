namespace TrackerUI
{
    partial class CreatePrize
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
            placeNumberValue = new TextBox();
            placeNumberLabel = new Label();
            placeNameValue = new TextBox();
            placeNameLabel = new Label();
            priceAmountValue = new TextBox();
            priceAmountLabel = new Label();
            pricePercentageValue = new TextBox();
            pricePercentageLabel = new Label();
            orLabel = new Label();
            createPrizeButton = new Button();
            SuspendLayout();
            // 
            // createTeamLabel
            // 
            createTeamLabel.AutoSize = true;
            createTeamLabel.Font = new Font("Segoe UI Light", 28.2F, FontStyle.Regular, GraphicsUnit.Point);
            createTeamLabel.ForeColor = SystemColors.MenuHighlight;
            createTeamLabel.Location = new Point(22, 23);
            createTeamLabel.Name = "createTeamLabel";
            createTeamLabel.Size = new Size(267, 62);
            createTeamLabel.TabIndex = 13;
            createTeamLabel.Text = "Create Prize";
            // 
            // placeNumberValue
            // 
            placeNumberValue.Location = new Point(321, 153);
            placeNumberValue.Name = "placeNumberValue";
            placeNumberValue.Size = new Size(274, 43);
            placeNumberValue.TabIndex = 15;
            // 
            // placeNumberLabel
            // 
            placeNumberLabel.AutoSize = true;
            placeNumberLabel.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            placeNumberLabel.ForeColor = SystemColors.MenuHighlight;
            placeNumberLabel.Location = new Point(59, 150);
            placeNumberLabel.Name = "placeNumberLabel";
            placeNumberLabel.Size = new Size(230, 46);
            placeNumberLabel.TabIndex = 14;
            placeNumberLabel.Text = "Place Number";
            // 
            // placeNameValue
            // 
            placeNameValue.Location = new Point(321, 237);
            placeNameValue.Name = "placeNameValue";
            placeNameValue.Size = new Size(274, 43);
            placeNameValue.TabIndex = 17;
            // 
            // placeNameLabel
            // 
            placeNameLabel.AutoSize = true;
            placeNameLabel.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            placeNameLabel.ForeColor = SystemColors.MenuHighlight;
            placeNameLabel.Location = new Point(59, 234);
            placeNameLabel.Name = "placeNameLabel";
            placeNameLabel.Size = new Size(196, 46);
            placeNameLabel.TabIndex = 16;
            placeNameLabel.Text = "Place Name";
            // 
            // priceAmountValue
            // 
            priceAmountValue.Location = new Point(321, 321);
            priceAmountValue.Name = "priceAmountValue";
            priceAmountValue.Size = new Size(274, 43);
            priceAmountValue.TabIndex = 19;
            // 
            // priceAmountLabel
            // 
            priceAmountLabel.AutoSize = true;
            priceAmountLabel.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            priceAmountLabel.ForeColor = SystemColors.MenuHighlight;
            priceAmountLabel.Location = new Point(59, 318);
            priceAmountLabel.Name = "priceAmountLabel";
            priceAmountLabel.Size = new Size(222, 46);
            priceAmountLabel.TabIndex = 18;
            priceAmountLabel.Text = "Prize Amount";
            // 
            // pricePercentageValue
            // 
            pricePercentageValue.Location = new Point(321, 467);
            pricePercentageValue.Name = "pricePercentageValue";
            pricePercentageValue.Size = new Size(274, 43);
            pricePercentageValue.TabIndex = 21;
            // 
            // pricePercentageLabel
            // 
            pricePercentageLabel.AutoSize = true;
            pricePercentageLabel.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            pricePercentageLabel.ForeColor = SystemColors.MenuHighlight;
            pricePercentageLabel.Location = new Point(59, 464);
            pricePercentageLabel.Name = "pricePercentageLabel";
            pricePercentageLabel.Size = new Size(269, 46);
            pricePercentageLabel.TabIndex = 20;
            pricePercentageLabel.Text = "Prize Percentage";
            // 
            // orLabel
            // 
            orLabel.AutoSize = true;
            orLabel.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            orLabel.ForeColor = SystemColors.MenuHighlight;
            orLabel.Location = new Point(283, 392);
            orLabel.Name = "orLabel";
            orLabel.Size = new Size(104, 46);
            orLabel.TabIndex = 22;
            orLabel.Text = "- Or -";
            // 
            // createPrizeButton
            // 
            createPrizeButton.FlatAppearance.BorderColor = Color.Silver;
            createPrizeButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            createPrizeButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(242, 242, 242);
            createPrizeButton.FlatStyle = FlatStyle.Flat;
            createPrizeButton.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            createPrizeButton.ForeColor = SystemColors.MenuHighlight;
            createPrizeButton.Location = new Point(221, 552);
            createPrizeButton.Name = "createPrizeButton";
            createPrizeButton.Size = new Size(272, 70);
            createPrizeButton.TabIndex = 28;
            createPrizeButton.Text = "Create Prize";
            createPrizeButton.UseVisualStyleBackColor = true;
            // 
            // CreatePrize
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(708, 670);
            Controls.Add(createPrizeButton);
            Controls.Add(orLabel);
            Controls.Add(pricePercentageValue);
            Controls.Add(pricePercentageLabel);
            Controls.Add(priceAmountValue);
            Controls.Add(priceAmountLabel);
            Controls.Add(placeNameValue);
            Controls.Add(placeNameLabel);
            Controls.Add(placeNumberValue);
            Controls.Add(placeNumberLabel);
            Controls.Add(createTeamLabel);
            Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(6, 6, 6, 6);
            Name = "CreatePrize";
            Text = "Create Prize";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createTeamLabel;
        private TextBox placeNumberValue;
        private Label placeNumberLabel;
        private TextBox placeNameValue;
        private Label placeNameLabel;
        private TextBox priceAmountValue;
        private Label priceAmountLabel;
        private TextBox pricePercentageValue;
        private Label pricePercentageLabel;
        private Label orLabel;
        private Button createPrizeButton;
    }
}