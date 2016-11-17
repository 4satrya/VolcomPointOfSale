Public Class FormTrf
    Private Sub FormTrf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewTrf()
    End Sub

    Private Sub FormTrf_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormTrf_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then 'close
            Close()
        ElseIf e.KeyCode = Keys.F8 Then 'new
            insert()
        ElseIf e.KeyCode = Keys.F7 Then 'view
            edit()
        ElseIf e.KeyCode = Keys.F9 Then 'delete
            'delete()
        ElseIf e.KeyCode = Keys.F10 Then 'delete
            printPreview()
        End If
    End Sub

    Sub insert()
        Cursor = Cursors.WaitCursor
        'FormRetDet.action = "ins"
        'FormRetDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub edit()
        Cursor = Cursors.WaitCursor
        If GVTrf.FocusedRowHandle >= 0 Then
            'FormRetDet.action = "upd"
            'FormRetDet.id = GVRet.GetFocusedRowCellValue("id_ret").ToString
            'FormRetDet.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub delete()
        'If GVRet.FocusedRowHandle >= 0 Then
        '    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        '    If confirm = DialogResult.Yes Then
        '        Try
        '            Dim id As String = GVRet.GetFocusedRowCellValue("id_ret").ToString
        '            Dim query As String = "DELETE FROM tb_ret WHERE id_ret=" + id + " "
        '            execute_non_query(query, True, "", "", "", "")
        '            viewRet()
        '        Catch ex As Exception
        '            errorDelete()
        '        End Try
        '    End If
        'End If
    End Sub

    Sub exitForm()
        Cursor = Cursors.WaitCursor
        Close()
        Cursor = Cursors.Default
    End Sub

    Sub printPreview()
        Cursor = Cursors.WaitCursor
        FormBlack.Show()
        print(GCTrf, "Transfer List")
        FormBlack.Close()
        Cursor = Cursors.Default
    End Sub

    Sub viewTrf()
        Cursor = Cursors.WaitCursor
        Dim i As New ClassTrf()
        Dim query As String = i.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCTrf.DataSource = data '
        Cursor = Cursors.Default
    End Sub


End Class