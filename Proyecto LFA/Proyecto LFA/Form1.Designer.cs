
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
            this.btnAddMT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PanelA = new System.Windows.Forms.Panel();
            this.PanelP = new System.Windows.Forms.Panel();
            this.lblTransition = new System.Windows.Forms.Label();
            this.lblCurrentState = new System.Windows.Forms.Label();
            this.lblHeaderPos = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblCintaP = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAuto = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnStartA = new System.Windows.Forms.Button();
            this.lblCintaA = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.StartupPanel.SuspendLayout();
            this.PanelA.SuspendLayout();
            this.PanelP.SuspendLayout();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Palabra a analizar:";
            // 
            // PanelA
            // 
            this.PanelA.Controls.Add(this.btnStartA);
            this.PanelA.Controls.Add(this.lblCintaA);
            this.PanelA.Controls.Add(this.label3);
            this.PanelA.Controls.Add(this.btnSwitch);
            this.PanelA.Controls.Add(this.btnReset);
            this.PanelA.Enabled = false;
            this.PanelA.Location = new System.Drawing.Point(415, 12);
            this.PanelA.Name = "PanelA";
            this.PanelA.Size = new System.Drawing.Size(476, 208);
            this.PanelA.TabIndex = 1;
            this.PanelA.Visible = false;
            // 
            // PanelP
            // 
            this.PanelP.Controls.Add(this.lblTransition);
            this.PanelP.Controls.Add(this.lblCurrentState);
            this.PanelP.Controls.Add(this.lblHeaderPos);
            this.PanelP.Controls.Add(this.label9);
            this.PanelP.Controls.Add(this.label8);
            this.PanelP.Controls.Add(this.label7);
            this.PanelP.Controls.Add(this.btnNext);
            this.PanelP.Controls.Add(this.lblCintaP);
            this.PanelP.Controls.Add(this.label6);
            this.PanelP.Controls.Add(this.btnAuto);
            this.PanelP.Controls.Add(this.btnRestart);
            this.PanelP.Enabled = false;
            this.PanelP.Location = new System.Drawing.Point(415, 12);
            this.PanelP.Name = "PanelP";
            this.PanelP.Size = new System.Drawing.Size(476, 208);
            this.PanelP.TabIndex = 9;
            this.PanelP.Visible = false;
            // 
            // lblTransition
            // 
            this.lblTransition.AutoSize = true;
            this.lblTransition.Location = new System.Drawing.Point(172, 99);
            this.lblTransition.Name = "lblTransition";
            this.lblTransition.Size = new System.Drawing.Size(0, 20);
            this.lblTransition.TabIndex = 14;
            // 
            // lblCurrentState
            // 
            this.lblCurrentState.AutoSize = true;
            this.lblCurrentState.Location = new System.Drawing.Point(172, 79);
            this.lblCurrentState.Name = "lblCurrentState";
            this.lblCurrentState.Size = new System.Drawing.Size(0, 20);
            this.lblCurrentState.TabIndex = 13;
            // 
            // lblHeaderPos
            // 
            this.lblHeaderPos.AutoSize = true;
            this.lblHeaderPos.Location = new System.Drawing.Point(172, 59);
            this.lblHeaderPos.Name = "lblHeaderPos";
            this.lblHeaderPos.Size = new System.Drawing.Size(0, 20);
            this.lblHeaderPos.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 20);
            this.label9.TabIndex = 11;
            this.label9.Text = "Transición Realizada:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "Estado Actual";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Posición del Cabezal";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(21, 130);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(94, 29);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Analizar";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // lblCintaP
            // 
            this.lblCintaP.AutoSize = true;
            this.lblCintaP.Location = new System.Drawing.Point(82, 29);
            this.lblCintaP.Name = "lblCintaP";
            this.lblCintaP.Size = new System.Drawing.Size(0, 20);
            this.lblCintaP.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Cinta:";
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(221, 130);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(176, 29);
            this.btnAuto.TabIndex = 1;
            this.btnAuto.Text = "Intentar Paso-A-Paso";
            this.btnAuto.UseVisualStyleBackColor = true;
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(121, 130);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(94, 29);
            this.btnRestart.TabIndex = 0;
            this.btnRestart.Text = "Reiniciar";
            this.btnRestart.UseVisualStyleBackColor = true;
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
            // lblCintaA
            // 
            this.lblCintaA.AutoSize = true;
            this.lblCintaA.Location = new System.Drawing.Point(82, 29);
            this.lblCintaA.Name = "lblCintaA";
            this.lblCintaA.Size = new System.Drawing.Size(0, 20);
            this.lblCintaA.TabIndex = 7;
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
            // btnSwitch
            // 
            this.btnSwitch.Location = new System.Drawing.Point(221, 130);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(176, 29);
            this.btnSwitch.TabIndex = 1;
            this.btnSwitch.Text = "Intentar Paso-A-Paso";
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Visible = false;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(121, 130);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(94, 29);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reiniciar";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Berlin Sans FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(521, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(279, 33);
            this.label4.TabIndex = 1;
            this.label4.Text = "Analizador de Turing";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 243);
            this.Controls.Add(this.PanelP);
            this.Controls.Add(this.PanelA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StartupPanel);
            this.Name = "Form1";
            this.Text = "Analizador Máquinas de Turing";
            this.StartupPanel.ResumeLayout(false);
            this.StartupPanel.PerformLayout();
            this.PanelA.ResumeLayout(false);
            this.PanelA.PerformLayout();
            this.PanelP.ResumeLayout(false);
            this.PanelP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button btnSwitch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCintaA;
        private System.Windows.Forms.Button btnStartA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel PanelP;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblCintaP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCurrentState;
        private System.Windows.Forms.Label lblHeaderPos;
        private System.Windows.Forms.Label lblTransition;
    }
}

