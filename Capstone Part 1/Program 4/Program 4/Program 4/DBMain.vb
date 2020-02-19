'------------------------------------------------------------
'-                File Name : DBMain.vb         - 
'-                Part of Project: Assignment 4             -
'------------------------------------------------------------
'-                Written By: Austin Sliter                 -
'-                Written On: 10/11/18                      -
'------------------------------------------------------------
'- File Purpose:                                            -
'- This file contains the DBMain Module, responsible for    -
'- primary database operations such as Creating, Deleting,  -
'- Inserting Default Values into Relevant Tables and Clearing-
'- Tables.                                                  - 
'------------------------------------------------------------
Imports System.Data.SqlClient
Module DBMain
    'Name of the Local Database
    Const strDB_NAME As String = "Dispatch_DB"

    'SQL Server Location
    Const strSQL_LOC As String = "(localdb)\MSSQLLocalDB"

    'Location of the Database
    Dim strDB_PATH As String = My.Application.Info.DirectoryPath &
                                  "\" & strDB_NAME & ".mdf"
    'Full Connection String
    Dim strDBCONN As String = "SERVER=" & strSQL_LOC & ";DATABASE=" &
                     strDB_NAME & ";Integrated Security=SSPI;AttachDbFileName=" &
                     strDB_PATH

    '------------------------------------------------------------
    '-                Subprogram Name: MakeDatabase             -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called from the Application_Startup   -
    '- event if the database file doesn't exist. This subroutine-
    '- relays commands to the relavent subroutines to make a new-
    '- database and populate with default data.                 -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Sub MakeDatabase()
        'Create a New Database and related tables
        CreateDatabase(strSQL_LOC, strDB_NAME, strDB_PATH, strDBCONN)

        'Make sure all tables are cleaned out each time we run the program
        'Delete Foreign Key Dependant tables first to prevent exceptions in clearing 
        'main tables (Most FKs to Least FKs)
        ClearDB_Tbl(strDBCONN, "BOM")
        ClearDB_Tbl(strDBCONN, "OrdersToProduct")
        ClearDB_Tbl(strDBCONN, "Orders")
        ClearDB_Tbl(strDBCONN, "Inventory")
        ClearDB_Tbl(strDBCONN, "Product")
        ClearDB_Tbl(strDBCONN, "Customer")
        ClearDB_Tbl(strDBCONN, "AssemblyArea")

        'Put Default data into the tables
        'Populate in Table Creation Order to prevent Foreign Key Dependancy Exceptions
        PopulateDB_InvTbl(strDBCONN)
        PopulateDB_ProdTbl(strDBCONN)
        PopulateDB_CustTbl(strDBCONN)
        PopulateDB_BOMTbl(strDBCONN)
        PopulateDB_AssemblyAreaTbl(strDBCONN)
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: ResetDB                  -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called from frmMain with the Reset    -
    '- Database Button. This subroutine is a relay to give      -
    '- instructions to the relavent subroutines to clear all    -
    '- database tables and repopulate with default data.        -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Sub ResetDB()
        'Make sure all tables are cleaned out each time we run the program
        'Delete Foreign Key Dependant tables first to prevent exceptions in clearing 
        'main tables (Most FKs to Least FKs)
        ClearDB_Tbl(strDBCONN, "BOM")
        ClearDB_Tbl(strDBCONN, "OrdersToProduct")
        ClearDB_Tbl(strDBCONN, "Orders")
        ClearDB_Tbl(strDBCONN, "Inventory")
        ClearDB_Tbl(strDBCONN, "Product")
        ClearDB_Tbl(strDBCONN, "Customer")
        ClearDB_Tbl(strDBCONN, "AssemblyArea")

        'Put Default data into the tables
        'Populate in Table Creation Order to prevent Foreign Key Dependancy Exceptions
        PopulateDB_InvTbl(strDBCONN)
        PopulateDB_ProdTbl(strDBCONN)
        PopulateDB_CustTbl(strDBCONN)
        PopulateDB_BOMTbl(strDBCONN)
        PopulateDB_AssemblyAreaTbl(strDBCONN)
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: CreateDatabase            -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called from the MakeDatabase Relay    -
    '- Subroutine. This Subroutine Creates the Database file on -
    '- Disk and the Relavent Tables.                            -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- strServerName - The DB Server Name                       -
    '- strDatabaseName - The Database Name                      -
    '- strDatabasePath - The Path where Database File is Located-
    '- strConnection - The Full Connection String               -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- DBConn - SQL Connection                                  -
    '- DBCmd - SQLCommand                                       -
    '- strSQLCmd - String of SQL Command                        -
    '------------------------------------------------------------
    Private Sub CreateDatabase(strServerName As String, strDatabaseName As String,
                            strDatabasePath As String, strConnection As String)
        'Adapted and enhanced from original from CIS311 Example Code
        'Let's build a SQL Server database from scratch
        Dim DBConn As SqlConnection
        Dim strSQLCmd As String
        Dim DBCmd As SqlCommand

        'All we need to do initially is just point at the server
        DBConn = New SqlConnection("Server=" & strServerName)

        'Let's write a SQL DDL Command to build the database
        'There are a lot of other parameters but we can let them default
        'All we need are these three
        strSQLCmd = "CREATE DATABASE " & strDatabaseName & " On " &
                    "(NAME = '" & strDatabaseName & "', " &
                    "FILENAME = '" & strDatabasePath & "')"

        DBCmd = New SqlCommand(strSQLCmd, DBConn)

        Try
            'Open the connection and try running the command
            DBConn.Open()
            DBCmd.ExecuteNonQuery()
            MessageBox.Show("Database was successfully created!", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            'If we can't build the database, we are dead in the water so bail...
            MessageBox.Show(ex.ToString(), "Database Exception Caught - Trace", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MessageBox.Show("Cannot build database!  Closing program down...", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try

        'We are currently pointing at the [MASTER] database, so we
        'need to close the connection and reopen it pointing at the
        'Registration database...
        If (DBConn.State = ConnectionState.Open) Then
            DBConn.Close()
        End If

        'Now we need to use the full connection string with the Integrated 
        'Security line, et cetera
        DBConn = New SqlConnection(strConnection)
        DBConn.Open()

        'Build All the Tables one at a time
        'Build the Inventory Table by writing the SQL DDL Command
        DBCmd.CommandText = "CREATE TABLE Inventory (" &
                             "TUID int Primary Key NOT NULL, " &
                             "Inv_Name nvarchar(50), " &
                             "Qty_OnHand int)"
        DBCmd.Connection = DBConn

        Try
            DBCmd.ExecuteNonQuery()
            MessageBox.Show("Created Inventory Table", "Table Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch Ex As Exception
            MessageBox.Show("Inventory Table Already Exists", "Exception Caught", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        'Build the Product Table by writing the SQL DDL Command
        DBCmd.CommandText = "CREATE TABLE Product (" &
                             "TUID int Primary Key NOT NULL, " &
                             "Prod_Name nvarchar(50), " &
                             "Assembly_Time int)"
        DBCmd.Connection = DBConn
        Try
            DBCmd.ExecuteNonQuery()
            'Debug
            MessageBox.Show("Created Product Table", "Table Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch Ex As Exception
            'Debug
            MessageBox.Show("Product Table Already Exists", "Exception Caught", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        'Build the Customer Table by writing the SQL DDL Command
        DBCmd.CommandText = "CREATE TABLE Customer (" &
                             "TUID int NOT NULL Primary Key, " &
                             "Cust_Name nvarchar(50), " &
                             "Cust_Phone nvarchar(50))"
        DBCmd.Connection = DBConn
        Try
            DBCmd.ExecuteNonQuery()
            'Debug
            MessageBox.Show("Created Customer Table", "Table Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch Ex As Exception
            'Debug
            MessageBox.Show("Customer Table Already Exists", "Exception Caught", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        'Build the Orders Table by writing the SQL DDL Command
        DBCmd.CommandText = "CREATE TABLE Orders (" &
                             "TUID int NOT NULL Primary Key, " &
                             "Cust_TUID int Not Null, " &
                             "AssemblyArea int CHECK(AssemblyArea<=5), " &
                             "StartDateTm Datetime, " &
                             "EndDateTm Datetime, " &
                             "Foreign Key(Cust_TUID) References Customer(TUID))"
        Try
            DBCmd.ExecuteNonQuery()
            'Debug
            MessageBox.Show("Created Orders Table", "Table Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch Ex As Exception
            'Debug
            MessageBox.Show("Orders Table Already Exists", "Exception Caught", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        'Build the Ord_To_Prod Table by writing the SQL DDL Command
        DBCmd.CommandText = "CREATE TABLE OrdersToProduct (" &
                             "TUID int Primary Key NOT NULL, " &
                             "Orders_TUID int, " &
                             "Prod_TUID int, " &
                             "Quantity int, " &
                             "Foreign Key(Orders_TUID) References Orders(TUID), " &
                             "Foreign Key(Prod_TUID) References Product(TUID))"
        DBCmd.Connection = DBConn
        Try
            DBCmd.ExecuteNonQuery()
            MessageBox.Show("Created OrderToProduct Table", "Table Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch Ex As Exception
            MessageBox.Show("OrderToProduct Table Already Exists", "Exception Caught", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        'Build the BOM Table by writing the SQL DDL Command
        DBCmd.CommandText = "CREATE TABLE BOM (" &
                             "TUID int Primary Key NOT NULL, " &
                             "Prod_TUID int, " &
                             "Inv_TUID int, " &
                             "Qty_Required int, " &
                             "Foreign Key(Prod_TUID) References Product(TUID), " &
                             "Foreign Key(Inv_TUID) References Inventory(TUID))"
        DBCmd.Connection = DBConn
        Try
            DBCmd.ExecuteNonQuery()
            'Debug
            MessageBox.Show("Created BOM Table", "Table Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch Ex As Exception
            'Debug
            MessageBox.Show("BOM Table Already Exists", "Exception Caught", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        'Build the AssemblyArea Table by writing the SQL DDL Command
        DBCmd.CommandText = "CREATE TABLE AssemblyArea (" &
                             "TUID int Primary Key NOT NULL, " &
                             "NextFree DateTime NOT NULL)"
        DBCmd.Connection = DBConn
        Try
            DBCmd.ExecuteNonQuery()
            'Debug
            MessageBox.Show("Created Assembly Area Table", "Table Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch Ex As Exception
            'Debug
            MessageBox.Show("Assembly Area Table Already Exists", "Exception Caught", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        'We can check to see if we're open before trying to
        'issue a connection close
        If (DBConn.State = ConnectionState.Open) Then
            DBConn.Close()
        End If
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: ClearDBTbl               -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called from the MakeDatabase Relay    -
    '- Subroutine. This will clear any table in the database,   -
    '- given a table name and the full connection string.       -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- strConnection - Full Connection String                   -
    '- strTblName - The Name of the Table to Clear              -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub ClearDB_Tbl(strConnection As String, strTblName As String)
        'Adapted from CIS 311/422 Example Code
        Dim DBConn As SqlConnection
        Dim DBCmd As SqlCommand = New SqlCommand()

        'Now try to open up a connection to the database
        DBConn = New SqlConnection(strConnection)
        DBConn.Open()

        'Use SQL DML to zap the contents of the table
        DBCmd.CommandText = "DELETE FROM " & strTblName
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        'Debug
        MessageBox.Show("Deleted Everything In " & strTblName & " Table", "Cleared Table", MessageBoxButtons.OK, MessageBoxIcon.Information)

        DBConn.Close()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: PopulateDB_InvTbl        -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called from the MakeDatabase Relay    -
    '- Subroutine. This Subroutine Populates the Inventory table-
    '- with default values.                                     -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- strConnection - The Full Connection String               -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- DBConn - SQL Connection                                  -
    '- DBCmd - SQL Command                                      -
    '------------------------------------------------------------
    Private Sub PopulateDB_InvTbl(strConnection As String)
        'Adapted from CIS 311 Example Code
        Dim DBConn As SqlConnection
        Dim DBCmd As SqlCommand = New SqlCommand()

        'Now try to open up a connection to the database
        DBConn = New SqlConnection(strConnection)
        DBConn.Open()

        'Add first Inventory Item using SQL DML
        DBCmd.CommandText = "INSERT INTO Inventory (TUID, Inv_Name, Qty_OnHand) " &
                            "VALUES (1, 'Top', 1000), (2, 'Leg', 1500), " &
                            "(3, 'Fastener', 5000), (4, 'Short Side', 1500), " &
                            "(5, 'Long Side', 1500), (6, 'Wheel', 2000)"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBConn.Close()
        'Debug
        MessageBox.Show("Added Default Inventory Stocks", "Added Default Values", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: PopulateDB_ProdTbl       -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called from the MakeDatabase Relay    -
    '- Subroutine. This Subroutine Populates the Product table  -
    '- with default values.                                     -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- strConnection - The Full Connection String               -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- DBConn - SQL Connection                                  -
    '- DBCmd - SQL Command                                      -
    '------------------------------------------------------------
    Private Sub PopulateDB_ProdTbl(strConnection As String)
        'Adapted from CIS 311 Example Code
        Dim DBConn As SqlConnection
        Dim DBCmd As SqlCommand = New SqlCommand()

        'Now try to open up a connection to the database
        DBConn = New SqlConnection(strConnection)
        DBConn.Open()

        DBCmd.CommandText = "INSERT into Product (TUID, Prod_Name, Assembly_Time) " &
                            "VALUES (1, 'Table', 10), (2, 'Wagon', 20), " &
                            "(3, 'Skateboard', 5), (4, 'Chair', 15)"

        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBConn.Close()
        'Debug
        MessageBox.Show("Added Default Products Available", "Added Default Values", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: PopulateDB_CustTbl       -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called from the MakeDatabase Relay    -
    '- Subroutine. This Subroutine Populates the Customer table-
    '- with default values.                                     -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- strConnection - The Full Connection String               -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- DBConn - SQL Connection                                  -
    '- DBCmd - SQL Command                                      -
    '------------------------------------------------------------
    Private Sub PopulateDB_CustTbl(strConnection As String)
        'Adapted from CIS 311 Example Code
        Dim DBConn As SqlConnection
        Dim DBCmd As SqlCommand = New SqlCommand()

        'Now try to open up a connection to the database
        DBConn = New SqlConnection(strConnection)
        DBConn.Open()

        'Add a student using SQL DML
        DBCmd.CommandText = "INSERT INTO Customer (TUID, Cust_Name, Cust_Phone) " &
                            "VALUES (104,'James Kirk', '(123)-456-7890'), " &
                            "(117, 'Montgomery Scott', '(987)-654-3210'), " &
                            "(102, 'Leonard McCoy', '(345)-123-3345'), " &
                            "(109, 'Hikaru Sulu', '(567)-123-4456'), " &
                            "(107, 'Pavell Chekov', '(997)-234-8876'), " &
                            "(154, 'Kathryn Janeway', '(778)-345-5675'), " &
                            "(143, 'Jean-Luc Picard', '(121)-345-6547'), " &
                            "(119, 'Geordie LaForge', '(222)-333-4454'), " &
                            "(137, 'William Riker', '(565)-999-8856'), " &
                            "(147, 'Karl Jeager', '(656)-098-7843'), " &
                            "(132, 'Henry Morgan', '(453)-986-5678'), " &
                            "(133, 'Albert Einstein', '(787)-345-8675')"

        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBConn.Close()
        'Debug
        MessageBox.Show("Added Default Customers In System", "Added Default Values", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: PopulateDB_BOMTbl        -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called from the MakeDatabase Relay    -
    '- Subroutine. This Subroutine Populates the BOM table      -
    '- with default values.                                     -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- strConnection - The Full Connection String               -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- DBConn - SQL Connection                                  -
    '- DBCmd - SQL Command                                      -
    '------------------------------------------------------------
    Private Sub PopulateDB_BOMTbl(strConnection As String)
        'Adapted from CIS 311 Example Code
        Dim DBConn As SqlConnection
        Dim DBCmd As SqlCommand = New SqlCommand()

        'Now try to open up a connection to the database
        DBConn = New SqlConnection(strConnection)
        DBConn.Open()

        'Add a student using SQL DML
        DBCmd.CommandText = "INSERT INTO BOM (TUID, Prod_TUID, Inv_TUID, Qty_Required) " &
                            "VALUES (1, 1, 1, 1), (2, 1, 2, 4), " &
                            "(3, 1, 3, 4), (4, 2, 1, 1), " &
                            "(5, 2, 6, 8), (6, 2, 3, 8), " &
                            "(7, 2, 5, 2), (8, 2, 4, 2), " &
                            "(9, 3, 5, 1), (10, 3, 6, 4), " &
                            "(11, 3, 3, 4), (12, 4, 1, 1), " &
                            "(13, 4, 4, 1), (14, 4, 2, 4), " &
                            "(15, 4, 3, 6)"

        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBConn.Close()
        'Debug
        MessageBox.Show("Added Default BOM Values", "Added Default Values", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    '------------------------------------------------------------
    '-              Subprogram Name: PopulateDB_AssemblyAreaTbl -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called from the MakeDatabase Relay    -
    '- Subroutine. This Subroutine Populates the Assembly Area  -
    '- table with default values.                               -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- strConnection - The Full Connection String               -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- DBConn - SQL Connection                                  -
    '- DBCmd - SQL Command                                      -
    '------------------------------------------------------------
    Private Sub PopulateDB_AssemblyAreaTbl(strConnection As String)
        'Adapted from CIS 311 Example Code
        Dim DBConn As SqlConnection
        Dim DBCmd As SqlCommand = New SqlCommand()

        'Now try to open up a connection to the database
        DBConn = New SqlConnection(strConnection)
        DBConn.Open()

        'Add a student using SQL DML
        DBCmd.CommandText = "Insert Into AssemblyArea (TUID, NextFree)" &
            "Values (1,'" & DateTime.Now.Date.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss") & "'), " &
            "(2,'" & DateTime.Now.Date.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss") & "'), " &
            "(3,'" & DateTime.Now.Date.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss") & "'), " &
            "(4,'" & DateTime.Now.Date.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss") & "'), " &
            "(5,'" & DateTime.Now.Date.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss") & "')"

        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBConn.Close()
        'Debug
        MessageBox.Show("Added Default AssemblyArea Values", "Added Default Values", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: DeleteDatabase           -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called from frmMain if user says Yes to-
    '- Database Deletion. This Subroutine deletes the entire    -
    '- database, file and all.                                  -                                     -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (none)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- DBConn - SQL Connection                                  -
    '- DBCmd - SQL Command                                      -
    '- strSQLCmd = String representation of SQL Command         -
    '------------------------------------------------------------
    Sub DeleteDatabase()
        'Complete Deletes Current Database
        Dim DBConn As SqlConnection
        Dim strSQLCmd As String
        Dim DBCmd As SqlCommand

        MessageBox.Show("Preparing to Delete Database. Do not attempt to close the form while this being done!", "Database Deletion in Progress", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Point to Master Database Again
        DBConn = New SqlConnection("Server=" & strSQL_LOC)

        'Force Single Ownership of Database
        strSQLCmd = "ALTER DATABASE [" & strDB_NAME & "] SET " &
            "SINGLE_USER WITH ROLLBACK IMMEDIATE"
        DBCmd = New SqlCommand(strSQLCmd, DBConn)
        Try
            DBConn.Open()
            DBCmd.ExecuteNonQuery()
            MessageBox.Show("Database Set to Exclusive Use!", "Database Deletion Progress Report", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Exception Caught - Trace", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If DBConn.State = ConnectionState.Open Then
            DBConn.Close()
        End If

        'Drop Database
        strSQLCmd = "DROP DATABASE " & strDB_NAME
        DBCmd = New SqlCommand(strSQLCmd, DBConn)

        Try
            DBConn.Open()
            DBCmd.ExecuteNonQuery()
            MessageBox.Show("Database Deleted Successfully! Program will Now Terminate!", "Database Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Exception Caught - Trace", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If DBConn.State = ConnectionState.Open Then
            DBConn.Close()
        End If
    End Sub
End Module
