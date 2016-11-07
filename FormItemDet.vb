Public Class FormItemDet
    Public action As String = ""
    Public id As String = "-1"
    Private Sub FormItemDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "upd" Then
            Dim i As New ClassItem()
            Dim query As String = i.queryMain("AND i.id_item=" + id + "", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtCode.Text = data.Rows(0)("item_code").ToString
            TxtDesc.Text = data.Rows(0)("item_name").ToString
            TxtPrice.EditValue = data.Rows(0)("price")
        Else
            TxtPrice.EditValue = 0
        End If
    End Sub

    Private Sub FormItemDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormItemDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Escape Then 'close
            Close()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim item_code As String = addSlashes(TxtCode.Text)
        Dim item_name As String = addSlashes(TxtDesc.Text)
        Dim price As String = decimalSQL(TxtPrice.EditValue.ToString)
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = DialogResult.Yes Then
            If action = "ins" Then
                Dim query As String = "INSERT INTO tb_item(item_code, item_name, price) 
                                    VALUES('" + item_code + "', '" + item_name + "', '" + price + "'); SELECT LAST_INSERT_ID(); "
                id = execute_query(query, 0, True, "", "", "", "")
            Else

            End If
            FormItem.viewItem()
            FormItem.GVItem.FocusedRowHandle = find_row(FormItem.GVItem, "id_item", id)
            Close()
        End If
    End Sub
End Class