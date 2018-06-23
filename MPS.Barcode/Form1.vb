Imports CrystalDecisions.CrystalReports.Engine
Imports Infragistics.Win.UltraWinGrid
Imports VsoftBMS

Public Class Form1
    Dim clsu As New VsoftBMS.Ulti.ClsUti

#Region "ShowDialog"
    Dim clsuf As New VsoftBMS.Ulti.ClsFormatUltraGrid

    Private showDAL As Boolean = False
    Private keySelect As String = ""
    Private tbSource As DataTable
    Private tbpro As DataTable
    Private tbGroup As DataTable
    Dim FilterPath As String = ""
    Private Col As String = "" 'cot duoc de in
    'Public Overloads Function ShowDialog(ByVal fEdit As Boolean, ByVal tb As DataTable) As String
    '    showDAL = fEdit
    '    tbSource = tb
    '    Me.ShowDialog()
    '    Return keySelect
    'End Function

    'Public Overloads Function ShowDialog(ByVal fEdit As Boolean, ByVal tbchoose As DataTable, ByVal tb As DataTable) As String
    '    showDAL = fEdit
    '    tbSource = tbchoose 'hang duoc chon
    '    tbpro = tb 'hang hoa lay tu danh muc hang
    '    Me.ShowDialog()
    '    Return keySelect
    'End Function
    Public Sub ShowForm(ByVal tbchoose As DataTable, ByVal tb As DataTable, ByVal S As String, ByVal tbGroup As DataTable)
        Col = S
        tbSource = tbchoose 'hang duoc chon
        tbpro = tb 'hang hoa lay tu danh muc hang
        Me.tbGroup = tbGroup
        Me.ShowDialog()
        'Return keySelect
    End Sub

#End Region

    Private Function SaveSetting() As Boolean
        My.Settings.FilePath = txtPath.Text
        If txtQty.Text = "" Then txtQty.Text = 0
        If txtQty_Row.Text = "" Then txtQty_Row.Text = 0
        My.Settings.NumBarcode = CDbl(txtQty.Text)
        My.Settings.NumBarcodeRow = CDbl(txtQty_Row.Text)
        My.Settings.FilterPath = FilterPath
        My.Settings.sPathData = txtData.Text
        My.Settings.sPathProcess = txtProcess.Text
        My.Settings.ConvertFont = ChConvert.Checked
        My.Settings.Save()
    End Function

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SaveSetting()
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.Control Then '05/05/2009dat
            If e.KeyCode = Keys.C Then
                btnSelect.PerformClick()
            End If
        End If
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub LoadGroup()

    End Sub

    Dim fPageLoad As Boolean = False
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TabBarcode.Tabs("001").Visible = False
        cboGroup.DisplayMember = "s_Name"
        cboGroup.ValueMember = "s_ID"
        cboGroup.DataSource = tbGroup
        If cboGroup.DataSource IsNot Nothing AndAlso tbGroup.Rows.Count > 0 Then
            cboGroup.Rows(0).Activate()
        End If

        GridProduct.DataSource = tbpro
        GridBarcode.DataSource = tbSource
        txtQty.Text = My.Settings.NumBarcode
        txtQty_Row.Text = My.Settings.NumBarcodeRow

        txtData.Text = My.Settings.sPathData
        txtProcess.Text = My.Settings.sPathProcess
        ChConvert.Checked = My.Settings.ConvertFont
        FormatLang()
        txtPath.Text = My.Settings.FilePath
        fPageLoad = True
    End Sub
    Private Sub Filter()
        If cboGroup.DataSource IsNot Nothing Then
            If cboGroup.Value IsNot Nothing AndAlso cboGroup.Value <> "-1" Then
                Dim groupId As String = cboGroup.Value
                tbpro.DefaultView.RowFilter = "s_ProductGroupID='" & groupId.Replace("'", "''") & "'"
            Else
                tbpro.DefaultView.RowFilter = Nothing
            End If
        Else
            tbpro.DefaultView.RowFilter = Nothing
        End If
    End Sub
    Private Sub FormatLang()
        Me.GroupSelectFile.Text = TextMultiLang("Chọn file Excel", 1016)
        Me.Label1.Text = TextMultiLang("Tập tin", 1537)
        Me.btnSelect.Text = TextMultiLang("Chuyển tất cả sang in mã vạch (Ctrl+C)", 1538)
        Me.TabBarcode.Tabs("001").Text = TextMultiLang("Chọn dữ liệu", 1539)
        Me.TabBarcode.Tabs("002").Text = TextMultiLang("In mã vạch", 1540)

        Me.UltraGroupBox4.Text = TextMultiLang("Dữ liệu đọc từ file Excel", 1542)
        Me.UltraGroupBox5.Text = TextMultiLang("Cột dữ liệu tương ứng", 1541)

        Me.GroupProduct.Text = TextMultiLang("Danh sách hàng hóa", 316)
        Me.GroupBarcode.Text = TextMultiLang("Danh sách in mã vạch", 1543)
        Me.Label2.Text = TextMultiLang("Số lượng in/mã vạch", 1547)
        Me.Label3.Text = TextMultiLang("Số mã vạch/dòng", 1545)
        Me.Label4.Text = TextMultiLang("Chọn mẫu in", 1546)
        Me.btnPrint.Text = TextMultiLang("Xem mẫu in", 1548)
        Me.Link_Open_report.Text = TextMultiLang("Mở file Report", 1549)
        Me.btnApply.Text = TextMultiLang("Áp dụng", 1550)
    End Sub
#Region "SUB - FUNCTION"
    'THÔNG BÁO
    Private Sub ShowMsg(ByVal sMsg As String)
        MessageBox.Show(sMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub
    Public Sub ShowMsgInfo(ByVal sMsg As String)
        MessageBox.Show(sMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Public Function ShowMsgYesNo(ByVal sMsg As String) As Windows.Forms.DialogResult
        Return MessageBox.Show(sMsg, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    End Function
    Public Function ShowMsgOKExclamation(ByVal sMsg As String) As Windows.Forms.DialogResult
        Return MessageBox.Show(sMsg, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)
    End Function

    'lấy danh sách cột dữ liệu
    Private Function getTableCol() As DataTable
        'lay cau truc
        Dim tb As DataTable = New DataTable
        tb = New DataTable
        tb.Columns.Add("ProductID", GetType(String))
        tb.Columns.Add("ProductName", GetType(String))
        tb.Columns.Add("Price", GetType(Double))
        tb.Columns.Add("CreateDate", GetType(Date))
        tb.Columns.Add("V1", GetType(String))
        tb.Columns.Add("V2", GetType(String))
        tb.Columns.Add("V3", GetType(String))

        Dim tbCol As New DataTable
        tbCol.Columns.Add("Col")
        tbCol.Columns.Add("Name")
        tbCol.Columns.Add("ColAlias")
        tbCol.Columns.Add("isSelect", GetType(Boolean))

        For i As Integer = 0 To tb.Columns.Count - 1
            Dim drnew As DataRow = tbCol.NewRow
            drnew("Col") = tb.Columns(i).ColumnName
            Select Case tb.Columns(i).ColumnName
                Case "ProductID"
                    drnew("Name") = TextMultiLang("Mã hàng", 921)
                Case "ProductName"
                    drnew("Name") = TextMultiLang("Tên hàng", 922)
                Case "Price"
                    drnew("Name") = TextMultiLang("Đơn giá", 1551)
                Case "CreateDate"
                    drnew("Name") = TextMultiLang("Ngày tạo", 1552)
                Case "V1"
                    drnew("Name") = TextMultiLang("Ghi chú 1", 1553)
                Case "V2"
                    drnew("Name") = TextMultiLang("Ghi chú 2", 1554)
                Case "V3"
                    drnew("Name") = TextMultiLang("Ghi chú 3", 1555)
            End Select

            drnew("ColAlias") = ""
            drnew("isSelect") = False
            tbCol.Rows.Add(drnew)
        Next
        Return tbCol

    End Function
    'tạo cấu trúc bảng barcode
    Private Sub createTableBarcode()
        'lay cau truc
        Dim tb As DataTable = New DataTable
        tb = New DataTable
        tb.Columns.Add("ProductID", GetType(String))
        tb.Columns.Add("ProductName", GetType(String))
        tb.Columns.Add("Price", GetType(Double))
        tb.Columns.Add("CreateDate", GetType(Date))
        tb.Columns.Add("V1", GetType(String))
        tb.Columns.Add("V2", GetType(String))
        tb.Columns.Add("V3", GetType(String))
        tb.Columns.Add("Qty", GetType(Double))

        GridBarcode.DataSource = tb
    End Sub
    'map cột dữ liệu
    Private Sub ShowCol()
        'map cot
        Dim tblCol As DataTable = getTableCol()
        Dim tblData As DataTable = Grid.DataSource
        If Not tblData Is Nothing Then
            Dim tbColAlias As New DataTable
            tbColAlias.Columns.Add("Col")
            For i As Integer = 0 To tblData.Columns.Count - 1
                Dim drN As DataRow = tbColAlias.NewRow
                drN("Col") = tblData.Columns(i).ColumnName
                tbColAlias.Rows.Add(drN)
            Next
            GridColAlias.ValueMember = "Col"
            GridColAlias.DisplayMember = "Col"
            GridColAlias.DataSource = tbColAlias


            For Each dr As DataRow In tblCol.Rows
                Dim DF() As DataRow = tbColAlias.Select("Col='" & dr("Name").ToString.Replace("'", "''") & "'")
                If DF.Length > 0 Then
                    dr("ColAlias") = DF(0)("Col")
                    dr("isSelect") = True
                    'Thao21.06.2010-Frame "Else"
                    'Else
                    '    dr("ColAlias") = ""
                    '    dr("isSelect") = True
                End If
            Next

            GridCol.DataSource = tblCol
        End If
    End Sub



    'Chuyển danh sách đã lọc sang danh sách in mã vạch(trường hợp file Excel)
    Private Sub ChangeListToBarcodeList(ByVal isAll As Boolean)
        Try
            Dim tbCol As DataTable = GridCol.DataSource
            If tbCol Is Nothing Then Exit Sub
            Dim tb As DataTable = Grid.DataSource
            If tb Is Nothing Then Exit Sub

            'KIỂM TRA DỮ LIỆU ĐƯỢC CHỌN===========================
            Dim DF() As DataRow = tbCol.Select("isSelect=True")
            If DF.Length = 0 Then
                ShowMsg(TextMultiLang("Không có cột dữ liệu nào được chọn !", 1310))
                Exit Sub
            Else
                For Each drf As DataRow In DF
                    If drf("ColAlias") = "" Then
                        ShowMsg(TextMultiLang("Cột dữ liệu tương ứng chưa được chọn!", 1557))
                        Exit Sub
                    End If
                Next
            End If
            If txtQty.Text = "" Then
                ShowMsg(TextMultiLang("Chưa nhập số lượng in mỗi mã vạch !", 1215))
                txtQty.Focus()
                Exit Sub
            End If
            If CDbl(txtQty.Text) = 0 Then
                ShowMsg(TextMultiLang("Chưa nhập số lượng in mỗi mã vạch !", 1215))
                txtQty.Focus()
                Exit Sub
            End If

            'KIỂM TRA CỘT DỮ LIỆU ĐƯỢC CHỌN==========================
            'cột mã hàng
            Dim ProductID As String = ""
            DF = tbCol.Select("Col='ProductID' and isSelect=True")
            If DF.Length > 0 Then
                ProductID = DF(0)("ColAlias")
            Else
                DF = tbCol.Select("Col='ProductID'")
                If DF.Length > 0 Then
                    ShowMsg("Select : " & DF(0)("Name"))
                Else
                    ShowMsg("Error")
                End If
                Exit Sub
            End If
            'cột tên hàng
            Dim ProductName As String = ""
            DF = tbCol.Select("Col='ProductName' and isSelect=True")
            If DF.Length > 0 Then
                ProductName = DF(0)("ColAlias")
            End If
            'cột giá
            Dim Price As String = ""
            DF = tbCol.Select("Col='Price' and isSelect=True")
            If DF.Length > 0 Then
                Price = DF(0)("ColAlias")
            End If
            'cột ngày tạo mặt hàng
            Dim CreateDate As String = ""
            DF = tbCol.Select("Col='CreateDate' and isSelect=True")
            If DF.Length > 0 Then
                CreateDate = DF(0)("ColAlias")
            End If
            'cột V1
            Dim V1 As String = ""
            DF = tbCol.Select("Col='V1' and isSelect=True")
            If DF.Length > 0 Then
                V1 = DF(0)("ColAlias")
            End If
            'cột V2
            Dim V2 As String = ""
            DF = tbCol.Select("Col='V2' and isSelect=True")
            If DF.Length > 0 Then
                V2 = DF(0)("ColAlias")
            End If
            'cột V3
            Dim V3 As String = ""
            DF = tbCol.Select("Col='V3' and isSelect=True")
            If DF.Length > 0 Then
                V3 = DF(0)("ColAlias")
            End If

            If Not isAll Then 'CHỌN MỘT DÒNG
                Dim r As Infragistics.Win.UltraWinGrid.UltraGridRow = Grid.ActiveRow
                If r Is Nothing Then Exit Sub
                If r.Index = -1 Then Exit Sub

                Dim M As New MBarcode
                'KIỂM TRA KIỂU DỮ LIỆU
                'kiểu mã hàng 
                If ProductID <> "" Then
                    If IsDBNull(r.Cells(ProductID).Value) Then
                        ShowMsg(TextMultiLang("Mã hàng hóa không hợp lệ !", 1386))
                        Exit Sub
                    End If
                    M.ProductID = r.Cells(ProductID).Value
                End If
                'kiểu tên hàng
                If ProductName <> "" Then
                    If IsDBNull(r.Cells(ProductName).Value) Then
                        ShowMsg(TextMultiLang("Tên hàng hóa không hợp lệ !", 1385))
                        Exit Sub
                    End If
                    M.ProductName = r.Cells(ProductName).Value
                End If
                'kiểu giá
                If Price <> "" Then
                    If IsDBNull(r.Cells(Price).Value) Then
                        ShowMsg(TextMultiLang("Đơn giá hàng hóa không hợp lệ !", 1003))
                        Exit Sub
                    End If
                    If Not IsNumeric(r.Cells(Price).Value) Then
                        ShowMsg(TextMultiLang("Đơn giá hàng hóa không hợp lệ !", 1003))
                        Exit Sub
                    End If
                    M.Price = r.Cells(Price).Value
                End If
                'kiểu ngày tạo
                If CreateDate <> "" Then
                    If IsDBNull(r.Cells(CreateDate).Value) Then
                        ShowMsg(TextMultiLang("Ngày tạo hàng hóa không hợp lệ !", 1558))
                        Exit Sub
                    End If
                    If Not IsDate(r.Cells(CreateDate).Value) Then
                        ShowMsg(TextMultiLang("Ngày tạo hàng hóa không hợp lệ !", 1558))
                        Exit Sub
                    End If
                    M.CreateDate = r.Cells(CreateDate).Value
                End If
                'kiểu V1
                If V1 <> "" Then
                    If IsDBNull(r.Cells(V1).Value) Then
                        ShowMsg(TextMultiLang("V1 không hợp lệ !", 1559))
                        Exit Sub
                    End If
                    M.V1 = r.Cells(V1).Value
                End If
                'kiểu V2
                If V2 <> "" Then
                    If IsDBNull(r.Cells(V2).Value) Then
                        ShowMsg(TextMultiLang("V2 không hợp lệ !", 1560))
                        Exit Sub
                    End If
                    M.V2 = r.Cells(V2).Value
                End If
                'kiểu V3
                If V3 <> "" Then
                    If IsDBNull(r.Cells(V3).Value) Then
                        ShowMsg(TextMultiLang("V3 không hợp lệ !", 1561))
                        Exit Sub
                    End If
                    M.V3 = r.Cells(V3).Value
                End If

                'KIỂM TRA TỒN TẠI CẤU TRÚC BẢNG BARCODE
                If GridBarcode.DataSource Is Nothing Then
                    createTableBarcode()
                End If
                'CHÈN DỮ LIỆU
                Dim tbb As DataTable = GridBarcode.DataSource
                'KIỂM TRA CỘT DỮ LIỆU ĐÃ TỒN TẠI+INSERT DỮ LIỆU SANG DANH SÁCH BARCODE
                Dim dff() As DataRow = tbb.Select("ProductID='" & M.ProductID.Replace("'", "''") & "'")
                If dff.Length > 0 Then 'đã tồn tại mã hàng
                    If ProductName <> "" Then
                        dff(0)("ProductName") = M.ProductName 'gán dữ liệu
                    End If
                    If Price <> "" Then
                        dff(0)("ProductName") = M.ProductName 'gán dữ liệu
                    End If
                    If CreateDate <> "" Then
                        dff(0)("CreateDate") = M.CreateDate 'gán dữ liệu
                    End If
                    If V1 <> "" Then
                        dff(0)("V1") = M.V1 'gán dữ liệu
                    End If
                    If V2 <> "" Then
                        dff(0)("V2") = M.V2 'gán dữ liệu
                    End If
                    If V3 <> "" Then
                        dff(0)("V3") = M.V3 'gán dữ liệu
                    End If

                    dff(0)("Qty") = CDbl(txtQty.Text) 'gán dữ liệu
                Else
                    Dim drnew As DataRow = tbb.NewRow
                    drnew("ProductID") = M.ProductID
                    If ProductName <> "" Then
                        drnew("ProductName") = M.ProductName
                    End If
                    If CreateDate <> "" Then
                        drnew("CreateDate") = M.CreateDate 'gán dữ liệu
                    End If
                    If V1 <> "" Then
                        drnew("V1") = M.V1 'gán dữ liệu
                    End If
                    If V2 <> "" Then
                        drnew("V2") = M.V2 'gán dữ liệu
                    End If
                    If V3 <> "" Then
                        drnew("V3") = M.V3 'gán dữ liệu
                    End If
                    drnew("Qty") = CDbl(txtQty.Text)
                    tbb.Rows.Add(drnew)
                End If
            Else 'chọn tất cả
                Dim k As Integer = 0
                For Each dr As DataRow In tb.Rows
                    If dr.RowState = DataRowState.Deleted Then GoTo fContinue

                    Dim M As New MBarcode
                    'KIỂM TRA KIỂU DỮ LIỆU
                    'kiểu mã hàng 
                    If ProductID <> "" Then
                        If IsDBNull(dr(ProductID)) Then
                            If Grid.Rows.Count > k Then
                                If ShowMsgYesNo(TextMultiLang("Mã hàng hóa không hợp lệ", 1386) & Chr(13) & TextMultiLang("Có tiếp tục chọn không ?", 15)) = Windows.Forms.DialogResult.Yes Then
                                    GoTo fContinue
                                End If
                                Exit Sub
                            Else
                                If ShowMsgOKExclamation(TextMultiLang("Mã hàng hóa không hợp lệ", 1386) & Chr(13) & TextMultiLang("Có tiếp tục chọn không ?", 15)) = Windows.Forms.DialogResult.OK Then
                                    GoTo fContinue
                                End If
                                Exit Sub
                            End If

                        End If
                        M.ProductID = dr(ProductID)
                    End If
                    'kiểu tên hàng
                    If ProductName <> "" Then
                        If IsDBNull(dr(ProductName)) Then
                            If Grid.Rows.Count > k Then
                                If ShowMsgYesNo(TextMultiLang("Tên hàng hóa không hợp lệ", 1385) & Chr(13) & TextMultiLang("Có tiếp tục chọn không ?", 15)) = Windows.Forms.DialogResult.Yes Then
                                    GoTo fContinue
                                End If
                                Exit Sub
                            Else
                                If ShowMsgOKExclamation(TextMultiLang("Tên hàng hóa không hợp lệ ", 1385)) = Windows.Forms.DialogResult.OK Then
                                    GoTo fContinue
                                End If
                                Exit Sub
                            End If

                        End If
                        M.ProductName = dr(ProductName)
                    End If
                    'kiểu giá
                    If Price <> "" Then
                        If IsDBNull(dr(Price)) Then
                            If Grid.Rows.Count > k Then
                                If ShowMsgYesNo(TextMultiLang("Đơn giá hàng hóa không hợp lệ", 1003) & Chr(13) & TextMultiLang("Có tiếp tục chọn không ?", 15)) = Windows.Forms.DialogResult.Yes Then
                                    GoTo fContinue
                                End If
                                Exit Sub
                            Else
                                If ShowMsgOKExclamation(TextMultiLang("Đơn giá hàng hóa không hợp lệ ", 1003)) = Windows.Forms.DialogResult.OK Then
                                    GoTo fContinue
                                End If
                                Exit Sub
                            End If
                        End If
                        If Not IsNumeric(dr(Price)) Then
                            If ShowMsgYesNo(TextMultiLang("Đơn giá hàng hóa không hợp lệ", 1003) & Chr(13) & TextMultiLang("Có tiếp tục chọn không ?", 15)) = Windows.Forms.DialogResult.Yes Then
                                GoTo fContinue
                            End If
                            Exit Sub
                        End If
                        M.Price = CDbl(dr(Price))
                    End If
                    'kiểu ngày tạo
                    If CreateDate <> "" Then
                        If IsDBNull(dr(CreateDate)) Then
                            If Grid.Rows.Count > k Then
                                If ShowMsgYesNo(TextMultiLang("Ngày tạo hàng hóa không hợp lệ", 1558) & Chr(13) & TextMultiLang("Có tiếp tục chọn không ?", 15)) = Windows.Forms.DialogResult.Yes Then
                                    GoTo fContinue
                                End If
                                Exit Sub
                            Else
                                If ShowMsgOKExclamation(TextMultiLang("Ngày tạo hàng hóa không hợp lệ ", 1558)) = Windows.Forms.DialogResult.OK Then
                                    GoTo fContinue
                                End If
                                Exit Sub
                            End If
                        End If
                        If Not IsDate(dr(CreateDate)) Then
                            If ShowMsgYesNo(TextMultiLang("Ngày tạo hàng hóa không hợp lệ", 1558) & Chr(13) & TextMultiLang("Có tiếp tục chọn không ?", 15)) = Windows.Forms.DialogResult.Yes Then
                                GoTo fContinue
                            End If
                            Exit Sub
                        End If
                        M.CreateDate = dr(Price)
                    End If
                    'kiểu V1
                    If V1 <> "" Then
                        If IsDBNull(dr(V1)) Then
                            If Grid.Rows.Count > k Then
                                If ShowMsgYesNo(TextMultiLang("V1 không hợp lệ", 1559) & Chr(13) & TextMultiLang("Có tiếp tục chọn không ?", 15)) = Windows.Forms.DialogResult.Yes Then
                                    GoTo fContinue
                                End If
                                Exit Sub
                            Else
                                If ShowMsgOKExclamation(TextMultiLang("V1 không hợp lệ ", 1559)) = Windows.Forms.DialogResult.OK Then
                                    GoTo fContinue
                                End If
                                Exit Sub
                            End If

                        End If
                        M.V1 = dr(V1)
                    End If
                    'kiểu V2
                    If V2 <> "" Then
                        If IsDBNull(dr(V2)) Then
                            If Grid.Rows.Count > k Then
                                If ShowMsgYesNo(TextMultiLang("V2 không hợp lệ", 1560) & Chr(13) & TextMultiLang("Có tiếp tục chọn không ?", 15)) = Windows.Forms.DialogResult.Yes Then
                                    GoTo fContinue
                                End If
                                Exit Sub
                            Else
                                If ShowMsgOKExclamation(TextMultiLang("V2 không hợp lệ ", 1560)) = Windows.Forms.DialogResult.OK Then
                                    GoTo fContinue
                                End If
                                Exit Sub
                            End If

                        End If
                        M.V2 = dr(V2)
                    End If
                    'kiểu V3
                    If V3 <> "" Then
                        If IsDBNull(dr(V3)) Then
                            If Grid.Rows.Count > k Then
                                If ShowMsgYesNo(TextMultiLang("V3 không hợp lệ", 1561) & Chr(13) & TextMultiLang("Có tiếp tục chọn không ?", 15)) = Windows.Forms.DialogResult.Yes Then
                                    GoTo fContinue
                                End If
                                Exit Sub
                            Else
                                If ShowMsgOKExclamation(TextMultiLang("V3 không hợp lệ ", 1561)) = Windows.Forms.DialogResult.OK Then
                                    GoTo fContinue
                                End If
                                Exit Sub
                            End If

                        End If
                        M.V3 = dr(V3)
                    End If

                    'KIỂM TRA TỒN TẠI CẤU TRÚC BẢNG BARCODE
                    If GridBarcode.DataSource Is Nothing Then
                        createTableBarcode()
                    End If
                    'CHÈN DỮ LIỆU
                    Dim tbb As DataTable = GridBarcode.DataSource
                    'KIỂM TRA CỘT DỮ LIỆU ĐÃ TỒN TẠI+INSERT DỮ LIỆU SANG DANH SÁCH BARCODE
                    Dim dff() As DataRow = tbb.Select("ProductID='" & M.ProductID.Replace("'", "''") & "'")
                    If dff.Length > 0 Then 'đã tồn tại mã hàng
                        If ProductName <> "" Then
                            dff(0)("ProductName") = M.ProductName 'gán dữ liệu
                        End If
                        If Price <> "" Then
                            dff(0)("ProductName") = M.ProductName 'gán dữ liệu
                        End If
                        If CreateDate <> "" Then
                            dff(0)("CreateDate") = M.CreateDate 'gán dữ liệu
                        End If
                        If V1 <> "" Then
                            dff(0)("V1") = M.V1 'gán dữ liệu
                        End If
                        If V2 <> "" Then
                            dff(0)("V2") = M.V2 'gán dữ liệu
                        End If
                        If V3 <> "" Then
                            dff(0)("V3") = M.V3 'gán dữ liệu
                        End If

                        dff(0)("Qty") = CDbl(txtQty.Text) 'gán dữ liệu
                        GoTo fContinue
                    End If

                    Dim drnew As DataRow = tbb.NewRow
                    drnew("ProductID") = M.ProductID
                    If ProductName <> "" Then
                        drnew("ProductName") = M.ProductName
                    End If
                    If Price <> "" Then
                        drnew("Price") = M.Price
                    End If
                    If CreateDate <> "" Then
                        drnew("CreateDate") = M.CreateDate 'gán dữ liệu
                    End If
                    If V1 <> "" Then
                        drnew("V1") = M.V1 'gán dữ liệu
                    End If
                    If V2 <> "" Then
                        drnew("V2") = M.V2 'gán dữ liệu
                    End If
                    If V3 <> "" Then
                        drnew("V3") = M.V3 'gán dữ liệu
                    End If
                    drnew("Qty") = CDbl(txtQty.Text)
                    tbb.Rows.Add(drnew)
fContinue:

                Next
            End If

            If TabBarcode.Tabs("001").Active = True Then
                TabBarcode.Tabs("002").Selected = True
                txtQty_Row.Focus()
                txtQty_Row.SelectAll()
            End If


        Catch ex As Exception
            ShowMsg(ex.Message)
        End Try

    End Sub

    'kiểm tra dữ liệu in mã vạch
    Private Function CheckBarcodeData() As Boolean
        Try
            Dim tbCol As DataTable = GridCol.DataSource
            If tbCol Is Nothing Then Exit Function
            Dim DF() As DataRow
            Dim ProductID As String = ""
            Dim ProductName As String = ""

            'Dim tbGroup As DataTable = cls.getListGroup
            DF = tbCol.Select("Col='ProductID' and isSelect=True")
            If DF.Length > 0 Then
                ProductID = DF(0)("ColAlias")
            Else
                DF = tbCol.Select("Col='ProductID'")
                If DF.Length > 0 Then
                    ShowMsg("Phải chọn : " & DF(0)("Name"))
                Else
                    ShowMsg("Error")
                End If
                Exit Function
            End If
            'cột tên hàng
            DF = tbCol.Select("Col='ProductName' and isSelect=True")
            If DF.Length > 0 Then
                ProductName = DF(0)("ColAlias")
            End If
            'cột giá
            Dim Price As String = ""
            DF = tbCol.Select("Col='Price' and isSelect=True")
            If DF.Length > 0 Then
                Price = DF(0)("ColAlias")
            End If

            Dim count As Integer = 0
            For i As Integer = 0 To GridBarcode.Rows.Count - 1
                If ProductID <> "" Then
                    If IsDBNull(GridBarcode.Rows(i).Cells("ProductID").Value) Then
                        GridBarcode.Rows(i).Cells("ProductID").Appearance.BackColor = Color.Red
                        count += 1
                    End If
                End If

                If ProductName <> "" Then
                    If IsDBNull(GridBarcode.Rows(i).Cells("ProductName").Value) Then
                        GridBarcode.Rows(i).Cells("ProductName").Appearance.BackColor = Color.Red
                        count += 1
                    End If
                End If

                If Price <> "" Then
                    If IsDBNull(GridBarcode.Rows(i).Cells("Price").Value) Then
                        GridBarcode.Rows(i).Cells("Price").Appearance.BackColor = Color.Red
                        count += 1
                    End If
                    If Not IsDBNull(GridBarcode.Rows(i).Cells("Price").Value) Then
                        If CDbl(GridBarcode.Rows(i).Cells("Price").Value) = 0 Then
                            GridBarcode.Rows(i).Cells("Price").Appearance.BackColor = Color.Red
                            count += 1
                        End If
                    End If

                End If

                If IsDBNull(GridBarcode.Rows(i).Cells("Qty").Value) Then
                    GridBarcode.Rows(i).Cells("Qty").Appearance.BackColor = Color.Red
                    count += 1
                End If
                If GridBarcode.Rows(i).Cells("Qty").Value = 0 Then
                    GridBarcode.Rows(i).Cells("Qty").Appearance.BackColor = Color.Red
                    count += 1
                End If

            Next

            If count > 0 Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            ShowMsg(ex.Message)
        End Try

    End Function

    Private Sub SetColChoose(ByVal sarrCol As String)
        If GridCol.DataSource Is Nothing Then Exit Sub
        Dim arrColumns() As String = sarrCol.Split(";")
        For Each s As String In arrColumns
            If s <> "" Then
                For Each r As UltraGridRow In GridCol.Rows
                    If r.Cells("Col").Value.ToString.ToLower = s.ToLower Then
                        r.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                        r.Appearance.ForeColor = Color.Fuchsia
                    End If
                Next
            End If
        Next
    End Sub
#End Region

    'Chọn dữ liệu từ file Excel
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim sMsg As String = "File import phải có cấu trúc sau:"
        sMsg += vbCrLf & "Cột 1: Mã hàng"
        sMsg += vbCrLf & "Cột 2: Số lượng in(Không bắt buộc)"
        ShowMsgInfo(sMsg)

        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.Title = TextMultiLang("Chọn file Excel", 1016)
        OpenFileDialog1.Filter = "Excel Files(*.xls)|*.xls"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.FileName = ""
        Dim dlg As DialogResult = OpenFileDialog1.ShowDialog()
        If dlg = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Dim sFilePath As String
        sFilePath = OpenFileDialog1.FileName
        If sFilePath = "" Then Exit Sub
        Me.txtFile.Text = sFilePath
        Dim clsu As New Ulti.ClsUti
        Dim tb As DataTable = clsu.ImportDataFromExcel(sFilePath)
        If tb Is Nothing Then
            Exit Sub
        End If
        If tb.Columns.Count < 1 Then
            ShowMsg("File không đúng cấu trúc!")
            Exit Sub
        End If
        Dim fAsk As Boolean = True
        For i As Integer = 0 To tb.Rows.Count - 1
            Dim ProductID As String = tb.Rows(i)(0).ToString
            Dim Qty As Double = 1
            If tb.Columns.Count > 1 Then
                If Not IsDBNull(tb.Rows(i)(1)) AndAlso IsNumeric(tb.Rows(i)(1)) Then
                    Qty = CDbl(tb.Rows(i)(1))
                End If
            Else
                If IsNumeric(txtQty.Text) AndAlso CDbl(txtQty.Text) > 0 Then
                    Qty = CDbl(txtQty.Text)
                End If
            End If
            If Not AddProduct(ProductID, fAsk, Qty) Then
                If fAsk Then
                    If i < tb.Rows.Count - 1 Then
                        If ShowMsgYesNo("Chọn YES tiếp tục thực hiện(bỏ qua những dòng không hợp lệ)" & vbCrLf & "Chọn NO dừng lại để kiểm tra") <> Windows.Forms.DialogResult.Yes Then
                            Exit Sub
                        Else

                            fAsk = False
                        End If
                    End If

                End If
            End If
        Next

        'Grid.DataSource = tb
        'ShowCol()
        'SetColChoose("ProductID;ProductName")
    End Sub


    'chuyển dữ liệu sang danh sách in mã vạch
    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Dim isAll As Boolean = True
        ChangeListToBarcodeList(True)
    End Sub
    'thực hiện in mã vạch
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'If Not showDAL Then
        '    If Not Me.CheckBarcodeData Then
        '        ShowMsg(TextMultiLang("Dữ liệu không hợp lệ !", 167))
        '        Exit Sub
        '    End If
        'End If

        If txtQty_Row.Text = "" Then
            ShowMsg(TextMultiLang("Số mã vạch/dòng không hợp lệ !", 1562))
            txtQty_Row.Focus()
            Exit Sub
        End If
        If CDbl(txtQty_Row.Text) = 0 Then
            ShowMsg(TextMultiLang("Số mã vạch/dòng không hợp lệ !", 1562))
            txtQty_Row.Focus()
            Exit Sub
        End If
        If txtPath.Text = "" Then
            ShowMsg(TextMultiLang("Chưa có đường dẫn mẫu in !", 1217))
            btnBrowseReport.Focus()
            Exit Sub
        End If

        Dim num As Integer = CInt(Me.txtQty_Row.Text) '- số mã vạch/dòng
        If num > 15 Then
            ShowMsg(TextMultiLang("Số mã vạch/dòng hiện tại tối đa là 15 !", 1563))
        End If

        Dim k As Integer = 1
        Dim j As Integer = 1
        Dim sql As String = ""
        Dim clsM As New DALAccess

        sql = " Delete from images "
        If clsM.ExecuteSQL(sql) Then
            sql = " Insert into images([Note]) values('" & j.ToString & "')"
            If clsM.ExecuteSQL(sql) Then
                For r As Integer = 0 To GridBarcode.Rows.Count - 1 'danh sách mã vạch cần in
                    For rc As Integer = 1 To CDbl(GridBarcode.Rows(r).Cells("Qty").Value) 'số lần in cho một mã vạch
                        Dim ii As Integer = k Mod num
                        If ii = 0 Then ii = num

                        Dim ProductID As String = GridBarcode.Rows(r).Cells("ProductID").Value
                        Dim ProductName As String = ""
                        If Not IsDBNull(GridBarcode.Rows(r).Cells("ProductName").Value) Then
                            ProductName = GridBarcode.Rows(r).Cells("ProductName").Value
                        End If
                        Dim Price As Double = 0
                        If Not IsDBNull(GridBarcode.Rows(r).Cells("Price").Value) Then
                            Price = CDbl(GridBarcode.Rows(r).Cells("Price").Value)
                        End If
                        Dim isDay As Boolean = False
                        Dim d As Date = Now
                        If Not IsDBNull(GridBarcode.Rows(r).Cells("CreateDate").Value) Then
                            If IsDate(GridBarcode.Rows(r).Cells("CreateDate").Value) Then
                                isDay = True
                                d = GridBarcode.Rows(r).Cells("CreateDate").Value
                            End If
                        End If
                        Dim V1 As String = ""
                        If Not IsDBNull(GridBarcode.Rows(r).Cells("V1").Value) Then
                            V1 = GridBarcode.Rows(r).Cells("V1").Value
                        End If
                        Dim V2 As String = ""
                        If Not IsDBNull(GridBarcode.Rows(r).Cells("V2").Value) Then
                            V2 = GridBarcode.Rows(r).Cells("V2").Value
                        End If
                        Dim V3 As String = ""
                        If Not IsDBNull(GridBarcode.Rows(r).Cells("V3").Value) Then
                            V3 = GridBarcode.Rows(r).Cells("V3").Value
                        End If

                        sql = "Update images set [BarCodeID" & ii.ToString & "]='" & ProductID.Replace("'", "''") & "', "
                        'sql += "[A_Image" & ii.ToString & "]=getdate(), "
                        sql += "[BarCodeName" & ii.ToString & "]='" & ProductName.Replace("'", "''") & "', "
                        sql += "[Price" & ii.ToString & "]=" & Price
                        If isDay Then
                            sql += ", [CreateDate" & ii.ToString & "]='" & Format(d, "yyyy/MM/dd") & "'"
                        End If
                        sql += ", [NA" & ii.ToString & "]='" & V1.Replace("'", "''") & "', "
                        sql += "[NB" & ii.ToString & "]='" & V2.Replace("'", "''") & "', "
                        sql += "[NC" & ii.ToString & "]='" & V3.Replace("'", "''") & "' "

                        sql += " where [Note]='" & j.ToString & "'"
                        If clsM.ExecuteSQL(sql) Then
                            If k Mod num = 0 Then
                                j += 1
                                sql = " Insert into images([Note]) values('" & j.ToString & "')"
                                clsM.ExecuteSQL(sql)

                            End If
                            k += 1
                        End If

                    Next

                Next

                sql = "Delete from images where BarCodeID1=''"
                clsM.ExecuteSQL(sql)

            End If

        End If

        'Dim ser, db, uid, pass As String

        'ser = System.Configuration.ConfigurationSettings.AppSettings("Server")
        'db = System.Configuration.ConfigurationSettings.AppSettings("Database")
        'uid = System.Configuration.ConfigurationSettings.AppSettings("UserID")
        'pass = System.Configuration.ConfigurationSettings.AppSettings("Password")

        Dim clsR As New ClsReportBarcode
        Dim rp As New ReportDocument
        Dim filename As String = txtPath.Text 'Application.StartupPath & "\Reports\banhang_HNC\rptMavachdung.rpt"

        rp = clsR.InitReport(filename)

        Dim frm As New FrmReportBarcode
        frm.rpt.ReportSource = rp
        frm.Show()
        rp = Nothing

    End Sub

    Private Sub btnBrowseReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseReport.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.Title = TextMultiLang("Chọn mẫu báo cáo", 1564)
        OpenFileDialog1.Filter = "Excel Files(*.rpt)|*.rpt"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.InitialDirectory = My.Settings.FilterPath

        Dim dlg As DialogResult = OpenFileDialog1.ShowDialog()
        If dlg = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        Dim sFilePath As String
        sFilePath = OpenFileDialog1.FileName
        If sFilePath = "" Then Exit Sub
        Me.txtPath.Text = sFilePath
        Dim ind As Integer = sFilePath.LastIndexOf("\")
        If ind <> 0 Then
            FilterPath = sFilePath.Substring(0, ind)
        Else
            FilterPath = sFilePath
        End If
        My.Settings.FilterPath = FilterPath
        My.Settings.Save()
        'FilterPath = sFilePath.Substring(0, Len(sFilePath) - Len(OpenFileDialog1.SafeFileName))
        '===

    End Sub

    'dữ liệu đọc từ file excel
    Private Sub Grid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.DoubleClick
        Dim r As Infragistics.Win.UltraWinGrid.UltraGridRow = Grid.ActiveRow
        If r Is Nothing Then Exit Sub
        If r.Index = -1 Then Exit Sub

        Dim isAll As Boolean = False
        Me.ChangeListToBarcodeList(isAll)
    End Sub
    Private Sub Grid_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles Grid.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub
    'định dạng lưới danh sách cột dữ liệu
    Private Sub GridCol_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridCol.InitializeLayout
        If GridCol.DataSource Is Nothing Then Exit Sub
        e.Layout.Bands(0).Columns("Col").Hidden = True
        e.Layout.Bands(0).Columns("Name").Header.Caption = TextMultiLang("Cột dữ liệu", 1512)
        e.Layout.Bands(0).Columns("Name").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        e.Layout.Bands(0).Columns("Name").CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect

        e.Layout.Bands(0).Columns("ColAlias").Header.Caption = TextMultiLang("Cột tương ứng", 1311)
        e.Layout.Bands(0).Columns("ColAlias").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center

        e.Layout.Bands(0).Columns("isSelect").Header.Caption = TextMultiLang("Chọn In", 1565)
        e.Layout.Bands(0).Columns("isSelect").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center

        If Not GridColAlias.DataSource Is Nothing Then
            e.Layout.Bands(0).Columns("ColAlias").ValueList = GridColAlias
        End If
        'Thao21.06.2010- Frame các dòng dưới do dc thiêt lập trong hàm ShowCol()

        'Dim tb As DataTable = GridColAlias.DataSource
        'For Each r As UltraGridRow In GridCol.Rows
        '    Select Case r.Cells("Col").Value
        '        Case "ProductID"
        '            If tb.Rows.Count > 0 Then
        '                r.Cells("ColAlias").Value = tb.Rows(0)(0)
        '            End If
        '        Case "ProductName"
        '            If tb.Rows.Count > 1 Then
        '                r.Cells("ColAlias").Value = tb.Rows(1)(0)
        '            End If
        '        Case "Price"
        '            If tb.Rows.Count > 2 Then
        '                r.Cells("ColAlias").Value = tb.Rows(2)(0)
        '            End If
        '        Case "CreateDate"
        '            If tb.Rows.Count > 3 Then
        '                r.Cells("ColAlias").Value = tb.Rows(3)(0)
        '            End If
        '        Case "V1"
        '            If tb.Rows.Count > 4 Then
        '                r.Cells("ColAlias").Value = tb.Rows(4)(0)
        '            End If
        '        Case "V2"
        '            If tb.Rows.Count > 5 Then
        '                r.Cells("ColAlias").Value = tb.Rows(5)(0)
        '            End If
        '        Case "V3"
        '            If tb.Rows.Count > 6 Then
        '                r.Cells("ColAlias").Value = tb.Rows(6)(0)
        '            End If
        '    End Select

        '    If r.Cells("ColAlias").Value <> "" Then
        '        'r.Cells("isSelect").Value = True
        '        Select r.Cells("Col").Value
        '            Case "ProductID"
        '                r.Cells("isSelect").Value = True
        '            Case "ProductName"
        '                r.Cells("isSelect").Value = True
        '            Case Else
        '                r.Cells("isSelect").Value = False
        '        End Select
        '    End If

        '    r.Update()

        ' Next

        GridCol.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.FromArgb(255, 216, 228, 248)
    End Sub
    'danh sách in mã vạch
    Private Sub GridBarcode_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridBarcode.InitializeLayout
        If GridBarcode.DataSource Is Nothing Then Exit Sub

        e.Layout.Bands(0).Columns("ProductID").Header.Caption = TextMultiLang("Mã hàng", 921)
        e.Layout.Bands(0).Columns("ProductID").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        e.Layout.Bands(0).Columns("ProductID").CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect

        e.Layout.Bands(0).Columns("ProductName").Header.Caption = TextMultiLang("Tên hàng", 922)
        e.Layout.Bands(0).Columns("ProductName").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        e.Layout.Bands(0).Columns("ProductName").CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect

        e.Layout.Bands(0).Columns("Price").Header.Caption = TextMultiLang("Đơn giá", 1551)
        e.Layout.Bands(0).Columns("Price").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        e.Layout.Bands(0).Columns("Price").CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect

        e.Layout.Bands(0).Columns("CreateDate").Header.Caption = TextMultiLang("Ngày tạo", 1552)
        e.Layout.Bands(0).Columns("CreateDate").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        e.Layout.Bands(0).Columns("CreateDate").Format = "dd/MM/yyyy"
        e.Layout.Bands(0).Columns("CreateDate").CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect

        e.Layout.Bands(0).Columns("V1").Header.Caption = TextMultiLang("Ghi chú 1", 1553)
        e.Layout.Bands(0).Columns("V1").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        e.Layout.Bands(0).Columns("V1").CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText

        e.Layout.Bands(0).Columns("V2").Header.Caption = TextMultiLang("Ghi chú 2", 1554)
        e.Layout.Bands(0).Columns("V2").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        e.Layout.Bands(0).Columns("V2").CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText

        e.Layout.Bands(0).Columns("V3").Header.Caption = TextMultiLang("Ghi chú 3", 1555)
        e.Layout.Bands(0).Columns("V3").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        e.Layout.Bands(0).Columns("V3").CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText

        e.Layout.Bands(0).Columns("Qty").Header.Caption = TextMultiLang("Sl in", 1566)
        e.Layout.Bands(0).Columns("Qty").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        e.Layout.Bands(0).Columns("Qty").Format = "#,##0"
        GridBarcode.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.FromArgb(255, 216, 228, 248)
    End Sub
    Private Sub GridBarcode_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles GridBarcode.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub txtQty_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        Dim k As Short = Asc(e.KeyChar)
        clsu.UltraTextBox_KeyPress(k, txtQty)
        If k = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtQty_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyUp
        If e.KeyCode = Keys.Enter Then
            btnSelect.Focus()
        End If
    End Sub
    Private Sub txtQty_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.ValueChanged
        clsu.UltraTextBox_Change("#,##0", txtQty)
    End Sub

    Private Sub txtQty_Row_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty_Row.KeyPress
        Dim k As Short = Asc(e.KeyChar)
        clsu.UltraTextBox_KeyPress(k, txtQty_Row)
        If k = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtQty_Row_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty_Row.KeyUp
        If e.KeyCode = Keys.Enter Then
            btnBrowseReport.Focus()
        End If
    End Sub
    Private Sub txtQty_Row_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty_Row.ValueChanged
        clsu.UltraTextBox_Change("#,##0", txtQty_Row)
    End Sub

    'xóa một dòng in mã vạch
    Private Sub T_DEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim r As Infragistics.Win.UltraWinGrid.UltraGridRow = GridBarcode.ActiveRow
        If r Is Nothing Then Exit Sub
        If r.Index = -1 Then Exit Sub

        r.Delete(False)
        r.Update()
    End Sub
    Private Sub T_DELALL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If GridBarcode.Selected.Rows.Count = 0 Then
            ShowMsg("Chưa chọn dòng để xóa !")
            GridBarcode.Focus()
            Exit Sub
        End If

        For i As Integer = 0 To GridBarcode.Selected.Rows.Count - 1

        Next

    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        If txtQty.Text = "" Then
            ShowMsg(TextMultiLang("Chưa nhập số lượng in mỗi mã vạch !", 1215))
            txtQty.Focus()
            Exit Sub
        End If
        If CDbl(txtQty.Text) = 0 Then
            ShowMsg(TextMultiLang("Chưa nhập số lượng in mỗi mã vạch !", 1215))
            txtQty.Focus()
            Exit Sub
        End If
        If Not Grid.DataSource Is Nothing And GridBarcode.DataSource Is Nothing Then
            ShowMsg(TextMultiLang("Phải chuyển tất cả sang in mã vạch !", 1567))
            Exit Sub
        End If

        Dim tb As DataTable = GridBarcode.DataSource
        If tb Is Nothing Then Exit Sub
        For Each dr As DataRow In tb.Rows
            dr("Qty") = CDbl(txtQty.Text)
        Next

    End Sub

    Private Sub Grid_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid.InitializeLayout
        'Grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.FromArgb(255, 216, 228, 248)

        'For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
        '    e.Layout.Bands(0).Columns(i).Hidden = True
        'Next
        'clsuf.FormatGridFromDB(Me.Name, Grid) ', iLang

        Grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.FromArgb(255, 216, 228, 248)

        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = False
        Next
        'clsuf.FormatGridFromDB(Me.Name, Grid, iLang)
        Grid.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True
    End Sub

    Private Sub GridColAlias_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridColAlias.InitializeLayout
        e.Layout.Bands(0).ColHeadersVisible = False 'Thao21.06.2010
        GridColAlias.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.FromArgb(255, 216, 228, 248)
    End Sub


    Private Sub GridBarcode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridBarcode.KeyUp
        If e.KeyCode = Keys.Enter Or e.KeyCode = 37 Or e.KeyCode = 38 Or e.KeyCode = 39 Or e.KeyCode = 40 Then

            Dim r As UltraGridRow = GridBarcode.ActiveRow
            If r Is Nothing Then Exit Sub
            If r.Index = -1 Then Exit Sub

            If GridBarcode.ActiveCell Is Nothing Then Exit Sub
            Dim sCol As String = GridBarcode.ActiveCell.Column.Key.ToLower

            If e.KeyCode = Keys.Enter Then
                If r.Index = GridBarcode.Rows.Count - 1 Then
                    r = GridBarcode.Rows(0)
                Else
                    r = GridBarcode.Rows(r.Index + 1)
                End If
            End If
            r.Activated = True
            r.Cells(sCol).Activate()
            If GridBarcode.ActiveCell.CanEnterEditMode Then
                Me.GridBarcode.PerformAction(UltraGridAction.EnterEditMode)
                r.Cells(sCol).IsInEditMode = True
                r.Cells(sCol).SelectAll()
            End If

        End If
    End Sub


#Region " Them hang hoa"

    Private Function AddProduct(ByVal ProID As String, ByVal fAsk As Boolean, ByVal Qty As Double) As Boolean
        Dim tb As DataTable = GridBarcode.DataSource
        Dim tbPro As DataTable = GridProduct.DataSource
        If tb Is Nothing OrElse tbPro Is Nothing Then Exit Function
        Dim DF() As DataRow = tbPro.Select("s_Product_ID='" & ProID.Replace("'", "''") & "'")
        If DF.Length = 0 Then
            If fAsk Then
                ShowMsg("Mã hàng '" & ProID & "' chưa được định nghĩa!")
            End If

            Return False
        End If
        Dim df2() As DataRow = tb.Select("ProductID = '" & ProID.Replace("'", "''") & "'")
        If df2.Length > 0 Then
            If fAsk Then
                ShowMsg("Mã hàng '" & ProID & "' đã được chọn!")
            End If

            Return False
        End If

        Dim drnew As DataRow = tb.NewRow
        Dim ProductID As String = DF(0)("s_Product_ID").ToString
        Dim ProductName As String = DF(0)("s_Name").ToString
        Dim Price As Double = IsNull(DF(0)("m_UnitPrice"), 0)
        Dim CreateDate As Date = Now()
        Try
            If tbPro.Columns.Contains("dt_Create") Then
                CreateDate = IsNull(DF(0)("dt_Create"), Now)
            End If

        Catch ex As Exception

        End Try

        Dim V1 As String = "" 'DF(0)("s_Unit")
        Dim V2 As String = "" 'DF(0)("GroupName")
        Dim V3 As String = "" 'Grid.Selected.Rows(i).Cells("s_Name")

        Dim s() As String = Col.Split(",")
        If s.Length >= 3 Then
            If s(0) <> "" Then
                Try
                    If tbPro.Columns.Contains(s(0)) Then
                        V1 = DF(0)(s(0)).ToString
                    End If

                Catch ex As Exception
                    V1 = ""
                End Try
            End If
            If s(1) <> "" Then
                Try
                    If tbPro.Columns.Contains(s(1)) Then
                        V2 = DF(0)(s(1)).ToString
                    End If
                Catch ex As Exception
                    V2 = ""
                End Try
            End If
            If s(2) <> "" Then
                Try
                    If tbPro.Columns.Contains(s(2)) Then
                        V3 = DF(0)(s(2)).ToString
                    End If
                Catch ex As Exception
                    V3 = ""
                End Try
            End If
        End If

        drnew("Qty") = Qty
        drnew("ProductID") = ProductID
        drnew("ProductName") = ProductName
        drnew("Price") = Price
        drnew("CreateDate") = CreateDate
        drnew("V1") = V1
        drnew("V2") = V2
        drnew("V3") = V3

        tb.Rows.Add(drnew)
        Return True

    End Function

    Private Sub GridProduct_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridProduct.DoubleClick

        AddMulti()
    End Sub
    Private Sub AddMulti()

        If Not GridProduct.ActiveRow Is Nothing AndAlso GridProduct.ActiveRow.Index <> -1 Then GridProduct.ActiveRow.Selected = True
        Dim fAsk As Boolean = True
        Dim Qty As Double = 1
        If IsNumeric(txtQty.Text) AndAlso CDbl(txtQty.Text) > 0 Then
            Qty = CDbl(txtQty.Text)
        End If
        For i As Integer = 0 To GridProduct.Selected.Rows.Count - 1
            Dim ProductID As String = GridProduct.Selected.Rows(i).Cells("s_Product_ID").Value.ToString
            If Not AddProduct(ProductID, fAsk, Qty) Then
                If fAsk Then
                    If i < GridProduct.Selected.Rows.Count - 1 Then
                        If ShowMsgYesNo("Chọn YES tiếp tục thực hiện(bỏ qua những dòng không hợp lệ)" & vbCrLf & "Chọn NO dừng lại để kiểm tra") <> Windows.Forms.DialogResult.Yes Then
                            Exit Sub
                        Else
                            fAsk = False
                        End If
                    End If

                End If
            End If
        Next
    End Sub
    'Private Function Checkpro(ByVal ID As String) As Boolean
    '    Dim tb As DataTable = GridBarcode.DataSource
    '    Dim df() As DataRow = tb.Select("ProductID = '" & ID & "'")

    '    For Each r As UltraGridRow In GridBarcode.Rows
    '        If r.Cells("ProductID").Value = ID Then
    '            If ShowMsgYesNo("Hàng hóa này đã được chọn ! . Tiếp tục hay dừng lại .") = Windows.Forms.DialogResult.No Then
    '                Return False
    '            Else
    '                Continue For
    '            End If
    '        End If
    '    Next
    '    Return True
    'End Function

    Private Sub GridProduct_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridProduct.InitializeLayout
        GridProduct.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.FromArgb(255, 216, 228, 248)

        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = False
        Next
        clsuf.FormatGridFromDB(Me.Name, GridProduct)
        GridProduct.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True
    End Sub

    Private Sub GridProduct_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridProduct.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.Z Then
                Dim frm As New Ulti.FrmFormatUltraGrid(Me.Name, GridProduct)
                frm.ShowDialog()
            End If
        End If
    End Sub

    Public Function IsNull(ByVal Exp As Object, ByVal ExpReplace As Object) As Object
        If IsDBNull(Exp) Then
            Return ExpReplace
        Else
            Return Exp
        End If
    End Function

    Private Sub T_Addproduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Addproduct.Click
        AddMulti()
    End Sub

    Private Sub GridProduct_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GridProduct.MouseDown
        Dim r As UltraGridRow = GridProduct.ActiveRow

        Dim element As Infragistics.Win.UIElement = GridProduct.DisplayLayout.UIElement.ElementFromPoint(New Point(e.X, e.Y))
        Dim result As UltraGridRow = element.GetContext(GetType(UltraGridRow))


        If Not result Is Nothing Then
            If result.Index <> -1 Then
                If Not result.IsDataRow Then
                    Exit Sub
                End If
                result.Activated = True
                r = result
            End If
        End If

        If e.Button = Windows.Forms.MouseButtons.Right Then
            ctmenu.Show(GridProduct, New Point(e.X, e.Y))
        End If
    End Sub

#End Region

    Private Sub Link_Open_report_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Link_Open_report.LinkClicked
        Try
            If txtPath.Text = "" Then Exit Sub
            'If lstFunc.DataSource Is Nothing Then Exit Sub
            'If lstFunc.SelectedValue = 0 Then Exit Sub
            'Dim tb As DataTable
            'Dim s_FileReport As String = ""
            'tb = lstFunc.DataSource
            'Dim DF() As DataRow = tb.Select("ID=" & lstFunc.SelectedValue)
            'If DF.Length > 0 Then
            '    s_FileReport = IsNull(DF(0)("PathFile"), "")
            'End If

            'Process.Start(Application.StartupPath & s_FileReport)
            Process.Start(txtPath.Text)
        Catch ex As Exception
            ShowMsg(TextMultiLang("Lỗi khi mở file report !", 192))
        End Try

    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        'If TabBarcode.Tabs("001").Selected Then
        '    ExportExcel(Grid)
        'Else
        '    ExportExcel(GridBarcode)
        'End If
        ExportExcel(GridBarcode)

    End Sub

    Private Exp As New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    ''' <summary>
    ''' xuất ra file excel từ grid
    ''' </summary>
    ''' <param name="Grid"></param>
    ''' <param name="NameOfFile">Đặt tên cho file excel</param>
    ''' <remarks></remarks>
    Public Sub ExportExcel(ByVal Grid As Infragistics.Win.UltraWinGrid.UltraGrid, Optional ByVal NameOfFile As String = "")
        If Grid Is Nothing Then Exit Sub
        If Grid.DataSource Is Nothing Then Exit Sub
        Dim OpenFileDialog1 As New SaveFileDialog
        OpenFileDialog1.Title = "Chọn file lưu trữ"
        OpenFileDialog1.Filter = "Excel Files(*.xls)|*.xls"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.FileName = NameOfFile
        Dim dlg As DialogResult = OpenFileDialog1.ShowDialog()
        Exp.FileLimitBehaviour = Infragistics.Win.UltraWinGrid.ExcelExport.FileLimitBehaviour.TruncateData
        If dlg = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Dim sFilePath As String

        sFilePath = OpenFileDialog1.FileName
        If sFilePath = "" Then Exit Sub
        'If System.IO.File.Exists(sFilePath) = False Then
        '    Exit Sub
        'End If
        Try
            Exp.Export(Grid, sFilePath)
            ShowMsgInfo("Xuất file thành công!")
            Dim p As New Process
            Process.Start(sFilePath)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.Title = TextMultiLang("Chọn chương trình in mã vạch", 1016)
        'OpenFileDialog1.Filter = "Excel Files(*.exe)|*.exe"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.FileName = ""
        Dim dlg As DialogResult = OpenFileDialog1.ShowDialog()
        If dlg = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        txtProcess.Text = OpenFileDialog1.FileName

    End Sub

    Private Sub UltraButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton2.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.Title = TextMultiLang("Chọn file lưu dữ liệu", 1016)
        OpenFileDialog1.Filter = "Access Files(*.mdb)|*.mdb"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.FileName = ""
        Dim dlg As DialogResult = OpenFileDialog1.ShowDialog()
        If dlg = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        txtData.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub UltraButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton3.Click
        Try
            If Not IO.File.Exists(txtProcess.Text) Then
                ShowMsg("Đường dẫn chương trình in không hợp lệ!")
                TabBarcode.Tabs("003").Active = True
                txtProcess.Focus()
                Exit Sub
            End If
            If Not IO.File.Exists(txtProcess.Text) Then
                ShowMsg("Đường dẫn file lưu dữ liệu không hợp lệ!")
                TabBarcode.Tabs("003").Active = True
                txtData.Focus()
                Exit Sub
            End If
            GridBarcode.UpdateData()
            Dim tb As DataTable = GridBarcode.DataSource
            If tb Is Nothing Then Exit Sub
            If tb.Rows.Count = 0 Then
                ShowMsg("Không có dữ liệu")
                Exit Sub
            End If
            'tb.Columns.Add("ProductID", GetType(String))
            'tb.Columns.Add("ProductName", GetType(String))
            'tb.Columns.Add("Price", GetType(Double))
            'tb.Columns.Add("CreateDate", GetType(Date))
            'tb.Columns.Add("V1", GetType(String))
            'tb.Columns.Add("V2", GetType(String))
            'tb.Columns.Add("V3", GetType(String))
            'tb.Columns.Add("Qty", GetType(Double))
            'Dim fConvert As Boolean = False
            'If ShowMsgYesNo("Convert font chữ qua TCVN?") = Windows.Forms.DialogResult.Yes Then
            '    fConvert = True
            'End If
            Dim clsM As New DALAccess
            clsM.SERVER = txtData.Text
            If Not clsM.ExecuteSQL("Delete from SLTemIn") Then
                Exit Sub
            End If
            Dim k As Integer = 1
            For Each dr As DataRow In tb.Rows
                If dr.RowState <> DataRowState.Deleted Then
                    Dim ProductID As String = dr("ProductID").ToString
                    Dim ProductName As String = dr("ProductName").ToString
                    Dim V1 As String = dr("V1").ToString
                    Dim V2 As String = dr("V2").ToString
                    Dim V3 As String = dr("V3").ToString
                    If ChConvert.Checked Then
                        ProductID = ConvertUnicode_TCVN(ProductID)
                        ProductName = ConvertUnicode_TCVN(ProductName)
                        V1 = ConvertUnicode_TCVN(V1)
                        V2 = ConvertUnicode_TCVN(V2)
                        V3 = ConvertUnicode_TCVN(V3)

                    End If
                    If V1 = "" Then V1 = " "
                    If V2 = "" Then V2 = " "
                    If V3 = "" Then V3 = " "

                    Dim CreateDate As Date = IsNull(dr("CreateDate"), Now)
                    Dim Price As Double = CDbl(IsNull(dr("Price"), 0))
                    Dim Qty As Integer = CInt(IsNull(dr("Qty"), 0))
                    For i As Integer = 1 To Qty
                        Dim sql As String = "Insert into SLTemIn(SO_THU_TU,MA_HH,TEN_HH,GIA_BAN_LE,MA_NCC,NGAY_IN,TEXT01,TEXT02)"
                        sql += " values(" & k.ToString
                        sql += " ,'" & ProductID.Replace("'", "''") & "'"
                        sql += " ,'" & ProductName.Replace("'", "''") & "'"
                        sql += " ,'" & Format(Price, "#,##0.##") & "'"
                        sql += " ,'" & V1.Replace("'", "''") & "'"
                        sql += " ,#" & Format(CreateDate, "MM/dd/yyyy") & "#"
                        sql += " ,'" & V2.Replace("'", "''") & "'"
                        sql += " ,'" & V3.Replace("'", "''") & "')"
                        If Not clsM.ExecuteSQL(sql) Then
                            Exit Sub
                        End If
                        k += 1
                    Next

                End If

            Next
            ShowMsgInfo("Save dữ liệu thành công!")
            Process.Start(txtProcess.Text)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub cboGroup_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboGroup.InitializeLayout
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next
        e.Layout.Bands(0).Columns("s_Name").Hidden = False
        e.Layout.Bands(0).Columns("s_ProductGroup_ID").Hidden = False
        e.Layout.Bands(0).Columns("s_ProductGroup_ID").Width = 80
        e.Layout.Bands(0).Columns("s_Name").Width = 200
        If cboGroup.Rows.Count > 0 Then
            cboGroup.Rows(0).Appearance.BackColor = Color.LightCyan
        End If
    End Sub

    Private Sub cboGroup_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGroup.ValueChanged
        If fPageLoad Then
            Me.Filter()
        End If
    End Sub
End Class
