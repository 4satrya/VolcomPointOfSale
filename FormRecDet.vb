Public Class FormRecDet
    Public id As String = "-1"
    Public action As String = "-1"

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

        Else
            LEReportStatus.Enabled = False
            BtnPrint.Enabled = False
        End If
    End Sub
End Class