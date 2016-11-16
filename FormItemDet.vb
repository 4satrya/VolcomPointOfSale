Public Class FormItemDet
    Public action As String = ""
    Public id As String = "-1"
    Private Sub FormItemDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSize()
        actionLoad()
        SLESize.ShowPopup()
    End Sub

    Sub viewSize()
        Dim query As String = "SELECT * FROM tb_size ORDER BY size ASC "
        viewSearchLookupQuery(SLESize, query, "id_size", "size", "id_size")
    End Sub

    Sub actionLoad()
        If action = "upd" Then
            Dim i As New ClassItem()
            Dim query As String = i.queryMain("AND i.id_item=" + id + "", "1", False)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtCode.Text = data.Rows(0)("item_code").ToString
            TxtDesc.Text = data.Rows(0)("item_name").ToString
            TxtPrice.EditValue = data.Rows(0)("price")
            SLESize.EditValue = data.Rows(0)("id_size").ToString
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
        Dim id_size As String = SLESize.EditValue.ToString

        'cek duplikat
        Dim check As Boolean = False
        Dim query_cek As String = "SELECT COUNT(*) FROM tb_item WHERE item_code='" + item_code + "' "
        If action = "upd" Then
            query_cek += "AND id_item<>'" + id + "'"
        End If
        Dim jum_cek As String = execute_query(query_cek, 0, True, "", "", "", "")
        If jum_cek > "0" Then
            check = False
        Else
            check = True
        End If

        If item_code = "" Or item_name = "" Or price = "" Then
            stopCustom("Data can't blank")
        ElseIf Not check
            stopCustom("Product code is already exist")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                If action = "ins" Then
                    Dim query As String = "INSERT INTO tb_item(item_code, item_name, id_size, price) 
                                    VALUES('" + item_code + "', '" + item_name + "', '" + id_size + "','" + price + "'); SELECT LAST_INSERT_ID(); "
                    id = execute_query(query, 0, True, "", "", "", "")
                Else
                    Dim query As String = "UPDATE tb_item SET item_code='" + item_code + "', 
                item_name='" + item_name + "', id_size='" + id_size + "', price='" + price + "' WHERE id_item='" + id + "' "
                    execute_non_query(query, True, "", "", "", "")
                End If
                FormItem.viewItem()
                FormItem.GVItem.FocusedRowHandle = find_row(FormItem.GVItem, "id_item", id)
                Close()
            End If
        End If
    End Sub
    Private Sub SLESize_Focus(sender As Object, e As EventArgs) Handles SLESize.GotFocus
        SLESize.ShowPopup()
    End Sub

    Private Sub SLESize_KeyDown(sender As Object, e As KeyEventArgs) Handles SLESize.KeyDown

    End Sub
End Class