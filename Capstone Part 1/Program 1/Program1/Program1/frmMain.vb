'------------------------------------------------------------
'-                File Name : frmMain                       - 
'-                Part of Project: Assignment 1             -
'------------------------------------------------------------
'-                Written By: Austin Sliter                 -
'-                Written On: 8/30/18                       -
'------------------------------------------------------------
'- File Purpose:                                            -
'- This file contains the main application form where the   -
'- user can create new Order forms. The User Can Cascade,   -
'- Tile and Switch Between Orders on the Fly. There is also -
'- an option to exit the program from the menu bar, in      -
'- addition to the X button.                                - 
'------------------------------------------------------------
'- Program Purpose:                                         -
'-                                                          -
'- This program, in addition to the description above, allows-
'- the user to enter Contact Information, Meal Type, Amount -
'- of Meals, Discounts (Amount in Percent), And Either Clear-
'- the Order or Calculate the Totals for the current order. -
'------------------------------------------------------------
'- Global Variable Dictionary (alphabetically):             -
'- intCurrFrmNum - Determines what the new Form Should be   -
'-                called when it is created.                –
'------------------------------------------------------------
Imports System.ComponentModel

Public Class frmMain
    '---Global Vars---
    Private intCurrFrmNum As Integer = 1

    '---Events---
    '--Main Menu--
    '------------------------------------------------------------
    '-                Subprogram Name: mnuFile_NewOrder_Click   -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 8/30/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user clicks the   -
    '- New Order Option in the Menu Bar under File. Creates a new-
    '- MDI Child Form Attached to this Form as the designated Parent–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- frmNewOrder - The New Order Form                         -
    '------------------------------------------------------------
    Private Sub mnuFile_NewOrder_Click(sender As Object, e As EventArgs) Handles mnuFile_NewOrder.Click
        'Create New Instance of Order Form
        Dim frmNewOrder As New frmOrder

        'Make Order Indexing Appear and increment index for next order
        frmNewOrder.Text = "Order " & intCurrFrmNum
        intCurrFrmNum += 1

        'Make child link to parent
        frmNewOrder.MdiParent = Me

        'Show new Form
        frmNewOrder.Show()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: mnuFileExit_Click        -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 8/30/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user clicks the   -
    '- Exit Option from the File Menu. Exits the Program.       –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub mnuFileExit_Click(sender As Object, e As EventArgs) Handles mnuFileExit.Click
        'Close the Main Form
        Me.Close()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: mnuWindow_Cascade_Click  -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 8/30/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user clicks the   -
    '- Cascade Option from the Window Menu. Cascades MDI Children.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub mnuWindow_Cascade_Click(sender As Object, e As EventArgs) Handles mnuWindow_Cascade.Click
        'Arrange MDI Children in Cascade Format
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: mnuWindow_Tile_Horiz_Click-
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 8/30/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user clicks the   -
    '- Tile Horizontal Option from the Window Menu. Tiles Horizonal MDI Children.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub mnuWindow_Tile_Horiz_Click(sender As Object, e As EventArgs) Handles mnuWindow_Tile_Horiz.Click
        'Arrange MDI Children in Horizontal Tiling Format
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: mnuWindow_Tile_Vert_Click-
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 8/30/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user clicks the   -
    '- Tile Vertical Option from the Window Menu. Tiles Vertical MDI Children.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub mnuWindow_Tile_Vert_Click(sender As Object, e As EventArgs) Handles mnuWindow_Tile_Vert.Click
        'Arrange MDI Children in Vertical Tiling Format
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    '--Closing Event--
    '------------------------------------------------------------
    '-                Subprogram Name: frmMain_Closing          -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 8/30/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Main Form is Closing.-
    '- Prompts the User if they want to exit. If yes Exits the Program.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- DiagRes - Dialog Result Variable for Analyzing User Prompt-
    '------------------------------------------------------------
    Private Sub frmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Assign a Dialog Result to this Messagebox Prompt
        Dim DiagRes As DialogResult = MessageBox.Show("Are you sure you wish to exit the application?", "Program Exiting", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'If the answer is yes, continue to close the form - else retain the form.
        If DiagRes = DialogResult.Yes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub
End Class
