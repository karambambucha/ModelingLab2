
namespace ModelingLab2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.modelingTime = new System.Windows.Forms.NumericUpDown();
            this.milliseconds = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PlusMinute = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.clientIntervalTime = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.timeToWarehouse = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.timeFromWarehouse = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.calcTime = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.maxClients = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.clerkNum = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.modelingTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.milliseconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientIntervalTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeToWarehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeFromWarehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clerkNum)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Время моделирования";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(276, 43);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(512, 424);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 444);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(255, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Начать моделирование";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // modelingTime
            // 
            this.modelingTime.Location = new System.Drawing.Point(15, 63);
            this.modelingTime.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.modelingTime.Name = "modelingTime";
            this.modelingTime.Size = new System.Drawing.Size(207, 22);
            this.modelingTime.TabIndex = 4;
            this.modelingTime.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // milliseconds
            // 
            this.milliseconds.Location = new System.Drawing.Point(100, 418);
            this.milliseconds.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.milliseconds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.milliseconds.Name = "milliseconds";
            this.milliseconds.Size = new System.Drawing.Size(81, 22);
            this.milliseconds.TabIndex = 5;
            this.milliseconds.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 420);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "1 минута = ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 420);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "мс";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 398);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Параметры таймера";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(464, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Журнал моделирования";
            // 
            // clientIntervalTime
            // 
            this.clientIntervalTime.Location = new System.Drawing.Point(15, 108);
            this.clientIntervalTime.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.clientIntervalTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.clientIntervalTime.Name = "clientIntervalTime";
            this.clientIntervalTime.Size = new System.Drawing.Size(207, 22);
            this.clientIntervalTime.TabIndex = 11;
            this.clientIntervalTime.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Интервал прихода клиентов";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(222, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "мин.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(222, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "мин.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(221, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "мин.";
            // 
            // timeToWarehouse
            // 
            this.timeToWarehouse.Location = new System.Drawing.Point(14, 153);
            this.timeToWarehouse.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.timeToWarehouse.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timeToWarehouse.Name = "timeToWarehouse";
            this.timeToWarehouse.Size = new System.Drawing.Size(207, 22);
            this.timeToWarehouse.TabIndex = 15;
            this.timeToWarehouse.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(163, 17);
            this.label10.TabIndex = 14;
            this.label10.Text = "Время на путь к складу";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(222, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 17);
            this.label11.TabIndex = 19;
            this.label11.Text = "мин.";
            // 
            // timeFromWarehouse
            // 
            this.timeFromWarehouse.Location = new System.Drawing.Point(15, 198);
            this.timeFromWarehouse.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.timeFromWarehouse.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timeFromWarehouse.Name = "timeFromWarehouse";
            this.timeFromWarehouse.Size = new System.Drawing.Size(207, 22);
            this.timeFromWarehouse.TabIndex = 18;
            this.timeFromWarehouse.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 178);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(211, 17);
            this.label12.TabIndex = 17;
            this.label12.Text = "Время возвращения со склада";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(221, 245);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 17);
            this.label13.TabIndex = 22;
            this.label13.Text = "мин.";
            // 
            // calcTime
            // 
            this.calcTime.Location = new System.Drawing.Point(14, 243);
            this.calcTime.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.calcTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.calcTime.Name = "calcTime";
            this.calcTime.Size = new System.Drawing.Size(207, 22);
            this.calcTime.TabIndex = 21;
            this.calcTime.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 223);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(108, 17);
            this.label14.TabIndex = 20;
            this.label14.Text = "Время расчета";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(221, 305);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 17);
            this.label15.TabIndex = 25;
            this.label15.Text = "чел.";
            // 
            // maxClients
            // 
            this.maxClients.Location = new System.Drawing.Point(14, 303);
            this.maxClients.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.maxClients.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxClients.Name = "maxClients";
            this.maxClients.Size = new System.Drawing.Size(207, 22);
            this.maxClients.TabIndex = 24;
            this.maxClients.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 268);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(189, 34);
            this.label16.TabIndex = 23;
            this.label16.Text = "Максимальное количество \r\nклиентов на клерка";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(221, 350);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(36, 17);
            this.label17.TabIndex = 28;
            this.label17.Text = "чел.";
            // 
            // clerkNum
            // 
            this.clerkNum.Location = new System.Drawing.Point(14, 348);
            this.clerkNum.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.clerkNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.clerkNum.Name = "clerkNum";
            this.clerkNum.Size = new System.Drawing.Size(207, 22);
            this.clerkNum.TabIndex = 27;
            this.clerkNum.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 328);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(143, 17);
            this.label18.TabIndex = 26;
            this.label18.Text = "Количество клерков";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 479);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.clerkNum);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.maxClients);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.calcTime);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.timeFromWarehouse);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.timeToWarehouse);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.clientIntervalTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.milliseconds);
            this.Controls.Add(this.modelingTime);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.modelingTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.milliseconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientIntervalTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeToWarehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeFromWarehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clerkNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown modelingTime;
        private System.Windows.Forms.NumericUpDown milliseconds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer PlusMinute;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown clientIntervalTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown timeToWarehouse;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown timeFromWarehouse;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown calcTime;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown maxClients;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown clerkNum;
        private System.Windows.Forms.Label label18;
    }
}

