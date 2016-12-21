<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormFront
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFront))
        Dim TileItemElement13 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement14 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement15 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement16 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement17 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement18 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Me.TileControl1 = New DevExpress.XtraEditors.TileControl()
        Me.TGGeneral = New DevExpress.XtraEditors.TileGroup()
        Me.TIInv = New DevExpress.XtraEditors.TileItem()
        Me.TIPOS = New DevExpress.XtraEditors.TileItem()
        Me.TileItem4 = New DevExpress.XtraEditors.TileItem()
        Me.TIEnd = New DevExpress.XtraEditors.TileItem()
        Me.TIExit = New DevExpress.XtraEditors.TileItem()
        Me.TileItem2 = New DevExpress.XtraEditors.TileItem()
        Me.PanelBasic = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelBasic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBasic.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TileControl1
        '
        Me.TileControl1.AppearanceGroupText.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TileControl1.AppearanceGroupText.ForeColor = System.Drawing.Color.White
        Me.TileControl1.AppearanceGroupText.Options.UseFont = True
        Me.TileControl1.AppearanceGroupText.Options.UseForeColor = True
        Me.TileControl1.AppearanceItem.Normal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TileControl1.AppearanceItem.Normal.Options.UseFont = True
        Me.TileControl1.AppearanceText.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TileControl1.AppearanceText.ForeColor = System.Drawing.Color.White
        Me.TileControl1.AppearanceText.Options.UseFont = True
        Me.TileControl1.AppearanceText.Options.UseForeColor = True
        Me.TileControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TileControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TileControl1.DragSize = New System.Drawing.Size(0, 0)
        Me.TileControl1.Groups.Add(Me.TGGeneral)
        Me.TileControl1.ItemSize = 125
        Me.TileControl1.Location = New System.Drawing.Point(293, 445)
        Me.TileControl1.MaxId = 50
        Me.TileControl1.Name = "TileControl1"
        Me.TileControl1.ShowGroupText = True
        Me.TileControl1.Size = New System.Drawing.Size(107, 10)
        Me.TileControl1.TabIndex = 3
        Me.TileControl1.Text = "POINT OF SALE"
        '
        'TGGeneral
        '
        Me.TGGeneral.Items.Add(Me.TIInv)
        Me.TGGeneral.Items.Add(Me.TIPOS)
        Me.TGGeneral.Items.Add(Me.TileItem4)
        Me.TGGeneral.Items.Add(Me.TIEnd)
        Me.TGGeneral.Name = "TGGeneral"
        Me.TGGeneral.Text = "Volcom POS"
        '
        'TIInv
        '
        Me.TIInv.BackgroundImage = CType(resources.GetObject("TIInv.BackgroundImage"), System.Drawing.Image)
        Me.TIInv.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileItemElement13.Text = "Inventory Control"
        TileItemElement13.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter
        Me.TIInv.Elements.Add(TileItemElement13)
        Me.TIInv.Id = 47
        Me.TIInv.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TIInv.Name = "TIInv"
        '
        'TIPOS
        '
        Me.TIPOS.AppearanceItem.Normal.BackColor = System.Drawing.Color.SlateBlue
        Me.TIPOS.AppearanceItem.Normal.BorderColor = System.Drawing.Color.SlateBlue
        Me.TIPOS.AppearanceItem.Normal.Options.UseBackColor = True
        Me.TIPOS.AppearanceItem.Normal.Options.UseBorderColor = True
        Me.TIPOS.BackgroundImage = CType(resources.GetObject("TIPOS.BackgroundImage"), System.Drawing.Image)
        Me.TIPOS.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileItemElement14.Text = "Point of Sale"
        TileItemElement14.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter
        Me.TIPOS.Elements.Add(TileItemElement14)
        Me.TIPOS.Id = 23
        Me.TIPOS.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TIPOS.Name = "TIPOS"
        '
        'TileItem4
        '
        Me.TileItem4.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TileItem4.AppearanceItem.Normal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TileItem4.AppearanceItem.Normal.Options.UseBackColor = True
        Me.TileItem4.AppearanceItem.Normal.Options.UseBorderColor = True
        Me.TileItem4.BackgroundImage = CType(resources.GetObject("TileItem4.BackgroundImage"), System.Drawing.Image)
        Me.TileItem4.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileItemElement15.Text = "About"
        TileItemElement15.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft
        Me.TileItem4.Elements.Add(TileItemElement15)
        Me.TileItem4.Id = 48
        Me.TileItem4.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
        Me.TileItem4.Name = "TileItem4"
        Me.TileItem4.Visible = False
        '
        'TIEnd
        '
        Me.TIEnd.AppearanceItem.Normal.BackColor = System.Drawing.Color.Crimson
        Me.TIEnd.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Crimson
        Me.TIEnd.AppearanceItem.Normal.Options.UseBackColor = True
        Me.TIEnd.AppearanceItem.Normal.Options.UseBorderColor = True
        Me.TIEnd.BackgroundImage = CType(resources.GetObject("TIEnd.BackgroundImage"), System.Drawing.Image)
        TileItemElement16.Text = "Exit"
        TileItemElement16.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter
        Me.TIEnd.Elements.Add(TileItemElement16)
        Me.TIEnd.Id = 49
        Me.TIEnd.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TIEnd.Name = "TIEnd"
        '
        'TIExit
        '
        Me.TIExit.AppearanceItem.Normal.BackColor = System.Drawing.Color.Firebrick
        Me.TIExit.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Firebrick
        Me.TIExit.AppearanceItem.Normal.Options.UseBackColor = True
        Me.TIExit.AppearanceItem.Normal.Options.UseBorderColor = True
        Me.TIExit.BackgroundImage = CType(resources.GetObject("TIExit.BackgroundImage"), System.Drawing.Image)
        TileItemElement17.Text = "Exit"
        TileItemElement17.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter
        Me.TIExit.Elements.Add(TileItemElement17)
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
        TileItemElement18.Text = "Exit Program"
        TileItemElement18.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft
        Me.TileItem2.Elements.Add(TileItemElement18)
        Me.TileItem2.Id = 45
        Me.TileItem2.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
        Me.TileItem2.Name = "TileItem2"
        '
        'PanelBasic
        '
        Me.PanelBasic.Appearance.BackColor = System.Drawing.Color.LightBlue
        Me.PanelBasic.Appearance.Options.UseBackColor = True
        Me.PanelBasic.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelBasic.Controls.Add(Me.LabelControl2)
        Me.PanelBasic.Controls.Add(Me.PictureEdit1)
        Me.PanelBasic.Controls.Add(Me.PanelControl4)
        Me.PanelBasic.Controls.Add(Me.PanelControl2)
        Me.PanelBasic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBasic.Location = New System.Drawing.Point(0, 0)
        Me.PanelBasic.LookAndFeel.SkinName = "Office 2007 Pink"
        Me.PanelBasic.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelBasic.Name = "PanelBasic"
        Me.PanelBasic.Size = New System.Drawing.Size(662, 437)
        Me.PanelBasic.TabIndex = 4
        '
        'PanelControl2
        '
        Me.PanelControl2.Appearance.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PanelControl2.Appearance.Options.UseBackColor = True
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 206)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(662, 231)
        Me.PanelControl2.TabIndex = 1
        '
        'PanelControl4
        '
        Me.PanelControl4.Appearance.BackColor = System.Drawing.SystemColors.GrayText
        Me.PanelControl4.Appearance.Options.UseBackColor = True
        Me.PanelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl4.Controls.Add(Me.LabelControl1)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl4.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(662, 26)
        Me.PanelControl4.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI Light", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.White
        Me.LabelControl1.Location = New System.Drawing.Point(7, 4)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(69, 17)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Volcom POS"
        '
        'PictureEdit1
        '
        Me.PictureEdit1.EditValue = CType(resources.GetObject("PictureEdit1.EditValue"), Object)
        Me.PictureEdit1.Location = New System.Drawing.Point(3, 35)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit1.Size = New System.Drawing.Size(225, 163)
        Me.PictureEdit1.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.White
        Me.LabelControl2.Location = New System.Drawing.Point(188, 44)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(247, 32)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "TOKO BEMO CORNER"
        '
        'FormFront
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(662, 437)
        Me.Controls.Add(Me.PanelBasic)
        Me.Controls.Add(Me.TileControl1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFront"
        Me.Opacity = 0R
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Point of Sale"
        CType(Me.PanelBasic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBasic.ResumeLayout(False)
        Me.PanelBasic.PerformLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        Me.PanelControl4.PerformLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TileControl1 As DevExpress.XtraEditors.TileControl
    Friend WithEvents TGGeneral As DevExpress.XtraEditors.TileGroup
    Friend WithEvents TIPOS As DevExpress.XtraEditors.TileItem
    Friend WithEvents TIExit As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileItem2 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TIInv As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileItem4 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TIEnd As DevExpress.XtraEditors.TileItem
    Friend WithEvents PanelBasic As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
End Class
