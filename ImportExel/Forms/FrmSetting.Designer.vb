<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSetting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSetting))
        Me.grdProperties = New System.Windows.Forms.PropertyGrid
        Me.SuspendLayout()
        '
        'grdProperties
        '
        Me.grdProperties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProperties.Location = New System.Drawing.Point(0, 0)
        Me.grdProperties.Name = "grdProperties"
        Me.grdProperties.Size = New System.Drawing.Size(322, 498)
        Me.grdProperties.TabIndex = 0
        '
        'FrmSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 498)
        Me.Controls.Add(Me.grdProperties)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmSetting"
        Me.Text = "Setting"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdProperties As System.Windows.Forms.PropertyGrid
End Class
