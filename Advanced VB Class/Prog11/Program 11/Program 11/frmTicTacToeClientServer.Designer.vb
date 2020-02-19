<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTicTacToeClientServer
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.radM2 = New System.Windows.Forms.RadioButton()
        Me.radM1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.radP2 = New System.Windows.Forms.RadioButton()
        Me.radP1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.txtServerAddress = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.radClient = New System.Windows.Forms.RadioButton()
        Me.radServer = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(13, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 75)
        Me.Button1.TabIndex = 0
        Me.Button1.Tag = "A1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(116, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(84, 75)
        Me.Button2.TabIndex = 1
        Me.Button2.Tag = "A2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(216, 13)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(84, 75)
        Me.Button3.TabIndex = 2
        Me.Button3.Tag = "A3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Enabled = False
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(13, 104)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(84, 75)
        Me.Button4.TabIndex = 3
        Me.Button4.Tag = "B1"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Enabled = False
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(116, 104)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(84, 75)
        Me.Button5.TabIndex = 4
        Me.Button5.Tag = "B2"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Enabled = False
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(216, 104)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(84, 75)
        Me.Button6.TabIndex = 5
        Me.Button6.Tag = "B3"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Enabled = False
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(13, 195)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(84, 75)
        Me.Button7.TabIndex = 6
        Me.Button7.Tag = "C1"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Enabled = False
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(116, 195)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(84, 75)
        Me.Button8.TabIndex = 7
        Me.Button8.Tag = "C2"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Enabled = False
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Location = New System.Drawing.Point(216, 195)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(84, 75)
        Me.Button9.TabIndex = 8
        Me.Button9.Tag = "C3"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(330, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(240, 230)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Game Settings:"
        Me.GroupBox1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 204)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(230, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Set Options Before Starting Server!"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 175)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "---Server Controls---"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.radM2)
        Me.GroupBox3.Controls.Add(Me.radM1)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 81)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(235, 77)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Moves First"
        '
        'radM2
        '
        Me.radM2.AutoSize = True
        Me.radM2.Location = New System.Drawing.Point(115, 21)
        Me.radM2.Name = "radM2"
        Me.radM2.Size = New System.Drawing.Size(106, 21)
        Me.radM2.TabIndex = 3
        Me.radM2.Tag = "MO"
        Me.radM2.Text = "Player 2 (O)"
        Me.radM2.UseVisualStyleBackColor = True
        '
        'radM1
        '
        Me.radM1.AutoSize = True
        Me.radM1.Location = New System.Drawing.Point(7, 21)
        Me.radM1.Name = "radM1"
        Me.radM1.Size = New System.Drawing.Size(104, 21)
        Me.radM1.TabIndex = 2
        Me.radM1.Tag = "MX"
        Me.radM1.Text = "Player 1 (X)"
        Me.radM1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.radP2)
        Me.GroupBox2.Controls.Add(Me.radP1)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 22)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(227, 53)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Player:"
        '
        'radP2
        '
        Me.radP2.AutoSize = True
        Me.radP2.Location = New System.Drawing.Point(115, 22)
        Me.radP2.Name = "radP2"
        Me.radP2.Size = New System.Drawing.Size(106, 21)
        Me.radP2.TabIndex = 1
        Me.radP2.Tag = "PO"
        Me.radP2.Text = "Player 2 (O)"
        Me.radP2.UseVisualStyleBackColor = True
        '
        'radP1
        '
        Me.radP1.AutoSize = True
        Me.radP1.Location = New System.Drawing.Point(7, 22)
        Me.radP1.Name = "radP1"
        Me.radP1.Size = New System.Drawing.Size(104, 21)
        Me.radP1.TabIndex = 0
        Me.radP1.Tag = "PX"
        Me.radP1.Text = "Player 1 (X)"
        Me.radP1.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnStop)
        Me.GroupBox4.Controls.Add(Me.btnStart)
        Me.GroupBox4.Controls.Add(Me.lblAddress)
        Me.GroupBox4.Controls.Add(Me.lblPort)
        Me.GroupBox4.Controls.Add(Me.txtPort)
        Me.GroupBox4.Controls.Add(Me.txtServerAddress)
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Location = New System.Drawing.Point(593, 15)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(289, 254)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Network Configuration:"
        '
        'btnStop
        '
        Me.btnStop.Enabled = False
        Me.btnStop.Location = New System.Drawing.Point(7, 198)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(276, 43)
        Me.btnStop.TabIndex = 6
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(7, 149)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(276, 43)
        Me.btnStart.TabIndex = 5
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Location = New System.Drawing.Point(4, 92)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(110, 17)
        Me.lblAddress.TabIndex = 4
        Me.lblAddress.Text = "Server Address:"
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.Location = New System.Drawing.Point(4, 125)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(153, 17)
        Me.lblPort.TabIndex = 3
        Me.lblPort.Text = "Server Listens on Port:"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(183, 122)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(100, 22)
        Me.txtPort.TabIndex = 2
        Me.txtPort.Text = "1000"
        '
        'txtServerAddress
        '
        Me.txtServerAddress.Location = New System.Drawing.Point(183, 89)
        Me.txtServerAddress.Name = "txtServerAddress"
        Me.txtServerAddress.Size = New System.Drawing.Size(100, 22)
        Me.txtServerAddress.TabIndex = 1
        Me.txtServerAddress.Text = "127.0.0.1"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.radClient)
        Me.GroupBox5.Controls.Add(Me.radServer)
        Me.GroupBox5.Location = New System.Drawing.Point(7, 22)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(276, 59)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Endpoint Type:"
        '
        'radClient
        '
        Me.radClient.AutoSize = True
        Me.radClient.Location = New System.Drawing.Point(206, 21)
        Me.radClient.Name = "radClient"
        Me.radClient.Size = New System.Drawing.Size(64, 21)
        Me.radClient.TabIndex = 1
        Me.radClient.Tag = "TC"
        Me.radClient.Text = "Client"
        Me.radClient.UseVisualStyleBackColor = True
        '
        'radServer
        '
        Me.radServer.AutoSize = True
        Me.radServer.Location = New System.Drawing.Point(6, 21)
        Me.radServer.Name = "radServer"
        Me.radServer.Size = New System.Drawing.Size(71, 21)
        Me.radServer.TabIndex = 0
        Me.radServer.Tag = "TS"
        Me.radServer.Text = "Server"
        Me.radServer.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 277)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 17)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Communication Log:"
        '
        'txtLog
        '
        Me.txtLog.Location = New System.Drawing.Point(15, 298)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(867, 157)
        Me.txtLog.TabIndex = 13
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResult.Location = New System.Drawing.Point(311, 245)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(0, 36)
        Me.lblResult.TabIndex = 14
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape4, Me.LineShape3, Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(892, 467)
        Me.ShapeContainer1.TabIndex = 15
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape4
        '
        Me.LineShape4.BorderWidth = 4
        Me.LineShape4.Name = "LineShape4"
        Me.LineShape4.X1 = 6
        Me.LineShape4.X2 = 225
        Me.LineShape4.Y1 = 152
        Me.LineShape4.Y2 = 152
        '
        'LineShape3
        '
        Me.LineShape3.BorderWidth = 4
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 7
        Me.LineShape3.X2 = 226
        Me.LineShape3.Y1 = 78
        Me.LineShape3.Y2 = 78
        '
        'LineShape2
        '
        Me.LineShape2.BorderWidth = 4
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 154
        Me.LineShape2.X2 = 155
        Me.LineShape2.Y1 = 11
        Me.LineShape2.Y2 = 218
        '
        'LineShape1
        '
        Me.LineShape1.BorderWidth = 4
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 79
        Me.LineShape1.X2 = 80
        Me.LineShape1.Y1 = 13
        Me.LineShape1.Y2 = 216
        '
        'frmTicTacToeClientServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 467)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "frmTicTacToeClientServer"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents radM2 As RadioButton
    Friend WithEvents radM1 As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents radP2 As RadioButton
    Friend WithEvents radP1 As RadioButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents lblPort As Label
    Friend WithEvents txtPort As TextBox
    Friend WithEvents txtServerAddress As TextBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents radClient As RadioButton
    Friend WithEvents radServer As RadioButton
    Friend WithEvents btnStop As Button
    Friend WithEvents btnStart As Button
    Friend WithEvents lblAddress As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtLog As TextBox
    Friend WithEvents lblResult As Label
    Friend WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As PowerPacks.LineShape
    Friend WithEvents LineShape2 As PowerPacks.LineShape
    Friend WithEvents LineShape3 As PowerPacks.LineShape
    Friend WithEvents LineShape4 As PowerPacks.LineShape
End Class
