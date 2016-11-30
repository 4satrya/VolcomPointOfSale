﻿Public Class FormPOS
    Public id As String = "-1"
    Public id_shift As String = "-1"
    Dim id_user_shift As String = "-1"
    Dim new_trans As Boolean = False
    Dim id_stock_last As String = "-1"
    Dim id_detail_last As String = "-1"
    Dim id_display_default As String = "-1"
    Dim id_sales As String = "-1"
    Dim is_payment_ok As Boolean = False
    Dim id_voucher_db As String = "-1"

    Private Sub FormPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LabelInfoLeft.Focus()
        viewCountry()
        viewCardType()
        viewPOSSTatus()
        shift()

        'get display default
        id_display_default = get_setup_field("id_display_default")
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
        ElseIf e.KeyCode = Keys.Insert And is_payment_ok = False 'new trans
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
        TxtDiscount.Enabled = False
        TxtVoucherNo.Enabled = False
        TxtVoucher.Enabled = False
        TxtPoint.Enabled = False
        TxtCash.Enabled = False
        TxtCard.Enabled = False
        LECardType.Enabled = False
        TxtCardNumber.Enabled = False
        TxtCardName.Enabled = False

        TxtItemCode.Enabled = True
        TxtItemCode.Focus()
        If Not new_trans Then
            Dim query As String = "INSERT INTO tb_pos(id_shift, pos_number, pos_date, id_pos_status, id_pos_cat) 
            VALUES('" + id_shift + "', header_number(4), NOW(), 1, 1); SELECT LAST_INSERT_ID(); "
            id = execute_query(query, 0, True, "", "", "", "")
            new_trans = True
            actionLoad()
        End If
    End Sub

    Sub payment()
        Cursor = Cursors.WaitCursor
        TxtItemCode.Enabled = False
        TxtDiscount.Enabled = True
        TxtDiscount.EditValue = 0
        TxtDiscount.Focus()
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
            Dim query As String = query_c.queryMain("AND p.id_pos=" + id + "", "1")
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
            TxtQty.EditValue = 1

            viewDetail()
        End If
    End Sub

    Sub viewDetail()
        Dim query_c As New ClassPOS()
        Dim query As String = query_c.queryDet("AND pd.id_pos=" + id + " ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPOS.DataSource = data
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
                Dim code As String = TxtItemCode.Text
                '- query direct to stock Dim query As String = "CALL view_stock_item('AND j.id_comp=" + id_display_default + " AND f.item_code=" + code + " AND j.storage_item_datetime<=''9999-12-01'' ', '2')"
                Dim i As New ClassItem()
                Dim query As String = i.queryMain("AND i.item_code='" + code + "' ", "1", False)
                Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
                If dt.Rows.Count > 0 Then
                    'Dim qty_avail As Decimal = dt.Rows(0)("qty_avl")
                    'If qty_avail <= 0 Then
                    '    stopCustom("No stock available")
                    'Else
                    'End If
                    'insert stock
                    'insertStock(dt(0)("id_item").ToString, id_display_default, "1", "2", "-1")

                    'insert detail
                    insertDetail(dt(0)("id_item").ToString, decimalSQL(dt(0)("comm").ToString), "1", decimalSQL(dt(0)("price").ToString), "-1")

                    'insert gv
                    Dim newRow As DataRow = (TryCast(GCPOS.DataSource, DataTable)).NewRow()
                    newRow("id_pos_det") = id_detail_last
                    newRow("id_item") = dt(0)("id_item").ToString
                    newRow("item_code") = dt(0)("item_code").ToString
                    newRow("item_name") = dt(0)("item_name").ToString
                    newRow("qty") = 1
                    newRow("price") = dt(0)("price")
                    newRow("comm") = dt(0)("comm")
                    newRow("is_edit") = "2"
                    TryCast(GCPOS.DataSource, DataTable).Rows.Add(newRow)
                    GCPOS.RefreshDataSource()
                    GVPOS.RefreshData()

                    'info
                    getSubTotal()
                    Dim rh As Integer = GVPOS.RowCount - 1
                    showDisplay(dt(0)("item_name").ToString, "1", GVPOS.GetRowCellDisplayText(rh, "amount").ToString)
                Else
                    stopCustom("Code not found")
                End If
                TxtQty.EditValue = 1
                TxtItemCode.Text = ""
                TxtItemCode.Focus()
            End If
        ElseIf e.KeyCode = Keys.add Then
            If GVPOS.RowCount > 0 Then
                Dim last_index As Integer = GVPOS.RowCount - 1
                TxtItemCode.Text = GVPOS.GetRowCellValue(last_index, "item_code").ToString
                TxtItemCode.Enabled = False
                GVPOS.SetRowCellValue(last_index, "is_edit", "1")
                TxtQty.Enabled = True
                TxtQty.Focus()
            End If
        End If
    End Sub

    Sub showDisplay(ByVal name As String, ByVal qty As String, ByVal price As String)
        LabelInfoLeft.Text = name.Substring(0, 13) + " @" + qty.ToString
        LabelControlPrice.Text = price.ToString
    End Sub

    Private Sub TxtQty_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtQty.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim qty As Integer = TxtQty.EditValue
            Dim rh As Integer = GVPOS.RowCount - 1
            Dim code As String = TxtItemCode.Text
            Dim id_pos_det As String = GVPOS.GetRowCellValue(rh, "id_pos_det")


            If qty > 0 Then 'plus
                'insert detail
                insertDetail("0", "0", qty.ToString, "0", id_pos_det)

                GVPOS.SetRowCellValue(rh, "qty", qty)
                GVPOS.SetRowCellValue(rh, "is_edit", "2")
                GCPOS.RefreshDataSource()
                GVPOS.RefreshData()
                getSubTotal()
                showDisplay(GVPOS.GetRowCellDisplayText(rh, "item_name").ToString, qty, GVPOS.GetRowCellDisplayText(rh, "amount").ToString)
                TxtQty.EditValue = 1
                TxtQty.Enabled = False
                TxtItemCode.Enabled = True
                TxtItemCode.Text = ""
                TxtItemCode.Focus()
            ElseIf qty = 0 Then 'zero
                GVPOS.SetRowCellValue(rh, "is_edit", "2")
                GCPOS.RefreshDataSource()
                GVPOS.RefreshData()
                TxtQty.EditValue = 1
                TxtQty.Enabled = False
                TxtItemCode.Enabled = True
                TxtItemCode.Text = ""
                TxtItemCode.Focus()
            Else 'minus
                Dim id_item As String = GVPOS.GetRowCellValue(rh, "id_item").ToString
                GVPOS.ActiveFilterString = "[id_item]='" + id_item + "' AND [is_edit]='2' "
                GCPOS.RefreshDataSource()
                GVPOS.RefreshData()
                Dim max As Integer = 0
                For i As Integer = 0 To GVPOS.RowCount - 1
                    max = max + GVPOS.GetRowCellValue(i, "qty")
                Next

                GVPOS.ActiveFilterString = ""
                GCPOS.RefreshDataSource()
                GVPOS.RefreshData()

                If (qty * -1) <= max Then
                    'insert detail
                    insertDetail("0", "0", qty.ToString, "0", id_pos_det)

                    GVPOS.SetRowCellValue(rh, "qty", qty)
                    GVPOS.SetRowCellValue(rh, "is_edit", "2")
                    GCPOS.RefreshDataSource()
                    GVPOS.RefreshData()
                    getSubTotal()
                    showDisplay(GVPOS.GetRowCellDisplayText(rh, "item_name").ToString, qty, GVPOS.GetRowCellDisplayText(rh, "amount").ToString)
                    TxtQty.EditValue = 1
                    TxtQty.Enabled = False
                    TxtItemCode.Enabled = True
                    TxtItemCode.Text = ""
                    TxtItemCode.Focus()
                Else
                    GVPOS.SetRowCellValue(rh, "is_edit", "2")
                    GCPOS.RefreshDataSource()
                    GVPOS.RefreshData()
                    TxtQty.EditValue = 1
                    TxtQty.Enabled = False
                    TxtItemCode.Enabled = True
                    TxtItemCode.Text = ""
                    TxtItemCode.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub TxtItemCode_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtItemCode.KeyUp
        If GVPOS.RowCount <= 0 Then
            If e.KeyCode = Keys.Add Then
                TxtItemCode.Text = ""
                TxtItemCode.Focus()
            End If
        End If
    End Sub

    Private Sub GVPOS_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVPOS.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub getSubTotal()
        TxtSubTotal.EditValue = GVPOS.Columns("amount").SummaryItem.SummaryValue()

        Dim subtotal As Decimal = 0
        Try
            subtotal = TxtSubTotal.EditValue
        Catch ex As Exception
        End Try

        Dim discount As Decimal = 0
        Try
            discount = TxtDiscount.EditValue
        Catch ex As Exception
        End Try

        Dim tax As Decimal = 0
        Try
            tax = TxtTax.EditValue
        Catch ex As Exception
        End Try

        TxtTotal.EditValue = subtotal - discount + tax
    End Sub

    Sub insertStock(ByVal id_item_par As String, id_comp_par As String, qty_par As String, ByVal id_storage_category_par As String, id_stock_par As String)
        If id_stock_par <> "-1" Then 'edit
            Dim query As String = "UPDATE tb_storage_item SET storage_item_qty='" + qty_par + "' WHERE id_storage_item='" + id_stock_par + "' "
            execute_non_query(query, True, "", "", "", "")
        Else 'new
            Dim query As String = "INSERT INTO tb_storage_item(id_comp, id_storage_category, id_item, report_mark_type, id_report, storage_item_qty, storage_item_datetime, id_stock_status) 
            VALUES ('" + id_comp_par + "', '" + id_storage_category_par + "', '" + id_item_par + "', '3', '" + id + "', '" + qty_par + "', NOW(), '1'); SELECT LAST_INSERT_ID(); "
            id_stock_last = execute_query(query, 0, True, "", "", "", "")
        End If
    End Sub

    Sub insertDetail(ByVal id_item_par As String, ByVal comm_par As String, ByVal qty_par As String, ByVal price_par As String, ByVal id_pos_det_par As String)
        If id_pos_det_par <> "-1" Then 'edit only qty
            Dim query As String = "UPDATE tb_pos_det SET qty='" + qty_par + "' WHERE id_pos_det='" + id_pos_det_par + "'"
            execute_non_query(query, True, "", "", "", "")
        Else
            Dim query As String = "INSERT INTO tb_pos_det(id_pos, id_item, comm, qty, price) 
            VALUES ('" + id + "', '" + id_item_par + "', '" + comm_par + "', '" + qty_par + "', '" + price_par + "'); SELECT LAST_INSERT_ID(); "
            id_detail_last = execute_query(query, 0, True, "", "", "", "")
        End If
    End Sub

    Private Sub TxtDiscount_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDiscount.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim discount As Decimal = TxtDiscount.EditValue
            If discount = 0 Then
                getSubTotal()
                TxtDiscount.Enabled = False
                TxtCash.Enabled = True
                TxtCash.EditValue = TxtTotal.EditValue
                TxtCash.Focus()
            Else 'with login
                getSubTotal()
                TxtDiscount.Enabled = False
                TxtCash.Enabled = True
                TxtCash.EditValue = TxtTotal.EditValue
                TxtCash.Focus()
            End If
        End If
    End Sub

    Private Sub TxtCash_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCash.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtCash.EditValue > TxtTotal.EditValue Then
                'jika lebih ada kembalian
                TxtChange.EditValue = TxtCash.EditValue - TxtTotal.EditValue
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Payment OK ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = DialogResult.Yes Then
                    TxtCash.Enabled = False
                    paymentOK()
                Else
                    TxtCash.EditValue = TxtTotal.EditValue
                End If
            ElseIf TxtCash.EditValue = TxtTotal.EditValue Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Payment OK ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = DialogResult.Yes Then
                    TxtCash.Enabled = False
                    paymentOK()
                Else
                    TxtCash.EditValue = TxtTotal.EditValue
                End If
            Else
                'jika kurang sisanya ke card
                TxtCash.Enabled = False
                TxtCard.Enabled = True
                TxtCard.EditValue = TxtTotal.EditValue - TxtCash.EditValue
                TxtCard.Focus()
            End If
        End If
    End Sub

    Sub paymentOK()
        Dim subtotal As String = "0"
        Try
            subtotal = decimalSQL(TxtSubTotal.EditValue.ToString)
        Catch ex As Exception
        End Try

        Dim discount As String = "0"
        Try
            discount = decimalSQL(TxtDiscount.EditValue.ToString)
        Catch ex As Exception
        End Try

        Dim tax As String = "0"
        Try
            tax = decimalSQL(TxtTax.EditValue.ToString)
        Catch ex As Exception
        End Try

        Dim total As String = "0"
        Try
            total = decimalSQL(TxtTotal.EditValue.ToString)
        Catch ex As Exception
        End Try

        Dim id_voucher As String = id_voucher_db
        If id_voucher = "-1" Then
            id_voucher = "NULL"
        Else
            id_voucher = "'" + id_voucher_db + "'"
        End If
        Dim voucher_number As String = addSlashes(TxtVoucherNo.Text)
        Dim voucher As String = "0"
        Try
            voucher = decimalSQL(TxtVoucher.EditValue.ToString)
        Catch ex As Exception
        End Try

        Dim point As String = "0"
        Try
            point = decimalSQL(TxtPoint.EditValue.ToString)
        Catch ex As Exception
        End Try

        Dim cash As String = "0"
        Try
            cash = decimalSQL(TxtCash.EditValue.ToString)
        Catch ex As Exception

        End Try

        Dim card As String = "0"
        Try
            card = decimalSQL(TxtCard.EditValue.ToString)
        Catch ex As Exception
        End Try

        Dim id_card_type As String = "NULL"
        Try
            id_card_type = "'" + LECardType.EditValue.ToString + "'"
        Catch ex As Exception
        End Try

        Dim card_number As String = addSlashes(TxtCardNumber.Text.ToString)
        Dim card_name As String = addSlashes(TxtCardName.Text.ToString)

        Dim query As String = "UPDATE tb_pos SET is_payment_ok=1,
        subtotal='" + subtotal + "', discount='" + discount + "', tax='" + tax + "',
        total='" + total + "', id_voucher=" + id_voucher + ", voucher_number='" + voucher_number + "',
        voucher='" + voucher + "', point='" + point + "', cash='" + cash + "', card='" + card + "',
        id_card_type=" + id_card_type + ", card_number='" + card_number + "', card_name='" + card_name + "'
        WHERE id_pos=" + id + " "
        execute_non_query(query, True, "", "", "", "")
        is_payment_ok = True
        TxtSales.Enabled = True
        TxtSales.Focus()
    End Sub

    Private Sub TxtCard_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCard.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtCash.EditValue + TxtCard.EditValue < TxtTotal.EditValue Then
                stopCustom("Payment cannot less than payment")
                TxtCard.EditValue = TxtTotal.EditValue - TxtCash.EditValue
                TxtCard.Focus()
            ElseIf TxtCash.EditValue + TxtCard.EditValue > TxtTotal.EditValue
                TxtChange.EditValue = (TxtCash.EditValue + TxtCard.EditValue) - TxtTotal.EditValue
                TxtCard.Enabled = False
                LECardType.Enabled = True
                LECardType.Focus()
            Else
                TxtCard.Enabled = False
                LECardType.Enabled = True
                LECardType.Focus()
            End If
        End If
    End Sub

    Private Sub LECardType_KeyDown(sender As Object, e As KeyEventArgs) Handles LECardType.KeyDown
        If e.KeyCode = Keys.Enter Then
            If LECardType.EditValue = Nothing Then
                LECardType.Focus()
            Else
                LECardType.Enabled = False
                TxtCardNumber.Enabled = True
                TxtCardNumber.Focus()
            End If
        End If
    End Sub

    Private Sub TxtCardNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCardNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtCardNumber.EditValue = Nothing Then
                TxtCardNumber.Focus()
            Else
                TxtCardNumber.Enabled = False
                TxtCardName.Enabled = True
                TxtCardName.Focus()
            End If
        End If
    End Sub

    Private Sub TxtCardName_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCardName.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtCardName.EditValue = Nothing Then
                TxtCardName.Focus()
            Else
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Payment OK ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = DialogResult.Yes Then
                    TxtCardName.Enabled = False
                    paymentOK()
                Else
                    TxtCardName.Text = ""
                End If
            End If
        End If
    End Sub

    Private Sub TxtSales_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtSales.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim code As String = addSlashes(TxtSales.Text)
            If code = "" Then
                FormBlack.Show()
                Cursor = Cursors.WaitCursor
                FormPOSSales.ShowDialog()
                Cursor = Cursors.Default
                FormBlack.Close()
                BringToFront()
            Else
                Dim query As String = "SELECT * FROM tb_m_employee WHERE employee_code='" + code + "' "
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                If data.Rows.Count > 0 Then
                    id_sales = data.Rows(0)("id_employee").ToString
                    TxtSales.Enabled = False
                    LENation.Enabled = True
                    LENation.Focus()
                Else
                    stopCustom("Sales not found")
                    TxtSales.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub LENation_KeyDown(sender As Object, e As KeyEventArgs) Handles LENation.KeyDown
        If e.KeyCode = Keys.Enter Then
            If LENation.EditValue = Nothing Then
                LENation.Focus()
            Else
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Transaction OK ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = DialogResult.Yes Then
                    completed()
                Else
                    LENation.Focus()
                End If
            End If
        End If
    End Sub

    Sub completed()
        'potong stok
        Dim query_stc As String = "INSERT INTO tb_storage_item(id_comp, id_storage_category, id_item, report_mark_type, id_report, storage_item_qty, storage_item_datetime, id_stock_status) 
        SELECT '" + id_display_default + "', IF(qty>=0,'2', '1'), id_item, '3', '" + id + "', ABS(qty), NOW(), '1' 
        FROM tb_pos_det WHERE id_pos=" + id + " "
        execute_non_query(query_stc, True, "", "", "", "")

        'closed pos
        Dim query As String = "UPDATE tb_pos SET id_sales='" + id_sales + "', id_country='" + LENation.EditValue.ToString + "', id_pos_status=2 WHERE id_pos=" + id + ""
        execute_non_query(query, True, "", "", "", "")
        Close()
    End Sub
End Class