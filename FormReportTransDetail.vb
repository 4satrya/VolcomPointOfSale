Public Class FormReportTransDetail
    Dim from As String = ""
    Dim until As String = ""
    Dim status As String = ""
    Dim shift As String = ""

    Private Sub FormReportTransDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEFrom.EditValue = getTimeDB()
        DEUntil.EditValue = getTimeDB()
        viewShift()
        viewStatus()
        viewPOSDev()
    End Sub

    Sub viewShift()
        Dim query As String = "SELECT 0 AS `id_shift_type`, 'ALL' AS `shift_type` UNION ALL "
        query += "SELECT s.id_shift_type, s.shift_type FROM tb_shift_type s ORDER BY id_shift_type ASC "
        viewLookupQuery(LEShift, query, 0, "shift_type", "id_shift_type")
    End Sub

    Sub viewStatus()
        Dim query As String = "SELECT * FROM tb_lookup_pos_status s ORDER BY s.id_pos_status ASC "
        viewLookupQuery(LEStatus, query, 1, "pos_status", "id_pos_status")
    End Sub

    Sub viewPOSDev()
        Dim query As String = "SELECT * FROM tb_pos_dev d ORDER BY d.id_pos_dev ASC "
        viewLookupQuery(LEPOSDev, query, 1, "pos_dev", "id_pos_dev")
    End Sub

    Sub exitForm()
        Close()
    End Sub

    Private Sub FormReportTransDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            exitForm()
        ElseIf e.KeyCode = Keys.F10 Then
            printPreview()
        End If
    End Sub

    Sub printPreview()
        'Cursor = Cursors.WaitCursor
        'FormBlack.Show()
        'ReportDaily.dt = GCDaily.DataSource
        'Dim Report As New ReportDaily()

        '' '... 
        '' ' creating and saving the view's layout to a new memory stream 
        'Dim str As System.IO.Stream
        'str = New System.IO.MemoryStream()
        'GVDaily.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)
        'Report.GVDaily.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)

        ''Grid Detail
        'ReportStyleGridview(Report.GVDaily)

        ''Parse val
        'Dim dt As DateTime = getTimeDB()
        'Report.LabelFrom.Text = from
        'Report.LabelUntil.Text = until
        'Report.LabelShift.Text = shift
        'Report.LabelStatus.Text = status
        'Report.LabelDate.Text = dt.ToString("dd\/MM\/yyyy")
        'Report.LabelTime.Text = dt.ToString("HH:mm:ss")

        '' Show the report's preview. 
        'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        'Tool.ShowPreviewDialog()
        'FormBlack.Close()
        'Cursor = Cursors.Default
    End Sub

    Private Sub PanelControlBack_Click(sender As Object, e As EventArgs) Handles PanelControlBack.Click
        exitForm()
    End Sub

    Private Sub FormReportTransDetail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class