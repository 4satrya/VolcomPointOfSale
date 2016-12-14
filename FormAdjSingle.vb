Public Class FormAdjSingle
    Public id_pop_up As String = "-1"
    Public id_comp As String = "-1"

    Private Sub FormAdjSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtQty.EditValue = 0
        TxtSOH.EditValue = 0
    End Sub

    Private Sub FormAdjSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormAdjSingle_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then

        ElseIf e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

    Private Sub TxtCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtCode.Text = "" Then
                Cursor = Cursors.WaitCursor
                FormPOSItem.id_pop_up = "1"
                FormPOSItem.ShowDialog()
                Cursor = Cursors.Default
            Else
                Cursor = Cursors.Default
                Dim query As String = "CALL view_stock_item('AND j.id_comp=" + id_comp + " AND f.item_code=''" + addSlashes(TxtCode.Text) + "''', 2)"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                If data.Rows.Count > 0 Then
                    TxtDesc.Text = data.Rows(0)("item_name").ToString
                    'TxtSOH.Text
                Else
                    stopCustom("Code not found")
                    TxtCode.Text = ""
                    TxtCode.Focus()
                End If
                Cursor = Cursors.WaitCursor
            End If
        End If
    End Sub
End Class