<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVehicles
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
        Me.grpOwner = New System.Windows.Forms.GroupBox()
        Me.lblID = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtStreet = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.lblAddr = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnForward = New System.Windows.Forms.Button()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.pnlAdd_Upd = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.dgvOwnedVehicles = New System.Windows.Forms.DataGridView()
        Me.pnlNonEdit = New System.Windows.Forms.Panel()
        Me.grpOwner.SuspendLayout()
        Me.pnlAdd_Upd.SuspendLayout()
        CType(Me.dgvOwnedVehicles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNonEdit.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpOwner
        '
        Me.grpOwner.Controls.Add(Me.lblID)
        Me.grpOwner.Controls.Add(Me.txtID)
        Me.grpOwner.Controls.Add(Me.txtState)
        Me.grpOwner.Controls.Add(Me.txtZip)
        Me.grpOwner.Controls.Add(Me.txtCity)
        Me.grpOwner.Controls.Add(Me.txtStreet)
        Me.grpOwner.Controls.Add(Me.txtLastName)
        Me.grpOwner.Controls.Add(Me.lblAddr)
        Me.grpOwner.Controls.Add(Me.txtFirstName)
        Me.grpOwner.Controls.Add(Me.lblName)
        Me.grpOwner.Location = New System.Drawing.Point(13, 8)
        Me.grpOwner.Name = "grpOwner"
        Me.grpOwner.Size = New System.Drawing.Size(725, 119)
        Me.grpOwner.TabIndex = 5
        Me.grpOwner.TabStop = False
        Me.grpOwner.Text = "Owner Information"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(529, 20)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(79, 17)
        Me.lblID.TabIndex = 9
        Me.lblID.Text = "ID Number:"
        '
        'txtID
        '
        Me.txtID.Enabled = False
        Me.txtID.Location = New System.Drawing.Point(614, 17)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(100, 22)
        Me.txtID.TabIndex = 8
        Me.txtID.TabStop = False
        '
        'txtState
        '
        Me.txtState.Enabled = False
        Me.txtState.Location = New System.Drawing.Point(241, 76)
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(49, 22)
        Me.txtState.TabIndex = 4
        '
        'txtZip
        '
        Me.txtZip.Enabled = False
        Me.txtZip.Location = New System.Drawing.Point(296, 76)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(146, 22)
        Me.txtZip.TabIndex = 5
        '
        'txtCity
        '
        Me.txtCity.Enabled = False
        Me.txtCity.Location = New System.Drawing.Point(81, 76)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(154, 22)
        Me.txtCity.TabIndex = 3
        '
        'txtStreet
        '
        Me.txtStreet.Enabled = False
        Me.txtStreet.Location = New System.Drawing.Point(81, 48)
        Me.txtStreet.Name = "txtStreet"
        Me.txtStreet.Size = New System.Drawing.Size(361, 22)
        Me.txtStreet.TabIndex = 2
        '
        'txtLastName
        '
        Me.txtLastName.Enabled = False
        Me.txtLastName.Location = New System.Drawing.Point(269, 20)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(173, 22)
        Me.txtLastName.TabIndex = 1
        '
        'lblAddr
        '
        Me.lblAddr.AutoSize = True
        Me.lblAddr.Location = New System.Drawing.Point(11, 51)
        Me.lblAddr.Name = "lblAddr"
        Me.lblAddr.Size = New System.Drawing.Size(64, 17)
        Me.lblAddr.TabIndex = 2
        Me.lblAddr.Text = "Address:"
        '
        'txtFirstName
        '
        Me.txtFirstName.Enabled = False
        Me.txtFirstName.Location = New System.Drawing.Point(81, 20)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(182, 22)
        Me.txtFirstName.TabIndex = 0
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(26, 23)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(49, 17)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Name:"
        '
        'btnFirst
        '
        Me.btnFirst.Enabled = False
        Me.btnFirst.Location = New System.Drawing.Point(13, 134)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(45, 42)
        Me.btnFirst.TabIndex = 3
        Me.btnFirst.Text = "<||"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Enabled = False
        Me.btnBack.Location = New System.Drawing.Point(64, 134)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(45, 42)
        Me.btnBack.TabIndex = 1
        Me.btnBack.Text = "<<"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnForward
        '
        Me.btnForward.Location = New System.Drawing.Point(631, 133)
        Me.btnForward.Name = "btnForward"
        Me.btnForward.Size = New System.Drawing.Size(45, 42)
        Me.btnForward.TabIndex = 0
        Me.btnForward.Text = ">>"
        Me.btnForward.UseVisualStyleBackColor = True
        '
        'btnLast
        '
        Me.btnLast.Location = New System.Drawing.Point(693, 133)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(45, 42)
        Me.btnLast.TabIndex = 2
        Me.btnLast.Text = "||>"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(3, 3)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 43)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(208, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 43)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(402, 3)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 43)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'pnlAdd_Upd
        '
        Me.pnlAdd_Upd.Controls.Add(Me.btnCancel)
        Me.pnlAdd_Upd.Controls.Add(Me.btnSave)
        Me.pnlAdd_Upd.Location = New System.Drawing.Point(13, 185)
        Me.pnlAdd_Upd.Name = "pnlAdd_Upd"
        Me.pnlAdd_Upd.Size = New System.Drawing.Size(725, 71)
        Me.pnlAdd_Upd.TabIndex = 8
        Me.pnlAdd_Upd.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(519, 14)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 43)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(117, 14)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 43)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'dgvOwnedVehicles
        '
        Me.dgvOwnedVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOwnedVehicles.Location = New System.Drawing.Point(13, 262)
        Me.dgvOwnedVehicles.Name = "dgvOwnedVehicles"
        Me.dgvOwnedVehicles.RowTemplate.Height = 24
        Me.dgvOwnedVehicles.Size = New System.Drawing.Size(725, 173)
        Me.dgvOwnedVehicles.TabIndex = 9
        Me.dgvOwnedVehicles.TabStop = False
        '
        'pnlNonEdit
        '
        Me.pnlNonEdit.Controls.Add(Me.btnAdd)
        Me.pnlNonEdit.Controls.Add(Me.btnDelete)
        Me.pnlNonEdit.Controls.Add(Me.btnUpdate)
        Me.pnlNonEdit.Location = New System.Drawing.Point(130, 133)
        Me.pnlNonEdit.Name = "pnlNonEdit"
        Me.pnlNonEdit.Size = New System.Drawing.Size(480, 52)
        Me.pnlNonEdit.TabIndex = 4
        '
        'frmVehicles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(750, 440)
        Me.Controls.Add(Me.pnlNonEdit)
        Me.Controls.Add(Me.dgvOwnedVehicles)
        Me.Controls.Add(Me.pnlAdd_Upd)
        Me.Controls.Add(Me.btnLast)
        Me.Controls.Add(Me.btnForward)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnFirst)
        Me.Controls.Add(Me.grpOwner)
        Me.Name = "frmVehicles"
        Me.Text = "Vehicles Database"
        Me.grpOwner.ResumeLayout(False)
        Me.grpOwner.PerformLayout()
        Me.pnlAdd_Upd.ResumeLayout(False)
        CType(Me.dgvOwnedVehicles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNonEdit.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpOwner As GroupBox
    Friend WithEvents lblID As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents txtState As TextBox
    Friend WithEvents txtZip As TextBox
    Friend WithEvents txtCity As TextBox
    Friend WithEvents txtStreet As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents lblAddr As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents lblName As Label
    Friend WithEvents btnFirst As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents btnForward As Button
    Friend WithEvents btnLast As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents pnlAdd_Upd As Panel
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents dgvOwnedVehicles As DataGridView
    Friend WithEvents pnlNonEdit As Panel
End Class
