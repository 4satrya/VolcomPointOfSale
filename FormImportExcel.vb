﻿Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class FormImportExcel
    Private dataset_field As DataSet
    Public id_pop_up As String = "-1"
    ' List of id popup
    ' 1 = Sample Purchase
    ' 2 = Sample Planning
    Private Sub TBFileAddress_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBFileAddress.EditValueChanged
        If Not TBFileAddress.Text = "" Then
            fill_combo_worksheet()
        End If
    End Sub

    Private Sub CBWorksheetName_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBWorksheetName.EditValueChanged
        If Not CBWorksheetName.EditValue = "" Then
            Cursor = Cursors.WaitCursor
            fill_field_grid()
            Cursor = Cursors.Default
        End If
    End Sub
    Sub fill_combo_worksheet()
        Dim oledbconn As New OleDbConnection
        Dim strConn As String = ""
        Dim ExcelTables As DataTable
        'Try
        Dim extension As String = IO.Path.GetExtension(TBFileAddress.Text)
        If extension.ToLower = ".xlsx" Then
            strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & TBFileAddress.Text.ToLower & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;"""
        ElseIf extension.ToLower = ".xls" Then
            strConn = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;""", TBFileAddress.Text.ToLower)
            'strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & TBFileAddress.Text.ToLower & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;"""
        Else
            stopCustom("Make sure your file in .xls or .xlsx format.")
            Exit Sub
        End If

        oledbconn.ConnectionString = strConn
        oledbconn.Open()
        ExcelTables = oledbconn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
        oledbconn.Close()
        oledbconn.Dispose()
        Dim dr As DataRow
        Dim i As Integer = 0
        CBWorksheetName.Properties.Items.Clear()
        CBWorksheetName.EditValue = ""
        For Each dr In ExcelTables.Rows
            If dr.Item(3).ToString = "TABLE" Then
                If InStr(dr.Item(2), "$") > 0 Then
                    i += 1
                    CBWorksheetName.Properties.Items.Add(dr.Item(2).ToString)
                    If i = 1 Then
                        CBWorksheetName.SelectedItem = dr.Item(2).ToString
                    End If
                End If
            End If
        Next
        ExcelTables.Dispose()
        'Catch ex As Exception
        '    stopCustom("Please make sure your file not open and available to read.")
        'End Try
    End Sub
    Sub fill_field_grid()
        Dim oledbconn As New OleDbConnection
        Dim strConn As String
        Dim data_temp As New DataTable

        GCData.DataSource = Nothing

        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & TBFileAddress.Text.ToLower & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;"""
        oledbconn.ConnectionString = strConn
        Dim MyCommand As OleDbDataAdapter

        If id_pop_up = "" Then
            MyCommand = New OleDbDataAdapter("select code, SUM(qty) AS qty from [" & CBWorksheetName.SelectedItem.ToString & "] GROUP BY code", oledbconn)
        Else
            MyCommand = New OleDbDataAdapter("select * from [" & CBWorksheetName.SelectedItem.ToString & "]", oledbconn)
        End If

        'Try
        MyCommand.Fill(data_temp)
            MyCommand.Dispose()
            'Catch ex As Exception
            '    stopCustom("Input must be in accordance with the format specified !")
            '    Exit Sub
            'End Try

            If id_pop_up = "1" Then
            'MASTER PRODUCT
            Try
                Dim dt As DataTable = execute_query("SELECT * FROM tb_item", -1, True, "", "", "", "")
                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()
                Dim query = From table1 In tb1
                            Group Join table_tmp In tb2 On table1("code").ToString Equals table_tmp("item_code").ToString
                            Into Group
                            From y1 In Group.DefaultIfEmpty()
                            Select New With
                            {
                                .Code = table1.Field(Of String)("code").ToString,
                                .Description = table1.Field(Of String)("description").ToString,
                                .Price = table1("price"),
                                .Status = If(y1 Is Nothing, "OK", "Product code is already exist")
                            }
                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        End If


        data_temp.Dispose()
        oledbconn.Close()
        oledbconn.Dispose()
    End Sub
    Private Sub BBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBrowse.Click
        Me.Cursor = Cursors.WaitCursor
        Dim fdlg As OpenFileDialog = New OpenFileDialog()
        fdlg.Title = "Select excel file To import"
        fdlg.InitialDirectory = "C: \"
        fdlg.Filter = "Excel File|*.xls; *.xlsx"
        fdlg.FilterIndex = 0
        fdlg.RestoreDirectory = True
        Cursor = Cursors.Default
        If fdlg.ShowDialog() = DialogResult.OK Then
            TBFileAddress.Text = ""
            TBFileAddress.Text = fdlg.FileName
        End If
        fdlg.Dispose()
    End Sub

    Private Sub GVData_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVData.RowCellStyle
        If id_pop_up = "1" Then
            Dim stt As String = sender.GetRowCellValue(e.RowHandle, sender.Columns("Status")).ToString
            If stt <> "OK" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.Salmon
            End If
        ElseIf id_pop_up = "2" Then

        End If
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormImportExcel_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImport.Click
        Cursor = Cursors.WaitCursor
        Try

        Catch ex As Exception
            stopCustom("Import failed. Please make sure : " & vbNewLine & "- Row data not empty" & vbNewLine & "- Value in correct format")
        End Try
        If Not GVData.RowCount > 0 Then
            infoCustom("No data imported.")
            Close()
        Else
            If id_pop_up = "1" Then
                'MASTER PRODUCT
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        Cursor = Cursors.WaitCursor

                        'ins
                        Dim l_i As Integer = 0
                        Dim query_ins As String = "INSERT INTO tb_item(item_code, item_name, price) VALUES "
                        For l As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim item_code As String = GVData.GetRowCellValue(l, "Code").ToString
                            Dim item_name As String = addSlashes(GVData.GetRowCellValue(l, "Description").ToString)
                            Dim price As String = decimalSQL(GVData.GetRowCellValue(l, "Price").ToString)

                            If l_i > 0 Then
                                query_ins += ", "
                            End If
                            query_ins += "('" + item_code + "', '" + item_name + "', '" + price + "') "
                            l_i += 1
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        If l_i > 0 Then
                            execute_non_query(query_ins, True, "", "", "", "")
                        End If
                        FormItem.viewItem()
                        Close()
                        Cursor = Cursors.Default
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            End If
        End If
        Cursor = Cursors.Default
    End Sub



    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print(GCData, "List Import Excel")
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GVData.ValidatingEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim currentDataView As DataView = TryCast(TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).DataSource, DataView)
        If view.FocusedColumn.FieldName = "Code" Then
            'check duplicate code
            Dim currentCode As String = e.Value.ToString()
            For i As Integer = 0 To currentDataView.Count - 1
                If i <> view.GetDataSourceRowIndex(view.FocusedRowHandle) Then
                    If currentDataView(i)("Code").ToString() = currentCode Then
                        MsgBox("Duplicate Code detected.")
                        e.ErrorText = "Duplicate Code detected."
                        e.Valid = False
                        Exit For
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub FormImportExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        If id_pop_up = "6" Or id_pop_up = "18" Then
            TBFileAddress.Text = My.Application.Info.DirectoryPath.ToString & "\import\sales_pos.xlsx"
            fill_combo_worksheet()
        End If
    End Sub

    Private Sub FormImportExcel_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub
End Class