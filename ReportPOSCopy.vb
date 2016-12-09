Public Class ReportPOSCopy
    Public Shared id As String = "90"
    Private Sub ReportPOSCopy_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim pos As New ClassPOS()
        Dim query As String = pos.queryDet("AND pd.id_pos=" + id + "", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPOS.DataSource = data
        GVPOS.OptionsPrint.UsePrintStyles = True

        GVPOS.AppearancePrint.FilterPanel.BackColor = Color.Transparent
        GVPOS.AppearancePrint.FilterPanel.ForeColor = Color.Black
        GVPOS.AppearancePrint.FilterPanel.Font = New Font("Segoe UI", 7, FontStyle.Regular)

        GVPOS.AppearancePrint.GroupFooter.BackColor = Color.Transparent
        GVPOS.AppearancePrint.GroupFooter.ForeColor = Color.Black
        GVPOS.AppearancePrint.GroupFooter.Font = New Font("Segoe UI", 7, FontStyle.Bold)

        GVPOS.AppearancePrint.GroupRow.BackColor = Color.Transparent
        GVPOS.AppearancePrint.GroupRow.ForeColor = Color.Black
        GVPOS.AppearancePrint.GroupRow.Font = New Font("Segoe UI", 7, FontStyle.Bold)


        GVPOS.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
        GVPOS.AppearancePrint.HeaderPanel.ForeColor = Color.Black
        GVPOS.AppearancePrint.HeaderPanel.Font = New Font("Segoe UI", 5, FontStyle.Regular)

        GVPOS.AppearancePrint.FooterPanel.BackColor = Color.Transparent
        GVPOS.AppearancePrint.FooterPanel.ForeColor = Color.Black
        GVPOS.AppearancePrint.FooterPanel.Font = New Font("Segoe UI", 5, FontStyle.Regular)

        GVPOS.AppearancePrint.Row.Font = New Font("Segoe UI", 5, FontStyle.Regular)

        GVPOS.OptionsPrint.ExpandAllDetails = True
        GVPOS.OptionsPrint.UsePrintStyles = True
        GVPOS.OptionsPrint.PrintDetails = True
        GVPOS.OptionsPrint.PrintFooter = True
    End Sub
End Class