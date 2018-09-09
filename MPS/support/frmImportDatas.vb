Imports Infragistics.Win.UltraWinGrid
Imports VsoftBMS

Public Class frmImportDatas
    Dim clsuf As New Ulti.ClsFormatUltraGrid
    Dim fOK As Boolean = False
    Private sFunc As String = ""
    Dim bImportOK As Boolean = True

    Public Overloads Function ShowDialog(ByVal s_Import As String) As Boolean
        sFunc = s_Import
        Me.ShowDialog()
        Return fOK
    End Function

    Private Sub frmImportDatas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmImportDatas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me)
        ModMain.BlueButton(btnImports, ModMain.m_AddIcon)
        ModMain.RedButton(btncheck, ModMain.m_OkIcon)
        ModMain.GreenButton(btnclose, ModMain.m_CancelIcon)
    End Sub

    Private Sub GridCol_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles GridCol.CellChange
        Dim r As UltraGridRow = GridCol.ActiveRow
        If r Is Nothing Then Exit Sub
        If r.Index = -1 Then Exit Sub

        Select Case e.Cell.Column.Key
            Case "ColAlias"
                If IsNull(r.Cells("ColAlias").Text, "") <> "" Then
                    r.Cells("isSelect").Value = True
                Else
                    r.Cells("isSelect").Value = False
                End If
        End Select

        r.Update()
    End Sub

    Private Sub GridCol_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridCol.InitializeLayout
        e.Layout.Bands(0).Columns("Col").Hidden = True
        e.Layout.Bands(0).Columns("Name").Header.Caption = "Cột dữ liệu"
        e.Layout.Bands(0).Columns("Name").CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        e.Layout.Bands(0).Columns("ColAlias").Header.Caption = "Cột tương ứng"
        e.Layout.Bands(0).Columns("isSelect").Header.Caption = "Chọn Import"
        If Not GridColAlias.DataSource Is Nothing Then
            e.Layout.Bands(0).Columns("ColAlias").ValueList = GridColAlias
        End If
        GridCol.DisplayLayout.Override.RowAlternateAppearance.BackColor = ModMain.m_sysColor
    End Sub

    Private Sub GridColAlias_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridColAlias.InitializeLayout
        e.Layout.Bands(0).ColHeadersVisible = False
        GridColAlias.DisplayLayout.Override.RowAlternateAppearance.BackColor = ModMain.m_sysColor
    End Sub

    Private Sub btnImports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImports.Click
        If Not Grid.ActiveRow Is Nothing Then Grid.ActiveRow.Update()
        If Not GridCol.ActiveRow Is Nothing Then GridCol.ActiveRow.Update()

        Select Case sFunc.ToLower
            Case "frmMainContractors".ToLower
                ImportUnit()
        End Select
        fOK = True
    End Sub

    Private Sub btncheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncheck.Click
        If Not Grid.ActiveRow Is Nothing Then Grid.ActiveRow.Update()
        If Not GridCol.ActiveRow Is Nothing Then GridCol.ActiveRow.Update()

        bImportOK = True
        Select Case sFunc.ToLower
            Case "Unit2".ToLower
                CheckImportUnit()
        End Select
        If Not bImportOK Then
            ShowMsg("Thông tin import bị trùng hoặc nội dung còn trống hoặc nội dung không hợp lệ!")
            Exit Sub
        Else
            ShowMsgInfo("Thông tin import hợp lệ!")
        End If

        fOK = True
    End Sub

    Private Sub Grid_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles Grid.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub Grid_CellDataError(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs) Handles Grid.CellDataError
        e.RaiseErrorEvent = False
        e.RestoreOriginalValue = True
        Dim r As UltraGridRow = Grid.ActiveRow
        If r Is Nothing Then Exit Sub
        If r.Index = -1 Then Exit Sub
        If Grid.ActiveCell Is Nothing Then Exit Sub
        Dim sCol As String = Grid.ActiveCell.Column.Key

        Dim ind As Integer
        If r.Index <= Grid.Rows.Count - 1 Then
            ind = r.Index '+ 1
        Else
            ind = 0
        End If
        Grid.Rows(ind).Activated = True
        Grid.Rows(ind).Cells(sCol).Activated = True
        Grid.PerformAction(UltraGridAction.EnterEditMode)
    End Sub

    Private Sub Grid_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid.InitializeLayout
        Grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = ModMain.m_sysColor
        Grid.DisplayLayout.Override.RowAppearance.BorderColor = ModMain.m_sysColor
    End Sub

    Private Sub Grid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim r As UltraGridRow = Grid.ActiveRow
            If r Is Nothing Then Exit Sub
            If r.Index = -1 Then Exit Sub
            If Grid.ActiveCell Is Nothing Then Exit Sub
            Dim sCol As String = Grid.ActiveCell.Column.Key

            Dim ind As Integer
            If r.Index < Grid.Rows.Count - 1 Then
                ind = r.Index + 1
            Else
                ind = 0
            End If
            Grid.Rows(ind).Activated = True
            Grid.Rows(ind).Cells(sCol).Activated = True
            Grid.PerformAction(UltraGridAction.EnterEditMode)
        End If

    End Sub
    Private Sub RemoveCol(ByVal Col As String)
        Dim tb As DataTable = GridCol.DataSource
        If tb Is Nothing Then Exit Sub
        Dim arrCol() As String = Col.Split(";")
        For Each Col In arrCol
            If Col.Trim <> "" Then
                Dim DF() As DataRow = tb.Select("Col='" & Col.Trim.Replace("'", "''") & "'")
                If DF.Length > 0 Then DF(0).Delete()
            End If
        Next

    End Sub
    Private Sub AddCol(ByVal ColData As String, ByVal sName As String)
        Dim tb As DataTable = GridCol.DataSource
        If tb Is Nothing Then Exit Sub

        Dim DF() As DataRow = tb.Select("Col='" & ColData.Trim.Replace("'", "''") & "'")
        If DF.Length = 0 Then
            Dim drN As DataRow = tb.NewRow
            drN("Col") = ColData
            drN("isSelect") = False
            drN("Name") = sName
            drN("ColAlias") = ""
            tb.Rows.Add(drN)
        Else
            DF(0)("Name") = sName
        End If


    End Sub

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

    'Thao140809 focus cell khi có cột tuong ứng ko có
    Private Sub CellFocus(ByVal ColName As String)
        For Each r As UltraGridRow In GridCol.Rows
            If r.Cells(0).Value.ToString = ColName Then
                If r.Cells(1).Value.ToString <> r.Cells(2).Value.ToString Then
                    r.Cells(2).Activate()
                    Exit For
                End If
            End If
        Next
    End Sub
    Dim fCheckImport As Boolean = False
    Private Function CheckImportUnit() As Boolean
        fCheckImport = True
        If Grid.DataSource Is Nothing Then
            bImportOK = False
            Return False
        End If

        Dim tb As DataTable = Grid.DataSource
        If tb Is Nothing Then Exit Function
        Grid.DataSource = tb
        Grid.Rows.Refresh(RefreshRow.RefreshDisplay)
        Grid.DisplayLayout.Bands(0).Columns("s_IDProduct").Hidden = True
        Grid.DisplayLayout.Bands(0).Columns("b_Import").Header.Caption = "Mặc định nhập"
        Grid.DisplayLayout.Bands(0).Columns("b_Order").Header.Caption = "Mặc định xuất"
        Grid.DisplayLayout.Bands(0).Columns("b_Instock").Header.Caption = "Mặc định tồn"

        Dim tbCol As DataTable = GridCol.DataSource
        If tbCol Is Nothing Then
            bImportOK = False
            Exit Function
        End If


        Dim DF() As DataRow
        DF = tbCol.Select("isSelect=True")
        If DF.Length = 0 Then
            ShowMsg("Không có cột dữ liệu nào được chọn Import!")
            bImportOK = False
            Exit Function
        End If

        Dim ProductID As String = ""
        DF = tbCol.Select("Col='ProductID' and isSelect=True")
        If DF.Length > 0 Then
            ProductID = IsNull(DF(0)("ColAlias"), "")
            If ProductID = "" Then
                ShowMsg("Chọn cột tương ứng với '" & DF(0)("Name") & "'", m_MsgCaption)
                CellFocus("ProductID")
                bImportOK = False
                Exit Function
            End If
        Else
            DF = tbCol.Select("Col='ProductID'")
            If DF.Length > 0 Then
                ShowMsg("Phải chọn : " & DF(0)("Name"), m_MsgCaption)
            Else
                ShowMsg("Error", m_MsgCaption)
            End If
            bImportOK = False
            Exit Function
        End If

        Dim s_Unit As String = ""
        DF = tbCol.Select("Col='s_Unit' and isSelect=True")
        If DF.Length > 0 Then
            s_Unit = IsNull(DF(0)("ColAlias"), "")
            If s_Unit = "" Then
                ShowMsg("Chọn cột tương ứng với '" & DF(0)("Name") & "'", m_MsgCaption)
                CellFocus("s_Unit")
                bImportOK = False
                Exit Function
            End If
        Else
            DF = tbCol.Select("Col='s_Unit'")
            If DF.Length > 0 Then
                ShowMsg("Phải chọn : " & DF(0)("Name"), m_MsgCaption)
            Else
                ShowMsg("Error", m_MsgCaption)
            End If
            bImportOK = False
            Exit Function
        End If

        Dim f_Convert As String = ""
        DF = tbCol.Select("Col='f_Convert' and isSelect=True")
        If DF.Length > 0 Then
            f_Convert = IsNull(DF(0)("ColAlias"), "")
            If f_Convert = "" Then
                ShowMsg("Chọn cột tương ứng với '" & DF(0)("Name") & "'", m_MsgCaption)
                CellFocus("f_Convert")
                bImportOK = False
                Exit Function
            End If
        Else
            DF = tbCol.Select("Col='f_Convert'")
            If DF.Length > 0 Then
                ShowMsg("Phải chọn : " & DF(0)("Name"), m_MsgCaption)
            Else
                ShowMsg("Error", m_MsgCaption)
            End If
            bImportOK = False
            Exit Function
        End If

        For Each dr As UltraGridRow In Grid.Rows '26.08.09-Minh Tam
            If ProductID <> "" Then
                If IsDBNull(dr.Cells(ProductID).Value) Then
                    dr.Cells(ProductID).Appearance.BackColor = Color.Red
                    bImportOK = False
                End If
            End If
            If s_Unit <> "" Then
                If IsDBNull(dr.Cells(s_Unit).Value) Then
                    dr.Cells(s_Unit).Appearance.BackColor = Color.Red
                    bImportOK = False
                End If
            End If
            If f_Convert <> "" Then
                If IsDBNull(dr.Cells(f_Convert).Value) Then
                    dr.Cells(f_Convert).Appearance.BackColor = Color.Red
                    bImportOK = False
                End If
                If Not IsDBNull(dr.Cells(f_Convert).Value) Then
                    If CDbl(dr.Cells(f_Convert).Value) = 0 Then
                        dr.Cells(f_Convert).Appearance.BackColor = Color.Red
                        bImportOK = False
                    End If
                End If

            End If
        Next


        'Dim clsP As BLL.BProduct = BLL.BProduct.Instance

        'For i As Integer = 0 To Grid.Rows.Count - 2
        '    Dim dri As UltraGridRow = Grid.Rows(i)
        '    dri.Cells(ProductID).Value = IsNull(dri.Cells(ProductID).Value, "")
        '    dri.Cells(s_Unit).Value = IsNull(dri.Cells(s_Unit).Value, "")
        '    dri.Update()
        '    If Not IsDBNull(dri.Cells(f_Convert).Value) Then
        '        If Not IsNumeric(dri.Cells(f_Convert).Value) Then
        '            bImportOK = False
        '            dri.Cells(f_Convert).Appearance.BackColor = Color.Red
        '        Else
        '            If CDbl(dri.Cells(f_Convert).Value) <= 0 Then
        '                bImportOK = False
        '                dri.Cells(f_Convert).Appearance.BackColor = Color.Red
        '            End If
        '        End If
        '    Else
        '        bImportOK = False
        '        dri.Cells(f_Convert).Appearance.BackColor = Color.Red
        '    End If

        '    Dim s_ID As String = clsP.getCode(dri.Cells(ProductID).Value)
        '    If s_ID = "" Then
        '        bImportOK = False
        '        dri.Cells(ProductID).Appearance.BackColor = Color.Red
        '    Else
        '        dri.Cells("s_IDProduct").Value = s_ID
        '        Dim m As Model.MProduct = clsP.getInfo(s_ID)
        '        If dri.Cells(s_Unit).Value.ToString.Trim.ToLower = m.s_Unit.Trim.ToLower Then
        '            dri.Cells(s_Unit).Appearance.BackColor = Color.Red
        '            bImportOK = False
        '        End If
        '        If Not m.ArrUnit Is Nothing Then
        '            For Each it As Model.MPR_Product_Units In m.ArrUnit
        '                If dri.Cells(s_Unit).Value.ToString.Trim.ToLower = it.s_Unit.Trim.ToLower Then
        '                    dri.Cells(s_Unit).Appearance.BackColor = Color.Red
        '                    bImportOK = False
        '                End If
        '                If dri.Cells("b_Import").Value = it.b_DefaultImport And it.b_DefaultImport = True Then
        '                    dri.Cells("b_Import").Appearance.BackColor = Color.Red
        '                    bImportOK = False
        '                End If
        '                If dri.Cells("b_Order").Value = it.b_DefaultOrders And it.b_DefaultOrders = True Then
        '                    dri.Cells("b_Order").Appearance.BackColor = Color.Red
        '                    bImportOK = False
        '                End If
        '                If dri.Cells("b_Instock").Value = it.b_DefaultInstock And it.b_DefaultInstock = True Then
        '                    dri.Cells("b_Instock").Appearance.BackColor = Color.Red
        '                    bImportOK = False
        '                End If

        '            Next
        '        End If

        '        For j As Integer = i + 1 To Grid.Rows.Count - 1
        '            Dim drj As UltraGridRow = Grid.Rows(j)

        '            If j = Grid.Rows.Count - 1 Then
        '                drj.Cells(ProductID).Value = IsNull(drj.Cells(ProductID).Value, "")
        '                drj.Cells(s_Unit).Value = IsNull(drj.Cells(s_Unit).Value, "")
        '                drj.Update()
        '                If Not IsDBNull(drj.Cells(f_Convert).Value) Then
        '                    If Not IsNumeric(drj.Cells(f_Convert).Value) Then
        '                        bImportOK = False
        '                        drj.Cells(f_Convert).Appearance.BackColor = Color.Red
        '                    Else
        '                        If CDbl(drj.Cells(f_Convert).Value) <= 0 Then
        '                            bImportOK = False
        '                            drj.Cells(f_Convert).Appearance.BackColor = Color.Red
        '                        End If
        '                    End If
        '                Else
        '                    bImportOK = False
        '                    drj.Cells(f_Convert).Appearance.BackColor = Color.Red
        '                End If
        '            End If


        '            If dri.Cells(ProductID).Value.ToString.Trim.ToLower = drj.Cells(ProductID).Value.ToString.Trim.ToLower Then
        '                drj.Cells("s_IDProduct").Value = s_ID
        '                If Not m.ArrUnit Is Nothing Then
        '                    For Each it As Model.MPR_Product_Units In m.ArrUnit
        '                        If drj.Cells(s_Unit).Value.ToString.Trim.ToLower = it.s_Unit.Trim.ToLower Then
        '                            drj.Cells(s_Unit).Appearance.BackColor = Color.Red
        '                            bImportOK = False
        '                        End If
        '                        If drj.Cells("b_Import").Value = it.b_DefaultImport And it.b_DefaultImport = True Then
        '                            drj.Cells("b_Import").Appearance.BackColor = Color.Red
        '                            bImportOK = False
        '                        End If
        '                        If drj.Cells("b_Order").Value = it.b_DefaultOrders And it.b_DefaultOrders = True Then
        '                            drj.Cells("b_Order").Appearance.BackColor = Color.Red
        '                        End If
        '                        If drj.Cells("b_Instock").Value = it.b_DefaultInstock And it.b_DefaultInstock = True Then
        '                            drj.Cells("b_Instock").Appearance.BackColor = Color.Red
        '                            bImportOK = False
        '                        End If
        '                    Next
        '                End If

        '                If dri.Cells(s_Unit).Value.ToString.Trim.ToLower = drj.Cells(s_Unit).Value.ToString.Trim.ToLower Then
        '                    drj.Cells(s_Unit).Appearance.BackColor = Color.Red
        '                    bImportOK = False
        '                Else
        '                    If dri.Cells("b_Import").Value = drj.Cells("b_Import").Value And drj.Cells("b_Import").Value = True Then
        '                        drj.Cells("b_Import").Appearance.BackColor = Color.Red
        '                        bImportOK = False
        '                    End If
        '                    If dri.Cells("b_Order").Value = drj.Cells("b_Order").Value And drj.Cells("b_Order").Value = True Then
        '                        drj.Cells("b_Order").Appearance.BackColor = Color.Red
        '                        bImportOK = False
        '                    End If
        '                    If dri.Cells("b_Instock").Value = drj.Cells("b_Instock").Value And drj.Cells("b_Instock").Value = True Then
        '                        drj.Cells("b_Instock").Appearance.BackColor = Color.Red
        '                        bImportOK = False
        '                    End If

        '                End If
        '            End If
        '        Next
        '    End If
        'Next

        Return bImportOK

    End Function

    Private Function ImportUnit() As Boolean
        If Grid.DataSource Is Nothing Then
            Return False
        End If
        Dim tbCol As DataTable = GridCol.DataSource
        If tbCol Is Nothing Then
            Return False
        End If
        If Not fCheckImport Then
            CheckImportUnit()
        End If
        If Not bImportOK Then
            If MsgBox("Dữ liệu bị lỗi, có tiếp tục import không ?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                Return False
            End If
        End If

        Dim DF() As DataRow

        Dim ProductID As String = ""
        DF = tbCol.Select("Col='ProductID' and isSelect=True")
        If DF.Length > 0 Then
            ProductID = IsNull(DF(0)("ColAlias"), "")
            If ProductID = "" Then
                ShowMsg("Chọn cột tương ứng với '" & DF(0)("Name") & "'", m_MsgCaption)

                CellFocus("ProductID")
                Exit Function
            End If
        Else
            DF = tbCol.Select("Col='ProductID'")
            If DF.Length > 0 Then
                ShowMsg("Phải chọn : " & DF(0)("Name"), m_MsgCaption)
            Else
                ShowMsg("Error", m_MsgCaption)
            End If
            Exit Function
        End If

        Dim s_Unit As String = ""
        DF = tbCol.Select("Col='s_Unit' and isSelect=True")
        If DF.Length > 0 Then
            s_Unit = IsNull(DF(0)("ColAlias"), "")
            If s_Unit = "" Then
                ShowMsg("Chọn cột tương ứng với '" & DF(0)("Name") & "'", m_MsgCaption)
                CellFocus("s_Unit")
                Exit Function
            End If
        Else
            DF = tbCol.Select("Col='s_Unit'")
            If DF.Length > 0 Then
                ShowMsg("Phải chọn : " & DF(0)("Name"), m_MsgCaption)
            Else
                ShowMsg("Error", m_MsgCaption)
            End If
            Exit Function
        End If

        Dim f_Convert As String = ""
        DF = tbCol.Select("Col='f_Convert' and isSelect=True")
        If DF.Length > 0 Then
            f_Convert = IsNull(DF(0)("ColAlias"), "")
            If f_Convert = "" Then
                ShowMsg("Chọn cột tương ứng với '" & DF(0)("Name") & "'", m_MsgCaption)
                CellFocus("f_Convert")
                Exit Function
            End If
        Else
            DF = tbCol.Select("Col='f_Convert'")
            If DF.Length > 0 Then
                ShowMsg("Phải chọn : " & DF(0)("Name"), m_MsgCaption)
            Else
                ShowMsg("Error", m_MsgCaption)
            End If
            Exit Function
        End If

        'Dim clsP As BLL.BProduct = BLL.BProduct.Instance
        ''Dim clsUnit As New BLL.b
        'Dim arrUnit As IList(Of Model.MPR_Product_Units) = New List(Of Model.MPR_Product_Units)
        'For i As Integer = 0 To Grid.Rows.Count - 1

        '    Dim dri As UltraGridRow = Grid.Rows(i)
        '    If IsNull(dri.Cells("s_IDProduct").Value, "") <> "" Then
        '        If Not dri.Cells(ProductID).Appearance.BackColor.Equals(Color.Red) And _
        '        Not dri.Cells(s_Unit).Appearance.BackColor.Equals(Color.Red) And _
        '        Not dri.Cells("b_Import").Appearance.BackColor.Equals(Color.Red) And _
        '        Not dri.Cells("b_Order").Appearance.BackColor.Equals(Color.Red) And _
        '        Not dri.Cells("b_Instock").Appearance.BackColor.Equals(Color.Red) And _
        '        Not dri.Cells(f_Convert).Appearance.BackColor.Equals(Color.Red) Then

        '            If dri.Cells(f_Convert).Value <> 0 Then '26.08.09-Minh Tam
        '                Dim mUnit As New Model.MPR_Product_Units
        '                mUnit.b_DefaultImport = dri.Cells("b_Import").Value
        '                mUnit.b_DefaultInstock = dri.Cells("b_Instock").Value
        '                mUnit.b_DefaultOrders = dri.Cells("b_Order").Value
        '                mUnit.f_ConvertedQuantity = dri.Cells(f_Convert).Value
        '                mUnit.s_Unit = dri.Cells(s_Unit).Value
        '                mUnit.s_Product_ID = dri.Cells("s_IDProduct").Value
        '                arrUnit.Add(mUnit)
        '            End If

        '        End If

        '    End If

        'Next
        'If arrUnit.Count > 0 Then
        '    If Not clsP.UpdateUnit(arrUnit) Then
        '        Return False
        '    End If
        'End If
        If m_Lang = 1 Then
            ShowMsgInfo("Import được 1 dòng dữ liệu !", m_MsgCaption)
        Else
            ShowMsgInfo("OK", m_MsgCaption)
        End If

        Return True

    End Function

    Private Sub btnBrown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrown.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.Title = "Chọn file dữ liệu"
        OpenFileDialog1.Filter = "Microsoft Excel (*.xls, *.xlsx)|*.xls;*.xlsx"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.FileName = ""
        Dim dlg As DialogResult = OpenFileDialog1.ShowDialog()
        If dlg = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        If OpenFileDialog1.FileName = "" Then Exit Sub
        txtPath.Text = OpenFileDialog1.FileName

        Dim tb = Helper.ImportFromExcel(txtPath.Text)
        If tb Is Nothing Then
            Exit Sub
        End If

        Grid.DataSource = tb

        Select Case sFunc.ToLower
            Case "frmMainContractors".ToLower
                fCheckImport = False

                ShowCol(sFunc, "Grid")

                'AddCol("ProductID", "Mã hàng")
                'AddCol("f_Convert", "Quy đổi")
                ''ShowCol("", "")
                'SetColChoose("ProductID;s_Unit;f_Convert")
        End Select
    End Sub


    Private Function getTableCol(ByVal FormName As String, ByVal GridName As String) As DataTable
        'lay cau truc
        Dim sql As String = "Select * from InfoFormatGrid where [FormName]='" & FormName.Trim.Replace("'", "''") & "' and [GridName]='" & GridName.Trim.Replace("'", "''") & "' Order by [Position] asc"
        Dim tbl As DataTable = clsuf.OpenDataSetAccess(sql)
        If tbl Is Nothing Then Return Nothing
        Dim tbCol As New DataTable
        tbCol.Columns.Add("Col")
        tbCol.Columns.Add("Name")
        tbCol.Columns.Add("ColAlias")
        tbCol.Columns.Add("isSelect", GetType(Boolean))
        For Each dr As DataRow In tbl.Rows
            If dr("ColName").ToString.ToLower <> "s_ID".ToLower _
            And dr("ColName").ToString.ToLower <> "i_Ordinal".ToLower _
            And dr("ColName").ToString.ToLower <> "i_IDSort".ToLower Then
                Dim drN As DataRow = tbCol.NewRow
                drN("Col") = dr("ColName")
                drN("Name") = dr("Caption")
                drN("ColAlias") = ""
                drN("isSelect") = False
                tbCol.Rows.Add(drN)
            End If
        Next
        Return tbCol
    End Function
    Private Sub ShowCol(ByVal FormName As String, ByVal GridName As String)
        Dim tblCol As DataTable = getTableCol(FormName, GridName)
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
                End If
            Next
            GridCol.DataSource = tblCol
        End If
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub
End Class