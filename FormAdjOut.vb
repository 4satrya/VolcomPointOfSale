Public Class FormAdjOut
    Public id As String = "-1"
    Public action As String = "-1"
    Public id_comp As String = "-1"
    Dim id_report_status_glb As String = "-1"
    Dim item As New ClassItem()
    Dim role_prepared As String = ""
    Dim spv As String = ""

    Private Sub FormAdjOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormAdjOut_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormAdjOut_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

    End Sub

    Sub actionLoad()
        If action = "upd" Then
            Dim so As New ClassSO()
            Dim query As String = so.queryMain("AND s.id_so=" + id + "", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("so_number").ToString
            DECreated.EditValue = data.Rows(0)("so_date")
            id_comp = data.Rows(0)("id_comp").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
            MENote.Text = data.Rows(0)("so_note").ToString
            id_report_status_glb = data.Rows(0)("id_report_status").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            TxtPreparedBy.Text = data.Rows(0)("employee_name").ToString
            role_prepared = data.Rows(0)("role").ToString
            spv = get_setup_field("spv").ToString

            viewDetail()
            allow_status()
        Else
            LEReportStatus.Enabled = False
            BtnPrint.Enabled = False
            viewDetail()
        End If
    End Sub

    Sub viewReportStatus()
        Dim query As String = queryReportStatus()
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL get_adj_out('" + id + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCScanSum.DataSource = data
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
        FormPopUpContact.id_pop_up = "8"
        FormPopUpContact.ShowDialog()
        FormBlack.Close()
        BringToFront()
        If TxtNameCompFrom.Text <> "" Then
            BtnAddScan.Focus()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtCodeCompFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim dt As DataTable = get_company_by_code(addSlashes(TxtCodeCompFrom.Text), "AND (comp.id_comp_cat=5 OR comp.id_comp_cat=6) ")
            If dt.Rows.Count > 0 Then
                id_comp = dt.Rows(0)("id_comp").ToString
                TxtCodeCompFrom.Text = dt.Rows(0)("comp_number").ToString
                TxtNameCompFrom.Text = dt.Rows(0)("comp_name").ToString
                viewDetail()
                BtnAddScan.Focus()
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
End Class