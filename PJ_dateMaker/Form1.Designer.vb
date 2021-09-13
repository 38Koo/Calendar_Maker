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
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Location = New System.Drawing.Point(26, 210)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.RowHeadersVisible = False
        Me.dgv1.RowHeadersWidth = 82
        Me.dgv1.RowTemplate.Height = 21
        Me.dgv1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgv1.Size = New System.Drawing.Size(1138, 790)
        Me.dgv1.TabIndex = 1000
        Me.dgv1.TabStop = False
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
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1437, 906)
        Me.Button1.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(836, 86)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "コピー"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1437, 1004)
        Me.Button2.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(836, 86)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "リセット"
        Me.Button2.UseVisualStyleBackColor = True
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
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(319, 104)
        Me.Button3.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 54)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(758, 104)
        Me.Button4.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(72, 54)
        Me.Button4.TabIndex = 1001
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(913, 104)
        Me.Button5.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(72, 54)
        Me.Button5.TabIndex = 1002
        Me.Button5.Text = "Button5"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(2740, 1783)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.dgv1)
        Me.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Name = "Form1"
        Me.Text = "以下の日程でご都合いかがでしょうか？"
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents txtDate As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents lblDate As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
End Class
