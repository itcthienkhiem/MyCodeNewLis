Public Class FrmSetting
#Region "Properties"
    Public PropertiesObject As Object
    Public ConfigFileName As String
    Public Title As String
#End Region

    Private Sub FrmSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        grdProperties.SelectedObject = PropertiesObject

    End Sub
End Class