<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrmManualAddTestDetail
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPara_Name = New System.Windows.Forms.TextBox()
        Me.txtNormal_LevelW = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNormal_Level = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTest_Result = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtMeasure_Unit = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tên thông số:"
        '
        'txtPara_Name
        '
        Me.txtPara_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPara_Name.Location = New System.Drawing.Point(115, 6)
        Me.txtPara_Name.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPara_Name.Name = "txtPara_Name"
        Me.txtPara_Name.Size = New System.Drawing.Size(234, 22)
        Me.txtPara_Name.TabIndex = 1
        '
        'txtNormal_LevelW
        '
        Me.txtNormal_LevelW.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNormal_LevelW.Location = New System.Drawing.Point(115, 82)
        Me.txtNormal_LevelW.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNormal_LevelW.Name = "txtNormal_LevelW"
        Me.txtNormal_LevelW.Size = New System.Drawing.Size(234, 22)
        Me.txtNormal_LevelW.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 85)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "TB nữ:"
        '
        'txtNormal_Level
        '
        Me.txtNormal_Level.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNormal_Level.Location = New System.Drawing.Point(115, 44)
        Me.txtNormal_Level.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNormal_Level.Name = "txtNormal_Level"
        Me.txtNormal_Level.Size = New System.Drawing.Size(234, 22)
        Me.txtNormal_Level.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(46, 47)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "TB nam:"
        '
        'txtTest_Result
        '
        Me.txtTest_Result.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTest_Result.Location = New System.Drawing.Point(115, 158)
        Me.txtTest_Result.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTest_Result.Name = "txtTest_Result"
        Me.txtTest_Result.Size = New System.Drawing.Size(234, 22)
        Me.txtTest_Result.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(46, 161)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Kết quả:"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(200, 195)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(149, 34)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Chấp nhận (Ctrl + S)"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtMeasure_Unit
        '
        Me.txtMeasure_Unit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMeasure_Unit.Location = New System.Drawing.Point(115, 120)
        Me.txtMeasure_Unit.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMeasure_Unit.Name = "txtMeasure_Unit"
        Me.txtMeasure_Unit.Size = New System.Drawing.Size(234, 22)
        Me.txtMeasure_Unit.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 123)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Đơn vị tính:"
        '
        'FrmManualAddTestDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 234)
        Me.Controls.Add(Me.txtMeasure_Unit)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtTest_Result)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtNormal_Level)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNormal_LevelW)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPara_Name)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmManualAddTestDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Thêm thông số  mới"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPara_Name As System.Windows.Forms.TextBox
    Friend WithEvents txtNormal_LevelW As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNormal_Level As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTest_Result As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtMeasure_Unit As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class