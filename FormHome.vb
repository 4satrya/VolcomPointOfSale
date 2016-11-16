Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Xml

Public Class FormHome
    Public connection_problem As Boolean = False
    Dim id_super_user As String = "0"

    Private Sub FormHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        apply_skin()
        SplashScreenManager1.ShowWaitForm()
        Try
            read_database_configuration()
            check_connection(True, "", "", "", "")

            'sync product
            Dim sc As New ClassItem
            sc.syncItem()

            SplashScreenManager1.CloseWaitForm()
            WindowState = FormWindowState.Maximized
            Opacity = 100
        Catch ex As Exception
            SplashScreenManager1.CloseWaitForm()
            connection_problem = True
            FormDatabase.id_type = "2"
            FormDatabase.TopMost = True
            FormDatabase.Show()
            FormDatabase.Focus()
            FormDatabase.TopMost = False
        End Try

        setLabelUser()

        My.Application.ChangeCulture("en-US")
        My.Application.Culture.NumberFormat.NumberDecimalSeparator = ","
        My.Application.Culture.NumberFormat.NumberGroupSeparator = "."
    End Sub

    Sub setDBInfo()
        'db conn info
        Dim el As DevExpress.XtraEditors.TileItemElement = TIDB.Elements(1)
        el.Text = app_host
        el = TIDB.Elements(2)
        el.Text = app_database
    End Sub

    Private Sub NavButton6_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs)
        Dispose()
    End Sub

    Private Sub TileItem10_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TIExit.ItemClick
        End
    End Sub

    Sub read_database_configuration()
        Dim path As String = My.Application.Info.DirectoryPath.ToString & "\DatabaseConfiguration.xml"
        Dim sharedkey As New TripleDESCryptoServiceProvider()
        Dim md5 As New MD5CryptoServiceProvider()
        sharedkey.Key = md5.ComputeHash(System.Text.Encoding.Unicode.GetBytes("csmtafc"))

        Dim encryptedDoc As New XmlDocument()
        encryptedDoc.Load(path)

        Dim EncryptedElement As XmlElement = CType(encryptedDoc.GetElementsByTagName("EncryptedData")(0), XmlElement)

        Dim ed As New EncryptedData()
        ed.LoadXml(EncryptedElement)

        Dim encryptXML As New EncryptedXml()
        Dim decryptedXML As Byte() = encryptXML.DecryptData(ed, sharedkey)

        encryptXML.ReplaceData(EncryptedElement, decryptedXML)

        Dim xmlnode As XmlNodeList
        xmlnode = encryptedDoc.GetElementsByTagName("database_config")
        app_host = xmlnode(0).ChildNodes.Item(0).InnerText.Trim()
        app_username = xmlnode(0).ChildNodes.Item(1).InnerText
        app_password = xmlnode(0).ChildNodes.Item(2).InnerText
        app_database = xmlnode(0).ChildNodes.Item(3).InnerText.Trim()
    End Sub

    Private Sub TileItem2_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TIUser.ItemClick
        Cursor = Cursors.WaitCursor
        FormLogin.menu_acc = "1"
        FormLogin.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub setLabelUser()
        Dim u As New ClassUser()
        LabelEmployeeLogin.Text = u.getHostName()
        LabelRoleLogin.Text = u.getIP()
    End Sub

    Private Sub TILogout_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TILogout.ItemClick
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to logout this system?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = DialogResult.Yes Then
            Dim lg As New ClassUser()
            lg.logout()
        End If
    End Sub

    Private Sub FormHome_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then 'close
            Close()
        End If
    End Sub

    Private Sub TIProduct_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TIProduct.ItemClick
        Cursor = Cursors.WaitCursor
        FormLogin.menu_acc = "2"
        FormLogin.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TINotif_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TICompany.ItemClick
        Cursor = Cursors.WaitCursor
        FormMasterCompany.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TIRec_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TIRec.ItemClick
        Cursor = Cursors.WaitCursor
        FormRec.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TIStock_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TIStock.ItemClick
        Cursor = Cursors.WaitCursor
        FormStock.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TIRet_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TIRet.ItemClick
        Cursor = Cursors.WaitCursor
        FormRet.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class