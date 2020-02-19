'------------------------------------------------------------
'-                File Name : frmNewOrder.frm               - 
'-                Part of Project: Assignment 2             -
'------------------------------------------------------------
'-                Written By: Austin Sliter                 -
'-                Written On: 1/29/18                       -
'------------------------------------------------------------
'- File Purpose:                                            -
'- This file contains the main application form where the   -
'- user will input data from the controls which will assign -
'- the data immediately to transferrable global variables.  -
'- When the command button is pressed, the second form will -
'- appear which will generate the output and give command   -
'- options for exit, return to editing or submit.           - 
'------------------------------------------------------------
'- Program Purpose:                                         -
'-                                                          -
'- This program will assign user data immediately to        -
'- transferrable global variables. When the command button  -
'- is pressed, the second form will appear which will       -
'- generate the output and give command options for exit,   -
'- return to editing or submit.                             -
'------------------------------------------------------------
'- Global Variable Dictionary (alphabetically):             -
'- blnFirstFormActivate - True When Form is First Activated -
'- blnFrmInvoiceActive - True When Other form is Active     -
'- blnFrmInvoiceDetected - True When other form was first   -
'-                          found                           -
'- blnFrmInvoiceClosed -  True When other form is closed    -
'- intCarsQty – Quantity of Custom Cars selected.           –
'- intSelNumOptions – Quantity of Options selected.         –
'- sngSelCarTypCst – Cost of Base Car type selected.        –
'- sngSelDriveTrnCst – Cost of Drive Train type selected.   –
'- sngTotOptPrice – Cost of all Options selected.           –
'- strCustName - Customer Name                              -
'- strOptionsLst - Built String containing Selected Options -
'- strSelCarTyp - Selected Base Car Type                    -
'- strSelDriveTrn - Selected Drive Train                    -
'------------------------------------------------------------

Imports System.ComponentModel

Public Class frmNewOrder
    '---Constants---
    '--Base Car Type--
    '-Numeric-
    Private Const sngCOUPE As Single = 10000
    Private Const sngSEDAN As Single = 17000
    Private Const sngLUXURY As Single = 20000
    Private Const sngSPORT_ED As Single = 25000
    Private Const sngSUV As Single = 27000

    '-String-
    Private Const strCOUPE As String = "Coupe"
    Private Const strSEDAN As String = "Sedan"
    Private Const strLUXURY As String = "Luxury"
    Private Const strSPORT_ED As String = "Sports Edition"
    Private Const strSUV As String = "SUV"

    '--Drivetrain--
    '-Numeric-
    Private Const sngV4 As Single = 500
    Private Const sngV6 As Single = 1000
    Private Const sngV8 As Single = 2500
    Private Const sngV12 As Single = 7500
    Private Const sngHYBRID As Single = 3000
    Private Const sngELECTRIC As Single = 6000

    '-String-
    Private Const strV4 As String = "V-4"
    Private Const strV6 As String = "V-6"
    Private Const strV8 As String = "V-8"
    Private Const strV12 As String = "V-12"
    Private Const strHYBRID As String = "Hybrid"
    Private Const strELECTRIC As String = "Electric"

    '--Options Flat Rate--
    Private Const sngOPTIONRATE As Single = 750

    '-Option Strings-
    Private Const strLETHSEAT As String = "Leather Seats"
    Private Const strAC As String = "Air Conditioning"
    Private Const strBLUETOOTH As String = "Bluetooth"
    Private Const strHOTSEATS As String = "Heated Seats"
    Private Const strPREMSTEREO As String = "Premium Stereo"
    Private Const strGPS As String = "GPS"
    Private Const strREARDEFROSTER As String = "Rear Defroster"
    Private Const strCD_MP3 As String = "CD/MP3 Connections"
    Private Const strENTERTAINMENT As String = "Entertainment Package"

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
    Private blnFirstFormActivate As Boolean = True
    Private blnFrmInvoiceActive As Boolean
    Private blnFrmInvoiceDetected As Boolean
    Public blnFrmInvoiceClosed As Boolean = False

    '------------------------------------------------------------
    '-                Subprogram Name: frmNewOrder_Activated    -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the form is activated -
    '- Invoice form switch boolean is made false while checking -
    '- if first time event. If so puts the default data into the-
    '- list box. Trys to find the second form. If it exists it  -
    '- sets both booleans for the form being detected and active-
    '- to true while checking for the submit button on the other-
    '- form to being clicked. If no it returns the form to it's -
    '- previous settings. if yes, It clears the form to it's    -
    '- defaults.                                                -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- intCount - counter for For Loop.                         -
    '------------------------------------------------------------

    Private Sub frmNewOrder_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'makes sure the invoice boolean is ready
        blnFrmInvoiceDetected = False
        'if it is the first time, then select defaults and set the first time boolean to false
        If blnFirstFormActivate Then
            lstBaseCar.SelectedItem = strCOUPE
            blnFirstFormActivate = False
        End If
        'Find the invoice form
        For Each frm As Form In Application.OpenForms
            If frm.Name.Equals("frmInvoice") Then
                'Form invoice exists and has been detected
                blnFrmInvoiceActive = True
                blnFrmInvoiceDetected = True
                'If submit button on form invoice is not clicked
                If Not frmInvoice.blnSubmitClicked Then
                    'Repopulate user data and variables
                    sngSelCarTypCst = frmInvoice.sngSelCarTypCst
                    intCarsQty = frmInvoice.intCarsQty
                    sngSelDriveTrnCst = frmInvoice.sngSelDriveTrnCst
                    intSelNumOptions = frmInvoice.intSelNumOptions
                    sngTotOptPrice = frmInvoice.sngTotOptPrice
                    strCustName = frmInvoice.strCustName
                    strSelCarTyp = frmInvoice.strSelCarTyp
                    strSelDriveTrn = frmInvoice.strSelDriveTrn
                    strOptionsLst = frmInvoice.strOptionsLst
                    Dim arrString() As String = strOptionsLst.Split(vbCrLf & vbTab)
                    For intCount As Integer = 0 To intSelNumOptions - 1
                        Select Case arrString(intCount)
                            Case strLETHSEAT : chkLethSeat.Checked = True
                            Case strAC : chkAC.Checked = True
                            Case strBLUETOOTH : chkBluetooth.Checked = True
                            Case strHOTSEATS : chkHotSeats.Checked = True
                            Case strHOTSEATS : chkPremStereo.Checked = True
                            Case strHOTSEATS : chkGPS.Checked = True
                            Case strREARDEFROSTER : chkRearDefroster.Checked = True
                            Case strCD_MP3 : chkCD_MP3.Checked = True
                            Case strENTERTAINMENT : chkEntertainment.Checked = True
                        End Select
                    Next
                    Select Case strSelDriveTrn
                        Case strV4 : radV4.Checked = True
                        Case strV6 : radV6.Checked = True
                        Case strV8 : radV8.Checked = True
                        Case strV12 : radV12.Checked = True
                        Case strHYBRID : radHyb.Checked = True
                        Case strELECTRIC : radElectr.Checked = True
                    End Select
                    nudQuantity.Value = intCarsQty
                    txtCustName.Text = strCustName
                    lstBaseCar.SelectedItem = strSelCarTyp
                Else 'if clicked
                    'return form to default values
                    chkLethSeat.Checked = False
                    chkAC.Checked = False
                    chkBluetooth.Checked = False
                    chkHotSeats.Checked = False
                    chkPremStereo.Checked = False
                    chkGPS.Checked = False
                    chkRearDefroster.Checked = False
                    chkCD_MP3.Checked = False
                    chkEntertainment.Checked = False
                    radV4.Checked = True
                    radV6.Checked = False
                    radV8.Checked = False
                    radV12.Checked = False
                    radHyb.Checked = False
                    nudQuantity.Value = 1
                    txtCustName.Text = ""
                    lstBaseCar.SelectedItem = strCOUPE
                End If
            Else 'if any other form is detected
                'if invoice was detected
                If blnFrmInvoiceDetected Then
                    'remain true
                    blnFrmInvoiceActive = True
                Else 'otherwise
                    'change to false
                    blnFrmInvoiceActive = False
                End If
            End If
        Next
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: getCarTypePrice          -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the base car list box -
    '- is changed. Based on the  list box selection, makes the  -
    '- cost equal to the constant for that base car type.       -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- strCarType - The Base Car Type                           -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub getCarTypePrice(ByVal strCarTyp As String)
        'based on the string found, assign an integer constant for that string to the selected car type
        Select Case strCarTyp
            Case strCOUPE : sngSelCarTypCst = sngCOUPE
            Case strSEDAN : sngSelCarTypCst = sngSEDAN
            Case strLUXURY : sngSelCarTypCst = sngLUXURY
            Case strSPORT_ED : sngSelCarTypCst = sngSPORT_ED
            Case strSUV : sngSelCarTypCst = sngSUV
        End Select
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: buildOptionString        -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever an Option checkbox is -
    '- checked. Checks all checkboxes for checked=true and adds -
    '- cost constant, 1 to number of options and the string to  -
    '- the appropriate global transfer variables.               -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub buildOptionString()
        'reset transfer variables each time it is called
        strOptionsLst = ""
        intSelNumOptions = 0
        sngTotOptPrice = 0
        'for each "hit" options price is increased by a flat amount (750), number of options increases and the string is added to the built string
        If chkLethSeat.Checked Then
            strOptionsLst &= vbCrLf & vbTab & strLETHSEAT
            intSelNumOptions += 1
            sngTotOptPrice += sngOPTIONRATE
        End If
        If chkAC.Checked Then
            strOptionsLst &= vbCrLf & vbTab & strAC
            intSelNumOptions += 1
            sngTotOptPrice += sngOPTIONRATE
        End If
        If chkBluetooth.Checked Then
            strOptionsLst &= vbCrLf & vbTab & strBLUETOOTH
            intSelNumOptions += 1
            sngTotOptPrice += sngOPTIONRATE
        End If
        If chkHotSeats.Checked Then
            strOptionsLst &= vbCrLf & vbTab & strHOTSEATS
            intSelNumOptions += 1
            sngTotOptPrice += sngOPTIONRATE
        End If
        If chkPremStereo.Checked Then
            strOptionsLst &= vbCrLf & vbTab & strPREMSTEREO
            intSelNumOptions += 1
            sngTotOptPrice += sngOPTIONRATE
        End If
        If chkGPS.Checked Then
            strOptionsLst &= vbCrLf & vbTab & strGPS
            intSelNumOptions += 1
            sngTotOptPrice += sngOPTIONRATE
        End If
        If chkRearDefroster.Checked Then
            strOptionsLst &= vbCrLf & vbTab & strREARDEFROSTER
            intSelNumOptions += 1
            sngTotOptPrice += sngOPTIONRATE
        End If
        If chkCD_MP3.Checked Then
            strOptionsLst &= vbCrLf & vbTab & strCD_MP3
            intSelNumOptions += 1
            sngTotOptPrice += sngOPTIONRATE
        End If
        If chkEntertainment.Checked Then
            strOptionsLst &= vbCrLf & vbTab & strENTERTAINMENT
            intSelNumOptions += 1
            sngTotOptPrice += sngOPTIONRATE
        End If
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: nudQuantity_ValueChanged -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the number up/down    -
    '- control is changed. Sets that value to the transfer var. -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub nudQuantity_ValueChanged(sender As Object, e As EventArgs) Handles nudQuantity.ValueChanged
        'when changed the variable changes too
        intCarsQty = nudQuantity.Value
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: nudQuantity_ValueChanged -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the list box selected -
    '- item is changed. Sets that value to the transfer var and -
    '- calls the setCarTypePrice subroutine.                    -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub lstBaseCar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstBaseCar.SelectedIndexChanged
        'when changed the string and int value change to their selected values
        strSelCarTyp = lstBaseCar.SelectedItem
        'call function based on params of current item
        getCarTypePrice(strSelCarTyp)
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: radV4_CheckedChanged     -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Radio Button is   -
    '- checked. Sets that value (integer and string) to the     -
    '- transfer variable.                                       -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub radV4_CheckedChanged(sender As Object, e As EventArgs) Handles radV4.CheckedChanged
        'make selection string and int value equal to the corresponding constants
        strSelDriveTrn = strV4
        sngSelDriveTrnCst = sngV4
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: radV6_CheckedChanged     -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Radio Button is   -
    '- checked. Sets that value (integer and string) to the     -
    '- transfer variable.                                       -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub radV6_CheckedChanged(sender As Object, e As EventArgs) Handles radV6.CheckedChanged
        'make selection string and int value equal to the corresponding constants
        strSelDriveTrn = strV6
        sngSelDriveTrnCst = sngV6
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: radV8_CheckedChanged     -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Radio Button is   -
    '- checked. Sets that value (integer and string) to the     -
    '- transfer variable.                                       -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub radV8_CheckedChanged(sender As Object, e As EventArgs) Handles radV8.CheckedChanged
        'make selection string and int value equal to the corresponding constants
        strSelDriveTrn = strV8
        sngSelDriveTrnCst = sngV8
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: radV12_CheckedChanged     -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Radio Button is   -
    '- checked. Sets that value (integer and string) to the     -
    '- transfer variable.                                       -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub radV12_CheckedChanged(sender As Object, e As EventArgs) Handles radV12.CheckedChanged
        'make selection string and int value equal to the corresponding constants
        strSelDriveTrn = strV12
        sngSelDriveTrnCst = sngV12
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: radHyb_CheckedChanged    -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Radio Button is   -
    '- checked. Sets that value (integer and string) to the     -
    '- transfer variable.                                       -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub radHyb_CheckedChanged(sender As Object, e As EventArgs) Handles radHyb.CheckedChanged
        'make selection string and int value equal to the corresponding constants
        strSelDriveTrn = strHYBRID
        sngSelDriveTrnCst = sngHYBRID
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: radElectr_CheckedChanged -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Radio Button is   -
    '- checked. Sets that value (integer and string) to the     -
    '- transfer variable.                                       -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub radElectr_CheckedChanged(sender As Object, e As EventArgs) Handles radElectr.CheckedChanged
        'make selection string and int value equal to the corresponding constants
        strSelDriveTrn = strELECTRIC
        sngSelDriveTrnCst = sngELECTRIC
    End Sub

    '------------------------------------------------------------
    '-             Subprogram Name: chkLethSeats_CheckedChanged -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Checkbox is       -
    '- checked. Calls the buildOptionString subroutine.         -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub chkLethSeat_CheckedChanged(sender As Object, e As EventArgs) Handles chkLethSeat.CheckedChanged
        buildOptionString()
    End Sub

    '------------------------------------------------------------
    '-             Subprogram Name: chkAC_CheckedChanged        -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Checkbox is       -
    '- checked. Calls the buildOptionString subroutine.         -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub chkAC_CheckedChanged(sender As Object, e As EventArgs) Handles chkAC.CheckedChanged
        buildOptionString()
    End Sub

    '------------------------------------------------------------
    '-             Subprogram Name: chkBluetooth_CheckedChanged -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Checkbox is       -
    '- checked. Calls the buildOptionString subroutine.         -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub chkBluetooth_CheckedChanged(sender As Object, e As EventArgs) Handles chkBluetooth.CheckedChanged
        buildOptionString()
    End Sub

    '------------------------------------------------------------
    '-             Subprogram Name:  chkHotSeats_CheckedChanged -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Checkbox is       -
    '- checked. Calls the buildOptionString subroutine.         -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub chkHotSeats_CheckedChanged(sender As Object, e As EventArgs) Handles chkHotSeats.CheckedChanged
        buildOptionString()
    End Sub

    '------------------------------------------------------------
    '-            Subprogram Name: chkPremStereo_CheckedChanged -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Checkbox is       -
    '- checked. Calls the buildOptionString subroutine.         -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub chkPremStereo_CheckedChanged(sender As Object, e As EventArgs) Handles chkPremStereo.CheckedChanged
        buildOptionString()
    End Sub

    '------------------------------------------------------------
    '-             Subprogram Name: chkGPS_CheckedChanged       -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Checkbox is       -
    '- checked. Calls the buildOptionString subroutine.         -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub chkGPS_CheckedChanged(sender As Object, e As EventArgs) Handles chkGPS.CheckedChanged
        buildOptionString()
    End Sub

    '------------------------------------------------------------
    '-         Subprogram Name: chkRearDefroster_CheckedChanged -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Checkbox is       -
    '- checked. Calls the buildOptionString subroutine.         -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub chkRearDefroster_CheckedChanged(sender As Object, e As EventArgs) Handles chkRearDefroster.CheckedChanged
        buildOptionString()
    End Sub

    '------------------------------------------------------------
    '-             Subprogram Name: chkCD_MP3_CheckedChanged    -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Checkbox is       -
    '- checked. Calls the buildOptionString subroutine.         -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub chkCD_MP3_CheckedChanged(sender As Object, e As EventArgs) Handles chkCD_MP3.CheckedChanged
        buildOptionString()
    End Sub

    '------------------------------------------------------------
    '-         Subprogram Name: chkEntertainment_CheckedChanged -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Checkbox is       -
    '- checked. Calls the buildOptionString subroutine.         -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub chkEntertainment_CheckedChanged(sender As Object, e As EventArgs) Handles chkEntertainment.CheckedChanged
        buildOptionString()
    End Sub

    '------------------------------------------------------------
    '-             Subprogram Name: btnPlaceOrder_Click         -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the button  is        -
    '- pressed. If customer name is not empty, then hide this   -
    '- form and show the other one; else show a warning message.-
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnPlaceOrder_Click(sender As Object, e As EventArgs) Handles btnPlaceOrder.Click
        'if customer name is not blank
        If Not txtCustName.Text = "" Then
            'Get Name
            strCustName = txtCustName.Text
            'Open and Generate Invoice while hiding current form
            Me.Hide()
            frmInvoice.Show()
        Else
            'Otherwise show an error message that you must enter a name
            MessageBox.Show("Attention! You Must Enter a Name.", "Systen Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    '------------------------------------------------------------
    '-             Subprogram Name: frmNewOrder_Closing         -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 1/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the form is closing.  -
    '- If the other form has closed (bln), then close this form -
    '- else show a warning message and cancel closing.          -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub frmNewOrder_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If blnFrmInvoiceClosed Then 'This bool is changed by the invoice form. If true
            e.Cancel = False 'close this form
        Else 'otherwise it is an unauthorized closure and show a message box saying "you can't do that"
            e.Cancel = True
            MessageBox.Show("Attention! The application cannot be closed from here. Click 'Place Car(s) Order' to go to the Invoice Screen. There, you can close the application.", "System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class