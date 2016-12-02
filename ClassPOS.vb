Public Class ClassPOS
    Public Const eClear As String = Chr(27) + "@"
    Public Const eCentre As String = Chr(27) + Chr(97) + "1"
    Public Const eLeft As String = Chr(27) + Chr(77) + "1" + Chr(27) + Chr(97) + "0"
    Public Const eRight As String = Chr(27) + Chr(97) + "2"
    Public Const eDrawer As String = eClear + Chr(27) + "p" + Chr(0) + ".}"
    Public Const eCut As String = Chr(27) + "i" + vbCrLf
    Public Const eSmlText As String = Chr(27) + "!" + Chr(1)
    Public Const eNmlText As String = Chr(27) + "!" + Chr(0)
    Public Const eInit As String = eNmlText + Chr(13) + Chr(27) + "3" + Chr(18) + vbCrLf
    Public Const eBigCharOn As String = Chr(27) + "!" + Chr(56)
    Public Const eBigCharOff As String = Chr(27) + "!" + Chr(0)

    Private prn As New ClassRawPrint

    Private PrinterName As String = get_setup_field("printer_name")

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

        Dim query As String = "SELECT p.id_pos, p.pos_number, 
        p.pos_date, DATE_FORMAT(p.pos_date,'%d/%m/%Y') AS  `pos_date_display` , DATE_FORMAT(p.pos_date,'%H:%i') AS  `pos_time_display`,
        p.id_shift, s.id_shift_type, st.shift_type, st.shift_name, st.shift_start, s.id_user, 
        s.id_pos_dev, pd.pos_dev, pd.mac_address,
        s.open_shift, s.close_shift, s.cash AS `cash_initial`, s.is_open, 
        s.id_user, csh.username AS `cashier`, csh_emp.employee_code AS `cashier_number`, csh_emp.employee_name AS `cashier_name`,  
        p.id_pos_status, stt.pos_status,
        p.id_pos_cat, cat.pos_cat,
        p.subtotal, p.discount, p.tax, p.total, 
        CAST(((100/(100+o.tax))*p.total) AS DECIMAL(15,0)) AS `kena_ppn`,
        CAST(((o.tax/(100+o.tax))*p.total) AS DECIMAL(15,0)) AS `ppn`,
        p.id_voucher, p.voucher_number, p.voucher, p.point, p.cash, 
        p.card, p.id_card_type, card.card_type, p.card_number, p.card_name, p.`change`,
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
        JOIN tb_opt o
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
        pd.id_item, i.item_code, 
        i.item_name, 
        IF(LENGTH(i.item_name)<=35,i.item_name, SUBSTRING(i.item_name,1,35)) AS `item_name_display`,
        pd.comm, pd.qty, pd.price, (pd.price*pd.qty) AS `amo`, 
        '' AS `is_edit`
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

    '===========PRINTER==================
    Private Sub StartPrint()
        prn.OpenPrint(PrinterName)
    End Sub

    Private Sub PrintHeader()
        Dim query As String = "SELECT * FROM tb_opt"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Print(eInit + eCentre + Chr(27) + Chr(33) + Chr(16) + data.Rows(0)("header_1").ToString)
        Print(eNmlText + Chr(27) + Chr(77) + "1" + data.Rows(0)("header_2").ToString)
        Print(Chr(27) + Chr(77) + "1" + data.Rows(0)("header_3").ToString)
        Print(Chr(27) + Chr(77) + "1" + data.Rows(0)("header_4").ToString)
        Print(Chr(27) + Chr(77) + "1" + data.Rows(0)("header_5").ToString + eLeft)
        PrintDashes()
    End Sub

    Private Sub PrintBody(ByVal id_pos As String)
        Dim query_main As String = queryMain("AND p.id_pos=" + id_pos + "", "1")
        Dim dt_main As DataTable = execute_query(query_main, -1, True, "", "", "", "")
        Print(eLeft + dt_main.Rows(0)("pos_number").ToString + Chr(13) + eRight + dt_main.Rows(0)("pos_date_display").ToString)
        Print(eLeft + dt_main.Rows(0)("pos_dev").ToString + Chr(13) + eRight + dt_main.Rows(0)("pos_time_display").ToString)

        Print(eLeft + "No.--------Code--------Qty--------Amount")
        Dim query_det As String = queryDet("AND pd.id_pos=" + id_pos + "", "1")
        Dim dt_det As DataTable = execute_query(query_det, -1, True, "", "", "", "")
        Dim no As Integer = 1
        For i As Integer = 0 To (dt_det.Rows.Count - 1)
            printItem(no.ToString, dt_det.Rows(i)("item_code").ToString, dt_det.Rows(i)("item_name_display").ToString, Decimal.Parse(dt_det.Rows(i)("qty")).ToString("N0"), Decimal.Parse(dt_det.Rows(i)("amo")).ToString("N0"))
            no += 1
        Next

        PrintDashes()
        Print(eLeft + "Total" + Chr(13) + eRight + Decimal.Parse(dt_main.Rows(0)("total")).ToString("N0"))
        Print(eLeft + "Dasar Kena PPN" + Chr(13) + eRight + Decimal.Parse(dt_main.Rows(0)("kena_ppn")).ToString("N0"))
        Print(eLeft + "PPN" + Chr(13) + eRight + Decimal.Parse(dt_main.Rows(0)("ppn")).ToString("N0"))
        Print(eLeft + "Cash" + Chr(13) + eRight + Decimal.Parse(dt_main.Rows(0)("cash")).ToString("N0"))
        If dt_main.Rows(0)("card") > 0 Then
            Print(eLeft + "Card" + Chr(13) + eRight + Decimal.Parse(dt_main.Rows(0)("card")).ToString("N0"))
        End If
        If dt_main.Rows(0)("voucher") > 0 Then
            Print(eLeft + "Voucher" + Chr(13) + eRight + Decimal.Parse(dt_main.Rows(0)("voucher")).ToString("N0"))
        End If
        Print(eLeft + "Change" + Chr(13) + eRight + Decimal.Parse(dt_main.Rows(0)("change")).ToString("N0"))

        'jika ada card/voucher
        Print(vbLf)
        If dt_main.Rows(0)("card") > 0 Then
            Print(eLeft + "       Card Type" + "    : " + dt_main.Rows(0)("card_type").ToString)
            Print(eLeft + "       Number" + "       : " + dt_main.Rows(0)("card_number").ToString)
            Print(eLeft + "       Holder" + "       : " + dt_main.Rows(0)("card_name").ToString)
        End If
        If dt_main.Rows(0)("voucher") > 0 Then
            Print(eLeft + "       Voucher No." + "  : " + dt_main.Rows(0)("voucher_number"))
        End If

        Print(vbLf)
    End Sub

    Private Sub printItem(ByVal no As String, code As String, desc As String, qty As String, amount As String)
        'no=5; code=18; qty=2; amount=15
        If no.Length = "1" Then
            no = " " + no + ".  "
        Else
            no = no + ".  "
        End If

        Dim code_max As Integer = 18
        If code.Length < code_max Then
            For c = 1 To (code_max - code.Length)
                code += " "
            Next
        Else
            code = code
        End If

        If qty.Length = "1" Then
            qty = " " + qty
        Else
            qty = qty
        End If

        Dim amount_max As Integer = 15
        If amount.Length < amount_max Then
            For a = 1 To (amount_max - amount.Length)
                amount = " " + amount
            Next
        Else
            amount = amount
        End If
        Print(eLeft + no + code + qty + amount)
        Print(eLeft + "     " + desc)
    End Sub

    Private Sub PrintFooter()
        Dim query As String = "SELECT * FROM tb_opt"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Print(eCentre + data.Rows(0)("footer_1").ToString)
        Print(eCentre + data.Rows(0)("footer_2").ToString)
        Print(eCentre + data.Rows(0)("footer_3").ToString)
        Print(eCentre + data.Rows(0)("footer_4").ToString)
        Print(vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + eCut + eDrawer)
    End Sub

    Private Sub Print(Line As String)
        prn.SendStringToPrinter(PrinterName, Line + vbLf)
    End Sub

    Private Sub PrintDashes()
        Print(eLeft + eNmlText + "-".PadRight(33, "-"))
    End Sub

    Private Sub EndPrint()
        prn.ClosePrint()
    End Sub

    Public Sub printPos(ByVal id_pos As String)
        StartPrint()

        If prn.PrinterIsOpen = True Then
            PrintHeader()
            PrintBody(id_pos)
            PrintFooter()
            EndPrint()
        End If
    End Sub

End Class
