Public Class FormStock
    Private Sub FormStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewComp()
        viewItem()
        DERefDate.EditValue = getTimeDB()
    End Sub

    Sub viewComp()
        Dim comp As New ClassComp()
        Dim query_comp As String = comp.queryMain("AND comp.id_comp_cat=5 OR comp.id_comp_cat=6", "1", True)
        viewSearchLookupQuery(SLEStorage, query_comp, "id_comp", "comp", "id_comp")

        'supplier
        Dim query_supp As String = comp.queryMain("AND comp.id_comp_cat=1", "1", True)
        viewSearchLookupQuery(SLESupplier, query_supp, "id_comp", "comp", "id_comp")
    End Sub

    Sub viewItem()
        Dim i As New ClassItem()
        Dim query As String = i.queryMain("-1", "1", True)
        viewSearchLookupQuery(SLEItem, query, "id_item", "item", "id_item")
    End Sub

    Sub showHideFilter()
        If XTCStock.SelectedTabPageIndex = 0 Then
            If PanelControlStock.Visible = True Then
                PanelControlStock.Visible = False
            Else
                PanelControlStock.Visible = True
            End If
        End If
    End Sub

    Private Sub FormStock_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F4 Then
            showHideFilter()
        ElseIf e.KeyCode = Keys.Escape Then
            Close()
        ElseIf e.KeyCode = Keys.F10 Then
            printPreview()
        End If
    End Sub

    Sub printPreview()
        If XTCStock.SelectedTabPageIndex = 0 Then
            FormBlack.Show()
            print(GCStock, "STOCK ON HAND")
            FormBlack.Close()
        End If
    End Sub

    Private Sub FormStock_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewStock()
        Dim cond As String = ""

        'storage
        If SLEStorage.EditValue.ToString <> "0" Then
            cond += "AND j.id_comp=" + SLEStorage.EditValue.ToString + " "
        End If

        'supplier
        If SLESupplier.EditValue.ToString <> "0" Then
            cond += "AND f.id_comp_sup=" + SLESupplier.EditValue.ToString + " "
        End If

        'product
        If SLEItem.EditValue.ToString <> "0" Then
            cond += "AND f.id_item=" + SLEItem.EditValue.ToString + " "
        End If

        Dim dt As String = DateTime.Parse(DERefDate.EditValue.ToString).ToString("yyyy-MM-dd")
        cond += "AND DATE(j.storage_item_datetime) <= DATE(''" + dt + "'') "

        Dim query As String = "CALL view_stock_item('" + cond + "', '2') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCStock.DataSource = data
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewStock()
        Cursor = Cursors.Default
    End Sub
End Class