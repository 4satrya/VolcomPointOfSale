Public Class FormPOS
    Public id As String = "-1"
    Public id_shift As String = "-1"
    Dim id_user_shift As String = "-1"

    Private Sub FormPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LabelInfoLeft.Focus()
        viewCountry()
        viewCardType()
        viewPOSSTatus()
        shift()
    End Sub

    Sub shift()
        'check registered POS
        Dim id_pos_dev As String = "0"
        Dim pos As New ClassPOS()
        Dim dt_comp As DataTable = pos.getPOSDev()
        If dt_comp.Rows.Count <= 0 Then
            stopCustom("This computer is not registered")
            Close()
            Exit Sub
        Else
            id_pos_dev = dt_comp.Rows(0)("id_pos_dev").ToString
        End If

        'cek sudah ada inisialize atau belum
        Dim query_open As String = pos.queryShift("AND s.id_pos_dev=" + id_pos_dev + " AND s.is_open=1", "2")
        Dim dt_open As DataTable = execute_query(query_open, -1, True, "", "", "", "")
        If dt_open.Rows.Count <= 0 Then
            id_shift = "-1"
            FormBlack.Show()
            FormPOSShift.ShowDialog()
            FormBlack.Close()
        Else
            id_shift = dt_open.Rows(0)("id_shift").ToString
            TxtShift.Text = dt_open.Rows(0)("shift_type").ToString
            TxtPOS.Text = dt_open.Rows(0)("pos_dev").ToString
        End If

        'cek user
        id_user_shift = dt_open.Rows(0)("id_user").ToString
        If id_user_shift <> id_user Then
            stopCustom("User : '" + username_user + "' is active")
            Close()
            Exit Sub
        End If
    End Sub

    Private Sub FormPOS_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            help()
        ElseIf e.KeyCode = Keys.F2 Then
            payment()
        ElseIf e.KeyCode = Keys.F3 Then
            price()
        ElseIf e.KeyCode = Keys.F4 Then
            member()
        ElseIf e.KeyCode = Keys.F5 Then
            refund()
        ElseIf e.KeyCode = Keys.F6 Then
            pickup()
        ElseIf e.KeyCode = Keys.F7 Then
            drawer()
        ElseIf e.KeyCode = Keys.F8 Then 'closing
            closing_shift()
        ElseIf e.KeyCode = Keys.F9 Then
            term()
        ElseIf e.KeyCode = Keys.F10 Then
            bonus()
        ElseIf e.KeyCode = Keys.F11 Then
            voucher()
        ElseIf e.KeyCode = Keys.Insert 'new trans
            newTrans()
        ElseIf e.KeyCode = Keys.Escape Then
            exitForm()
        End If
    End Sub

    Sub closing_shift()
        Cursor = Cursors.WaitCursor
        Cursor = Cursors.Default
    End Sub

    Sub newTrans()
        TxtItemCode.Enabled = True
        TxtItemCode.Focus()
        Dim query As String = "INSERT INTO tb_pos(pos_number, pos_date, id_pos_status, id_pos_cat) 
        VALUES(header_number(4), NOW(), 1, 1); SELECT LAST_INSERT_ID(); "
        id = execute_query(query, 0, True, "", "", "", "")
        actionLoad()
    End Sub

    Sub payment()
        Cursor = Cursors.WaitCursor

        Cursor = Cursors.Default
    End Sub

    Sub price()
        Cursor = Cursors.WaitCursor

        Cursor = Cursors.Default
    End Sub

    Sub member()
        Cursor = Cursors.WaitCursor

        Cursor = Cursors.Default
    End Sub

    Sub refund()
        Cursor = Cursors.WaitCursor

        Cursor = Cursors.Default
    End Sub

    Sub pickup()
        Cursor = Cursors.WaitCursor

        Cursor = Cursors.Default
    End Sub

    Sub drawer()
        Cursor = Cursors.WaitCursor

        Cursor = Cursors.Default
    End Sub

    Sub term()
        Cursor = Cursors.WaitCursor
        Cursor = Cursors.Default
    End Sub

    Sub bonus()
        Cursor = Cursors.WaitCursor
        Cursor = Cursors.Default
    End Sub

    Sub voucher()
        Cursor = Cursors.WaitCursor
        Cursor = Cursors.Default
    End Sub


    Sub actionLoad()
        If id <> "-1" Then
            Dim query_c As New ClassPOS()
            Dim query As String = query_c.queryMain("-1", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtCashierUser.Text = data.Rows(0)("cashier").ToString
            TxtCashierName.Text = data.Rows(0)("cashier_name").ToString
            TxtNumber.Text = data.Rows(0)("pos_number").ToString
            DECreated.EditValue = data.Rows(0)("pos_date")
            TxtShift.Text = data.Rows(0)("shift_type").ToString
            TxtPOS.Text = data.Rows(0)("pos_dev").ToString
            LEStatus.ItemIndex = LEStatus.Properties.GetDataSourceRowIndex("id_pos_status", data.Rows(0)("id_pos_status").ToString)

            Dim subtotal As Decimal = 0
            Try
                subtotal = data.Rows(0)("subtotal")
            Catch ex As Exception
            End Try
            If subtotal <> 0 Then
                TxtSubTotal.EditValue = subtotal
            Else
                TxtSubTotal.EditValue = Nothing
            End If

            Dim discount As Decimal = 0
            Try
                discount = data.Rows(0)("discount")
            Catch ex As Exception
            End Try
            If discount <> 0 Then
                TxtDiscount.EditValue = discount
            Else
                TxtDiscount.EditValue = Nothing
            End If

            Dim tax As Decimal = 0
            Try
                tax = data.Rows(0)("tax")
            Catch ex As Exception
            End Try
            If tax <> 0 Then
                TxtTax.EditValue = tax
            Else
                TxtTax.EditValue = Nothing
            End If

            Dim total As Decimal = 0
            Try
                total = data.Rows(0)("total")
            Catch ex As Exception
            End Try
            If total <> 0 Then
                TxtTotal.EditValue = total
            Else
                TxtTotal.EditValue = Nothing
            End If

            TxtVoucherNo.Text = data.Rows(0)("voucher_number").ToString
            Dim voucher As Decimal = 0
            Try
                voucher = data.Rows(0)("voucher")
            Catch ex As Exception
            End Try
            If voucher <> 0 Then
                TxtVoucher.EditValue = voucher
            Else
                TxtVoucher.EditValue = Nothing
            End If

            Dim point As Decimal = 0
            Try
                point = data.Rows(0)("point")
            Catch ex As Exception
            End Try
            If point <> 0 Then
                TxtPoint.EditValue = point
            Else
                TxtPoint.EditValue = Nothing
            End If

            Dim cash As Decimal = 0
            Try
                cash = data.Rows(0)("cash")
            Catch ex As Exception
            End Try
            If point <> 0 Then
                TxtCash.EditValue = cash
            Else
                TxtCash.EditValue = Nothing
            End If

            Dim card As Decimal = 0
            Try
                card = data.Rows(0)("card")
            Catch ex As Exception
            End Try
            If card <> 0 Then
                TxtCard.EditValue = card
            Else
                TxtCard.EditValue = Nothing
            End If
            LECardType.ItemIndex = LECardType.Properties.GetDataSourceRowIndex("id_card_type", data.Rows(0)("id_card_type").ToString)
            TxtCardNumber.Text = data.Rows(0)("card_number").ToString
            TxtCardName.Text = data.Rows(0)("card_name").ToString
            'TxtMemberNumber -> belum ada
            ' -> belum ada
            LENation.ItemIndex = LENation.Properties.GetDataSourceRowIndex("id_country", data.Rows(0)("id_country").ToString)
            TxtSales.Text = data.Rows(0)("sales_name").ToString
        End If
    End Sub

    Sub help()
        'If GroupControlMenu.Visible = True Then
        '    GroupControlMenu.Visible = False
        'Else
        '    GroupControlMenu.Visible = True
        'End If
    End Sub

    Sub exitForm()
        Close()
    End Sub

    Private Sub FormPOS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewCountry()
        Dim query As String = "SELECT * FROM tb_m_country a ORDER BY a.country ASC "
        viewLookupQuery(LENation, query, -1, "country", "id_country")
    End Sub

    Sub viewCardType()
        Dim query As String = "SELECT * FROM tb_lookup_card_type a ORDER BY a.id_card_type ASC "
        viewLookupQuery(LECardType, query, -1, "card_type", "id_card_type")
    End Sub

    Sub viewPOSSTatus()
        Dim query As String = "SELECT * FROM tb_lookup_pos_status a ORDER BY a.id_pos_status ASC "
        viewLookupQuery(LEStatus, query, -1, "pos_status", "id_pos_status")
    End Sub

    Private Sub TxtItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtItemCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim val As String = TxtItemCode.Text.Trim()
            If val = "" Then
                FormBlack.Show()
                Cursor = Cursors.WaitCursor
                FormPOSItem.ShowDialog()
                Cursor = Cursors.Default
                FormBlack.Close()
                BringToFront()
            Else

            End If
        End If
    End Sub
End Class