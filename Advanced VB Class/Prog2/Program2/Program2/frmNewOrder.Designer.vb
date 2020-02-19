<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewOrder
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
        Me.lblCustName = New System.Windows.Forms.Label()
        Me.txtCustName = New System.Windows.Forms.TextBox()
        Me.lblCarTyp = New System.Windows.Forms.Label()
        Me.lstBaseCar = New System.Windows.Forms.ListBox()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.nudQuantity = New System.Windows.Forms.NumericUpDown()
        Me.grpDriveTrain = New System.Windows.Forms.GroupBox()
        Me.radElectr = New System.Windows.Forms.RadioButton()
        Me.radHyb = New System.Windows.Forms.RadioButton()
        Me.radV12 = New System.Windows.Forms.RadioButton()
        Me.radV8 = New System.Windows.Forms.RadioButton()
        Me.radV6 = New System.Windows.Forms.RadioButton()
        Me.radV4 = New System.Windows.Forms.RadioButton()
        Me.grpOptions = New System.Windows.Forms.GroupBox()
        Me.chkEntertainment = New System.Windows.Forms.CheckBox()
        Me.chkCD_MP3 = New System.Windows.Forms.CheckBox()
        Me.chkRearDefroster = New System.Windows.Forms.CheckBox()
        Me.chkGPS = New System.Windows.Forms.CheckBox()
        Me.chkPremStereo = New System.Windows.Forms.CheckBox()
        Me.chkHotSeats = New System.Windows.Forms.CheckBox()
        Me.chkBluetooth = New System.Windows.Forms.CheckBox()
        Me.chkAC = New System.Windows.Forms.CheckBox()
        Me.chkLethSeat = New System.Windows.Forms.CheckBox()
        Me.btnPlaceOrder = New System.Windows.Forms.Button()
        CType(Me.nudQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDriveTrain.SuspendLayout()
        Me.grpOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCustName
        '
        Me.lblCustName.AutoSize = True
        Me.lblCustName.Location = New System.Drawing.Point(13, 13)
        Me.lblCustName.Name = "lblCustName"
        Me.lblCustName.Size = New System.Drawing.Size(113, 17)
        Me.lblCustName.TabIndex = 0
        Me.lblCustName.Text = "Customer Name:"
        '
        'txtCustName
        '
        Me.txtCustName.Location = New System.Drawing.Point(132, 13)
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.Size = New System.Drawing.Size(405, 22)
        Me.txtCustName.TabIndex = 1
        '
        'lblCarTyp
        '
        Me.lblCarTyp.AutoSize = True
        Me.lblCarTyp.Location = New System.Drawing.Point(16, 52)
        Me.lblCarTyp.Name = "lblCarTyp"
        Me.lblCarTyp.Size = New System.Drawing.Size(70, 17)
        Me.lblCarTyp.TabIndex = 2
        Me.lblCarTyp.Text = "Car Type:"
        '
        'lstBaseCar
        '
        Me.lstBaseCar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstBaseCar.FormattingEnabled = True
        Me.lstBaseCar.ItemHeight = 18
        Me.lstBaseCar.Items.AddRange(New Object() {"Coupe", "Sedan", "Luxury", "Sports Edition", "SUV"})
        Me.lstBaseCar.Location = New System.Drawing.Point(92, 50)
        Me.lstBaseCar.Name = "lstBaseCar"
        Me.lstBaseCar.Size = New System.Drawing.Size(120, 58)
        Me.lstBaseCar.TabIndex = 3
        '
        'lblQty
        '
        Me.lblQty.AutoSize = True
        Me.lblQty.Location = New System.Drawing.Point(334, 52)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(65, 17)
        Me.lblQty.TabIndex = 4
        Me.lblQty.Text = "Quantity:"
        '
        'nudQuantity
        '
        Me.nudQuantity.Location = New System.Drawing.Point(405, 50)
        Me.nudQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudQuantity.Name = "nudQuantity"
        Me.nudQuantity.Size = New System.Drawing.Size(132, 22)
        Me.nudQuantity.TabIndex = 5
        Me.nudQuantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'grpDriveTrain
        '
        Me.grpDriveTrain.Controls.Add(Me.radElectr)
        Me.grpDriveTrain.Controls.Add(Me.radHyb)
        Me.grpDriveTrain.Controls.Add(Me.radV12)
        Me.grpDriveTrain.Controls.Add(Me.radV8)
        Me.grpDriveTrain.Controls.Add(Me.radV6)
        Me.grpDriveTrain.Controls.Add(Me.radV4)
        Me.grpDriveTrain.Location = New System.Drawing.Point(19, 93)
        Me.grpDriveTrain.Name = "grpDriveTrain"
        Me.grpDriveTrain.Size = New System.Drawing.Size(518, 81)
        Me.grpDriveTrain.TabIndex = 6
        Me.grpDriveTrain.TabStop = False
        Me.grpDriveTrain.Text = "Drive Train"
        '
        'radElectr
        '
        Me.radElectr.AutoSize = True
        Me.radElectr.Location = New System.Drawing.Point(437, 32)
        Me.radElectr.Name = "radElectr"
        Me.radElectr.Size = New System.Drawing.Size(75, 21)
        Me.radElectr.TabIndex = 5
        Me.radElectr.Text = "Electric"
        Me.radElectr.UseVisualStyleBackColor = True
        '
        'radHyb
        '
        Me.radHyb.AutoSize = True
        Me.radHyb.Location = New System.Drawing.Point(335, 32)
        Me.radHyb.Name = "radHyb"
        Me.radHyb.Size = New System.Drawing.Size(70, 21)
        Me.radHyb.TabIndex = 4
        Me.radHyb.Text = "Hybrid"
        Me.radHyb.UseVisualStyleBackColor = True
        '
        'radV12
        '
        Me.radV12.AutoSize = True
        Me.radV12.Location = New System.Drawing.Point(250, 32)
        Me.radV12.Name = "radV12"
        Me.radV12.Size = New System.Drawing.Size(59, 21)
        Me.radV12.TabIndex = 3
        Me.radV12.Text = "V-12"
        Me.radV12.UseVisualStyleBackColor = True
        '
        'radV8
        '
        Me.radV8.AutoSize = True
        Me.radV8.Location = New System.Drawing.Point(163, 32)
        Me.radV8.Name = "radV8"
        Me.radV8.Size = New System.Drawing.Size(51, 21)
        Me.radV8.TabIndex = 2
        Me.radV8.Text = "V-8"
        Me.radV8.UseVisualStyleBackColor = True
        '
        'radV6
        '
        Me.radV6.AutoSize = True
        Me.radV6.Location = New System.Drawing.Point(80, 32)
        Me.radV6.Name = "radV6"
        Me.radV6.Size = New System.Drawing.Size(51, 21)
        Me.radV6.TabIndex = 1
        Me.radV6.Text = "V-6"
        Me.radV6.UseVisualStyleBackColor = True
        '
        'radV4
        '
        Me.radV4.AutoSize = True
        Me.radV4.Checked = True
        Me.radV4.Location = New System.Drawing.Point(6, 32)
        Me.radV4.Name = "radV4"
        Me.radV4.Size = New System.Drawing.Size(51, 21)
        Me.radV4.TabIndex = 0
        Me.radV4.TabStop = True
        Me.radV4.Text = "V-4"
        Me.radV4.UseVisualStyleBackColor = True
        '
        'grpOptions
        '
        Me.grpOptions.Controls.Add(Me.chkEntertainment)
        Me.grpOptions.Controls.Add(Me.chkCD_MP3)
        Me.grpOptions.Controls.Add(Me.chkRearDefroster)
        Me.grpOptions.Controls.Add(Me.chkGPS)
        Me.grpOptions.Controls.Add(Me.chkPremStereo)
        Me.grpOptions.Controls.Add(Me.chkHotSeats)
        Me.grpOptions.Controls.Add(Me.chkBluetooth)
        Me.grpOptions.Controls.Add(Me.chkAC)
        Me.grpOptions.Controls.Add(Me.chkLethSeat)
        Me.grpOptions.Location = New System.Drawing.Point(19, 180)
        Me.grpOptions.Name = "grpOptions"
        Me.grpOptions.Size = New System.Drawing.Size(518, 114)
        Me.grpOptions.TabIndex = 7
        Me.grpOptions.TabStop = False
        Me.grpOptions.Text = "Extra Options ($750 Each)"
        '
        'chkEntertainment
        '
        Me.chkEntertainment.AutoSize = True
        Me.chkEntertainment.Location = New System.Drawing.Point(335, 75)
        Me.chkEntertainment.Name = "chkEntertainment"
        Me.chkEntertainment.Size = New System.Drawing.Size(177, 21)
        Me.chkEntertainment.TabIndex = 8
        Me.chkEntertainment.Text = "Entertainment Package"
        Me.chkEntertainment.UseVisualStyleBackColor = True
        '
        'chkCD_MP3
        '
        Me.chkCD_MP3.AutoSize = True
        Me.chkCD_MP3.Location = New System.Drawing.Point(153, 75)
        Me.chkCD_MP3.Name = "chkCD_MP3"
        Me.chkCD_MP3.Size = New System.Drawing.Size(163, 21)
        Me.chkCD_MP3.TabIndex = 7
        Me.chkCD_MP3.Text = "CD/MP3 Connections"
        Me.chkCD_MP3.UseVisualStyleBackColor = True
        '
        'chkRearDefroster
        '
        Me.chkRearDefroster.AutoSize = True
        Me.chkRearDefroster.Location = New System.Drawing.Point(7, 75)
        Me.chkRearDefroster.Name = "chkRearDefroster"
        Me.chkRearDefroster.Size = New System.Drawing.Size(124, 21)
        Me.chkRearDefroster.TabIndex = 6
        Me.chkRearDefroster.Text = "Rear Defroster"
        Me.chkRearDefroster.UseVisualStyleBackColor = True
        '
        'chkGPS
        '
        Me.chkGPS.AutoSize = True
        Me.chkGPS.Location = New System.Drawing.Point(335, 48)
        Me.chkGPS.Name = "chkGPS"
        Me.chkGPS.Size = New System.Drawing.Size(59, 21)
        Me.chkGPS.TabIndex = 5
        Me.chkGPS.Text = "GPS"
        Me.chkGPS.UseVisualStyleBackColor = True
        '
        'chkPremStereo
        '
        Me.chkPremStereo.AutoSize = True
        Me.chkPremStereo.Location = New System.Drawing.Point(153, 48)
        Me.chkPremStereo.Name = "chkPremStereo"
        Me.chkPremStereo.Size = New System.Drawing.Size(131, 21)
        Me.chkPremStereo.TabIndex = 4
        Me.chkPremStereo.Text = "Premium Stereo"
        Me.chkPremStereo.UseVisualStyleBackColor = True
        '
        'chkHotSeats
        '
        Me.chkHotSeats.AutoSize = True
        Me.chkHotSeats.Location = New System.Drawing.Point(6, 48)
        Me.chkHotSeats.Name = "chkHotSeats"
        Me.chkHotSeats.Size = New System.Drawing.Size(116, 21)
        Me.chkHotSeats.TabIndex = 3
        Me.chkHotSeats.Text = "Heated Seats"
        Me.chkHotSeats.UseVisualStyleBackColor = True
        '
        'chkBluetooth
        '
        Me.chkBluetooth.AutoSize = True
        Me.chkBluetooth.Location = New System.Drawing.Point(335, 21)
        Me.chkBluetooth.Name = "chkBluetooth"
        Me.chkBluetooth.Size = New System.Drawing.Size(90, 21)
        Me.chkBluetooth.TabIndex = 2
        Me.chkBluetooth.Text = "Bluetooth"
        Me.chkBluetooth.UseVisualStyleBackColor = True
        '
        'chkAC
        '
        Me.chkAC.AutoSize = True
        Me.chkAC.Location = New System.Drawing.Point(153, 21)
        Me.chkAC.Name = "chkAC"
        Me.chkAC.Size = New System.Drawing.Size(129, 21)
        Me.chkAC.TabIndex = 1
        Me.chkAC.Text = "Air Conditioning"
        Me.chkAC.UseVisualStyleBackColor = True
        '
        'chkLethSeat
        '
        Me.chkLethSeat.AutoSize = True
        Me.chkLethSeat.Location = New System.Drawing.Point(7, 22)
        Me.chkLethSeat.Name = "chkLethSeat"
        Me.chkLethSeat.Size = New System.Drawing.Size(119, 21)
        Me.chkLethSeat.TabIndex = 0
        Me.chkLethSeat.Text = "Leather Seats"
        Me.chkLethSeat.UseVisualStyleBackColor = True
        '
        'btnPlaceOrder
        '
        Me.btnPlaceOrder.Location = New System.Drawing.Point(16, 301)
        Me.btnPlaceOrder.Name = "btnPlaceOrder"
        Me.btnPlaceOrder.Size = New System.Drawing.Size(521, 54)
        Me.btnPlaceOrder.TabIndex = 8
        Me.btnPlaceOrder.Text = "Place Car(s) Order"
        Me.btnPlaceOrder.UseVisualStyleBackColor = True
        '
        'frmNewOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 367)
        Me.Controls.Add(Me.btnPlaceOrder)
        Me.Controls.Add(Me.grpOptions)
        Me.Controls.Add(Me.grpDriveTrain)
        Me.Controls.Add(Me.nudQuantity)
        Me.Controls.Add(Me.lblQty)
        Me.Controls.Add(Me.lstBaseCar)
        Me.Controls.Add(Me.lblCarTyp)
        Me.Controls.Add(Me.txtCustName)
        Me.Controls.Add(Me.lblCustName)
        Me.Name = "frmNewOrder"
        Me.Text = "Kustom Karz Order Form"
        CType(Me.nudQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDriveTrain.ResumeLayout(False)
        Me.grpDriveTrain.PerformLayout()
        Me.grpOptions.ResumeLayout(False)
        Me.grpOptions.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCustName As Label
    Friend WithEvents txtCustName As TextBox
    Friend WithEvents lblCarTyp As Label
    Friend WithEvents lblQty As Label
    Friend WithEvents nudQuantity As NumericUpDown
    Friend WithEvents grpDriveTrain As GroupBox
    Friend WithEvents radElectr As RadioButton
    Friend WithEvents radHyb As RadioButton
    Friend WithEvents radV12 As RadioButton
    Friend WithEvents radV8 As RadioButton
    Friend WithEvents radV6 As RadioButton
    Friend WithEvents radV4 As RadioButton
    Friend WithEvents grpOptions As GroupBox
    Friend WithEvents chkEntertainment As CheckBox
    Friend WithEvents chkCD_MP3 As CheckBox
    Friend WithEvents chkRearDefroster As CheckBox
    Friend WithEvents chkGPS As CheckBox
    Friend WithEvents chkPremStereo As CheckBox
    Friend WithEvents chkHotSeats As CheckBox
    Friend WithEvents chkBluetooth As CheckBox
    Friend WithEvents chkAC As CheckBox
    Friend WithEvents chkLethSeat As CheckBox
    Friend WithEvents btnPlaceOrder As Button
    Friend WithEvents lstBaseCar As ListBox
End Class
