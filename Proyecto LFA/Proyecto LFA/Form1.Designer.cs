
namespace Proyecto_LFA
{
    partial class Form1
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
            this.StartupPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.SelectAuto = new System.Windows.Forms.Button();
            this.txtWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddMT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelA = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSwitchSBS = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCintaA = new System.Windows.Forms.Label();
            this.btnStartA = new System.Windows.Forms.Button();
            this.StartupPanel.SuspendLayout();
            this.PanelA.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartupPanel
            // 
            this.StartupPanel.Controls.Add(this.button2);
            this.StartupPanel.Controls.Add(this.SelectAuto);
            this.StartupPanel.Controls.Add(this.txtWord);
            this.StartupPanel.Controls.Add(this.btnAddMT);
            this.StartupPanel.Controls.Add(this.label1);
            this.StartupPanel.Controls.Add(this.label2);
            this.StartupPanel.Location = new System.Drawing.Point(12, 12);
            this.StartupPanel.Name = "StartupPanel";
            this.StartupPanel.Size = new System.Drawing.Size(397, 208);
            this.StartupPanel.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(237, 110);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 68);
            this.button2.TabIndex = 5;
            this.button2.Text = "Modo Paso-A-Paso";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // SelectAuto
            // 
            this.SelectAuto.Location = new System.Drawing.Point(14, 110);
            this.SelectAuto.Name = "SelectAuto";
            this.SelectAuto.Size = new System.Drawing.Size(107, 68);
            this.SelectAuto.TabIndex = 4;
            this.SelectAuto.Text = "Modo Automático";
            this.SelectAuto.UseVisualStyleBackColor = true;
            this.SelectAuto.Click += new System.EventHandler(this.SelectAuto_Click);
            // 
            // txtWord
            // 
            this.txtWord.Location = new System.Drawing.Point(164, 59);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(180, 27);
            this.txtWord.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Palabra a analizar:";
            // 
            // btnAddMT
            // 
            this.btnAddMT.Location = new System.Drawing.Point(164, 20);
            this.btnAddMT.Name = "btnAddMT";
            this.btnAddMT.Size = new System.Drawing.Size(180, 29);
            this.btnAddMT.TabIndex = 1;
            this.btnAddMT.Text = "Ingresar una máquina";
            this.btnAddMT.UseVisualStyleBackColor = true;
            this.btnAddMT.Click += new System.EventHandler(this.btnAddMT_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingreso de Máquina:";
            // 
            // PanelA
            // 
            this.PanelA.Controls.Add(this.btnStartA);
            this.PanelA.Controls.Add(this.lblCintaA);
            this.PanelA.Controls.Add(this.label3);
            this.PanelA.Controls.Add(this.btnSwitchSBS);
            this.PanelA.Controls.Add(this.btnReset);
            this.PanelA.Location = new System.Drawing.Point(415, 12);
            this.PanelA.Name = "PanelA";
            this.PanelA.Size = new System.Drawing.Size(476, 208);
            this.PanelA.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(121, 130);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(94, 29);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reiniciar";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // btnSwitchSBS
            // 
            this.btnSwitchSBS.Location = new System.Drawing.Point(221, 130);
            this.btnSwitchSBS.Name = "btnSwitchSBS";
            this.btnSwitchSBS.Size = new System.Drawing.Size(176, 29);
            this.btnSwitchSBS.TabIndex = 1;
            this.btnSwitchSBS.Text = "Intentar Paso-A-Paso";
            this.btnSwitchSBS.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cinta:";
            // 
            // lblCintaA
            // 
            this.lblCintaA.AutoSize = true;
            this.lblCintaA.Location = new System.Drawing.Point(82, 29);
            this.lblCintaA.Name = "lblCintaA";
            this.lblCintaA.Size = new System.Drawing.Size(0, 20);
            this.lblCintaA.TabIndex = 7;
            // 
            // btnStartA
            // 
            this.btnStartA.Location = new System.Drawing.Point(21, 130);
            this.btnStartA.Name = "btnStartA";
            this.btnStartA.Size = new System.Drawing.Size(94, 29);
            this.btnStartA.TabIndex = 8;
            this.btnStartA.Text = "Analizar";
            this.btnStartA.UseVisualStyleBackColor = true;
            this.btnStartA.Click += new System.EventHandler(this.btnStartA_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 243);
            this.Controls.Add(this.PanelA);
            this.Controls.Add(this.StartupPanel);
            this.Name = "Form1";
            this.Text = "Analizador Máquinas de Turing";
            this.StartupPanel.ResumeLayout(false);
            this.StartupPanel.PerformLayout();
            this.PanelA.ResumeLayout(false);
            this.PanelA.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel StartupPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddMT;
        private System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button SelectAuto;
        private System.Windows.Forms.Panel PanelA;
        private System.Windows.Forms.Button btnSwitchSBS;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCintaA;
        private System.Windows.Forms.Button btnStartA;
    }
}

