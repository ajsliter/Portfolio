'------------------------------------------------------------
'-                File Name : frmMain.vb                    - 
'-                Part of Project: Assignment 1             -
'------------------------------------------------------------
'-                Written By: Austin Sliter                 -
'-                Written On: 1/22/18                       -
'------------------------------------------------------------
'- File Purpose:                                            -
'- This file contains the main application form where the   -
'- user will input data and the core program divided into   -
'- multiple documented subroutines for ease of reading and  -
'- debugging.                                               - 
'------------------------------------------------------------
'- Program Purpose:                                         -
'-                                                          -
'- This program starts by reading an Inventory File, or if  -
'- no file exists, creates one for you while setting up the -
'- form for browsing the Inventory. Next it waits for user  -
'- input. Depending on the user input, the Form may perform -
'- the following Actions:                                   -
'-                                                          -
'- 1. Forward/Back Buttons: Increments or Decrements the    -
'- Array List's Targeted Index and displays the appropriate data -
'- For that record in the Text Boxes. If it is the final    -
'- record and a forward operation is called or the first    -
'- record and a back operation is called, an error Message  -
'- Box will show notifying the user of an invalid operation.-
'-                                                          -
'- 2. Add Item Button: Transforms the Form into Editing Mode-
'- by Making the "Active" Property on the Text and Check    -
'- Boxes equal To True. Next, Hides the Add New Inventory   -
'- Item Button along With the Next And Previous Item Browse -
'- buttons. From Edit Mode you Can Perform the Folowing     -
'- Actions:                                 -
'-                                                          -
'- a. Save Item Button: Performs input Validation to make   -
'- sure the inputs are of correct datatype. When and if a   -
'- problem is detected, a targeted error message box will   -
'- show along with clearing the field in question. If the   -
'- data passes the validation step, it is added to the Array- 
'- List as the Data Structure "InvRecord" and recorded as a -
'- new index in the Array List. The Form then switches to Browse Mode- 
'- by Making the "Active" Property on the Text and Check    -
'- Boxes equal To False. Next, Shows the Add New Inventory  -
'-Item Button along With the Next And Previous Item Browse  -
'- buttons. Finally the Array List is Written to the File when program is terminated.        -
'-                                                          -
'- b. Cancel Button: Asks the user if they want to discard  -
'- their data if and only if data is contained in any of    -
'- the text boxes. If both conditions are yes, then the form-
'- switches to browse mode by Making the "Active" Property  -
'- on the Text and Check Boxes equal To False. Next, Shows  -
'- the Add New Inventory Item Button along With the Next and-
'- Previous Item Browse buttons.                            -
'-                                                          -
'- 3. Calculate Total Inventory Item Value: This Button, and-
'- its corresponding label are both visable in both Edit    -
'- Mode And Browse Mode. As such, clicking the button will  -
'- initiate a check to see which mode the program is in and -
'- behave accordingly:                                      -
'-                                                          -
'- a. Edit Mode: Performs Data Validation, Just Like in the - 
'- Save Function and if it is ok, performs a calculation as:-
'- Total Value of Inventory Items = Quantity * Unit Price   -
'- expessed as a double and converted into a string in the  -
'- format of Currency when it is concatenated as part of the-
'- output label's text property.                            -
'-                                                          -
'- b. Browse Mode: Performs the Same Function as in Edit    -
'- Mode, however does not perform data validation as it is  -
'- not needed.                                              -
'-                                                          -
'- 4. Exiting the Program: When the X button is pressed,    -
'- the user is prompted if they want to exit in a Yes/No    -
'- format. If Yes the form closes, If No the Form stays     -
'- active.                                                  -
'-                                                          -
'------------------------------------------------------------
'- Global Variable Dictionary (alphabetically):             -
'-  lstInventory – The Inventory Array List that stores the      -
'-                 Current inventory as read from the file. -
'-  blnIsEditMode – Tells certain subroutines the program   -
'-                  state. Switches based on the Edit Mode. -
'-  intCurrIndex - Specifies the Current index of the list  -
'-  InvRecord - Data Structure that allows 1 Item in the    -
'-              Array List to hold all of the item data. Contains-
'-              the following data:                         -
'-            1. blnFlatPrice - The State of the Flat Rate  -
'-               Check Box.                                 -
'-            2. dblUnitPrice - The Price Per Unit of the   -
'-               Inventory Item.                            -
'-            3. intID - The ID of the Inventory Item.      -
'-            4. intQuantity - Quantity of the Inventory    -
'-               Item in Stock.                             -
'-            5. strDescr - The String Description for the  -
'-               Inventory Item.                            -
'- objStreamReader - StreamReader object for Reading a File -
'- objStreamWriter - StreamWriter object for Writing to File-
'------------------------------------------------------------
Public Class frmMain
    '---CLASS VARIABLES---
    'This Data Structure adds the Multidata Structure InvRecord for each Inventory Record to be recorded as part of an Array List
    Structure InvRecord
        Dim intID As Integer 'The ID of the Inventory Item
        Dim strDescr As String 'The String Description for the Inventory Item
        Dim intQuantity As Integer 'Quantity of the Inventory Item in Stock
        Dim dblUnitPrice As Double 'The Price Per Unit of the Inventory Item
        Dim blnFlatPrice As Boolean 'The State of the Flat Rate Check Box
    End Structure

    'Defines the Inventory Array List for use in the rest of the Program
    Dim lstInventory As New ArrayList

    'Boolean Value to Tell the State of the Program
    Dim blnIsEditMode As Boolean = False

    'Indexing
    Dim intCurrIndex As Integer = 0

    'StreamReader and Stream Writer
    Dim objStreamWriter As System.IO.StreamWriter
    Dim objStreamReader As System.IO.StreamReader


    '------------------------------------------------------------
    '-                Subprogram Name: frmMain_Activated        -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/23/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Program Starts.   -
    '- The subroutine will Read the Inventory File and Parse it –
    '- to an Array List. By using the construct InvRecord that  -
    '- contains all data parsed from the file in one index of   -
    '- the Array List, in order To simplify both the list and   -
    '- the data entered. Then The subroutine will Set the Form's-
    '- Text property to the standard String and the First Item  -
    '- (index 0) of the Array List out of the total number of   -
    '- items Expressed as a fraction.                           -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Read Inventory File and Parse it as Multidata Array List 
        'Then Set the Form Text property to the standard String + the First Item out of the Array List out of the total number of items
        ''Local Vars
        Dim strline As String = ""
        Dim arrLineData() As String
        Dim record As InvRecord = New InvRecord
        'Checks if the Inventory File Exists
        If System.IO.File.Exists("Inventory.txt") Then
            objStreamReader = System.IO.File.OpenText("Inventory.txt")
            'If the File is Empty, then the system puts you in edit mode automatically to add a new record
            If System.IO.File.ReadAllText("Inventory.txt").Length = 0 Then
                ToggleEditMode()
            Else 'Otherwise reads the file and puts it into a new construct for copying into the array list
                'Reads data and puts it into the array list
                While Not (objStreamReader.EndOfStream)
                    strline = objStreamReader.ReadLine()
                    arrLineData = strline.Split(", ")
                    record.intID = CInt(arrLineData(0).Trim)
                    record.strDescr = arrLineData(1).Trim
                    record.intQuantity = CInt(arrLineData(2).Trim)
                    record.dblUnitPrice = CDbl(arrLineData(3).Trim)
                    If arrLineData(4).Equals("True") Then
                        record.blnFlatPrice = True
                    Else
                        record.blnFlatPrice = False
                    End If
                    lstInventory.Add(record)
                End While
                'Populates the Uneditable fields for Browse mode and makes the Item status in the bar show up
                PopBrowseFields()
            End If
            objStreamReader.Close()
        Else 'If not then the System creates the file and puts you in Edit Mode Automatically
            objStreamWriter = System.IO.File.CreateText("Inventory.txt")
            objStreamWriter.Close()
            ToggleEditMode()
        End If
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: PopBrowseFields          -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/22/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Program goes to   -
    '- browse mode or changes inventory items.                  -
    '- The subroutine will change the form's title text, and text–
    '- fields to the record found at the current index          -
    '- (see vairable of same name)                              -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Sub PopBrowseFields()
        Me.Text = "Inventory System - Item " & (intCurrIndex + 1) & "/" & lstInventory.Count
        txtID.Text = lstInventory(intCurrIndex).intID
        txtDescription.Text = lstInventory(intCurrIndex).strDescr
        txtQuantity.Text = lstInventory(intCurrIndex).intQuantity
        txtUnitPrice.Text = lstInventory(intCurrIndex).dblUnitPrice
        chkFlatPrice.Checked = lstInventory(intCurrIndex).blnFlatPrice
        lblInvValue.Text = "Total Inventory Value of Current Item: "
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: ToggleEditMode           -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/23/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called only at ceratin times noted    -
    '- above.                                                   -
    '- The subroutine will check if edit mode is on or not to   –
    '- make a decision based on what mode the form needs        -
    '- changing to.                                             -
    '- When this Toggle Subroutine goes back to browse mode,    -
    '- the function will return the title and the fields to the -
    '- Last known inventory index.                              -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Sub ToggleEditMode()
        If blnIsEditMode Then
            blnIsEditMode = False
            txtID.Enabled = False
            txtDescription.Enabled = False
            txtQuantity.Enabled = False
            txtUnitPrice.Enabled = False
            chkFlatPrice.Enabled = False
            btnAddItm.Visible = True
            btnBackInv.Visible = True
            btnForwardInv.Visible = True
            btnSaveItm.Visible = False
            btnCnlAddItm.Visible = False
            PopBrowseFields()
        Else
            blnIsEditMode = True
            txtID.Enabled = True
            txtDescription.Enabled = True
            txtQuantity.Enabled = True
            txtUnitPrice.Enabled = True
            chkFlatPrice.Enabled = True
            btnAddItm.Visible = False
            btnBackInv.Visible = False
            btnForwardInv.Visible = False
            btnSaveItm.Visible = True
            btnCnlAddItm.Visible = True
            Me.Text = "Inventory System - Add New"
            txtID.Text = ""
            txtDescription.Text = ""
            txtQuantity.Text = ""
            txtUnitPrice.Text = ""
            chkFlatPrice.Checked = False
            lblInvValue.Text = "Total Inventory Value of Current Item: "
        End If
    End Sub

    '------------------------------------------------------------
    '-                Function Name: CheckInputs                -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/25/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the the textboxes need-
    '- to be checked for invalid input. If invalid input is found–
    '- the system will find the field(s) that is invalid and show-
    '- a targeted error message while clearing the invalid fields-
    '- in order to prevent calculation errors.                  -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Returns:                                                 -
    '- Boolean – telling if the inputs are OK to use            -
    '------------------------------------------------------------

    Function CheckInputs() As Boolean
        'If all text boxes that require numeric data are fine, then the function returns true
        If IsNumeric(txtID.Text) And IsNumeric(txtQuantity.Text) And IsNumeric(txtUnitPrice.Text) And txtDescription.Text <> "" Then
            Return True
        Else 'Shows an Error message depending on the type of error while the function returns false.
            If txtDescription.Text = "" And txtID.Text = "" And txtQuantity.Text = "" And txtUnitPrice.Text = "" And txtDescription.Text = "" Then
                MessageBox.Show("Attention! The Textboxes are Empty, Please Enter Something into the Texboxes!", "System Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'all textboxes are invalid
            ElseIf Not IsNumeric(txtID.Text) And Not IsNumeric(txtQuantity.Text) And Not IsNumeric(txtUnitPrice.Text) And txtDescription.Text = "" Then 'Case All text boxes are invalid
                MessageBox.Show("Error! Invalid Entry Detected in ID, Unit Price and Quantity Text Boxes. Empty Description! You must enter an integer or float (float for unit price only) and must have a description! (Integer eg. 1,2,3)", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUnitPrice.Clear()
                txtQuantity.Clear()
                txtID.Clear()
                'Three Text Boxes are invalid
            ElseIf Not IsNumeric(txtID.Text) And Not IsNumeric(txtQuantity.Text) And txtDescription.Text = "" Then
                MessageBox.Show("Error! Invalid Entry Detected in ID and Quantity Text Boxes with Missing Description. You must enter an integer! (eg. 1,2,3)", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtID.Clear()
                txtQuantity.Clear()

            ElseIf Not IsNumeric(txtQuantity.Text) And Not IsNumeric(txtUnitPrice.Text) And txtDescription.Text = "" Then
                MessageBox.Show("Error! Invalid Entry Detected in Unit Price and Quantity Text Boxes with missing Description. You must enter an integer! (eg. 1,2,3)", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUnitPrice.Clear()
                txtQuantity.Clear()
            ElseIf Not IsNumeric(txtID.Text) And Not IsNumeric(txtUnitPrice.Text) And txtDescription.Text = "" Then
                MessageBox.Show("Error! Invalid Entry Detected in ID and Unit Price Text Boxes with missing Description. You must enter an integer! (eg. 1,2,3)", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUnitPrice.Clear()
                txtID.Clear()
                'Two text boxes invalid with description
            ElseIf Not IsNumeric(txtID.Text) And txtDescription.Text = "" Then
                MessageBox.Show("Error! Invalid Entry Detected in ID and Empty Description Text Boxes. You must enter an integer! (eg. 1,2,3)", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtID.Clear()
            ElseIf Not IsNumeric(txtQuantity.Text) And txtDescription.Text = "" Then
                MessageBox.Show("Error! Invalid Entry Detected in Quantity and Empty Description Text Boxes. You must enter an integer! (eg. 1,2,3)", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtQuantity.Clear()
            ElseIf Not IsNumeric(txtUnitPrice.Text) And txtDescription.Text = "" Then
                MessageBox.Show("Error! Invalid Entry Detected in Unit Price and Empty Description Text Boxes. You must enter an integer! (eg. 1,2,3)", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUnitPrice.Clear()
                'Two Text Boxes are invalid
            ElseIf Not IsNumeric(txtID.Text) And Not IsNumeric(txtQuantity.Text) Then
                MessageBox.Show("Error! Invalid Entry Detected in ID and Quantity Text Boxes. You must enter an integer! (eg. 1,2,3)", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtID.Clear()
                txtQuantity.Clear()

            ElseIf Not IsNumeric(txtQuantity.Text) And Not IsNumeric(txtUnitPrice.Text) Then
                MessageBox.Show("Error! Invalid Entry Detected in Unit Price and Quantity Text Boxes. You must enter an integer! (eg. 1,2,3)", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUnitPrice.Clear()
                txtQuantity.Clear()
            ElseIf Not IsNumeric(txtID.Text) And Not IsNumeric(txtUnitPrice.Text) Then
                MessageBox.Show("Error! Invalid Entry Detected in ID and Unit Price Text Boxes. You must enter an integer! (eg. 1,2,3)", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUnitPrice.Clear()
                txtID.Clear()
                'One text Box is Invalid
            ElseIf Not IsNumeric(txtID.Text) Then
                MessageBox.Show("Error! Invalid Entry Detected in ID Text Box. You must enter an integer! (eg. 1,2,3)", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtID.Clear()
            ElseIf Not IsNumeric(txtQuantity.Text) Then
                MessageBox.Show("Error! Invalid Entry Detected in Quantity Text Box. You must enter an integer! (eg. 1,2,3)", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtQuantity.Clear()
            ElseIf txtDescription.Text = "" Then
                MessageBox.Show("Error! Description Text Box is Empty. You must enter a Description!", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf Not IsNumeric(txtUnitPrice.Text) Then
                MessageBox.Show("Error! Invalid Entry Detected in Unit Price Text Box. You must enter an integer or floating point number! (eg. 1,2,3,2.5,3.5)", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUnitPrice.Clear()
            End If
            Return False
        End If
    End Function

    '------------------------------------------------------------
    '-                Subprogram Name: btnForwardInv_Click      -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/23/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the corresponding     -
    '- button is pressed. If there is a next position in the    -
    '- Array List, Advance the Array List to the Next Position and Change -
    '- the Form's Text property to the standard string with the -
    '- next item (current item + 1) out of the Array List out of the -
    '- total number of items in fraction format. The text boxes -
    '- For ID, Quantity Description And Per Unit Price are      -
    '- changed with flat rate check box to match data in Array List  -
    '- to match that Array List position. Else, Show error message   -
    '- box.                                                     -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnForwardInv_Click(sender As Object, e As EventArgs) Handles btnForwardInv.Click
        'If there is a next position in the Array List, Advance the Array List to the Next Position 
        'Else Show error message box
        'The text boxes For ID, Quantity Description And Per Unit Price are changed with flat rate check box to match data in Array List
        'Change the Form Text property to the standard string + the next item out of the Array List out of the total number of items
        If intCurrIndex + 1 <= lstInventory.Count - 1 Then
            intCurrIndex += 1
            PopBrowseFields()
        Else
            MessageBox.Show("Attention! You Have Reached the Maximum Index of the Inventory.", "System Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnBackInv_Click         -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/23/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the corresponding     -
    '- button is pressed. If there is a next position in the    -
    '- Array List, Move the Array List to the Previous Position -
    '- And Change the Form's Text property to the standard      -
    '- string with the next item (current item - 1) out of the  -
    '- Array List out of the total number of items in fraction  -
    '- format. The text boxes For ID, Quantity Description And  -
    '- Per Unit Price are changed with flat rate check box to   -
    '- match data In Array List to match that Array List        -
    '- position. Else, Show error message box.                  -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnBackInv_Click(sender As Object, e As EventArgs) Handles btnBackInv.Click
        'If there is a previous position in the Array List, Advance the Array List to the Previous Position 
        'Else Show error message box
        'The text boxes For ID, Quantity Description And Per Unit Price are changed with flat rate check box to match data in Array List
        'Cheange the Form Text property to the standard string + the previous item out of the Array List out of the total number of items
        If intCurrIndex - 1 >= 0 Then
            intCurrIndex -= 1
            PopBrowseFields()
        Else
            MessageBox.Show("Attention! You Have Reached the Minimum Index of the Inventory.", "System Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnAddItm_Click          -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/23/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the corresponding     -
    '- button is pressed. Transforms the Form into Editing Mode -
    '- by Making the "Active" Property on the Text and Check    -
    '- Boxes equal To True. Next, Hides the Add New Inventory   -
    '- Item Button along With the Next And Previous Item Browse -
    '- buttons.                                                 -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnAddItm_Click(sender As Object, e As EventArgs) Handles btnAddItm.Click
        'Changes The Form to Edit Mode
        'Makes the Textboxes and Check Box Available for Editing by Making the "Active" Property on those items = True
        'Hides the Add New Inventory Item Button along with the Next and Previous Item Browse buttons
        ToggleEditMode()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnCnlAddItm_Click       -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/23/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the corresponding     -
    '- button is pressed. Asks the user if they want to discard -
    '- their data if and only if data is contained in any of    -
    '- the text boxes. If both conditions are yes, then the form-
    '- switches to browse mode by Making the "Active" Property  -
    '- on the Text and Check Boxes equal To False. Next, Shows  -
    '- the Add New Inventory Item Button along With the Next and-
    '- Previous Item Browse buttons.                            -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- result - records the dialog result of the message box    -
    '-          to determine whether or not to cancel the Edit  -
    '-          Mode when data is detected in the.                                           -
    '------------------------------------------------------------
    Private Sub btnCnlAddItm_Click(sender As Object, e As EventArgs) Handles btnCnlAddItm.Click
        'Changes the Form Back To Browse Mode by Subroutine (Checks if CNL Button Was Pressed to determine if saving to file is needed)
        If Not (txtID.Text = "" Or txtDescription.Text = "" Or txtQuantity.Text = "" Or txtUnitPrice.Text = "") Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to discard your entries?", "System Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                If lstInventory.Count = 0 Then
                    MessageBox.Show("Error! You Must Enter a New Record! Inventory is Empty!", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    ToggleEditMode()
                End If
            Else
                'Nothing
            End If
        Else
            If lstInventory.Count = 0 Then
                MessageBox.Show("Error! You Must Enter a New Record! Inventory is Empty!", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                ToggleEditMode()
            End If
        End If
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnSaveItm_Click         -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/25/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the corresponding     -
    '- button is pressed. Performs input Validation to make     -
    '- sure the inputs are of correct datatype. When and if a   -
    '- problem is detected, a targeted error message box will   -
    '- show along with clearing the field in question. If the   -
    '- data passes the validation step, it is added to the Array List -
    '- as the Data Structure "InvRecord" and recorded as a new  -
    '- index in the Array List. The Form then switches to Browse Mode- 
    '- by Making the "Active" Property on the Text and Check    -
    '- Boxes equal To False. Next, Shows the Add New Inventory  -
    '-Item Button along With the Next And Previous Item Browse  -
    '- buttons. Finally the Array List is Written to the File.        -                                               -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- record - The record that holds the entered data for      -
    '- entry into the list.                                     -
    '------------------------------------------------------------
    Private Sub btnSaveItm_Click(sender As Object, e As EventArgs) Handles btnSaveItm.Click
        'Changes the Form Back to Browse Mode by Subroutine (Checks if CNL Button Was Pressed to determine if saving to file is needed)
        If CheckInputs() Then
            Dim record As InvRecord = New InvRecord
            record.intID = CInt(txtID.Text)
            record.strDescr = txtDescription.Text
            record.intQuantity = CInt(txtQuantity.Text)
            record.dblUnitPrice = CDbl(txtUnitPrice.Text)
            record.blnFlatPrice = CBool(chkFlatPrice.Checked)
            lstInventory.Add(record)
            ToggleEditMode()
        End If
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnCalcTotInvValue_Click -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/25/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the corresponding     -
    '- button is pressed. This Button, and its corresponding    -
    '- label are both visable In both Edit Mode And Browse Mode.-
    '- As such, clicking the button will initiate a check to see-
    '- which mode the program is in and behave accordingly:     -
    '-                                                          -
    '- a. Edit Mode: Performs Data Validation, Just Like in the - 
    '- Save Function and if it is ok, performs a calculation as:-
    '- Total Value of Inventory Items = Quantity * Unit Price   -
    '- expessed as a double and converted into a string in the  -
    '- format of Currency when it is concatenated as part of the-
    '- output label's text property.                            -
    '-                                                          -
    '- b. Browse Mode: Performs the Same Function as in Edit    -
    '- Mode, however does not perform data validation as it is  -
    '- not needed.                                              - 
    '- if flat rate is checked unit price is the answer.        -
    '- otherwise unit price times quantity is the answer.       -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- currRecord - The Current Inventory Record Pulled from the-
    '-              list instead of the text boxes to ensure    -
    '-              correct results.                            -
    '- result - the double result of the calculation added as a -
    '-          string in currency format to the output label   -
    '------------------------------------------------------------
    Private Sub btnCalcTotInvValue_Click(sender As Object, e As EventArgs) Handles btnCalcTotInvValue.Click
        'Calculates the Total Invantory Value on the Item. This Button and the label will be Visible while both adding Items and Browsing.
        'local variables
        Dim result As Double
        If (lstInventory.Count = 0 And (Not txtQuantity.Text = "" And Not txtUnitPrice.Text = "")) Or (Not lstInventory.Count = 0 And (Not txtQuantity.Text = "" And Not txtUnitPrice.Text = "")) Then
            'Checks if edit mode is on (determines if to read from text boxes or from list)
            If blnIsEditMode Then
                'when edit mode is on
                If CheckInputs() Then
                    If chkFlatPrice.Checked = True Then
                        result = CDbl(txtUnitPrice.Text)
                    Else
                        result = CDbl(txtUnitPrice.Text) * CInt(txtQuantity.Text)
                    End If
                    lblInvValue.Text = "Total Inventory Value of Current Item: " & result.ToString("C")
                End If
            Else
                'local variables
                Dim currRecord As InvRecord = lstInventory(intCurrIndex)
                If currRecord.blnFlatPrice = True Then
                    result = currRecord.dblUnitPrice
                Else
                    result = currRecord.dblUnitPrice * currRecord.intQuantity
                End If
                lblInvValue.Text = "Total Inventory Value of Current Item: " & result.ToString("C")
            End If
        ElseIf lstInventory.Count = 0 Then
            MessageBox.Show("Error! Cannot Calculate - No Items in Inventory", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: frmMain_Closing          -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/23/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user closes the   -
    '- application. The subroutine asks by message box whether  -  
    '- or not the user wishes to exit. If so, the exit event    -
    '- continues, otherwise the exit event is cancelled         -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the System.ComponentModel.CancelEventArgs to   -
    '-     signify the cancel decision of the close event       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- result - records the dialog result of the message box    -
    '-          to determine whether or not to cancel the close -
    '-          event.                                          -
    '------------------------------------------------------------
    Private Sub frmMain_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim result As DialogResult = MessageBox.Show("Do you wish to exit the application?", "Exit Prompt", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: frmMain_Closed           -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/25/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Program Ends.     -
    '- The subroutine will Read the Inventory List and Parse it –
    '- to the Inventory File.                                   -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub frmMain_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        objStreamWriter = System.IO.File.CreateText("Inventory.txt")
        Dim currRecord As InvRecord
        For intCurrIndex = 0 To lstInventory.Count - 1
            currRecord = lstInventory(intCurrIndex)
            Dim strBuild As String = currRecord.intID & ", " & currRecord.strDescr & ", " & currRecord.intQuantity & ", " & currRecord.dblUnitPrice & ", " & currRecord.blnFlatPrice
            objStreamWriter.WriteLine(strBuild)
        Next
        objStreamWriter.Close()
        If lstInventory.Count = 0 Then
            'nothing
        Else
            MessageBox.Show("Inventory Written to File!", "System Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class
