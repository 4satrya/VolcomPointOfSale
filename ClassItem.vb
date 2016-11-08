﻿Public Class ClassItem
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

        Dim query As String = "SELECT i.id_item, i.item_code, i.item_name, i.id_size, s.size, i.price, i.id_product  
        FROM tb_item i 
        INNER JOIN tb_size s ON s.id_size = i.id_size
        WHERE i.id_item>0 "
        query += condition + " "
        query += "ORDER BY i.id_item " + order_type
        Return query
    End Function

    Sub syncItem()
        Dim query As String = "CALL get_product()"
        execute_non_query(query, True, "", "", "", "")
    End Sub
End Class
