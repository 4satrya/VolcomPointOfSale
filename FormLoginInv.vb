Public Class FormLoginInv
    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        Cursor = Cursors.WaitCursor
        Close()
        FormHome.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormLoginInv_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
        FormFront.Opacity = 100
    End Sub

    Private Sub FormLoginInv_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class