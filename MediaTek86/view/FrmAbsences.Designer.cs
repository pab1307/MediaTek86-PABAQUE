namespace MediaTek86.view
{
    partial class FrmAbsences
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
            this.grpAbsences = new System.Windows.Forms.GroupBox();
            this.btnModifAbsence = new System.Windows.Forms.Button();
            this.btnSupprAbsence = new System.Windows.Forms.Button();
            this.btnAjouterAbsence = new System.Windows.Forms.Button();
            this.dgvAbsences = new System.Windows.Forms.DataGridView();
            this.grpAjouterAbsence = new System.Windows.Forms.GroupBox();
            this.dtpDateFin = new System.Windows.Forms.DateTimePicker();
            this.dtpDateDebut = new System.Windows.Forms.DateTimePicker();
            this.btnEnregistrerAbs = new System.Windows.Forms.Button();
            this.btnAnnulerAbs = new System.Windows.Forms.Button();
            this.cmbMotif = new System.Windows.Forms.ComboBox();
            this.lblMotif = new System.Windows.Forms.Label();
            this.lblDateFin = new System.Windows.Forms.Label();
            this.lblDateDebut = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.grpAbsences.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsences)).BeginInit();
            this.grpAjouterAbsence.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAbsences
            // 
            this.grpAbsences.Controls.Add(this.btnModifAbsence);
            this.grpAbsences.Controls.Add(this.btnSupprAbsence);
            this.grpAbsences.Controls.Add(this.btnAjouterAbsence);
            this.grpAbsences.Controls.Add(this.dgvAbsences);
            this.grpAbsences.Location = new System.Drawing.Point(16, 15);
            this.grpAbsences.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpAbsences.Name = "grpAbsences";
            this.grpAbsences.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpAbsences.Size = new System.Drawing.Size(923, 503);
            this.grpAbsences.TabIndex = 0;
            this.grpAbsences.TabStop = false;
            this.grpAbsences.Text = "Absences";
            // 
            // btnModifAbsence
            // 
            this.btnModifAbsence.Location = new System.Drawing.Point(383, 452);
            this.btnModifAbsence.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModifAbsence.Name = "btnModifAbsence";
            this.btnModifAbsence.Size = new System.Drawing.Size(156, 28);
            this.btnModifAbsence.TabIndex = 5;
            this.btnModifAbsence.Text = "Modifier";
            this.btnModifAbsence.UseVisualStyleBackColor = true;
            this.btnModifAbsence.Click += new System.EventHandler(this.btnModifierAbsence_Click);
            // 
            // btnSupprAbsence
            // 
            this.btnSupprAbsence.Location = new System.Drawing.Point(639, 452);
            this.btnSupprAbsence.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSupprAbsence.Name = "btnSupprAbsence";
            this.btnSupprAbsence.Size = new System.Drawing.Size(156, 28);
            this.btnSupprAbsence.TabIndex = 4;
            this.btnSupprAbsence.Text = "Supprimer";
            this.btnSupprAbsence.UseVisualStyleBackColor = true;
            this.btnSupprAbsence.Click += new System.EventHandler(this.btnSupprAbsence_Click);
            // 
            // btnAjouterAbsence
            // 
            this.btnAjouterAbsence.Location = new System.Drawing.Point(127, 452);
            this.btnAjouterAbsence.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAjouterAbsence.Name = "btnAjouterAbsence";
            this.btnAjouterAbsence.Size = new System.Drawing.Size(156, 28);
            this.btnAjouterAbsence.TabIndex = 3;
            this.btnAjouterAbsence.Text = "Ajouter";
            this.btnAjouterAbsence.UseVisualStyleBackColor = true;
            this.btnAjouterAbsence.Click += new System.EventHandler(this.btnAjouterAbsence_Click);
            // 
            // dgvAbsences
            // 
            this.dgvAbsences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAbsences.Location = new System.Drawing.Point(8, 23);
            this.dgvAbsences.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvAbsences.Name = "dgvAbsences";
            this.dgvAbsences.RowHeadersWidth = 51;
            this.dgvAbsences.Size = new System.Drawing.Size(907, 406);
            this.dgvAbsences.TabIndex = 0;
            // 
            // grpAjouterAbsence
            // 
            this.grpAjouterAbsence.Controls.Add(this.dtpDateFin);
            this.grpAjouterAbsence.Controls.Add(this.dtpDateDebut);
            this.grpAjouterAbsence.Controls.Add(this.btnEnregistrerAbs);
            this.grpAjouterAbsence.Controls.Add(this.btnAnnulerAbs);
            this.grpAjouterAbsence.Controls.Add(this.cmbMotif);
            this.grpAjouterAbsence.Controls.Add(this.lblMotif);
            this.grpAjouterAbsence.Controls.Add(this.lblDateFin);
            this.grpAjouterAbsence.Controls.Add(this.lblDateDebut);
            this.grpAjouterAbsence.Location = new System.Drawing.Point(16, 539);
            this.grpAjouterAbsence.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpAjouterAbsence.Name = "grpAjouterAbsence";
            this.grpAjouterAbsence.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpAjouterAbsence.Size = new System.Drawing.Size(923, 135);
            this.grpAjouterAbsence.TabIndex = 1;
            this.grpAjouterAbsence.TabStop = false;
            this.grpAjouterAbsence.Text = "Ajouter absence";
            // 
            // dtpDateFin
            // 
            this.dtpDateFin.Location = new System.Drawing.Point(128, 81);
            this.dtpDateFin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDateFin.Name = "dtpDateFin";
            this.dtpDateFin.Size = new System.Drawing.Size(261, 22);
            this.dtpDateFin.TabIndex = 13;
            // 
            // dtpDateDebut
            // 
            this.dtpDateDebut.Location = new System.Drawing.Point(128, 38);
            this.dtpDateDebut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDateDebut.Name = "dtpDateDebut";
            this.dtpDateDebut.Size = new System.Drawing.Size(261, 22);
            this.dtpDateDebut.TabIndex = 12;
            // 
            // btnEnregistrerAbs
            // 
            this.btnEnregistrerAbs.Location = new System.Drawing.Point(495, 81);
            this.btnEnregistrerAbs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEnregistrerAbs.Name = "btnEnregistrerAbs";
            this.btnEnregistrerAbs.Size = new System.Drawing.Size(153, 28);
            this.btnEnregistrerAbs.TabIndex = 7;
            this.btnEnregistrerAbs.Text = "Enregistrer";
            this.btnEnregistrerAbs.UseVisualStyleBackColor = true;
            this.btnEnregistrerAbs.Click += new System.EventHandler(this.btnEnregistrerAbs_Click);
            // 
            // btnAnnulerAbs
            // 
            this.btnAnnulerAbs.Location = new System.Drawing.Point(656, 81);
            this.btnAnnulerAbs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAnnulerAbs.Name = "btnAnnulerAbs";
            this.btnAnnulerAbs.Size = new System.Drawing.Size(153, 28);
            this.btnAnnulerAbs.TabIndex = 6;
            this.btnAnnulerAbs.Text = "Annuler";
            this.btnAnnulerAbs.UseVisualStyleBackColor = true;
            this.btnAnnulerAbs.Click += new System.EventHandler(this.btnAnnulerAbs_Click);
            // 
            // cmbMotif
            // 
            this.cmbMotif.FormattingEnabled = true;
            this.cmbMotif.Location = new System.Drawing.Point(547, 38);
            this.cmbMotif.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbMotif.Name = "cmbMotif";
            this.cmbMotif.Size = new System.Drawing.Size(261, 24);
            this.cmbMotif.TabIndex = 5;
            // 
            // lblMotif
            // 
            this.lblMotif.AutoSize = true;
            this.lblMotif.Location = new System.Drawing.Point(491, 42);
            this.lblMotif.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMotif.Name = "lblMotif";
            this.lblMotif.Size = new System.Drawing.Size(41, 16);
            this.lblMotif.TabIndex = 2;
            this.lblMotif.Text = "Motif :";
            // 
            // lblDateFin
            // 
            this.lblDateFin.AutoSize = true;
            this.lblDateFin.Location = new System.Drawing.Point(32, 87);
            this.lblDateFin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateFin.Name = "lblDateFin";
            this.lblDateFin.Size = new System.Drawing.Size(58, 16);
            this.lblDateFin.TabIndex = 1;
            this.lblDateFin.Text = "Date fin :";
            // 
            // lblDateDebut
            // 
            this.lblDateDebut.AutoSize = true;
            this.lblDateDebut.Location = new System.Drawing.Point(32, 42);
            this.lblDateDebut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateDebut.Name = "lblDateDebut";
            this.lblDateDebut.Size = new System.Drawing.Size(79, 16);
            this.lblDateDebut.TabIndex = 0;
            this.lblDateDebut.Text = "Date début :";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FrmAbsences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 692);
            this.Controls.Add(this.grpAjouterAbsence);
            this.Controls.Add(this.grpAbsences);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmAbsences";
            this.Text = "Gestion des absences";
            this.grpAbsences.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsences)).EndInit();
            this.grpAjouterAbsence.ResumeLayout(false);
            this.grpAjouterAbsence.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAbsences;
        private System.Windows.Forms.DataGridView dgvAbsences;
        private System.Windows.Forms.Button btnModifAbsence;
        private System.Windows.Forms.Button btnSupprAbsence;
        private System.Windows.Forms.Button btnAjouterAbsence;
        private System.Windows.Forms.GroupBox grpAjouterAbsence;
        private System.Windows.Forms.Button btnAnnulerAbs;
        private System.Windows.Forms.ComboBox cmbMotif;
        private System.Windows.Forms.Label lblMotif;
        private System.Windows.Forms.Label lblDateFin;
        private System.Windows.Forms.Label lblDateDebut;
        private System.Windows.Forms.Button btnEnregistrerAbs;
        private System.Windows.Forms.DateTimePicker dtpDateFin;
        private System.Windows.Forms.DateTimePicker dtpDateDebut;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}