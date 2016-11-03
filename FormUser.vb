Public Class FormUser
    Private Sub FormUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewUser()
    End Sub

    Sub viewUser()
        Dim user As New ClassUser()
        Dim query As String = user.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCUser.DataSource = data
    End Sub

    Private Sub FormUser_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormUser_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Dim u As New ClassUser()
        u.access(e, Me)
    End Sub
End Class