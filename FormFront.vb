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
        Opacity = 0
        FormLoginInv.ShowDialog()
    End Sub

    Private Sub TIPOS_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TIPOS.ItemClick
        FormLogin.is_open_form = True
        FormLogin.menu_acc = "14"
        FormLogin.ShowDialog()
    End Sub

    Private Sub FormFront_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        apply_skin()
        Cursor = Cursors.WaitCursor
        Try
            read_database_configuration()
            check_connection(True, "", "", "", "")
            Cursor = Cursors.Default
            Opacity = 100
        Catch ex As Exception
            Cursor = Cursors.Default
            connection_problem = True
            FormDatabase.id_type = "2"
            FormDatabase.TopMost = True
            FormDatabase.Show()
            FormDatabase.Focus()
            FormDatabase.TopMost = False
            Exit Sub
        End Try

        'sync
        Dim sy As New ClassSync()
        sy.sync_list.Add("1")
        sy.sync_list.Add("2")
        sy.synchronize()

        My.Application.ChangeCulture("en-US")
        My.Application.Culture.NumberFormat.NumberDecimalSeparator = ","
        My.Application.Culture.NumberFormat.NumberGroupSeparator = "."
    End Sub

    Private Sub FormFront_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            'Cursor = Cursors.WaitCursor
            'Dim sy As New ClassSync()
            'sy.BackupCustomTable()
            'Cursor = Cursors.Default
            'Dim prn As New ClassPOS()
            'prn.printPos(90, False)
            ' FormPOSCopy.ShowDialog()
            'ReportPOSCopy.id = "89"
            'Dim Report As New ReportPOSCopy()
            'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            'Tool.PreviewForm.PrintControl.Zoom = 2.0F
            'Tool.PreviewForm.FormBorderStyle = FormBorderStyle.None
            'Tool.ShowPreviewDialog()
        ElseIf e.KeyCode = Keys.F2 Then
            'Cursor = Cursors.WaitCursor
            'Dim sy As New ClassSync()
            'sy.RestoreCustomTable()
            'Cursor = Cursors.Default
        End If
    End Sub

    Private Sub TIEnd_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TIEnd.ItemClick
        End
    End Sub
End Class