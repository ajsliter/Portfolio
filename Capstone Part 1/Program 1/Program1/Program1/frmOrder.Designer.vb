<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrder
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.grpContact = New System.Windows.Forms.GroupBox()
        Me.mtbMidInitial = New System.Windows.Forms.MaskedTextBox()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.lblMiddleInitial = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.mtbPhone = New System.Windows.Forms.MaskedTextBox()
        Me.txtLName = New System.Windows.Forms.TextBox()
        Me.txtFName = New System.Windows.Forms.TextBox()
        Me.grpServiceType = New System.Windows.Forms.GroupBox()
        Me.nudMeals = New System.Windows.Forms.NumericUpDown()
        Me.lblNumMeals = New System.Windows.Forms.Label()
        Me.lblType = New System.Windows.Forms.Label()
        Me.radDeluxe = New System.Windows.Forms.RadioButton()
        Me.radStandard = New System.Windows.Forms.RadioButton()
        Me.chkDiscount = New System.Windows.Forms.CheckBox()
        Me.grpDiscAmt = New System.Windows.Forms.GroupBox()
        Me.lblPercSign = New System.Windows.Forms.Label()
        Me.nudDiscPerc = New System.Windows.Forms.NumericUpDown()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCalc = New System.Windows.Forms.Button()
        Me.txtTotals = New System.Windows.Forms.TextBox()
        Me.grpContact.SuspendLayout()
        Me.grpServiceType.SuspendLayout()
        CType(Me.nudMeals, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDiscAmt.SuspendLayout()
        CType(Me.nudDiscPerc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpContact
        '
        Me.grpContact.Controls.Add(Me.mtbMidInitial)
        Me.grpContact.Controls.Add(Me.lblPhone)
        Me.grpContact.Controls.Add(Me.lblLastName)
        Me.grpContact.Controls.Add(Me.lblMiddleInitial)
        Me.grpContact.Controls.Add(Me.lblFirstName)
        Me.grpContact.Controls.Add(Me.mtbPhone)
        Me.grpContact.Controls.Add(Me.txtLName)
        Me.grpContact.Controls.Add(Me.txtFName)
        Me.grpContact.Location = New System.Drawing.Point(13, 13)
        Me.grpContact.Name = "grpContact"
        Me.grpContact.Size = New System.Drawing.Size(460, 82)
        Me.grpContact.TabIndex = 0
        Me.grpContact.TabStop = False
        Me.grpContact.Text = "Contact Information"
        '
        'mtbMidInitial
        '
        Me.mtbMidInitial.Location = New System.Drawing.Point(143, 48)
        Me.mtbMidInitial.Mask = "L"
        Me.mtbMidInitial.Name = "mtbMidInitial"
        Me.mtbMidInitial.Size = New System.Drawing.Size(34, 22)
        Me.mtbMidInitial.TabIndex = 1
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Location = New System.Drawing.Point(347, 27)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(107, 17)
        Me.lblPhone.TabIndex = 7
        Me.lblPhone.Text = "Phone Number:"
        '
        'lblLastName
        '
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Location = New System.Drawing.Point(209, 27)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(80, 17)
        Me.lblLastName.TabIndex = 6
        Me.lblLastName.Text = "Last Name:"
        '
        'lblMiddleInitial
        '
        Me.lblMiddleInitial.AutoSize = True
        Me.lblMiddleInitial.Location = New System.Drawing.Point(140, 27)
        Me.lblMiddleInitial.Name = "lblMiddleInitial"
        Me.lblMiddleInitial.Size = New System.Drawing.Size(34, 17)
        Me.lblMiddleInitial.TabIndex = 5
        Me.lblMiddleInitial.Text = "M.I.:"
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Location = New System.Drawing.Point(7, 27)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(80, 17)
        Me.lblFirstName.TabIndex = 4
        Me.lblFirstName.Text = "First Name:"
        '
        'mtbPhone
        '
        Me.mtbPhone.Location = New System.Drawing.Point(350, 47)
        Me.mtbPhone.Mask = "(999) 000-0000"
        Me.mtbPhone.Name = "mtbPhone"
        Me.mtbPhone.Size = New System.Drawing.Size(103, 22)
        Me.mtbPhone.TabIndex = 3
        '
        'txtLName
        '
        Me.txtLName.Location = New System.Drawing.Point(212, 47)
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Size = New System.Drawing.Size(100, 22)
        Me.txtLName.TabIndex = 2
        '
        'txtFName
        '
        Me.txtFName.Location = New System.Drawing.Point(7, 47)
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Size = New System.Drawing.Size(100, 22)
        Me.txtFName.TabIndex = 0
        '
        'grpServiceType
        '
        Me.grpServiceType.Controls.Add(Me.nudMeals)
        Me.grpServiceType.Controls.Add(Me.lblNumMeals)
        Me.grpServiceType.Controls.Add(Me.lblType)
        Me.grpServiceType.Controls.Add(Me.radDeluxe)
        Me.grpServiceType.Controls.Add(Me.radStandard)
        Me.grpServiceType.Location = New System.Drawing.Point(13, 102)
        Me.grpServiceType.Name = "grpServiceType"
        Me.grpServiceType.Size = New System.Drawing.Size(314, 98)
        Me.grpServiceType.TabIndex = 1
        Me.grpServiceType.TabStop = False
        Me.grpServiceType.Text = "Catering Service Info"
        '
        'nudMeals
        '
        Me.nudMeals.Location = New System.Drawing.Point(192, 41)
        Me.nudMeals.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudMeals.Name = "nudMeals"
        Me.nudMeals.Size = New System.Drawing.Size(111, 22)
        Me.nudMeals.TabIndex = 2
        Me.nudMeals.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblNumMeals
        '
        Me.lblNumMeals.AutoSize = True
        Me.lblNumMeals.Location = New System.Drawing.Point(189, 21)
        Me.lblNumMeals.Name = "lblNumMeals"
        Me.lblNumMeals.Size = New System.Drawing.Size(119, 17)
        Me.lblNumMeals.TabIndex = 3
        Me.lblNumMeals.Text = "Number of Meals:"
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Location = New System.Drawing.Point(7, 21)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(78, 17)
        Me.lblType.TabIndex = 2
        Me.lblType.Text = "Meal Type:"
        '
        'radDeluxe
        '
        Me.radDeluxe.AutoSize = True
        Me.radDeluxe.Location = New System.Drawing.Point(10, 71)
        Me.radDeluxe.Name = "radDeluxe"
        Me.radDeluxe.Size = New System.Drawing.Size(164, 21)
        Me.radDeluxe.TabIndex = 1
        Me.radDeluxe.Text = "Deluxe Meal ($10.00)"
        Me.radDeluxe.UseVisualStyleBackColor = True
        '
        'radStandard
        '
        Me.radStandard.AutoSize = True
        Me.radStandard.Checked = True
        Me.radStandard.Location = New System.Drawing.Point(10, 44)
        Me.radStandard.Name = "radStandard"
        Me.radStandard.Size = New System.Drawing.Size(171, 21)
        Me.radStandard.TabIndex = 0
        Me.radStandard.TabStop = True
        Me.radStandard.Text = "Standard Meal ($8.50)"
        Me.radStandard.UseVisualStyleBackColor = True
        '
        'chkDiscount
        '
        Me.chkDiscount.AutoSize = True
        Me.chkDiscount.Location = New System.Drawing.Point(333, 102)
        Me.chkDiscount.Name = "chkDiscount"
        Me.chkDiscount.Size = New System.Drawing.Size(120, 21)
        Me.chkDiscount.TabIndex = 2
        Me.chkDiscount.Text = "Discount Y/N?"
        Me.chkDiscount.UseVisualStyleBackColor = True
        '
        'grpDiscAmt
        '
        Me.grpDiscAmt.Controls.Add(Me.lblPercSign)
        Me.grpDiscAmt.Controls.Add(Me.nudDiscPerc)
        Me.grpDiscAmt.Location = New System.Drawing.Point(333, 129)
        Me.grpDiscAmt.Name = "grpDiscAmt"
        Me.grpDiscAmt.Size = New System.Drawing.Size(140, 71)
        Me.grpDiscAmt.TabIndex = 3
        Me.grpDiscAmt.TabStop = False
        Me.grpDiscAmt.Text = "Discount Amount"
        Me.grpDiscAmt.Visible = False
        '
        'lblPercSign
        '
        Me.lblPercSign.AutoSize = True
        Me.lblPercSign.Location = New System.Drawing.Point(99, 34)
        Me.lblPercSign.Name = "lblPercSign"
        Me.lblPercSign.Size = New System.Drawing.Size(20, 17)
        Me.lblPercSign.TabIndex = 1
        Me.lblPercSign.Text = "%"
        '
        'nudDiscPerc
        '
        Me.nudDiscPerc.Location = New System.Drawing.Point(6, 32)
        Me.nudDiscPerc.Name = "nudDiscPerc"
        Me.nudDiscPerc.Size = New System.Drawing.Size(87, 22)
        Me.nudDiscPerc.TabIndex = 0
        '
        'btnClear
        '
        Me.btnClear.Enabled = False
        Me.btnClear.Location = New System.Drawing.Point(13, 207)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(107, 34)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear Order"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnCalc
        '
        Me.btnCalc.Location = New System.Drawing.Point(347, 206)
        Me.btnCalc.Name = "btnCalc"
        Me.btnCalc.Size = New System.Drawing.Size(126, 34)
        Me.btnCalc.TabIndex = 5
        Me.btnCalc.Text = "Calculate Totals"
        Me.btnCalc.UseVisualStyleBackColor = True
        '
        'txtTotals
        '
        Me.txtTotals.Location = New System.Drawing.Point(12, 248)
        Me.txtTotals.Multiline = True
        Me.txtTotals.Name = "txtTotals"
        Me.txtTotals.ReadOnly = True
        Me.txtTotals.Size = New System.Drawing.Size(461, 91)
        Me.txtTotals.TabIndex = 7
        '
        'frmOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 351)
        Me.Controls.Add(Me.txtTotals)
        Me.Controls.Add(Me.btnCalc)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.grpDiscAmt)
        Me.Controls.Add(Me.chkDiscount)
        Me.Controls.Add(Me.grpServiceType)
        Me.Controls.Add(Me.grpContact)
        Me.Name = "frmOrder"
        Me.Text = "Order "
        Me.grpContact.ResumeLayout(False)
        Me.grpContact.PerformLayout()
        Me.grpServiceType.ResumeLayout(False)
        Me.grpServiceType.PerformLayout()
        CType(Me.nudMeals, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDiscAmt.ResumeLayout(False)
        Me.grpDiscAmt.PerformLayout()
        CType(Me.nudDiscPerc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grpContact As GroupBox
    Friend WithEvents lblPhone As Label
    Friend WithEvents lblLastName As Label
    Friend WithEvents lblMiddleInitial As Label
    Friend WithEvents lblFirstName As Label
    Friend WithEvents mtbPhone As MaskedTextBox
    Friend WithEvents txtLName As TextBox
    Friend WithEvents txtFName As TextBox
    Friend WithEvents mtbMidInitial As MaskedTextBox
    Friend WithEvents grpServiceType As GroupBox
    Friend WithEvents nudMeals As NumericUpDown
    Friend WithEvents lblNumMeals As Label
    Friend WithEvents lblType As Label
    Friend WithEvents radDeluxe As RadioButton
    Friend WithEvents radStandard As RadioButton
    Friend WithEvents chkDiscount As CheckBox
    Friend WithEvents grpDiscAmt As GroupBox
    Friend WithEvents nudDiscPerc As NumericUpDown
    Friend WithEvents lblPercSign As Label
    Friend WithEvents btnClear As Button
    Friend WithEvents btnCalc As Button
    Friend WithEvents txtTotals As TextBox
End Class
