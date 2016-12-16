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
        Dim TileItemElement43 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement44 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement45 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement46 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement47 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement48 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Me.TileControl1 = New DevExpress.XtraEditors.TileControl()
        Me.TGGeneral = New DevExpress.XtraEditors.TileGroup()
        Me.TIInv = New DevExpress.XtraEditors.TileItem()
        Me.TIPOS = New DevExpress.XtraEditors.TileItem()
        Me.TileItem4 = New DevExpress.XtraEditors.TileItem()
        Me.TIEnd = New DevExpress.XtraEditors.TileItem()
        Me.TIExit = New DevExpress.XtraEditors.TileItem()
        Me.TileItem2 = New DevExpress.XtraEditors.TileItem()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
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
        Me.TileControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TileControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TileControl1.DragSize = New System.Drawing.Size(0, 0)
        Me.TileControl1.Groups.Add(Me.TGGeneral)
        Me.TileControl1.ItemSize = 125
        Me.TileControl1.Location = New System.Drawing.Point(2, 2)
        Me.TileControl1.MaxId = 50
        Me.TileControl1.Name = "TileControl1"
        Me.TileControl1.ShowGroupText = True
        Me.TileControl1.Size = New System.Drawing.Size(567, 313)
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
        Me.TIInv.AppearanceItem.Normal.BackColor = System.Drawing.Color.OrangeRed
        Me.TIInv.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Teal
        Me.TIInv.AppearanceItem.Normal.Options.UseBackColor = True
        Me.TIInv.AppearanceItem.Normal.Options.UseBorderColor = True
        Me.TIInv.BackgroundImage = CType(resources.GetObject("TIInv.BackgroundImage"), System.Drawing.Image)
        Me.TIInv.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileItemElement43.Text = "Inventory Control"
        TileItemElement43.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter
        Me.TIInv.Elements.Add(TileItemElement43)
        Me.TIInv.Id = 47
        Me.TIInv.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TIInv.Name = "TIInv"
        '
        'TIPOS
        '
        Me.TIPOS.AppearanceItem.Normal.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.TIPOS.AppearanceItem.Normal.BorderColor = System.Drawing.Color.DarkSlateBlue
        Me.TIPOS.AppearanceItem.Normal.Options.UseBackColor = True
        Me.TIPOS.AppearanceItem.Normal.Options.UseBorderColor = True
        Me.TIPOS.BackgroundImage = CType(resources.GetObject("TIPOS.BackgroundImage"), System.Drawing.Image)
        Me.TIPOS.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileItemElement44.Text = "Point of Sale"
        TileItemElement44.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter
        Me.TIPOS.Elements.Add(TileItemElement44)
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
        TileItemElement45.Text = "About"
        TileItemElement45.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft
        Me.TileItem4.Elements.Add(TileItemElement45)
        Me.TileItem4.Id = 48
        Me.TileItem4.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
        Me.TileItem4.Name = "TileItem4"
        Me.TileItem4.Visible = False
        '
        'TIEnd
        '
        Me.TIEnd.AppearanceItem.Normal.BackColor = System.Drawing.Color.Firebrick
        Me.TIEnd.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Firebrick
        Me.TIEnd.AppearanceItem.Normal.Options.UseBackColor = True
        Me.TIEnd.AppearanceItem.Normal.Options.UseBorderColor = True
        Me.TIEnd.BackgroundImage = CType(resources.GetObject("TIEnd.BackgroundImage"), System.Drawing.Image)
        TileItemElement46.Text = "Exit"
        TileItemElement46.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter
        Me.TIEnd.Elements.Add(TileItemElement46)
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
        TileItemElement47.Text = "Exit"
        TileItemElement47.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter
        Me.TIExit.Elements.Add(TileItemElement47)
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
        TileItemElement48.Text = "Exit Program"
        TileItemElement48.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft
        Me.TileItem2.Elements.Add(TileItemElement48)
        Me.TileItem2.Id = 45
        Me.TileItem2.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
        Me.TileItem2.Name = "TileItem2"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.White
        Me.LabelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.LabelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LabelControl1.Location = New System.Drawing.Point(2, 321)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.LabelControl1.Size = New System.Drawing.Size(567, 16)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "PT VOLCOM INDONESIA - 2016"
        '
        'FormFront
        '
        Me.Appearance.BackColor = System.Drawing.Color.DimGray
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(571, 339)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.TileControl1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.LookAndFeel.SkinName = "Metropolis Dark"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFront"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Point of Sale"
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
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
