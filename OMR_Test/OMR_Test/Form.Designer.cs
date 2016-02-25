namespace OMR_Test
{
    partial class MainForm
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
            this.original = new System.Windows.Forms.PictureBox();
            this.downloadButton = new System.Windows.Forms.Button();
            this.path = new System.Windows.Forms.TextBox();
            this.test = new System.Windows.Forms.PictureBox();
            this.exception = new System.Windows.Forms.TextBox();
            this.group = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.surname = new System.Windows.Forms.TextBox();
            this.lPath = new System.Windows.Forms.Label();
            this.lGroup = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.Label();
            this.lSurname = new System.Windows.Forms.Label();
            this.lErrors = new System.Windows.Forms.Label();
            this.lResult = new System.Windows.Forms.Label();
            this.testResult = new System.Windows.Forms.TextBox();
            this.lSubject = new System.Windows.Forms.Label();
            this.subject = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.original)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.test)).BeginInit();
            this.SuspendLayout();
            // 
            // original
            // 
            this.original.Location = new System.Drawing.Point(50, 50);
            this.original.Name = "original";
            this.original.Size = new System.Drawing.Size(557, 669);
            this.original.TabIndex = 0;
            this.original.TabStop = false;
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(1279, 50);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(240, 80);
            this.downloadButton.TabIndex = 1;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadClick);
            // 
            // path
            // 
            this.path.Location = new System.Drawing.Point(1279, 136);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(240, 20);
            this.path.TabIndex = 2;
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(677, 50);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(557, 669);
            this.test.TabIndex = 3;
            this.test.TabStop = false;
            // 
            // exception
            // 
            this.exception.Location = new System.Drawing.Point(1279, 175);
            this.exception.Name = "exception";
            this.exception.ReadOnly = true;
            this.exception.Size = new System.Drawing.Size(240, 20);
            this.exception.TabIndex = 4;
            // 
            // group
            // 
            this.group.Location = new System.Drawing.Point(1279, 214);
            this.group.Name = "group";
            this.group.Size = new System.Drawing.Size(240, 20);
            this.group.TabIndex = 5;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(1279, 253);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(240, 20);
            this.name.TabIndex = 6;
            // 
            // surname
            // 
            this.surname.Location = new System.Drawing.Point(1279, 292);
            this.surname.Name = "surname";
            this.surname.Size = new System.Drawing.Size(240, 20);
            this.surname.TabIndex = 7;
            // 
            // lPath
            // 
            this.lPath.AutoSize = true;
            this.lPath.Location = new System.Drawing.Point(1276, 159);
            this.lPath.Name = "lPath";
            this.lPath.Size = new System.Drawing.Size(29, 13);
            this.lPath.TabIndex = 8;
            this.lPath.Text = "Path";
            // 
            // lGroup
            // 
            this.lGroup.AutoSize = true;
            this.lGroup.Location = new System.Drawing.Point(1276, 237);
            this.lGroup.Name = "lGroup";
            this.lGroup.Size = new System.Drawing.Size(36, 13);
            this.lGroup.TabIndex = 10;
            this.lGroup.Text = "Group";
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(1276, 276);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(35, 13);
            this.lName.TabIndex = 11;
            this.lName.Text = "Name";
            // 
            // lSurname
            // 
            this.lSurname.AutoSize = true;
            this.lSurname.Location = new System.Drawing.Point(1276, 315);
            this.lSurname.Name = "lSurname";
            this.lSurname.Size = new System.Drawing.Size(49, 13);
            this.lSurname.TabIndex = 12;
            this.lSurname.Text = "Surname";
            // 
            // lErrors
            // 
            this.lErrors.AutoSize = true;
            this.lErrors.Location = new System.Drawing.Point(1276, 198);
            this.lErrors.Name = "lErrors";
            this.lErrors.Size = new System.Drawing.Size(34, 13);
            this.lErrors.TabIndex = 13;
            this.lErrors.Text = "Errors";
            // 
            // lResult
            // 
            this.lResult.AutoSize = true;
            this.lResult.Location = new System.Drawing.Point(1276, 393);
            this.lResult.Name = "lResult";
            this.lResult.Size = new System.Drawing.Size(37, 13);
            this.lResult.TabIndex = 15;
            this.lResult.Text = "Result";
            // 
            // testResult
            // 
            this.testResult.Location = new System.Drawing.Point(1279, 370);
            this.testResult.Name = "testResult";
            this.testResult.ReadOnly = true;
            this.testResult.Size = new System.Drawing.Size(240, 20);
            this.testResult.TabIndex = 14;
            // 
            // lSubject
            // 
            this.lSubject.AutoSize = true;
            this.lSubject.Location = new System.Drawing.Point(1276, 354);
            this.lSubject.Name = "lSubject";
            this.lSubject.Size = new System.Drawing.Size(43, 13);
            this.lSubject.TabIndex = 17;
            this.lSubject.Text = "Subject";
            // 
            // subject
            // 
            this.subject.Location = new System.Drawing.Point(1279, 331);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(240, 20);
            this.subject.TabIndex = 16;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.lSubject);
            this.Controls.Add(this.subject);
            this.Controls.Add(this.lResult);
            this.Controls.Add(this.testResult);
            this.Controls.Add(this.lErrors);
            this.Controls.Add(this.lSurname);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.lGroup);
            this.Controls.Add(this.lPath);
            this.Controls.Add(this.surname);
            this.Controls.Add(this.name);
            this.Controls.Add(this.group);
            this.Controls.Add(this.exception);
            this.Controls.Add(this.test);
            this.Controls.Add(this.path);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.original);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.original)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.test)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox original;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.PictureBox test;
        private System.Windows.Forms.TextBox exception;
        private System.Windows.Forms.TextBox group;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox surname;
        private System.Windows.Forms.Label lPath;
        private System.Windows.Forms.Label lGroup;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lSurname;
        private System.Windows.Forms.Label lErrors;
        private System.Windows.Forms.Label lResult;
        private System.Windows.Forms.TextBox testResult;
        private System.Windows.Forms.Label lSubject;
        private System.Windows.Forms.TextBox subject;
    }
}

