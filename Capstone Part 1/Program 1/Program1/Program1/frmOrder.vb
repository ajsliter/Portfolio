'------------------------------------------------------------
'-                File Name : frmOrder                     - 
'-                Part of Project: Assignment 1           -
'------------------------------------------------------------
'-                Written By: Austin Sliter                 -
'-                Written On: 8/30/18                       -
'------------------------------------------------------------
'- File Purpose:                                            -
'- This file contains the MDI Child Form that contains Fields-
'- where the user will input order information. When the user-
'- clicks the calculate button it will perform Subtotal,    -
'- Discount, Tax and Grand Total Calculations. It also has  -
'- a Clear Button where you can reuse the Order Form if need-
'- be instead of creating another one.                      - 
'------------------------------------------------------------
Public Class frmOrder
    '---Global Constants---
    '--Meals--
    Private Const dblSTD_MEAL As Double = 8.5
    Private Const dblDLXE_MEAL As Double = 10

    '--Sales Tax (6% in Michigan)--
    Private Const dblTAX As Double = 0.06

    '---Program Events---
    '------------------------------------------------------------
    '-            Subprogram Name: InputTextBoxes_TextChanged   -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 8/30/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever The Primary Text Boxes- 
    '- are Changed. If the text property of these text boxes are-
    '- not empty, enable the clear button as form is dirty.     –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub InputTxtBoxes_TextChanged(sender As Object, e As EventArgs) Handles txtFName.TextChanged, txtLName.TextChanged, mtbMidInitial.TextChanged, mtbPhone.TextChanged
        If txtFName.Text <> "" Or txtLName.Text <> "" Or mtbPhone.MaskCompleted Or mtbMidInitial.Text <> "" Then
            'Enable Clear Button, Form Considered Dirty.
            btnClear.Enabled = True
        End If
    End Sub

    '------------------------------------------------------------
    '-            Subprogram Name: btnClear_Click               -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 8/30/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever button is clicked.    -
    '- Resets Everything on the Form to default values.         –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'Disables All Buttons
        btnClear.Enabled = False

        'Reset Numeric Up Downs
        nudDiscPerc.Value = 0
        nudMeals.Value = 1

        'Clears All Text Boxes
        txtFName.Clear()
        txtLName.Clear()
        mtbMidInitial.Clear()
        mtbPhone.Clear()
        txtTotals.Clear()
        txtFName.Focus()

        'Unchecks the Discount Checkbox
        chkDiscount.Checked = False
    End Sub

    '------------------------------------------------------------
    '-            Subprogram Name: btnCalc_Click                -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 8/30/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the button is clicked.-
    '- After clearing the output textbox; gathers all information-
    '- needed from form, Calculates Subtotal, Discounts         -
    '- (if applicable), Tax and Grand Total. Displays the Results-
    '- into the Text Box.                                       –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- dblDiscountAmt - The Amount to subtract from Subtotal for-
    '-                  discounts.                              -
    '- dblDiscountPerc - Percentage of Discount (from Form).    -
    '- dblDiscountedTotal - The Total after Discount is Applied.-
    '- dblGrandTotal - The Total after Discounts and Tax are    -
    '-                 Applied.                                 -
    '- dblSubtotal - The Initial Total after the number of meals-
    '-               and the meal type price are multiplied.    -
    '- dblTaxCollected - The Amount of Tax to add to the Current-
    '-                   Total.                                 -
    '- intNumOrders - The Number of Meals (from Form)           -
    '------------------------------------------------------------
    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        '-Local Variables-
        'Calculated 
        Dim dblDiscountAmt As Double
        Dim dblDiscountedTotal As Double
        Dim dblGrandTotal As Double
        Dim dblSubtotal As Double
        Dim dblTaxCollected As Double
        'Gathered from Form
        Dim dblDiscountPerc As Double
        Dim intNumOrders As Integer

        'Clear anything old out of the text box
        txtTotals.Clear()

        If IsValidFields() Then
            'Gather Current Values from the Fields
            intNumOrders = nudMeals.Value
            'Depending on the Meal Type, reiterate the Order and the Price for each Meal
            If radStandard.Checked Then
                txtTotals.Text = "Your Order: " & intNumOrders & " Standard Meal(s) for " & dblSTD_MEAL.ToString("C") & vbCrLf
            Else
                txtTotals.Text = "Your Order: " & intNumOrders & " Deluxe Meal(s) for " & dblDLXE_MEAL.ToString("C") & vbCrLf
            End If
            'Only if Discout is Used, will it be retrieved
            If chkDiscount.Checked Then
                dblDiscountPerc = CDbl(nudDiscPerc.Value) / 100.0
            End If
            'Get Subtotal
            dblSubtotal = CalcSubtotal(intNumOrders)
            txtTotals.Text &= "Subtotal: " & dblSubtotal.ToString("C") & vbCrLf
            If chkDiscount.Checked Then
                dblDiscountAmt = CalcDiscountAmt(dblSubtotal, dblDiscountPerc)
                dblDiscountedTotal = dblSubtotal - dblDiscountAmt
                dblTaxCollected = CalcTaxCollected(dblDiscountedTotal)
                dblGrandTotal = dblDiscountedTotal + dblTaxCollected
                txtTotals.Text &= "Subtotal Due to Discount: " & dblDiscountedTotal.ToString("C") & " | You Save: " & dblDiscountAmt.ToString("C") & "!" & vbCrLf
                txtTotals.Text &= "Tax to be Collected: " & dblTaxCollected.ToString("C") & vbCrLf
                txtTotals.Text &= "Grand Total: " & dblGrandTotal.ToString("C")
            Else
                dblTaxCollected = CalcTaxCollected(dblSubtotal)
                dblGrandTotal = dblSubtotal + dblTaxCollected
                txtTotals.Text &= "Tax to be Collected: " & dblTaxCollected.ToString("C") & vbCrLf
                txtTotals.Text &= "Grand Total: " & dblGrandTotal.ToString("C")
            End If
        End If
    End Sub

    '------------------------------------------------------------
    '-            Subprogram Name: chkDiscount_CheckChanged     -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 8/30/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever state of the discount - 
    '- Checkbox is Changed. If it is checked, the amount controls-
    '- should be shown, else hide them.                         –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub chkDiscount_CheckedChanged(sender As Object, e As EventArgs) Handles chkDiscount.CheckedChanged
        If chkDiscount.Checked Then
            grpDiscAmt.Visible = True
        Else
            grpDiscAmt.Visible = False
        End If
    End Sub

    'Application Functions
    '------------------------------------------------------------
    '-            Subprogram Name: IsValidFields                -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 8/30/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the btnCalc_Click Event- 
    '- is Called. If any field is invalid, it will show a message-
    '- and not allow you to calculate.                          –
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
    '- Boolean – Letting the btnCalc Event that the fields are  -
    '-           valid or not.                                  -
    '------------------------------------------------------------
    Private Function IsValidFields() As Boolean
        'Determines if the fields for contact info are valid
        'Check if phone is correct and not missing any digits
        If Not mtbPhone.MaskCompleted Then
            MessageBox.Show("Phone Number Incomplete or Empty! Please correct the Phone Number field and try again.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
            mtbPhone.Focus()
            Return False
        End If
        'Last Name is Not Empty or contains non-alpha characters
        If txtLName.Text = "" Then
            MessageBox.Show("Last Name is a Required Field! Please Enter a Last Name.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLName.Focus()
            Return False
        ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(txtLName.Text, "^[a-zA-Z]+$") Then
            MessageBox.Show("Non-alpha characters are not allowed in the Last Name field! Please correct the Last Name field and try again.", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLName.Focus()
            Return False
        End If
        'Middle Initial is not empty
        If mtbMidInitial.Text = "" Then
            MessageBox.Show("Middle Initial is a Required Field! Please Enter a Middle Initial.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            mtbMidInitial.Focus()
            Return False
        End If
        'First Name is Not empy or contains non alpha characters
        If txtFName.Text = "" Then
            MessageBox.Show("First Name is a Required Field! Please Enter a First Name.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFName.Focus()
            Return False
        ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(txtFName.Text, "^[a-zA-Z]+$") Then
            MessageBox.Show("Non-alpha characters are not allowed in the First Name field! Please correct the First Name field and try again.", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFName.Focus()
            Return False
        End If

        'If all other checks pass
        Return True
    End Function

    'Calculates the Subtotal
    '------------------------------------------------------------
    '-            Subprogram Name:  CalcSubtotal                -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 8/30/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called from the btnCalc_Click Event.  -
    '- After Checking Mealtype, Returns the Correct Subtotal for-
    '- this order.                                              –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- intOrders - Number of Meals                              -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Returns:                                                 -
    '- Double - The subtotal.                                   -
    '------------------------------------------------------------
    Private Function CalcSubtotal(ByVal intOrders As Integer) As Double
        If radStandard.Checked Then
            Return dblSTD_MEAL * intOrders
        Else
            Return dblDLXE_MEAL * intOrders
        End If
    End Function

    'Calculates the Discounted Amount
    '------------------------------------------------------------
    '-            Subprogram Name:  CalcDiscountAmt             -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 8/30/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called from the btnCalc_Click Event.  -
    '- Returns the Amount to be taken off from the Total as a   -
    '- Discount.                                                –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- dblSubTot - The SubTotal from the Event                  -
    '- dblDiscPerc - the Discount Percent from the Event        -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Returns:                                                 -
    '- Double - Amount Taken off the Total as Discount.         -
    '------------------------------------------------------------
    Private Function CalcDiscountAmt(ByVal dblSubTot As Double, ByVal dblDiscPerc As Double) As Double
        Return dblSubTot * dblDiscPerc
    End Function

    'Calculates the Taxed Amount
    '------------------------------------------------------------
    '-            Subprogram Name:  CalcTaxCollected            -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 8/30/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called from the btnCalc_Click Event.  -
    '- Returns the Tax to be Collected to be Added to the Total.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- intOrders - Number of Meals                              -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Returns:                                                 -
    '- Double - The Tax to be Added to the Total.                                   -
    '------------------------------------------------------------
    Private Function CalcTaxCollected(ByVal dblTotalToTaxBy As Double)
        Return dblTotalToTaxBy * dblTAX
    End Function
End Class