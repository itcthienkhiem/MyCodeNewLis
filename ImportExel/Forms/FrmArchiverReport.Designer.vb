<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmArchiverReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmArchiverReport))
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker
        Me.dtpTodate = New System.Windows.Forms.DateTimePicker
        Me.btnPrintReport = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(142, 9)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 16)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "Đến"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 16)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Từ"
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(46, 9)
        Me.dtpFromDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.ShowUpDown = True
        Me.dtpFromDate.Size = New System.Drawing.Size(88, 20)
        Me.dtpFromDate.TabIndex = 49
        '
        'dtpTodate
        '
        Me.dtpTodate.CustomFormat = "dd/MM/yyyy"
        Me.dtpTodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTodate.Location = New System.Drawing.Point(176, 9)
        Me.dtpTodate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpTodate.Name = "dtpTodate"
        Me.dtpTodate.ShowUpDown = True
        Me.dtpTodate.Size = New System.Drawing.Size(88, 20)
        Me.dtpTodate.TabIndex = 51
        '
        'btnPrintReport
        '
        Me.btnPrintReport.Location = New System.Drawing.Point(100, 46)
        Me.btnPrintReport.Name = "btnPrintReport"
        Me.btnPrintReport.Size = New System.Drawing.Size(75, 23)
        Me.btnPrintReport.TabIndex = 54
        Me.btnPrintReport.Text = "In Báo Cáo"
        Me.btnPrintReport.UseVisualStyleBackColor = True
        '
        'FrmArchiverReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(278, 84)
        Me.Controls.Add(Me.btnPrintReport)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpFromDate)
        Me.Controls.Add(Me.dtpTodate)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmArchiverReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "In báo cáo lưu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTodate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnPrintReport As System.Windows.Forms.Button
End Class
