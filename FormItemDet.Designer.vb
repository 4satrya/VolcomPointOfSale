<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormItemDet
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
        Me.PanelControlBottom = New DevExpress.XtraEditors.PanelControl()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtCode = New DevExpress.XtraEditors.TextEdit()
        Me.TxtDesc = New DevExpress.XtraEditors.TextEdit()
        Me.TxtPrice = New DevExpress.XtraEditors.TextEdit()
        CType(Me.PanelControlBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlBottom.SuspendLayout()
        CType(Me.TxtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControlBottom
        '
        Me.PanelControlBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlBottom.Controls.Add(Me.BtnSave)
        Me.PanelControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlBottom.Location = New System.Drawing.Point(0, 99)
        Me.PanelControlBottom.Name = "PanelControlBottom"
        Me.PanelControlBottom.Size = New System.Drawing.Size(441, 34)
        Me.PanelControlBottom.TabIndex = 5
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
        Me.BtnSave.Location = New System.Drawing.Point(366, 0)
        Me.BtnSave.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnSave.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Red
        Me.BtnSave.LookAndFeel.SkinName = "Metropolis"
        Me.BtnSave.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnSave.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 34)
        Me.BtnSave.TabIndex = 4
        Me.BtnSave.Text = "Save"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(23, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl1.TabIndex = 6
        Me.LabelControl1.Text = "Code"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(23, 42)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl2.TabIndex = 7
        Me.LabelControl2.Text = "Description"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(23, 68)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl3.TabIndex = 8
        Me.LabelControl3.Text = "Price"
        '
        'TxtCode
        '
        Me.TxtCode.Location = New System.Drawing.Point(103, 13)
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.Size = New System.Drawing.Size(313, 20)
        Me.TxtCode.TabIndex = 0
        '
        'TxtDesc
        '
        Me.TxtDesc.Location = New System.Drawing.Point(103, 39)
        Me.TxtDesc.Name = "TxtDesc"
        Me.TxtDesc.Size = New System.Drawing.Size(313, 20)
        Me.TxtDesc.TabIndex = 1
        '
        'TxtPrice
        '
        Me.TxtPrice.Location = New System.Drawing.Point(103, 65)
        Me.TxtPrice.Name = "TxtPrice"
        Me.TxtPrice.Properties.Mask.EditMask = "n2"
        Me.TxtPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtPrice.Properties.Mask.SaveLiteral = False
        Me.TxtPrice.Properties.Mask.ShowPlaceHolders = False
        Me.TxtPrice.Size = New System.Drawing.Size(313, 20)
        Me.TxtPrice.TabIndex = 2
        '
        'FormItemDet
        '
        Me.AcceptButton = Me.BtnSave
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 133)
        Me.Controls.Add(Me.TxtPrice)
        Me.Controls.Add(Me.TxtDesc)
        Me.Controls.Add(Me.TxtCode)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.PanelControlBottom)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.LookAndFeel.SkinName = "Metropolis"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormItemDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product"
        CType(Me.PanelControlBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlBottom.ResumeLayout(False)
        CType(Me.TxtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelControlBottom As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtDesc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtPrice As DevExpress.XtraEditors.TextEdit
End Class
