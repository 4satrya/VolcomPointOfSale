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
            viewDetail()
            viewSummary()
            allow_status()
            XTPScanned.PageVisible = False
            XTPSummary.PageVisible = True
        Else
            LEReportStatus.Enabled = False
            BtnPrint.Enabled = False
            viewDetail()
            viewSummary()
            XTPSummary.PageVisible = False
        End If
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL get_rec('" + id + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCScan.DataSource = data
    End Sub


    Sub viewSummary()
        Dim query As String = "CALL get_rec_sum('" + id + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCScanSum.DataSource = data
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
        Cursor = Cursors.WaitCursor
        infoCustom("save")
        Cursor = Cursors.Default
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
End Class