<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormHome
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim TileItemElement19 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement20 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement21 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement22 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement23 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement24 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormHome))
        Me.TileControl1 = New DevExpress.XtraEditors.TileControl()
        Me.TileGroup2 = New DevExpress.XtraEditors.TileGroup()
        Me.TileItem1 = New DevExpress.XtraEditors.TileItem()
        Me.TileItem2 = New DevExpress.XtraEditors.TileItem()
        Me.TileGroup3 = New DevExpress.XtraEditors.TileGroup()
        Me.TileItem4 = New DevExpress.XtraEditors.TileItem()
        Me.TileItem5 = New DevExpress.XtraEditors.TileItem()
        Me.TileItem7 = New DevExpress.XtraEditors.TileItem()
        Me.TileItem6 = New DevExpress.XtraEditors.TileItem()
        Me.TileGroup4 = New DevExpress.XtraEditors.TileGroup()
        Me.NavButton3 = New DevExpress.XtraBars.Navigation.NavButton()
        Me.NavButton2 = New DevExpress.XtraBars.Navigation.NavButton()
        Me.NavButton4 = New DevExpress.XtraBars.Navigation.NavButton()
        Me.SuspendLayout()
        '
        'TileControl1
        '
        Me.TileControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TileControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TileControl1.DragSize = New System.Drawing.Size(0, 0)
        Me.TileControl1.Groups.Add(Me.TileGroup2)
        Me.TileControl1.Groups.Add(Me.TileGroup3)
        Me.TileControl1.Groups.Add(Me.TileGroup4)
        Me.TileControl1.ItemSize = 150
        Me.TileControl1.Location = New System.Drawing.Point(0, 0)
        Me.TileControl1.MaxId = 16
        Me.TileControl1.Name = "TileControl1"
        Me.TileControl1.ShowGroupText = True
        Me.TileControl1.Size = New System.Drawing.Size(834, 562)
        Me.TileControl1.TabIndex = 0
        Me.TileControl1.Text = "TileControl1"
        '
        'TileGroup2
        '
        Me.TileGroup2.Items.Add(Me.TileItem1)
        Me.TileGroup2.Items.Add(Me.TileItem2)
        Me.TileGroup2.Name = "TileGroup2"
        Me.TileGroup2.Text = "General"
        '
        'TileItem1
        '
        TileItemElement19.Text = "Master Product"
        Me.TileItem1.Elements.Add(TileItemElement19)
        Me.TileItem1.Id = 4
        Me.TileItem1.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
        Me.TileItem1.Name = "TileItem1"
        '
        'TileItem2
        '
        TileItemElement20.Text = "User Management"
        Me.TileItem2.Elements.Add(TileItemElement20)
        Me.TileItem2.Id = 5
        Me.TileItem2.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TileItem2.Name = "TileItem2"
        '
        'TileGroup3
        '
        Me.TileGroup3.Items.Add(Me.TileItem4)
        Me.TileGroup3.Items.Add(Me.TileItem5)
        Me.TileGroup3.Items.Add(Me.TileItem7)
        Me.TileGroup3.Items.Add(Me.TileItem6)
        Me.TileGroup3.Name = "TileGroup3"
        Me.TileGroup3.Text = "Transaction"
        '
        'TileItem4
        '
        TileItemElement21.Text = "Receive"
        Me.TileItem4.Elements.Add(TileItemElement21)
        Me.TileItem4.Id = 11
        Me.TileItem4.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TileItem4.Name = "TileItem4"
        '
        'TileItem5
        '
        TileItemElement22.Text = "Return"
        Me.TileItem5.Elements.Add(TileItemElement22)
        Me.TileItem5.Id = 12
        Me.TileItem5.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TileItem5.Name = "TileItem5"
        '
        'TileItem7
        '
        TileItemElement23.Text = "Transfer"
        Me.TileItem7.Elements.Add(TileItemElement23)
        Me.TileItem7.Id = 15
        Me.TileItem7.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TileItem7.Name = "TileItem7"
        '
        'TileItem6
        '
        TileItemElement24.Text = "Sales"
        Me.TileItem6.Elements.Add(TileItemElement24)
        Me.TileItem6.Id = 14
        Me.TileItem6.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TileItem6.Name = "TileItem6"
        '
        'TileGroup4
        '
        Me.TileGroup4.Name = "TileGroup4"
        Me.TileGroup4.Text = "Report"
        '
        'NavButton3
        '
        Me.NavButton3.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right
        Me.NavButton3.Appearance.ForeColor = System.Drawing.Color.Black
        Me.NavButton3.Appearance.Options.UseForeColor = True
        Me.NavButton3.Caption = "Logout"
        Me.NavButton3.Name = "NavButton3"
        '
        'NavButton2
        '
        Me.NavButton2.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right
        Me.NavButton2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.NavButton2.Appearance.Options.UseForeColor = True
        Me.NavButton2.Caption = "Catur Anas"
        Me.NavButton2.Glyph = CType(resources.GetObject("NavButton2.Glyph"), System.Drawing.Image)
        Me.NavButton2.IsMain = True
        Me.NavButton2.Name = "NavButton2"
        '
        'NavButton4
        '
        Me.NavButton4.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right
        Me.NavButton4.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavButton4.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.NavButton4.Appearance.Options.UseFont = True
        Me.NavButton4.Appearance.Options.UseForeColor = True
        Me.NavButton4.AppearanceSelected.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.NavButton4.AppearanceSelected.Options.UseBackColor = True
        Me.NavButton4.Caption = "Catur Anas"
        Me.NavButton4.Glyph = CType(resources.GetObject("NavButton4.Glyph"), System.Drawing.Image)
        Me.NavButton4.IsMain = True
        Me.NavButton4.Name = "NavButton4"
        '
        'FormHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 562)
        Me.Controls.Add(Me.TileControl1)
        Me.LookAndFeel.SkinName = "Metropolis"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "FormHome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Point of Sale"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TileControl1 As DevExpress.XtraEditors.TileControl
    Friend WithEvents TileGroup2 As DevExpress.XtraEditors.TileGroup
    Friend WithEvents TileItem1 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileItem2 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileGroup3 As DevExpress.XtraEditors.TileGroup
    Friend WithEvents TileItem4 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileItem5 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileItem7 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileItem6 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileGroup4 As DevExpress.XtraEditors.TileGroup
    Friend WithEvents NavButton3 As DevExpress.XtraBars.Navigation.NavButton
    Friend WithEvents NavButton2 As DevExpress.XtraBars.Navigation.NavButton
    Friend WithEvents NavButton4 As DevExpress.XtraBars.Navigation.NavButton
End Class
