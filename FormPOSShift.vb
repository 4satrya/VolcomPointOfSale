Public Class FormPOSShift
    Private Sub FormPOSShift_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPOSShift_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtUsername.Text = username_user
        TxtName.Text = name_user
        DEDate.EditValue = getTimeDB()
    End Sub
End Class