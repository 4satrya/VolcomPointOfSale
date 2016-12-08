Public Class FormReportDaily
    Private Sub FormReportDaily_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEFrom.Focus()
        DEFrom.EditValue = getTimeDB()
        DEUntil.EditValue = getTimeDB()
        viewShift()
        viewStatus()
    End Sub

    Sub exitForm()
        Close()
    End Sub

    Sub viewPOS()
        Dim cond As String = ""

        'date
        Dim dt_from As String = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim dt_until As String = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        cond += "AND (DATE(p.pos_date) >= DATE('" + dt_from + "') AND DATE(p.pos_date) <= DATE('" + dt_until + "')) "

        'status
        cond += "AND p.id_pos_status=" + LEStatus.EditValue.ToString + " "

        'shift
        cond += "AND s.id_shift_type=" + LEShift.EditValue.ToString + " "

        Dim pos As New ClassPOS()
        Dim query As String = pos.queryMain(cond, "1")
        Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDaily.DataSource = dt
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewPOS()
    End Sub

    Sub viewShift()
        Dim query As String = "SELECT * FROM tb_shift_type s ORDER BY s.id_shift_type ASC "
        viewLookupQuery(LEShift, query, 0, "shift_type", "id_shift_type")
    End Sub

    Sub viewStatus()
        Dim query As String = "SELECT * FROM tb_lookup_pos_status s ORDER BY s.id_pos_status ASC "
        viewLookupQuery(LEStatus, query, 1, "pos_status", "id_pos_status")
    End Sub

    Private Sub FormReportDaily_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub PanelControlBack_Click(sender As Object, e As EventArgs) Handles PanelControlBack.Click
        exitForm()
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
            LEShift.Focus()
        End If
    End Sub

    Private Sub LEShift_KeyDown(sender As Object, e As KeyEventArgs) Handles LEShift.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnView.Focus()
        End If
    End Sub

    Private Sub GVDaily_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDaily.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class