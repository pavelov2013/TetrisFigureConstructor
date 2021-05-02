namespace FigureConstructor
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
            this.FigureList = new System.Windows.Forms.ListBox();
            this.newFile = new System.Windows.Forms.Button();
            this.loadFile = new System.Windows.Forms.Button();
            this.saveFile = new System.Windows.Forms.Button();
            this.AddFigure = new System.Windows.Forms.Button();
            this.RemoveFigure = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // FigureList
            // 
            this.FigureList.FormattingEnabled = true;
            this.FigureList.Location = new System.Drawing.Point(450, 30);
            this.FigureList.Name = "FigureList";
            this.FigureList.Size = new System.Drawing.Size(180, 173);
            this.FigureList.TabIndex = 1;
            this.FigureList.SelectedIndexChanged += new System.EventHandler(this.FigureList_SelectedIndexChanged);
            // 
            // newFile
            // 
            this.newFile.Location = new System.Drawing.Point(30, 0);
            this.newFile.Name = "newFile";
            this.newFile.Size = new System.Drawing.Size(75, 23);
            this.newFile.TabIndex = 2;
            this.newFile.Text = "New";
            this.newFile.UseVisualStyleBackColor = true;
            this.newFile.Click += new System.EventHandler(this.newFile_Click);
            // 
            // loadFile
            // 
            this.loadFile.Location = new System.Drawing.Point(120, 0);
            this.loadFile.Name = "loadFile";
            this.loadFile.Size = new System.Drawing.Size(75, 23);
            this.loadFile.TabIndex = 3;
            this.loadFile.Text = "Load";
            this.loadFile.UseVisualStyleBackColor = true;
            this.loadFile.Click += new System.EventHandler(this.loadFile_Click);
            // 
            // saveFile
            // 
            this.saveFile.Location = new System.Drawing.Point(210, 0);
            this.saveFile.Name = "saveFile";
            this.saveFile.Size = new System.Drawing.Size(75, 23);
            this.saveFile.TabIndex = 4;
            this.saveFile.Text = "Save";
            this.saveFile.UseVisualStyleBackColor = true;
            this.saveFile.Click += new System.EventHandler(this.saveFile_Click);
            // 
            // AddFigure
            // 
            this.AddFigure.Location = new System.Drawing.Point(450, 210);
            this.AddFigure.Name = "AddFigure";
            this.AddFigure.Size = new System.Drawing.Size(75, 23);
            this.AddFigure.TabIndex = 6;
            this.AddFigure.Text = "Add";
            this.AddFigure.UseVisualStyleBackColor = true;
            this.AddFigure.Click += new System.EventHandler(this.AddFigure_Click);
            // 
            // RemoveFigure
            // 
            this.RemoveFigure.Location = new System.Drawing.Point(540, 210);
            this.RemoveFigure.Name = "RemoveFigure";
            this.RemoveFigure.Size = new System.Drawing.Size(75, 23);
            this.RemoveFigure.TabIndex = 7;
            this.RemoveFigure.Text = "Remove";
            this.RemoveFigure.UseVisualStyleBackColor = true;
            this.RemoveFigure.Click += new System.EventHandler(this.RemoveFigure_Click);
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(30, 30);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(360, 360);
            this.canvas.TabIndex = 8;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(450, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Color:";
            // 
            // SelectBox
            // 
            this.SelectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectBox.FormattingEnabled = true;
            this.SelectBox.Location = new System.Drawing.Point(450, 300);
            this.SelectBox.Name = "SelectBox";
            this.SelectBox.Size = new System.Drawing.Size(180, 21);
            this.SelectBox.TabIndex = 10;
            this.SelectBox.SelectedIndexChanged += new System.EventHandler(this.SelectBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 574);
            this.Controls.Add(this.SelectBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.RemoveFigure);
            this.Controls.Add(this.AddFigure);
            this.Controls.Add(this.saveFile);
            this.Controls.Add(this.loadFile);
            this.Controls.Add(this.newFile);
            this.Controls.Add(this.FigureList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox FigureList;
        private System.Windows.Forms.Button newFile;
        private System.Windows.Forms.Button loadFile;
        private System.Windows.Forms.Button saveFile;
        private System.Windows.Forms.Button AddFigure;
        private System.Windows.Forms.Button RemoveFigure;
        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SelectBox;
    }
}

