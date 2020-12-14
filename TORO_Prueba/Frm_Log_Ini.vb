Public Class Frm_Log_Ini
    Dim tiem As Integer
    Private Sub Frm_Log_Ini_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tiem = 0
        Timer1.Start()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        tiem = tiem + 1
        Opacity = Opacity + 0.01
        If tiem = 400 Then
            Timer1.Stop()
            Me.Hide()
            Ini.Show()

        End If
    End Sub
End Class