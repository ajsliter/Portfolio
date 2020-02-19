'------------------------------------------------------------
'-                File Name : frmMain.vb                    - 
'-                Part of Project: Assignment 4             -
'------------------------------------------------------------
'-                Written By: Austin Sliter                 -
'-                Written On: 10/11/18                      -
'------------------------------------------------------------
'- File Purpose:                                            -
'- This file contains the main application form where the   -
'- user will input an Order manually or through a Text File.- 
'- The User Can Do Other Things such as Generate a Report   -
'- about all Current Orders in the System, Reset the Database-
'- and a Seperate Exit Button.                              -
'------------------------------------------------------------
'- Program Purpose:                                         -
'-                                                          -
'- This program Allows the user to input Orders manually or -
'- through a Text File.                                     - 
'- The User Can Do Other Things such as Generate a Report   -
'- about all Current Orders in the System, Reset the Database-
'- and a Seperate Exit Button.                              -                -
'------------------------------------------------------------
'- Global Variable Dictionary (alphabetically):             -
'- intCurrArea - The Currently Selected Assembly Area to be -
'-               Assigned.                                  -
'- lstAreasNextAvail - A List to Keep Track of Assembly Area-
'-                     Timetables.                          -
'- strDBCONN - Full Connection String                       -
'- strDB_Path - Full DB Path                                -
'------------------------------------------------------------
Imports System.ComponentModel
Imports System.Data.SqlClient
Public Class frmMain
    'Name of the Local Database
    Const strDB_NAME As String = "Dispatch_DB"

    'SQL Server Location
    Const strSQL_LOC As String = "(localdb)\MSSQLLocalDB"

    'Next Available Times
    Dim lstAreasNextAvail As New List(Of DateTime)

    'Current Assembly Area - Initialized to 1
    Dim intCurrArea As Integer = 1

    'Location of the Database
    Dim strDB_PATH As String = My.Application.Info.DirectoryPath &
                                  "\" & strDB_NAME & ".mdf"
    'Full Connection String
    Dim strDBCONN As String = "SERVER=" & strSQL_LOC & ";DATABASE=" &
                     strDB_NAME & ";Integrated Security=SSPI;AttachDbFileName=" &
                     strDB_PATH

    '---Application Events---
    '------------------------------------------------------------
    '-                Subprogram Name: frmMain_Load             -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Form is Loaded.   -
    '- It Refreshes All DataSource Dependant Controls to prepare-
    '- the form for the user.                                   -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Get DataGridViews Populated
        RefreshInventory()
        RefreshAssignedWork()

        'Refresh Available Products
        RefreshAvailProducts()
        'Refresh Available Customers
        RefreshAvailCusts()
        'Refresh New Order Number
        RefreshOrderNumber()
        'Get Next Available Times
        GetAvailTimes()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnAdd_Click             -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Add to Order Button-
    '- is Clicked on the Manual Order Area. It adds the currently-
    '- selected item and it's quantity to the selected Products -
    '- List Boxes for Storage.                                  -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Adds the Current Order Item and it's Qty.
        'If the List Box Contains the Item Specified
        If lstItems.Items.Contains(cboItem.SelectedItem) Then
            'Get the Index of that item and Add
            lstItems.SelectedItem = cboItem.SelectedItem
            lstQtys.Items(lstItems.SelectedIndex) = CInt(lstQtys.Items(lstItems.SelectedIndex).ToString) + nudQty.Value
            lstItems.SelectedItem = Nothing
        Else
            'Add New Item
            lstItems.Items.Add(cboItem.SelectedItem)
            lstQtys.Items.Add(nudQty.Value)
        End If

        'Restore Item Defaults
        cboItem.SelectedItem = "Table"
        nudQty.Value = 1
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnReset_Click           -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Reset DB Button   -
    '- is Clicked System Controls Area. It Refreshes the Database-
    '- and all of the dependant controls.                       -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        'Clear Data Grid Views
        dgvInventory.DataSource = Nothing
        dgvAsssignedWork.DataSource = Nothing

        'Reset the Database
        ResetDB()

        'Once DB is Refreshed Redisplay Data Grid Views, refresh combo boxes and text box
        RefreshOrderNumber()
        RefreshAvailCusts()
        RefreshAvailProducts()
        RefreshInventory()
        RefreshAssignedWork()
        GetAvailTimes()
        lstvwReport.Items.Clear()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnOrdSubmit_Click       -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Order Submit Button-
    '- is Clicked on the Manual Order Area. It calls a subroutine-
    '- which adds the Order and it's items to the database and  -
    '- performs time and inventory calculations.                -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- lstProduct - A List of Product Names Selected by User    -
    '- lstQtys - A List of Product Quantities selected by User  -
    '------------------------------------------------------------
    Private Sub btnOrdSubmit_Click(sender As Object, e As EventArgs) Handles btnOrdSubmit.Click
        'Inputs the Manual Entry Order into the System
        Dim lstProduct As New List(Of String)
        Dim lstQty As New List(Of Integer)

        'If Submit button was pressed without filling in List Boxes
        If lstItems.Items.Count = 0 Then
            'Take Directly from combo box selected item and number up down's current value
            lstProduct.Add(cboItem.SelectedItem)
            lstQty.Add(nudQty.Value)
        Else
            'Put All Products into a List
            For Each Item In lstItems.Items
                lstProduct.Add(Item)
            Next

            'Put All Quatities for those Products into a List
            For Each Item In lstQtys.Items
                lstQty.Add(Item)
            Next
        End If

        SubmitNewOrder(txtOrdNum.Text, cboCustID.SelectedItem, lstProduct, lstQty)

        'Clear Text Boxes and Restore Item Default Values
        cboCustID.SelectedItem = "102"
        RefreshOrderNumber()
        cboItem.SelectedItem = "Table"
        nudQty.Value = 1

        'Clear List Boxes
        ClearItms()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnClearItms_Click       -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Clear Order Itms Button-
    '- is Clicked on the Manual Order Area. It Removes all of the-
    '- Order's Selected Products.                               -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub btnClearItems_Click(sender As Object, e As EventArgs) Handles btnClearItems.Click
        'Clears All Items from the Product List Boxes
        ClearItms()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnLoadFromFile_Click    -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Load from File Button-
    '- is Clicked. Loads a text file of Orders in Batch to Database.-
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- dtFileContents - Contents of the New File in psudo DB Format-
    '- intCurrentCustomerID - The Current Customer ID being Processed-
    '- lstCurrentOrderProducts - The Current List of Products   -
    '-                           for Current Order              -
    '- lstCurrentProductQtys - The Current Quantities for Each  -
    '-                         Product of the Current Order     -
    '- lstOrderNumbers - A List of All Order Numbers            -
    '- lstPartsOfLine - A List that Contains a Split String of  -
    '-                  the Line Read by StreamReader           -
    '- lstTemp - A Temporary Holder for LINQ query results      -
    '- srReader - The StreamReader Object                       -
    '- strFilename - the Filename and Path of the File to open  -
    '- strLine - A String containing a Single Line read by      -
    '-           StreamReader                                   -
    '------------------------------------------------------------
    Private Sub btnLoadFromFile_Click(sender As Object, e As EventArgs) Handles btnLoadFromFile.Click
        'Loads Orders From File
        Dim dtFileContents As New DataTable
        Dim intCurrentCustomerID As Integer
        Dim lstCurrentOrderProducts As New List(Of String)
        Dim lstCurrentProductQtys As New List(Of Integer)
        Dim lstOrderNumbers As New List(Of Integer)
        Dim lstPartsOfLine As List(Of String)
        Dim lstTemp As New List(Of Integer)
        Dim srReader As System.IO.StreamReader
        Dim strFilename As String
        Dim strLine As String

        'Setup Open File Dialog
        ofdOrdersFromFile.CheckPathExists = True
        ofdOrdersFromFile.CheckFileExists = True
        ofdOrdersFromFile.FileName = "Orders.txt"
        ofdOrdersFromFile.InitialDirectory = My.Application.Info.DirectoryPath
        ofdOrdersFromFile.Filter = "Text Files (*.txt) | *.txt"
        ofdOrdersFromFile.Title = "Load Orders From File"

        'Set Up Datatable
        dtFileContents.Columns.Add("CustomerID", GetType(Integer))
        dtFileContents.Columns.Add("OrderNumber", GetType(Integer))
        dtFileContents.Columns.Add("ItemType", GetType(String))
        dtFileContents.Columns.Add("ItemQuantity", GetType(Integer))

        'Show the Box and if File Selected
        If ofdOrdersFromFile.ShowDialog() = DialogResult.OK Then
            'Assign that File to the Filename
            strFilename = ofdOrdersFromFile.FileName

            'Assign to Stream Reader
            srReader = My.Computer.FileSystem.OpenTextFileReader(strFilename)

            'Read The File
            Do Until srReader.EndOfStream
                strLine = srReader.ReadLine()
                'Add To a List
                lstPartsOfLine = strLine.Split(vbTab).ToList
                'Go to a Table to Be Queried
                dtFileContents.Rows.Add(lstPartsOfLine(0), lstPartsOfLine(1), lstPartsOfLine(2), lstPartsOfLine(3))
            Loop

            'Query Table for all unique Order Numbers
            lstOrderNumbers = (From Row In dtFileContents.AsEnumerable
                               Select Row.Field(Of Integer)("OrderNumber")).Distinct.ToList
            'For Each Order Number
            For Each Num In lstOrderNumbers
                'Get The Customer ID
                lstTemp = (From Row In dtFileContents.AsEnumerable
                           Where Row.Field(Of Integer)("OrderNumber") = Num
                           Select Row.Field(Of Integer)("CustomerID")).Distinct.ToList
                intCurrentCustomerID = lstTemp(0)
                'Get All Products for Current Order Number
                lstCurrentOrderProducts = (From Row In dtFileContents.AsEnumerable
                                           Where Row.Field(Of Integer)("OrderNumber") = Num
                                           Select Row.Field(Of String)("ItemType")).ToList
                'Get All Product Quantities for Current Order Number
                lstCurrentProductQtys = (From Row In dtFileContents.AsEnumerable
                                         Where Row.Field(Of Integer)("OrderNumber") = Num
                                         Select Row.Field(Of Integer)("ItemQuantity")).ToList
                'Submit New Order
                SubmitNewOrder(Num, intCurrentCustomerID, lstCurrentOrderProducts, lstCurrentProductQtys)
            Next
            'Reset Order Number
            RefreshOrderNumber()
        End If
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnReport_Click          -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Generate Report Button-
    '- is Clicked on the System Controls Area. Generates a List -
    '- View Report of all Orders in the System according to the Fields-
    '- Specified by the Client.                                 -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- daOrders - Data Adapter for Orders Table                 -
    '- daOrdToProd - Data Adapter for OrdersToProduct Table     -
    '- daProducts - Data Adapter for Product Table              -
    '- dtOrders - Data Table for Orders DB Query Results        -
    '- dtOrdToProd - Data Table for OrdersToPRoduct DB Query Res.-
    '- dtProducts - Data Table for Products DB Query Results    -
    '- intCount - Counter Variable for Outer Loop               -
    '- intCount2 - Counter Variable for Inner Loop              -
    '- lstAssemAreas - List of All Assembly Areas used          -
    '- lstCurrProductIDs - A List of the Current Product IDs of -
    '-                     a Given Oder Number                  -
    '- lstCurrProductNames - Same Description as previous,      -
    '-                       except With the String Names       -
    '- lstCurrProductQtys - Same Description as previous,       -
    '- lstEndTimes - List of Ending Times for the Order to be   -
    '-               Processed                                  -
    '- lstOrderNums - List of All Order Numbers to be Processed -
    '- lstStartTimes - List of All Starting Times for the Order -
    '-                  to Start Processing                     -
    '- lstTemp - Temporary List for Query Results               -
    '- strCurrOrderOutAll - Output for First Line Only of Current-
    '-                      Order (Array)                       -
    '- strCurrOrderOutProdLines - Output for Other Lines of Same-
    '-                            Order (Array)                 -
    '------------------------------------------------------------
    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        'Define DataAdapters
        Dim daOrders As New SqlDataAdapter("SELECT * FROM Orders", strDBCONN)
        Dim daOrdToProd As New SqlDataAdapter("SELECT Orders_TUID, Prod_TUID, Quantity from OrdersToProduct", strDBCONN)
        Dim daProducts As New SqlDataAdapter("SELECT TUID, Prod_Name FROM Product", strDBCONN)
        'Define DataTables
        Dim dtOrders As New DataTable
        Dim dtOrdToProd As New DataTable
        Dim dtProducts As New DataTable
        'Define Counter
        Dim intCount As Integer
        Dim intCount2 As Integer
        'Define Lists
        Dim lstAssemAreas As New List(Of Integer)
        Dim lstCurrProductIDs As New List(Of Integer)
        Dim lstCurrProductNames As New List(Of String)
        Dim lstCurrProductQtys As New List(Of Integer)
        Dim lstEndTimes As New List(Of DateTime)
        Dim lstOrderNums As New List(Of Integer)
        Dim lstStartTimes As New List(Of DateTime)
        Dim lstTemp As New List(Of String)
        Dim strCurrOrderOutAll(5) As String
        Dim strCurrOrderOutProdLines(5) As String

        'Fill DataTables
        daOrders.Fill(dtOrders)
        daOrdToProd.Fill(dtOrdToProd)
        daProducts.Fill(dtProducts)

        'Assign All Data From Orders
        lstOrderNums = (From Row In dtOrders.AsEnumerable
                        Select Row.Field(Of Integer)("TUID")).ToList
        lstAssemAreas = (From Row In dtOrders.AsEnumerable
                         Select Row.Field(Of Integer)("AssemblyArea")).ToList
        lstStartTimes = (From Row In dtOrders.AsEnumerable
                         Select Row.Field(Of DateTime)("StartDateTm")).ToList
        lstEndTimes = (From Row In dtOrders.AsEnumerable
                       Select Row.Field(Of DateTime)("EndDateTm")).ToList

        'Clear List View
        lstvwReport.Items.Clear()

        'Get Product Data and Output
        'Reset counter
        intCount = 0
        For Each Order In lstOrderNums
            'Get Product ID's and Quantities for Current Order
            lstCurrProductIDs = (From Row In dtOrdToProd.AsEnumerable
                                 Where Row.Field(Of Integer)("Orders_TUID") = Order
                                 Select Row.Field(Of Integer)("Prod_TUID")).ToList
            lstCurrProductQtys = (From Row In dtOrdToProd.AsEnumerable
                                  Where Row.Field(Of Integer)("Orders_TUID") = Order
                                  Select Row.Field(Of Integer)("Quantity")).ToList

            'Make Sure Current Product Names is Reset
            lstCurrProductNames.Clear()

            'Convert Product IDs to Names
            For Each ProductID In lstCurrProductIDs
                lstTemp = (From Row In dtProducts.AsEnumerable
                           Where Row.Field(Of Integer)("TUID") = ProductID
                           Select Row.Field(Of String)("Prod_Name")).ToList
                lstCurrProductNames.Add(lstTemp(0))
            Next

            'Reset Counter Variable
            intCount2 = 0
            'Output to List View
            For Each ProdName In lstCurrProductNames
                'Assign Array for All Output
                strCurrOrderOutAll(0) = Order
                strCurrOrderOutAll(1) = ProdName
                strCurrOrderOutAll(2) = lstCurrProductQtys(intCount2)
                strCurrOrderOutAll(3) = lstAssemAreas(intCount)
                strCurrOrderOutAll(4) = lstStartTimes(intCount)
                strCurrOrderOutAll(5) = lstEndTimes(intCount)
                'Assign Array for Subsequent Products
                strCurrOrderOutProdLines(0) = ""
                strCurrOrderOutProdLines(1) = ProdName
                strCurrOrderOutProdLines(2) = lstCurrProductQtys(intCount2)
                strCurrOrderOutProdLines(3) = ""
                strCurrOrderOutProdLines(4) = ""
                strCurrOrderOutProdLines(5) = ""
                If intCount2 = 0 Then
                    lstvwReport.Items.Add(New ListViewItem(strCurrOrderOutAll))
                Else
                    lstvwReport.Items.Add(New ListViewItem(strCurrOrderOutProdLines))
                End If
                intCount2 += 1
            Next
            intCount += 1
        Next
        lstvwReport.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnExit_Click            -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the Exit Button is    -
    '- Pressed. Performs Me.Close().                            -
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
        Me.Close()
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: frmMain_Closing          -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever an Exit Button is     -
    '- Pressed. Asks if you want to delete the database. If Yes,-
    '- Call Database Delete Subroutine, else call UpdateShcedule-
    '- to update the Assembly Area Time Tables.                 -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub frmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If MessageBox.Show("Do you want to delete the Database?", "Form Closing - Erase DB Data?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            DeleteDatabase()
        Else
            'Persist Schedule Info to DataBase
            UpdateSchedule()
        End If
    End Sub

    '---Application Subroutines---
    '------------------------------------------------------------
    '-                Subprogram Name: SubmitNewOrder          -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called from the Submit Button for Single-
    '- Input and from Load from File when doing Batch-Input. It -
    '- is a relay subroutine that adds each new order to the    -
    '- database by calling the relavent Update subroutines.     -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- intOrderNumber - The Order Number                        -
    '- intCustID - The Customer ID                              -
    '- lstProducts - A List of Products for the Order           -
    '- lstQty - A List of Qtys for Products for the Order       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub SubmitNewOrder(intOrderNumber As Integer, intCustID As Integer, lstProducts As List(Of String), lstQty As List(Of Integer))
        'Update All Order Facets
        UpdateOrders(intOrderNumber, intCustID)
        UpdateOrdersProducts(intOrderNumber, lstProducts, lstQty)
        UpdateOrderTimes(intOrderNumber, lstProducts, lstQty)
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: UpdateOrders             -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called from the SubmitNewOrder relay  -
    '- Subroutine. It Does preliminary work of submitting basic -
    '- information to the Orders Table of the Database.          -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- intOrderNumber - The Order Number                        -
    '- intCustID - The Customer ID                              -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- DBConn - SQL Connection                                  -
    '- DBCmd - SQL Command                                      -
    '------------------------------------------------------------
    Private Sub UpdateOrders(intOrdNumber As Integer, intCustID As Integer)
        'Adapted from CIS 311 Example Code
        Dim DBConn As SqlConnection
        Dim DBCmd As SqlCommand = New SqlCommand()

        'Now try to open up a connection to the database
        DBConn = New SqlConnection(strDBCONN)
        DBConn.Open()

        'Add Order using SQL DML
        DBCmd.CommandText = "INSERT INTO Orders (TUID, Cust_TUID) " &
                            "VALUES (" & intOrdNumber & ", " & intCustID & ")"

        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBConn.Close()

        'Debug
        MessageBox.Show("Orders Updated Successfully!", "Orders Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: UpdateOrdersProducts     -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called from the SubmitNewOrder relay  -
    '- Subroutine. It submits Product information about the new -
    '- order to the OrdersToProduct Table of the Database       -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- intOrderNumber - The Order Number                        -
    '- lstProducts - A List of Products for the Order           -
    '- lstQtys - A List of Qtys for Products for the Order       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- DBConn - SQL Connection                                  -
    '- DBCmd - SQL Command                                      -
    '- daProducts - Data Adapter for DB Products Table          -
    '- dtProducts - Data Table for DB Products Table            -
    '- intRowNum - The Number of Rows the Table has             -
    '- lstProdIDs - List of Converted Product IDs               -
    '------------------------------------------------------------
    Private Sub UpdateOrdersProducts(intOrderNumber As Integer, lstProducts As List(Of String), lstQtys As List(Of Integer))
        'Adapted from CIS 311 Example Code
        Dim DBConn As SqlConnection
        Dim DBCmd As SqlCommand = New SqlCommand()
        Dim lstProdIDs As New List(Of Integer)
        Dim lstTemp As New List(Of Integer)
        Dim daProducts As New SqlDataAdapter("Select TUID, Prod_Name From Product", strDBCONN)
        Dim dtProducts As New DataTable
        Dim intRowNum As Integer

        daProducts.Fill(dtProducts)
        'Now try to open up a connection to the database
        DBConn = New SqlConnection(strDBCONN)
        DBConn.Open()
        DBCmd.CommandText = "INSERT INTO OrdersToProduct (TUID, Orders_TUID, Prod_TUID, Quantity) VALUES "
        'For each Product into the Product Table
        For Each Product In lstProducts
            Dim queryRes = From Prod In dtProducts
                           Where Prod.Field(Of String)("Prod_Name") = Product
                           Select Prod.Field(Of Integer)("TUID")
            lstTemp = queryRes.ToList()
            lstProdIDs.Add(lstTemp(0))
        Next
        'Repurpose the Products table and adapter to make sure Orders to Product Table is empty or Not
        dtProducts.Clear()
        daProducts = New SqlDataAdapter("Select Count(TUID) From OrdersToProduct", strDBCONN)
        daProducts.Fill(dtProducts)
        Try
            intRowNum = CInt(dtProducts.Rows(0).ItemArray(2))
        Catch e As Exception
            intRowNum = 0
        End Try

        'For Each Product In the Order
        For intCounter = 0 To lstProdIDs.Count - 1
            If intRowNum = 0 Then
                'Add new Order Product Item and Quantity using SQL DML - Number using Counter Variable
                DBCmd.CommandText &= "(" & (intCounter + 1) & ", " & intOrderNumber & ", " & "'" & lstProdIDs(intCounter) & "'" & ", " & lstQtys(intCounter) & ")"
            Else
                'Add new Order Product Item and Quantity using SQL DML - Number using Number of Rows + Counter Variable
                DBCmd.CommandText &= "(" & (intRowNum + intCounter) + 1 & ", " & intOrderNumber & ", " & "'" & lstProdIDs(intCounter) & "'" & ", " & lstQtys(intCounter) & ")"
            End If

            'If it is not the final Product
            If Not intCounter = lstProducts.Count - 1 Then
                'Add a Comma Separator for the SQL DML
                DBCmd.CommandText &= ", "
            End If
        Next
        'Open Connection for Commmand Object and Push to DB
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()
        'Close Connection
        DBConn.Close()
        'Debug
        MessageBox.Show("Products for Given Orders Updated Successfully!", "Orders To Products Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: UpdateOrderTimes         -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called from the SubmitNewOrder relay  -
    '- Subroutine. It submits Time Information and Assembly Area-
    '- Assignments to the Database. It also Calls the Inventory -
    '- Calculation Subroutine to update the Inventory numbers.  -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- intOrderNumber - The Order Number                        -
    '- lstProducts - A List of Products for the Order           -
    '- lstQuantity - A List of Qtys for Products for the Order  -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- DBConn - SQL Connection                                  -
    '- DBCmd - SQL Command                                      -
    '- daProducts - Data Adapter for DB Products Table          -
    '- dtProducts - Data Table for DB Products Table            -
    '- intAssignedTo - The Area the Order is Assigned to        -
    '- intAssemblyTime - the Assembly Time for a Given Product  -
    '- lstAssemblyTimes - A List of Assembly Times for the      -
    '-                    Products of the Order                 -
    '- lstProdIDs - List of Converted Product IDs               -
    '- lstTemp - a Temporary List for Query Results             -
    '- queryRes - Query Result Temp Variable                    -
    '- queryRes2 - Query Result Temp Variable                   -
    '------------------------------------------------------------
    Private Sub UpdateOrderTimes(intOrdNumber As Integer, lstProducts As List(Of String), lstQuantity As List(Of Integer))
        'Adapted from CIS 311 Example Code
        Dim DBConn As SqlConnection
        Dim DBCmd As SqlCommand = New SqlCommand()
        Dim daProducts As New SqlDataAdapter("Select TUID, Prod_Name From Product", strDBCONN)
        Dim dtProducts As New DataTable
        Dim intAssignedTo As Integer
        Dim intAssemblyTime As Integer
        Dim lstAssemblyTimes As New List(Of Integer)
        Dim lstProdIDs As New List(Of Integer)
        Dim lstTemp As New List(Of Integer)


        daProducts.Fill(dtProducts)
        'For each Product into the Product Table
        'Get the Product IDs
        For Each Product In lstProducts
            Dim queryRes = From Prod In dtProducts
                           Where Prod.Field(Of String)("Prod_Name") = Product
                           Select Prod.Field(Of Integer)("TUID")
            lstTemp = queryRes.ToList()
            lstProdIDs.Add(lstTemp(0))
        Next

        'Repurpose DataAdapter and DataTable for TUID to get Assembly Time for each Product ID
        daProducts = New SqlDataAdapter("Select TUID, Assembly_Time from Product", strDBCONN)
        dtProducts.Clear()
        daProducts.Fill(dtProducts)
        For Each ID In lstProdIDs
            Dim queryRes2 = (From Row In dtProducts.AsEnumerable
                             Where Row.Field(Of Integer)("TUID") = ID
                             Select Row.Field(Of Integer)("Assembly_Time")).Distinct
            lstTemp.Clear()
            lstTemp = queryRes2.ToList
            intAssemblyTime = lstTemp(0)
            lstAssemblyTimes.Add(intAssemblyTime)
        Next

        'Add Correct Assembly Area Assignment and Increment Current Area
        Select Case intCurrArea
            Case 1
                intAssignedTo = 1
            Case 2
                intAssignedTo = 2
            Case 3
                intAssignedTo = 3
            Case 4
                intAssignedTo = 4
            Case 5
                intAssignedTo = 5
        End Select

        'For Each Product
        For intCount = 0 To lstProdIDs.Count - 1
            'Now try to open up a connection to the database
            DBConn = New SqlConnection(strDBCONN)
            DBConn.Open()
            If intCount = 0 Then
                'Update Fields with Assembly Area Assignment and Both Times
                DBCmd.CommandText = "UPDATE Orders " &
                            "SET AssemblyArea = " & intAssignedTo &
                            ", StartDateTm = '" & lstAreasNextAvail(intCurrArea - 1).ToString("yyyy-MM-dd HH:mm:ss") & "', EndDateTm = '" &
                            lstAreasNextAvail(intCurrArea - 1).AddMinutes(lstQuantity(intCount) * lstAssemblyTimes(intCount)).ToString("yyyy-MM-dd HH:mm:ss") & "' " &
                            "Where TUID = " & intOrdNumber
            Else
                'Update Fields with End Times ONLY
                DBCmd.CommandText = "UPDATE Orders " &
                            "SET EndDateTm = '" & lstAreasNextAvail(intCurrArea - 1).
                            AddMinutes(lstQuantity(intCount) * lstAssemblyTimes(intCount)).
                            ToString("yyyy-MM-dd HH:mm:ss") & "' " &
                            "Where TUID = " & intOrdNumber
            End If

            'Update AreasNextAvailable list?
            lstAreasNextAvail(intCurrArea - 1) = lstAreasNextAvail(intCurrArea - 1).AddMinutes(lstQuantity(intCount) * lstAssemblyTimes(intCount))

            'Open Connection for Commmand Object and Push to DB
            DBCmd.Connection = DBConn
            DBCmd.ExecuteNonQuery()
            'Close Connection
            DBConn.Close()
        Next

        'Refresh DataGridView
        RefreshAssignedWork()
        CalculateInventoryLosses(lstProdIDs, lstQuantity)
        RefreshInventory()

        'Increment Current Assignment Area
        If intCurrArea = 5 Then
            intCurrArea = 1
        Else
            intCurrArea += 1
        End If

        'Debug
        MessageBox.Show("Orders have Been Assigned to Assembly Facilities and Timetable Updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    '------------------------------------------------------------
    '-            Subprogram Name: CalculateInventoryLosses     -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called from the UopdateOrderTimes     -
    '- Subroutine. It Calculates the amount of Inventory Used and-
    '- Applies it to the Inventory Table of the Database.       -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- lstProdIDs - A List of Product IDs                       -
    '- lstQuantities - A List of Quantities for those Products  -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- DBConn - SQL Connection                                  -
    '- DBCmd - SQL Command                                      -
    '- daBOM - Data Adapter for DB BOM Table                    -
    '- dtBOM - Data Table for DB BOM Table                      -
    '- intCurrItemLostInv - Current Lost Inventory of the Item  -
    '- intCount - Counter Variable                              -
    '- lstCurrItemsRequired - A List of All the Parts Required  -
    '-                        for the Product.                  -
    '- lstInventoryUsed - List of a Running Total of Each       -
    '-                    Inventory Item Used in Current Order. -
    '- lstTemp - a Temporary List for Query Results             -
    '------------------------------------------------------------
    Private Sub CalculateInventoryLosses(lstProdIDs As List(Of Integer), lstQuantities As List(Of Integer))
        'Adapted from CIS 311 Example Code
        Dim DBConn As SqlConnection
        Dim DBCmd As SqlCommand = New SqlCommand()
        Dim daBOM As New SqlDataAdapter("Select * from BOM", strDBCONN)
        Dim dtBOM As New DataTable
        Dim intCurrItemLostInv As Integer
        Dim intCount As Integer = 0
        Dim lstCurrItemsRequired As New List(Of Integer)
        Dim lstInventoryUsed As New List(Of Integer) '6 Items in Order
        Dim lstTemp As New List(Of Integer)

        'Fill Local Bom Table
        daBOM.Fill(dtBOM)

        'Fill List with 6 0s Signifying the 6 Inventory Items
        For intCount = 0 To 5
            lstInventoryUsed.Add(0)
        Next

        'Null intCount
        intCount = 0
        For Each ID In lstProdIDs
            lstCurrItemsRequired = (From Row In dtBOM.AsEnumerable
                                    Where Row.Field(Of Integer)("Prod_TUID") = ID
                                    Select Row.Field(Of Integer)("Inv_TUID")).ToList

            For Each InvItem In lstCurrItemsRequired
                lstTemp = (From Row In dtBOM.AsEnumerable
                           Where Row.Field(Of Integer)("Prod_TUID") = ID And Row.Field(Of Integer)("Inv_TUID") = InvItem
                           Select Row.Field(Of Integer)("Qty_Required")).Distinct.ToList
                intCurrItemLostInv = lstTemp(0)

                'Add Required
                lstInventoryUsed(InvItem - 1) += (intCurrItemLostInv * lstQuantities(intCount))
            Next
            'Increment Counter
            intCount += 1
        Next

        For intCount = 0 To lstInventoryUsed.Count - 1
            'Now try to open up a connection to the database
            DBConn = New SqlConnection(strDBCONN)
            DBConn.Open()

            'Add Order using SQL DML
            DBCmd.CommandText = "Update Inventory " &
                                "SET Qty_OnHand = Qty_OnHand - " & lstInventoryUsed(intCount) &
                                " Where TUID = " & intCount + 1

            DBCmd.Connection = DBConn
            DBCmd.ExecuteNonQuery()

            DBConn.Close()
        Next


        'Debug
        MessageBox.Show("Inventory Updated on Database", "Inventory Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    '------------------------------------------------------------
    '-            Subprogram Name: UpdateSchedule               -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called to Update the Assembly Area Time-
    '- Tables to the Database.                                  -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- DBConn - SQL Connection                                  -
    '- DBCmd - SQL Command                                      -
    '------------------------------------------------------------
    Private Sub UpdateSchedule()
        'Adapted from CIS 311 Example Code
        Dim DBConn As SqlConnection
        Dim DBCmd As SqlCommand = New SqlCommand()

        For intCount = 0 To 4
            'Now try to open up a connection to the database
            DBConn = New SqlConnection(strDBCONN)
            DBConn.Open()

            'Add Order using SQL DML
            DBCmd.CommandText = "Update AssemblyArea " &
                                "SET NextFree = '" & lstAreasNextAvail(intCount).ToString("yyyy-MM-dd HH:mm:ss") & "' " &
                                "Where TUID = " & intCount + 1

            DBCmd.Connection = DBConn
            DBCmd.ExecuteNonQuery()

            DBConn.Close()
        Next


        'Debug
        MessageBox.Show("Assembly Area Timetable Updated Successfully!", "Assembly Timetable Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    '------------------------------------------------------------
    '-            Subprogram Name: ClearItms              -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called to Clear all Items from the    -
    '- ListBoxes.                                               -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub ClearItms()
        'Clears All Items
        lstItems.Items.Clear()
        lstQtys.Items.Clear()
    End Sub

    '------------------------------------------------------------
    '-            Subprogram Name: RefreshAvailProducts         -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called to Refresh the Available Products-
    '- in Manual Order Entry.                                   -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- daProducts - DataAdapter for Products                    -
    '- dtProducts - DataTable for Products                      -
    '- lstProducts - A List of Available Products               -
    '------------------------------------------------------------
    Private Sub RefreshAvailProducts()
        'Define Data Adapter
        Dim daProducts = New SqlDataAdapter("Select Prod_Name FROM Product", strDBCONN)

        'Define Temporary DataTable
        Dim dtProducts As New DataTable

        'Define List for Products
        Dim lstProducts As New List(Of String)

        'Get Data
        daProducts.Fill(dtProducts)

        'Add New Records
        For Each Row In dtProducts.Rows
            lstProducts.Add(Row.ItemArray(0).ToString)
        Next

        'Set Data Source
        cboItem.DataSource = lstProducts
    End Sub

    '------------------------------------------------------------
    '-            Subprogram Name: RefreshAvailProducts         -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called to Refresh Order Number Text Box-
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- daOrderNum- DataAdapter for Orders Table                 -
    '- dtProducts - DataTable for Orders Query Result           -
    '- intNumOrders - Current Max Number of Orders              -
    '------------------------------------------------------------
    Private Sub RefreshOrderNumber()
        Dim daOrderNum As New SqlDataAdapter("Select Count(TUID) FROM Orders", strDBCONN)
        Dim dtOrderNums As New DataTable
        Dim intNumOrders As Integer
        'Check to See if Rows Exist in the Orders Table
        daOrderNum.Fill(dtOrderNums)
        Try
            intNumOrders = CInt(dtOrderNums.Rows(0)(0))
        Catch e As Exception
            intNumOrders = 0
        End Try

        'If no rows exist in the orders table
        If intNumOrders = 0 Then
            txtOrdNum.Text = 1
        Else 'If Rows Exist
            'Get the Max TUID Value
            daOrderNum = New SqlDataAdapter("Select Max(TUID) from Orders", strDBCONN)
            dtOrderNums.Clear()
            daOrderNum.Fill(dtOrderNums)
            'Assign it to the Texbox and Add 1 to it so that it is the next unique number
            intNumOrders = CInt(dtOrderNums.Rows(0)(0)) + 1
            txtOrdNum.Text = intNumOrders
        End If
    End Sub

    '------------------------------------------------------------
    '-            Subprogram Name: RefreshAvailCusts            -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called to Refresh the Customer IDs Selection-
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- daCustomers- DataAdapter for Customers Table             -
    '- dtCustomers - DataTable for Customers Query Result       -
    '- lstCustomers - A List of Available Customers             -
    '------------------------------------------------------------
    Private Sub RefreshAvailCusts()
        'Define Data Adapter
        Dim daCustomers As New SqlDataAdapter("Select TUID FROM Customer", strDBCONN)

        'Define Temporary Datatable
        Dim dtCustomers As New DataTable

        'Define Temporary Table
        Dim lstCustomers As New List(Of Integer)

        'Get Data
        daCustomers.Fill(dtCustomers)

        'Add New Records
        For Each Row In dtCustomers.Rows
            lstCustomers.Add(Row.ItemArray(0).ToString)
        Next
        lstCustomers.Sort()

        'Set Data Source
        cboCustID.DataSource = lstCustomers
    End Sub

    '------------------------------------------------------------
    '-            Subprogram Name: RefreshInventory             -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called to Refresh Inventory Status    -
    '- DataGridView.                                            -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- daInventory- DataAdapter for Inventory Table             -
    '- dtInventory - DataTable for Inventory Query Result       -
    '------------------------------------------------------------
    Private Sub RefreshInventory()
        'Define Data Adapter
        Dim daInventory = New SqlDataAdapter("Select Inv_Name, Qty_OnHand FROM Inventory", strDBCONN)

        'Create New Temporary DataTable
        Dim dtInventory As New DataTable

        'Fill with Inventory Data
        daInventory.Fill(dtInventory)

        'Change Columns to Make Better Sense
        dtInventory.Columns(0).ColumnName = "Part"
        dtInventory.Columns(1).ColumnName = "Quantity"

        'Set DataGridView DataSource Property
        dgvInventory.DataSource = dtInventory
    End Sub

    '------------------------------------------------------------
    '-            Subprogram Name: RefreshAssignedWork          -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called to Refresh the Assigned Orders -
    '- DataGridView.                                            -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- daAssignedWork- DataAdapter for Orders Table             -
    '- dtInventory - DataTable for Orders Query Result          -
    '------------------------------------------------------------
    Private Sub RefreshAssignedWork()
        'Define Data Adapter
        Dim daAssignedWork As New SqlDataAdapter("Select TUID,AssemblyArea,StartDateTm,EndDateTm FROM Orders Order By AssemblyArea", strDBCONN)

        'Create New Temporary DataTable
        Dim dtAsgnedWrk As New DataTable

        'Fill with Work
        daAssignedWork.Fill(dtAsgnedWrk)

        'Change Columns to make better Sense
        dtAsgnedWrk.Columns(0).ColumnName = "Order Number"
        dtAsgnedWrk.Columns(1).ColumnName = "Assigned To Area"
        dtAsgnedWrk.Columns(2).ColumnName = "Start Time"
        dtAsgnedWrk.Columns(3).ColumnName = "End Time"

        'Set DataGridView DataSource Property
        dgvAsssignedWork.DataSource = dtAsgnedWrk

    End Sub

    '------------------------------------------------------------
    '-            Subprogram Name: GetAvailTimes                -
    '------------------------------------------------------------
    '-                Written By: Austin Sliter                 -
    '-                Written On: 10/11/18                      -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called to Refresh the Next Available  -
    '- times for each Assembly Area.                            -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- daTimes- DataAdapter for Assembly Area Table             -
    '- dtTimes - DataTable for Assembly Area Query Result       -
    '------------------------------------------------------------
    Private Sub GetAvailTimes()
        'Define Data Adapter
        Dim daTimes As New SqlDataAdapter("Select NextFree from AssemblyArea", strDBCONN)

        'Create New Temporary DataTable
        Dim dtTimes As New DataTable
        daTimes.Fill(dtTimes)

        'Clear List We Don't Know what is in there
        lstAreasNextAvail.Clear()

        'Add Current Times
        For Each Row In dtTimes.Rows
            lstAreasNextAvail.Add(Row.ItemArray(0).ToString)
        Next
    End Sub
End Class