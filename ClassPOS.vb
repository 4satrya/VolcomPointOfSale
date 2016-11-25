Public Class ClassPOS
    Public Function getPOSDev() As DataTable
        Dim mycomp As New ClassUser()
        Dim query As String = "SELECT * FROM tb_pos_dev WHERE mac_address='" + mycomp.getMacAddress() + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function


    Public Function queryShift(ByVal condition As String, ByVal order_type As String) As String
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

        Dim query As String = "SELECT s.id_shift, s.id_shift_type, st.shift_type, st.shift_name, st.shift_start, 
        s.id_user, s.id_pos_dev, dev.pos_dev, dev.mac_address, s.open_shift, s.close_shift, s.cash, s.is_open 
        FROM tb_shift s 
        INNER JOIN tb_shift_type st ON st.id_shift_type = s.id_shift_type 
        INNER JOIN tb_pos_dev dev ON dev.id_pos_dev = s.id_pos_dev
        WHERE s.id_shift>0 "
        query += condition + " "
        query += "ORDER BY s.id_shift " + order_type
        Return query
    End Function

End Class
