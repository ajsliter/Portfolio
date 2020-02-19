'------------------------------------------------------------
'-                File Name : ApplicationEvents.vb          - 
'-                Part of Project: Assignment 4             -
'------------------------------------------------------------
'-                Written By: Austin Sliter                 -
'-                Written On: 10/11/18                      -
'------------------------------------------------------------
'- File Purpose:                                            -
'- This file contains the My Namespace and MyApplication Class.-
'- This Class will be called when the Program starts, which -
' -will check the install directory for the Database File.  -
'- If not Found, Will create the Database.                  - 
'------------------------------------------------------------
Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        'Name of the Local Database
        Const strDB_NAME As String = "Dispatch_DB"

        'SQL Server Location
        Const strSQL_LOC As String = "(localdb)\MSSQLLocalDB"

        'Location of the Database
        Dim strDB_PATH As String

        '------------------------------------------------------------
        '-                Subprogram Name: MyApplication_Startup    -
        '------------------------------------------------------------
        '-                Written By: Austin Sliter                 -
        '-                Written On: 10/11/18                      -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the Program starts up.-
        '– Checks the filesystem for the Database File in the install-
        '- directory. If Not Found it creates a new one.            -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- FileExists - Boolean To tell if the File exists or not.  -
        '------------------------------------------------------------
        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            'Adapted from CIS 311 Example Code
            'If the database doesn't exist, create it locally
            Dim FileExists As Boolean = False
            strDB_PATH = My.Application.Info.DirectoryPath &
                                  "\" & strDB_NAME & ".mdf"
            FileExists = My.Computer.FileSystem.FileExists(strDB_PATH)
            If Not (FileExists) Then
                MakeDatabase()
            End If
        End Sub
    End Class
End Namespace
