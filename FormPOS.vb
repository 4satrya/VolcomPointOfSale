﻿Public Class FormPOS
    Private Sub FormPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LabelInfoLeft.Focus()
        viewCountry()
    End Sub

    Private Sub FormPOS_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            help()
        ElseIf e.KeyCode = Keys.Insert Then
            TxtItemCode.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            exitForm()
        End If
    End Sub

    Sub help()
        If GroupControlMenu.Visible = True Then
            GroupControlMenu.Visible = False
        Else
            GroupControlMenu.Visible = True
        End If
    End Sub

    Sub exitForm()
        Close()
    End Sub

    Private Sub FormPOS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewCountry()
        Dim query As String = "SELECT * FROM tb_m_country a ORDER BY a.country ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'viewLookupQuery(LENation, query, 0, "country", "id_country")
    End Sub
End Class