
namespace SpecFlowCalculator
{
    partial class CalculatorForm
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
            this.label_firstNumber = new System.Windows.Forms.Label();
            this.textBox_firstNumber = new System.Windows.Forms.TextBox();
            this.textBox_secondNumber = new System.Windows.Forms.TextBox();
            this.label_secondNumber = new System.Windows.Forms.Label();
            this.button_add = new System.Windows.Forms.Button();
            this.button_subtract = new System.Windows.Forms.Button();
            this.button_multiply = new System.Windows.Forms.Button();
            this.button_divide = new System.Windows.Forms.Button();
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.label_result = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_Calculator = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_firstNumber
            // 
            this.label_firstNumber.AutoSize = true;
            this.label_firstNumber.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_firstNumber.Location = new System.Drawing.Point(12, 97);
            this.label_firstNumber.Name = "label_firstNumber";
            this.label_firstNumber.Size = new System.Drawing.Size(102, 19);
            this.label_firstNumber.TabIndex = 0;
            this.label_firstNumber.Text = "First number:";
            // 
            // textBox_firstNumber
            // 
            this.textBox_firstNumber.Location = new System.Drawing.Point(142, 93);
            this.textBox_firstNumber.Name = "textBox_firstNumber";
            this.textBox_firstNumber.Size = new System.Drawing.Size(100, 23);
            this.textBox_firstNumber.TabIndex = 1;
            // 
            // textBox_secondNumber
            // 
            this.textBox_secondNumber.Location = new System.Drawing.Point(142, 122);
            this.textBox_secondNumber.Name = "textBox_secondNumber";
            this.textBox_secondNumber.Size = new System.Drawing.Size(100, 23);
            this.textBox_secondNumber.TabIndex = 3;
            // 
            // label_secondNumber
            // 
            this.label_secondNumber.AutoSize = true;
            this.label_secondNumber.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_secondNumber.Location = new System.Drawing.Point(12, 126);
            this.label_secondNumber.Name = "label_secondNumber";
            this.label_secondNumber.Size = new System.Drawing.Size(124, 19);
            this.label_secondNumber.TabIndex = 2;
            this.label_secondNumber.Text = "Second number:";
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(50, 160);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 23);
            this.button_add.TabIndex = 4;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_subtract
            // 
            this.button_subtract.Location = new System.Drawing.Point(131, 160);
            this.button_subtract.Name = "button_subtract";
            this.button_subtract.Size = new System.Drawing.Size(75, 23);
            this.button_subtract.TabIndex = 5;
            this.button_subtract.Text = "Subtract";
            this.button_subtract.UseVisualStyleBackColor = true;
            this.button_subtract.Click += new System.EventHandler(this.button_subtract_Click);
            // 
            // button_multiply
            // 
            this.button_multiply.Location = new System.Drawing.Point(50, 189);
            this.button_multiply.Name = "button_multiply";
            this.button_multiply.Size = new System.Drawing.Size(75, 23);
            this.button_multiply.TabIndex = 6;
            this.button_multiply.Text = "Multiply";
            this.button_multiply.UseVisualStyleBackColor = true;
            this.button_multiply.Click += new System.EventHandler(this.button_multiply_Click);
            // 
            // button_divide
            // 
            this.button_divide.Location = new System.Drawing.Point(131, 189);
            this.button_divide.Name = "button_divide";
            this.button_divide.Size = new System.Drawing.Size(75, 23);
            this.button_divide.TabIndex = 7;
            this.button_divide.Text = "Divide";
            this.button_divide.UseVisualStyleBackColor = true;
            this.button_divide.Click += new System.EventHandler(this.button_divide_Click);
            // 
            // textBox_result
            // 
            this.textBox_result.Location = new System.Drawing.Point(104, 231);
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.ReadOnly = true;
            this.textBox_result.Size = new System.Drawing.Size(100, 23);
            this.textBox_result.TabIndex = 9;
            // 
            // label_result
            // 
            this.label_result.AutoSize = true;
            this.label_result.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_result.Location = new System.Drawing.Point(50, 235);
            this.label_result.Name = "label_result";
            this.label_result.Size = new System.Drawing.Size(57, 19);
            this.label_result.TabIndex = 8;
            this.label_result.Text = "Result:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SpecFlowCalculator.Properties.Resources.Logo_1280;
            this.pictureBox1.Location = new System.Drawing.Point(16, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(226, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label_Calculator
            // 
            this.label_Calculator.AutoSize = true;
            this.label_Calculator.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_Calculator.Location = new System.Drawing.Point(123, 54);
            this.label_Calculator.Name = "label_Calculator";
            this.label_Calculator.Size = new System.Drawing.Size(81, 19);
            this.label_Calculator.TabIndex = 11;
            this.label_Calculator.Text = "Calculator";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(260, 277);
            this.Controls.Add(this.label_Calculator);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox_result);
            this.Controls.Add(this.label_result);
            this.Controls.Add(this.button_divide);
            this.Controls.Add(this.button_multiply);
            this.Controls.Add(this.button_subtract);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.textBox_secondNumber);
            this.Controls.Add(this.label_secondNumber);
            this.Controls.Add(this.textBox_firstNumber);
            this.Controls.Add(this.label_firstNumber);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_firstNumber;
        private System.Windows.Forms.TextBox textBox_firstNumber;
        private System.Windows.Forms.TextBox textBox_secondNumber;
        private System.Windows.Forms.Label label_secondNumber;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_subtract;
        private System.Windows.Forms.Button button_multiply;
        private System.Windows.Forms.Button button_divide;
        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.Label label_result;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_Calculator;
    }
}

