<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBaoCaoThang
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBaoCaoThang))
        Dim grdDetail_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtmTo = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtmFrom = New System.Windows.Forms.DateTimePicker
        Me.btnExcel = New System.Windows.Forms.Button
        Me.cmdReport = New System.Windows.Forms.Button
        Me.cmdClose = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.grdDetailExporter = New Janus.Windows.GridEX.Export.GridEXExporter(Me.components)
        Me.grdDetail = New Janus.Windows.GridEX.GridEX
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(909, 26)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "BÁO CÁO XÉT NGHIỆM THEO THÁNG"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dtmTo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtmFrom)
        Me.GroupBox1.Controls.Add(Me.btnExcel)
        Me.GroupBox1.Controls.Add(Me.cmdReport)
        Me.GroupBox1.Controls.Add(Me.cmdClose)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(94, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(821, 52)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'dtmTo
        '
        Me.dtmTo.CustomFormat = "dd/MM/yyyy"
        Me.dtmTo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtmTo.Location = New System.Drawing.Point(235, 18)
        Me.dtmTo.Name = "dtmTo"
        Me.dtmTo.ShowUpDown = True
        Me.dtmTo.Size = New System.Drawing.Size(103, 25)
        Me.dtmTo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(172, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "đến ngày"
        '
        'dtmFrom
        '
        Me.dtmFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtmFrom.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtmFrom.Location = New System.Drawing.Point(68, 18)
        Me.dtmFrom.Name = "dtmFrom"
        Me.dtmFrom.ShowUpDown = True
        Me.dtmFrom.Size = New System.Drawing.Size(98, 25)
        Me.dtmFrom.TabIndex = 0
        '
        'btnExcel
        '
        Me.btnExcel.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(467, 14)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(178, 30)
        Me.btnExcel.TabIndex = 3
        Me.btnExcel.Text = "&Xuất Dữ Liệu Trên Lưới"
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'cmdReport
        '
        Me.cmdReport.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReport.Image = CType(resources.GetObject("cmdReport.Image"), System.Drawing.Image)
        Me.cmdReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdReport.Location = New System.Drawing.Point(344, 14)
        Me.cmdReport.Name = "cmdReport"
        Me.cmdReport.Size = New System.Drawing.Size(117, 30)
        Me.cmdReport.TabIndex = 3
        Me.cmdReport.Text = "&Lấy Dữ Liệu"
        Me.cmdReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdReport.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Image = CType(resources.GetObject("cmdClose.Image"), System.Drawing.Image)
        Me.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdClose.Location = New System.Drawing.Point(710, 13)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(99, 33)
        Me.cmdClose.TabIndex = 4
        Me.cmdClose.Text = "&Thoát(Esc)"
        Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Từ ngày"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(82, 91)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'grdDetailExporter
        '
        Me.grdDetailExporter.GridEX = Me.grdDetail
        '
        'grdDetail
        '
        Me.grdDetail.AlternatingColors = True
        Me.grdDetail.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        grdDetail_DesignTimeLayout.LayoutString = resources.GetString("grdDetail_DesignTimeLayout.LayoutString")
        Me.grdDetail.DesignTimeLayout = grdDetail_DesignTimeLayout
        Me.grdDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDetail.GroupByBoxVisible = False
        Me.grdDetail.GroupRowFormatStyle.BackColor = System.Drawing.Color.Silver
        Me.grdDetail.GroupRowFormatStyle.BackColorGradient = System.Drawing.Color.Empty
        Me.grdDetail.GroupRowVisualStyle = Janus.Windows.GridEX.GroupRowVisualStyle.UseRowStyle
        Me.grdDetail.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grdDetail.Location = New System.Drawing.Point(12, 98)
        Me.grdDetail.Name = "grdDetail"
        Me.grdDetail.Size = New System.Drawing.Size(909, 344)
        Me.grdDetail.TabIndex = 14
        '
        'FrmBaoCaoThang
        '
        Me.AcceptButton = Me.cmdReport
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 445)
        Me.Controls.Add(Me.grdDetail)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmBaoCaoThang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Báo cáo xét nghiệm theo tháng"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdReport As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtmTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtmFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents grdDetailExporter As Janus.Windows.GridEX.Export.GridEXExporter
    Friend WithEvents grdDetail As Janus.Windows.GridEX.GridEX
End Class
