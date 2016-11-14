Public Class FormStock
    Private Sub FormStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT i.id_item, i.item_code, i.item_name, s.size, SUM(st.storage_item_qty) AS `qty` 
        FROM tb_storage_item st
        INNER JOIN tb_item i ON i.id_item = st.id_item 
        INNER JOIN tb_size s ON s.id_size = i.id_size 
        GROUP BY i.id_item
        ORDER BY i.item_name ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        PGCStock.DataSource = data
    End Sub
End Class