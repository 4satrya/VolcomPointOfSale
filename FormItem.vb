﻿Public Class FormItem
    Private Sub PanelControlExit_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub FormItem_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub insert()
        FormItemDet.action = "ins"
        FormItemDet.ShowDialog()
    End Sub

    Sub edit()
        FormItemDet.action = "upd"
        FormItemDet.id = GVItem.GetFocusedRowCellValue("id_item").ToString
        FormItemDet.ShowDialog()
    End Sub

    Sub delete()
        If GVItem.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                Try
                    Dim id As String = GVItem.GetFocusedRowCellValue("id_item").ToString
                    Dim query As String = "DELETE FROM tb_item WHERE id_item=" + id + " "
                    execute_non_query(query, True, "", "", "", "")
                    viewItem()
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        End If
    End Sub

    Sub importExcel()

    End Sub

    Sub exitForm()
        Close()
    End Sub

    Sub printPreview()
        print(GCItem, "Product List")
    End Sub

    Sub viewItem()
        Dim i As New ClassItem()
        Dim query As String = i.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItem.DataSource = data
    End Sub

    Private Sub FormItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewItem()
    End Sub

    Private Sub FormItem_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Escape Then 'close
            Close()
        ElseIf e.KeyCode = Keys.Insert Then 'new
            insert()
        ElseIf e.KeyCode = Keys.Enter Then 'edit
            edit()
        ElseIf e.KeyCode = Keys.Delete Then 'delete
            delete()
        ElseIf e.KeyCode = Keys.P AndAlso e.Modifiers = Keys.Control Then 'delete
            printPreview()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        insert()
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        edit()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        delete()
    End Sub

    Private Sub ImportExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportExcelToolStripMenuItem.Click
        importExcel()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        printPreview()
    End Sub
End Class