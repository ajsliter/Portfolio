'------------------------------------------------------------
'-                File Name : frmVehicles.vb                - 
'-                Part of Project: Assignment 6             -
'------------------------------------------------------------
'-                Written By: Austin Sliter                 -
'-                Written On: 3/29/18                       -
'------------------------------------------------------------
'- File Purpose:                                            -
'- This file contains the main application form where The   -
'- User can traverse the owners database and also perform   -
'- update, add and delete operations.                       -
'------------------------------------------------------------
'- Program Purpose:                                         -
'-                                                          -
'- The user will traverse the vehicle owners Database. In each  -
'- traverse operation, The Data shown in the textboxes and  -
'- data grid view will change. From the inital view you can -
'- also delete the current record, Add a new Record or Update-
'- the current record. Update and Add Operations will check -
'- for bad input and then perform the operation if nothing  -
'- is wrong when pressing the save button. The cancel button-
'- will discard changes using the Update or add operations. -
'- The Delete Operation will prompt if they want to delete  -
'- before the operation is carried out. If the user deletes -
'- till no records exist, the system will ask for input, if -
'- none is given then the program will terminate.           -
'------------------------------------------------------------
'- Global Variable Dictionary (alphabetically):             -
'- DBAdaptOwners - Data adapter for Owners Database         -
'- DBAdaptVehicles - Data adapter for Vehicles Database     -
'- DBConn - The Connection to the database                  -
'- dsOwners - The dataset for the Owners Database           -
'- dsVehicles - The dataset for the Vehicles Database       -
'- strCONNECTION - The Connection to the Database link      -
'- strDBNAME - The Database Name                            -
'- strDBPATH - The Database Directory                       -
'- strSERVERNAME - The Database Server Name                 -
'------------------------------------------------------------
Imports System.Data.SqlClient

Public Class frmVehicles
    '---Form Variables---
    '--Datasets--
    Dim dsOwners As DataSet = New DataSet
    Dim dsVehicles As DataSet = New DataSet

    '--Connections and Paths--
    'Database Name
    Const strDBNAME As String = "Autos"
    'Define Current Server Name
    Const strSERVERNAME As String = "(localdb)\MSSQLLocalDB"
    'Define Directory Path
    Dim strDBPATH As String = My.Application.Info.DirectoryPath &
                                  "\" & strDBNAME & ".mdf"
    'Define Full Connection
    Dim strCONNECTION As String = "SERVER=" & strSERVERNAME & ";DATABASE=" &
                     strDBNAME & ";Integrated Security=SSPI;AttachDbFileName=" &
                     strDBPATH
    'SQL Connection for Direct Queries
    Dim DBConn As New SqlConnection(strCONNECTION)

    '--Data Adapter--
    Dim DBAdaptOwners As SqlDataAdapter
    Dim DBAdaptVehicles As SqlDataAdapter

    '---Subroutines---
    'Selects the Correct Nav Button Layout
    '------------------------------------------------------------
    '-                Subprogram Name: doNavButtons            -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Navigation Buttons-
    '- status needs to be reset. Selects the Correct Nav Button -
    '- Layout.                                                  –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- intCurrPosition - The Current position of the database pointer-
    '------------------------------------------------------------
    Sub DoNavButtons()
        '-Local Variables-
        Dim intCurrPosition As Integer = CInt(txtID.Text)

        'If the Last ID is Equal to the Number of Rows in the Table Then Behave Normally
        If dsOwners.Tables(0)(dsOwners.Tables(0).Rows.Count - 1)("TUID") = CInt(dsOwners.Tables("Owners").Rows.Count) Then
            If Not (BindingContext(dsOwners, "Owners").Position = 0 Or intCurrPosition = CInt(dsOwners.Tables("Owners").Rows.Count)) Then
                'If current position is Nither the First or Last Record, Allow Both Directions
                btnForward.Enabled = True
                btnLast.Enabled = True
                btnBack.Enabled = True
                btnFirst.Enabled = True
            ElseIf BindingContext(dsOwners, "Owners").Position = 0 Then
                'If Current Position is First Record, Only Allow Going Forward
                btnBack.Enabled = False
                btnFirst.Enabled = False
                btnForward.Enabled = True
                btnLast.Enabled = True
            ElseIf intCurrPosition = CInt(dsOwners.Tables("Owners").Rows.Count) Then
                'If current position is last record, Only Allow Going Back
                btnForward.Enabled = False
                btnLast.Enabled = False
                btnBack.Enabled = True
                btnFirst.Enabled = True
            End If
        Else
            'If Not, Then Behave with the Current Position is less by 1
            If Not ((BindingContext(dsOwners, "Owners").Position = 0) Or (intCurrPosition = dsOwners.Tables(0)(dsOwners.Tables(0).Rows.Count - 1)("TUID"))) Then
                'If current position is Nither the First or Last Record, Allow Both Directions
                btnForward.Enabled = True
                btnLast.Enabled = True
                btnBack.Enabled = True
                btnFirst.Enabled = True
            ElseIf BindingContext(dsOwners, "Owners").Position = 0 Then
                'If Current Position is First Record, Only Allow Going Forward
                btnBack.Enabled = False
                btnFirst.Enabled = False
                btnForward.Enabled = True
                btnLast.Enabled = True
            ElseIf intCurrPosition = dsOwners.Tables(0)(dsOwners.Tables(0).Rows.Count - 1)("TUID") Then
                'If current position is last record, Only Allow Going Back
                btnForward.Enabled = False
                btnLast.Enabled = False
                btnBack.Enabled = True
                btnFirst.Enabled = True
            End If
        End If
    End Sub

    'Toggles all the controls to editable state
    '------------------------------------------------------------
    '-                Subprogram Name: ToggleEditMode           -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Add or Update     -
    '- Buttons are clicked. Toggles all the controls to editable-
    '- state.                                                   –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Sub ToggleEditMode()
        'Toggle Text Boxes Editing
        txtFirstName.Enabled = Not txtFirstName.Enabled
        txtLastName.Enabled = Not txtLastName.Enabled
        txtStreet.Enabled = Not txtStreet.Enabled
        txtCity.Enabled = Not txtCity.Enabled
        txtState.Enabled = Not txtState.Enabled
        txtZip.Enabled = Not txtZip.Enabled

        'Toggle Nav Button Visibility
        btnFirst.Visible = Not btnFirst.Visible
        btnBack.Visible = Not btnBack.Visible
        btnForward.Visible = Not btnForward.Visible
        btnLast.Visible = Not btnLast.Visible

        'Toggle Panel for Add and Update Operations Enabled and Add,Update and Delete Buttons Visibility
        pnlAdd_Upd.Visible = Not pnlAdd_Upd.Visible
        pnlNonEdit.Visible = Not pnlNonEdit.Visible
    End Sub

    'Resets the Data Grid View to show correct Vehicles forthe Currently Selected Owner
    '------------------------------------------------------------
    '-                Subprogram Name: ResetOwnedVehicles       -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the DataGridView Needs-
    '- to be Refreshed. Resets the Data Grid View to show correct-
    '- Vehicles forthe Currently Selected Owner.                –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- strSQLcmd - String representation of the SQL Query       -
    '------------------------------------------------------------
    Sub ResetOwnedVehicles(strID As String, firstTime As Boolean)
        '-Local Variables-
        'Select only Make, Model, Color, ModelYear and Vin where Owner ID is = to ID taken 
        'from current selected record
        Dim strSQLcmd As String = "Select Vehicles.Make, Vehicles.Model, Vehicles.Color, " &
            "Vehicles.ModelYear, Vehicles.VIN From Vehicles Where OwnerID='" & Trim(strID) & "'"

        'Clear DataSet
        dsVehicles.Clear()

        'Redefine Data Adapter
        DBAdaptVehicles = New SqlDataAdapter(strSQLcmd, strCONNECTION)

        'Refill DataSet
        DBAdaptVehicles.Fill(dsVehicles, "Vehicles")

        'Refresh if data source is not Empty, otherwise connect to data source
        If firstTime Then
            dgvOwnedVehicles.DataSource = dsVehicles.Tables("Vehicles")
        Else
            dgvOwnedVehicles.Refresh()
        End If
    End Sub

    '---Form Events---
    '--Load--
    '------------------------------------------------------------
    '-                Subprogram Name: frmVehicles_Load         -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Form Loads.       -
    '- Sets Databindings of all Text Boxes and DataGridView.    –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- strSQLcmd - String Representation of SQL Query           -
    '------------------------------------------------------------
    Private Sub frmVehicles_Load(sender As Object, e As EventArgs) Handles Me.Load
        '-Local Variables-
        'Define the String for SQL Queries
        Dim strSQLcmd As String

        'Select All Fields of Owners
        strSQLcmd = "SELECT * FROM Owners"
        DBAdaptOwners = New SqlDataAdapter(strSQLcmd, DBConn)
        DBAdaptOwners.Fill(dsOwners, "Owners")

        'Data Bind all Text Boxes
        txtID.DataBindings.Add(New Binding("Text", dsOwners, "Owners.TUID"))
        txtFirstName.DataBindings.Add(New Binding("Text", dsOwners, "Owners.FirstName"))
        txtLastName.DataBindings.Add(New Binding("Text", dsOwners, "Owners.LastName"))
        txtStreet.DataBindings.Add(New Binding("Text", dsOwners, "Owners.StreetAddress"))
        txtCity.DataBindings.Add(New Binding("Text", dsOwners, "Owners.City"))
        txtState.DataBindings.Add(New Binding("Text", dsOwners, "Owners.State"))
        txtZip.DataBindings.Add(New Binding("Text", dsOwners, "Owners.ZipCode"))

        'Reset the Data Grid View for Currently Selected ID
        ResetOwnedVehicles(txtID.Text, True)
    End Sub

    '--Traversing Personal Information Event--
    '------------------------------------------------------------
    '-                Subprogram Name: TraverseButton_Click     -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Nav Buttons are   -
    '- clicked. Based on the Button Perform the correct operations.-
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- btnTraverse - The Button that was Pressed                -
    '------------------------------------------------------------
    Private Sub TraverseButton_Click(sender As Object, e As EventArgs) Handles btnFirst.Click,
        btnBack.Click, btnForward.Click, btnLast.Click
        '-Local Variables-
        'The Button that was pressed - Derived from Sender
        Dim btnTraverse As Button = CType(sender, Button)

        'Perform Taverse Action based on button pressed
        Select Case btnTraverse.Name
            Case "btnFirst"
                'Move to First Record
                BindingContext(dsOwners, "Owners").Position = 0
                'Reset Nav Button Layout
                DoNavButtons()
            Case "btnBack"
                'Move Back 1 Record
                BindingContext(dsOwners, "Owners").Position = (BindingContext(dsOwners,
                       "Owners").Position - 1)
                'Reset Nav Button Layout
                DoNavButtons()
            Case "btnForward"
                'Move Forward 1 record
                BindingContext(dsOwners, "Owners").Position = (BindingContext(dsOwners,
                       "Owners").Position + 1)
                'Reset Nav Button Layout
                DoNavButtons()
            Case "btnLast"
                'Move to Last Record
                BindingContext(dsOwners, "Owners").Position =
                      (dsOwners.Tables("Owners").Rows.Count - 1)
                'Reset Nav Button Layout
                DoNavButtons()
        End Select

        'Reset the Data Grid View for Currently Selected ID
        ResetOwnedVehicles(txtID.Text, False)
    End Sub

    '--Add, Delete and Update Click Events--
    '------------------------------------------------------------
    '-                Subprogram Name: btnAdd_Click             -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Button is Clicked.–
    '- Define the insert command and open the form for adding.  -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- cmdBuilder - SQL Command Builder for Insert              -
    '- strID - The Current ID Selected                          -
    '------------------------------------------------------------
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        '-Local Variables-
        'The Current Id Selected
        Dim strID As String

        'The Command Builder for Insert Queries
        Dim cmdBuilder As SqlCommandBuilder

        'Bind to Owners and set insert command
        cmdBuilder = New SqlCommandBuilder(DBAdaptOwners)
        DBAdaptOwners.InsertCommand = cmdBuilder.GetInsertCommand

        If dsOwners.Tables("Owners").Rows.Count <= 0 Then
            'If Owners table is empty, start with ID 1 and execute the add new command
            BindingContext(dsOwners, "Owners").AddNew()
            txtID.Text = "1"
        Else
            'Navigate to the last Record and increment the ID value by one after clearing the boxes
            BindingContext(dsOwners, "Owners").Position =
                (dsOwners.Tables("Owners").Rows.Count - 1)
            strID = txtID.Text
            BindingContext(dsOwners, "Owners").EndCurrentEdit()
            BindingContext(dsOwners, "Owners").AddNew()
            txtID.Text = CStr(CInt(strID) + 1)
        End If

        'Turn Off Foward and Last Buttons
        btnForward.Enabled = False
        btnLast.Enabled = False

        'Turn On Edit Mode
        ToggleEditMode()

        'Reset the Data Grid View for Currently Selected ID
        ResetOwnedVehicles(txtID.Text, False)

        'Focus the First Text Box in Tab Order
        txtFirstName.Focus()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnDelete_Click          -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Button is Clicked.–
    '- Prompts the user "Are you sure?". If Yes, then the current-
    '- record is deleted along with dependancies.               -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- DBcmd - SQL Command object for the command               -
    '- strSQLcmd - the String containing the SQL Command DELETE -
    '------------------------------------------------------------
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        '-Local Variables-
        'Define the String for SQL Queries
        Dim strSQLcmd As String
        'Command Object for NonQuery of DELETE
        Dim DBcmd As New SqlCommand

        If MessageBox.Show("Are you sure you want to permenantly delete this record and " &
            "all dependencies? ", "Confirm Delete", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.Yes Then
            'Open Connection
            DBConn.Open()

            'Delete Main Record
            DBcmd.CommandText = "DELETE FROM Owners WHERE TUID='" & txtID.Text & "'"
            DBcmd.Connection = DBConn
            DBcmd.ExecuteNonQuery()

            'Delete Dependant Records
            DBcmd.CommandText = "DELETE FROM Vehicles WHERE OwnerID='" & txtID.Text & "'"
            DBcmd.ExecuteNonQuery()

            'Done with Deleting so Close Connection
            DBConn.Close()

            'Clear Owners Dataset
            dsOwners.Clear()

            'Select All Fields of Owners
            strSQLcmd = "SELECT * FROM Owners"
            DBAdaptOwners = New SqlDataAdapter(strSQLcmd, DBConn)
            DBAdaptOwners.Fill(dsOwners, "Owners")

            'Resets to first record
            BindingContext(dsOwners, "Owners").Position = 0

            'Refreshes the Owner vehicles
            ResetOwnedVehicles(txtID.Text, False)

            'Notifies of Successful Deletion
            MessageBox.Show("Record and Dependancies Successfully Deleted!", "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'If Table is Empty, Show a Message Stating that the form cannot exist without at least one record. Prompt The User to Input a new record.
            If dsOwners.Tables("Owners").Rows.Count <= 0 Then
                If MessageBox.Show("Warning! The owners table is empty. Please enter a new owner's information.", "Table Empty", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.Cancel Then
                    'If he presses Cancel, a new mesage will tell the user that the form will close.
                    MessageBox.Show("You have selected to not enter any new information when the Owner's Table is empty. The application cannot continue and must terminate.", "Program Termination", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                Else
                    'Call the Add Rountine
                    btnAdd_Click(sender, e)
                End If
            End If
        End If

        'Reset Nav Buttons
        DoNavButtons()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnUpdate_Click          -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Button is Clicked.–
    '- Define the update command and open the form for updating.-
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- cmdBuilder - SQL Command Builder for Update              -
    '------------------------------------------------------------
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        '-Local Variables-
        'Command Builder Object for Building UPDATE Command
        Dim cmdBuilder As SqlCommandBuilder

        'Bind to Owners and set Update command
        cmdBuilder = New SqlCommandBuilder(DBAdaptOwners)
        DBAdaptOwners.UpdateCommand = cmdBuilder.GetUpdateCommand

        'Turn on Edit Mode
        ToggleEditMode()
    End Sub

    '--Edit Mode Commands--
    '------------------------------------------------------------
    '-                Subprogram Name: btnSave_Click             -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Button is Clicked.–
    '- Checks for Bad Input. If Good, it will perform Add/Update.-
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Checks for Empty Text Boxes
        If (txtFirstName.Text = "" Or txtFirstName.Text = Nothing) Or
            (txtLastName.Text = "" Or txtLastName.Text = Nothing) Or
            (txtStreet.Text = "" Or txtStreet.Text = Nothing) Or
            (txtCity.Text = "" Or txtCity.Text = Nothing) Or
            (txtState.Text = "" Or txtState.Text = Nothing) Or
            (txtZip.Text = "" Or txtZip.Text = Nothing) Then
            MessageBox.Show("Warning! Some Textboxes are Empty. " &
                            "Please Enter Data For All Text Boxes!", "System Warning",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf Not IsNumeric(txtZip.Text) Then
            MessageBox.Show("Warning! Zip Code is Not Numeric, Please Enter a Numeric " &
                            "Zip Code!" & vbCrLf & "eg. 48371", "System Warning",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtZip.Focus()
        Else
            'Editing is Complete
            BindingContext(dsOwners, "Owners").EndCurrentEdit()

            'Open Database Connection, Update and Close
            DBConn.Open()
            DBAdaptOwners.Update(dsOwners, "Owners")
            DBConn.Close()

            'Accept The Changes in the Dataset
            dsOwners.AcceptChanges()

            'Turn Off Edit Mode
            ToggleEditMode()

            'Reset the Data Grid View for Currently Selected ID
            ResetOwnedVehicles(txtID.Text, False)

            'Reset Nav Button Layout
            DoNavButtons()

            'Notify that operation is successful
            MessageBox.Show("Add/Update Successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnCancel_Click          -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Button is Clicked.–
    '- Cancels the Current Add or Update Operation.             -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Checks for Nothing in the Data Table
        If dsOwners.Tables("Owners").Rows.Count <= 0 Then
            MessageBox.Show("The Table Cannot Be Empty, Please Enter Owner Data!", "Owner Table Empty", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            'Cancel what is being Edited
            BindingContext(dsOwners, "Owners").CancelCurrentEdit()

            'Turn Off Edit Mode
            ToggleEditMode()

            'Reset the Data Grid View for Currently Selected ID
            ResetOwnedVehicles(txtID.Text, False)

            'Reset Nav Button Layout
            DoNavButtons()
        End If
    End Sub
End Class