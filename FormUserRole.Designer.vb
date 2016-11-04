<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUserRole
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtRole = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControlTop = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControlBottom = New DevExpress.XtraEditors.PanelControl()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GCRole = New DevExpress.XtraGrid.GridControl()
        Me.GVRole = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdMenu = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.TxtRole.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlTop.SuspendLayout()
        CType(Me.PanelControlBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlBottom.SuspendLayout()
        CType(Me.GCRole, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRole, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Role"
        '
        'TxtRole
        '
        Me.TxtRole.Location = New System.Drawing.Point(46, 12)
        Me.TxtRole.Name = "TxtRole"
        Me.TxtRole.Size = New System.Drawing.Size(223, 20)
        Me.TxtRole.TabIndex = 1
        '
        'PanelControlTop
        '
        Me.PanelControlTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlTop.Controls.Add(Me.TxtRole)
        Me.PanelControlTop.Controls.Add(Me.Label1)
        Me.PanelControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlTop.Location = New System.Drawing.Point(5, 0)
        Me.PanelControlTop.Name = "PanelControlTop"
        Me.PanelControlTop.Size = New System.Drawing.Size(632, 43)
        Me.PanelControlTop.TabIndex = 2
        '
        'PanelControlBottom
        '
        Me.PanelControlBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlBottom.Controls.Add(Me.BtnSave)
        Me.PanelControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlBottom.Location = New System.Drawing.Point(5, 329)
        Me.PanelControlBottom.Name = "PanelControlBottom"
        Me.PanelControlBottom.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.PanelControlBottom.Size = New System.Drawing.Size(632, 34)
        Me.PanelControlBottom.TabIndex = 3
        '
        'BtnSave
        '
        Me.BtnSave.Appearance.BackColor = System.Drawing.SystemColors.Highlight
        Me.BtnSave.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnSave.Appearance.Options.UseBackColor = True
        Me.BtnSave.Appearance.Options.UseFont = True
        Me.BtnSave.Appearance.Options.UseForeColor = True
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Location = New System.Drawing.Point(557, 5)
        Me.BtnSave.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnSave.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Red
        Me.BtnSave.LookAndFeel.SkinName = "Metropolis"
        Me.BtnSave.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnSave.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 29)
        Me.BtnSave.TabIndex = 4
        Me.BtnSave.Text = "Save"
        '
        'GCRole
        '
        Me.GCRole.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRole.Location = New System.Drawing.Point(5, 43)
        Me.GCRole.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GCRole.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GCRole.MainView = Me.GVRole
        Me.GCRole.Name = "GCRole"
        Me.GCRole.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemCheckEdit2, Me.RepositoryItemCheckEdit3, Me.RepositoryItemCheckEdit4})
        Me.GCRole.Size = New System.Drawing.Size(632, 286)
        Me.GCRole.TabIndex = 4
        Me.GCRole.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRole})
        '
        'GVRole
        '
        Me.GVRole.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdMenu, Me.GridColumnDesc, Me.GridColumn1})
        Me.GVRole.GridControl = Me.GCRole
        Me.GVRole.Name = "GVRole"
        Me.GVRole.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdMenu
        '
        Me.GridColumnIdMenu.Caption = "Id Menu"
        Me.GridColumnIdMenu.FieldName = "id_menu"
        Me.GridColumnIdMenu.Name = "GridColumnIdMenu"
        Me.GridColumnIdMenu.OptionsColumn.AllowEdit = False
        '
        'GridColumnDesc
        '
        Me.GridColumnDesc.Caption = "Description"
        Me.GridColumnDesc.FieldName = "menu"
        Me.GridColumnDesc.Name = "GridColumnDesc"
        Me.GridColumnDesc.OptionsColumn.AllowEdit = False
        Me.GridColumnDesc.Visible = True
        Me.GridColumnDesc.VisibleIndex = 0
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Access"
        Me.GridColumn1.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumn1.FieldName = "is_allow"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 1
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "1"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "2"
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.ValueChecked = "1"
        Me.RepositoryItemCheckEdit2.ValueUnchecked = "2"
        '
        'RepositoryItemCheckEdit3
        '
        Me.RepositoryItemCheckEdit3.AutoHeight = False
        Me.RepositoryItemCheckEdit3.Name = "RepositoryItemCheckEdit3"
        Me.RepositoryItemCheckEdit3.ValueChecked = "1"
        Me.RepositoryItemCheckEdit3.ValueUnchecked = "2"
        '
        'RepositoryItemCheckEdit4
        '
        Me.RepositoryItemCheckEdit4.AutoHeight = False
        Me.RepositoryItemCheckEdit4.Name = "RepositoryItemCheckEdit4"
        Me.RepositoryItemCheckEdit4.ValueChecked = "1"
        Me.RepositoryItemCheckEdit4.ValueUnchecked = "2"
        '
        'FormUserRole
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(637, 363)
        Me.Controls.Add(Me.GCRole)
        Me.Controls.Add(Me.PanelControlBottom)
        Me.Controls.Add(Me.PanelControlTop)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.LookAndFeel.SkinName = "Metropolis"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormUserRole"
        Me.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Role"
        CType(Me.TxtRole.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlTop.ResumeLayout(False)
        Me.PanelControlTop.PerformLayout()
        CType(Me.PanelControlBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlBottom.ResumeLayout(False)
        CType(Me.GCRole, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRole, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TxtRole As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControlTop As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControlBottom As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCRole As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRole As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdMenu As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
