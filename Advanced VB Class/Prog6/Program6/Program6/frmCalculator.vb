'------------------------------------------------------------
'-                File Name : frmCalculator.vb              - 
'-                Part of Project: Assignment 6             -
'------------------------------------------------------------
'-                Written By: Austin Sliter                 -
'-                Written On: 3/15/18                       -
'------------------------------------------------------------
'- File Purpose:                                            -
'- This file contains all the code for a single instance of -
'- the child form.                                          - 
'------------------------------------------------------------
'- Global Variable Dictionary (alphabetically):             -
'- ctrlCurrTextBox - The current input Text Box Selected    -
'-                   (or last used)                         –
'- strTextType - The Text Type of the current or previous   -
'-               control.                                   -
'------------------------------------------------------------

Public Class frmCalculator
    '---Constants---
    '--Text Types--
    Const strBIN As String = "Binary"
    Const strDEC As String = "Decimal"
    Const strHEX As String = "Hexadecimal"
    '--Control Types--
    Const strBINTEXT As String = "txtBin"
    Const strDECTEXT As String = "txtDec"
    Const strHEXTEXT As String = "txtHex"
    '--Value Numbers--
    Const strVAL1 As String = "1"
    Const strVAL2 As String = "2"

    '---Global Variables---
    Dim ctrlCurrTextBox As Control = New Control
    Dim strTextType As String

    '--Input and Conversion Events--
    '-Alpha-
    '------------------------------------------------------------
    '-                Subprogram Name: btnA_Click               -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Enters the Applicable Character into the current text box.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnA_Click(sender As Object, e As EventArgs) Handles btnA.Click
        'Fills current text box with the Button's Character (Alpha)
        ctrlCurrTextBox.Text &= "A"

        'Resets the button layout
        toggleButtons()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnB_Click               -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Enters the Applicable Character into the current text box.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnB_Click(sender As Object, e As EventArgs) Handles btnB.Click
        'Fills current text box with the Button's Character (Alpha)
        ctrlCurrTextBox.Text &= "B"

        'Resets the button layout
        toggleButtons()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnC_Click               -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Enters the Applicable Character into the current text box.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnC_Click(sender As Object, e As EventArgs) Handles btnC.Click
        'Fills current text box with the Button's Character (Alpha)
        ctrlCurrTextBox.Text &= "C"

        'Resets the button layout
        toggleButtons()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnD_Click               -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Enters the Applicable Character into the current text box.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnD_Click(sender As Object, e As EventArgs) Handles btnD.Click
        'Fills current text box with the Button's Character (Alpha)
        ctrlCurrTextBox.Text &= "D"

        'Resets the button layout
        toggleButtons()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnE_Click               -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Enters the Applicable Character into the current text box.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnE_Click(sender As Object, e As EventArgs) Handles btnE.Click
        'Fills current text box with the Button's Character (Alpha)
        ctrlCurrTextBox.Text &= "E"

        'Resets the button layout
        toggleButtons()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnF_Click               -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Enters the Applicable Character into the current text box.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnF_Click(sender As Object, e As EventArgs) Handles btnF.Click
        'Fills current text box with the Button's Character (Alpha)
        ctrlCurrTextBox.Text &= "F"

        'Resets the button layout
        toggleButtons()
    End Sub

    '-Numeric-
    '------------------------------------------------------------
    '-                Subprogram Name: btnNum9_Click            -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Enters the Applicable Character into the current text box.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnNum9_Click(sender As Object, e As EventArgs) Handles btnNum9.Click
        'Fills current text box with the Button's Character (Numeric)
        ctrlCurrTextBox.Text &= "9"

        'Resets the button layout
        toggleButtons()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnNum8_Click            -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Enters the Applicable Character into the current text box.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnNum8_Click(sender As Object, e As EventArgs) Handles btnNum8.Click
        'Fills current text box with the Button's Character (Numeric)
        ctrlCurrTextBox.Text &= "8"

        'Resets the button layout
        toggleButtons()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnNum7_Click            -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Enters the Applicable Character into the current text box.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnNum7_Click(sender As Object, e As EventArgs) Handles btnNum7.Click
        'Fills current text box with the Button's Character (Numeric)
        ctrlCurrTextBox.Text &= "7"

        'Resets the button layout
        toggleButtons()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnNum6_Click            -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Enters the Applicable Character into the current text box.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnNum6_Click(sender As Object, e As EventArgs) Handles btnNum6.Click
        'Fills current text box with the Button's Character (Numeric)
        ctrlCurrTextBox.Text &= "6"

        'Resets the button layout
        toggleButtons()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnNum5_Click            -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Enters the Applicable Character into the current text box.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnNum5_Click(sender As Object, e As EventArgs) Handles btnNum5.Click
        'Fills current text box with the Button's Character (Numeric)
        ctrlCurrTextBox.Text &= "5"

        'Resets the button layout
        toggleButtons()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnNum4_Click            -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Enters the Applicable Character into the current text box.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnNum4_Click(sender As Object, e As EventArgs) Handles btnNum4.Click
        'Fills current text box with the Button's Character (Numeric)
        ctrlCurrTextBox.Text &= "4"

        'Resets the button layout
        toggleButtons()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnNum3_Click            -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Enters the Applicable Character into the current text box.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnNum3_Click(sender As Object, e As EventArgs) Handles btnNum3.Click
        'Fills current text box with the Button's Character (Numeric)
        ctrlCurrTextBox.Text &= "3"

        'Resets the button layout
        toggleButtons()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnNum2_Click            -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Enters the Applicable Character into the current text box.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnNum2_Click(sender As Object, e As EventArgs) Handles btnNum2.Click
        'Fills current text box with the Button's Character (Numeric)
        ctrlCurrTextBox.Text &= "2"

        'Resets the button layout
        toggleButtons()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnNum1_Click            -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Enters the Applicable Character into the current text box.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnNum1_Click(sender As Object, e As EventArgs) Handles btnNum1.Click
        'Fills current text box with the Button's Character (Numeric)
        ctrlCurrTextBox.Text &= "1"

        'Resets the button layout
        toggleButtons()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnNum0_Click            -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Enters the Applicable Character into the current text box.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnNum0_Click(sender As Object, e As EventArgs) Handles btnNum0.Click
        'Fills current text box with the Button's Character (Numeric)
        ctrlCurrTextBox.Text &= "0"

        'Resets the button layout
        toggleButtons()
    End Sub

    '-Convert Button-
    '------------------------------------------------------------
    '-                Subprogram Name: btnConvert_Click         -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Determines the target Value for the conversion and calls -
    '- the conversion subroutine.                               –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        'Figures out Whether or not The Control is part of the Value 1 Group or Value 2 Group
        'Then Calls the Subroutine to Convert based on Text Type (Now that Value is Figured out)
        If ctrlCurrTextBox.Name.Contains(strVAL1) Then
            ConvertMsgVals(strVAL1)
        ElseIf ctrlCurrTextBox.Name.Contains(strVAL2) Then
            ConvertMsgVals(strVAL2)
        End If
    End Sub

    '-Convert Missing Values-
    '------------------------------------------------------------
    '-                Subprogram Name: ConvertMsgVals           -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Enters the Applicable Character into the current text box.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- strVal - The Value number for conversion                 -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- ctrlTemp - A temporary control variable that stores the  -
    '-          current text box to return to that text box.    -
    '- strBinVal - The Name of the Binary Text box of Specified -
    '-           Value.                                         -
    '- strContents - The Contents of a TextBox                  -
    '- strDecVal - The Name of the Decimal Text box of Specified-
    '-           Value.                                         -
    '- strHexVal - The Name of the Hexadecimal Text box of      -
    '-           Specified Value.                               -
    '------------------------------------------------------------
    Private Sub ConvertMsgVals(strVal As String)
        '-Local Variables-
        'Temporary Control Variable
        Dim ctrlTemp As Control = ctrlCurrTextBox
        'String values For the name property of Binary, Decimal and Hex TextBox Controls of specific value number
        Dim strBinVal As String = strBINTEXT & strVal
        Dim strDecVal As String = strDECTEXT & strVal
        Dim strHexVal As String = strHEXTEXT & strVal

        'String Contents of that Control's text property
        Dim strContents As String = ""

        Select Case strTextType
            Case strBIN 'If last text box was binary
                'Get Contents from current Binary Text Box's text property
                strContents = ctrlCurrTextBox.Text

                'Get Decimal Text box control of Current Value
                ctrlCurrTextBox = Me.Controls.Find(strDecVal, True).FirstOrDefault

                'Assign Converted Value to Text box Text Property
                If strContents.Contains(" ") Then
                    ctrlCurrTextBox.Text = CBinToDec(CBinFormat(strContents))
                    If Not ctrlCurrTextBox.Text.Contains(" ") Then
                        'Reformat to Binary Format
                        Me.Controls.Find(strBinVal, True).FirstOrDefault.Text = CBinFormat(Me.Controls.Find(strBinVal, True).FirstOrDefault.Text)
                    End If
                Else
                    ctrlCurrTextBox.Text = CBinToDec(strContents)
                End If

                'Get Contents of Decimal Text Box's text property
                strContents = ctrlCurrTextBox.Text

                'Get Hexidecimal Text Box Control of Current Value
                ctrlCurrTextBox = Me.Controls.Find(strHexVal, True).FirstOrDefault

                'Assign Converted Value To Text Box Text Property
                ctrlCurrTextBox.Text = CDecToHex(CInt(strContents))

                'Reformat to Binary Format
                Me.Controls.Find(strBinVal, True).FirstOrDefault.Text = CBinFormat(Me.Controls.Find(strBinVal, True).FirstOrDefault.Text)
            Case strDEC 'If last text box was Decimal
                'Get Contents from current Decimal Text Box's text property
                strContents = ctrlCurrTextBox.Text

                'Get Binary Text box control of Current Value
                ctrlCurrTextBox = Me.Controls.Find(strBinVal, True).FirstOrDefault

                'Assign Converted Value to Text box Text Property
                ctrlCurrTextBox.Text = CDecToBin(CInt(strContents))

                'Reformat to Binary Format
                Me.Controls.Find(strBinVal, True).FirstOrDefault.Text = CBinFormat(Me.Controls.Find(strBinVal, True).FirstOrDefault.Text)

                'Get Hexidecimal Text Box Control of Current Value
                ctrlCurrTextBox = Me.Controls.Find(strHexVal, True).FirstOrDefault

                'Assign Converted Value To Text Box Text Property
                ctrlCurrTextBox.Text = CDecToHex(CInt(strContents))
            Case strHEX 'If last text box was Hexidecimal
                'Get Contents from current Hexadecimal Text Box's text property
                strContents = ctrlCurrTextBox.Text

                'Get Decimal Text box control of Current Value
                ctrlCurrTextBox = Me.Controls.Find(strDecVal, True).FirstOrDefault

                'Assign Converted Value to Text box Text Property
                ctrlCurrTextBox.Text = CHexToDec(strContents)

                'Get Contents of Decimal Text Box's text property
                strContents = ctrlCurrTextBox.Text

                'Get Binary Text Box Control of Current Value
                ctrlCurrTextBox = Me.Controls.Find(strBinVal, True).FirstOrDefault

                'Assign Converted Value To Text Box Text Property
                ctrlCurrTextBox.Text = CDecToBin(CInt(strContents))

                'Reformat to Binary Format
                Me.Controls.Find(strBinVal, True).FirstOrDefault.Text = CBinFormat(Me.Controls.Find(strBinVal, True).FirstOrDefault.Text)
        End Select

        'Returns to Last known control before conversion and Focus That Control
        ctrlCurrTextBox = ctrlTemp
        Me.Controls.Find(ctrlCurrTextBox.Name, True).FirstOrDefault.Focus()

        'Refreshes the Button Layout
        toggleButtons()
    End Sub

    '-Conversion Functions
    '------------------------------------------------------------
    '-               Function Name: CBinFormat                  -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the The binary Fields need to be -
    '- formatted or converted into readable binary. Performs said-
    '- conversion.                                              -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- strOutput - string used for outputting the formatted and -
    '-           readable strings.                              -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- strArrBin - an Array of The Binary groups of 4 for formatting-
    '------------------------------------------------------------
    '- Returns:                                                 -
    '- String – The Converted or Formatted Binary Value         -
    '------------------------------------------------------------
    Private Function CBinFormat(strOutput As String) As String
        'Local Variables
        Dim strArrBin As String()

        If strOutput.Contains(" ") Then
            Return strOutput.Replace(" ", "")
        Else
            strOutput = StrDup(32 - strOutput.Length, "0") & strOutput
            strArrBin = {Mid(strOutput, 1, 4), Mid(strOutput, 5, 4), Mid(strOutput, 9, 4), Mid(strOutput, 13, 4), Mid(strOutput, 17, 4), Mid(strOutput, 21, 4), Mid(strOutput, 25, 4), Mid(strOutput, 29, 4)}
            strOutput = strArrBin(0) & " " & strArrBin(1) & " " & strArrBin(2) & " " & strArrBin(3) & " " & strArrBin(4) & " " & strArrBin(5) & " " & strArrBin(6) & " " & strArrBin(7)
            Return strOutput
        End If
    End Function

    'Convert From Decimal to Binary
    '------------------------------------------------------------
    '-               Function Name: CDecToBin                   -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever you need to convert a decimal to -
    '- binary. Performs the conversion.                         -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- intDec - integer used for converting a Decimal to a      -
    '- Binary Value.                                            -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Returns:                                                 -
    '- String – For The Converted Binary Value                  -
    '------------------------------------------------------------
    Private Function CDecToBin(intDec As Integer) As String
        Return Convert.ToString(intDec, 2)
    End Function

    'Convert from Binary To Decimal
    '------------------------------------------------------------
    '-               Function Name: CBinToDec                  -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever you need to convert a decimal to -
    '- binary. Performs the conversion.                         -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- strBin - String used for converting a Deimal value  to a -
    '- Binary Value.                                            -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Returns:                                                 -
    '- Integer – For The Converted Decimal Value                -
    '------------------------------------------------------------
    Private Function CBinToDec(strBin As String) As Integer
        Return Convert.ToInt32(strBin, 2)
    End Function

    'Convert from Hexadecimal to Decimal
    '------------------------------------------------------------
    '-               Function Name: CHexToDec                   -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever you need to convert a decimal to -
    '- binary. Performs the conversion.                         -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- strHex - integer used for converting a Hex Value to a    -
    '- Decimal.                                            -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Returns:                                                 -
    '- Integer – For The Converted Hex Value                    -
    '------------------------------------------------------------
    Private Function CHexToDec(strHex As String) As Integer
        Return Convert.ToInt32(strHex, 16)
    End Function

    'Convert from Decimal to Hexadecimal
    '------------------------------------------------------------
    '-               Function Name: CDecToBin                   -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever you need to convert a decimal to -
    '- binary. Performs the conversion.                         -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- intDec - integer used for converting a Decimal to a      -
    '- Hexadecimal Value.                                       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Returns:                                                 -
    '- String – For The Converted Hex Value                     -
    '------------------------------------------------------------
    Private Function CDecToHex(intDec As Integer) As String
        Return Hex(intDec)
    End Function

    '--Program Events--
    'Load Event
    '------------------------------------------------------------
    '-                Subprogram Name: frmCalculator_Load       -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever Program Loads. Sets the Placeholder-
    '- Name for the Current Text Box and resets the Botton Layout–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub frmCalculator_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Sets the Placeholder Name for the Text Box
        ctrlCurrTextBox.Name = "Default"

        'Resets the button layout
        toggleButtons()
    End Sub

    '-Focus Events-
    '------------------------------------------------------------
    '-                Subprogram Name: txtDec1_GotFocus         -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above text box gets focus.   -
    '- sets Current Text Box and Current Text Type and also resets-
    '- the Buttons.                                             –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub txtDec1_GotFocus(sender As Object, e As EventArgs) Handles txtDec1.GotFocus
        'Change TextType and Current Text Box Accordingly
        strTextType = strDEC
        ctrlCurrTextBox = txtDec1

        'Resets the button layout
        toggleButtons()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: txtDec2_GotFocus         -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above text box gets focus.   -
    '- sets Current Text Box and Current Text Type and also resets-
    '- the Buttons.                                             –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub txtDec2_GotFocus(sender As Object, e As EventArgs) Handles txtDec2.GotFocus
        'Change TextType and Current Text Box Accordingly
        strTextType = strDEC
        ctrlCurrTextBox = txtDec2

        'Resets the button layout
        toggleButtons()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: txtHex1_GotFocus         -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above text box gets focus.   -
    '- sets Current Text Box and Current Text Type and also resets-
    '- the Buttons.                                             –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub txtHex1_GotFocus(sender As Object, e As EventArgs) Handles txtHex1.GotFocus
        'Change TextType and Current Text Box Accordingly
        strTextType = strHEX
        ctrlCurrTextBox = txtHex1

        'Resets the button layout
        toggleButtons()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: txtHex2_GotFocus         -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above text box gets focus.   -
    '- sets Current Text Box and Current Text Type and also resets-
    '- the Buttons.                                             –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub txtHex2_GotFocus(sender As Object, e As EventArgs) Handles txtHex2.GotFocus
        'Change TextType and Current Text Box Accordingly
        strTextType = strHEX
        ctrlCurrTextBox = txtHex2
        toggleButtons()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: txtBin1_GotFocus         -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above text box gets focus.   -
    '- sets Current Text Box and Current Text Type and also resets-
    '- the Buttons.                                             –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub txtBin1_GotFocus(sender As Object, e As EventArgs) Handles txtBin1.GotFocus
        'Change TextType and Current Text Box Accordingly
        strTextType = strBIN
        ctrlCurrTextBox = txtBin1

        'Resets the button layout
        toggleButtons()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: txtBin2_GotFocus         -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above text box gets focus.   -
    '- sets Current Text Box and Current Text Type and also resets-
    '- the Buttons.                                             –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub txtBin2_GotFocus(sender As Object, e As EventArgs) Handles txtBin2.GotFocus
        'Change TextType and Current Text Box Accordingly
        strTextType = strBIN
        ctrlCurrTextBox = txtBin2

        'Resets the button layout
        toggleButtons()
    End Sub

    '--Toggle Enabled/Disabled Buttons--
    '------------------------------------------------------------
    '-                Subprogram Name: toggleButtons            -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the Buttons need to be reset.    -
    '- Resets these Buttons.                                    -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- strBin1 - The Name of the Value 1 Binary Text Box        -
    '- strBin2 - The Name of the Value 2 Binary Text Box        -
    '- strHex1 - The Name of the Value 1 Hexadecimal Text Box   -
    '- strHex2 - The Name of the Value 2 Hexadecimal Text Box   -
    '------------------------------------------------------------
    Private Sub toggleButtons()
        'Local Variables
        'String values For the name property of Binary and Hex TextBox Controls of specific value number for comparisons
        Dim strHex1 As String = strHEXTEXT & strVAL1
        Dim strHex2 As String = strHEXTEXT & strVAL2
        Dim strBin1 As String = strBINTEXT & strVAL1
        Dim strBin2 As String = strBINTEXT & strVAL2

        'Not Nothing Selected Switch
        If Not ctrlCurrTextBox.Name.Equals("Default") Then
            btnNum0.Enabled = True
            btnNum1.Enabled = True
            btnNum2.Enabled = True
            btnNum3.Enabled = True
            btnNum4.Enabled = True
            btnNum5.Enabled = True
            btnNum6.Enabled = True
            btnNum7.Enabled = True
            btnNum8.Enabled = True
            btnNum9.Enabled = True

            'Binary Switch for Binary Code
            If Not (ctrlCurrTextBox.Name.Equals(strBin1) Or ctrlCurrTextBox.Name.Equals(strBin2)) Then
                btnNum0.Enabled = True
                btnNum1.Enabled = True
                btnNum2.Enabled = True
                btnNum3.Enabled = True
                btnNum4.Enabled = True
                btnNum5.Enabled = True
                btnNum6.Enabled = True
                btnNum7.Enabled = True
                btnNum8.Enabled = True
                btnNum9.Enabled = True
            ElseIf (ctrlCurrTextBox.Name.Equals(strBin1) Or ctrlCurrTextBox.Name.Equals(strBin2)) Then
                btnNum0.Enabled = True
                btnNum1.Enabled = True
                btnNum2.Enabled = False
                btnNum3.Enabled = False
                btnNum4.Enabled = False
                btnNum5.Enabled = False
                btnNum6.Enabled = False
                btnNum7.Enabled = False
                btnNum8.Enabled = False
                btnNum9.Enabled = False
            End If

            'Convert Switch
            If ctrlCurrTextBox.Text.Equals(Nothing) Or ctrlCurrTextBox.Text.Equals("") Then
                btnConvert.Enabled = False
            Else
                btnConvert.Enabled = True
            End If

            'Operators Switch
            If (((txtBin1.Text.Equals(Nothing) Or txtDec1.Text.Equals(Nothing) Or txtHex1.Text.Equals(Nothing)) Or (txtBin1.Text.Equals("") Or txtDec1.Text.Equals("") Or txtHex1.Text.Equals(""))) OrElse ((txtBin2.Text.Equals(Nothing) Or txtDec2.Text.Equals(Nothing) Or txtHex2.Text.Equals(Nothing)) Or (txtBin2.Text.Equals("") Or txtDec2.Text.Equals("") Or txtHex2.Text.Equals("")))) Then
                btnAnd.Enabled = False
                btnOr.Enabled = False
                btnXor.Enabled = False
            Else
                btnAnd.Enabled = True
                btnOr.Enabled = True
                btnXor.Enabled = True
            End If

            'Value 1 Has/has no values
            If ((txtBin1.Text.Equals(Nothing) And txtDec1.Text.Equals(Nothing) And txtHex1.Text.Equals(Nothing)) Or (txtBin1.Text.Equals("") And txtDec1.Text.Equals("") And txtHex1.Text.Equals(""))) Then
                btnNotVal1.Enabled = False
                btnClrVal1.Enabled = False
            Else
                btnNotVal1.Enabled = True
                btnClrVal1.Enabled = True
            End If

            'Value 2 has/has no values
            If ((txtBin2.Text.Equals(Nothing) And txtDec2.Text.Equals(Nothing) And txtHex2.Text.Equals(Nothing)) Or (txtBin2.Text.Equals("") And txtDec2.Text.Equals("") And txtHex2.Text.Equals(""))) Then
                btnClrVal2.Enabled = False
            Else
                btnClrVal2.Enabled = True
            End If

            'Alpha Switch for Hex Code
            If Not (ctrlCurrTextBox.Name.Equals(strHex1) Or ctrlCurrTextBox.Name.Equals(strHex2)) Then
                btnA.Enabled = False
                btnB.Enabled = False
                btnC.Enabled = False
                btnD.Enabled = False
                btnE.Enabled = False
                btnF.Enabled = False
            ElseIf ctrlCurrTextBox.Name.Equals(strHex1) Or ctrlCurrTextBox.Name.Equals(strHex2) Then
                btnA.Enabled = True
                btnB.Enabled = True
                btnC.Enabled = True
                btnD.Enabled = True
                btnE.Enabled = True
                btnF.Enabled = True
            End If
        Else 'If default ctrl placeholder is present
            btnNum0.Enabled = False
            btnNum1.Enabled = False
            btnNum2.Enabled = False
            btnNum3.Enabled = False
            btnNum4.Enabled = False
            btnNum5.Enabled = False
            btnNum6.Enabled = False
            btnNum7.Enabled = False
            btnNum8.Enabled = False
            btnNum9.Enabled = False
        End If
    End Sub

    '-Clear Button events-
    '------------------------------------------------------------
    '-                Subprogram Name: btnClrVal1_Click         -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Clears all relavent text boxes and resets Butons.        –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnClrVal1_Click(sender As Object, e As EventArgs) Handles btnClrVal1.Click
        'Clear Relavent Text Boxes
        txtBin1.Clear()
        txtDec1.Clear()
        txtHex1.Clear()
        'Reset Convert and Clear Buttons
        btnConvert.Enabled = False
        btnClrVal1.Enabled = False
        'Reset Input/Operation Buttons
        toggleButtons()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnClrVal2_Click         -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Clears all relavent text boxes and resets Butons.        –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnClrVal2_Click(sender As Object, e As EventArgs) Handles btnClrVal2.Click
        'Clear Relavent Text Boxes
        txtBin2.Clear()
        txtDec2.Clear()
        txtHex2.Clear()
        'Reset Convert and Clear Buttons
        btnConvert.Enabled = False
        btnClrVal2.Enabled = False
        'Reset Input/Operation Buttons
        toggleButtons()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnClrRes_Click          -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Clears all relavent text boxes and resets Butons.        –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnClrRes_Click(sender As Object, e As EventArgs) Handles btnClrRes.Click
        'Zero Relavent Text Boxes
        txtResBin.Text = 0
        txtResDec.Text = 0
        txtResHex.Text = 0
        'Reset Clear Result Button
        btnClrRes.Enabled = False
    End Sub

    '-Logical Operation Buttons-
    '------------------------------------------------------------
    '-                Subprogram Name: btnAnd_Click             -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Performs the Applicable Operation and sets the result text-
    '- boxes.                                                   –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnAnd_Click(sender As Object, e As EventArgs) Handles btnAnd.Click
        'Perform Operation AND
        txtResDec.Text = (CInt(txtDec1.Text) And CInt(txtDec2.Text))
        'Convert from First Result
        txtResBin.Text = CDecToBin(CInt(txtResDec.Text))
        'Reformat Binary Result to Binary Format
        txtResBin.Text = CBinFormat(txtResBin.Text)
        'Convert to Hex
        txtResHex.Text = CDecToHex(CInt(txtResDec.Text))
        'Enable Clear Button
        btnClrRes.Enabled = True
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnOr_Click             -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Performs the Applicable Operation and sets the result text-
    '- boxes.                                                   –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnOr_Click(sender As Object, e As EventArgs) Handles btnOr.Click
        'Perform Operation OR
        txtResDec.Text = (CInt(txtDec1.Text) Or CInt(txtDec2.Text))
        'Convert from First Result
        txtResBin.Text = CDecToBin(CInt(txtResDec.Text))
        'Reformat Binary Result to Binary Format
        txtResBin.Text = CBinFormat(txtResBin.Text)
        'Convert to Hex
        txtResHex.Text = CDecToHex(CInt(txtResDec.Text))
        'Enable Clear Button
        btnClrRes.Enabled = True
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnXor_Click             -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Performs the Applicable Operation and sets the result text-
    '- boxes.                                                   –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnXor_Click(sender As Object, e As EventArgs) Handles btnXor.Click
        'Perform Operation XOR
        txtResDec.Text = (CInt(txtDec1.Text) Xor CInt(txtDec2.Text))
        'Convert from First Result
        txtResBin.Text = CDecToBin(CInt(txtResDec.Text))
        'Reformat Binary Result to Binary Format
        txtResBin.Text = CBinFormat(txtResBin.Text)
        'Convert to Hex
        txtResHex.Text = CDecToHex(CInt(txtResDec.Text))
        'Enable Clear Button
        btnClrRes.Enabled = True
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnNotVal1_Click         -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the above button is clicked      -
    '- Performs the Applicable Operation and sets the result text-
    '- boxes.                                                   –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnNotVal1_Click(sender As Object, e As EventArgs) Handles btnNotVal1.Click
        'Perform Operation NOT (Val1 Only)
        txtResDec.Text = (Not CInt(txtDec1.Text))
        'Convert from First Result
        txtResBin.Text = CDecToBin(CInt(txtResDec.Text))
        'Reformat Binary Result to Binary Format
        txtResBin.Text = CBinFormat(txtResBin.Text)
        'Convert to Hex
        txtResHex.Text = CDecToHex(CInt(txtResDec.Text))
        'Enable Clear Button
        btnClrRes.Enabled = True
    End Sub

    '-Form Closing Event (For All Child Forms)-
    '------------------------------------------------------------
    '-                Subprogram Name: btnNotVal1_Click         -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/15/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This is called whenever the Child form instances are closing-
    '- for each child form, if the form is dirty, then the user is-
    '- prompted on whether or not to discard the changes. If yes,-
    '- the form is closed, if not the form stays open.          -
    '- Note: When Closing the main form, if any child forms'    -
    '- changes are not discarded, all the child forms will remain-
    '- open.                                                    -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- dlgRes - Dialog result Variable.                         -
    '------------------------------------------------------------
    Private Sub frmCalculator_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Note: For Single Forms, This works like any form closing event, however when Closing the main form, if any child forms' changes are not discarded, all the child forms will remain open.
        Dim dlgRes As DialogResult
        If ((txtBin1.Text <> Nothing Or txtDec1.Text <> Nothing Or txtHex1.Text <> Nothing) Or (txtBin1.Text <> "" Or txtDec1.Text <> "" Or txtHex1.Text <> "")) Or ((txtBin2.Text <> Nothing Or txtDec2.Text <> Nothing Or txtHex2.Text <> Nothing) Or (txtBin2.Text <> "" Or txtDec2.Text <> "" Or txtHex2.Text <> "")) Then
            dlgRes = MessageBox.Show("Do you wish to discard the changes made in " & Me.Text & "?", Me.Text & " Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dlgRes = DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub
End Class