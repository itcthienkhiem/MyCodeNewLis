<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTestGroupList
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
        Dim grdTestGroupRelation_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTestGroupList))
        Dim grdTestGroupList_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.grdTestGroupRelation = New Janus.Windows.GridEX.GridEX
        Me.grdTestGroupList = New Janus.Windows.GridEX.GridEX
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnDelTestGroup = New Janus.Windows.EditControls.UIButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboDeviceList = New Janus.Windows.EditControls.UIComboBox
        Me.btnExit = New Janus.Windows.EditControls.UIButton
        Me.txtTestGroupName = New Janus.Windows.GridEX.EditControls.EditBox
        Me.btnAddTestGroup = New Janus.Windows.EditControls.UIButton
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.grdTestGroupRelation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTestGroupList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.grdTestGroupRelation)
        Me.UiGroupBox1.Controls.Add(Me.grdTestGroupList)
        Me.UiGroupBox1.Controls.Add(Me.Panel1)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UiGroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(764, 505)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.Text = "Danh sách nhóm"
        '
        'grdTestGroupRelation
        '
        Me.grdTestGroupRelation.ColumnAutoResize = True
        grdTestGroupRelation_DesignTimeLayout.LayoutString = resources.GetString("grdTestGroupRelation_DesignTimeLayout.LayoutString")
        Me.grdTestGroupRelation.DesignTimeLayout = grdTestGroupRelation_DesignTimeLayout
        Me.grdTestGroupRelation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTestGroupRelation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdTestGroupRelation.GroupByBoxVisible = False
        Me.grdTestGroupRelation.Location = New System.Drawing.Point(401, 89)
        Me.grdTestGroupRelation.Name = "grdTestGroupRelation"
        Me.grdTestGroupRelation.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex
        Me.grdTestGroupRelation.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdTestGroupRelation.Size = New System.Drawing.Size(360, 413)
        Me.grdTestGroupRelation.TabIndex = 3
        '
        'grdTestGroupList
        '
        Me.grdTestGroupList.ColumnAutoResize = True
        grdTestGroupList_DesignTimeLayout.LayoutString = resources.GetString("grdTestGroupList_DesignTimeLayout.LayoutString")
        Me.grdTestGroupList.DesignTimeLayout = grdTestGroupList_DesignTimeLayout
        Me.grdTestGroupList.Dock = System.Windows.Forms.DockStyle.Left
        Me.grdTestGroupList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdTestGroupList.GroupByBoxVisible = False
        Me.grdTestGroupList.Location = New System.Drawing.Point(3, 89)
        Me.grdTestGroupList.Name = "grdTestGroupList"
        Me.grdTestGroupList.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex
        Me.grdTestGroupList.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdTestGroupList.Size = New System.Drawing.Size(398, 413)
        Me.grdTestGroupList.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btnDelTestGroup)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cboDeviceList)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Controls.Add(Me.txtTestGroupName)
        Me.Panel1.Controls.Add(Me.btnAddTestGroup)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(758, 71)
        Me.Panel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Tên nhóm"
        '
        'btnDelTestGroup
        '
        Me.btnDelTestGroup.Location = New System.Drawing.Point(90, 42)
        Me.btnDelTestGroup.Name = "btnDelTestGroup"
        Me.btnDelTestGroup.Size = New System.Drawing.Size(75, 23)
        Me.btnDelTestGroup.TabIndex = 3
        Me.btnDelTestGroup.Text = "Xóa"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(327, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Thiết bị"
        '
        'cboDeviceList
        '
        Me.cboDeviceList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDeviceList.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cboDeviceList.Location = New System.Drawing.Point(398, 11)
        Me.cboDeviceList.Name = "cboDeviceList"
        Me.cboDeviceList.Size = New System.Drawing.Size(351, 22)
        Me.cboDeviceList.TabIndex = 0
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(651, 42)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(98, 23)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Thoát (ESC)"
        '
        'txtTestGroupName
        '
        Me.txtTestGroupName.Location = New System.Drawing.Point(91, 11)
        Me.txtTestGroupName.Name = "txtTestGroupName"
        Me.txtTestGroupName.Size = New System.Drawing.Size(230, 22)
        Me.txtTestGroupName.TabIndex = 1
        '
        'btnAddTestGroup
        '
        Me.btnAddTestGroup.Location = New System.Drawing.Point(9, 42)
        Me.btnAddTestGroup.Name = "btnAddTestGroup"
        Me.btnAddTestGroup.Size = New System.Drawing.Size(75, 23)
        Me.btnAddTestGroup.TabIndex = 0
        Me.btnAddTestGroup.Text = "Thêm"
        '
        'frmTestGroupList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 505)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmTestGroupList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DANH MỤC NHÓM CHỈ ĐỊNH XÉT NGHIỆM"
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.grdTestGroupRelation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTestGroupList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents grdTestGroupList As Janus.Windows.GridEX.GridEX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnExit As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtTestGroupName As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnAddTestGroup As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDeviceList As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents grdTestGroupRelation As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnDelTestGroup As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
