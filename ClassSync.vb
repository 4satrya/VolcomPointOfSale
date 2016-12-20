Imports MySql.Data.MySqlClient

Public Class ClassSync
    Dim curr_time As String = getTimeDBServer()
    Dim last_upd As String = ""
    Public sync_list As New List(Of String)


    Public Sub syncCodeDet()
        Dim err As String = ""

        '-----CLASS
        Try
            'update
            Dim qupd_cls As String = "UPDATE tb_class cls 
            INNER JOIN(
                SELECT a.id_code_detail, a.code_detail_name, a.display_name FROM db_sync.tb_m_code_detail a WHERE a.id_code=30
            ) src ON src.id_code_detail = cls.id_code_detail 
            SET cls.class = src.code_detail_name, 
            cls.class_display = src.display_name "
            execute_non_query(qupd_cls, True, "", "", "", "")
        Catch ex As Exception
            err = ex.ToString + "; "
        End Try

        Try
            'insert
            Dim qins_cls As String = "INSERT INTO tb_class(class, class_display, id_code_detail)
            SELECT cd.code_detail_name, cd.display_name, cd.id_code_detail
            FROM tb_class cls
            RIGHT JOIN (
	            SELECT a.id_code_detail, a.code_detail_name, a.display_name FROM db_sync.tb_m_code_detail a WHERE a.id_code=30
            ) cd ON cd.id_code_detail = cls.id_code_detail
            WHERE ISNULL(cls.id_class) "
            execute_non_query(qins_cls, True, "", "", "", "")
        Catch ex As Exception
            err += ex.ToString + "; "
        End Try

        '-----SIZE
        Try
            'update
            Dim qupd_sz As String = "UPDATE tb_size sz 
            INNER JOIN(
                SELECT a.id_code_detail, a.code_detail_name, a.display_name FROM db_sync.tb_m_code_detail a WHERE a.id_code=33
            ) src ON src.id_code_detail = sz.id_code_detail 
            SET sz.size = src.code_detail_name "
            execute_non_query(qupd_sz, True, "", "", "", "")
        Catch ex As Exception
            err += ex.ToString + "; "
        End Try

        Try
            'insert
            Dim qins_sz As String = "INSERT INTO tb_size(size, id_code_detail)
            SELECT cd.code_detail_name, cd.id_code_detail
            FROM tb_size sz
            RIGHT JOIN (
	            SELECT a.id_code_detail, a.code_detail_name, a.display_name FROM db_sync.tb_m_code_detail a WHERE a.id_code=33
            ) cd ON cd.id_code_detail = sz.id_code_detail
            WHERE ISNULL(sz.id_size) "
            execute_non_query(qins_sz, True, "", "", "", "")
        Catch ex As Exception
            err += ex.ToString + "; "
        End Try

        '--COLOR
        Try
            'update
            Dim qupd_col As String = "UPDATE tb_color col 
            INNER JOIN(
                SELECT a.id_code_detail, a.code_detail_name, a.display_name FROM db_sync.tb_m_code_detail a WHERE a.id_code=14
            ) src ON src.id_code_detail = col.id_code_detail 
            SET col.color = src.code_detail_name,
            col.color_display = src.display_name "
            execute_non_query(qupd_col, True, "", "", "", "")
        Catch ex As Exception
            err += ex.ToString + "; "
        End Try

        Try
            'insert
            Dim qins_col As String = "INSERT INTO tb_color(color, color_display, id_code_detail)
            SELECT cd.code_detail_name, cd.display_name, cd.id_code_detail
            FROM tb_color col
            RIGHT JOIN (
	            SELECT a.id_code_detail, a.code_detail_name, a.display_name FROM db_sync.tb_m_code_detail a WHERE a.id_code=14
            ) cd ON cd.id_code_detail = col.id_code_detail
            WHERE ISNULL(col.id_color) "
            execute_non_query(qins_col, True, "", "", "", "")
        Catch ex As Exception
            err += ex.ToString + "; "
        End Try

        Dim is_success = ""
        If err = "" Then
            is_success = "1"
        Else
            is_success = "2"
        End If
        Dim qlast As String = "INSERT INTO tb_sync_log(sync_time, id_sync_data, is_success, remark) VALUES('" + curr_time + "', '1', '" + is_success + "','" + addSlashes(err) + "') "
        execute_non_query(qlast, True, "", "", "", "")
    End Sub


    Public Sub startofSync()
        For i As Integer = 0 To sync_list.Count - 1
            If sync_list(i) = "1" Then 'code det
                syncCodeDet()
            End If
        Next
    End Sub


    Public Sub synchronize()
        BackupCustomTable()
        RestoreCustomTable()
        startofSync()
    End Sub

    Public Sub BackupCustomTable()
        last_upd = ""
        Dim constring As String = "server=localhost;user=root;pwd=bangcat48;database=db_volcom_mrp;"
        Dim path_root As String = Application.StartupPath
        Dim fileName As String = "bup" + ".sql"
        Dim file As String = IO.Path.Combine(path_root, fileName)

        'dictionary
        Dim dic As New Dictionary(Of String, String)()
        For i As Integer = 0 To sync_list.Count - 1
            If sync_list(i) = "1" Then 'code det
                Dim ql As String = "SELECT a.sync_time FROM tb_sync_log a WHERE a.id_sync_data=1 AND a.is_success=1 ORDER BY a.sync_time DESC LIMIT 1"
                Dim dql As DataTable = execute_query(ql, -1, True, "", "", "", "")
                If dql.Rows.Count > 0 Then
                    last_upd = DateTime.Parse(dql.Rows(0)("sync_time").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                Else
                    last_upd = "1945-08-17 00:00:10"
                End If
                dic.Add("tb_m_code_detail", "SELECT cd.* FROM tb_m_code_detail cd JOIN tb_opt o WHERE (cd.id_code= 14 OR cd.id_code=30 OR id_code=33) AND cd.last_updated>'" + last_upd + "';")
            End If
        Next

        Using conn As New MySqlConnection(constring)
            Using cmd As New MySqlCommand()
                Using mb As New MySqlBackup(cmd)
                    cmd.Connection = conn
                    conn.Open()
                    mb.ExportInfo.AddCreateDatabase = False
                    mb.ExportInfo.ExportTableStructure = True
                    mb.ExportInfo.ExportRows = True
                    mb.ExportInfo.TablesToBeExportedDic = dic
                    mb.ExportInfo.ExportProcedures = False
                    mb.ExportInfo.ExportFunctions = False
                    mb.ExportInfo.ExportTriggers = False
                    mb.ExportInfo.ExportEvents = False
                    mb.ExportInfo.ExportViews = False
                    mb.ExportInfo.EnableEncryption = True
                    mb.ExportInfo.EncryptionPassword = "csmtafc"
                    mb.ExportToFile(file)
                End Using
            End Using
        End Using
    End Sub


    Public Sub RestoreCustomTable()
        Dim constring As String = "server=localhost;user=root;pwd=bangcat48;database=db_sync;"
        Dim path_root As String = Application.StartupPath
        Dim fileName As String = "bup" + ".sql"
        Dim file As String = IO.Path.Combine(path_root, fileName)
        Using conn As New MySqlConnection(constring)
            Using cmd As New MySqlCommand()
                Using mb As New MySqlBackup(cmd)
                    cmd.Connection = conn
                    conn.Open()
                    mb.ImportInfo.TargetDatabase = "db_sync"
                    mb.ImportInfo.EnableEncryption = True
                    mb.ImportInfo.EncryptionPassword = "csmtafc"
                    mb.ImportFromFile(file)
                    conn.Close()
                End Using
            End Using
        End Using
    End Sub

End Class