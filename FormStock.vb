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
        End If
    End Sub

    Private Sub FormStock_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class