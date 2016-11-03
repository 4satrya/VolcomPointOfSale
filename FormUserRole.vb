Public Class FormUserRole
    Public id As String = "-1"
    Public action As String = "-1"

    Private Sub FormUserRole_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "upd" Then
            GCRole.Enabled = True
            Dim r As New ClassUser()
            Dim query_main As String = r.queryRole("AND r.id_role=" + id + "", 1)
            Dim data_main As DataTable = execute_query(query_main, -1, True, "", "", "", "")
            TxtRole.Text = data_main.Rows(0)("role").ToString

            Dim query As String = "SELECT m.id_menu, m.menu, m.description, m.form, 
            IF(a.`view`, 'Yes', 'No') AS `view`,
            IF(a.`new`, 'Yes', 'No') AS `new`,
            IF(a.`edit`, 'Yes', 'No') AS `edit`,
            IF(a.`delete`, 'Yes', 'No') AS `delete`
            FROM tb_menu m
            LEFT JOIN tb_menu_access a ON a.id_menu = m.id_menu AND a.id_role='" + id + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCRole.DataSource = data
        Else
            GCRole.Enabled = False
        End If
    End Sub

    Private Sub FormUserRole_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormUserRole_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub
End Class