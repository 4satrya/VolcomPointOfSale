Public Class FormFront
    Private Sub TIExitProg_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) 
        Cursor = Cursors.WaitCursor
        End
        Cursor = Cursors.Default
    End Sub

    Private Sub FormFront_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub TIInv_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TIInv.ItemClick
        Cursor = Cursors.WaitCursor
        Opacity = 0
        FormHome.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class