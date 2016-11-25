Public Class ClassPOS

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

        Dim query As String = "SELECT p.id_pos, p.pos_number, p.pos_date, 
        p.id_shift, s.id_shift_type, st.shift_type, st.shift_name, st.shift_start, s.id_user, 
        s.id_pos_dev, pd.pos_dev, pd.mac_address,
        s.open_shift, s.close_shift, s.cash, s.is_open, 
        p.id_pos_status, 
        p.subtotal, p.discount, p.tax, p.total, 
        p.id_voucher, p.voucher_number, p.voucher, p.point, p.cash, 
        p.card, p.id_card_type, p.card_number, p.card_name
        FROM tb_pos p 
        INNER JOIN tb_shift s ON s.id_shift = p.id_shift 
        INNER JOIN tb_shift_type st ON st.id_shift_type = s.id_shift_type 
        INNER JOIN tb_pos_dev pd ON pd.id_pos_dev = s.id_pos_dev
        WHERE p.id_pos>0 "
        query += condition + " "
        query += "ORDER BY p.id_pos " + order_type
        Return query
    End Function


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
