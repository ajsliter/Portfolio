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
        Me.btnReset = New System.Windows.Forms.Button()
        Me.grpInventory = New System.Windows.Forms.GroupBox()
        Me.dgvInventory = New System.Windows.Forms.DataGridView()
        Me.grpOrderStatus = New System.Windows.Forms.GroupBox()
        Me.dgvAsssignedWork = New System.Windows.Forms.DataGridView()
        Me.btnLoadFromFile = New System.Windows.Forms.Button()
        Me.txtOrdNum = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboItem = New System.Windows.Forms.ComboBox()
        Me.nudQty = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboCustID = New System.Windows.Forms.ComboBox()
        Me.btnOrdSubmit = New System.Windows.Forms.Button()
        Me.lstItems = New System.Windows.Forms.ListBox()
        Me.lstQtys = New System.Windows.Forms.ListBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnClearItems = New System.Windows.Forms.Button()
        Me.ofdOrdersFromFile = New System.Windows.Forms.OpenFileDialog()
        Me.lstvwReport = New System.Windows.Forms.ListView()
        Me.chOrdNum = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chProdName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chProdQty = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chAssignedTo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chStartTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chEndTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grpInventory.SuspendLayout()
        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpOrderStatus.SuspendLayout()
        CType(Me.dgvAsssignedWork, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudQty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(7, 58)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(125, 30)
        Me.btnReset.TabIndex = 1
        Me.btnReset.Text = "Reset Database"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'grpInventory
        '
        Me.grpInventory.Controls.Add(Me.dgvInventory)
        Me.grpInventory.Location = New System.Drawing.Point(12, 13)
        Me.grpInventory.Name = "grpInventory"
        Me.grpInventory.Size = New System.Drawing.Size(343, 339)
        Me.grpInventory.TabIndex = 4
        Me.grpInventory.TabStop = False
        Me.grpInventory.Text = "Inventory Status"
        '
        'dgvInventory
        '
        Me.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventory.Location = New System.Drawing.Point(6, 50)
        Me.dgvInventory.Name = "dgvInventory"
        Me.dgvInventory.ReadOnly = True
        Me.dgvInventory.RowTemplate.Height = 24
        Me.dgvInventory.Size = New System.Drawing.Size(324, 236)
        Me.dgvInventory.TabIndex = 0
        Me.dgvInventory.TabStop = False
        '
        'grpOrderStatus
        '
        Me.grpOrderStatus.Controls.Add(Me.dgvAsssignedWork)
        Me.grpOrderStatus.Location = New System.Drawing.Point(12, 358)
        Me.grpOrderStatus.Name = "grpOrderStatus"
        Me.grpOrderStatus.Size = New System.Drawing.Size(688, 211)
        Me.grpOrderStatus.TabIndex = 5
        Me.grpOrderStatus.TabStop = False
        Me.grpOrderStatus.Text = "Assembly Area Dispatches"
        '
        'dgvAsssignedWork
        '
        Me.dgvAsssignedWork.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAsssignedWork.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.dgvAsssignedWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAsssignedWork.Location = New System.Drawing.Point(12, 21)
        Me.dgvAsssignedWork.Name = "dgvAsssignedWork"
        Me.dgvAsssignedWork.ReadOnly = True
        Me.dgvAsssignedWork.RowHeadersVisible = False
        Me.dgvAsssignedWork.RowTemplate.Height = 24
        Me.dgvAsssignedWork.Size = New System.Drawing.Size(670, 184)
        Me.dgvAsssignedWork.TabIndex = 0
        Me.dgvAsssignedWork.TabStop = False
        '
        'btnLoadFromFile
        '
        Me.btnLoadFromFile.Location = New System.Drawing.Point(361, 295)
        Me.btnLoadFromFile.Name = "btnLoadFromFile"
        Me.btnLoadFromFile.Size = New System.Drawing.Size(192, 50)
        Me.btnLoadFromFile.TabIndex = 2
        Me.btnLoadFromFile.Text = "Load Orders from File"
        Me.btnLoadFromFile.UseVisualStyleBackColor = True
        '
        'txtOrdNum
        '
        Me.txtOrdNum.Location = New System.Drawing.Point(226, 35)
        Me.txtOrdNum.Name = "txtOrdNum"
        Me.txtOrdNum.ReadOnly = True
        Me.txtOrdNum.Size = New System.Drawing.Size(104, 22)
        Me.txtOrdNum.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Customer ID:"
        '
        'cboItem
        '
        Me.cboItem.FormattingEnabled = True
        Me.cboItem.Location = New System.Drawing.Point(9, 80)
        Me.cboItem.Name = "cboItem"
        Me.cboItem.Size = New System.Drawing.Size(109, 24)
        Me.cboItem.TabIndex = 2
        '
        'nudQty
        '
        Me.nudQty.Location = New System.Drawing.Point(226, 80)
        Me.nudQty.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.nudQty.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudQty.Name = "nudQty"
        Me.nudQty.Size = New System.Drawing.Size(104, 22)
        Me.nudQty.TabIndex = 3
        Me.nudQty.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(223, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Order Number:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Item Type"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(223, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Qty:"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(6, 110)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(109, 38)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Add To Order"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(7, 94)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(127, 33)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnReset)
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.btnReport)
        Me.GroupBox1.Location = New System.Drawing.Point(559, 218)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(141, 134)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "System Controls"
        '
        'btnReport
        '
        Me.btnReport.Location = New System.Drawing.Point(7, 22)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(127, 30)
        Me.btnReport.TabIndex = 0
        Me.btnReport.Text = "Generate Report"
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboCustID)
        Me.GroupBox2.Controls.Add(Me.btnOrdSubmit)
        Me.GroupBox2.Controls.Add(Me.btnAdd)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cboItem)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtOrdNum)
        Me.GroupBox2.Controls.Add(Me.nudQty)
        Me.GroupBox2.Location = New System.Drawing.Point(364, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(336, 153)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Manual Order Entry"
        '
        'cboCustID
        '
        Me.cboCustID.FormattingEnabled = True
        Me.cboCustID.Location = New System.Drawing.Point(9, 37)
        Me.cboCustID.Name = "cboCustID"
        Me.cboCustID.Size = New System.Drawing.Size(109, 24)
        Me.cboCustID.TabIndex = 0
        '
        'btnOrdSubmit
        '
        Me.btnOrdSubmit.Location = New System.Drawing.Point(226, 111)
        Me.btnOrdSubmit.Name = "btnOrdSubmit"
        Me.btnOrdSubmit.Size = New System.Drawing.Size(110, 37)
        Me.btnOrdSubmit.TabIndex = 5
        Me.btnOrdSubmit.Text = "Submit Order"
        Me.btnOrdSubmit.UseVisualStyleBackColor = True
        '
        'lstItems
        '
        Me.lstItems.FormattingEnabled = True
        Me.lstItems.ItemHeight = 16
        Me.lstItems.Location = New System.Drawing.Point(392, 184)
        Me.lstItems.Name = "lstItems"
        Me.lstItems.Size = New System.Drawing.Size(83, 100)
        Me.lstItems.TabIndex = 9
        Me.lstItems.TabStop = False
        '
        'lstQtys
        '
        Me.lstQtys.FormattingEnabled = True
        Me.lstQtys.ItemHeight = 16
        Me.lstQtys.Location = New System.Drawing.Point(481, 184)
        Me.lstQtys.Name = "lstQtys"
        Me.lstQtys.Size = New System.Drawing.Size(42, 100)
        Me.lstQtys.TabIndex = 10
        Me.lstQtys.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(359, 164)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(174, 17)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Manual Entry - Order Itms:"
        '
        'btnClearItems
        '
        Me.btnClearItems.Location = New System.Drawing.Point(559, 172)
        Me.btnClearItems.Name = "btnClearItems"
        Me.btnClearItems.Size = New System.Drawing.Size(141, 40)
        Me.btnClearItems.TabIndex = 1
        Me.btnClearItems.Text = "Clear Order Itms"
        Me.btnClearItems.UseVisualStyleBackColor = True
        '
        'ofdOrdersFromFile
        '
        Me.ofdOrdersFromFile.FileName = "OpenFileDialog1"
        '
        'lstvwReport
        '
        Me.lstvwReport.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chOrdNum, Me.chProdName, Me.chProdQty, Me.chAssignedTo, Me.chStartTime, Me.chEndTime})
        Me.lstvwReport.Location = New System.Drawing.Point(12, 608)
        Me.lstvwReport.Name = "lstvwReport"
        Me.lstvwReport.Size = New System.Drawing.Size(688, 176)
        Me.lstvwReport.TabIndex = 7
        Me.lstvwReport.TabStop = False
        Me.lstvwReport.UseCompatibleStateImageBehavior = False
        Me.lstvwReport.View = System.Windows.Forms.View.Details
        '
        'chOrdNum
        '
        Me.chOrdNum.Text = "Order Number"
        Me.chOrdNum.Width = 80
        '
        'chProdName
        '
        Me.chProdName.Text = "Product Name"
        Me.chProdName.Width = 90
        '
        'chProdQty
        '
        Me.chProdQty.Text = "Quantity"
        '
        'chAssignedTo
        '
        Me.chAssignedTo.Text = "Assigned to Area"
        Me.chAssignedTo.Width = 95
        '
        'chStartTime
        '
        Me.chStartTime.Text = "Start Time"
        '
        'chEndTime
        '
        Me.chEndTime.Text = "End Time"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 588)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 17)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Order Report:"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 796)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lstvwReport)
        Me.Controls.Add(Me.btnClearItems)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lstQtys)
        Me.Controls.Add(Me.lstItems)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnLoadFromFile)
        Me.Controls.Add(Me.grpOrderStatus)
        Me.Controls.Add(Me.grpInventory)
        Me.Name = "frmMain"
        Me.Text = "Plastico Order Dispatcher"
        Me.grpInventory.ResumeLayout(False)
        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpOrderStatus.ResumeLayout(False)
        CType(Me.dgvAsssignedWork, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudQty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnReset As Button
    Friend WithEvents grpInventory As GroupBox
    Friend WithEvents dgvInventory As DataGridView
    Friend WithEvents grpOrderStatus As GroupBox
    Friend WithEvents dgvAsssignedWork As DataGridView
    Friend WithEvents btnLoadFromFile As Button
    Friend WithEvents txtOrdNum As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboItem As ComboBox
    Friend WithEvents nudQty As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnOrdSubmit As Button
    Friend WithEvents lstItems As ListBox
    Friend WithEvents lstQtys As ListBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnClearItems As Button
    Friend WithEvents btnReport As Button
    Friend WithEvents cboCustID As ComboBox
    Friend WithEvents ofdOrdersFromFile As OpenFileDialog
    Friend WithEvents lstvwReport As ListView
    Friend WithEvents chOrdNum As ColumnHeader
    Friend WithEvents chProdName As ColumnHeader
    Friend WithEvents chProdQty As ColumnHeader
    Friend WithEvents chAssignedTo As ColumnHeader
    Friend WithEvents chStartTime As ColumnHeader
    Friend WithEvents chEndTime As ColumnHeader
    Friend WithEvents Label6 As Label
End Class
