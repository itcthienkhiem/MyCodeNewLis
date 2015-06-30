Namespace LABLink1_V2
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmPrintSetting
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintSetting))
            Me.Label1 = New System.Windows.Forms.Label
            Me.Label2 = New System.Windows.Forms.Label
            Me.chkPrintByTestType = New System.Windows.Forms.CheckBox
            Me.cboPrinter = New System.Windows.Forms.ComboBox
            Me.Button1 = New System.Windows.Forms.Button
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(13, 9)
            Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(54, 16)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Máy in:"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(13, 42)
            Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(115, 16)
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "In theo từng test:"
            '
            'chkPrintByTestType
            '
            Me.chkPrintByTestType.AutoSize = True
            Me.chkPrintByTestType.Location = New System.Drawing.Point(135, 44)
            Me.chkPrintByTestType.Name = "chkPrintByTestType"
            Me.chkPrintByTestType.Size = New System.Drawing.Size(15, 14)
            Me.chkPrintByTestType.TabIndex = 3
            Me.chkPrintByTestType.UseVisualStyleBackColor = True
            '
            'cboPrinter
            '
            Me.cboPrinter.FormattingEnabled = True
            Me.cboPrinter.Location = New System.Drawing.Point(135, 6)
            Me.cboPrinter.Name = "cboPrinter"
            Me.cboPrinter.Size = New System.Drawing.Size(369, 24)
            Me.cboPrinter.TabIndex = 4
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(407, 42)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(97, 23)
            Me.Button1.TabIndex = 5
            Me.Button1.Text = "Lưu (Ctrl+S)"
            Me.Button1.UseVisualStyleBackColor = True
            '
            'frmPrintSetting
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(520, 72)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.cboPrinter)
            Me.Controls.Add(Me.chkPrintByTestType)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.KeyPreview = True
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmPrintSetting"
            Me.Text = "Cấu hình máy in"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents chkPrintByTestType As System.Windows.Forms.CheckBox
        Friend WithEvents cboPrinter As System.Windows.Forms.ComboBox
        Friend WithEvents Button1 As System.Windows.Forms.Button
    End Class
End Namespace