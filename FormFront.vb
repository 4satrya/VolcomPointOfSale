Public Class FormFront
    Public connection_problem As Boolean = False
    Private Sub TIExitProg_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        Cursor = Cursors.WaitCursor
        End
        Cursor = Cursors.Default
    End Sub

    Private Sub FormFront_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub TIInv_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TIInv.ItemClick
        Cursor = Cursors.WaitCursor
        Opacity = 0
        FormHome.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TIPOS_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TIPOS.ItemClick
        FormPOS.ShowDialog()
    End Sub

    Private Sub FormFront_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        apply_skin()
        Cursor = Cursors.WaitCursor
        Try
            read_database_configuration()
            check_connection(True, "", "", "", "")

            'sync product
            Dim sc As New ClassItem
            sc.syncItem()

            Cursor = Cursors.Default
            WindowState = FormWindowState.Maximized
            Opacity = 100
        Catch ex As Exception
            Cursor = Cursors.Default
            connection_problem = True
            FormDatabase.id_type = "2"
            FormDatabase.TopMost = True
            FormDatabase.Show()
            FormDatabase.Focus()
            FormDatabase.TopMost = False
        End Try


        My.Application.ChangeCulture("en-US")
        My.Application.Culture.NumberFormat.NumberDecimalSeparator = ","
        My.Application.Culture.NumberFormat.NumberGroupSeparator = "."
    End Sub

    Private Sub FormFront_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            'Dim prn As New ClassPOS()
            'prn.printPos(90, False)
            ' FormPOSCopy.ShowDialog()
            Dim Report As New ReportPOSCopy()
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        End If
    End Sub
End Class