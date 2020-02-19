<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalculator
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
        Me.txtBin1 = New System.Windows.Forms.TextBox()
        Me.txtDec1 = New System.Windows.Forms.TextBox()
        Me.txtHex1 = New System.Windows.Forms.TextBox()
        Me.txtHex2 = New System.Windows.Forms.TextBox()
        Me.txtDec2 = New System.Windows.Forms.TextBox()
        Me.txtBin2 = New System.Windows.Forms.TextBox()
        Me.txtResHex = New System.Windows.Forms.TextBox()
        Me.txtResDec = New System.Windows.Forms.TextBox()
        Me.txtResBin = New System.Windows.Forms.TextBox()
        Me.btnNum1 = New System.Windows.Forms.Button()
        Me.btnNum2 = New System.Windows.Forms.Button()
        Me.btnNum3 = New System.Windows.Forms.Button()
        Me.btnNum4 = New System.Windows.Forms.Button()
        Me.btnNum5 = New System.Windows.Forms.Button()
        Me.btnNum6 = New System.Windows.Forms.Button()
        Me.btnNum7 = New System.Windows.Forms.Button()
        Me.btnNum8 = New System.Windows.Forms.Button()
        Me.btnNum9 = New System.Windows.Forms.Button()
        Me.btnNum0 = New System.Windows.Forms.Button()
        Me.btnA = New System.Windows.Forms.Button()
        Me.btnF = New System.Windows.Forms.Button()
        Me.btnE = New System.Windows.Forms.Button()
        Me.btnD = New System.Windows.Forms.Button()
        Me.btnC = New System.Windows.Forms.Button()
        Me.btnB = New System.Windows.Forms.Button()
        Me.btnConvert = New System.Windows.Forms.Button()
        Me.btnClrVal1 = New System.Windows.Forms.Button()
        Me.btnClrVal2 = New System.Windows.Forms.Button()
        Me.btnClrRes = New System.Windows.Forms.Button()
        Me.btnAnd = New System.Windows.Forms.Button()
        Me.btnOr = New System.Windows.Forms.Button()
        Me.btnXor = New System.Windows.Forms.Button()
        Me.btnNotVal1 = New System.Windows.Forms.Button()
        Me.grpInputConv = New System.Windows.Forms.GroupBox()
        Me.grpClr = New System.Windows.Forms.GroupBox()
        Me.grpOps = New System.Windows.Forms.GroupBox()
        Me.grpVal1 = New System.Windows.Forms.GroupBox()
        Me.grpVal2 = New System.Windows.Forms.GroupBox()
        Me.grpRes = New System.Windows.Forms.GroupBox()
        Me.grpInputConv.SuspendLayout()
        Me.grpClr.SuspendLayout()
        Me.grpOps.SuspendLayout()
        Me.grpVal1.SuspendLayout()
        Me.grpVal2.SuspendLayout()
        Me.grpRes.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBin1
        '
        Me.txtBin1.Location = New System.Drawing.Point(6, 35)
        Me.txtBin1.Name = "txtBin1"
        Me.txtBin1.ReadOnly = True
        Me.txtBin1.Size = New System.Drawing.Size(292, 22)
        Me.txtBin1.TabIndex = 0
        '
        'txtDec1
        '
        Me.txtDec1.Location = New System.Drawing.Point(6, 91)
        Me.txtDec1.Name = "txtDec1"
        Me.txtDec1.ReadOnly = True
        Me.txtDec1.Size = New System.Drawing.Size(292, 22)
        Me.txtDec1.TabIndex = 1
        '
        'txtHex1
        '
        Me.txtHex1.Location = New System.Drawing.Point(5, 147)
        Me.txtHex1.Name = "txtHex1"
        Me.txtHex1.ReadOnly = True
        Me.txtHex1.Size = New System.Drawing.Size(293, 22)
        Me.txtHex1.TabIndex = 2
        '
        'txtHex2
        '
        Me.txtHex2.Location = New System.Drawing.Point(6, 147)
        Me.txtHex2.Name = "txtHex2"
        Me.txtHex2.ReadOnly = True
        Me.txtHex2.Size = New System.Drawing.Size(295, 22)
        Me.txtHex2.TabIndex = 5
        '
        'txtDec2
        '
        Me.txtDec2.Location = New System.Drawing.Point(6, 91)
        Me.txtDec2.Name = "txtDec2"
        Me.txtDec2.ReadOnly = True
        Me.txtDec2.Size = New System.Drawing.Size(295, 22)
        Me.txtDec2.TabIndex = 4
        '
        'txtBin2
        '
        Me.txtBin2.Location = New System.Drawing.Point(6, 35)
        Me.txtBin2.Name = "txtBin2"
        Me.txtBin2.ReadOnly = True
        Me.txtBin2.Size = New System.Drawing.Size(295, 22)
        Me.txtBin2.TabIndex = 3
        '
        'txtResHex
        '
        Me.txtResHex.Location = New System.Drawing.Point(6, 147)
        Me.txtResHex.Name = "txtResHex"
        Me.txtResHex.ReadOnly = True
        Me.txtResHex.Size = New System.Drawing.Size(293, 22)
        Me.txtResHex.TabIndex = 8
        Me.txtResHex.Text = "0"
        '
        'txtResDec
        '
        Me.txtResDec.Location = New System.Drawing.Point(6, 91)
        Me.txtResDec.Name = "txtResDec"
        Me.txtResDec.ReadOnly = True
        Me.txtResDec.Size = New System.Drawing.Size(293, 22)
        Me.txtResDec.TabIndex = 7
        Me.txtResDec.Text = "0"
        '
        'txtResBin
        '
        Me.txtResBin.Location = New System.Drawing.Point(6, 35)
        Me.txtResBin.Name = "txtResBin"
        Me.txtResBin.ReadOnly = True
        Me.txtResBin.Size = New System.Drawing.Size(293, 22)
        Me.txtResBin.TabIndex = 6
        Me.txtResBin.Text = "0"
        '
        'btnNum1
        '
        Me.btnNum1.Enabled = False
        Me.btnNum1.Location = New System.Drawing.Point(65, 167)
        Me.btnNum1.Name = "btnNum1"
        Me.btnNum1.Size = New System.Drawing.Size(43, 40)
        Me.btnNum1.TabIndex = 9
        Me.btnNum1.Text = "&1"
        Me.btnNum1.UseVisualStyleBackColor = True
        '
        'btnNum2
        '
        Me.btnNum2.Enabled = False
        Me.btnNum2.Location = New System.Drawing.Point(16, 121)
        Me.btnNum2.Name = "btnNum2"
        Me.btnNum2.Size = New System.Drawing.Size(43, 40)
        Me.btnNum2.TabIndex = 10
        Me.btnNum2.Text = "&2"
        Me.btnNum2.UseVisualStyleBackColor = True
        '
        'btnNum3
        '
        Me.btnNum3.Enabled = False
        Me.btnNum3.Location = New System.Drawing.Point(65, 121)
        Me.btnNum3.Name = "btnNum3"
        Me.btnNum3.Size = New System.Drawing.Size(43, 40)
        Me.btnNum3.TabIndex = 11
        Me.btnNum3.Text = "&3"
        Me.btnNum3.UseVisualStyleBackColor = True
        '
        'btnNum4
        '
        Me.btnNum4.Enabled = False
        Me.btnNum4.Location = New System.Drawing.Point(114, 121)
        Me.btnNum4.Name = "btnNum4"
        Me.btnNum4.Size = New System.Drawing.Size(43, 40)
        Me.btnNum4.TabIndex = 12
        Me.btnNum4.Text = "&4"
        Me.btnNum4.UseVisualStyleBackColor = True
        '
        'btnNum5
        '
        Me.btnNum5.Enabled = False
        Me.btnNum5.Location = New System.Drawing.Point(163, 121)
        Me.btnNum5.Name = "btnNum5"
        Me.btnNum5.Size = New System.Drawing.Size(43, 40)
        Me.btnNum5.TabIndex = 13
        Me.btnNum5.Text = "&5"
        Me.btnNum5.UseVisualStyleBackColor = True
        '
        'btnNum6
        '
        Me.btnNum6.Enabled = False
        Me.btnNum6.Location = New System.Drawing.Point(16, 75)
        Me.btnNum6.Name = "btnNum6"
        Me.btnNum6.Size = New System.Drawing.Size(43, 40)
        Me.btnNum6.TabIndex = 14
        Me.btnNum6.Text = "&6"
        Me.btnNum6.UseVisualStyleBackColor = True
        '
        'btnNum7
        '
        Me.btnNum7.Enabled = False
        Me.btnNum7.Location = New System.Drawing.Point(65, 75)
        Me.btnNum7.Name = "btnNum7"
        Me.btnNum7.Size = New System.Drawing.Size(43, 40)
        Me.btnNum7.TabIndex = 15
        Me.btnNum7.Text = "&7"
        Me.btnNum7.UseVisualStyleBackColor = True
        '
        'btnNum8
        '
        Me.btnNum8.Enabled = False
        Me.btnNum8.Location = New System.Drawing.Point(114, 75)
        Me.btnNum8.Name = "btnNum8"
        Me.btnNum8.Size = New System.Drawing.Size(43, 40)
        Me.btnNum8.TabIndex = 16
        Me.btnNum8.Text = "&8"
        Me.btnNum8.UseVisualStyleBackColor = True
        '
        'btnNum9
        '
        Me.btnNum9.Enabled = False
        Me.btnNum9.Location = New System.Drawing.Point(163, 75)
        Me.btnNum9.Name = "btnNum9"
        Me.btnNum9.Size = New System.Drawing.Size(43, 40)
        Me.btnNum9.TabIndex = 17
        Me.btnNum9.Text = "&9"
        Me.btnNum9.UseVisualStyleBackColor = True
        '
        'btnNum0
        '
        Me.btnNum0.Enabled = False
        Me.btnNum0.Location = New System.Drawing.Point(16, 167)
        Me.btnNum0.Name = "btnNum0"
        Me.btnNum0.Size = New System.Drawing.Size(43, 40)
        Me.btnNum0.TabIndex = 18
        Me.btnNum0.Text = "&0"
        Me.btnNum0.UseVisualStyleBackColor = True
        '
        'btnA
        '
        Me.btnA.Enabled = False
        Me.btnA.Location = New System.Drawing.Point(16, 29)
        Me.btnA.Name = "btnA"
        Me.btnA.Size = New System.Drawing.Size(43, 40)
        Me.btnA.TabIndex = 19
        Me.btnA.Text = "&A"
        Me.btnA.UseVisualStyleBackColor = True
        '
        'btnF
        '
        Me.btnF.Enabled = False
        Me.btnF.Location = New System.Drawing.Point(261, 29)
        Me.btnF.Name = "btnF"
        Me.btnF.Size = New System.Drawing.Size(43, 40)
        Me.btnF.TabIndex = 20
        Me.btnF.Text = "&F"
        Me.btnF.UseVisualStyleBackColor = True
        '
        'btnE
        '
        Me.btnE.Enabled = False
        Me.btnE.Location = New System.Drawing.Point(212, 29)
        Me.btnE.Name = "btnE"
        Me.btnE.Size = New System.Drawing.Size(43, 40)
        Me.btnE.TabIndex = 21
        Me.btnE.Text = "&E"
        Me.btnE.UseVisualStyleBackColor = True
        '
        'btnD
        '
        Me.btnD.Enabled = False
        Me.btnD.Location = New System.Drawing.Point(163, 29)
        Me.btnD.Name = "btnD"
        Me.btnD.Size = New System.Drawing.Size(43, 40)
        Me.btnD.TabIndex = 22
        Me.btnD.Text = "&D"
        Me.btnD.UseVisualStyleBackColor = True
        '
        'btnC
        '
        Me.btnC.Enabled = False
        Me.btnC.Location = New System.Drawing.Point(114, 29)
        Me.btnC.Name = "btnC"
        Me.btnC.Size = New System.Drawing.Size(43, 40)
        Me.btnC.TabIndex = 23
        Me.btnC.Text = "&C"
        Me.btnC.UseVisualStyleBackColor = True
        '
        'btnB
        '
        Me.btnB.Enabled = False
        Me.btnB.Location = New System.Drawing.Point(65, 29)
        Me.btnB.Name = "btnB"
        Me.btnB.Size = New System.Drawing.Size(43, 40)
        Me.btnB.TabIndex = 24
        Me.btnB.Text = "&B"
        Me.btnB.UseVisualStyleBackColor = True
        '
        'btnConvert
        '
        Me.btnConvert.Enabled = False
        Me.btnConvert.Location = New System.Drawing.Point(212, 76)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(92, 131)
        Me.btnConvert.TabIndex = 25
        Me.btnConvert.Text = "Convert"
        Me.btnConvert.UseVisualStyleBackColor = True
        '
        'btnClrVal1
        '
        Me.btnClrVal1.Enabled = False
        Me.btnClrVal1.Location = New System.Drawing.Point(6, 21)
        Me.btnClrVal1.Name = "btnClrVal1"
        Me.btnClrVal1.Size = New System.Drawing.Size(209, 40)
        Me.btnClrVal1.TabIndex = 26
        Me.btnClrVal1.Text = "Clear Value 1"
        Me.btnClrVal1.UseVisualStyleBackColor = True
        '
        'btnClrVal2
        '
        Me.btnClrVal2.Enabled = False
        Me.btnClrVal2.Location = New System.Drawing.Point(6, 90)
        Me.btnClrVal2.Name = "btnClrVal2"
        Me.btnClrVal2.Size = New System.Drawing.Size(209, 40)
        Me.btnClrVal2.TabIndex = 27
        Me.btnClrVal2.Text = "Clear Value 2"
        Me.btnClrVal2.UseVisualStyleBackColor = True
        '
        'btnClrRes
        '
        Me.btnClrRes.Enabled = False
        Me.btnClrRes.Location = New System.Drawing.Point(6, 165)
        Me.btnClrRes.Name = "btnClrRes"
        Me.btnClrRes.Size = New System.Drawing.Size(209, 40)
        Me.btnClrRes.TabIndex = 28
        Me.btnClrRes.Text = "Clear Result"
        Me.btnClrRes.UseVisualStyleBackColor = True
        '
        'btnAnd
        '
        Me.btnAnd.Enabled = False
        Me.btnAnd.Location = New System.Drawing.Point(6, 21)
        Me.btnAnd.Name = "btnAnd"
        Me.btnAnd.Size = New System.Drawing.Size(209, 40)
        Me.btnAnd.TabIndex = 29
        Me.btnAnd.Text = "And"
        Me.btnAnd.UseVisualStyleBackColor = True
        '
        'btnOr
        '
        Me.btnOr.Enabled = False
        Me.btnOr.Location = New System.Drawing.Point(6, 69)
        Me.btnOr.Name = "btnOr"
        Me.btnOr.Size = New System.Drawing.Size(209, 40)
        Me.btnOr.TabIndex = 30
        Me.btnOr.Text = "Or"
        Me.btnOr.UseVisualStyleBackColor = True
        '
        'btnXor
        '
        Me.btnXor.Enabled = False
        Me.btnXor.Location = New System.Drawing.Point(6, 116)
        Me.btnXor.Name = "btnXor"
        Me.btnXor.Size = New System.Drawing.Size(209, 40)
        Me.btnXor.TabIndex = 31
        Me.btnXor.Text = "Xor"
        Me.btnXor.UseVisualStyleBackColor = True
        '
        'btnNotVal1
        '
        Me.btnNotVal1.Enabled = False
        Me.btnNotVal1.Location = New System.Drawing.Point(6, 165)
        Me.btnNotVal1.Name = "btnNotVal1"
        Me.btnNotVal1.Size = New System.Drawing.Size(209, 40)
        Me.btnNotVal1.TabIndex = 32
        Me.btnNotVal1.Text = "Not (Value 1)"
        Me.btnNotVal1.UseVisualStyleBackColor = True
        '
        'grpInputConv
        '
        Me.grpInputConv.Controls.Add(Me.btnA)
        Me.grpInputConv.Controls.Add(Me.btnNum1)
        Me.grpInputConv.Controls.Add(Me.btnNum2)
        Me.grpInputConv.Controls.Add(Me.btnNum3)
        Me.grpInputConv.Controls.Add(Me.btnNum4)
        Me.grpInputConv.Controls.Add(Me.btnNum5)
        Me.grpInputConv.Controls.Add(Me.btnNum6)
        Me.grpInputConv.Controls.Add(Me.btnNum7)
        Me.grpInputConv.Controls.Add(Me.btnConvert)
        Me.grpInputConv.Controls.Add(Me.btnNum8)
        Me.grpInputConv.Controls.Add(Me.btnB)
        Me.grpInputConv.Controls.Add(Me.btnNum9)
        Me.grpInputConv.Controls.Add(Me.btnC)
        Me.grpInputConv.Controls.Add(Me.btnNum0)
        Me.grpInputConv.Controls.Add(Me.btnD)
        Me.grpInputConv.Controls.Add(Me.btnF)
        Me.grpInputConv.Controls.Add(Me.btnE)
        Me.grpInputConv.Location = New System.Drawing.Point(12, 213)
        Me.grpInputConv.Name = "grpInputConv"
        Me.grpInputConv.Size = New System.Drawing.Size(312, 212)
        Me.grpInputConv.TabIndex = 33
        Me.grpInputConv.TabStop = False
        Me.grpInputConv.Text = "Input and Conversion"
        '
        'grpClr
        '
        Me.grpClr.Controls.Add(Me.btnClrVal1)
        Me.grpClr.Controls.Add(Me.btnClrVal2)
        Me.grpClr.Controls.Add(Me.btnClrRes)
        Me.grpClr.Location = New System.Drawing.Point(438, 213)
        Me.grpClr.Name = "grpClr"
        Me.grpClr.Size = New System.Drawing.Size(221, 212)
        Me.grpClr.TabIndex = 34
        Me.grpClr.TabStop = False
        Me.grpClr.Text = "Clear"
        '
        'grpOps
        '
        Me.grpOps.Controls.Add(Me.btnAnd)
        Me.grpOps.Controls.Add(Me.btnOr)
        Me.grpOps.Controls.Add(Me.btnXor)
        Me.grpOps.Controls.Add(Me.btnNotVal1)
        Me.grpOps.Location = New System.Drawing.Point(780, 213)
        Me.grpOps.Name = "grpOps"
        Me.grpOps.Size = New System.Drawing.Size(222, 212)
        Me.grpOps.TabIndex = 35
        Me.grpOps.TabStop = False
        Me.grpOps.Text = "Logical Operations"
        '
        'grpVal1
        '
        Me.grpVal1.Controls.Add(Me.txtBin1)
        Me.grpVal1.Controls.Add(Me.txtDec1)
        Me.grpVal1.Controls.Add(Me.txtHex1)
        Me.grpVal1.Location = New System.Drawing.Point(12, 12)
        Me.grpVal1.Name = "grpVal1"
        Me.grpVal1.Size = New System.Drawing.Size(304, 183)
        Me.grpVal1.TabIndex = 36
        Me.grpVal1.TabStop = False
        Me.grpVal1.Text = "Value 1"
        '
        'grpVal2
        '
        Me.grpVal2.Controls.Add(Me.txtBin2)
        Me.grpVal2.Controls.Add(Me.txtDec2)
        Me.grpVal2.Controls.Add(Me.txtHex2)
        Me.grpVal2.Location = New System.Drawing.Point(352, 12)
        Me.grpVal2.Name = "grpVal2"
        Me.grpVal2.Size = New System.Drawing.Size(307, 183)
        Me.grpVal2.TabIndex = 37
        Me.grpVal2.TabStop = False
        Me.grpVal2.Text = "Value 2"
        '
        'grpRes
        '
        Me.grpRes.Controls.Add(Me.txtResBin)
        Me.grpRes.Controls.Add(Me.txtResDec)
        Me.grpRes.Controls.Add(Me.txtResHex)
        Me.grpRes.Location = New System.Drawing.Point(697, 12)
        Me.grpRes.Name = "grpRes"
        Me.grpRes.Size = New System.Drawing.Size(305, 183)
        Me.grpRes.TabIndex = 38
        Me.grpRes.TabStop = False
        Me.grpRes.Text = "Result"
        '
        'frmCalculator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 431)
        Me.Controls.Add(Me.grpRes)
        Me.Controls.Add(Me.grpVal2)
        Me.Controls.Add(Me.grpVal1)
        Me.Controls.Add(Me.grpOps)
        Me.Controls.Add(Me.grpClr)
        Me.Controls.Add(Me.grpInputConv)
        Me.Name = "frmCalculator"
        Me.Text = "Calculator"
        Me.grpInputConv.ResumeLayout(False)
        Me.grpClr.ResumeLayout(False)
        Me.grpOps.ResumeLayout(False)
        Me.grpVal1.ResumeLayout(False)
        Me.grpVal1.PerformLayout()
        Me.grpVal2.ResumeLayout(False)
        Me.grpVal2.PerformLayout()
        Me.grpRes.ResumeLayout(False)
        Me.grpRes.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtBin1 As TextBox
    Friend WithEvents txtDec1 As TextBox
    Friend WithEvents txtHex1 As TextBox
    Friend WithEvents txtHex2 As TextBox
    Friend WithEvents txtDec2 As TextBox
    Friend WithEvents txtBin2 As TextBox
    Friend WithEvents txtResHex As TextBox
    Friend WithEvents txtResDec As TextBox
    Friend WithEvents txtResBin As TextBox
    Friend WithEvents btnNum1 As Button
    Friend WithEvents btnNum2 As Button
    Friend WithEvents btnNum3 As Button
    Friend WithEvents btnNum4 As Button
    Friend WithEvents btnNum5 As Button
    Friend WithEvents btnNum6 As Button
    Friend WithEvents btnNum7 As Button
    Friend WithEvents btnNum8 As Button
    Friend WithEvents btnNum9 As Button
    Friend WithEvents btnNum0 As Button
    Friend WithEvents btnA As Button
    Friend WithEvents btnF As Button
    Friend WithEvents btnE As Button
    Friend WithEvents btnD As Button
    Friend WithEvents btnC As Button
    Friend WithEvents btnB As Button
    Friend WithEvents btnConvert As Button
    Friend WithEvents btnClrVal1 As Button
    Friend WithEvents btnClrVal2 As Button
    Friend WithEvents btnClrRes As Button
    Friend WithEvents btnAnd As Button
    Friend WithEvents btnOr As Button
    Friend WithEvents btnXor As Button
    Friend WithEvents btnNotVal1 As Button
    Friend WithEvents grpInputConv As GroupBox
    Friend WithEvents grpClr As GroupBox
    Friend WithEvents grpOps As GroupBox
    Friend WithEvents grpVal1 As GroupBox
    Friend WithEvents grpVal2 As GroupBox
    Friend WithEvents grpRes As GroupBox
End Class
