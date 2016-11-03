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
End Class
