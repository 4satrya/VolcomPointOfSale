Public Class FormPOSItem
    Private Sub FormPOSItem_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPOSItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As New ClassItem()
        Dim query As String = i.queryMain("AND i.is_active=1 ", "1", False)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItem.DataSource = data
    End Sub

    Private Sub FormPOSItem_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            FormPOS.TxtItemCode.Text = GVItem.GetFocusedRowCellValue("item_code").ToString
            Close()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
End Class