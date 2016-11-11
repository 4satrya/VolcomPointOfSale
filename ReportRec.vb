Imports DevExpress.XtraReports.UI

Public Class ReportRec
    Public Shared id As String = "-1"
    Public Shared dt As DataTable

    Private Sub ReportRec_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCScanSum.DataSource = dt
    End Sub

End Class