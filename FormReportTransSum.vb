Public Class FormReportTransSum
    Dim from As String = ""
    Dim until As String = ""
    Dim status As String = ""

    Private Sub FormReportTransSum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEFrom.EditValue = getTimeDB()
        DEUntil.EditValue = getTimeDB()
        viewStatus()
    End Sub

    Sub viewStatus()
        Dim query As String = "SELECT * FROM tb_lookup_pos_status s ORDER BY s.id_pos_status ASC "
        viewLookupQuery(LEStatus, query, 1, "pos_status", "id_pos_status")
    End Sub

    Sub exitForm()
        Close()
    End Sub

    Private Sub FormReportTransSum_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            exitForm()
        ElseIf e.KeyCode = Keys.F10 Then
            printPreview()
        End If
    End Sub

    Sub printPreview()
        'Cursor = Cursors.WaitCursor
        'FormBlack.Show()
        'ReportTransDetail.dt = GCTransDetail.DataSource
        'Dim Report As New ReportTransDetail()

        '' '... 
        '' ' creating and saving the view's layout to a new memory stream 
        'Dim str As System.IO.Stream
        'str = New System.IO.MemoryStream()
        'GVTransDetail.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)
        'Report.GVTransDetail.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)

        ''Grid Detail
        'ReportStyleGridview(Report.GVTransDetail)

        ''Parse val
        'Dim dt As DateTime = getTimeDB()
        'Report.LabelFrom.Text = from
        'Report.LabelUntil.Text = until
        'Report.LabelShift.Text = shift
        'Report.LabelStatus.Text = status
        'Report.LabelDate.Text = dt.ToString("dd\/MM\/yyyy")
        'Report.LabelTime.Text = dt.ToString("HH:mm:ss")
        'Report.LabelPOS.Text = "POS-" + pos
        '' Show the report's preview. 
        'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        'Tool.ShowPreviewDialog()
        'FormBlack.Close()
        'Cursor = Cursors.Default
    End Sub

    Private Sub PanelControlBack_Click(sender As Object, e As EventArgs) Handles PanelControlBack.Click
        exitForm()
    End Sub

    Private Sub PanelControlBack_MouseHover(sender As Object, e As EventArgs) Handles PanelControlBack.MouseHover
        PanelControlBack.Cursor = Cursors.Hand
    End Sub

    Private Sub PanelControlBack_MouseLeave(sender As Object, e As EventArgs) Handles PanelControlBack.MouseLeave
        PanelControlBack.Cursor = Cursors.Default
    End Sub

    Private Sub FormReportTransSum_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub DEFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntil.Focus()
        End If
    End Sub

    Private Sub DEUntil_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntil.KeyDown
        If e.KeyCode = Keys.Enter Then
            LEStatus.Focus()
        End If
    End Sub

    Private Sub LEStatus_KeyDown(sender As Object, e As KeyEventArgs) Handles LEStatus.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnView.Focus()
        End If
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewContribution()
        viewPayment()
    End Sub

    Sub viewContribution()
        Cursor = Cursors.WaitCursor
        Dim cond As String = ""

        'date
        Dim dt_from As String = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim dt_until As String = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        cond += "AND (DATE(p.pos_date) >= DATE('" + dt_from + "') AND DATE(p.pos_date) <= DATE('" + dt_until + "')) "

        'status
        cond += "AND p.id_pos_status=" + LEStatus.EditValue.ToString + " "

        Dim query As String = "SELECT c.comp_number, c.comp_name,
        SUM(pd.qty) AS `total_qty`, 
        SUM(pd.qty*pd.price) AS `total`, 
        SUM((pd.comm/100)*(pd.qty*pd.price)) AS `commission`,
        (SUM(pd.qty*pd.price)-SUM((pd.comm/100)*(pd.qty*pd.price))) AS `consignment`
        FROM tb_pos_det pd
        INNER JOIN tb_pos p ON p.id_pos = pd.id_pos
        INNER JOIN tb_item i ON i.id_item = pd.id_item
        INNER JOIN tb_m_comp c ON c.id_comp = i.id_comp_sup
        WHERE 1=1 "
        query += cond + " "
        query += "GROUP BY i.id_comp_sup "
        query += "ORDER BY c.comp_number ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSales.DataSource = data

        'label
        from = DEFrom.Text
        until = DEUntil.Text
        status = LEStatus.Text
        Cursor = Cursors.Default
    End Sub

    Sub viewPayment()
        Cursor = Cursors.WaitCursor
        Dim cond As String = ""

        'date
        Dim dt_from As String = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim dt_until As String = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        cond += "AND (DATE(p.pos_date) >= DATE('" + dt_from + "') AND DATE(p.pos_date) <= DATE('" + dt_until + "')) "

        'status
        cond += "AND p.id_pos_status=" + LEStatus.EditValue.ToString + " "
        Cursor = Cursors.Default
    End Sub

    Private Sub DEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEFrom.EditValueChanged
        DEUntil.Properties.MinValue = DEFrom.EditValue
    End Sub

    Private Sub GVSales_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSales.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVPayment_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVPayment.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class