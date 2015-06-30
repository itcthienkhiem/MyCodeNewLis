<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Preview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Preview))
        Me.stbr = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.crptViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdExcel = New Janus.Windows.EditControls.UIButton()
        Me.cmdTrinhKy = New Janus.Windows.EditControls.UIButton()
        Me.stbr.SuspendLayout()
        Me.SuspendLayout()
        '
        'stbr
        '
        Me.stbr.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.stbr.Location = New System.Drawing.Point(0, 419)
        Me.stbr.Name = "stbr"
        Me.stbr.Size = New System.Drawing.Size(1182, 22)
        Me.stbr.TabIndex = 2
        Me.stbr.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(583, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "Nhấn P hoặc Ctrl+P để in ra máy in"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(583, 17)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "Nhấn S hoặc Ctrl+S để lưu dữ liệu in ra file Excel"
        '
        'crptViewer
        '
        Me.crptViewer.ActiveViewIndex = -1
        Me.crptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crptViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.crptViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crptViewer.Location = New System.Drawing.Point(0, 0)
        Me.crptViewer.Name = "crptViewer"
        Me.crptViewer.SelectionFormula = ""
        Me.crptViewer.Size = New System.Drawing.Size(1182, 419)
        Me.crptViewer.TabIndex = 3
        Me.crptViewer.ViewTimeSelectionFormula = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(731, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Nhấn P hoặc Ctrl+P để in ra máy in"
        '
        'cmdExcel
        '
        Me.cmdExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExcel.Image = CType(resources.GetObject("cmdExcel.Image"), System.Drawing.Image)
        Me.cmdExcel.Location = New System.Drawing.Point(599, 4)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(111, 23)
        Me.cmdExcel.TabIndex = 5
        Me.cmdExcel.Text = "&Export Excel"
        '
        'cmdTrinhKy
        '
        Me.cmdTrinhKy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTrinhKy.Image = CType(resources.GetObject("cmdTrinhKy.Image"), System.Drawing.Image)
        Me.cmdTrinhKy.Location = New System.Drawing.Point(495, 4)
        Me.cmdTrinhKy.Name = "cmdTrinhKy"
        Me.cmdTrinhKy.Size = New System.Drawing.Size(101, 23)
        Me.cmdTrinhKy.TabIndex = 6
        Me.cmdTrinhKy.Text = "Trình ký"
        '
        'frm_Preview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1182, 441)
        Me.Controls.Add(Me.cmdTrinhKy)
        Me.Controls.Add(Me.cmdExcel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.crptViewer)
        Me.Controls.Add(Me.stbr)
        Me.KeyPreview = True
        Me.Name = "frm_Preview"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "In dữ liệu"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.stbr.ResumeLayout(False)
        Me.stbr.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents stbr As System.Windows.Forms.StatusStrip
    Friend WithEvents crptViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmdExcel As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmdTrinhKy As Janus.Windows.EditControls.UIButton
End Class
