Public Class ClassItem
    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        If order_type = "1" Then
            order_type = "ASC "
        ElseIf order_type = "2" Then
            order_type = "DESC "
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "SELECT i.id_item, i.item_code, i.item_name, i.price, i.id_product  
        FROM tb_item i 
        WHERE i.id_item>0 "
        query += condition + " "
        query += "ORDER BY i.id_item " + order_type
        Return query
    End Function
End Class
