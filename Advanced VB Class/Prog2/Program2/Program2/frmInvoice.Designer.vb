<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvoice
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
        Me.txtInvoice = New System.Windows.Forms.TextBox()
        Me.btnOrderChng = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtInvoice
        '
        Me.txtInvoice.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoice.Location = New System.Drawing.Point(12, 12)
        Me.txtInvoice.Multiline = True
        Me.txtInvoice.Name = "txtInvoice"
        Me.txtInvoice.ReadOnly = True
        Me.txtInvoice.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtInvoice.Size = New System.Drawing.Size(784, 367)
        Me.txtInvoice.TabIndex = 0
        '
        'btnOrderChng
        '
        Me.btnOrderChng.Location = New System.Drawing.Point(12, 403)
        Me.btnOrderChng.Name = "btnOrderChng"
        Me.btnOrderChng.Size = New System.Drawing.Size(214, 66)
        Me.btnOrderChng.TabIndex = 1
        Me.btnOrderChng.Text = "Change Order"
        Me.btnOrderChng.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(297, 403)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(214, 66)
        Me.btnSubmit.TabIndex = 2
        Me.btnSubmit.Text = "Submit to Manufacturing"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(582, 403)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(214, 66)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 481)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.btnOrderChng)
        Me.Controls.Add(Me.txtInvoice)
        Me.Name = "frmInvoice"
        Me.Text = "Kustom Karz Invoice"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtInvoice As TextBox
    Friend WithEvents btnOrderChng As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnExit As Button
End Class
