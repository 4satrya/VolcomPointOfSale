﻿Public Class FormSODet
    Public id As String = "-1"
    Public action As String = "-1"
    Public id_comp As String = "-1"
    Dim id_report_status_glb As String = "-1"
    Dim item As New ClassItem()
    Dim role_prepared As String = ""
    Dim spv As String = ""

    Private Sub FormSODet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "upd" Then
            Dim rt As New ClassTrf()
            Dim query As String = rt.queryMain("AND t.id_trf=" + id + "", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("trf_number").ToString
            DECreated.EditValue = data.Rows(0)("trf_date")
            id_comp = data.Rows(0)("id_comp").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
            MENote.Text = data.Rows(0)("trf_note").ToString
            id_report_status_glb = data.Rows(0)("id_report_status").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            TxtPreparedBy.Text = data.Rows(0)("employee_name").ToString
            role_prepared = data.Rows(0)("role").ToString
            spv = get_setup_field("spv").ToString

            viewDetail()
            allow_status()
            XTPScanned.PageVisible = False
            XTPSummary.PageVisible = True
        Else
            LEReportStatus.Enabled = False
            BtnPrint.Enabled = False
            XTPSummary.PageVisible = False
        End If
    End Sub

    Sub viewReportStatus()
        Dim query As String = queryReportStatus()
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL get_so('" + id + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If action = "ins" Then
            GCScan.DataSource = data
        Else
            GCScanSum.DataSource = data
        End If
    End Sub


    Sub allow_status()
        If check_status(id_report_status_glb) Then
            MENote.Enabled = True
            BtnSave.Enabled = True
            LEReportStatus.Enabled = True
        Else
            MENote.Enabled = False
            BtnSave.Enabled = False
            LEReportStatus.Enabled = False
        End If
        PanelControlItem.Enabled = False
        TxtCodeCompFrom.Enabled = False
        BtnBrowseFrom.Enabled = False

        If check_print_report_status(id_report_status_glb) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
    End Sub

    Private Sub BtnBrowseFrom_Click(sender As Object, e As EventArgs) Handles BtnBrowseFrom.Click
        Cursor = Cursors.WaitCursor
        FormBlack.Show()
        FormPopUpContact.cond = "AND (tb_m_comp.id_comp_cat=5 OR tb_m_comp.id_comp_cat=6) "
        FormPopUpContact.id_pop_up = "7"
        FormPopUpContact.ShowDialog()
        FormBlack.Close()
        BringToFront()
        If TxtNameCompFrom.Text <> "" Then
            TxtItemCode.Focus()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormSODet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSODet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 Then 'save
            save()
        ElseIf e.KeyCode = Keys.Escape Then 'close
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
        If id_report_status_glb <> "5" And id_report_status_glb <> "6" Then
            Dim rec_note As String = addSlashes(MENote.Text)
            Dim id_report_status As String = LEReportStatus.EditValue.ToString
            Dim gv As DevExpress.XtraGrid.Views.Grid.GridView
            If action = "ins" Then
                gv = GVScan
            Else
                gv = GVScanSum
            End If

            If id_comp = "-1" Or gv.RowCount = 0 Then
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
                        Dim qry As String = "DROP TABLE IF EXISTS tb_so_temp; CREATE TEMPORARY TABLE IF NOT EXISTS tb_so_temp AS ( SELECT * FROM ("
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
                        qry += ") a ); ALTER TABLE tb_so_temp CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "
                        command.CommandText = qry
                        command.ExecuteNonQuery()
                        command.Dispose()
                        ' Console.WriteLine(qry)

                        Dim data_view As New DataTable
                        Dim qry_view As String = "SELECT a.id_item, a.item_code, a.item_name, a.size, COUNT(a.id_item) AS `so_qty`, a.price 
                                FROM tb_so_temp a 
                                GROUP BY a.id_item"
                        Dim adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(qry_view, connection)
                        adapter.SelectCommand.CommandTimeout = 300
                        adapter.Fill(data_view)
                        adapter.Dispose()
                        connection.Close()
                        connection.Dispose()

                        'get data stock
                        Dim query_stock = "CALL view_stock_item('AND j.id_comp=" + id_comp + " AND j.storage_item_datetime<=''9999-12-01'' ', '2')"
                        Dim data_stock As DataTable = execute_query(query_stock, -1, True, "", "", "", "")
                        Dim tb1 = data_stock.AsEnumerable()
                        Dim tb2 = data_view.AsEnumerable()
                        Dim query_cek = From table1 In tb1
                                        Group Join table_tmp In tb2 On table1("id_item").ToString Equals table_tmp("id_item").ToString
                                        Into Group
                                        From y1 In Group.DefaultIfEmpty()
                                        Select New With
                                        {
                                            .id_item = table1.Field(Of String)("id_item").ToString,
                                            .item_code = table1.Field(Of String)("item_code").ToString,
                                            .item_name = table1.Field(Of String)("item_name").ToString,
                                            .size = table1.Field(Of String)("size").ToString,
                                            .so_qty = If(y1 Is Nothing, 0, y1("so_qty")),
                                            .qty = table1("qty_avl"),
                                            .price = table1("price"),
                                            .diff = If(y1 Is Nothing, 0, y1("so_qty")) - table1("qty_avl")
                                        }
                        GCScanSum.DataSource = Nothing
                        GCScanSum.DataSource = query_cek.ToList()

                        'main query
                        'Dim query As String = "INSERT INTO tb_rec(id_comp_to, rec_number, rec_date, ref, ref_date, rec_note, id_report_status, id_prepared_by) 
                        'VALUES('" + id_comp + "', header_number(1), NOW(), '" + rec_note + "', '1', '" + id_user + "'); SELECT LAST_INSERT_ID(); "
                        'id = execute_query(query, 0, True, "", "", "", "")

                        ''detail
                        'Dim query_det As String = "INSERT INTO tb_rec_det(id_rec, id_item, price, rec_qty) VALUES"
                        'For i As Integer = 0 To data_view.Rows.Count - 1
                        '    Dim id_item As String = data_view.Rows(i)("id_item").ToString
                        '    Dim price As String = data_view.Rows(i)("price").ToString
                        '    Dim rec_qty As String = data_view.Rows(i)("rec_qty").ToString
                        '    If i > 0 Then
                        '        query_det += ", "
                        '    End If
                        '    query_det += "('" + id + "','" + id_item + "', '" + price + "', '" + rec_qty + "')"
                        'Next
                        'If data_view.Rows.Count > 0 Then
                        '    execute_non_query(query_det, True, "", "", "", "")
                        'End If

                        'FormRec.viewRec()
                        'FormRec.GVRec.FocusedRowHandle = find_row(FormRec.GVRec, "id_rec", id)
                        'action = "upd"
                        'actionLoad()
                        'infoCustom("Document #" + TxtNumber.Text + " was created successfully.")
                    Else
                        Dim query As String = "UPDATE tb_rec SET id_comp='" + id_comp + "', 
                        rec_note='" + rec_note + "', id_report_status='" + id_report_status + "' "
                        If id_report_status = "5" Or id_report_status = "6" Then 'final
                            query += ", final_status_time=NOW() "
                        End If
                        query += "WHERE id_rec ='" + id + "' "
                        execute_non_query(query, True, "", "", "", "")

                        'completed
                        If id_report_status = "6" Then
                            Dim query_stock As String = "INSERT INTO tb_storage_item(id_comp, id_storage_category, id_item, report_mark_type, id_report, storage_item_qty, storage_item_datetime, id_stock_status) 
                            SELECT tb_rec.id_comp_to, 1, tb_rec_det.id_item, 1, " + id + ", tb_rec_det.rec_qty, NOW(), 1 
                            FROM tb_rec_det 
                            INNER JOIN tb_rec ON tb_rec.id_rec = tb_rec_det.id_rec
                            WHERE tb_rec_det.id_rec=" + id + ""
                            execute_non_query(query_stock, True, "", "", "", "")
                        End If

                        FormRec.viewRec()
                        FormRec.GVRec.FocusedRowHandle = find_row(FormRec.GVRec, "id_rec", id)
                        action = "upd"
                        actionLoad()

                        'show preview when completed
                        If id_report_status = "6" Then
                            print()
                        End If
                    End If
                    Cursor = Cursors.Default
                End If
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
        If action = "ins" Then
            Cursor = Cursors.WaitCursor
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                GVScan.DeleteSelectedRows()
                GCScan.RefreshDataSource()
                GVScan.RefreshData()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Sub print()
        Cursor = Cursors.WaitCursor
        FormBlack.Show()
        ReportTrf.id = id
        ReportTrf.dt = GCScanSum.DataSource
        Dim Report As New ReportTrf()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVScanSum.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVScanSum.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVScanSum)

        'Parse val
        Report.LabelFrom.Text = TxtCodeCompFrom.Text + " - " + TxtNameCompFrom.Text
        Report.LRecNumber.Text = TxtNumber.Text
        Report.LRecDate.Text = DECreated.Text
        Report.LabelNote.Text = MENote.Text
        Report.LabelStatus.Text = LEReportStatus.Text
        Report.LabelPreparedBy.Text = TxtPreparedBy.Text.ToUpper
        Report.LabelRoleBy.Text = role_prepared
        Report.LabelSpv.Text = spv.ToUpper


        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
        FormBlack.Close()
        Cursor = Cursors.Default
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

    Private Sub TxtCodeCompFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim dt As DataTable = get_company_by_code(addSlashes(TxtCodeCompFrom.Text), "AND (comp.id_comp_cat=5 OR comp.id_comp_cat=6) ")
            If dt.Rows.Count > 0 Then
                id_comp = dt.Rows(0)("id_comp").ToString
                TxtCodeCompFrom.Text = dt.Rows(0)("comp_number").ToString
                TxtNameCompFrom.Text = dt.Rows(0)("comp_name").ToString
                viewDetail()
                TxtItemCode.Focus()
            Else
                stopCustom("Account not found !")
                id_comp = "-1"
                TxtCodeCompFrom.Text = ""
                TxtNameCompFrom.Text = ""
                viewDetail()
                TxtCodeCompFrom.Focus()
            End If
        End If
    End Sub

    Private Sub TxtItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtItemCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim code As String = TxtItemCode.Text
            Dim query As String = item.queryMain("AND i.item_code='" + code + "' AND i.is_active=1", "1", False)
            Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                Dim newRow As DataRow = (TryCast(GCScan.DataSource, DataTable)).NewRow()
                newRow("id_so_det") = "0"
                newRow("id_item") = dt(0)("id_item").ToString
                newRow("item_code") = dt(0)("item_code").ToString
                newRow("item_name") = dt(0)("item_name").ToString
                newRow("size") = dt(0)("size").ToString
                newRow("so_qty") = 1
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
End Class