Public Class ClassUser
    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        If order_type = "1" Then
            order_type = "ASC "
        ElseIf order_type = "2" Then
            order_type = "DESC "
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "SELECT u.id_user, u.id_role, r.role, u.id_employee, e.employee_code,e.employee_name, u.username, u.password, u.is_change 
        FROM tb_user u 
        INNER JOIN tb_role r ON r.id_role = u.id_role 
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee 
        WHERE u.id_user>0 "
        query += condition + " "
        query += "ORDER BY u.id_user " + order_type
        Return query
    End Function

    Public Sub access(e As KeyEventArgs, form As DevExpress.XtraEditors.XtraForm)
        If e.KeyCode = Keys.Escape Then 'close
            form.Close()
        ElseIf e.KeyCode = Keys.Insert Then 'new
            MsgBox("new")
        ElseIf e.KeyCode = Keys.Enter Then 'edit
            MsgBox("edit")
        ElseIf e.KeyCode = Keys.Delete Then 'delete
            MsgBox("delete")
        End If
    End Sub

    Public Sub hideMenu()
        For m As Integer = 0 To FormHome.TileControl1.Groups.Count - 1
            Dim group As DevExpress.XtraEditors.TileGroup = TryCast(FormHome.TileControl1.Groups(m), DevExpress.XtraEditors.TileGroup)
            For i As Integer = 0 To group.Items.Count - 1
                If TypeOf group.Items(i) Is DevExpress.XtraEditors.TileItem Then
                    Dim item As DevExpress.XtraEditors.TileItem = TryCast(group.Items(i), DevExpress.XtraEditors.TileItem)
                    If item.Name.ToString <> "TIExit" And item.Name.ToString <> "TILogout" Then
                        item.Visible = False
                    End If
                End If
            Next i
        Next
    End Sub

    Public Sub setMenuAccess()
        For m As Integer = 0 To FormHome.TileControl1.Groups.Count - 1
            Dim group As DevExpress.XtraEditors.TileGroup = TryCast(FormHome.TileControl1.Groups(m), DevExpress.XtraEditors.TileGroup)
            For i As Integer = 0 To group.Items.Count - 1
                If TypeOf group.Items(i) Is DevExpress.XtraEditors.TileItem Then
                    Dim item As DevExpress.XtraEditors.TileItem = TryCast(group.Items(i), DevExpress.XtraEditors.TileItem)
                    Dim data_filter As DataRow() = dt_acc.Select("[menu]='" + item.Name.ToString + "'")
                    If data_filter.Length > 0 Then
                        item.Visible = True
                    End If
                End If
            Next i
        Next
    End Sub

    Public Sub setDataAccess()
        Dim query As String = "SELECT * FROM tb_menu_access a
        INNER JOIN tb_menu m ON m.id_menu = a.id_menu
        WHERE a.id_role = '" + id_role_login + "'"
        dt_acc = execute_query(query, -1, True, "", "", "", "")
    End Sub

    Public Sub clearDataAccess()
        dt_acc.Clear()
    End Sub

    Public Sub logout()
        Try
            id_user = Nothing
            id_role_login = Nothing
            role_login = Nothing
            username_user = Nothing
            name_user = Nothing
            is_change_pass_user = Nothing
            clearDataAccess()
            hideMenu()
            FormHome.Opacity = 0
            FormLogin.ShowDialog()
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
    End Sub
End Class
