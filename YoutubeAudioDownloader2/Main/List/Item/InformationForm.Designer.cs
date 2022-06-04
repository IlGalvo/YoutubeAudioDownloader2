﻿namespace YoutubeAudioDownloader2.Main.List.Item
{
    partial class InformationForm
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
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.groupBoxDescription = new System.Windows.Forms.GroupBox();
            this.groupBoxStatistics = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelStatistics = new System.Windows.Forms.TableLayoutPanel();
            this.panelViewsVerified = new System.Windows.Forms.Panel();
            this.labelViews = new System.Windows.Forms.Label();
            this.labelOfficial = new System.Windows.Forms.Label();
            this.labelOfficialStatic = new System.Windows.Forms.Label();
            this.labelViewsStatic = new System.Windows.Forms.Label();
            this.panelLikesDislikes = new System.Windows.Forms.Panel();
            this.labelDislikes = new System.Windows.Forms.Label();
            this.labelLikesStatic = new System.Windows.Forms.Label();
            this.labelDislikesStatic = new System.Windows.Forms.Label();
            this.labelLikes = new System.Windows.Forms.Label();
            this.groupBoxDescription.SuspendLayout();
            this.groupBoxStatistics.SuspendLayout();
            this.tableLayoutPanelStatistics.SuspendLayout();
            this.panelViewsVerified.SuspendLayout();
            this.panelLikesDislikes.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.AutoWordSelection = true;
            this.richTextBoxDescription.BackColor = System.Drawing.Color.White;
            this.richTextBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxDescription.Location = new System.Drawing.Point(3, 23);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.ReadOnly = true;
            this.richTextBoxDescription.Size = new System.Drawing.Size(449, 304);
            this.richTextBoxDescription.TabIndex = 1;
            this.richTextBoxDescription.Text = "";
            this.richTextBoxDescription.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.RichTextBoxDescription_LinkClicked);
            // 
            // groupBoxDescription
            // 
            this.groupBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDescription.Controls.Add(this.richTextBoxDescription);
            this.groupBoxDescription.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDescription.Name = "groupBoxDescription";
            this.groupBoxDescription.Size = new System.Drawing.Size(455, 330);
            this.groupBoxDescription.TabIndex = 0;
            this.groupBoxDescription.TabStop = false;
            this.groupBoxDescription.Text = "Descrizione";
            // 
            // groupBoxStatistics
            // 
            this.groupBoxStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxStatistics.Controls.Add(this.tableLayoutPanelStatistics);
            this.groupBoxStatistics.Location = new System.Drawing.Point(12, 348);
            this.groupBoxStatistics.Name = "groupBoxStatistics";
            this.groupBoxStatistics.Size = new System.Drawing.Size(452, 90);
            this.groupBoxStatistics.TabIndex = 2;
            this.groupBoxStatistics.TabStop = false;
            this.groupBoxStatistics.Text = "Statistiche";
            // 
            // tableLayoutPanelStatistics
            // 
            this.tableLayoutPanelStatistics.ColumnCount = 2;
            this.tableLayoutPanelStatistics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelStatistics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelStatistics.Controls.Add(this.panelViewsVerified, 1, 0);
            this.tableLayoutPanelStatistics.Controls.Add(this.panelLikesDislikes, 0, 0);
            this.tableLayoutPanelStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelStatistics.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanelStatistics.Name = "tableLayoutPanelStatistics";
            this.tableLayoutPanelStatistics.RowCount = 1;
            this.tableLayoutPanelStatistics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelStatistics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanelStatistics.Size = new System.Drawing.Size(446, 64);
            this.tableLayoutPanelStatistics.TabIndex = 3;
            // 
            // panelViewsVerified
            // 
            this.panelViewsVerified.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelViewsVerified.Controls.Add(this.labelViews);
            this.panelViewsVerified.Controls.Add(this.labelOfficial);
            this.panelViewsVerified.Controls.Add(this.labelOfficialStatic);
            this.panelViewsVerified.Controls.Add(this.labelViewsStatic);
            this.panelViewsVerified.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelViewsVerified.Location = new System.Drawing.Point(226, 3);
            this.panelViewsVerified.Name = "panelViewsVerified";
            this.panelViewsVerified.Size = new System.Drawing.Size(217, 58);
            this.panelViewsVerified.TabIndex = 9;
            // 
            // labelViews
            // 
            this.labelViews.AutoSize = true;
            this.labelViews.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelViews.Location = new System.Drawing.Point(105, 8);
            this.labelViews.Name = "labelViews";
            this.labelViews.Size = new System.Drawing.Size(91, 17);
            this.labelViews.TabIndex = 11;
            this.labelViews.Text = "Visualizzazioni";
            // 
            // labelOfficial
            // 
            this.labelOfficial.AutoSize = true;
            this.labelOfficial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelOfficial.Location = new System.Drawing.Point(105, 31);
            this.labelOfficial.Name = "labelOfficial";
            this.labelOfficial.Size = new System.Drawing.Size(54, 17);
            this.labelOfficial.TabIndex = 13;
            this.labelOfficial.Text = "Ufficiale";
            // 
            // labelOfficialStatic
            // 
            this.labelOfficialStatic.AutoSize = true;
            this.labelOfficialStatic.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelOfficialStatic.Location = new System.Drawing.Point(3, 31);
            this.labelOfficialStatic.Name = "labelOfficialStatic";
            this.labelOfficialStatic.Size = new System.Drawing.Size(57, 17);
            this.labelOfficialStatic.TabIndex = 12;
            this.labelOfficialStatic.Text = "Ufficiale:";
            // 
            // labelViewsStatic
            // 
            this.labelViewsStatic.AutoSize = true;
            this.labelViewsStatic.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelViewsStatic.Location = new System.Drawing.Point(3, 8);
            this.labelViewsStatic.Name = "labelViewsStatic";
            this.labelViewsStatic.Size = new System.Drawing.Size(96, 17);
            this.labelViewsStatic.TabIndex = 10;
            this.labelViewsStatic.Text = "Visualizzazioni:";
            // 
            // panelLikesDislikes
            // 
            this.panelLikesDislikes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelLikesDislikes.Controls.Add(this.labelDislikes);
            this.panelLikesDislikes.Controls.Add(this.labelLikesStatic);
            this.panelLikesDislikes.Controls.Add(this.labelDislikesStatic);
            this.panelLikesDislikes.Controls.Add(this.labelLikes);
            this.panelLikesDislikes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLikesDislikes.Location = new System.Drawing.Point(3, 3);
            this.panelLikesDislikes.Name = "panelLikesDislikes";
            this.panelLikesDislikes.Size = new System.Drawing.Size(217, 58);
            this.panelLikesDislikes.TabIndex = 4;
            // 
            // labelDislikes
            // 
            this.labelDislikes.AutoSize = true;
            this.labelDislikes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDislikes.Location = new System.Drawing.Point(100, 31);
            this.labelDislikes.Name = "labelDislikes";
            this.labelDislikes.Size = new System.Drawing.Size(86, 17);
            this.labelDislikes.TabIndex = 8;
            this.labelDislikes.Text = "Non mi piace";
            // 
            // labelLikesStatic
            // 
            this.labelLikesStatic.AutoSize = true;
            this.labelLikesStatic.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelLikesStatic.Location = new System.Drawing.Point(3, 8);
            this.labelLikesStatic.Name = "labelLikesStatic";
            this.labelLikesStatic.Size = new System.Drawing.Size(61, 17);
            this.labelLikesStatic.TabIndex = 5;
            this.labelLikesStatic.Text = "Mi piace:";
            // 
            // labelDislikesStatic
            // 
            this.labelDislikesStatic.AutoSize = true;
            this.labelDislikesStatic.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDislikesStatic.Location = new System.Drawing.Point(3, 31);
            this.labelDislikesStatic.Name = "labelDislikesStatic";
            this.labelDislikesStatic.Size = new System.Drawing.Size(91, 17);
            this.labelDislikesStatic.TabIndex = 7;
            this.labelDislikesStatic.Text = "Non mi piace:";
            // 
            // labelLikes
            // 
            this.labelLikes.AutoSize = true;
            this.labelLikes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelLikes.Location = new System.Drawing.Point(100, 8);
            this.labelLikes.Name = "labelLikes";
            this.labelLikes.Size = new System.Drawing.Size(58, 17);
            this.labelLikes.TabIndex = 6;
            this.labelLikes.Text = "Mi piace";
            // 
            // InformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(479, 450);
            this.Controls.Add(this.groupBoxStatistics);
            this.Controls.Add(this.groupBoxDescription);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = global::YoutubeAudioDownloader2.Properties.Resources.Icon;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MinimumSize = new System.Drawing.Size(470, 377);
            this.Name = "InformationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Youtube Audio Downloader 2";
            this.Load += new System.EventHandler(this.InformationForm_Load);
            this.groupBoxDescription.ResumeLayout(false);
            this.groupBoxStatistics.ResumeLayout(false);
            this.tableLayoutPanelStatistics.ResumeLayout(false);
            this.panelViewsVerified.ResumeLayout(false);
            this.panelViewsVerified.PerformLayout();
            this.panelLikesDislikes.ResumeLayout(false);
            this.panelLikesDislikes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.GroupBox groupBoxDescription;
        private System.Windows.Forms.GroupBox groupBoxStatistics;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelStatistics;
        private System.Windows.Forms.Panel panelViewsVerified;
        private System.Windows.Forms.Label labelViews;
        private System.Windows.Forms.Label labelOfficial;
        private System.Windows.Forms.Label labelOfficialStatic;
        private System.Windows.Forms.Label labelViewsStatic;
        private System.Windows.Forms.Panel panelLikesDislikes;
        private System.Windows.Forms.Label labelDislikes;
        private System.Windows.Forms.Label labelLikesStatic;
        private System.Windows.Forms.Label labelDislikesStatic;
        private System.Windows.Forms.Label labelLikes;
    }
}