Public Class FormPOSDrawerInfo
    Public id_shift As String = "-1"

    Private Sub FormPOSDrawerInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'opt
        Dim query_opt As String = "SELECT * FROM tb_opt"
        Dim dt_opt As DataTable = execute_query(query_opt, -1, True, "", "", "", "")
        LabelHeader1.Text = dt_opt.Rows(0)("header_1").ToString
        LabelHeader2.Text = dt_opt.Rows(0)("header_2").ToString

        'shift
        Dim pos As New ClassPOS()
        Dim query_shf As String = pos.queryShift("AND s.id_shift=" + id_shift + "", "1")
        Dim dt_shf As DataTable = execute_query(query_shf, -1, True, "", "", "", "")
        LabelDateShift.Text = DateTime.Parse(dt_shf.Rows(0)("open_shift").ToString).ToString("dd/MM/yyyy")
        LabelCashier.Text = dt_shf.Rows(0)("username").ToString
        LabelShift.Text = dt_shf.Rows(0)("shift_type").ToString
        LabelPOS.Text = "POS#" + dt_shf.Rows(0)("pos_dev").ToString
    End Sub

End Class