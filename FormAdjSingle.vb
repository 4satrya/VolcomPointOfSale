Public Class FormAdjSingle
    Public id_pop_up As String = "-1"
    Public id_comp As String = "-1"
    Dim id_item As String = ""
    Dim item_code As String = ""
    Dim item_name As String = ""
    Dim size As String = ""
    Dim price As Decimal = 0

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
                    id_item = data.Rows(0)("id_item").ToString
                    item_code = data.Rows(0)("item_code").ToString
                    item_name = data.Rows(0)("item_name").ToString
                    size = data.Rows(0)("size").ToString
                    price = data.Rows(0)("price")
                    TxtDesc.Text = data.Rows(0)("item_name").ToString
                    TxtSOH.EditValue = data.Rows(0)("qty_tot")
                    TxtQty.Enabled = True
                    TxtQty.Focus()
                Else
                    stopCustom("Code not found")
                    TxtCode.Text = ""
                    TxtCode.Focus()
                End If
                Cursor = Cursors.WaitCursor
            End If
        End If
    End Sub

    Private Sub TxtQty_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtQty.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim qty As Decimal = TxtQty.EditValue
            If qty > 0 Then
                Dim gc As DevExpress.XtraGrid.GridControl = FormAdjOut.GCScanSum
                Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = FormAdjOut.GVScanSum
                Dim newRow As DataRow = (TryCast(gc.DataSource, DataTable)).NewRow()
                newRow("id_adj_out_det") = "0"
                newRow("id_item") = id_item
                newRow("item_code") = item_code
                newRow("item_name") = item_name
                newRow("size") = size
                newRow("adj_out_qty") = TxtQty.EditValue
                newRow("origin_qty") = TxtSOH.EditValue
                newRow("price") = price
                TryCast(gc.DataSource, DataTable).Rows.Add(newRow)
                gc.RefreshDataSource()
                gv.RefreshData()
                Close()
            End If
        End If
    End Sub
End Class