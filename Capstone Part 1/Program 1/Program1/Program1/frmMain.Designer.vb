<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFile_NewOrder = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindow_Cascade = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindow_Tile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindow_Tile_Horiz = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindow_Tile_Vert = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuWindow})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.MdiWindowListItem = Me.mnuWindow
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Size = New System.Drawing.Size(1069, 28)
        Me.mnuMain.TabIndex = 0
        Me.mnuMain.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile_NewOrder, Me.mnuFileExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(44, 24)
        Me.mnuFile.Text = "File"
        '
        'mnuFile_NewOrder
        '
        Me.mnuFile_NewOrder.Name = "mnuFile_NewOrder"
        Me.mnuFile_NewOrder.Size = New System.Drawing.Size(181, 26)
        Me.mnuFile_NewOrder.Text = "New Order"
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Name = "mnuFileExit"
        Me.mnuFileExit.Size = New System.Drawing.Size(181, 26)
        Me.mnuFileExit.Text = "Exit"
        '
        'mnuWindow
        '
        Me.mnuWindow.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuWindow_Cascade, Me.mnuWindow_Tile})
        Me.mnuWindow.Name = "mnuWindow"
        Me.mnuWindow.Size = New System.Drawing.Size(76, 24)
        Me.mnuWindow.Text = "Window"
        '
        'mnuWindow_Cascade
        '
        Me.mnuWindow_Cascade.Name = "mnuWindow_Cascade"
        Me.mnuWindow_Cascade.Size = New System.Drawing.Size(181, 26)
        Me.mnuWindow_Cascade.Text = "Cascade"
        '
        'mnuWindow_Tile
        '
        Me.mnuWindow_Tile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuWindow_Tile_Horiz, Me.mnuWindow_Tile_Vert})
        Me.mnuWindow_Tile.Name = "mnuWindow_Tile"
        Me.mnuWindow_Tile.Size = New System.Drawing.Size(181, 26)
        Me.mnuWindow_Tile.Text = "Tile"
        '
        'mnuWindow_Tile_Horiz
        '
        Me.mnuWindow_Tile_Horiz.Name = "mnuWindow_Tile_Horiz"
        Me.mnuWindow_Tile_Horiz.Size = New System.Drawing.Size(181, 26)
        Me.mnuWindow_Tile_Horiz.Text = "Horizontal"
        '
        'mnuWindow_Tile_Vert
        '
        Me.mnuWindow_Tile_Vert.Name = "mnuWindow_Tile_Vert"
        Me.mnuWindow_Tile_Vert.Size = New System.Drawing.Size(181, 26)
        Me.mnuWindow_Tile_Vert.Text = "Vertical"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1069, 504)
        Me.Controls.Add(Me.mnuMain)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.mnuMain
        Me.Name = "frmMain"
        Me.Text = "Big J Catering Service - Orders"
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mnuMain As MenuStrip
    Friend WithEvents mnuFile As ToolStripMenuItem
    Friend WithEvents mnuFile_NewOrder As ToolStripMenuItem
    Friend WithEvents mnuFileExit As ToolStripMenuItem
    Friend WithEvents mnuWindow As ToolStripMenuItem
    Friend WithEvents mnuWindow_Cascade As ToolStripMenuItem
    Friend WithEvents mnuWindow_Tile As ToolStripMenuItem
    Friend WithEvents mnuWindow_Tile_Horiz As ToolStripMenuItem
    Friend WithEvents mnuWindow_Tile_Vert As ToolStripMenuItem
End Class
