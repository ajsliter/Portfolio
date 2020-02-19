<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.txtUnitPrice = New System.Windows.Forms.TextBox()
        Me.lblItmID = New System.Windows.Forms.Label()
        Me.lblItmDescr = New System.Windows.Forms.Label()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.lblUnitPrice = New System.Windows.Forms.Label()
        Me.chkFlatPrice = New System.Windows.Forms.CheckBox()
        Me.lblInvValue = New System.Windows.Forms.Label()
        Me.btnCalcTotInvValue = New System.Windows.Forms.Button()
        Me.btnAddItm = New System.Windows.Forms.Button()
        Me.btnBackInv = New System.Windows.Forms.Button()
        Me.btnForwardInv = New System.Windows.Forms.Button()
        Me.btnSaveItm = New System.Windows.Forms.Button()
        Me.btnCnlAddItm = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtID
        '
        Me.txtID.Enabled = False
        Me.txtID.Location = New System.Drawing.Point(90, 27)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(187, 22)
        Me.txtID.TabIndex = 0
        '
        'txtDescription
        '
        Me.txtDescription.Enabled = False
        Me.txtDescription.Location = New System.Drawing.Point(448, 27)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(187, 22)
        Me.txtDescription.TabIndex = 1
        '
        'txtQuantity
        '
        Me.txtQuantity.Enabled = False
        Me.txtQuantity.Location = New System.Drawing.Point(90, 84)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(187, 22)
        Me.txtQuantity.TabIndex = 2
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.Enabled = False
        Me.txtUnitPrice.Location = New System.Drawing.Point(448, 82)
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.Size = New System.Drawing.Size(187, 22)
        Me.txtUnitPrice.TabIndex = 3
        '
        'lblItmID
        '
        Me.lblItmID.AutoSize = True
        Me.lblItmID.Location = New System.Drawing.Point(19, 30)
        Me.lblItmID.Name = "lblItmID"
        Me.lblItmID.Size = New System.Drawing.Size(55, 17)
        Me.lblItmID.TabIndex = 4
        Me.lblItmID.Text = "Item ID:"
        '
        'lblItmDescr
        '
        Me.lblItmDescr.AutoSize = True
        Me.lblItmDescr.Location = New System.Drawing.Point(329, 30)
        Me.lblItmDescr.Name = "lblItmDescr"
        Me.lblItmDescr.Size = New System.Drawing.Size(113, 17)
        Me.lblItmDescr.TabIndex = 5
        Me.lblItmDescr.Text = "Item Description:"
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Location = New System.Drawing.Point(19, 85)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(65, 17)
        Me.lblQuantity.TabIndex = 6
        Me.lblQuantity.Text = "Quantity:"
        '
        'lblUnitPrice
        '
        Me.lblUnitPrice.AutoSize = True
        Me.lblUnitPrice.Location = New System.Drawing.Point(329, 85)
        Me.lblUnitPrice.Name = "lblUnitPrice"
        Me.lblUnitPrice.Size = New System.Drawing.Size(99, 17)
        Me.lblUnitPrice.TabIndex = 7
        Me.lblUnitPrice.Text = "Per Unit Price:"
        '
        'chkFlatPrice
        '
        Me.chkFlatPrice.AutoSize = True
        Me.chkFlatPrice.Enabled = False
        Me.chkFlatPrice.Location = New System.Drawing.Point(332, 135)
        Me.chkFlatPrice.Name = "chkFlatPrice"
        Me.chkFlatPrice.Size = New System.Drawing.Size(246, 21)
        Me.chkFlatPrice.TabIndex = 8
        Me.chkFlatPrice.Text = "Flat Price Regardless of Quantity?"
        Me.chkFlatPrice.UseVisualStyleBackColor = True
        '
        'lblInvValue
        '
        Me.lblInvValue.AutoSize = True
        Me.lblInvValue.Location = New System.Drawing.Point(19, 173)
        Me.lblInvValue.Name = "lblInvValue"
        Me.lblInvValue.Size = New System.Drawing.Size(247, 17)
        Me.lblInvValue.TabIndex = 9
        Me.lblInvValue.Text = "Total Inventory Value of Current Item: "
        '
        'btnCalcTotInvValue
        '
        Me.btnCalcTotInvValue.Location = New System.Drawing.Point(22, 212)
        Me.btnCalcTotInvValue.Name = "btnCalcTotInvValue"
        Me.btnCalcTotInvValue.Size = New System.Drawing.Size(613, 52)
        Me.btnCalcTotInvValue.TabIndex = 10
        Me.btnCalcTotInvValue.Text = "Calculate Total Inventory Item Value"
        Me.btnCalcTotInvValue.UseVisualStyleBackColor = True
        '
        'btnAddItm
        '
        Me.btnAddItm.Location = New System.Drawing.Point(90, 283)
        Me.btnAddItm.Name = "btnAddItm"
        Me.btnAddItm.Size = New System.Drawing.Size(477, 52)
        Me.btnAddItm.TabIndex = 11
        Me.btnAddItm.Text = "Add New Inventory Item"
        Me.btnAddItm.UseVisualStyleBackColor = True
        '
        'btnBackInv
        '
        Me.btnBackInv.Location = New System.Drawing.Point(22, 283)
        Me.btnBackInv.Name = "btnBackInv"
        Me.btnBackInv.Size = New System.Drawing.Size(62, 52)
        Me.btnBackInv.TabIndex = 12
        Me.btnBackInv.Text = "<<"
        Me.btnBackInv.UseVisualStyleBackColor = True
        '
        'btnForwardInv
        '
        Me.btnForwardInv.Location = New System.Drawing.Point(573, 283)
        Me.btnForwardInv.Name = "btnForwardInv"
        Me.btnForwardInv.Size = New System.Drawing.Size(62, 52)
        Me.btnForwardInv.TabIndex = 13
        Me.btnForwardInv.Text = ">>"
        Me.btnForwardInv.UseVisualStyleBackColor = True
        '
        'btnSaveItm
        '
        Me.btnSaveItm.Location = New System.Drawing.Point(90, 356)
        Me.btnSaveItm.Name = "btnSaveItm"
        Me.btnSaveItm.Size = New System.Drawing.Size(176, 52)
        Me.btnSaveItm.TabIndex = 14
        Me.btnSaveItm.Text = "Save Item"
        Me.btnSaveItm.UseVisualStyleBackColor = True
        Me.btnSaveItm.Visible = False
        '
        'btnCnlAddItm
        '
        Me.btnCnlAddItm.Location = New System.Drawing.Point(391, 356)
        Me.btnCnlAddItm.Name = "btnCnlAddItm"
        Me.btnCnlAddItm.Size = New System.Drawing.Size(176, 52)
        Me.btnCnlAddItm.TabIndex = 15
        Me.btnCnlAddItm.Text = "Cancel"
        Me.btnCnlAddItm.UseVisualStyleBackColor = True
        Me.btnCnlAddItm.Visible = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 420)
        Me.Controls.Add(Me.btnCnlAddItm)
        Me.Controls.Add(Me.btnSaveItm)
        Me.Controls.Add(Me.btnForwardInv)
        Me.Controls.Add(Me.btnBackInv)
        Me.Controls.Add(Me.btnAddItm)
        Me.Controls.Add(Me.btnCalcTotInvValue)
        Me.Controls.Add(Me.lblInvValue)
        Me.Controls.Add(Me.chkFlatPrice)
        Me.Controls.Add(Me.lblUnitPrice)
        Me.Controls.Add(Me.lblQuantity)
        Me.Controls.Add(Me.lblItmDescr)
        Me.Controls.Add(Me.lblItmID)
        Me.Controls.Add(Me.txtUnitPrice)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtID)
        Me.Name = "frmMain"
        Me.Text = "Inventory System - Item"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtID As TextBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents txtUnitPrice As TextBox
    Friend WithEvents lblItmID As Label
    Friend WithEvents lblItmDescr As Label
    Friend WithEvents lblQuantity As Label
    Friend WithEvents lblUnitPrice As Label
    Friend WithEvents chkFlatPrice As CheckBox
    Friend WithEvents lblInvValue As Label
    Friend WithEvents btnCalcTotInvValue As Button
    Friend WithEvents btnAddItm As Button
    Friend WithEvents btnBackInv As Button
    Friend WithEvents btnForwardInv As Button
    Friend WithEvents btnSaveItm As Button
    Friend WithEvents btnCnlAddItm As Button
End Class
