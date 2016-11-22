<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFront
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFront))
        Dim TileItemElement1 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement2 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement3 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement4 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement5 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Me.PanelControlTop = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TileControl1 = New DevExpress.XtraEditors.TileControl()
        Me.TGGeneral = New DevExpress.XtraEditors.TileGroup()
        Me.TIInv = New DevExpress.XtraEditors.TileItem()
        Me.TileItem4 = New DevExpress.XtraEditors.TileItem()
        Me.TileGroup3 = New DevExpress.XtraEditors.TileGroup()
        Me.TIPOS = New DevExpress.XtraEditors.TileItem()
        Me.TIExit = New DevExpress.XtraEditors.TileItem()
        Me.TileItem2 = New DevExpress.XtraEditors.TileItem()
        CType(Me.PanelControlTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControlTop
        '
        Me.PanelControlTop.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControlTop.Appearance.Options.UseBackColor = True
        Me.PanelControlTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlTop.Controls.Add(Me.LabelControl1)
        Me.PanelControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlTop.Name = "PanelControlTop"
        Me.PanelControlTop.Padding = New System.Windows.Forms.Padding(20)
        Me.PanelControlTop.Size = New System.Drawing.Size(1350, 81)
        Me.PanelControlTop.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI Light", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.White
        Me.LabelControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelControl1.Location = New System.Drawing.Point(20, 20)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(186, 47)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Volcom POS"
        '
        'TileControl1
        '
        Me.TileControl1.AppearanceGroupText.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TileControl1.AppearanceGroupText.ForeColor = System.Drawing.Color.White
        Me.TileControl1.AppearanceGroupText.Options.UseFont = True
        Me.TileControl1.AppearanceGroupText.Options.UseForeColor = True
        Me.TileControl1.AppearanceItem.Normal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TileControl1.AppearanceItem.Normal.Options.UseFont = True
        Me.TileControl1.AppearanceText.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TileControl1.AppearanceText.ForeColor = System.Drawing.Color.White
        Me.TileControl1.AppearanceText.Options.UseFont = True
        Me.TileControl1.AppearanceText.Options.UseForeColor = True
        Me.TileControl1.BackColor = System.Drawing.Color.Transparent
        Me.TileControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TileControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TileControl1.DragSize = New System.Drawing.Size(0, 0)
        Me.TileControl1.Groups.Add(Me.TGGeneral)
        Me.TileControl1.Groups.Add(Me.TileGroup3)
        Me.TileControl1.ItemSize = 125
        Me.TileControl1.Location = New System.Drawing.Point(0, 81)
        Me.TileControl1.MaxId = 49
        Me.TileControl1.Name = "TileControl1"
        Me.TileControl1.Size = New System.Drawing.Size(1350, 649)
        Me.TileControl1.TabIndex = 3
        Me.TileControl1.Text = "POINT OF SALE"
        '
        'TGGeneral
        '
        Me.TGGeneral.Items.Add(Me.TIInv)
        Me.TGGeneral.Items.Add(Me.TileItem4)
        Me.TGGeneral.Name = "TGGeneral"
        Me.TGGeneral.Text = "General"
        '
        'TIInv
        '
        Me.TIInv.AppearanceItem.Normal.BackColor = System.Drawing.Color.Chocolate
        Me.TIInv.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Chocolate
        Me.TIInv.AppearanceItem.Normal.Options.UseBackColor = True
        Me.TIInv.AppearanceItem.Normal.Options.UseBorderColor = True
        Me.TIInv.BackgroundImage = CType(resources.GetObject("TIInv.BackgroundImage"), System.Drawing.Image)
        Me.TIInv.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileItemElement1.Text = "Inventory Control"
        TileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft
        Me.TIInv.Elements.Add(TileItemElement1)
        Me.TIInv.Id = 47
        Me.TIInv.ItemSize = DevExpress.XtraEditors.TileItemSize.Large
        Me.TIInv.Name = "TIInv"
        '
        'TileItem4
        '
        Me.TileItem4.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TileItem4.AppearanceItem.Normal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TileItem4.AppearanceItem.Normal.Options.UseBackColor = True
        Me.TileItem4.AppearanceItem.Normal.Options.UseBorderColor = True
        Me.TileItem4.BackgroundImage = CType(resources.GetObject("TileItem4.BackgroundImage"), System.Drawing.Image)
        Me.TileItem4.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileItemElement2.Text = "About"
        TileItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft
        Me.TileItem4.Elements.Add(TileItemElement2)
        Me.TileItem4.Id = 48
        Me.TileItem4.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
        Me.TileItem4.Name = "TileItem4"
        Me.TileItem4.Visible = False
        '
        'TileGroup3
        '
        Me.TileGroup3.Items.Add(Me.TIPOS)
        Me.TileGroup3.Name = "TileGroup3"
        '
        'TIPOS
        '
        Me.TIPOS.AppearanceItem.Normal.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.TIPOS.AppearanceItem.Normal.BorderColor = System.Drawing.Color.DeepSkyBlue
        Me.TIPOS.AppearanceItem.Normal.Options.UseBackColor = True
        Me.TIPOS.AppearanceItem.Normal.Options.UseBorderColor = True
        Me.TIPOS.BackgroundImage = CType(resources.GetObject("TIPOS.BackgroundImage"), System.Drawing.Image)
        Me.TIPOS.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileItemElement3.Text = "Point of Sale"
        TileItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft
        Me.TIPOS.Elements.Add(TileItemElement3)
        Me.TIPOS.Id = 23
        Me.TIPOS.ItemSize = DevExpress.XtraEditors.TileItemSize.Large
        Me.TIPOS.Name = "TIPOS"
        '
        'TIExit
        '
        Me.TIExit.AppearanceItem.Normal.BackColor = System.Drawing.Color.Firebrick
        Me.TIExit.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Firebrick
        Me.TIExit.AppearanceItem.Normal.Options.UseBackColor = True
        Me.TIExit.AppearanceItem.Normal.Options.UseBorderColor = True
        Me.TIExit.BackgroundImage = CType(resources.GetObject("TIExit.BackgroundImage"), System.Drawing.Image)
        TileItemElement4.Text = "Exit"
        TileItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter
        Me.TIExit.Elements.Add(TileItemElement4)
        Me.TIExit.Id = 29
        Me.TIExit.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TIExit.Name = "TIExit"
        '
        'TileItem2
        '
        Me.TileItem2.AppearanceItem.Normal.BackColor = System.Drawing.Color.Firebrick
        Me.TileItem2.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Firebrick
        Me.TileItem2.AppearanceItem.Normal.Options.UseBackColor = True
        Me.TileItem2.AppearanceItem.Normal.Options.UseBorderColor = True
        Me.TileItem2.BackgroundImage = CType(resources.GetObject("TileItem2.BackgroundImage"), System.Drawing.Image)
        Me.TileItem2.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileItemElement5.Text = "Exit Program"
        TileItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft
        Me.TileItem2.Elements.Add(TileItemElement5)
        Me.TileItem2.Id = 45
        Me.TileItem2.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
        Me.TileItem2.Name = "TileItem2"
        '
        'FormFront
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1350, 730)
        Me.Controls.Add(Me.TileControl1)
        Me.Controls.Add(Me.PanelControlTop)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.LookAndFeel.SkinName = "Metropolis"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "FormFront"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormFront"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControlTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlTop.ResumeLayout(False)
        Me.PanelControlTop.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControlTop As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TileControl1 As DevExpress.XtraEditors.TileControl
    Friend WithEvents TGGeneral As DevExpress.XtraEditors.TileGroup
    Friend WithEvents TIPOS As DevExpress.XtraEditors.TileItem
    Friend WithEvents TIExit As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileItem2 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TIInv As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileItem4 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileGroup3 As DevExpress.XtraEditors.TileGroup
End Class
