﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormUser))
        Me.XTCUser = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPRole = New DevExpress.XtraTab.XtraTabPage()
        Me.GCRole = New DevExpress.XtraGrid.GridControl()
        Me.GVRole = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPUser = New DevExpress.XtraTab.XtraTabPage()
        Me.GCUser = New DevExpress.XtraGrid.GridControl()
        Me.GVUser = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControlBack = New DevExpress.XtraEditors.PanelControl()
        Me.XTPProfile = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPReceipt = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPServer = New DevExpress.XtraTab.XtraTabPage()
        Me.BtnSaveProfile = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtCompName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtTagline = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtOutletName = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtOutletId = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtSupervisor = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.XTCUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCUser.SuspendLayout()
        Me.XTPRole.SuspendLayout()
        CType(Me.GCRole, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRole, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPUser.SuspendLayout()
        CType(Me.GCUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.PanelControlBack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPProfile.SuspendLayout()
        CType(Me.TxtCompName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTagline.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOutletName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOutletId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSupervisor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCUser
        '
        Me.XTCUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCUser.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left
        Me.XTCUser.Location = New System.Drawing.Point(20, 65)
        Me.XTCUser.LookAndFeel.SkinName = "Metropolis"
        Me.XTCUser.LookAndFeel.UseDefaultLookAndFeel = False
        Me.XTCUser.Name = "XTCUser"
        Me.XTCUser.SelectedTabPage = Me.XTPRole
        Me.XTCUser.Size = New System.Drawing.Size(649, 267)
        Me.XTCUser.TabIndex = 0
        Me.XTCUser.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPRole, Me.XTPUser, Me.XTPProfile, Me.XTPReceipt, Me.XTPServer})
        '
        'XTPRole
        '
        Me.XTPRole.Controls.Add(Me.GCRole)
        Me.XTPRole.Name = "XTPRole"
        Me.XTPRole.Size = New System.Drawing.Size(623, 265)
        Me.XTPRole.Text = "Role"
        '
        'GCRole
        '
        Me.GCRole.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRole.Location = New System.Drawing.Point(0, 0)
        Me.GCRole.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GCRole.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GCRole.MainView = Me.GVRole
        Me.GCRole.Name = "GCRole"
        Me.GCRole.Size = New System.Drawing.Size(623, 265)
        Me.GCRole.TabIndex = 1
        Me.GCRole.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRole})
        '
        'GVRole
        '
        Me.GVRole.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumnId})
        Me.GVRole.GridControl = Me.GCRole
        Me.GVRole.Name = "GVRole"
        Me.GVRole.OptionsBehavior.Editable = False
        Me.GVRole.OptionsView.ShowGroupPanel = False
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Role"
        Me.GridColumn6.FieldName = "role"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "Role"
        Me.GridColumnId.FieldName = "id_role"
        Me.GridColumnId.Name = "GridColumnId"
        '
        'XTPUser
        '
        Me.XTPUser.Controls.Add(Me.GCUser)
        Me.XTPUser.Name = "XTPUser"
        Me.XTPUser.Size = New System.Drawing.Size(623, 265)
        Me.XTPUser.Text = "User"
        '
        'GCUser
        '
        Me.GCUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCUser.Location = New System.Drawing.Point(0, 0)
        Me.GCUser.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GCUser.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GCUser.MainView = Me.GVUser
        Me.GCUser.Name = "GCUser"
        Me.GCUser.Size = New System.Drawing.Size(623, 265)
        Me.GCUser.TabIndex = 0
        Me.GCUser.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVUser})
        '
        'GVUser
        '
        Me.GVUser.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.GVUser.GridControl = Me.GCUser
        Me.GVUser.Name = "GVUser"
        Me.GVUser.OptionsBehavior.Editable = False
        Me.GVUser.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Username"
        Me.GridColumn1.FieldName = "username"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 1
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Employee"
        Me.GridColumn2.FieldName = "employee_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Role"
        Me.GridColumn3.FieldName = "role"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.PanelControl2)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(20, 332)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(649, 35)
        Me.PanelControl1.TabIndex = 0
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.LabelControl8)
        Me.PanelControl2.Controls.Add(Me.LabelControl9)
        Me.PanelControl2.Controls.Add(Me.LabelControl5)
        Me.PanelControl2.Controls.Add(Me.LabelControl6)
        Me.PanelControl2.Controls.Add(Me.LabelControl3)
        Me.PanelControl2.Controls.Add(Me.LabelControl4)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl2.Location = New System.Drawing.Point(372, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(277, 35)
        Me.PanelControl2.TabIndex = 7
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(237, 11)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(28, 13)
        Me.LabelControl8.TabIndex = 15
        Me.LabelControl8.Text = "Close"
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(214, 11)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(16, 13)
        Me.LabelControl9.TabIndex = 14
        Me.LabelControl9.Text = "Esc"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(169, 11)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl5.TabIndex = 12
        Me.LabelControl5.Text = "Delete"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(146, 11)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(17, 13)
        Me.LabelControl6.TabIndex = 11
        Me.LabelControl6.Text = "Del"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(108, 11)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(20, 13)
        Me.LabelControl3.TabIndex = 10
        Me.LabelControl3.Text = "Edit"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(77, 11)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(27, 13)
        Me.LabelControl4.TabIndex = 9
        Me.LabelControl4.Text = "Enter"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(35, 11)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl2.TabIndex = 8
        Me.LabelControl2.Text = "New"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(16, 11)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(15, 13)
        Me.LabelControl1.TabIndex = 7
        Me.LabelControl1.Text = "Ins"
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.LabelControl13)
        Me.PanelControl3.Controls.Add(Me.PanelControlBack)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(20, 20)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(649, 45)
        Me.PanelControl3.TabIndex = 5
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.Font = New System.Drawing.Font("Segoe UI Light", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl13.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl13.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelControl13.Location = New System.Drawing.Point(40, 0)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(212, 37)
        Me.LabelControl13.TabIndex = 1
        Me.LabelControl13.Text = "Application Setting"
        '
        'PanelControlBack
        '
        Me.PanelControlBack.Appearance.BackColor = System.Drawing.Color.White
        Me.PanelControlBack.Appearance.Options.UseBackColor = True
        Me.PanelControlBack.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlBack.ContentImage = CType(resources.GetObject("PanelControlBack.ContentImage"), System.Drawing.Image)
        Me.PanelControlBack.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControlBack.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlBack.Name = "PanelControlBack"
        Me.PanelControlBack.Size = New System.Drawing.Size(40, 45)
        Me.PanelControlBack.TabIndex = 5
        '
        'XTPProfile
        '
        Me.XTPProfile.Controls.Add(Me.SimpleButton2)
        Me.XTPProfile.Controls.Add(Me.TxtSupervisor)
        Me.XTPProfile.Controls.Add(Me.LabelControl14)
        Me.XTPProfile.Controls.Add(Me.TxtOutletId)
        Me.XTPProfile.Controls.Add(Me.LabelControl12)
        Me.XTPProfile.Controls.Add(Me.SimpleButton1)
        Me.XTPProfile.Controls.Add(Me.TxtOutletName)
        Me.XTPProfile.Controls.Add(Me.LabelControl11)
        Me.XTPProfile.Controls.Add(Me.TxtTagline)
        Me.XTPProfile.Controls.Add(Me.LabelControl10)
        Me.XTPProfile.Controls.Add(Me.TxtCompName)
        Me.XTPProfile.Controls.Add(Me.LabelControl7)
        Me.XTPProfile.Controls.Add(Me.BtnSaveProfile)
        Me.XTPProfile.Name = "XTPProfile"
        Me.XTPProfile.Size = New System.Drawing.Size(623, 265)
        Me.XTPProfile.Text = "Profile"
        '
        'XTPReceipt
        '
        Me.XTPReceipt.Name = "XTPReceipt"
        Me.XTPReceipt.Size = New System.Drawing.Size(0, 0)
        Me.XTPReceipt.Text = "Receipt"
        '
        'XTPServer
        '
        Me.XTPServer.Name = "XTPServer"
        Me.XTPServer.Size = New System.Drawing.Size(0, 0)
        Me.XTPServer.Text = "Server"
        '
        'BtnSaveProfile
        '
        Me.BtnSaveProfile.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnSaveProfile.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaveProfile.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnSaveProfile.Appearance.Options.UseBackColor = True
        Me.BtnSaveProfile.Appearance.Options.UseFont = True
        Me.BtnSaveProfile.Appearance.Options.UseForeColor = True
        Me.BtnSaveProfile.Location = New System.Drawing.Point(96, 91)
        Me.BtnSaveProfile.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnSaveProfile.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Red
        Me.BtnSaveProfile.LookAndFeel.SkinName = "Metropolis"
        Me.BtnSaveProfile.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnSaveProfile.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnSaveProfile.Name = "BtnSaveProfile"
        Me.BtnSaveProfile.Size = New System.Drawing.Size(58, 20)
        Me.BtnSaveProfile.TabIndex = 8
        Me.BtnSaveProfile.Text = "Save"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(15, 16)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl7.TabIndex = 6
        Me.LabelControl7.Text = "Company Name"
        '
        'TxtCompName
        '
        Me.TxtCompName.Location = New System.Drawing.Point(96, 13)
        Me.TxtCompName.Name = "TxtCompName"
        Me.TxtCompName.Size = New System.Drawing.Size(266, 20)
        Me.TxtCompName.TabIndex = 1
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(373, 16)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl10.TabIndex = 8
        Me.LabelControl10.Text = "Tagline"
        '
        'TxtTagline
        '
        Me.TxtTagline.Location = New System.Drawing.Point(422, 13)
        Me.TxtTagline.Name = "TxtTagline"
        Me.TxtTagline.Size = New System.Drawing.Size(190, 20)
        Me.TxtTagline.TabIndex = 2
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(15, 42)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl11.TabIndex = 10
        Me.LabelControl11.Text = "Outlet Name"
        '
        'TxtOutletName
        '
        Me.TxtOutletName.Location = New System.Drawing.Point(96, 39)
        Me.TxtOutletName.Name = "TxtOutletName"
        Me.TxtOutletName.Size = New System.Drawing.Size(266, 20)
        Me.TxtOutletName.TabIndex = 3
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton1.Appearance.ForeColor = System.Drawing.Color.White
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.Appearance.Options.UseForeColor = True
        Me.SimpleButton1.Location = New System.Drawing.Point(581, 39)
        Me.SimpleButton1.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.SimpleButton1.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Red
        Me.SimpleButton1.LookAndFeel.SkinName = "Metropolis"
        Me.SimpleButton1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.SimpleButton1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(31, 20)
        Me.SimpleButton1.TabIndex = 5
        Me.SimpleButton1.Text = ". . ."
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(373, 42)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl12.TabIndex = 13
        Me.LabelControl12.Text = "Outlet Id"
        '
        'TxtOutletId
        '
        Me.TxtOutletId.Location = New System.Drawing.Point(422, 39)
        Me.TxtOutletId.Name = "TxtOutletId"
        Me.TxtOutletId.Size = New System.Drawing.Size(155, 20)
        Me.TxtOutletId.TabIndex = 4
        '
        'LabelControl14
        '
        Me.LabelControl14.Location = New System.Drawing.Point(15, 68)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl14.TabIndex = 15
        Me.LabelControl14.Text = "Supervisor"
        '
        'TxtSupervisor
        '
        Me.TxtSupervisor.Location = New System.Drawing.Point(96, 65)
        Me.TxtSupervisor.Name = "TxtSupervisor"
        Me.TxtSupervisor.Size = New System.Drawing.Size(229, 20)
        Me.TxtSupervisor.TabIndex = 6
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton2.Appearance.ForeColor = System.Drawing.Color.White
        Me.SimpleButton2.Appearance.Options.UseBackColor = True
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.Appearance.Options.UseForeColor = True
        Me.SimpleButton2.Location = New System.Drawing.Point(331, 65)
        Me.SimpleButton2.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.SimpleButton2.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Red
        Me.SimpleButton2.LookAndFeel.SkinName = "Metropolis"
        Me.SimpleButton2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.SimpleButton2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(31, 20)
        Me.SimpleButton2.TabIndex = 7
        Me.SimpleButton2.Text = ". . ."
        '
        'FormUser
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(689, 387)
        Me.Controls.Add(Me.XTCUser)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControl3)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.LookAndFeel.SkinName = "Metropolis"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MinimizeBox = False
        Me.Name = "FormUser"
        Me.Padding = New System.Windows.Forms.Padding(20)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Management"
        CType(Me.XTCUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCUser.ResumeLayout(False)
        Me.XTPRole.ResumeLayout(False)
        CType(Me.GCRole, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRole, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPUser.ResumeLayout(False)
        CType(Me.GCUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.PanelControlBack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPProfile.ResumeLayout(False)
        Me.XTPProfile.PerformLayout()
        CType(Me.TxtCompName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTagline.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOutletName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOutletId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSupervisor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCUser As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPUser As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPRole As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCUser As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVUser As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCRole As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRole As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControlBack As DevExpress.XtraEditors.PanelControl
    Friend WithEvents XTPProfile As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPReceipt As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPServer As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TxtTagline As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtCompName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnSaveProfile As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtOutletId As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtOutletName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtSupervisor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
End Class
