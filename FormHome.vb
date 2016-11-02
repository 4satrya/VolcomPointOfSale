Public Class FormHome
    Private Sub FormHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        apply_skin()
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub NavButton6_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs)
        Dispose()
    End Sub

    Private Sub TileItem10_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem10.ItemClick
        Dispose()
    End Sub
End Class