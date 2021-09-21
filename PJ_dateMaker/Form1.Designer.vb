<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvCalendar = New System.Windows.Forms.DataGridView()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.btnLastMonth = New System.Windows.Forms.Button()
        Me.btnNextMonth = New System.Windows.Forms.Button()
        Me.btnToday = New System.Windows.Forms.Button()
        CType(Me.dgvCalendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCalendar
        '
        Me.dgvCalendar.AllowUserToAddRows = False
        Me.dgvCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCalendar.Location = New System.Drawing.Point(26, 210)
        Me.dgvCalendar.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.dgvCalendar.Name = "dgvCalendar"
        Me.dgvCalendar.RowHeadersVisible = False
        Me.dgvCalendar.RowHeadersWidth = 82
        Me.dgvCalendar.RowTemplate.Height = 21
        Me.dgvCalendar.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgvCalendar.Size = New System.Drawing.Size(1138, 790)
        Me.dgvCalendar.TabIndex = 1000
        Me.dgvCalendar.TabStop = False
        '
        'txtDate
        '
        Me.txtDate.Font = New System.Drawing.Font("MS UI Gothic", 18.0!)
        Me.txtDate.ForeColor = System.Drawing.Color.Black
        Me.txtDate.Location = New System.Drawing.Point(1437, 138)
        Me.txtDate.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.txtDate.Multiline = True
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(832, 752)
        Me.txtDate.TabIndex = 1
        '
        'btnCopy
        '
        Me.btnCopy.Location = New System.Drawing.Point(1437, 906)
        Me.btnCopy.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(836, 86)
        Me.btnCopy.TabIndex = 2
        Me.btnCopy.Text = "コピー"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(1437, 1004)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(836, 86)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "リセット"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("MS UI Gothic", 20.0!)
        Me.lblDate.Location = New System.Drawing.Point(462, 104)
        Me.lblDate.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(212, 54)
        Me.lblDate.TabIndex = 4
        Me.lblDate.Text = "2020/01"
        '
        'btnLastMonth
        '
        Me.btnLastMonth.Location = New System.Drawing.Point(319, 104)
        Me.btnLastMonth.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnLastMonth.Name = "btnLastMonth"
        Me.btnLastMonth.Size = New System.Drawing.Size(72, 54)
        Me.btnLastMonth.TabIndex = 5
        Me.btnLastMonth.Text = "Button3"
        Me.btnLastMonth.UseVisualStyleBackColor = True
        '
        'btnNextMonth
        '
        Me.btnNextMonth.Location = New System.Drawing.Point(758, 104)
        Me.btnNextMonth.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnNextMonth.Name = "btnNextMonth"
        Me.btnNextMonth.Size = New System.Drawing.Size(72, 54)
        Me.btnNextMonth.TabIndex = 1001
        Me.btnNextMonth.Text = "Button4"
        Me.btnNextMonth.UseVisualStyleBackColor = True
        '
        'btnToday
        '
        Me.btnToday.Location = New System.Drawing.Point(913, 104)
        Me.btnToday.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnToday.Name = "btnToday"
        Me.btnToday.Size = New System.Drawing.Size(72, 54)
        Me.btnToday.TabIndex = 1002
        Me.btnToday.Text = "Button5"
        Me.btnToday.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(2740, 1783)
        Me.Controls.Add(Me.btnToday)
        Me.Controls.Add(Me.btnNextMonth)
        Me.Controls.Add(Me.btnLastMonth)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.dgvCalendar)
        Me.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Name = "Form1"
        Me.Text = "以下の日程でご都合いかがでしょうか？"
        CType(Me.dgvCalendar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvCalendar As DataGridView
    Friend WithEvents txtDate As TextBox
    Friend WithEvents btnCopy As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents lblDate As Label
    Friend WithEvents btnLastMonth As Button
    Friend WithEvents btnNextMonth As Button
    Friend WithEvents btnToday As Button
End Class
