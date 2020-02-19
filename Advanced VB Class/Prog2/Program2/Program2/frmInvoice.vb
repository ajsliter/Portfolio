'------------------------------------------------------------
'-                File Name : frmNewOrder.frm               - 
'-                Part of Project: Assignment 2             -
'------------------------------------------------------------
'-                Written By: Austin Sliter                 -
'-                Written On: 1/29/18                       -
'------------------------------------------------------------
'- File Purpose:                                            -
'- This file contains the output application form where the -
'- form will generate the output and give command options   -
'- for exit, return to editing or submit. Submit will zero  -
'- the other form and call it, Exit will exit the form after-
'- a Yes/No Prompt, Return to editing will show the other   - 
'- form with the old data on it.                            - 
'------------------------------------------------------------
Imports System.ComponentModel

Public Class frmInvoice
    '---Global Variables (Transferred between forms)---
    '--Numeric--
    Public sngSelCarTypCst As Single = 0
    Public intCarsQty As Integer = 1
    Public sngSelDriveTrnCst As Single = 0
    Public intSelNumOptions As Integer = 0
    Public sngTotOptPrice As Single = 0

    '--String--
    Public strCustName As String = ""
    Public strSelCarTyp As String = ""
    Public strSelDriveTrn As String = ""
    Public strOptionsLst As String = ""

    '--Boolean--
    Public blnSubmitClicked As Boolean

    '--Form Variables--
    Private sngVehicleTotal As Single = 0
    Private sngGrandTotal As Single = 0

    '------------------------------------------------------------
    '-             Subprogram Name: calcVehicleTotal            -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This function is called from frmInvoice_Activated event. -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Returns:                                                 -
    '- Single – Per Vehicle Total Cost                          -
    '------------------------------------------------------------
    Function calcVehicleTotal() As Single
        Return sngTotOptPrice + sngSelCarTypCst + sngSelDriveTrnCst
    End Function

    '------------------------------------------------------------
    '-             Subprogram Name: calcGrandTotal              -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This function is called from frmInvoice_Activated event. -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Returns:                                                 -
    '- Single – Grand Total Cost                                -
    '------------------------------------------------------------
    Function calcGrandTotal() As Single
        Return sngVehicleTotal * intCarsQty
    End Function

    '------------------------------------------------------------
    '-                Subprogram Name: buildOutputString_Print  -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the form is activated -
    '- Determines the type of drivetrain for the other variable.-
    '- builds the output string and then assigns it to textbox. -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- strDashSeparator - contains 70 '-' characters            -
    '- strEqualsSeparator - contains 80 '=' characters          -
    '- strDrivetrainType - Will Contain type Engine or System   -
    '- strHeader - contains the default header for the output   -
    '- strOutput - The Full Output String for the Text Box      -
    '------------------------------------------------------------
    Private Sub buildOutputString_Print()
        '--Local Variables--
        Dim strOutput As String = ""
        Dim strEqualsSeparator As String = "================================================================================"
        Dim strDashSeparator As String = "----------------------------------------------------------------------"
        Dim strHeader As String = strEqualsSeparator & vbCrLf &
            Space(31) & "Kustom Karz Order" & Space(31) & vbCrLf &
            strEqualsSeparator & vbCrLf & vbCrLf
        Dim strDrivetrainType As String = ""

        'Select the correct string for the specific drivetrain
        If String.Equals("V-4", strSelDriveTrn) Or String.Equals("V-6", strSelDriveTrn) Or String.Equals("V-8", strSelDriveTrn) Or String.Equals("V-12", strSelDriveTrn) Then
            strDrivetrainType = " Engine"
        Else
            strDrivetrainType = " System"
        End If

        'build output string
        strOutput = strHeader & "Getting ready to kustom manufacture for " & strCustName & "." & vbCrLf & vbCrLf &
            "There will be " & intCarsQty & " car(s) kustom built." & vbCrLf & vbCrLf &
            "Your Car Form Factor is a " & strSelCarTyp & " at " & sngSelCarTypCst.ToString("C") & vbCrLf & vbCrLf &
            "Your drive train is a " & strSelDriveTrn & strDrivetrainType & " at " & sngSelDriveTrnCst.ToString("C") & vbCrLf & vbCrLf &
            "Here are the Options Requested:" &
            strOptionsLst & vbCrLf &
            intSelNumOptions & " Option(s) selected for a total of " & sngTotOptPrice.ToString("C") & vbCrLf & vbCrLf & vbCrLf &
            "Per Vehicle Total: " & vbTab & sngVehicleTotal.ToString("C") & vbCrLf &
            strDashSeparator & vbCrLf &
            "Quantity Ordered: " & vbTab & intCarsQty & vbCrLf &
            strDashSeparator & vbCrLf &
            "Grand Total: " & vbTab & vbTab & sngGrandTotal.ToString("C") & vbCrLf & vbCrLf &
            strEqualsSeparator
        'Assign output string to output multi line text box
        txtInvoice.Text = strOutput
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: frmInvoice_Activated     -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the form is activated -
    '- Transfers the values from the other form to be worked on.-
    '- Calculates vehicle total and grand totals, then builds   -
    '- the string and spits it out into the text box.           -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub frmInvoice_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'submit for this instance have not been clicked yet so reset this variable
        blnSubmitClicked = False

        'Import variables from New Order Form
        sngSelCarTypCst = frmNewOrder.sngSelCarTypCst
        intCarsQty = frmNewOrder.intCarsQty
        sngSelDriveTrnCst = frmNewOrder.sngSelDriveTrnCst
        intSelNumOptions = frmNewOrder.intSelNumOptions
        sngTotOptPrice = frmNewOrder.sngTotOptPrice
        strCustName = frmNewOrder.strCustName
        strSelCarTyp = frmNewOrder.strSelCarTyp
        strSelDriveTrn = frmNewOrder.strSelDriveTrn
        strOptionsLst = frmNewOrder.strOptionsLst

        'calculate and return variables
        sngVehicleTotal = calcVehicleTotal()
        sngGrandTotal = calcGrandTotal()

        'Build and output string
        buildOutputString_Print()
    End Sub

    '------------------------------------------------------------
    '-             Subprogram Name: btnOrderChng_Click          -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the button  is        -
    '- pressed. Hides current form and shows other one.         -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnOrderChng_Click(sender As Object, e As EventArgs) Handles btnOrderChng.Click
        'hides the invoice form and shows the New Order form with current user data
        Me.Hide()
        frmNewOrder.Show()
        frmNewOrder.BringToFront()
    End Sub

    '------------------------------------------------------------
    '-             Subprogram Name: btnSubmit_Click             -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the button  is        -
    '- pressed. Hides current form and shows other one while    -
    '- notifying user of success and changing submit bool to true-
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        'shows a message box that the order is sent successfully and lets the other form know that the submit button has been clicked
        MessageBox.Show("Order Sent to Manufacturing Department!", "Order Sent", MessageBoxButtons.OK, MessageBoxIcon.Information)
        blnSubmitClicked = True
        'hides the invoice form and shows the new order form with no data in the boxes
        Me.Hide()
        frmNewOrder.Show()
        frmNewOrder.BringToFront()
    End Sub

    '------------------------------------------------------------
    '-             Subprogram Name: btnExit_Click               -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the button  is        -
    '- pressed. Closes the form.                                -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'initiates the form close command
        Me.Close()
    End Sub

    '------------------------------------------------------------
    '-             Subprogram Name: frmInvoice_Closing          -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the form is closing.  -
    '- asks if user wants to exit. if yes closes both forms; else-
    '- cancels form close.                                       -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- drDiagres - Dialog result of the messagebox              -
    '------------------------------------------------------------
    Private Sub frmInvoice_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Local Variable and performing exit prompt
        Dim drDiagres As DialogResult = MessageBox.Show("Are you sure you want to quit?", "Kustom Karz Order System", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        'If dialog result is yes then both forms close
        If drDiagres = DialogResult.Yes Then
            e.Cancel = False
            frmNewOrder.blnFrmInvoiceClosed = True
            frmNewOrder.Close()
        Else 'otherwise do not allow the forms to close
            e.Cancel = True
        End If
    End Sub
End Class