Public Class Form5
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.ProgressBar1.Value = ProgressBar1.Value + 1
        If ProgressBar1.Value >= 100 Then
            Timer1.Stop()
            Form4.Show()
            Me.Hide()
        End If
    End Sub
End Class