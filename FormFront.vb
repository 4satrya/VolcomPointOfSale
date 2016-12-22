﻿Public Class FormFront
    Public connection_problem As Boolean = False
    Private Sub TIExitProg_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        Cursor = Cursors.WaitCursor
        End
        Cursor = Cursors.Default
    End Sub

    Private Sub FormFront_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub TIInv_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TIPOS_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)

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
        info()
        My.Application.ChangeCulture("en-US")
        My.Application.Culture.NumberFormat.NumberDecimalSeparator = ","
        My.Application.Culture.NumberFormat.NumberGroupSeparator = "."
        syncProcess()
    End Sub

    Sub syncProcess()
        'sync
        SplashScreenManager1.ShowWaitForm()
        Dim sy As New ClassSync()
        sy.sync_list.Add("1")
        sy.sync_list.Add("2")
        sy.sync_list.Add("3")
        sy.synchronize()
        SplashScreenManager1.CloseWaitForm()
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

    Private Sub TIEnd_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        End
    End Sub

    Private Sub PCClose_Click(sender As Object, e As EventArgs) Handles PCClose.Click
        End
    End Sub

    Private Sub PIInv_Click(sender As Object, e As EventArgs) Handles PIInv.Click
        Opacity = 0
        FormLoginInv.ShowDialog()
    End Sub

    Private Sub PIPOS_Click(sender As Object, e As EventArgs) Handles PIPOS.Click
        FormLogin.is_open_form = True
        FormLogin.menu_acc = "14"
        FormLogin.ShowDialog()
    End Sub

    Sub info()
        Dim query As String = "select * from tb_opt o JOIN (SELECT DATE_FORMAT(NOW(),'%W, %d %M %Y') AS dt) d"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LabelStoreName.Text = data.Rows(0)("outlet_name").ToString
        LabelFooter.Text = data.Rows(0)("company_name").ToString + " - " + data.Rows(0)("company_tagline").ToString
        LabelDate.Text = data.Rows(0)("dt").ToString

        Dim str As String = ""
        Dim csh As String = ""
        Dim id_pos_dev As String = ""
        Dim pos As New ClassPOS()
        Dim dt_comp As DataTable = pos.getPOSDev()
        If dt_comp.Rows.Count <= 0 Then
            str += "This computer is not registered "
        Else
            id_pos_dev = dt_comp.Rows(0)("id_pos_dev").ToString
        End If

        'cek sudah ada inisialize atau belum
        Dim query_open As String = pos.queryShift("AND s.id_pos_dev=" + id_pos_dev + " AND s.is_open=1", "2")
        Dim dt_open As DataTable = execute_query(query_open, -1, True, "", "", "", "")
        If dt_open.Rows.Count <= 0 Then
            str += "/ There is no shift "
            csh += "CASHIER ACTIVE : -"
        Else
            str += "POS#" + dt_open.Rows(0)("pos_dev").ToString + " / Shift " + dt_open.Rows(0)("shift_type").ToString
            csh += "CASHIER ACTIVE : " + dt_open.Rows(0)("username").ToString
        End If
        LabelInfo.Text = str
        LabelCsh.Text = csh
    End Sub

    Private Sub PISync_Click(sender As Object, e As EventArgs) Handles PISync.Click
        syncProcess()
    End Sub
End Class