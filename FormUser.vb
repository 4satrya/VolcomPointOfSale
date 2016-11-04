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

    Sub editRole()
        Cursor = Cursors.WaitCursor
        FormUserRole.id = GVRole.GetFocusedRowCellValue("id_role").ToString
        FormUserRole.action = "upd"
        FormUserRole.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormUser_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Escape Then 'close
            Close()
        ElseIf e.KeyCode = Keys.Insert Then 'new
            If XTCUser.SelectedTabPageIndex = 0 Then 'role
                FormUserRole.action = "ins"
                FormUserRole.ShowDialog()
            Else

            End If
        ElseIf e.KeyCode = Keys.Enter Then 'edit
            If XTCUser.SelectedTabPageIndex = 0 Then 'role
                editRole()
            Else 'user

            End If
        ElseIf e.KeyCode = Keys.Delete Then 'delete

        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCUser_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCUser.SelectedPageChanged
        If XTCUser.SelectedTabPageIndex = 0 Then
            GVRole.Focus()
        ElseIf XTCUser.SelectedTabPageIndex = 1 Then
            GVUser.Focus()
        End If
    End Sub

    Private Sub GVRole_DoubleClick(sender As Object, e As EventArgs) Handles GVRole.DoubleClick
        If GVRole.FocusedRowHandle >= 0 And GVRole.RowCount > 0 Then
            editRole()
        End If
    End Sub
End Class