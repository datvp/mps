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
    Dim tbBegin As DataTable = Nothing

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
        ModMain.SetTitle(Me, "Nhập " & Me.funcName & " từ Excel")
        ModMain.BlueButton(btnImports, ModMain.m_AddIcon)
        ModMain.RedButton(btncheck, ModMain.m_OkIcon)
        ModMain.GreenButton(btnclose, ModMain.m_CancelIcon)
        ModMain.GreenButton(btnExportExcel)
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
            Case "frmClientGroups"
                Me.CheckImportClientGroups()
            Case "frmClients"
                Me.CheckImportClients()
            Case "frmConstructionLevels"
                Me.CheckImportConstructionLevels()
            Case "frmItems"
                Me.CheckImportItems()
            Case "frmProjects"
                Me.CheckImportProjects()
            Case "frmProjectTypes"
                Me.CheckImportProjectTypes()
            Case "frmSubContractors"
                Me.CheckImportSubContractors()
            Case "frmUnited"
                Me.CheckImportUniteds()
        End Select
        If Me.bImportOK Then
            ShowMsgInfo(ModMain.m_DataValid)
        End If
    End Sub
    Private Sub btnImports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImports.Click
        Select Case sFunc
            Case "frmMainContractors"
                result = Me.ImportMainContractors()
            Case "frmClientGroups"
                result = Me.ImportClientGroups()
            Case "frmClients"
                result = Me.ImportClients()
            Case "frmConstructionLevels"
                result = Me.ImportConstructionLevels()
            Case "frmItems"
                result = Me.ImportItems()
            Case "frmProjects"
                result = Me.ImportProjects()
            Case "frmProjectTypes"
                result = Me.ImportProjectTypes()
            Case "frmSubContractors"
                result = Me.ImportSubContractors()
            Case "frmUnited"
                result = Me.ImportUniteds()
        End Select
        If result Then
            ShowMsgInfo("Import được " & countImported.ToString & " dòng dữ liệu !")
            'rows imported are failure
            If countImported < Grid.Rows.Count Then
                'filter and show rows are error.
                Grid.DataSource = tbBegin.Copy
            Else ' import all successfully
                Me.Close()
            End If
        End If
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
    ''' <param name="columns">các cột bắt buộc cách nhau bởi dấu phẩy</param>
    ''' <remarks></remarks>
    Private Sub SetColumnIsRequired(ByVal columns As String)
        If GridCol.DataSource Is Nothing Then Exit Sub
        Dim arrColumns() As String = columns.Split(",")
        For Each s As String In arrColumns
            If s <> "" Then
                For Each r As UltraGridRow In GridCol.Rows
                    If r.Cells("Col").Value.ToString.ToLower = s.ToLower Then
                        r.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                        r.Appearance.ForeColor = Color.Maroon
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
        Me.tbBegin = tb.Copy
        Grid.DataSource = tb

        Me.ShowCol(sFunc, "Grid")
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
        'set color for the required columns
        Select Case sFunc
            Case "frmMainContractors"
                Me.SetColumnIsRequired("Id,Company")
            Case "frmClientGroups"
                Me.SetColumnIsRequired("ClientGroupId,ClientGroupName")
            Case "frmClients"
                Me.SetColumnIsRequired("ClientId,ClientName,ClientGroupId")
            Case "frmConstructionLevels"
                Me.SetColumnIsRequired("ConstructionLevelId,ConstructionLevelName")
            Case "frmItems"
                Me.SetColumnIsRequired("ItemId,ItemName")
            Case "frmProjects"
                Me.SetColumnIsRequired("ProjectId,ProjectName,ProjectTypeId,ProjectGroupId,ConstructionLevelId,ClientId")
            Case "frmProjectTypes"
                Me.SetColumnIsRequired("ProjectTypeId,ProjectTypeName")
            Case "frmSubContractors"
                Me.SetColumnIsRequired("SubContractorId,SubContractorName")
            Case "frmUnited"
                Me.SetColumnIsRequired("UnitedId,UnitedName")
        End Select
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
    Private Sub UpdateDataAfterImport(ByVal colName As String, ByVal colVal As String)
        If tbBegin Is Nothing Then Exit Sub
        Dim f = tbBegin.Select(colName & "='" & colVal & "'")
        If f IsNot Nothing AndAlso f.Length > 0 Then
            f(0).Delete()
        End If
    End Sub
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
            ShowMsg(ModMain.m_NoSelectedItemToImport)
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

        If Not Me.bImportOK Then
            ShowMsg(ModMain.m_DataInvalid)
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

            'if required collumn is empty or red -> ignore this row
            If mainContractorId = "" Then Continue For
            If mainContractorName = "" Then Continue For
            If dr.Cells(Id).Appearance.BackColor.Equals(errorColor) Then Continue For
            If dr.Cells(Company).Appearance.BackColor.Equals(errorColor) Then Continue For

            'init model
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
                'remove row into tbBegin which imported successfully
                Me.UpdateDataAfterImport(Id, mainContractorId)
            End If
        Next

        Return countImported > 0
    End Function
#End Region
#Region "ClientGroups"
    Private Sub CheckImportClientGroups()
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
            ShowMsg(ModMain.m_NoSelectedItemToImport)
            Me.bImportOK = False
            Exit Sub
        End If


        'Required
        Dim ClientGroupId = Me.IsSelectedRequireColumn("ClientGroupId", tbCol, True)
        If ClientGroupId = "" Then
            Me.bImportOK = False
            Exit Sub
        End If
        Dim ClientGroupName = Me.IsSelectedRequireColumn("ClientGroupName", tbCol, True)
        If ClientGroupName = "" Then
            Me.bImportOK = False
            Exit Sub
        End If

        For Each dr As UltraGridRow In Grid.Rows
            Dim code = IsNull(dr.Cells(ClientGroupId).Value, "")
            Dim name = IsNull(dr.Cells(ClientGroupName).Value, "")
            If code = "" Then
                dr.Cells(ClientGroupId).Appearance.BackColor = Me.errorColor
                Me.bImportOK = False
            End If
            If name = "" Then
                dr.Cells(ClientGroupName).Appearance.BackColor = Me.errorColor
                Me.bImportOK = False
            End If
        Next

        If Not Me.bImportOK Then
            ShowMsg(ModMain.m_DataInvalid)
        End If
    End Sub

    Private Function ImportClientGroups() As Boolean
        If Grid.DataSource Is Nothing OrElse GridCol.DataSource Is Nothing Then
            Return False
        End If

        If Not Me.fCheckImport Then
            Me.CheckImportClientGroups()
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
        Dim ClientGroupId = Me.IsSelectedRequireColumn("ClientGroupId", tbCol, True)
        If ClientGroupId = "" Then Return False
        Dim ClientGroupName = Me.IsSelectedRequireColumn("ClientGroupName", tbCol, True)
        If ClientGroupName = "" Then Return False

        'Not required
        Dim Note = Me.IsSelectedRequireColumn("Note", tbCol)

        countImported = 0
        Dim b As BLL.BClientGroups = BLL.BClientGroups.Instance
        Grid.UpdateData()
        For Each dr As UltraGridRow In Grid.Rows
            Dim code = IsNull(dr.Cells(ClientGroupId).Value, "")
            Dim name = IsNull(dr.Cells(ClientGroupName).Value, "")

            'if required collumn is empty -> ignore this row
            If code <> "" AndAlso name <> "" Then
                If Not dr.Cells(ClientGroupId).Appearance.BackColor.Equals(errorColor) _
                    AndAlso Not dr.Cells(ClientGroupName).Appearance.BackColor.Equals(errorColor) Then

                    Dim m As New Model.MClientGroup
                    m.ClientGroupId = code
                    m.ClientGroupName = name
                    If Note <> "" Then m.Note = IsNull(dr.Cells(Note).Value, "")

                    'save to db
                    If b.updateDB(m) Then
                        countImported += 1
                        'remove row into tbBegin which imported successfully
                        Me.UpdateDataAfterImport(ClientGroupId, code)
                    End If
                End If
            End If
        Next

        Return countImported > 0
    End Function
#End Region
#Region "Clients"
    Private Sub CheckImportClients()
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
            ShowMsg(ModMain.m_NoSelectedItemToImport)
            Me.bImportOK = False
            Exit Sub
        End If


        'Required
        Dim ClientId = Me.IsSelectedRequireColumn("ClientId", tbCol, True)
        If ClientId = "" Then
            Me.bImportOK = False
            Exit Sub
        End If
        Dim ClientName = Me.IsSelectedRequireColumn("ClientName", tbCol, True)
        If ClientName = "" Then
            Me.bImportOK = False
            Exit Sub
        End If
        Dim ClientGroupId = Me.IsSelectedRequireColumn("ClientGroupId", tbCol, True)
        If ClientGroupId = "" Then
            Me.bImportOK = False
            Exit Sub
        End If

        Dim bGroup As BLL.BClientGroups = BLL.BClientGroups.Instance

        For Each dr As UltraGridRow In Grid.Rows
            Dim code = IsNull(dr.Cells(ClientId).Value, "")
            Dim name = IsNull(dr.Cells(ClientName).Value, "")
            Dim group = IsNull(dr.Cells(ClientGroupId).Value, "")
            If code = "" Then
                dr.Cells(ClientId).Appearance.BackColor = Me.errorColor
                Me.bImportOK = False
            End If
            If name = "" Then
                dr.Cells(ClientName).Appearance.BackColor = Me.errorColor
                Me.bImportOK = False
            End If
            If group = "" OrElse Not bGroup.isExist(group) Then
                dr.Cells(ClientGroupId).Appearance.BackColor = Me.errorColor
                Me.bImportOK = False
            End If
        Next

        If Not Me.bImportOK Then
            ShowMsg(ModMain.m_DataInvalid)
        End If
    End Sub

    Private Function ImportClients() As Boolean
        If Grid.DataSource Is Nothing OrElse GridCol.DataSource Is Nothing Then
            Return False
        End If

        If Not Me.fCheckImport Then
            Me.CheckImportClients()
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
        Dim ClientId = Me.IsSelectedRequireColumn("ClientId", tbCol, True)
        If ClientId = "" Then Return False
        Dim ClientName = Me.IsSelectedRequireColumn("ClientName", tbCol, True)
        If ClientName = "" Then Return False
        Dim ClientGroupId = Me.IsSelectedRequireColumn("ClientGroupId", tbCol, True)
        If ClientGroupId = "" Then Return False

        'Not required
        Dim UnitedId = Me.IsSelectedRequireColumn("UnitedId", tbCol, True)
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
        Dim b As BLL.BClients = BLL.BClients.Instance
        Dim bGroup As BLL.BClientGroups = BLL.BClientGroups.Instance
        Grid.UpdateData()
        For Each dr As UltraGridRow In Grid.Rows
            Dim code = IsNull(dr.Cells(ClientId).Value, "")
            Dim name = IsNull(dr.Cells(ClientName).Value, "")
            Dim group = IsNull(dr.Cells(ClientGroupId).Value, "")

            'if required collumn is empty -> ignore this row
            If code = "" Then Continue For
            If name = "" Then Continue For
            If group = "" OrElse Not bGroup.isExist(group) Then Continue For

            If Not dr.Cells(ClientId).Appearance.BackColor.Equals(errorColor) Then Continue For
            If Not dr.Cells(ClientName).Appearance.BackColor.Equals(errorColor) Then Continue For
            If Not dr.Cells(ClientGroupId).Appearance.BackColor.Equals(errorColor) Then Continue For

            Dim m As New Model.MClient
            m.ClientId = code
            m.ClientName = name
            m.ClientGroupId = group
            If UnitedId <> "" Then m.UnitedId = IsNull(dr.Cells(UnitedId).Value, "")
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
            If b.updateDB(m) Then
                countImported += 1
                'remove row into tbBegin which imported successfully
                Me.UpdateDataAfterImport(ClientId, code)
            End If
        Next

        Return countImported > 0
    End Function
#End Region
#Region "ConstructionLevels"
    Private Sub CheckImportConstructionLevels()
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
            ShowMsg(ModMain.m_NoSelectedItemToImport)
            Me.bImportOK = False
            Exit Sub
        End If


        'Required
        Dim ConstructionLevelId = Me.IsSelectedRequireColumn("ConstructionLevelId", tbCol, True)
        If ConstructionLevelId = "" Then
            Me.bImportOK = False
            Exit Sub
        End If
        Dim ConstructionLevelName = Me.IsSelectedRequireColumn("ConstructionLevelName", tbCol, True)
        If ConstructionLevelName = "" Then
            Me.bImportOK = False
            Exit Sub
        End If

        For Each dr As UltraGridRow In Grid.Rows
            Dim code = IsNull(dr.Cells(ConstructionLevelId).Value, "")
            Dim name = IsNull(dr.Cells(ConstructionLevelName).Value, "")
            If code = "" Then
                dr.Cells(ConstructionLevelId).Appearance.BackColor = Me.errorColor
                Me.bImportOK = False
            End If
            If name = "" Then
                dr.Cells(ConstructionLevelName).Appearance.BackColor = Me.errorColor
                Me.bImportOK = False
            End If
        Next

        If Not Me.bImportOK Then
            ShowMsg(ModMain.m_DataInvalid)
        End If
    End Sub

    Private Function ImportConstructionLevels() As Boolean
        If Grid.DataSource Is Nothing OrElse GridCol.DataSource Is Nothing Then
            Return False
        End If

        If Not Me.fCheckImport Then
            Me.CheckImportConstructionLevels()
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
        Dim ConstructionLevelId = Me.IsSelectedRequireColumn("ConstructionLevelId", tbCol, True)
        If ConstructionLevelId = "" Then Return False
        Dim ConstructionLevelName = Me.IsSelectedRequireColumn("ConstructionLevelName", tbCol, True)
        If ConstructionLevelName = "" Then Return False

        'Not required
        Dim Note = Me.IsSelectedRequireColumn("Note", tbCol)

        countImported = 0
        Dim b As BLL.BConstructionLevels = BLL.BConstructionLevels.Instance
        Grid.UpdateData()
        For Each dr As UltraGridRow In Grid.Rows
            Dim code = IsNull(dr.Cells(ConstructionLevelId).Value, "")
            Dim name = IsNull(dr.Cells(ConstructionLevelName).Value, "")

            'if required collumn is empty -> ignore this row
            If code <> "" AndAlso name <> "" Then
                If Not dr.Cells(ConstructionLevelId).Appearance.BackColor.Equals(errorColor) _
                    AndAlso Not dr.Cells(ConstructionLevelName).Appearance.BackColor.Equals(errorColor) Then

                    Dim m As New Model.MConstructionLevel
                    m.ConstructionLevelId = code
                    m.ConstructionLevelName = name
                    If Note <> "" Then m.Note = IsNull(dr.Cells(Note).Value, "")

                    'save to db
                    If b.updateDB(m) Then
                        countImported += 1
                        'remove row into tbBegin which imported successfully
                        Me.UpdateDataAfterImport(ConstructionLevelId, code)
                    End If
                End If
            End If
        Next

        Return countImported > 0
    End Function
#End Region
#Region "Items"
    Private Sub CheckImportItems()
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
            ShowMsg(ModMain.m_NoSelectedItemToImport)
            Me.bImportOK = False
            Exit Sub
        End If


        'Required
        Dim ItemId = Me.IsSelectedRequireColumn("ItemId", tbCol, True)
        If ItemId = "" Then
            Me.bImportOK = False
            Exit Sub
        End If
        Dim ItemName = Me.IsSelectedRequireColumn("ItemName", tbCol, True)
        If ItemName = "" Then
            Me.bImportOK = False
            Exit Sub
        End If

        For Each dr As UltraGridRow In Grid.Rows
            Dim code = IsNull(dr.Cells(ItemId).Value, "")
            Dim name = IsNull(dr.Cells(ItemName).Value, "")
            If code = "" Then
                dr.Cells(ItemId).Appearance.BackColor = Me.errorColor
                Me.bImportOK = False
            End If
            If name = "" Then
                dr.Cells(ItemName).Appearance.BackColor = Me.errorColor
                Me.bImportOK = False
            End If
        Next

        If Not Me.bImportOK Then
            ShowMsg(ModMain.m_DataInvalid)
        End If
    End Sub

    Private Function ImportItems() As Boolean
        If Grid.DataSource Is Nothing OrElse GridCol.DataSource Is Nothing Then
            Return False
        End If

        If Not Me.fCheckImport Then
            Me.CheckImportItems()
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
        Dim ItemId = Me.IsSelectedRequireColumn("ItemId", tbCol, True)
        If ItemId = "" Then Return False
        Dim ItemName = Me.IsSelectedRequireColumn("ItemName", tbCol, True)
        If ItemName = "" Then Return False

        'Not required
        Dim Note = Me.IsSelectedRequireColumn("Note", tbCol)

        countImported = 0
        Dim b As BLL.BItems = BLL.BItems.Instance
        Grid.UpdateData()
        For Each dr As UltraGridRow In Grid.Rows
            Dim code = IsNull(dr.Cells(ItemId).Value, "")
            Dim name = IsNull(dr.Cells(ItemName).Value, "")

            'if required collumn is empty -> ignore this row
            If code <> "" AndAlso name <> "" Then
                If Not dr.Cells(ItemId).Appearance.BackColor.Equals(errorColor) _
                    AndAlso Not dr.Cells(ItemName).Appearance.BackColor.Equals(errorColor) Then

                    Dim m As New Model.MItem
                    m.ItemId = code
                    m.ItemName = name
                    If Note <> "" Then m.Note = IsNull(dr.Cells(Note).Value, "")

                    'save to db
                    If b.updateDB(m) Then
                        countImported += 1
                        'remove row into tbBegin which imported successfully
                        Me.UpdateDataAfterImport(ItemId, code)
                    End If
                End If
            End If
        Next

        Return countImported > 0
    End Function
#End Region
#Region "Projects"
    Private Sub CheckImportProjects()
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
            ShowMsg(ModMain.m_NoSelectedItemToImport)
            Me.bImportOK = False
            Exit Sub
        End If


        'Required
        Dim ProjectId = Me.IsSelectedRequireColumn("ProjectId", tbCol, True)
        If ProjectId = "" Then
            Me.bImportOK = False
            Exit Sub
        End If
        Dim ProjectName = Me.IsSelectedRequireColumn("ProjectName", tbCol, True)
        If ProjectName = "" Then
            Me.bImportOK = False
            Exit Sub
        End If
        Dim ProjectTypeId = Me.IsSelectedRequireColumn("ProjectTypeId", tbCol, True)
        If ProjectTypeId = "" Then
            Me.bImportOK = False
            Exit Sub
        End If
        Dim ProjectGroupId = Me.IsSelectedRequireColumn("ProjectGroupId", tbCol, True)
        If ProjectGroupId = "" Then
            Me.bImportOK = False
            Exit Sub
        End If
        Dim ConstructionLevelId = Me.IsSelectedRequireColumn("ConstructionLevelId", tbCol, True)
        If ConstructionLevelId = "" Then
            Me.bImportOK = False
            Exit Sub
        End If
        Dim ClientId = Me.IsSelectedRequireColumn("ClientId", tbCol, True)
        If ClientId = "" Then
            Me.bImportOK = False
            Exit Sub
        End If

        Dim bGroup As BLL.BProjects = BLL.BProjects.Instance
        Dim bType As BLL.BProjectTypes = BLL.BProjectTypes.Instance
        Dim bConsLevel As BLL.BConstructionLevels = BLL.BConstructionLevels.Instance
        Dim bClient As BLL.BClients = BLL.BClients.Instance

        For Each dr As UltraGridRow In Grid.Rows
            Dim code = IsNull(dr.Cells(ProjectId).Value, "")
            If code = "" Then
                dr.Cells(ProjectId).Appearance.BackColor = Me.errorColor
                Me.bImportOK = False
            End If

            Dim name = IsNull(dr.Cells(ProjectName).Value, "")
            If name = "" Then
                dr.Cells(ProjectName).Appearance.BackColor = Me.errorColor
                Me.bImportOK = False
            End If

            Dim projType = IsNull(dr.Cells(ProjectTypeId).Value, "")
            If projType = "" OrElse Not bType.isExist(projType) Then
                dr.Cells(ProjectTypeId).Appearance.BackColor = Me.errorColor
                Me.bImportOK = False
            End If

            Dim projGroup = IsNull(dr.Cells(ProjectGroupId).Value, "")
            If projGroup = "" OrElse Not bGroup.isExistGroup(projGroup) Then
                dr.Cells(ProjectGroupId).Appearance.BackColor = Me.errorColor
                Me.bImportOK = False
            End If

            Dim consLevel = IsNull(dr.Cells(ConstructionLevelId).Value, "")
            If consLevel = "" OrElse Not bConsLevel.isExist(consLevel) Then
                dr.Cells(ConstructionLevelId).Appearance.BackColor = Me.errorColor
                Me.bImportOK = False
            End If

            Dim client = IsNull(dr.Cells(ClientId).Value, "")
            If client = "" OrElse Not bClient.isExist(client) Then
                dr.Cells(ClientId).Appearance.BackColor = Me.errorColor
                Me.bImportOK = False
            End If
        Next

        If Not Me.bImportOK Then
            ShowMsg(ModMain.m_DataInvalid)
        End If
    End Sub

    Private Function ImportProjects() As Boolean
        If Grid.DataSource Is Nothing OrElse GridCol.DataSource Is Nothing Then
            Return False
        End If

        If Not Me.fCheckImport Then
            Me.CheckImportProjects()
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
        Dim ProjectId = Me.IsSelectedRequireColumn("ProjectId", tbCol, True)
        If ProjectId = "" Then
            Return False
        End If
        Dim ProjectName = Me.IsSelectedRequireColumn("ProjectName", tbCol, True)
        If ProjectName = "" Then
            Return False
        End If
        Dim ProjectTypeId = Me.IsSelectedRequireColumn("ProjectTypeId", tbCol, True)
        If ProjectTypeId = "" Then
            Return False
        End If
        Dim ProjectGroupId = Me.IsSelectedRequireColumn("ProjectGroupId", tbCol, True)
        If ProjectGroupId = "" Then
            Exit Function
        End If
        Dim ConstructionLevelId = Me.IsSelectedRequireColumn("ConstructionLevelId", tbCol, True)
        If ConstructionLevelId = "" Then
            Return False
        End If
        Dim ClientId = Me.IsSelectedRequireColumn("ClientId", tbCol, True)
        If ClientId = "" Then
            Return False
        End If


        'Not required
        Dim Performance = Me.IsSelectedRequireColumn("Performance", tbCol)
        Dim Length = Me.IsSelectedRequireColumn("Length", tbCol)
        Dim PerformanceUnit = Me.IsSelectedRequireColumn("PerformanceUnit", tbCol)
        Dim LengthUnit = Me.IsSelectedRequireColumn("LengthUnit", tbCol)
        Dim Note = Me.IsSelectedRequireColumn("Note", tbCol)

        countImported = 0

        Dim b As BLL.BProjects = BLL.BProjects.Instance
        Dim bType As BLL.BProjectTypes = BLL.BProjectTypes.Instance
        Dim bConsLevel As BLL.BConstructionLevels = BLL.BConstructionLevels.Instance
        Dim bClient As BLL.BClients = BLL.BClients.Instance

        Grid.UpdateData()
        For Each dr As UltraGridRow In Grid.Rows
            Dim code = IsNull(dr.Cells(ProjectId).Value, "")
            Dim name = IsNull(dr.Cells(ProjectName).Value, "")
            Dim projType = IsNull(dr.Cells(ProjectTypeId).Value, "")
            Dim projGroup = IsNull(dr.Cells(ProjectGroupId).Value, "")
            Dim consLevel = IsNull(dr.Cells(ConstructionLevelId).Value, "")
            Dim client = IsNull(dr.Cells(ClientId).Value, "")

            'if required collumn is empty or red -> ignore this row
            If code = "" Then Continue For
            If name = "" Then Continue For
            If projType = "" OrElse Not bType.isExist(projType) Then Continue For
            If projGroup = "" OrElse Not b.isExistGroup(projGroup) Then Continue For
            If consLevel = "" OrElse Not bConsLevel.isExist(consLevel) Then Continue For
            If client = "" OrElse Not bClient.isExist(client) Then Continue For

            If dr.Cells(ProjectId).Appearance.BackColor.Equals(errorColor) Then Continue For
            If dr.Cells(ProjectName).Appearance.BackColor.Equals(errorColor) Then Continue For
            If dr.Cells(ProjectTypeId).Appearance.BackColor.Equals(errorColor) Then Continue For
            If dr.Cells(ProjectGroupId).Appearance.BackColor.Equals(errorColor) Then Continue For
            If dr.Cells(ConstructionLevelId).Appearance.BackColor.Equals(errorColor) Then Continue For
            If dr.Cells(ClientId).Appearance.BackColor.Equals(errorColor) Then Continue For

            'init new a project
            Dim m As New Model.MProject
            m.ProjectId = code
            m.ProjectName = name
            m.ProjectTypeId = projType
            m.ProjectGroupId = projGroup
            m.ConstructionLevelId = consLevel
            m.ClientId = client
            m.BranchId = ModMain.m_BranchId
            If Performance <> "" Then m.Performance = IsNull(dr.Cells(Performance).Value, "")
            If Length <> "" Then m.Length = IsNull(dr.Cells(Length).Value, "")
            If PerformanceUnit <> "" Then m.PerformanceUnit = IsNull(dr.Cells(PerformanceUnit).Value, "")
            If LengthUnit <> "" Then m.LengthUnit = IsNull(dr.Cells(LengthUnit).Value, "")
            If Note <> "" Then m.Note = IsNull(dr.Cells(Note).Value, "")

            'save to db
            If b.updateDB(m) Then
                countImported += 1
                'remove row into tbBegin which imported successfully
                Me.UpdateDataAfterImport(ProjectId, code)
            End If
        Next

        Return countImported > 0
    End Function
#End Region
#Region "ProjectTypes"
    Private Sub CheckImportProjectTypes()
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
            ShowMsg(ModMain.m_NoSelectedItemToImport)
            Me.bImportOK = False
            Exit Sub
        End If


        'Required
        Dim ProjectTypeId = Me.IsSelectedRequireColumn("ProjectTypeId", tbCol, True)
        If ProjectTypeId = "" Then
            Me.bImportOK = False
            Exit Sub
        End If
        Dim ProjectTypeName = Me.IsSelectedRequireColumn("ProjectTypeName", tbCol, True)
        If ProjectTypeName = "" Then
            Me.bImportOK = False
            Exit Sub
        End If

        For Each dr As UltraGridRow In Grid.Rows
            Dim code = IsNull(dr.Cells(ProjectTypeId).Value, "")
            Dim name = IsNull(dr.Cells(ProjectTypeName).Value, "")
            If code = "" Then
                dr.Cells(ProjectTypeId).Appearance.BackColor = Me.errorColor
                Me.bImportOK = False
            End If
            If name = "" Then
                dr.Cells(ProjectTypeName).Appearance.BackColor = Me.errorColor
                Me.bImportOK = False
            End If
        Next

        If Not Me.bImportOK Then
            ShowMsg(ModMain.m_DataInvalid)
        End If
    End Sub

    Private Function ImportProjectTypes() As Boolean
        If Grid.DataSource Is Nothing OrElse GridCol.DataSource Is Nothing Then
            Return False
        End If

        If Not Me.fCheckImport Then
            Me.CheckImportProjectTypes()
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
        Dim ProjectTypeId = Me.IsSelectedRequireColumn("ProjectTypeId", tbCol, True)
        If ProjectTypeId = "" Then Return False
        Dim ProjectTypeName = Me.IsSelectedRequireColumn("ProjectTypeName", tbCol, True)
        If ProjectTypeName = "" Then Return False

        'Not required
        Dim Note = Me.IsSelectedRequireColumn("Note", tbCol)

        countImported = 0
        Dim b As BLL.BProjectTypes = BLL.BProjectTypes.Instance
        Grid.UpdateData()
        For Each dr As UltraGridRow In Grid.Rows
            Dim code = IsNull(dr.Cells(ProjectTypeId).Value, "")
            Dim name = IsNull(dr.Cells(ProjectTypeName).Value, "")

            'if required collumn is empty -> ignore this row
            If code = "" Then Continue For
            If name = "" Then Continue For
            If dr.Cells(ProjectTypeId).Appearance.BackColor.Equals(errorColor) Then Continue For
            If dr.Cells(ProjectTypeName).Appearance.BackColor.Equals(errorColor) Then Continue For

            'init model
            Dim m As New Model.MProjectType
            m.ProjectTypeId = code
            m.ProjectTypeName = name
            If Note <> "" Then m.Note = IsNull(dr.Cells(Note).Value, "")

            'save to db
            If b.updateDB(m) Then
                countImported += 1
                'remove row into tbBegin which imported successfully
                Me.UpdateDataAfterImport(ProjectTypeId, code)
            End If
        Next

        Return countImported > 0
    End Function
#End Region
#Region "SubContractors"
    Private Sub CheckImportSubContractors()
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
            ShowMsg(ModMain.m_NoSelectedItemToImport)
            Me.bImportOK = False
            Exit Sub
        End If


        'Required
        Dim SubContractorId = Me.IsSelectedRequireColumn("SubContractorId", tbCol, True)
        If SubContractorId = "" Then
            Me.bImportOK = False
            Exit Sub
        End If
        Dim SubContractorName = Me.IsSelectedRequireColumn("SubContractorName", tbCol, True)
        If SubContractorName = "" Then
            Me.bImportOK = False
            Exit Sub
        End If

        For Each dr As UltraGridRow In Grid.Rows
            Dim code = IsNull(dr.Cells(SubContractorId).Value, "")
            Dim name = IsNull(dr.Cells(SubContractorName).Value, "")
            If code = "" Then
                dr.Cells(SubContractorId).Appearance.BackColor = Me.errorColor
                Me.bImportOK = False
            End If
            If name = "" Then
                dr.Cells(SubContractorName).Appearance.BackColor = Me.errorColor
                Me.bImportOK = False
            End If
        Next

        If Not Me.bImportOK Then
            ShowMsg(ModMain.m_DataInvalid)
        End If
    End Sub

    Private Function ImportSubContractors() As Boolean
        If Grid.DataSource Is Nothing OrElse GridCol.DataSource Is Nothing Then
            Return False
        End If

        If Not Me.fCheckImport Then
            Me.CheckImportSubContractors()
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
        Dim SubContractorId = Me.IsSelectedRequireColumn("SubContractorId", tbCol, True)
        If SubContractorId = "" Then Return False
        Dim SubContractorName = Me.IsSelectedRequireColumn("SubContractorName", tbCol, True)
        If SubContractorName = "" Then Return False

        'Not required
        Dim ShortName = Me.IsSelectedRequireColumn("ShortName", tbCol)
        Dim Address = Me.IsSelectedRequireColumn("Address", tbCol)
        Dim Phone = Me.IsSelectedRequireColumn("Phone", tbCol)
        Dim Email = Me.IsSelectedRequireColumn("Email", tbCol)
        Dim ContactName = Me.IsSelectedRequireColumn("ContactName", tbCol)
        Dim ContactPhone = Me.IsSelectedRequireColumn("ContactPhone", tbCol)
        Dim ContactEmail = Me.IsSelectedRequireColumn("ContactEmail", tbCol)
        Dim Note = Me.IsSelectedRequireColumn("Note", tbCol)

        countImported = 0
        Dim b As BLL.BSubContractors = BLL.BSubContractors.Instance
        Grid.UpdateData()
        For Each dr As UltraGridRow In Grid.Rows
            Dim code = IsNull(dr.Cells(SubContractorId).Value, "")
            Dim name = IsNull(dr.Cells(SubContractorName).Value, "")

            'if required collumn is empty -> ignore this row
            If code = "" Then Continue For
            If name = "" Then Continue For
            If dr.Cells(SubContractorId).Appearance.BackColor.Equals(errorColor) Then Continue For
            If dr.Cells(SubContractorName).Appearance.BackColor.Equals(errorColor) Then Continue For

            'init model
            Dim m As New Model.MSubContractor
            m.SubContractorId = code
            m.SubContractorName = name
            If ShortName <> "" Then m.ShortName = IsNull(dr.Cells(ShortName).Value, "")
            If Address <> "" Then m.Address = IsNull(dr.Cells(Address).Value, "")
            If Phone <> "" Then m.Phone = IsNull(dr.Cells(Phone).Value, "")
            If Email <> "" Then m.Email = IsNull(dr.Cells(Email).Value, "")
            If ContactName <> "" Then m.ContactName = IsNull(dr.Cells(ContactName).Value, "")
            If ContactPhone <> "" Then m.ContactPhone = IsNull(dr.Cells(ContactPhone).Value, "")
            If ContactEmail <> "" Then m.ContactEmail = IsNull(dr.Cells(ContactEmail).Value, "")
            If Note <> "" Then m.Note = IsNull(dr.Cells(Note).Value, "")

            'save to db
            If b.updateDB(m) Then
                countImported += 1
                'remove row into tbBegin which imported successfully
                Me.UpdateDataAfterImport(SubContractorId, code)
            End If
        Next

        Return countImported > 0
    End Function
#End Region
#Region "Uniteds"
    Private Sub CheckImportUniteds()
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
            ShowMsg(ModMain.m_NoSelectedItemToImport)
            Me.bImportOK = False
            Exit Sub
        End If


        'Required
        Dim UnitedId = Me.IsSelectedRequireColumn("UnitedId", tbCol, True)
        If UnitedId = "" Then
            Me.bImportOK = False
            Exit Sub
        End If
        Dim UnitedName = Me.IsSelectedRequireColumn("UnitedName", tbCol, True)
        If UnitedName = "" Then
            Me.bImportOK = False
            Exit Sub
        End If

        For Each dr As UltraGridRow In Grid.Rows
            Dim code = IsNull(dr.Cells(UnitedId).Value, "")
            Dim name = IsNull(dr.Cells(UnitedName).Value, "")
            If code = "" Then
                dr.Cells(UnitedId).Appearance.BackColor = Me.errorColor
                Me.bImportOK = False
            End If
            If name = "" Then
                dr.Cells(UnitedName).Appearance.BackColor = Me.errorColor
                Me.bImportOK = False
            End If
        Next

        If Not Me.bImportOK Then
            ShowMsg(ModMain.m_DataInvalid)
        End If
    End Sub

    Private Function ImportUniteds() As Boolean
        If Grid.DataSource Is Nothing OrElse GridCol.DataSource Is Nothing Then
            Return False
        End If

        If Not Me.fCheckImport Then
            Me.CheckImportUniteds()
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
        Dim UnitedId = Me.IsSelectedRequireColumn("UnitedId", tbCol, True)
        If UnitedId = "" Then Return False
        Dim UnitedName = Me.IsSelectedRequireColumn("UnitedName", tbCol, True)
        If UnitedName = "" Then Return False

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
        Dim b As BLL.BUniteds = BLL.BUniteds.Instance
        Grid.UpdateData()
        For Each dr As UltraGridRow In Grid.Rows
            Dim code = IsNull(dr.Cells(UnitedId).Value, "")
            Dim name = IsNull(dr.Cells(UnitedName).Value, "")

            'if required collumn is empty -> ignore this row
            If code = "" Then Continue For
            If name = "" Then Continue For
            If dr.Cells(UnitedId).Appearance.BackColor.Equals(errorColor) Then Continue For
            If dr.Cells(UnitedName).Appearance.BackColor.Equals(errorColor) Then Continue For

            'init model
            Dim m As New Model.MUnited
            m.UnitedId = code
            m.UnitedName = name
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
            If b.updateDB(m) Then
                countImported += 1
                'remove row into tbBegin which imported successfully
                Me.UpdateDataAfterImport(UnitedId, code)
            End If
        Next

        Return countImported > 0
    End Function
#End Region

    Private Sub btnExportExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        ModMain.ExportExcel(Grid)
    End Sub
End Class