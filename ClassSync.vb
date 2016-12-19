Imports MySql.Data.MySqlClient

Public Class ClassSync
    Dim curr_time As String = getTimeDBStr()
    Dim last_upd As String = getLastUpd()


    Public Sub syncClass()
        'update
        Dim qupd As String = "UPDATE tb_class cls 
        INNER JOIN(
            SELECT a.id_code_detail, a.code_detail_name, a.display_name FROM db_sync.tb_m_code_detail a WHERE a.id_code=30
        ) src ON src.id_code_detail = cls.id_code_detail 
        SET cls.class = src.code_detail_name, 
        cls.class_display = src.display_name "
        execute_non_query(qupd, True, "", "", "", "")

        'insert
        Dim qins As String = "INSERT INTO tb_class(class, class_display, id_code_detail)
        SELECT cd.code_detail_name, cd.display_name, cd.id_code_detail
        FROM tb_class cls
        RIGHT JOIN (
	        SELECT a.id_code_detail, a.code_detail_name, a.display_name FROM db_sync.tb_m_code_detail a WHERE a.id_code=30
        ) cd ON cd.id_code_detail = cls.id_code_detail
        WHERE ISNULL(cls.id_class) "
        execute_non_query(qins, True, "", "", "", "")
    End Sub

    Public Sub syncSize()
        'update
        Dim qupd As String = "UPDATE tb_size sz 
        INNER JOIN(
            SELECT a.id_code_detail, a.code_detail_name, a.display_name FROM db_sync.tb_m_code_detail a WHERE a.id_code=33
        ) src ON src.id_code_detail = sz.id_code_detail 
        SET sz.size = src.code_detail_name "
        execute_non_query(qupd, True, "", "", "", "")

        'insert
        Dim qins As String = "INSERT INTO tb_size(size, id_code_detail)
        SELECT cd.code_detail_name, cd.id_code_detail
        FROM tb_size sz
        RIGHT JOIN (
	        SELECT a.id_code_detail, a.code_detail_name, a.display_name FROM db_sync.tb_m_code_detail a WHERE a.id_code=33
        ) cd ON cd.id_code_detail = sz.id_code_detail
        WHERE ISNULL(sz.id_size) "
        execute_non_query(qins, True, "", "", "", "")
    End Sub

    Public Sub syncColor()
        'update
        Dim qupd As String = "UPDATE tb_color col 
        INNER JOIN(
            SELECT a.id_code_detail, a.code_detail_name, a.display_name FROM db_sync.tb_m_code_detail a WHERE a.id_code=14
        ) src ON src.id_code_detail = col.id_code_detail 
        SET col.color = src.code_detail_name,
        col.color_display = src.display_name "
        execute_non_query(qupd, True, "", "", "", "")

        'insert
        Dim qins As String = "INSERT INTO tb_color(color, color_display, id_code_detail)
        SELECT cd.code_detail_name, cd.display_name, cd.id_code_detail
        FROM tb_color col
        RIGHT JOIN (
	        SELECT a.id_code_detail, a.code_detail_name, a.display_name FROM db_sync.tb_m_code_detail a WHERE a.id_code=14
        ) cd ON cd.id_code_detail = col.id_code_detail
        WHERE ISNULL(col.id_color) "
        execute_non_query(qins, True, "", "", "", "")
    End Sub

    Public Sub endOfSync()
        Dim qupd As String = "UPDATE tb_opt SET last_updated='" + curr_time + "'"
        execute_non_query(qupd, True, "", "", "", "")
    End Sub

    Public Sub syncAll()
        BackupCustomTable()
        RestoreCustomTable()
        syncClass()
        syncSize()
        syncColor()
        endOfSync()
    End Sub

    Public Sub BackupCustomTable()
        Dim constring As String = "server=localhost;user=root;pwd=bangcat48;database=db_volcom_mrp;"
        Dim path_root As String = Application.StartupPath
        Dim fileName As String = "bup" + ".sql"
        Dim file As String = IO.Path.Combine(path_root, fileName)

        'dictionary
        Dim dic As New Dictionary(Of String, String)()
        dic.Add("tb_m_code_detail", "SELECT cd.* FROM tb_m_code_detail cd JOIN tb_opt o WHERE (cd.id_code= o.id_code_fg_class OR cd.id_code=o.id_code_fg_color OR id_code=o.id_code_fg_size) AND cd.last_updated>'" + last_upd + "';")
        dic.Add("tb_opt", "SELECT id_code_fg_class,id_code_fg_size,id_code_fg_color FROM tb_opt;")

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
                    ' mb.ExportInfo.EnableEncryption = True
                    ' mb.ExportInfo.EncryptionPassword = "csmtafc"
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
                    ' mb.ImportInfo.EnableEncryption = True
                    'mb.ImportInfo.EncryptionPassword = "csmtafc"
                    mb.ImportFromFile(file)
                    conn.Close()
                End Using
            End Using
        End Using
    End Sub

End Class