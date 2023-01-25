namespace MMO
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMakeGood = new System.Windows.Forms.Button();
            this.btnFillGrids = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gridB = new System.Windows.Forms.DataGridView();
            this.MatrB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridC = new System.Windows.Forms.DataGridView();
            this.gridA = new System.Windows.Forms.DataGridView();
            this.MatrA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblFirstPay = new System.Windows.Forms.Label();
            this.btnFirstPay = new System.Windows.Forms.Button();
            this.lblCheck2 = new System.Windows.Forms.Label();
            this.lblCheck1 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnFogel = new System.Windows.Forms.Button();
            this.btnMinEl = new System.Windows.Forms.Button();
            this.btnNordWest = new System.Windows.Forms.Button();
            this.gridSupport = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblOptimum = new System.Windows.Forms.Label();
            this.btnStep2 = new System.Windows.Forms.Button();
            this.btnStep1 = new System.Windows.Forms.Button();
            this.gridFinal = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridA)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSupport)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFinal)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnMakeGood);
            this.panel1.Controls.Add(this.btnFillGrids);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(147, 357);
            this.panel1.TabIndex = 0;
            // 
            // btnMakeGood
            // 
            this.btnMakeGood.Location = new System.Drawing.Point(4, 325);
            this.btnMakeGood.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMakeGood.Name = "btnMakeGood";
            this.btnMakeGood.Size = new System.Drawing.Size(139, 28);
            this.btnMakeGood.TabIndex = 6;
            this.btnMakeGood.Text = "Сделать хорошо";
            this.btnMakeGood.UseVisualStyleBackColor = true;
            this.btnMakeGood.Click += new System.EventHandler(this.btnMakeGood_Click);
            // 
            // btnFillGrids
            // 
            this.btnFillGrids.Location = new System.Drawing.Point(4, 27);
            this.btnFillGrids.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFillGrids.Name = "btnFillGrids";
            this.btnFillGrids.Size = new System.Drawing.Size(139, 28);
            this.btnFillGrids.TabIndex = 3;
            this.btnFillGrids.Text = "Заполнить";
            this.btnFillGrids.UseVisualStyleBackColor = true;
            this.btnFillGrids.Click += new System.EventHandler(this.btnFillGrids_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(4, 0);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(139, 28);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Открыть из файла";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(171, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(768, 357);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage1.Controls.Add(this.gridB);
            this.tabPage1.Controls.Add(this.gridC);
            this.tabPage1.Controls.Add(this.gridA);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(760, 328);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Условия задачи";
            // 
            // gridB
            // 
            this.gridB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gridB.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gridB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MatrB});
            this.gridB.Location = new System.Drawing.Point(133, 0);
            this.gridB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridB.Name = "gridB";
            this.gridB.RowHeadersWidth = 51;
            this.gridB.Size = new System.Drawing.Size(125, 325);
            this.gridB.TabIndex = 2;
            this.gridB.Visible = false;
            this.gridB.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gridB_RowsAdded);
            this.gridB.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.gridB_RowsRemoved);
            // 
            // MatrB
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "null";
            this.MatrB.DefaultCellStyle = dataGridViewCellStyle1;
            this.MatrB.HeaderText = "MatrB";
            this.MatrB.MinimumWidth = 6;
            this.MatrB.Name = "MatrB";
            this.MatrB.Width = 50;
            // 
            // gridC
            // 
            this.gridC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridC.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gridC.ColumnHeadersHeight = 29;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "null";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridC.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridC.Location = new System.Drawing.Point(267, 0);
            this.gridC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridC.Name = "gridC";
            this.gridC.RowHeadersWidth = 50;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "null";
            this.gridC.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gridC.Size = new System.Drawing.Size(491, 325);
            this.gridC.TabIndex = 1;
            this.gridC.Visible = false;
            // 
            // gridA
            // 
            this.gridA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gridA.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gridA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MatrA});
            this.gridA.Location = new System.Drawing.Point(0, 0);
            this.gridA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridA.MultiSelect = false;
            this.gridA.Name = "gridA";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridA.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridA.RowHeadersWidth = 51;
            this.gridA.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gridA.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gridA.RowTemplate.DefaultCellStyle.Format = "N2";
            this.gridA.RowTemplate.DefaultCellStyle.NullValue = "0";
            this.gridA.Size = new System.Drawing.Size(125, 325);
            this.gridA.TabIndex = 0;
            this.gridA.Visible = false;
            this.gridA.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gridA_RowsAdded);
            this.gridA.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.gridA_RowsRemoved);
            // 
            // MatrA
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "null";
            this.MatrA.DefaultCellStyle = dataGridViewCellStyle4;
            this.MatrA.FillWeight = 50F;
            this.MatrA.HeaderText = "A";
            this.MatrA.MinimumWidth = 6;
            this.MatrA.Name = "MatrA";
            this.MatrA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MatrA.Width = 50;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage2.Controls.Add(this.lblFirstPay);
            this.tabPage2.Controls.Add(this.btnFirstPay);
            this.tabPage2.Controls.Add(this.lblCheck2);
            this.tabPage2.Controls.Add(this.lblCheck1);
            this.tabPage2.Controls.Add(this.btnCheck);
            this.tabPage2.Controls.Add(this.btnFogel);
            this.tabPage2.Controls.Add(this.btnMinEl);
            this.tabPage2.Controls.Add(this.btnNordWest);
            this.tabPage2.Controls.Add(this.gridSupport);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(760, 328);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Опорный план";
            // 
            // lblFirstPay
            // 
            this.lblFirstPay.AutoSize = true;
            this.lblFirstPay.Location = new System.Drawing.Point(8, 214);
            this.lblFirstPay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstPay.Name = "lblFirstPay";
            this.lblFirstPay.Size = new System.Drawing.Size(0, 16);
            this.lblFirstPay.TabIndex = 8;
            // 
            // btnFirstPay
            // 
            this.btnFirstPay.Location = new System.Drawing.Point(4, 182);
            this.btnFirstPay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFirstPay.Name = "btnFirstPay";
            this.btnFirstPay.Size = new System.Drawing.Size(139, 28);
            this.btnFirstPay.TabIndex = 7;
            this.btnFirstPay.Text = "Стоимость";
            this.btnFirstPay.UseVisualStyleBackColor = true;
            this.btnFirstPay.Click += new System.EventHandler(this.btnFirstPay_Click);
            // 
            // lblCheck2
            // 
            this.lblCheck2.AutoSize = true;
            this.lblCheck2.Location = new System.Drawing.Point(8, 162);
            this.lblCheck2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCheck2.Name = "lblCheck2";
            this.lblCheck2.Size = new System.Drawing.Size(0, 16);
            this.lblCheck2.TabIndex = 6;
            // 
            // lblCheck1
            // 
            this.lblCheck1.AutoSize = true;
            this.lblCheck1.Location = new System.Drawing.Point(8, 146);
            this.lblCheck1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCheck1.Name = "lblCheck1";
            this.lblCheck1.Size = new System.Drawing.Size(0, 16);
            this.lblCheck1.TabIndex = 5;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(4, 111);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(139, 28);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Text = "Вырожденность";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnFogel
            // 
            this.btnFogel.Location = new System.Drawing.Point(4, 75);
            this.btnFogel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFogel.Name = "btnFogel";
            this.btnFogel.Size = new System.Drawing.Size(139, 28);
            this.btnFogel.TabIndex = 3;
            this.btnFogel.Text = "Фогель";
            this.btnFogel.UseVisualStyleBackColor = true;
            this.btnFogel.Click += new System.EventHandler(this.btnFogel_Click);
            // 
            // btnMinEl
            // 
            this.btnMinEl.Location = new System.Drawing.Point(4, 39);
            this.btnMinEl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMinEl.Name = "btnMinEl";
            this.btnMinEl.Size = new System.Drawing.Size(139, 28);
            this.btnMinEl.TabIndex = 2;
            this.btnMinEl.Text = "Мин. эл-т";
            this.btnMinEl.UseVisualStyleBackColor = true;
            this.btnMinEl.Click += new System.EventHandler(this.btnMinEl_Click);
            // 
            // btnNordWest
            // 
            this.btnNordWest.Location = new System.Drawing.Point(4, 4);
            this.btnNordWest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNordWest.Name = "btnNordWest";
            this.btnNordWest.Size = new System.Drawing.Size(139, 28);
            this.btnNordWest.TabIndex = 1;
            this.btnNordWest.Text = "С-З угол";
            this.btnNordWest.UseVisualStyleBackColor = true;
            this.btnNordWest.Click += new System.EventHandler(this.btnNordWest_Click);
            // 
            // gridSupport
            // 
            this.gridSupport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "null";
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSupport.DefaultCellStyle = dataGridViewCellStyle6;
            this.gridSupport.Location = new System.Drawing.Point(151, 4);
            this.gridSupport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridSupport.Name = "gridSupport";
            this.gridSupport.RowHeadersWidth = 50;
            this.gridSupport.Size = new System.Drawing.Size(603, 318);
            this.gridSupport.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage3.Controls.Add(this.lblOptimum);
            this.tabPage3.Controls.Add(this.btnStep2);
            this.tabPage3.Controls.Add(this.btnStep1);
            this.tabPage3.Controls.Add(this.gridFinal);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(760, 328);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Оптимальное решение";
            // 
            // lblOptimum
            // 
            this.lblOptimum.AutoSize = true;
            this.lblOptimum.Location = new System.Drawing.Point(4, 71);
            this.lblOptimum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOptimum.Name = "lblOptimum";
            this.lblOptimum.Size = new System.Drawing.Size(0, 16);
            this.lblOptimum.TabIndex = 6;
            // 
            // btnStep2
            // 
            this.btnStep2.Location = new System.Drawing.Point(4, 39);
            this.btnStep2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStep2.Name = "btnStep2";
            this.btnStep2.Size = new System.Drawing.Size(139, 28);
            this.btnStep2.TabIndex = 5;
            this.btnStep2.Text = "Стоимость";
            this.btnStep2.UseVisualStyleBackColor = true;
            this.btnStep2.Click += new System.EventHandler(this.btnStep2_Click);
            // 
            // btnStep1
            // 
            this.btnStep1.Location = new System.Drawing.Point(4, 4);
            this.btnStep1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStep1.Name = "btnStep1";
            this.btnStep1.Size = new System.Drawing.Size(139, 28);
            this.btnStep1.TabIndex = 4;
            this.btnStep1.Text = "Найти";
            this.btnStep1.UseVisualStyleBackColor = true;
            this.btnStep1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // gridFinal
            // 
            this.gridFinal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "null";
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridFinal.DefaultCellStyle = dataGridViewCellStyle7;
            this.gridFinal.Location = new System.Drawing.Point(151, 4);
            this.gridFinal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridFinal.Name = "gridFinal";
            this.gridFinal.RowHeadersWidth = 50;
            this.gridFinal.Size = new System.Drawing.Size(603, 318);
            this.gridFinal.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(955, 378);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridA)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSupport)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFinal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView gridA;
        private System.Windows.Forms.DataGridView gridC;
        private System.Windows.Forms.DataGridView gridB;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnFillGrids;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatrA;
        private System.Windows.Forms.Button btnFogel;
        private System.Windows.Forms.Button btnMinEl;
        private System.Windows.Forms.Button btnNordWest;
        private System.Windows.Forms.DataGridView gridSupport;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatrB;
        private System.Windows.Forms.Label lblCheck1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label lblCheck2;
        private System.Windows.Forms.Label lblFirstPay;
        private System.Windows.Forms.Button btnFirstPay;
        private System.Windows.Forms.Button btnStep1;
        private System.Windows.Forms.DataGridView gridFinal;
        private System.Windows.Forms.Button btnStep2;
        private System.Windows.Forms.Button btnMakeGood;
        private System.Windows.Forms.Label lblOptimum;
    }
}

