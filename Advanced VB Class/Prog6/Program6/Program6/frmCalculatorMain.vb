'------------------------------------------------------------
'-                File Name : frmCalculatorMain.vb          - 
'-                Part of Project: Assignment 6             -
'------------------------------------------------------------
'-                Written By: Austin Sliter                 -
'-                Written On: 3/15/18                       -
'------------------------------------------------------------
'- File Purpose:                                            -
'- This file contains the MDI Parent Form that accepts input-
'- through the menu bar. Depending on the Option Selected,  -
'- The program will perform application event routines for  -
'- each selection.                                          - 
'------------------------------------------------------------
'- Program Purpose:                                         -
'- This program starts with the MDI parent. Depending on the-
'- Menu options it will perform events that include the New -
'- option; which will create a new Calculator child of the MDI-
'- parent. From there the Child is able to perform conversions-
'- between Binary, Decimal and Hexadecimal numbers. Binary  -
'- Numbers are formatted in groups of fours (after conversion).-
'- With the first Value filled, you gain access to perform the-
'- Not Logic Operation. After filling in the two Values and -
'- converting them to the other forms; the AND, OR and XOR  -
'- Logic operations become available. When you select a     -
'- specific Field for Value 1 or 2, The input buttons will  -
'- change depending on the type of data required for that   -
'- field. Also if the program detects changes in the editable-
'- fields, The option to clear those fields (including when -
'- results of a Logic Operation complete and display) will be-
'- available until it is clicked. If the individual child form-
'- is about to be closed and data still exists on that instance,-
'- the program will prompt the user if they want to discard the-
'- changes made. That logical decision determines           -
'- whether or not the form closes. If the main MDI parent is-
'- called to close and any active children contain any data, -
'- the user will be prompted for each child with data. If any-
'- results are "No", All Forms (including the Children) will -
'- remain active, otherwise the forms will close.            -
'------------------------------------------------------------
'- Global Variable Dictionary (alphabetically):             -
'- intFrmCnt – Keeps track of the number of forms instanced.–
'------------------------------------------------------------


Public Class frmMainCalculator
    '---Global Variables---
    Dim intFrmCnt As Integer = 0

    '---Menu Bar---
    '--File--
    '------------------------------------------------------------
    '-                Subprogram Name: mnuFileNew_Click         -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above menu option is clicked -
    '- Creates a New Instance of the calculator form.           –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- newCalculator - Contains a Calculator Form Object for    -
    '-               creating new unique instances of the       -
    '-               calculator form.                           -
    '------------------------------------------------------------
    Private Sub mnuFileNew_Click(sender As Object, e As EventArgs) Handles mnuFileNew.Click
        'Create New Calculator Instance
        Dim newCalculator As frmCalculator = New frmCalculator

        'Increment Counter
        intFrmCnt += 1

        'Change Form's Name and Title for Naming Scheme
        newCalculator.Name &= "_" & Trim(CStr(intFrmCnt))
        newCalculator.Text &= " " & Trim(CStr(intFrmCnt))

        'Attach Instance to Parent
        newCalculator.MdiParent = Me

        'Show New Calculator
        newCalculator.Show()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: mnuFileExit_Click         -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above menu option is clicked -
    '- Calls the Form_Closing for both the MDI form and any open-
    '- child forms.                                             –
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
        'Trigger Form Closing
        Me.Close()
    End Sub

    '--Window--
    '------------------------------------------------------------
    '-                Subprogram Name: mnuWindowCascade_Click   -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above menu option is clicked -
    '- Cascades all child windows.                              –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub mnuWindowCascade_Click(sender As Object, e As EventArgs) Handles mnuWindowCascade.Click
        'Cascade the Windows
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    '------------------------------------------------------------
    '-           Subprogram Name: mnuWindowTileVertical_Click   -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above menu option is clicked -
    '- Tiles all child windows Vertically.                      –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub mnuWindowTileVertical_Click(sender As Object, e As EventArgs) Handles mnuWindowTileVertical.Click
        'Tile the Windows Vertically
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    '------------------------------------------------------------
    '-         Subprogram Name: mnuWindowTileHorizontal_Click   -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above menu option is clicked -
    '- Tiles all child windows Horizontally.                    –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub mnuWindowTileHorizontal_Click(sender As Object, e As EventArgs) Handles mnuWindowTileHorizontal.Click
        'Tile the Windows Horizonally
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    '--Help--
    '------------------------------------------------------------
    '-                Subprogram Name: mnuHelpAbout_Click       -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above menu option is clicked -
    '- Shows an Autogenerated About Window for this application.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub mnuHelpAbout_Click(sender As Object, e As EventArgs) Handles mnuHelpAbout.Click
        'Shows the About Box Form
        frmAboutCalc.Show()
    End Sub
End Class
