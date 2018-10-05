namespace CodingExercise.PayslipGenerator
{
    partial class PayslipForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.lblTaxType = new System.Windows.Forms.Label();
            this.lblPayslipType = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.employeesGridView = new System.Windows.Forms.DataGridView();
            this.payslipsGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.employeesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.payslipsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(265, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(282, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "MYOB Payslip Generator";
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFilePath.Location = new System.Drawing.Point(40, 81);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(67, 17);
            this.lblFilePath.TabIndex = 1;
            this.lblFilePath.Text = "File Path:";
            // 
            // lblTaxType
            // 
            this.lblTaxType.AutoSize = true;
            this.lblTaxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTaxType.Location = new System.Drawing.Point(40, 134);
            this.lblTaxType.Name = "lblTaxType";
            this.lblTaxType.Size = new System.Drawing.Size(144, 17);
            this.lblTaxType.TabIndex = 2;
            this.lblTaxType.Text = "Tax Calculation Type:";
            // 
            // lblPayslipType
            // 
            this.lblPayslipType.AutoSize = true;
            this.lblPayslipType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPayslipType.Location = new System.Drawing.Point(353, 135);
            this.lblPayslipType.Name = "lblPayslipType";
            this.lblPayslipType.Size = new System.Drawing.Size(166, 17);
            this.lblPayslipType.TabIndex = 3;
            this.lblPayslipType.Text = "Payslip Calculation Type:";
            this.lblPayslipType.Click += new System.EventHandler(this.lblPayslipType_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(104, 81);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(477, 20);
            this.txtFilePath.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(181, 133);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(166, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(516, 134);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(157, 21);
            this.comboBox2.TabIndex = 6;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBrowse.Location = new System.Drawing.Point(598, 74);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 32);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpload.Location = new System.Drawing.Point(689, 73);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 32);
            this.btnUpload.TabIndex = 8;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCalculate.Location = new System.Drawing.Point(689, 125);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 34);
            this.btnCalculate.TabIndex = 9;
            this.btnCalculate.Text = "Start";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.button3_Click);
            // 
            // employeesGridView
            // 
            this.employeesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeesGridView.Location = new System.Drawing.Point(43, 174);
            this.employeesGridView.Name = "employeesGridView";
            this.employeesGridView.Size = new System.Drawing.Size(342, 264);
            this.employeesGridView.TabIndex = 10;
            // 
            // payslipsGridView
            // 
            this.payslipsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.payslipsGridView.Location = new System.Drawing.Point(430, 174);
            this.payslipsGridView.Name = "payslipsGridView";
            this.payslipsGridView.Size = new System.Drawing.Size(334, 264);
            this.payslipsGridView.TabIndex = 11;
            // 
            // PayslipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 474);
            this.Controls.Add(this.payslipsGridView);
            this.Controls.Add(this.employeesGridView);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.lblPayslipType);
            this.Controls.Add(this.lblTaxType);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.lblTitle);
            this.Name = "PayslipForm";
            this.Text = "PayslipForm";
            ((System.ComponentModel.ISupportInitialize)(this.employeesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.payslipsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Label lblTaxType;
        private System.Windows.Forms.Label lblPayslipType;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.DataGridView employeesGridView;
        private System.Windows.Forms.DataGridView payslipsGridView;
    }
}