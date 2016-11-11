Public Class FormRecDet
    Public id As String = "-1"
    Public action As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_comp_to As String = "-1"
    Dim id_report_status As String = "-1"
    Dim item As New ClassItem()

    Private Sub FormRecDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status ASC "
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "upd" Then
            Dim rc As New ClassRec()
            Dim query As String = rc.queryMain("AND r.id_rec=" + id + "", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("rec_number").ToString
            DECreated.EditValue = data.Rows(0)("rec_date")
            id_comp_from = data.Rows(0)("id_comp_from").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
            id_comp_to = data.Rows(0)("id_comp_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("comp_number_to").ToString
            TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
            TxtRef.Text = data.Rows(0)("ref").ToString
            DERefDate.EditValue = data.Rows(0)("ref_date")
            MENote.Text = data.Rows(0)("rec_note").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

            viewDetail()
            allow_status()
            XTPScanned.PageVisible = False
            XTPSummary.PageVisible = True
        Else
            LEReportStatus.Enabled = False
            BtnPrint.Enabled = False
            viewDetail()
            XTPSummary.PageVisible = False
        End If
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL get_rec('" + id + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If action = "ins" Then
            GCScan.DataSource = data
        Else
            GCScanSum.DataSource = data
        End If
    End Sub


    Sub allow_status()
        If check_status(id_report_status) Then
            MENote.Enabled = True
            BtnSave.Enabled = True
            TxtCodeCompFrom.Enabled = True
            TxtCodeCompTo.Enabled = True
            BtnBrowseFrom.Enabled = True
            BtnBrowseTo.Enabled = True
            TxtRef.Enabled = True
            DERefDate.Enabled = True
            LEReportStatus.Enabled = True
        Else
            MENote.Enabled = False
            BtnSave.Enabled = False
            TxtCodeCompFrom.Enabled = False
            TxtCodeCompTo.Enabled = False
            BtnBrowseFrom.Enabled = False
            BtnBrowseTo.Enabled = False
            TxtRef.Enabled = False
            DERefDate.Enabled = False
            LEReportStatus.Enabled = False
        End If
        PanelControlItem.Enabled = False

        'ATTACH
        'If check_attach_report_status(id_report_status, "91", id_fg_repair) Then
        '    BtnAttachment.Enabled = True
        'Else
        '    BtnAttachment.Enabled = False
        'End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
    End Sub


    Private Sub BtnBrowseFrom_Click(sender As Object, e As EventArgs) Handles BtnBrowseFrom.Click
        Cursor = Cursors.WaitCursor
        FormBlack.Show()
        FormPopUpContact.id_pop_up = "1"
        FormPopUpContact.ShowDialog()
        FormBlack.Close()
        BringToFront()
        If TxtNameCompFrom.Text <> "" Then
            TxtCodeCompTo.Focus()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnBrowseTo_Click(sender As Object, e As EventArgs) Handles BtnBrowseTo.Click
        Cursor = Cursors.WaitCursor
        FormBlack.Show()
        FormPopUpContact.id_pop_up = "2"
        FormPopUpContact.ShowDialog()
        FormBlack.Close()
        BringToFront()
        If TxtNameCompTo.Text <> "" Then
            TxtRef.Focus()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtRef_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtRef.KeyDown
        If e.KeyCode = Keys.Enter Then
            DERefDate.Focus()
        End If
    End Sub

    Private Sub FormRecDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub TxtCodeCompFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim dt As DataTable = get_company_by_code(addSlashes(TxtCodeCompFrom.Text), "-1")
            If dt.Rows.Count > 0 Then
                id_comp_from = dt.Rows(0)("id_comp").ToString
                TxtCodeCompFrom.Text = dt.Rows(0)("comp_number").ToString
                TxtNameCompFrom.Text = dt.Rows(0)("comp_name").ToString
                TxtCodeCompTo.Focus()
            Else
                stopCustom("Account not found !")
                id_comp_from = "-1"
                TxtCodeCompFrom.Text = ""
                TxtNameCompFrom.Text = ""
                TxtCodeCompFrom.Focus()
            End If
        End If
    End Sub

    Private Sub TxtCodeCompTo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim dt As DataTable = get_company_by_code(addSlashes(TxtCodeCompTo.Text), "-1")
            If dt.Rows.Count > 0 Then
                id_comp_to = dt.Rows(0)("id_comp").ToString
                TxtCodeCompTo.Text = dt.Rows(0)("comp_number").ToString
                TxtNameCompTo.Text = dt.Rows(0)("comp_name").ToString
                TxtRef.Focus()

            Else
                stopCustom("Account not found !")
                id_comp_to = "-1"
                TxtCodeCompTo.Text = ""
                TxtNameCompTo.Text = ""
                TxtCodeCompTo.Focus()
            End If
        End If
    End Sub

    Private Sub FormRecDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 Then 'save
            save()
        ElseIf e.KeyCode = Keys.F6 Then 'close
            closeForm()
        ElseIf e.KeyCode = Keys.F7 Then 'select
            selectList()
        ElseIf e.KeyCode = Keys.F8 Then 'add scan
            addScan()
        ElseIf e.KeyCode = Keys.F9 Then 'remove scan
            removeScan()
        ElseIf e.KeyCode = Keys.F10 Then 'print
            print()
        End If
    End Sub

    Sub save()
        Dim ref As String = addSlashes(TxtRef.Text)
        Dim ref_date As String = DateTime.Parse(DERefDate.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim rec_note As String = addSlashes(MENote.Text)
        Dim id_report_status As String = LEReportStatus.EditValue.ToString
        Dim gv As DevExpress.XtraGrid.Views.Grid.GridView
        If action = "ins" Then
            gv = GVScan
        Else
            gv = GVScanSum
        End If

        If id_comp_from = "-1" Or id_comp_to = "-1" Or ref = "" Or ref_date = "" Or gv.RowCount = 0 Then
            stopCustom("Data can't blank")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save this transaction?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                If action = "ins" Then
                    Dim data_temp As DataTable = GCScan.DataSource
                    Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True", app_host, app_username, app_password, app_database)
                    Dim connection As New MySql.Data.MySqlClient.MySqlConnection(connection_string)
                    connection.Open()
                    Dim command As MySql.Data.MySqlClient.MySqlCommand = connection.CreateCommand()
                    Dim qry As String = "DROP TABLE IF EXISTS tb_rec_temp; CREATE TEMPORARY TABLE IF NOT EXISTS tb_rec_temp AS ( SELECT * FROM ("
                    For d As Integer = 0 To data_temp.Rows.Count - 1
                        Dim id_item As String = data_temp.Rows(d)("id_item").ToString
                        Dim item_code As String = data_temp.Rows(d)("item_code").ToString
                        Dim item_name As String = data_temp.Rows(d)("item_name").ToString
                        Dim size As String = data_temp.Rows(d)("size").ToString
                        Dim price As String = decimalSQL(data_temp.Rows(d)("price").ToString)
                        If d > 0 Then
                            qry += "UNION ALL "
                        End If
                        qry += "SELECT '" + id_item + "' AS `id_item`, '" + item_code + "' AS `item_code`, '" + item_name + "' AS `item_name`, '" + size + "' AS `size` , '" + price + "' AS `price` "
                    Next
                    qry += ") a ); ALTER TABLE tb_rec_temp CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "
                    command.CommandText = qry
                    command.ExecuteNonQuery()
                    command.Dispose()
                    ' Console.WriteLine(qry)

                    Dim data_view As New DataTable
                    Dim qry_view As String = "SELECT a.id_item, a.item_code, a.item_name, a.size, COUNT(a.id_item) AS `rec_qty`, a.price 
                                FROM tb_rec_temp a 
                                GROUP BY a.id_item"
                    Dim adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(qry_view, connection)
                    adapter.SelectCommand.CommandTimeout = 300
                    adapter.Fill(data_view)
                    adapter.Dispose()
                    connection.Close()
                    connection.Dispose()
                    GCScanSum.DataSource = data_view

                    'main query
                    Dim query As String = "INSERT INTO tb_rec(id_comp_from, id_comp_to, rec_number, rec_date, ref, ref_date, rec_note, id_report_status) 
                    VALUES('" + id_comp_from + "', '" + id_comp_to + "', header_number(1), NOW(), '" + ref + "', '" + ref_date + "', '" + rec_note + "', '1'); SELECT LAST_INSERT_ID(); "
                    id = execute_query(query, 0, True, "", "", "", "")

                    'detail
                    Dim query_det As String = "INSERT INTO tb_rec_det(id_rec, id_item, price, rec_qty) VALUES"
                    For i As Integer = 0 To data_view.Rows.Count - 1
                        Dim id_item As String = data_view.Rows(i)("id_item").ToString
                        Dim price As String = data_view.Rows(i)("price").ToString
                        Dim rec_qty As String = data_view.Rows(i)("rec_qty").ToString
                        If i > 0 Then
                            query_det += ", "
                        End If
                        query_det += "('" + id + "','" + id_item + "', '" + price + "', '" + rec_qty + "')"
                    Next
                    If data_view.Rows.Count > 0 Then
                        execute_non_query(query_det, True, "", "", "", "")
                    End If

                    FormRec.viewRec()
                    FormRec.GVRec.FocusedRowHandle = find_row(FormRec.GVRec, "id_rec", id)
                    action = "upd"
                    actionLoad()
                    infoCustom("Document #" + TxtNumber.Text + " was created successfully.")
                Else
                    Dim query As String = "UPDATE tb_rec SET id_comp_from='" + id_comp_from + "', id_comp_to='" + id_comp_to + "', 
                    ref='" + ref + "', ref_date='" + ref_date + "', rec_note='" + rec_note + "', id_report_status='" + id_report_status + "'
                    WHERE id_rec ='" + id + "' "
                    execute_non_query(query, True, "", "", "", "")
                    FormRec.viewRec()
                    FormRec.GVRec.FocusedRowHandle = find_row(FormRec.GVRec, "id_rec", id)
                    action = "upd"
                    actionLoad()
                End If
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Sub closeForm()
        Cursor = Cursors.WaitCursor
        Close()
        Cursor = Cursors.Default
    End Sub

    Sub selectList()
        Cursor = Cursors.WaitCursor
        GVScan.Focus()
        Cursor = Cursors.Default
    End Sub

    Sub addScan()
        Cursor = Cursors.WaitCursor
        TxtItemCode.Focus()
        Cursor = Cursors.Default
    End Sub

    Sub removeScan()
        Cursor = Cursors.WaitCursor
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = DialogResult.Yes Then
            GVScan.DeleteSelectedRows()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub print()
        Cursor = Cursors.WaitCursor
        infoCustom("print")
        Cursor = Cursors.Default
    End Sub

    Private Sub GVScan_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVScan.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click
        selectList()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles BtnAddScan.Click
        addScan()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles BtnRemoveScan.Click
        removeScan()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        save()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        closeForm()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print()
    End Sub

    Private Sub TxtItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtItemCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim code As String = TxtItemCode.Text
            Dim query As String = item.queryMain("AND i.item_code='" + code + "' ", "1")
            Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                Dim newRow As DataRow = (TryCast(GCScan.DataSource, DataTable)).NewRow()
                newRow("id_rec_det") = "0"
                newRow("id_item") = dt(0)("id_item").ToString
                newRow("item_code") = dt(0)("item_code").ToString
                newRow("item_name") = dt(0)("item_name").ToString
                newRow("size") = dt(0)("size").ToString
                newRow("rec_qty") = 1
                newRow("price") = dt(0)("price")
                TryCast(GCScan.DataSource, DataTable).Rows.Add(newRow)
                GCScan.RefreshDataSource()
                GVScan.RefreshData()
            Else
                stopCustom("Code not found")
            End If
            TxtItemCode.Text = ""
            TxtItemCode.Focus()
        End If
    End Sub

    Private Sub GVScanSum_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVScanSum.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class