﻿Public Class FormStock
    Dim soh_storage As String = ""
    Dim soh_supp As String = ""
    Dim soh_prod As String = ""
    Dim soh_date As String = ""

    Dim card_storage As String = ""
    Dim card_prod As String = ""
    Dim card_from As String = ""
    Dim card_until As String = ""

    Private Sub FormStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewComp()
        viewItem()
        viewCompCard()
        viewItemCard()
        DERefDate.EditValue = getTimeDB()
        DEFromCard.EditValue = getTimeDB()
        DEUntilCard.EditValue = getTimeDB()
    End Sub

    Sub viewComp()
        Dim comp As New ClassComp()
        Dim query_comp As String = comp.queryMain("AND comp.id_comp_cat=5 OR comp.id_comp_cat=6", "1", True)
        viewSearchLookupQuery(SLEStorage, query_comp, "id_comp", "comp", "id_comp")

        'supplier
        Dim query_supp As String = comp.queryMain("AND comp.id_comp_cat=1", "1", True)
        viewSearchLookupQuery(SLESupplier, query_supp, "id_comp", "comp", "id_comp")
    End Sub

    Sub viewCompCard()
        Dim comp As New ClassComp()
        Dim query_comp As String = comp.queryMain("AND comp.id_comp_cat=5 OR comp.id_comp_cat=6", "1", False)
        viewSearchLookupQuery(SLEStorageCard, query_comp, "id_comp", "comp", "id_comp")
    End Sub

    Sub viewItem()
        Dim i As New ClassItem()
        Dim query As String = i.queryMain("-1", "1", True)
        viewSearchLookupQuery(SLEItem, query, "id_item", "item", "id_item")
    End Sub

    Sub viewItemCard()
        Dim i As New ClassItem()
        Dim query As String = i.queryMain("-1", "1", False)
        viewSearchLookupQuery(SLEItemCard, query, "id_item", "item", "id_item")
    End Sub

    Sub showHideFilter()
        If XTCStock.SelectedTabPageIndex = 0 Then
            If PanelControlStock.Visible = True Then
                PanelControlStock.Visible = False
            Else
                PanelControlStock.Visible = True
            End If
        Else
            If PCCard.Visible = True Then
                PCCard.Visible = False
            Else
                PCCard.Visible = True
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
        Cursor = Cursors.WaitCursor
        If XTCStock.SelectedTabPageIndex = 0 Then
            FormBlack.Show()
            ReportStock.dt = GCStock.DataSource
            Dim Report As New ReportStock()

            ' '... 
            ' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVStock.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GVStock.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'Grid Detail
            ReportStyleGridview(Report.GVStock)

            'Parse val
            Report.LabelStorage.Text = soh_storage
            Report.LabelSupplier.Text = soh_supp
            Report.LabelProd.Text = soh_prod
            Report.LabelDate.Text = soh_date

            ' Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
            FormBlack.Close()
        End If
        Cursor = Cursors.Default
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

        'label fill
        soh_storage = SLEStorage.Text
        soh_supp = SLESupplier.Text
        soh_prod = SLEItem.Text
        soh_date = DERefDate.Text
    End Sub

    Sub viewStockCard()
        'storage
        Dim id_comp As String = "-1"
        If SLEStorageCard.EditValue.ToString <> "0" Then
            id_comp = SLEStorageCard.EditValue.ToString
        End If

        'product
        Dim id_item As String = "-1"
        If SLEItemCard.EditValue.ToString <> "0" Then
            id_item = SLEItemCard.EditValue.ToString
        End If

        'date
        Dim dt_from As String = DateTime.Parse(DEFromCard.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim dt_until As String = DateTime.Parse(DEUntilCard.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim query As String = "CALL view_stock_card('" + id_item + "', '" + id_comp + "', '" + dt_from + "', '" + dt_until + "',1) "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCard.DataSource = data

        'label fill
        card_storage = SLEStorageCard.Text
        card_prod = SLEItemCard.Text
        card_from = DEFromCard.Text
        card_until = DEUntilCard.Text
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewStock()
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Cursor = Cursors.WaitCursor
        viewStockCard()
        Cursor = Cursors.Default
    End Sub
End Class