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
        Dim TileItemElement3 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement2 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement5 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement6 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement4 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Me.TileControl1 = New DevExpress.XtraEditors.TileControl()
        Me.TGGeneral = New DevExpress.XtraEditors.TileGroup()
        Me.TIInv = New DevExpress.XtraEditors.TileItem()
        Me.TileItem4 = New DevExpress.XtraEditors.TileItem()
        Me.TIPOS = New DevExpress.XtraEditors.TileItem()
        Me.TIExit = New DevExpress.XtraEditors.TileItem()
        Me.TileItem2 = New DevExpress.XtraEditors.TileItem()
        Me.TIEnd = New DevExpress.XtraEditors.TileItem()
        Me.SuspendLayout()
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
        Me.TileControl1.ItemSize = 125
        Me.TileControl1.Location = New System.Drawing.Point(0, 0)
        Me.TileControl1.MaxId = 50
        Me.TileControl1.Name = "TileControl1"
        Me.TileControl1.Size = New System.Drawing.Size(484, 233)
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
        Me.TGGeneral.Text = "General"
        '
        'TIInv
        '
        Me.TIInv.AppearanceItem.Normal.BackColor = System.Drawing.Color.SeaGreen
        Me.TIInv.AppearanceItem.Normal.BorderColor = System.Drawing.Color.SeaGreen
        Me.TIInv.AppearanceItem.Normal.Options.UseBackColor = True
        Me.TIInv.AppearanceItem.Normal.Options.UseBorderColor = True
        Me.TIInv.BackgroundImage = CType(resources.GetObject("TIInv.BackgroundImage"), System.Drawing.Image)
        Me.TIInv.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileItemElement1.Text = "Inventory Control"
        TileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter
        Me.TIInv.Elements.Add(TileItemElement1)
        Me.TIInv.Id = 47
        Me.TIInv.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
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
        TileItemElement3.Text = "About"
        TileItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft
        Me.TileItem4.Elements.Add(TileItemElement3)
        Me.TileItem4.Id = 48
        Me.TileItem4.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
        Me.TileItem4.Name = "TileItem4"
        Me.TileItem4.Visible = False
        '
        'TIPOS
        '
        Me.TIPOS.AppearanceItem.Normal.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.TIPOS.AppearanceItem.Normal.BorderColor = System.Drawing.Color.DeepSkyBlue
        Me.TIPOS.AppearanceItem.Normal.Options.UseBackColor = True
        Me.TIPOS.AppearanceItem.Normal.Options.UseBorderColor = True
        Me.TIPOS.BackgroundImage = CType(resources.GetObject("TIPOS.BackgroundImage"), System.Drawing.Image)
        Me.TIPOS.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileItemElement2.Text = "Point of Sale"
        TileItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter
        Me.TIPOS.Elements.Add(TileItemElement2)
        Me.TIPOS.Id = 23
        Me.TIPOS.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TIPOS.Name = "TIPOS"
        '
        'TIExit
        '
        Me.TIExit.AppearanceItem.Normal.BackColor = System.Drawing.Color.Firebrick
        Me.TIExit.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Firebrick
        Me.TIExit.AppearanceItem.Normal.Options.UseBackColor = True
        Me.TIExit.AppearanceItem.Normal.Options.UseBorderColor = True
        Me.TIExit.BackgroundImage = CType(resources.GetObject("TIExit.BackgroundImage"), System.Drawing.Image)
        TileItemElement5.Text = "Exit"
        TileItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter
        Me.TIExit.Elements.Add(TileItemElement5)
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
        TileItemElement6.Text = "Exit Program"
        TileItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft
        Me.TileItem2.Elements.Add(TileItemElement6)
        Me.TileItem2.Id = 45
        Me.TileItem2.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
        Me.TileItem2.Name = "TileItem2"
        '
        'TIEnd
        '
        Me.TIEnd.AppearanceItem.Normal.BackColor = System.Drawing.Color.Firebrick
        Me.TIEnd.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Firebrick
        Me.TIEnd.AppearanceItem.Normal.Options.UseBackColor = True
        Me.TIEnd.AppearanceItem.Normal.Options.UseBorderColor = True
        Me.TIEnd.BackgroundImage = CType(resources.GetObject("TIEnd.BackgroundImage"), System.Drawing.Image)
        TileItemElement4.Text = "Exit"
        TileItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter
        Me.TIEnd.Elements.Add(TileItemElement4)
        Me.TIEnd.Id = 49
        Me.TIEnd.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TIEnd.Name = "TIEnd"
        '
        'FormFront
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 233)
        Me.Controls.Add(Me.TileControl1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.LookAndFeel.SkinName = "Metropolis Dark"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFront"
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
End Class
