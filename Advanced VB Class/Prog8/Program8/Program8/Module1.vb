'------------------------------------------------------------
'-                File Name : Module1.vb                    - 
'-                Part of Project: Assignment 8             -
'------------------------------------------------------------
'-                Written By: Austin Sliter                 -
'-                Written On: 3/29/18                       -
'------------------------------------------------------------
'- File Purpose:                                            -
'- This file contains Sub Main() That Calls the Main        -
'- Application Form and sets up the database before showing -
'- the main form.                                           - 
'------------------------------------------------------------
Imports System.Data.SqlClient

Module Module1
    '------------------------------------------------------------
    '-                Subprogram Name: Main                     -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine at program startup. No Inputs. Readies the-
    '- Database and then Calls the Main application Form to take -
    '- over.                                                    –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- strDBPATH - The Database Path                            -
    '- strCONNECTION - The Full Database Link                   -
    '------------------------------------------------------------
    Sub Main()
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

        'If the database doesn't exist, create it
        If Not (System.IO.File.Exists(strDBPATH)) Then
            CreateDatabase(strSERVERNAME, strDBNAME, strDBPATH, strCONNECTION)
        End If

        'Make sure all tables are cleaned out each time we run this
        CleanOutOwnersTable(strCONNECTION)
        CleanOutVehiclesTable(strCONNECTION)

        'Put some data into the tables
        PopulateOwnersTable(strCONNECTION)  '3 Owner records
        PopulateVehiclesTable(strCONNECTION)   '5 Vehicle Records

        'Show the main dialog
        frmVehicles.ShowDialog()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: CreateDatabase           -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called from Sub Main when the Database-
    '- needs to be created.                                     –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- strSERVERNAME - The Database Server Name                 -
    '- strDBNAME - The Name of the database                     -
    '- strDBPATH - the Path of the Database                     -
    '- strCONNECTION - The Connection Logic for hte Database    -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- DBConn - The Database Connection in SQL                  -
    '- DBCmd - an Sql command object to create the database     -
    '- strSQLCmd - The string version of the command.           -
    '------------------------------------------------------------
    Sub CreateDatabase(ByVal strSERVERNAME As String, ByVal strDBNAME As String,
                       ByVal strDBPATH As String, ByVal strCONNECTION As String)
        'Create New Database
        Dim DBConn As SqlConnection
        Dim strSQLCmd As String
        Dim DBCmd As SqlCommand

        'Point at the server
        DBConn = New SqlConnection("Server=" & strSERVERNAME)

        'SQL DDL Command to build the database
        strSQLCmd = "CREATE DATABASE " & strDBNAME & " On " &
                    "(NAME = '" & strDBNAME & "', " &
                    "FILENAME = '" & strDBPATH & "')"

        DBCmd = New SqlCommand(strSQLCmd, DBConn)

        Try
            'Open connection and try running the command
            DBConn.Open()
            DBCmd.ExecuteNonQuery()
            MessageBox.Show("Database was successfully created", "Database Created",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            'If we can't build the database, bail out...
            MessageBox.Show(ex.ToString())
            MessageBox.Show("Cannot build database!  Program will Terminate...",
                            "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try

        'Close the connection and reopen it pointing at the
        'Autos database...
        If (DBConn.State = ConnectionState.Open) Then
            DBConn.Close()
        End If

        'Use the full connection string.
        DBConn = New SqlConnection(strCONNECTION)
        DBConn.Open()

        'Build all Tables
        'Specify Connection for DDL Queries
        DBCmd.Connection = DBConn
        'Building Owner Table
        DBCmd.CommandText = "CREATE TABLE Owners (" &
                             "TUID int NOT NULL, " &
                             "FirstName varchar(50) NULL, " &
                             "LastName varchar(50) NULL, " &
                             "StreetAddress varchar(50) NULL, " &
                             "City varchar(50) NULL, " &
                             "State varchar(50) NULL, " &
                             "ZipCode varchar(50) NULL, " &
                             "Primary Key Clustered (TUID ASC))"
        Try
            DBCmd.ExecuteNonQuery()
            MessageBox.Show("Created Vehicle Owners Table",
                            "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch Ex As Exception
            MessageBox.Show("Owners Table Already Exists",
                            "System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        'Build the Courses Table
        DBCmd.CommandText = "CREATE TABLE Vehicles (" &
                                     "TUID int NOT NULL, " &
                                     "OwnerID int NUll, " &
                                     "Make varchar(50) NUll, " &
                                     "Model varchar(50) NUll, " &
                                     "Color varchar(50) NUll, " &
                                     "ModelYear int NUll, " &
                                     "VIN varchar(50), " &
                                     "Primary Key Clustered (TUID ASC))"
        Try
            DBCmd.ExecuteNonQuery()
            MessageBox.Show("Created Courses Table", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch Ex As Exception
            MessageBox.Show("Courses Table Already Exists", "System Warning",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        'Check to see if any active connections are open before 
        'issuing a connection close
        If (DBConn.State = ConnectionState.Open) Then
            DBConn.Close()
        End If
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: CleanOutOwnersTable      -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called from sub Main when the Tables  -
    '- need to be restored to defaults. Clears the table.       –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- strConn - The Database Connection                        -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- DBConnection - The Sql Connection to Database            -
    '- DBCmd - The sql comman to Clear the table                -
    '------------------------------------------------------------
    Sub CleanOutOwnersTable(ByVal strConn As String)
        Dim DBConn As SqlConnection
        Dim DBCmd As SqlCommand = New SqlCommand()

        'Now try to open up a connection to the database
        DBConn = New SqlConnection(strConn)
        DBConn.Open()

        'Use SQL DML to zap the contents of the table
        DBCmd.CommandText = "DELETE FROM Owners"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()
        'MessageBox.Show("Deleted Everything In Students",
        '                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        DBConn.Close()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: CleanOutVehiclesTable    -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called from sub Main when the Tables  -
    '- need to be restored to defaults. Clears the table.       –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- strConn - The Database Connection                        -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- DBConnection - The Sql Connection to Database            -
    '- DBCmd - The sql comman to Clear the table                -
    '------------------------------------------------------------
    Sub CleanOutVehiclesTable(ByVal strConn As String)
        Dim DBConn As SqlConnection
        Dim DBCmd As SqlCommand = New SqlCommand()

        'Now try to open up a connection to the database
        DBConn = New SqlConnection(strConn)
        DBConn.Open()

        'Use SQL DML to zap the contents of the table
        DBCmd.CommandText = "DELETE FROM Vehicles"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()
        'MessageBox.Show("Deleted Everything In Vehicles",
        '                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        DBConn.Close()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: PopulateOwnersTable      -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called from Sub Main when the tables  -
    '- need to be populated with default data. Populates one table–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- strConn - The Database Connection                        -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- DBConnection - The Sql Connection to Database            -
    '- DBCmd - The sql comman to Clear the table                -
    '------------------------------------------------------------
    Sub PopulateOwnersTable(ByVal strConn As String)
        Dim DBConn As SqlConnection
        Dim DBCmd As SqlCommand = New SqlCommand()

        'Now try to open up a connection to the database
        DBConn = New SqlConnection(strConn)
        DBConn.Open()

        'Define the Default Command Connection
        DBCmd.Connection = DBConn

        'Add all owners using SQL DDL
        DBCmd.CommandText = "INSERT INTO Owners (TUID, FirstName, LastName, StreetAddress, City, State, ZipCode) " &
                            "VALUES (1,'Tom','Thomas','123 Elm St.','Saginaw','MI','48604')"
        DBCmd.ExecuteNonQuery()
        DBCmd.CommandText = "INSERT INTO Owners (TUID, FirstName, LastName, StreetAddress, City, State, ZipCode) " &
                            "VALUES (2,'Jane','Jones','456 Pine Ct.','Saginaw','MI','48605')"
        DBCmd.ExecuteNonQuery()
        DBCmd.CommandText = "INSERT INTO Owners (TUID, FirstName, LastName, StreetAddress, City, State, ZipCode) " &
                            "VALUES (3,'Bob','Fredericks','789 Maple Rd.','Birch Run','MI','48415')"
        DBCmd.ExecuteNonQuery()


        DBConn.Close()
        'MessageBox.Show("Added Default Owners To Owners Table",
        '                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: PopulateVehiclesTable    -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 3/29/18                       -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called from Sub Main when the tables  -
    '- need to be populated with default data. Populates one table–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- strConn - The Database Connection                        -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- DBConnection - The Sql Connection to Database            -
    '- DBCmd - The sql comman to Clear the table                -
    '------------------------------------------------------------
    Sub PopulateVehiclesTable(ByVal strConn As String)
        Dim DBConn As SqlConnection
        Dim DBCmd As SqlCommand = New SqlCommand()

        'Now try to open up a connection to the database
        DBConn = New SqlConnection(strConn)
        DBConn.Open()

        'Set Up Default Connection for default command connection
        DBCmd.Connection = DBConn

        'Add Vehicles using SQL DDL
        DBCmd.CommandText = "INSERT INTO Vehicles (TUID, OwnerID, Make, Model, Color, ModelYear, 
                             VIN) " &
           "VALUES (1,1,'Chevy','Malibu','Blue',2018,'14XA1394394')"
        DBCmd.ExecuteNonQuery()
        DBCmd.CommandText = "INSERT INTO Vehicles (TUID, OwnerID, Make, Model, Color, ModelYear, 
                             VIN) " &
           "VALUES (2,2,'Ford','F-150','Red',2017,'2A7764747236')"
        DBCmd.ExecuteNonQuery()
        DBCmd.CommandText = "INSERT INTO Vehicles (TUID, OwnerID, Make, Model, Color, ModelYear, 
                             VIN) " &
           "VALUES (3,2,'Volkswagen','Beetle 1500cc','Black',1967,'56B6D7667')"
        DBCmd.ExecuteNonQuery()
        DBCmd.CommandText = "INSERT INTO Vehicles (TUID, OwnerID, Make, Model, Color, ModelYear, 
                             VIN) " &
           "VALUES (4,3,'Volkswagen','Jetta','Blue',2013,'1A1467464484')"
        DBCmd.ExecuteNonQuery()
        DBCmd.CommandText = "INSERT INTO Vehicles (TUID, OwnerID, Make, Model, Color, ModelYear, 
                             VIN) " &
           "VALUES (5,3,'DeLorean','DMC-12','Silver',1985,'1S4A1W94E94')"
        DBCmd.ExecuteNonQuery()

        DBConn.Close()
        'MessageBox.Show("Added Default Vehicles To Vehicles Table",
        '                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Module