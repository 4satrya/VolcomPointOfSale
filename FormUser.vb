Imports System.Runtime.InteropServices
Public Class FormUser
    Public Const WM_NCLBUTTONDOWN As Integer = &HA1
    Public Const HT_CAPTION As Integer = &H2
    <DllImportAttribute("user32.dll")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr,
      ByVal Msg As Integer, ByVal wParam As Integer,
      ByVal lParam As Integer) As Integer
    End Function

    <DllImportAttribute("user32.dll")>
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    Private Sub FormUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GVRole.Focus()
        viewRole()
        viewUser()

        'opt
        Dim qopt As String = "SELECT * FROM tb_opt"
        Dim dopt As DataTable = execute_query(qopt, -1, True, "", "", "", "")
        TxtCompName.Text = dopt.Rows(0)("company_name").ToString
        TxtTagline.Text = dopt.Rows(0)("company_tagline").ToString
        TxtOutletName.Text = dopt.Rows(0)("outlet_name").ToString
        TxtOutletId.Text = dopt.Rows(0)("id_outlet").ToString
        TxtSupervisor.Text = dopt.Rows(0)("spv").ToString
    End Sub

    Sub viewRole()
        Dim role As New ClassUser()
        Dim query As String = role.queryRole("-1", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRole.DataSource = data
    End Sub

    Sub viewUser()
        Dim user As New ClassUser()
        Dim query As String = user.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCUser.DataSource = data
    End Sub

    Private Sub FormUser_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dim acc As New ClassUser()
        acc.logout()
        Dispose()
    End Sub

    Sub editRole()
        Cursor = Cursors.WaitCursor
        FormUserRole.id = GVRole.GetFocusedRowCellValue("id_role").ToString
        FormUserRole.action = "upd"
        FormUserRole.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub editUser()
        Cursor = Cursors.WaitCursor
        FormUserDet.id = GVUser.GetFocusedRowCellValue("id_user").ToString
        FormUserDet.action = "upd"
        FormUserDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormUser_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Escape Then 'close
            Close()
        ElseIf e.KeyCode = Keys.Insert Then 'new
            If XTCUser.SelectedTabPageIndex = 0 Then 'role
                FormUserRole.action = "ins"
                FormUserRole.ShowDialog()
            Else
                FormUserDet.action = "ins"
                FormUserDet.ShowDialog()
            End If
        ElseIf e.KeyCode = Keys.Enter Then 'edit
            If XTCUser.SelectedTabPageIndex = 0 Then 'role
                editRole()
            Else 'user
                editUser()
            End If
        ElseIf e.KeyCode = Keys.Delete Then 'delete
            If XTCUser.SelectedTabPageIndex = 0 Then 'role
                If GVRole.FocusedRowHandle >= 0 Then
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = DialogResult.Yes Then
                        Try
                            Dim id As String = GVRole.GetFocusedRowCellValue("id_role").ToString
                            Dim query As String = "DELETE FROM tb_role WHERE id_role=" + id + " "
                            execute_non_query(query, True, "", "", "", "")
                            viewRole()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                End If
            Else 'user
                If GVUser.FocusedRowHandle >= 0 Then
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = DialogResult.Yes Then
                        Try
                            Dim id As String = GVUser.GetFocusedRowCellValue("id_user").ToString
                            Dim query As String = "DELETE FROM tb_user WHERE id_user=" + id + " "
                            execute_non_query(query, True, "", "", "", "")
                            viewUser()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                End If
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCUser_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCUser.SelectedPageChanged
        If XTCUser.SelectedTabPageIndex = 0 Then
            GVRole.Focus()
        ElseIf XTCUser.SelectedTabPageIndex = 1 Then
            GVUser.Focus()
        End If
    End Sub

    Private Sub GVRole_DoubleClick(sender As Object, e As EventArgs) Handles GVRole.DoubleClick
        If GVRole.FocusedRowHandle >= 0 And GVRole.RowCount > 0 Then
            editRole()
        End If
    End Sub

    Private Sub GVUser_DoubleClick(sender As Object, e As EventArgs) Handles GVUser.DoubleClick
        editUser()
    End Sub

    Private Sub PanelControlBack_MouseHover(sender As Object, e As EventArgs) Handles PanelControlBack.MouseHover
        PanelControlBack.Cursor = Cursors.Hand
    End Sub

    Private Sub PanelControlBack_MouseLeave(sender As Object, e As EventArgs) Handles PanelControlBack.MouseLeave
        PanelControlBack.Cursor = Cursors.Default
    End Sub

    Private Sub PanelControlBack_Click(sender As Object, e As EventArgs) Handles PanelControlBack.Click
        Close()
    End Sub

    Private Sub FormUser_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN,
               HT_CAPTION, 0)
        End If
    End Sub
End Class