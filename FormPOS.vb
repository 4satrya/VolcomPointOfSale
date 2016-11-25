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
            closing()
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

    Sub closing()
        Cursor = Cursors.WaitCursor
        Cursor = Cursors.Default
    End Sub

    Sub newTrans()
        TxtItemCode.Enabled = True
        TxtItemCode.Focus()
        LEStatus.ItemIndex = LEStatus.Properties.GetDataSourceRowIndex("id_pos_status", 1)
        Dim query As String = "INSERT INTO tb_pos(pos_number, pos_date, id_pos_status) 
        VALUES(header_number(4), NOW(), 1); SELECT LAST_INSERT_ID(); "
        id = execute_query(query, 0, True, "", "", "", "")
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