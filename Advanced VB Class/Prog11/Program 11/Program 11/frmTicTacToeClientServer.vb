'Imports
Imports System.Threading
Imports System.Net.Sockets
Imports System.IO
Imports System.ComponentModel

'------------------------------------------------------------
'-                File Name : Form1.frm                     - 
'-                Part of Project: Assignment 6             -
'------------------------------------------------------------
'-                Written By: Austin Sliter                 -
'-                Written On: 4/18/18                       -
'------------------------------------------------------------
'- File Purpose:                                            -
'- This file contains the main application form where the   -
'- user Will specify If they are the Client or Server,      -
'- the Player they are currently and the First Moving Player.- 
'- The Latter Two are for the Server Only. You can Also Connect-
'- to Different Servers or Clients using the Text Boxes.    -
'- When you start up the client and Server you can play Tic -
'- Tac Toe until someone wins or there is a Tie. Then you can-
'- play again.                                              -
'------------------------------------------------------------
'- Program Purpose:                                         -
'-                                                          -
'- This program is both a client and a server, Allowing the -
'- User to play tic tac toe against a friend repeatedly.    -
'------------------------------------------------------------
'- Global Variable Dictionary (alphabetically):             -
'- aConnection - Socket for Server                          -
'- blnServer - Flag Boolean for Server/Client State         -
'- Client - TCP client object for Client                    -
'- GetDataThread - Thread for GetData Subroutine to Execute -
'- intFirstMove - Determines which Player Goes first        -
'- intPlayer - The Player that the client or server IS at   -
'-             the game runtime.                            -
'- NetStream - The Network Stream.                          -
'- NetReader - Network BinaryReader.                        -
'- NetWriter - Network BinaryWriter.                        -
'- Server - TCP Listener for the Server.                    -
'------------------------------------------------------------
Public Class frmTicTacToeClientServer
    '---Constants---
    '--Form Header Constants--
    Const strTICTACTOE As String = "Tic Tac Toe - "
    Const strSERVERTITLE As String = "Server - "
    Const strCLIENTTITLE As String = "Client - "
    Const strPLAYERX As String = "Player: X, "
    Const strPLAYERO As String = "Player: O, "
    Const strMV_FRSTX As String = "Moves First: X"
    Const strMV_FRSTO As String = "Moves First: O"

    '--Constants for Winning--
    Const strWINX As String = "X Wins!"
    Const strWINO As String = "O Wins!"
    Const strTIE As String = "Tie Game!"

    '--Constants For Turn Gameplay--
    Const strYOURTURN As String = "-Your Turn-"
    Const strOPPONENT_TURN As String = "-Opponent Turn-"

    '---Global Variables---
    '--Player and First Move Vars--
    Dim intPlayer As Integer = 1
    Dim intFirstMove As Integer = 1

    '--Flag Boolean for Server/Client State--
    Dim blnServer = False

    '---Client Server Example Program Extracted Global Variables for Client and Server---
    'This TcpListener object represents our server
    Dim Server As TcpListener

    'This TcpClient object represents a client
    Dim Client As TcpClient

    'We need to create a Socket object to associate with our 
    'server.  Our socket will run on port 1000 by default.
    Dim aConnection As Socket

    'We need a NetworkStream through which data is transferred
    'between the client and the server
    Dim NetStream As NetworkStream

    'These are the objects that we will use for reading and 
    'writing data across the network stream
    Dim NetWriter As BinaryWriter
    Dim NetReader As BinaryReader

    'We will have to start up a thread that specifically listens
    'for network stream traffic coming to our server from the
    'client.  This is the thread object we will use for that 
    'purpose.
    Dim GetDataThread As Thread
    '~~~End of Example Variables~~~

    '---Application Events---
    '------------------------------------------------------------
    '-      Subprogram Name: frmTicTacToeClientServer_Load      -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 4/18/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Form Loads. Sets  -
    '- the Default Selections For Radio Buttons And Turns the   -
    '- Illegal Threads Checker Off.                              –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub frmTicTacToeClientServer_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Select Default Selections
        radServer.Checked = True
        radP1.Checked = True
        radM1.Checked = True

        'Turn CheckforIllegalCrossThreads to OFF TO PREVENT VB FROM YELLING AT US
        CheckForIllegalCrossThreadCalls = False
    End Sub


    '------------------------------------------------------------
    '-      Subprogram Name: txtLog_TextChanged                 -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 4/18/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Log Text Box has  -
    '- It's Text Changed. AutoScrolls the Log Text Box to Keep Up-
    '- To Date on Client/Server Messages.                        –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub txtLog_TextChanged(sender As Object, e As EventArgs) Handles txtLog.TextChanged
        'This Code was adapted from a snippet found here:
        'https://social.msdn.microsoft.com/Forums/en-US
        '/39501aa1-5913-41d6-95ed-3b538b92c68c
        '/autoscroll-multiline-textbox-possible?forum=vbgeneral

        'Cursor Select Text Box Endpoint
        txtLog.Select(txtLog.Text.Length, 0)

        'Perform AutoScrool to Cursor
        txtLog.ScrollToCaret()
    End Sub

    '------------------------------------------------------------
    '-      Subprogram Name: Radio_CheckedChanged               -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 4/18/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Radio Buttons Have-
    '- their Checked Properties Changed. Depending on the One   -
    '- changed will perform different actions.                  –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- currRad - The Currently Changed Radio Button             -
    '------------------------------------------------------------
    Private Sub Radio_CheckedChanged(sender As Object, e As EventArgs) Handles radP1.CheckedChanged,
        radP2.CheckedChanged, radM1.CheckedChanged, radM2.CheckedChanged, radClient.CheckedChanged,
        radServer.CheckedChanged
        '---Local Variables---
        'Puts the currenly changed radio button into this container for analysis
        Dim currRad As RadioButton = sender

        'Based on the radio Button Perform the Following Actions
        Select Case currRad.Tag
            Case "PX" 'Player X
                intPlayer = 1

                'Updates Form Header
                UpdateHeader()
            Case "PO" 'Player O
                intPlayer = 2

                'Updates Form Header
                UpdateHeader()
            Case "MX" 'First Move X
                intFirstMove = 1

                'Updates Form Header
                UpdateHeader()
            Case "MO" 'First Move O
                intFirstMove = 2

                'Updates Form Header
                UpdateHeader()
            Case "TS" 'Type = Server
                blnServer = True

                'Updates Form Header
                UpdateHeader()

                'Enables/Disables Server Controls
                ToggleServerControls()
            Case "TC" 'Type = Client
                blnServer = False

                'Updates Form Header
                UpdateHeader()

                'Enables/Disables Server Controls
                ToggleServerControls()
        End Select

        'Prepare Starting Board
        CreateStartingBoard()
    End Sub

    '------------------------------------------------------------
    '-      Subprogram Name: btnBoardMove_Click                 -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 4/18/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Buttons that are  -
    '- part of the board are clicked. That one is disabled and  -
    '- filled with the appropriate letter (X/O) and it is sent to-
    '- the other end for it to preform the same operations. Each -
    '- time a move is made, the program checks for winning moves-
    '- and switches the player turn.                            –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- currButton - Selected Button for analysis.               -
    '- strMessage - Messageto be Sent to the Other End          -
    '------------------------------------------------------------
    Private Sub btnBoardMove_Click(sender As Object, e As EventArgs) Handles Button1.Click,
        Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click,
        Button7.Click, Button8.Click, Button9.Click
        '---Local Variables---
        'Puts the Selected Button into this container for Sending to other End (Client/Server)
        Dim currButton As Button = sender

        'Message to be sent to other endpoint
        Dim strMessage As String

        'Based on Player, Start Formatting a String
        If intPlayer = 1 Then
            strMessage = "X at "
            currButton.Text = "X"
            currButton.Enabled = False
        Else
            strMessage = "O at "
            currButton.Text = "O"
            currButton.Enabled = False
        End If

        'Send Moves Data to Opposite Endpoint
        NetWriter.Write(strMessage & currButton.Tag)

        'Check for Winning Moves
        CheckWinningMoves()

        'Change Player Turn
        ChangeTurn()
    End Sub

    '------------------------------------------------------------
    '-      Subprogram Name: btnStart_Click                 -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 4/18/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Start Button is Clicked.-
    '- Toggles the Controls for Start/Stop of the Endpoint, Nullify-
    '- the Text Log, Clear All Moves, Sets the starting Moves,  -
    '- establishes a connection, Sends the startup information to-
    '- the other end and assigns the turn label to the correct value.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        'Toggles the Controls for the Start of the Client/Server
        ToggleStartStop()

        'Nullify the Debug Log
        txtLog.Clear()

        'Clear All Buttons From Moves
        ClearMoves()

        'Create the Starting Board to Override the Clear Moves 
        'Subroutine when Not First Moving Player
        CreateStartingBoard()

        '---Code Originally Adapted from Example Program---
        If blnServer Then 'If it is a Server
            'Try to start up the server.
            Try
                txtLog.Text &= "Starting Server..." & vbCrLf
                'Create the server and point it at the port from 
                'the textbox value that the user entered.
                Server = New TcpListener(Net.IPAddress.Parse("127.0.0.1"),
                                     CInt(txtPort.Text))
                Server.Start()
                'We wait here until we get a connection request from a
                'client...  The server is running and when we get a connection,
                'we will accept it and place it in the Socket object we created.
                txtLog.Text &= "Listening for client connection..." & vbCrLf
                Application.DoEvents()
                aConnection = Server.AcceptSocket()
                txtLog.Text &= "...client connection accepted" & vbCrLf
                'If we get to this point with no exceptions, then we have
                'accepted a request from a client. Now we need to get the 
                'NetworkStream that is associated with our Socket object.
                NetStream = New NetworkStream(aConnection)
                'The last major setup piece that we need to do is to
                'create objects for transferring data across the 
                'NetworkStream.  Bind our Reader and Writer to the
                'NetworkStream object
                NetWriter = New BinaryWriter(NetStream)
                NetReader = New BinaryReader(NetStream)
                txtLog.Text &= vbCrLf &
                             "Network stream and reader/writer objects created" &
                             vbCrLf
                'Set up our thread to listen for data arriving from the
                'client
                txtLog.Text &= "Preparing thread to watch for data..." & vbCrLf
                GetDataThread = New Thread(AddressOf GetData)
                GetDataThread.Start()
            Catch IOEx As IOException
                txtLog.Text &= "Error in setting up Server -- Closing" & vbCrLf
                'We need to worry about trying to create another server on the same 
                'port
            Catch SocketEx As SocketException
                txtLog.Text &=
                             "Server already exists -- just restarting listening" &
                             vbCrLf
            End Try
        Else 'It is a Client
            Try
                txtLog.Text &= "Attempting connection..." & vbCrLf
                'Create the client and point it at the server's address
                'and port from the textbox values that the user entered.
                'We will get an exception here if the server is not already
                'up and running.
                Client = New TcpClient()
                Client.Connect(txtServerAddress.Text,
                               CInt(txtPort.Text))
                'If we get to this point with no exceptions, then we have
                'requested a connection to the server and it was accepted.
                'Now we need to get the NetworkStream that is associated 
                'with our TcpClient.
                NetStream = Client.GetStream()
                'The last major setup piece that we need to do is to
                'create objects for transferring data across the 
                'NetworkStream.  Bind the reader and writer.
                NetWriter = New BinaryWriter(NetStream)
                NetReader = New BinaryReader(NetStream)
                txtLog.Text &= vbCrLf &
                                 "Network stream and reader/writer objects created" &
                                 vbCrLf
                'Set up our thread to listen for data arriving from the
                'server
                txtLog.Text &= "Preparing thread to watch for data..." & vbCrLf
                GetDataThread = New Thread(AddressOf GetData)
                GetDataThread.Start()
                'Catch errors in trying to create the binary reader/writer
            Catch IOException As IOException
                txtLog.Text &= "Error in setting up Client -- Closing" & vbCrLf
                'Catch errors in trying to connect when a server is not present
            Catch SocketEx As SocketException
                txtLog.Text &= "Cannot find server -- please try again later" &
            vbCrLf
            End Try
        End If
        '---End Example Code---

        'Send Board Setup Instructions to other Endpoint
        SendSetupToOtherEnd()

        'If Going First then Display Correct Message
        If intPlayer = intFirstMove Then
            lblResult.Text = strYOURTURN
        Else
            lblResult.Text = strOPPONENT_TURN
        End If
    End Sub

    '------------------------------------------------------------
    '-      Subprogram Name: btnStop_Click                 -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 4/18/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Stop Button is Presed.-
    '- Toggles the Controls for Start/Stop and Disconnects the Connection.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        'Toggles the Controls for the Stop of the Client/Server
        ToggleStartStop()
        'call the disconnect subroutine
        Disconnect()
    End Sub

    '------------------------------------------------------------
    '-      Subprogram Name: frmTicTacToeClientServer_Closing   -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 4/18/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Closing Event is  -
    '- Called. Terminates any Open Connections.                 –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub frmTicTacToeClientServer_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Stop Listening to Client/Server Traffic
        Disconnect()
    End Sub

    '---Application Subroutines---
    '--Network Related--
    '------------------------------------------------------------
    '-      Subprogram Name: SendSetupToOtherEnd                -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 4/18/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever startup message needs -
    '- sending to the client.                                   –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- strOut - Contains the string that is sent to the other endpoint.-
    '------------------------------------------------------------
    Private Sub SendSetupToOtherEnd()
        '---Local Variables---
        'Define Output String
        Dim strOut As String

        'Reverse Player String To be analyzed by the opposite endpoint
        If intPlayer = 1 Then
            strOut = "2"
        Else
            strOut = "1"
        End If

        'Transfer First Move Message to Server
        If intFirstMove = 1 Then
            strOut &= "-1"
        Else
            strOut &= "-2"
        End If

        'Only Send it if you are the server 
        'because the Server has the Last Say
        Try
            If blnServer Then
                NetWriter.Write(strOut)
            End If
        Catch e As Exception
            txtLog.Text &= "Two Servers Are Trying to Interact on Same Port. Closing Connection of Duplicate." &
                vbCrLf
            btnStop.PerformClick()
        End Try
    End Sub

    '------------------------------------------------------------
    '-      Subprogram Name: GetData                            -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 4/18/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the thread calls this -
    '- subroutine. Retrieves Data Off the Wire.                 –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- TheData - String containing the data from the Wire       -
    '------------------------------------------------------------
    Private Sub GetData()
        '---Code Originally Adapted from Example Program---
        'This is the routine that we spin off into its own thread to 
        'listen for and retrieve network traffic coming to the server
        'from the client.
        'This is a string that we use to pull the data off of the
        'network stream
        Dim TheData As String = ""
        txtLog.Text &= "Data watching thread active" & vbCrLf
        'Here's the main listening loop that will continue until we
        'receive the ~~END~~ message from the client or the connection
        'abruptly stops.
        Try
            If blnServer Then
                Do
                    'Pull data from the network into our string
                    TheData = NetReader.ReadString
                    txtLog.Text &= "From Client: " & TheData & vbCrLf
                    'Analyze Data
                    AnalyzeData(TheData)
                Loop While (TheData <> "~~END~~") And aConnection.Connected
            Else
                Do
                    'Pull data from the network into our string
                    TheData = NetReader.ReadString
                    txtLog.Text &= "From Server: " & TheData & vbCrLf
                    'Analyze Data
                    AnalyzeData(TheData)
                Loop While (TheData <> "~~END~~")
            End If
            Disconnect()
            'Errors can occur if we try to write to the client and it's
            'not there
        Catch IOEx As IOException
            If blnServer Then
                txtLog.Text &= "Closing connection with client..." _
                            & vbCrLf
            Else
                txtLog.Text &= "Closing client connection..." _
                            & vbCrLf
            End If
            Disconnect()
        End Try
        '---End of Example Code---
    End Sub

    '------------------------------------------------------------
    '-      Subprogram Name: AnalyzeData                        -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 4/18/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the thread calls this -
    '- subroutine through the GetData Subroutine. Analyzes the  -
    '- Data taken off the wire and compared to a set number of  -
    '- conditions.                                              –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- TheData - String containing the data from the Wire       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub AnalyzeData(ByVal TheData As String)
        '---Local Variables---
        'Move Variables
        Dim arrMove As String()
        Dim strCharacter As String
        Dim strPosition As String

        'Control Variable
        Dim btnMove As Button

        'Winners/Tie
        If TheData = strWINX Then
            lblResult.Text = TheData
        ElseIf TheData = strWINO Then
            lblResult.Text = TheData
        ElseIf TheData = strTIE Then
            lblResult.Text = TheData
        End If

        'If Any of the Previous options were true then stop both Client and Server
        If TheData = strWINX Or TheData = strWINO Or TheData = strTIE Then
            btnStop.PerformClick()
        End If

        'Move
        If TheData.Contains(" at ") Then
            arrMove = TheData.Split(" at ")
            strCharacter = arrMove(0)
            strPosition = arrMove(2)
            Select Case strPosition
                Case "A1"
                    btnMove = CType(Me.Controls("Button1"), Button)
                Case "A2"
                    btnMove = CType(Me.Controls("Button2"), Button)
                Case "A3"
                    btnMove = CType(Me.Controls("Button3"), Button)
                Case "B1"
                    btnMove = CType(Me.Controls("Button4"), Button)
                Case "B2"
                    btnMove = CType(Me.Controls("Button5"), Button)
                Case "B3"
                    btnMove = CType(Me.Controls("Button6"), Button)
                Case "C1"
                    btnMove = CType(Me.Controls("Button7"), Button)
                Case "C2"
                    btnMove = CType(Me.Controls("Button8"), Button)
                Case "C3"
                    btnMove = CType(Me.Controls("Button9"), Button)
            End Select
            'Set the Opponent's Move on the Board of the Current Player
            btnMove.Text = strCharacter
            btnMove.Enabled = False

            'Check for Any Winning Moves before continuing
            CheckWinningMoves()

            'If no Winning string or Tie string is in the Label
            If Not (lblResult.Text = strWINO Or lblResult.Text = strWINX Or
                lblResult.Text = strTIE) Then
                'Toggle the Current Turn
                ChangeTurn()
            End If

            'Board Setup
        ElseIf TheData.Contains("-") Then
            'Reuse arrMove to set Player and First Moving Player
            arrMove = TheData.Split("-")

            'Set Player For Opposite End
            Select Case CInt(arrMove(0))
                Case 1
                    radP1.Checked = True
                Case 2
                    radP2.Checked = True
            End Select

            'Set Player Going First
            Select Case CInt(arrMove(1))
                Case 1
                    radM1.Checked = True
                Case 2
                    radM2.Checked = True
            End Select

            'Update the Header on the Reciever
            UpdateHeader()

            'Only if this Player Goes First, Make it so that only you can play First
            If intPlayer = intFirstMove Then
                lblResult.Text = strYOURTURN
            Else 'If not, lock Button controls and only allow player two to go.
                lblResult.Text = strOPPONENT_TURN
            End If
        Else
            '"~~END~~" DO NOT DO ANYTHING
        End If
    End Sub

    '------------------------------------------------------------
    '-      Subprogram Name: Disconnect                         -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 4/18/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever an Exception is handled-
    '- or the Stop button is pressed. Disconnects the Network   -
    '- between Client and Server.                               –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub Disconnect()
        '---Code Originally Adapted from Example Program---
        If blnServer Then
            txtLog.Text &= "Attempting to close connection to client..." & vbCrLf
        Else
            txtLog.Text &= "Attempting to disconnect from server..." & vbCrLf
        End If
        'If we are still validly connected to the client, let it know
        'that we are planning on ending our communication session with
        'it.  The string ~~END~~ is our way of saying the conversation
        'is over.
        Try
            NetWriter.Write("~~END~~")
        Catch Ex As Exception
            'We don't need to do anything, but there was a problem
            'communicating with the client
        End Try
        Try
            'Destroy all of the objects that we created
            NetWriter.Close()
            NetReader.Close()
            NetStream.Close()
            If blnServer = True Then
                Server.Stop()
            Else
                Client.Close()
            End If
            NetWriter = Nothing
            NetReader = Nothing
            NetStream = Nothing
            Client = Nothing
            Server = Nothing
            Try
                GetDataThread.Abort()
            Catch Ex As Exception
                'We don't care since we are aborting thread
            End Try
        Catch Ex As Exception
            'We don't have to do anything since we are leaving anyway
        Finally
            If blnServer Then
                txtLog.Text &= "Server has been stopped" & vbCrLf
            Else
                txtLog.Text &= "Disconnected...client closed" & vbCrLf
            End If
        End Try
        '---End of Example Code---
    End Sub

    '--Visual Related--
    '------------------------------------------------------------
    '-      Subprogram Name: UpdateHeader                       -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 4/18/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Form Title needs  -
    '- Attention. Updates the Form Header to the Correct Status.–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub UpdateHeader()
        'Puts initial string in the Text Property of the Main Form
        Me.Text = strTICTACTOE

        'Add Client/Server Identifier
        If blnServer = True Then
            Me.Text &= strSERVERTITLE
        Else
            Me.Text &= strCLIENTTITLE
        End If

        'Add Player Identifier
        Select Case intPlayer
            Case 1
                Me.Text &= strPLAYERX
            Case 2
                Me.Text &= strPLAYERO
        End Select

        'Add First Move Identifier
        Select Case intFirstMove
            Case 1
                Me.Text &= strMV_FRSTX
            Case 2
                Me.Text &= strMV_FRSTO
        End Select
    End Sub

    '------------------------------------------------------------
    '-      Subprogram Name: ToggleServerControls               -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 4/18/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Client and Server -
    '- Radio Buttons are changed. Toggles the Controls for      -
    '- Client/Server Radio Button Selections.                   –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub ToggleServerControls()
        'Based on flag boolean if it is a server or not
        If Not blnServer Then 'It is Client
            'Disable Server Controls
            GroupBox1.Visible = False

            'Enable Client Controls
            lblAddress.Visible = True
            txtServerAddress.Visible = True

            'Change Server Control Text Properties to Client Theme
            lblPort.Text = "Server Port:"
            btnStart.Text = "Start Client"
            btnStop.Text = "Stop Client"
        Else
            'Enable Server Controls
            GroupBox1.Visible = True

            'Disable Client Controls
            lblAddress.Visible = False
            txtServerAddress.Visible = False

            'Change Client Control Text Properties to Server Theme
            lblPort.Text = "Server Listens on Port:"
            btnStart.Text = "Start Server"
            btnStop.Text = "Stop Server"
        End If
    End Sub

    '------------------------------------------------------------
    '-      Subprogram Name: ToggleStartStop                    -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 4/18/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Start and Stop    -
    '- Buttons are Pressed. Prepares the Form for Creating the  -
    '- Link between client and server.                          –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub ToggleStartStop()
        'Toggle Buttons
        btnStart.Enabled = Not btnStart.Enabled
        btnStop.Enabled = Not btnStop.Enabled

        'Toggle Client/Server Configuration Box
        GroupBox5.Enabled = Not GroupBox5.Enabled

        'Disable/Enable Server Controls if Type = Server
        If GroupBox1.Enabled = True And blnServer = True Then
            GroupBox1.Enabled = False
        ElseIf GroupBox1.Enabled = False And blnServer = True Then
            GroupBox1.Enabled = True
        End If

        'Disable/Enable Remaining TextBoxes
        txtServerAddress.Enabled = Not txtServerAddress.Enabled
        txtPort.Enabled = Not txtPort.Enabled
    End Sub

    '--Game Related--
    '------------------------------------------------------------
    '-      Subprogram Name: CreateStartingBoard                -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 4/18/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Start Button is   -
    '- pressed. Creates the Starting Board for Each Player so   -
    '- that it is set up correctly.                             –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- currBtn - Button based on Loop Variable                  -
    '- intLoop - Lop Counter Variable                           -
    '------------------------------------------------------------
    Private Sub CreateStartingBoard()
        '---Local Variables---
        'Loop Variable for For Loop
        Dim intLoop As Integer

        'Current Button based on For Loop
        Dim currBtn As Button

        'If Client/Server is First Move Or Not
        If intPlayer = intFirstMove Then 'Yes
            For intLoop = 1 To 9 'Enable All TicTacToe Board Buttons
                currBtn = CType(Me.Controls("Button" & intLoop), Button)
                currBtn.Enabled = True
            Next
        Else 'No
            For intLoop = 1 To 9 'Disable all TicTacToe Board Buttons
                currBtn = CType(Me.Controls("Button" & intLoop), Button)
                currBtn.Enabled = False
            Next
        End If
    End Sub

    '------------------------------------------------------------
    '-      Subprogram Name: ChangeTurn                         -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 4/18/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Player Needs      -
    '- Switching. Changes the Current Turn in the Game by       - 
    '- switching players.                                       –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- currBtn - Button based on Loop Variable                  -
    '- intLoop - Lop Counter Variable                           -
    '------------------------------------------------------------
    Private Sub ChangeTurn() 'Toggles the Turn Indicator and related Controls
        'Toggle Turn Indicator
        If lblResult.Text = strYOURTURN Then
            lblResult.Text = strOPPONENT_TURN
        Else
            lblResult.Text = strYOURTURN
        End If

        'Toggle On/Off Empty Buttons
        If Button1.Text = Nothing Or Button1.Text = "" Then
            Button1.Enabled = Not Button1.Enabled
        End If
        If Button2.Text = Nothing Or Button2.Text = "" Then
            Button2.Enabled = Not Button2.Enabled
        End If
        If Button3.Text = Nothing Or Button3.Text = "" Then
            Button3.Enabled = Not Button3.Enabled
        End If
        If Button4.Text = Nothing Or Button4.Text = "" Then
            Button4.Enabled = Not Button4.Enabled
        End If
        If Button5.Text = Nothing Or Button5.Text = "" Then
            Button5.Enabled = Not Button5.Enabled
        End If
        If Button6.Text = Nothing Or Button6.Text = "" Then
            Button6.Enabled = Not Button6.Enabled
        End If
        If Button7.Text = Nothing Or Button7.Text = "" Then
            Button7.Enabled = Not Button7.Enabled
        End If
        If Button8.Text = Nothing Or Button8.Text = "" Then
            Button8.Enabled = Not Button8.Enabled
        End If
        If Button9.Text = Nothing Or Button9.Text = "" Then
            Button9.Enabled = Not Button9.Enabled
        End If
    End Sub

    '------------------------------------------------------------
    '-      Subprogram Name: CheckWinningMoves                  -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 4/18/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever a new move is made    -
    '- (before and after). Checks All Probable Winning Moves and-
    '- Every Tie sending the results to the other endpoint.     –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- strOut - Output String to be sent to an endpoint.        -
    '------------------------------------------------------------
    Private Sub CheckWinningMoves()
        '---Local Variables---
        'Output String
        Dim strOut As String

        'Tie Game
        If Button1.Text <> "" And Button2.Text <> "" And Button3.Text <> "" And
            Button4.Text <> "" And Button5.Text <> "" And Button6.Text <> "" And
            Button7.Text <> "" And Button8.Text <> "" And Button9.Text <> "" Then
            strOut = strTIE
        Else 'Not Finished
            strOut = ""
        End If

        'Stright Horizontal
        If (Button1.Text = "X" And Button2.Text = "X" And Button3.Text = "X") Or
            (Button1.Text = "O" And Button2.Text = "O" And Button3.Text = "O") Then
            If Button1.Text = "X" Then
                strOut = strWINX
            Else
                strOut = strWINO
            End If
        ElseIf (Button4.Text = "X" And Button5.Text = "X" And Button6.Text = "X") Or
            (Button4.Text = "O" And Button5.Text = "O" And Button6.Text = "O") Then
            If Button4.Text = "X" Then
                strOut = strWINX
            Else
                strOut = strWINO
            End If
        ElseIf (Button7.Text = "X" And Button8.Text = "X" And Button9.Text = "X") Or
            (Button7.Text = "O" And Button8.Text = "O" And Button9.Text = "O") Then
            If Button7.Text = "X" Then
                strOut = strWINX
            Else
                strOut = strWINO
            End If
        End If

        'Straight Vertical
        If (Button1.Text = "X" And Button4.Text = "X" And Button7.Text = "X") Or
            (Button1.Text = "O" And Button4.Text = "O" And Button7.Text = "O") Then
            If Button1.Text = "X" Then
                strOut = strWINX
            Else
                strOut = strWINO
            End If
        ElseIf (Button2.Text = "X" And Button5.Text = "X" And Button8.Text = "X") Or
            (Button2.Text = "O" And Button5.Text = "O" And Button8.Text = "O") Then
            If Button2.Text = "X" Then
                strOut = strWINX
            Else
                strOut = strWINO
            End If
        ElseIf (Button3.Text = "X" And Button6.Text = "X" And Button9.Text = "X") Or
            (Button3.Text = "O" And Button6.Text = "O" And Button9.Text = "O") Then
            If Button3.Text = "X" Then
                strOut = strWINX
            Else
                strOut = strWINO
            End If
        End If

        'Diagonal - Left to Right
        If (Button1.Text = "X" And Button5.Text = "X" And Button9.Text = "X") Or
            (Button1.Text = "O" And Button5.Text = "O" And Button9.Text = "O") Then
            If Button1.Text = "X" Then
                strOut = strWINX
            Else
                strOut = strWINO
            End If
        End If

        'Diagonal - Right to Left
        If (Button7.Text = "X" And Button5.Text = "X" And Button3.Text = "X") Or
            (Button7.Text = "O" And Button5.Text = "O" And Button3.Text = "O") Then
            If Button7.Text = "X" Then
                strOut = strWINX
            Else
                strOut = strWINO
            End If
        End If

        'If Game is Finished, Send to Other Endpoint
        If strOut <> "" Then
            lblResult.Text = strOut
            NetWriter.Write(strOut)
        End If
    End Sub

    '------------------------------------------------------------
    '-      Subprogram Name: ClearMoves                  -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 4/18/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever a new Game is initiated–
    '- Resets the Board so you can replay.                      -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub ClearMoves()
        'Clear All Buttons and Enable
        If Button1.Text = "X" Or Button1.Text = "O" Or Button1.Enabled = False Then
            Button1.Enabled = True
            Button1.Text = ""
        End If
        If Button2.Text = "X" Or Button2.Text = "O" Or Button2.Enabled = False Then
            Button2.Enabled = True
            Button2.Text = ""
        End If
        If Button3.Text = "X" Or Button3.Text = "O" Or Button3.Enabled = False Then
            Button3.Enabled = True
            Button3.Text = ""
        End If
        If Button4.Text = "X" Or Button4.Text = "O" Or Button4.Enabled = False Then
            Button4.Enabled = True
            Button4.Text = ""
        End If
        If Button5.Text = "X" Or Button5.Text = "O" Or Button5.Enabled = False Then
            Button5.Enabled = True
            Button5.Text = ""
        End If
        If Button6.Text = "X" Or Button6.Text = "O" Or Button6.Enabled = False Then
            Button6.Enabled = True
            Button6.Text = ""
        End If
        If Button7.Text = "X" Or Button7.Text = "O" Or Button7.Enabled = False Then
            Button7.Enabled = True
            Button7.Text = ""
        End If
        If Button8.Text = "X" Or Button8.Text = "O" Or Button8.Enabled = False Then
            Button8.Enabled = True
            Button8.Text = ""
        End If
        If Button9.Text = "X" Or Button9.Text = "O" Or Button9.Enabled = False Then
            Button9.Enabled = True
            Button9.Text = ""
        End If
    End Sub
End Class
