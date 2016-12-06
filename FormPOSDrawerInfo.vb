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

        'info sales
        Dim sal As New ClassPOS()
        Dim query_sal As String = sal.querySal("AND  p.id_shift=" + id_shift + " AND p.id_pos_status=2", "p.id_pos ASC", "p.id_shift")
        'Dim query_sal As String = "SELECT SUM(p.subtotal) AS `subtotal`, SUM(p.discount) AS `discount`,
        '(SUM(p.subtotal)-SUM(p.discount)) AS `after_discount`,
        'SUM(p.tax) AS `tax`, SUM(p.total) AS `total`,
        'SUM(p.card) AS `card`, SUM(p.voucher) AS `voucher`,
        'SUM(p.total)-(SUM(p.card)+SUM(p.voucher)) AS `cash_in_drawer`
        'FROM tb_pos p
        'WHERE p.id_shift=" + id_shift + " AND p.id_pos_status='2'
        'GROUP BY p.id_shift "
        Dim dt_sal As DataTable = execute_query(query_sal, -1, True, "", "", "", "")
        LabelBefore.Text = Decimal.Parse(dt_sal.Rows(0)("subtotal").ToString()).ToString("N2")
        LabelDiscount.Text = Decimal.Parse(dt_sal.Rows(0)("discount").ToString()).ToString("N2")
        LabelAfter.Text = Decimal.Parse(dt_sal.Rows(0)("after_discount").ToString()).ToString("N2")
        LabelTax.Text = Decimal.Parse(dt_sal.Rows(0)("tax").ToString()).ToString("N2")
        LabelNetto.Text = Decimal.Parse(dt_sal.Rows(0)("total").ToString()).ToString("N2")
        LabelCard.Text = Decimal.Parse(dt_sal.Rows(0)("card").ToString()).ToString("N2")
        LabelVoucher.Text = Decimal.Parse(dt_sal.Rows(0)("voucher").ToString()).ToString("N2")
        LabelCashDrawer.Text = Decimal.Parse(dt_sal.Rows(0)("cash_in_drawer").ToString()).ToString("N2")
    End Sub

End Class