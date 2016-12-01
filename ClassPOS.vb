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
        s.id_user, csh.username AS `cashier`, csh_emp.employee_code AS `cashier_number`, csh_emp.employee_name AS `cashier_name`,  
        p.id_pos_status, stt.pos_status,
        p.id_pos_cat, cat.pos_cat,
        p.subtotal, p.discount, p.tax, p.total, 
        p.id_voucher, p.voucher_number, p.voucher, p.point, p.cash, 
        p.card, p.id_card_type, card.card_type, p.card_number, p.card_name,
        p.id_sales, emp.employee_code AS `sales_number`, emp.employee_name AS `sales_name`, p.id_country, cty.country
        FROM tb_pos p 
        INNER JOIN tb_shift s ON s.id_shift = p.id_shift 
        INNER JOIN tb_shift_type st ON st.id_shift_type = s.id_shift_type 
        INNER JOIN tb_user csh ON csh.id_user = s.id_user
        INNER JOIN tb_m_employee csh_emp ON csh_emp.id_employee = csh.id_employee
        INNER JOIN tb_pos_dev pd ON pd.id_pos_dev = s.id_pos_dev
        LEFT JOIN tb_m_employee emp ON emp.id_employee = p.id_sales
        LEFT JOIN tb_m_country cty ON cty.id_country = p.id_country
        INNER JOIN tb_lookup_pos_status stt ON stt.id_pos_status = p.id_pos_status
        INNER JOIN tb_lookup_pos_cat cat ON cat.id_pos_cat = p.id_pos_cat
        LEFT JOIN tb_lookup_card_type card ON card.id_card_type = p.id_card_type
        WHERE p.id_pos>0 "
        query += condition + " "
        query += "ORDER BY p.id_pos " + order_type
        Return query
    End Function

    Public Function queryDet(ByVal condition As String, ByVal order_type As String)
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

        Dim query As String = "SELECT pd.id_pos_det, pd.id_pos,
        pd.id_item, i.item_code, i.item_name, 
        pd.comm, pd.qty, pd.price, '' AS `is_edit`
        FROM tb_pos_det pd 
        INNER JOIN tb_item i ON i.id_item = pd.id_item 
        WHERE pd.id_pos>0 "
        query += condition + " "
        query += "ORDER BY pd.id_pos_det " + order_type
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
