Imports Infragistics.Win.UltraWinGrid
Imports VsoftBMS

Public Class frmImportDatas
#Region "Declare Variables"
    Private clsuf As New Ulti.ClsFormatUltraGrid
    ''' <summary>
    ''' kết quả trả về
    ''' </summary>
    ''' <remarks></remarks>
    Private result As Boolean = False
    ''' <summary>
    ''' tên chức năng
    ''' </summary>
    ''' <remarks></remarks>
    Private sFunc As String = ""
    Private funcName As String = ""
    ''' <summary>
    ''' True: import thành công
    ''' </summary>
    ''' <remarks></remarks>
    Private bImportOK As Boolean = True
    ''' <summary>
    ''' True: đã kiểm tra dữ liệu
    ''' </summary>
    ''' <remarks></remarks>
    Private fCheckImport As Boolean = False
    ''' <summary>
    ''' màu của cell bị lỗi
    ''' </summary>
    ''' <remarks></remarks>
    Private errorColor As System.Drawing.Color = Color.Red
    Private countImported As Integer = 0
#End Region

#Region "Forms"
    Public Overloads Function ShowDialog(ByVal s_Import As String, ByVal funcName As String) As Boolean
        Me.sFunc = s_Import
        Me.funcName = funcName
        Me.ShowDialog()
        Return result
    End Function

    Private Sub frmImportDatas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmImportDatas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me, "Nhập " & Me.funcName & " từ file excel")
        ModMain.BlueButton(btnImports, ModMain.m_AddIcon)
        ModMain.RedButton(btncheck, ModMain.m_OkIcon)
        ModMain.GreenButton(btnclose, ModMain.m_CancelIcon)
    End Sub
#End Region

#Region "Grid"
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

    Private Sub Grid_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles Grid.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub Grid_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles Grid.CellChange
        If e.Cell.Text <> "" AndAlso e.Cell.Appearance.BackColor.Equals(Me.errorColor) Then
            e.Cell.Appearance.BackColor = Nothing
            Me.bImportOK = True
        End If
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
#End Region

#Region "Buttons"
    Private Sub btnBrown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrown.Click
        Me.ReadExcelFile()
    End Sub
    Private Sub btncheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncheck.Click
        Select Case sFunc
            Case "frmMainContractors"
                Me.CheckImportMainContractors()
        End Select
    End Sub
    Private Sub btnImports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImports.Click
        Try
            ModMain.ShowProcess()
            Select Case sFunc
                Case "frmMainContractors"
                    result = Me.ImportMainContractors()
            End Select
            If result Then
                ShowMsgInfo("Import được " & countImported.ToString & " dòng dữ liệu !")
                Me.Close()
            End If
        Finally
            ModMain.HideProcess()
        End Try
    End Sub
    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub
#End Region

#Region "Private Methods"

    ''' <summary>
    ''' remove column which is never used
    ''' </summary>
    ''' <param name="columns"></param>
    ''' <remarks></remarks>
    Private Sub RemoveCol(ByVal columns As String)
        Dim tb As DataTable = GridCol.DataSource
        If tb Is Nothing Then Exit Sub
        Dim arrCol() As String = columns.Split(";")
        For Each col In arrCol
            If col.Trim <> "" Then
                Dim f = tb.Select("Col='" & col.Trim.Replace("'", "''") & "'")
                If f.Length > 0 Then
                    f(0).Delete()
                End If
            End If
        Next
    End Sub
    ''' <summary>
    ''' add column by manually
    ''' </summary>
    ''' <param name="colData">key of column</param>
    ''' <param name="aliasName">name of column</param>
    ''' <remarks></remarks>
    Private Sub AddCol(ByVal colData As String, ByVal aliasName As String)
        Dim tb As DataTable = GridCol.DataSource
        If tb Is Nothing Then Exit Sub

        Dim DF() As DataRow = tb.Select("Col='" & colData.Trim.Replace("'", "''") & "'")
        If DF.Length = 0 Then
            Dim drN As DataRow = tb.NewRow
            drN("Col") = colData
            drN("isSelect") = False
            drN("Name") = aliasName
            drN("ColAlias") = ""
            tb.Rows.Add(drN)
        Else
            DF(0)("Name") = aliasName
        End If
    End Sub
    ''' <summary>
    ''' set color for column if its required column
    ''' </summary>
    ''' <param name="sarrCol"></param>
    ''' <remarks></remarks>
    Private Sub SetColumnIsRequired(ByVal sarrCol As String)
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
    Private Sub CellFocus(ByVal colName As String)
        For Each r As UltraGridRow In GridCol.Rows
            If r.Cells(0).Value.ToString = colName Then
                If r.Cells(1).Value.ToString <> r.Cells(2).Value.ToString Then
                    r.Cells(2).Activate()
                    Exit For
                End If
            End If
        Next
    End Sub
    Private Function ChooseFileDialog() As String
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.Title = "Chọn file dữ liệu"
        OpenFileDialog1.Filter = "Microsoft Excel (*.xls, *.xlsx)|*.xls;*.xlsx"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.FileName = ""
        Dim dlg As DialogResult = OpenFileDialog1.ShowDialog()
        If dlg = Windows.Forms.DialogResult.Cancel Then
            Return ""
        End If
        Return OpenFileDialog1.FileName
    End Function
    Private Sub ReadExcelFile()
        Dim path = Me.ChooseFileDialog()
        If path = "" Then Exit Sub
        txtPath.Text = path
        Me.fCheckImport = False

        Dim tb = Helper.ImportFromExcel(path)
        If tb Is Nothing Then Exit Sub
        Grid.DataSource = tb

        Select Case sFunc
            Case "frmMainContractors"
                Me.ShowCol(sFunc, "Grid")
        End Select

    End Sub
    Private Sub LoadCol(ByVal formName As String, ByVal gridName As String, ByVal tbColAlias As DataTable)
        Dim tblCol As DataTable = Me.GetColumnsOfGrid(formName, gridName)
        If tbColAlias IsNot Nothing Then
            For Each dr As DataRow In tblCol.Rows
                Dim f = tbColAlias.Select("Col='" & dr("Name").ToString.Replace("'", "''") & "'")
                If f.Length > 0 Then
                    dr("ColAlias") = f(0)("Col").ToString
                    dr("isSelect") = True
                    dr.AcceptChanges()
                End If
            Next
        End If
        GridCol.DataSource = tblCol
    End Sub
    ''' <summary>
    ''' Fill các cột dữ liệu của lưới
    ''' </summary>
    ''' <param name="formName">tên form</param>
    ''' <param name="gridName">tên grid</param>
    ''' <remarks></remarks>
    Private Sub ShowCol(ByVal formName As String, ByVal gridName As String)
        Dim tbColAlias = Me.LoadColAlias()
        Me.LoadCol(formName, gridName, tbColAlias)
    End Sub
    ''' <summary>
    ''' Kiểm tra hợp lệ dữ liệu của cột
    ''' </summary>
    ''' <param name="colKey">key of column</param>
    ''' <param name="tbCol">list columns</param>
    ''' <param name="isRequired">True: column is required</param>
    ''' <returns>tên alias của cột</returns>
    ''' <remarks></remarks>
    Private Function IsSelectedRequireColumn(ByVal colKey As String, ByVal tbCol As DataTable, Optional ByVal isRequired As Boolean = False) As String
        Dim colAlias As String = ""
        If tbCol Is Nothing Then Return colAlias

        Dim found = tbCol.Select("Col='" & colKey & "'")

        ' có tồn tại cột này
        If found.Length > 0 Then
            Dim colName = found(0)("Name").ToString
            Dim isSelected = IsNull(found(0)("isSelect"), False)
            'ko chọn cột
            If Not isSelected Then
                ' mà cột này là required -> warning
                If isRequired Then
                    ShowMsg("Phải chọn cột: '" & colName & "'", m_MsgCaption)
                    Me.bImportOK = False
                    Me.CellFocus(colKey)
                End If
                Return colAlias
            End If

            ' đã chọn cột
            colAlias = IsNull(found(0)("ColAlias"), "")
            ' chưa chọn cột tương ứng -> warning
            If colAlias = "" Then
                ShowMsg("Chọn cột tương ứng với '" & colName & "'", m_MsgCaption)
                Me.bImportOK = False
                Me.CellFocus(colKey)
            End If
        End If

        Return colAlias
    End Function
    Private Function GetColumnsOfGrid(ByVal FormName As String, ByVal GridName As String) As DataTable
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
    Private Function LoadColAlias() As DataTable
        Dim tblData As DataTable = Grid.DataSource
        If tblData Is Nothing Then Return Nothing

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
        Return tbColAlias
    End Function
#End Region

#Region "MainContractors"
    Private Sub CheckImportMainContractors()
        Me.fCheckImport = True
        Me.bImportOK = True

        Grid.UpdateData()
        GridCol.UpdateData()
        Dim tb As DataTable = Grid.DataSource
        Dim tbCol As DataTable = GridCol.DataSource
        If tb Is Nothing OrElse tbCol Is Nothing Then
            Me.bImportOK = False
            Exit Sub
        End If

        Dim DF() As DataRow
        DF = tbCol.Select("isSelect=True")
        If DF.Length = 0 Then
            ShowMsg("Không có cột dữ liệu nào được chọn Import!")
            Me.bImportOK = False
            Exit Sub
        End If


        'Required
        Dim Id = Me.IsSelectedRequireColumn("Id", tbCol, True)
        If Id = "" Then
            Me.bImportOK = False
            Exit Sub
        End If
        Dim Company = Me.IsSelectedRequireColumn("Company", tbCol, True)
        If Company = "" Then
            Me.bImportOK = False
            Exit Sub
        End If

        For Each dr As UltraGridRow In Grid.Rows
            Dim mainContractorId = IsNull(dr.Cells(Id).Value, "")
            Dim mainContractorName = IsNull(dr.Cells(Company).Value, "")
            If mainContractorId = "" Then
                dr.Cells(Id).Appearance.BackColor = Me.errorColor
                Me.bImportOK = False
            End If
            If mainContractorName = "" Then
                dr.Cells(Company).Appearance.BackColor = Me.errorColor
                Me.bImportOK = False
            End If
        Next

        If Me.bImportOK Then
            ShowMsgInfo("Thông tin import hợp lệ!")
        Else
            ShowMsg("Dữ liệu không hợp lệ.")
        End If
    End Sub

    Private Function ImportMainContractors() As Boolean
        If Grid.DataSource Is Nothing OrElse GridCol.DataSource Is Nothing Then
            Return False
        End If

        If Not Me.fCheckImport Then
            Me.CheckImportMainContractors()
        End If

        If Not Me.bImportOK Then
            If ShowMsgYesNo(ModMain.m_DataErrorWarningQuestion) = Windows.Forms.DialogResult.No Then
                Return False
            End If
        End If

        'Kiểm tra alias column có chọn chưa
        GridCol.UpdateData()
        Dim tbCol As DataTable = GridCol.DataSource

        'Required and get alias column
        Dim Id = Me.IsSelectedRequireColumn("Id", tbCol, True)
        If Id = "" Then Return False
        Dim Company = Me.IsSelectedRequireColumn("Company", tbCol, True)
        If Company = "" Then Return False

        'Not required
        Dim ShortName = Me.IsSelectedRequireColumn("ShortName", tbCol)
        Dim Address = Me.IsSelectedRequireColumn("Address", tbCol)
        Dim Phone = Me.IsSelectedRequireColumn("Phone", tbCol)
        Dim Email = Me.IsSelectedRequireColumn("Email", tbCol)
        Dim Website = Me.IsSelectedRequireColumn("Website", tbCol)
        Dim ContactName = Me.IsSelectedRequireColumn("ContactName", tbCol)
        Dim ContactPhone = Me.IsSelectedRequireColumn("ContactPhone", tbCol)
        Dim ContactEmail = Me.IsSelectedRequireColumn("ContactEmail", tbCol)
        Dim Note = Me.IsSelectedRequireColumn("Note", tbCol)

        countImported = 0
        Dim bMain As BLL.BMainContractors = BLL.BMainContractors.Instance
        Grid.UpdateData()
        For Each dr As UltraGridRow In Grid.Rows
            Dim mainContractorId = IsNull(dr.Cells(Id).Value, "")
            Dim mainContractorName = IsNull(dr.Cells(Company).Value, "")

            'if required collumn is empty -> ignore this row
            If mainContractorId <> "" AndAlso mainContractorName <> "" Then
                If Not dr.Cells(Id).Appearance.BackColor.Equals(errorColor) _
                    AndAlso Not dr.Cells(Company).Appearance.BackColor.Equals(errorColor) Then

                    Dim m As New Model.MMainContractor
                    m.Id = mainContractorId
                    m.Company = mainContractorName
                    If ShortName <> "" Then m.ShortName = IsNull(dr.Cells(ShortName).Value, "")
                    If Address <> "" Then m.Address = IsNull(dr.Cells(Address).Value, "")
                    If Phone <> "" Then m.Phone = IsNull(dr.Cells(Phone).Value, "")
                    If Email <> "" Then m.Email = IsNull(dr.Cells(Email).Value, "")
                    If Website <> "" Then m.Website = IsNull(dr.Cells(Website).Value, "")
                    If ContactName <> "" Then m.ContactName = IsNull(dr.Cells(ContactName).Value, "")
                    If ContactPhone <> "" Then m.ContactPhone = IsNull(dr.Cells(ContactPhone).Value, "")
                    If ContactEmail <> "" Then m.ContactEmail = IsNull(dr.Cells(ContactEmail).Value, "")
                    If Note <> "" Then m.Note = IsNull(dr.Cells(Note).Value, "")

                    'save to db
                    If bMain.updateDB(m) Then
                        countImported += 1
                    End If
                End If
            End If
        Next

        Return countImported > 0
    End Function
#End Region
End Class