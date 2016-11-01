Public Class FormHome
    Private Sub FormHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        apply_skin()
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub NavButton6_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles NavButton6.ElementClick
        Dispose()
    End Sub
End Class