Public Class FormUser
    Private Sub FormUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GVRole.Focus()
        viewRole()
        viewUser()
    End Sub

    Sub viewRole()
        Dim role As New ClassUser()
        Dim query As String = role.queryRole("-1", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRole.DataSource = data
    End Sub

    Sub viewUser()
        Dim user As New ClassUser()
        Dim query As String = user.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCUser.DataSource = data
    End Sub

    Private Sub FormUser_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dim acc As New ClassUser()
        acc.logout()
        Dispose()
    End Sub

    Private Sub FormUser_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Cursor = Cursors.WaitCursor
        Dim u As New ClassUser()
        u.access(e, Me)
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCUser_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCUser.SelectedPageChanged
        If XTCUser.SelectedTabPageIndex = 0 Then
            GVRole.Focus()
        ElseIf XTCUser.SelectedTabPageIndex = 1 Then
            GVUser.Focus()
        End If
    End Sub
End Class