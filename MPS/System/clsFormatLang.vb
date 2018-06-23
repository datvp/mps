Imports System.Data.OleDb
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinStatusBar
Imports Infragistics.Win.UltraWinExplorerBar
Public Class clsFormatLang
    Dim ArrContextMenuStrip() As ContextMenuStrip
    Dim ArrMenuStrip() As MenuStrip
    Dim arrToolbar() As UltraToolbarsManager
    Dim arrExplorer() As UltraExplorerBar
    Dim arrUltraStatusBar() As UltraStatusBar
    Dim arrToolTip() As ToolTip

    Dim frmParent As Form
    Dim tbControl As DataTable
    Dim iLang As Integer = 1 'System.Windows.Forms.Application.StartupPath & "\Lang.mdb" 
    Dim sPathfile As String = "Lang.mdb" '"Lang.mdb" "\\192.168.1.19\test-sanpham$\Lang.mdb"
    Public Function AddLangMsg(ByVal Lang As Integer, ByVal ID As Integer, ByVal MsgVN As String, ByVal MsgLang As String) As Boolean
        Dim tb As DataTable = OpenDataSetAccess("Select * from tblMsg where [ID]=" & ID).Tables(0)
        Dim sql As String = ""
        If tb.Rows.Count = 0 Then
            sql = "Insert into tblMsg([ID],[Msg]) values(" & ID.ToString & ",'" & MsgVN.Replace("'", "''") & "')"
            If ExecuteSQLToAccess(sql) Then
                If Lang <> 1 Then
                    sql = "Insert into tblMultiMsg([IDMsg],[LangID],[Msg]) values(" & ID.ToString & "," & Lang.ToString & ",'" & MsgVN.Replace("'", "''") & "')"
                    If Not ExecuteSQLToAccess(sql) Then
                        Return False
                    End If
                End If
            End If
        Else
            If Lang = 1 Then
                sql = "Update tblMsg set [Msg]='" & MsgVN.Replace("'", "''") & "' where [ID]=" & ID.ToString
                Return ExecuteSQLToAccess(sql)
            Else
                sql = "Update tblMultiMsg set [Msg]='" & MsgLang.Replace("'", "''") & "' where [IDMsg]=" & ID.ToString & " and LangID=" & Lang.ToString
                Return ExecuteSQLToAccess(sql)
            End If
        End If

        Return True
    End Function
    Public Function LoadListLang() As DataTable
        Return OpenDataSetAccess("Select * from tblLang where Valid=yes Order by [ID] asc").Tables(0)
    End Function
    Private dsLang As DataSet
    Private dsControl As DataSet
    Private dsCboTime As DataSet
    Private dsReport As DataSet
    Private dsConfigNumber As DataSet
    Private dsConfigMyDesk As DataSet
    Private dsEvent As DataSet
    Private dsFunc As DataSet
    Sub New()
        getDataLang()
    End Sub
    Private Sub getDataLang()
        If m_Lang <> 1 AndAlso System.IO.File.Exists(sPathfile) Then
            Dim sql As String = ""
            dsLang = OpenDataSetAccess("Select LangID,IDMsg,[Msg]  from tblMultiMsg where LangID=" & m_Lang.ToString)

            sql = "Select l.LangID, ctr.[ID], ctr.FormName,ctr.CtrName,l.Caption,l.Tooltip from tblFormControl ctr "
            sql += " ,tblMultiLang l  where ctr.Valid=yes AND ctr.[ID]=l.[ControlID] AND l.LangID=" & m_Lang.ToString
            dsControl = OpenDataSetAccess(sql)

            sql = "Select * from tblMultiCboTime where LangID=" & m_Lang
            dsCboTime = OpenDataSetAccess(sql)
           
            sql = "Select m.Msg,m.LangID,r.[ID] from tblMultiReport m,tblReport r where m.Report_ID=r.[ID] AND m.LangID=" & m_Lang
            dsReport = OpenDataSetAccess(sql)

            sql = "Select m.Msg,m.LangID,r.[ID] from tblMultiConfigNumber m,tblConfigNumber r where m.Config_ID=r.[ID] AND m.LangID=" & m_Lang
            dsConfigNumber = OpenDataSetAccess(sql)


            sql = "Select m.Msg,m.LangID,r.[ID] from tblMultiConfigMyDesk m,tblConfigMyDesk r where m.Config_ID=r.[ID] AND m.LangID=" & m_Lang
            dsConfigMyDesk = OpenDataSetAccess(sql)

            sql = "Select r.ID, m.Msg,m.LangID from tblMultiEvent m,tblEvent r where m.Event_ID=r.ID AND m.LangID=" & m_Lang
            dsEvent = OpenDataSetAccess(sql)

            sql = "Select r.ID, m.Msg,m.LangID from tblMultiFunc m,tblFunc r where m.Func_ID=r.ID AND m.LangID=" & m_Lang
            dsFunc = OpenDataSetAccess(sql)

        End If

    End Sub
    Public Function getLangEvent(ByVal Lang As Integer, ByVal ID As Integer) As String

        If Not dsEvent Is Nothing Then
            Dim DF() As DataRow
            Dim sql As String = ""
            sql = "[ID]=" & ID.ToString & " and LangID=" & Lang.ToString
            DF = dsEvent.Tables(0).Select(sql)
            If DF.Length > 0 Then
                Return IsNull(DF(0)("msg"), "")
            End If
        End If

        Return ""
    End Function
    Public Function InsertMsgRpt(ByVal Msg As String) As Boolean
        Dim ds As DataSet = OpenDataSetAccess("Select * from tblTxtRpt where Msg='" & Msg.Replace("'", "''") & "'")
        If Not ds Is Nothing AndAlso ds.Tables(0).Rows.Count = 0 Then
            Dim ID As Integer = 1
            ds = OpenDataSetAccess("Select Max(ID) as M from tblTxtRpt")
            If Not ds Is Nothing AndAlso Not IsDBNull(ds.Tables(0).Rows(0)("M")) Then
                ID = ds.Tables(0).Rows(0)("M") + 1
            End If
            Dim sql As String = "Insert into tblTxtRpt(ID,Msg,Valid)values(" & ID & ",'" & Msg.Replace("'", "''") & "',yes)"
            Return ExecuteSQLToAccess(sql)
        End If
        Return True
    End Function
    Public Function getMsgRpt(ByVal Msg As String, ByVal iLang As Integer) As String
        Dim s As String = Msg
        Dim ds As DataSet = OpenDataSetAccess("Select l.Msg from tblTxtRpt r, tblMultiTxtRpt l where r.Valid=Yes AND r.ID=l.Report_ID AND l.LangID=" & iLang.ToString & " AND r.Msg='" & Msg.Replace("'", "''") & "' Order by l.ID asc")
        If Not ds Is Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then
            s = IsNull(ds.Tables(0).Rows(0)("Msg"), "")
        End If
        Return s
    End Function
    Public Function getLang(ByVal Lang As Integer, ByVal ID As Integer) As String

        If dsLang Is Nothing Then
            getDataLang()
        End If

        If Not dsLang Is Nothing Then
            Dim DF() As DataRow
            Dim sql As String = ""
            sql = "[IDMsg]=" & ID.ToString
            DF = dsLang.Tables(0).Select(sql)

            If DF.Length > 0 Then
                Return IsNull(DF(0)("msg"), "")
            End If
        End If
        'Dim sql As String = ""
        'If Lang = 1 Then
        '    sql = "Select * from tblMsg where [ID]=" & ID
        'Else
        '    sql = "Select * from tblMultiMsg where  [IDMsg]=" & ID.ToString & " and LangID=" & Lang.ToString
        'End If
        'Dim tb As DataTable = OpenDataSetAccess(sql).Tables(0)
        'If tb.Rows.Count > 0 Then
        '    Return tb.Rows(0)("Msg")
        'End If

        Return ""
    End Function
    Public Sub FormatCboTime(ByVal iLang As Integer, ByVal cbo As ComboBoxTool)
        If Not cbo Is Nothing AndAlso Not dsCboTime Is Nothing Then
            Dim DF() As DataRow
            For i As Integer = 0 To cbo.ValueList.ValueListItems.Count - 1
                DF = dsCboTime.Tables(0).Select("LangID=" & iLang & " AND cboTimeID=" & i)
                If DF.Length > 0 Then
                    cbo.ValueList.ValueListItems(i).DisplayText = DF(0)("Msg")
                End If
            Next
        End If
    End Sub
    Public Sub FormatReport(ByRef tb As DataTable, ByVal iLang As Integer)
        If Not tb Is Nothing AndAlso Not dsReport Is Nothing Then
            Dim DF() As DataRow
            For Each dr As DataRow In tb.Rows
                If dr("ID") <> 0 Then
                    DF = dsReport.Tables(0).Select("LangID=" & iLang & " AND ID=" & dr("ID"))
                    If DF.Length > 0 Then
                        dr("Name") = DF(0)("Msg")
                    End If
                End If
            Next
        End If
    End Sub
    Public Sub FormatFunc(ByRef tb As DataTable, ByVal iLang As Integer)
        If Not tb Is Nothing AndAlso Not dsFunc Is Nothing Then
            Dim DF() As DataRow
            For Each dr As DataRow In tb.Rows
                DF = dsFunc.Tables(0).Select("LangID=" & iLang & " AND ID=" & dr("i_ID"))
                If DF.Length > 0 Then
                    dr("s_Name") = DF(0)("Msg")
                End If
            Next
        End If
    End Sub
    Public Sub FormatConfigNumber(ByRef tb As DataTable, ByVal iLang As Integer)
        If Not tb Is Nothing AndAlso Not dsConfigNumber Is Nothing Then
            Dim DF() As DataRow
            For Each dr As DataRow In tb.Rows
                DF = dsConfigNumber.Tables(0).Select("LangID=" & iLang & " AND ID=" & dr("i_TypeNumber"))
                If DF.Length > 0 Then
                    dr("s_TypeNumber") = DF(0)("Msg")
                End If
            Next
        End If
    End Sub
    Public Sub FormatConfigMyDesk(ByRef tb As DataTable, ByVal iLang As Integer)
        If Not tb Is Nothing AndAlso Not dsConfigMyDesk Is Nothing Then
            Dim DF() As DataRow
            For Each dr As DataRow In tb.Rows
                DF = dsConfigMyDesk.Tables(0).Select("LangID=" & iLang & " AND ID=" & dr("s_ID"))
                If DF.Length > 0 Then
                    dr("s_Name") = DF(0)("Msg")
                End If
            Next
        End If
    End Sub

    Public Sub FormatLang(ByVal Lang As Integer, ByVal AContextMenuStrip() As ContextMenuStrip, ByVal AMenuStrip() As MenuStrip, _
            ByVal aToolbar() As UltraToolbarsManager, ByVal aExplorer() As UltraExplorerBar, _
            ByVal aUltraStatusBar() As UltraStatusBar, ByVal aToolTip() As ToolTip, ByVal frm As Form)

        iLang = Lang
        arrToolTip = aToolTip
        ArrContextMenuStrip = AContextMenuStrip
        ArrMenuStrip = AMenuStrip
        arrToolbar = aToolbar
        arrExplorer = aExplorer
        arrUltraStatusBar = aUltraStatusBar
        frmParent = frm
        If dsControl Is Nothing Then Exit Sub

        Dim sql As String = ""
        tbControl = dsControl.Tables(0)

        If tbControl Is Nothing Then Exit Sub
        FillLangControl()

    End Sub
    Private Sub FillLangControl()

        Dim DF() As DataRow
        If Not ArrContextMenuStrip Is Nothing Then
            For Each it As ContextMenuStrip In ArrContextMenuStrip
                For i As Integer = 0 To it.Items.Count - 1
                    Dim obj As Object = it.Items(i)
                    Dim sType As String = obj.GetType.ToString
                    If sType = "System.Windows.Forms.ToolStripMenuItem" Then
                        Dim itChild As ToolStripMenuItem = it.Items(i)
                        DF = tbControl.Select("LangID=" & iLang.ToString & " and FormName='" & frmParent.Name.Replace("'", "''") & "' and CtrName='" & itChild.Name.Replace("'", "''") & "'")
                        If DF.Length > 0 Then
                            If IsNull(DF(0)("Caption"), "") <> "" Then
                                itChild.Text = IsNull(DF(0)("Caption"), "")
                            End If
                            itChild.ToolTipText = IsNull(DF(0)("Tooltip"), "")
                        End If
                        FindItemMenuChild(itChild)
                    End If
                Next
            Next
        End If

        If Not ArrMenuStrip Is Nothing Then
            For Each it As MenuStrip In ArrMenuStrip
                For i As Integer = 0 To it.Items.Count - 1
                    Dim obj As Object = it.Items(i)
                    If obj.GetType.ToString = "System.Windows.Forms.ToolStripMenuItem" Then
                        Dim itChild As ToolStripMenuItem = it.Items(i)
                        DF = tbControl.Select("LangID=" & iLang.ToString & " and FormName='" & frmParent.Name.Replace("'", "''") & "' and CtrName='" & itChild.Name.Replace("'", "''") & "'")
                        If DF.Length > 0 Then
                            If IsNull(DF(0)("Caption"), "") <> "" Then
                                itChild.Text = IsNull(DF(0)("Caption"), "")
                            End If
                            itChild.ToolTipText = IsNull(DF(0)("Tooltip"), "")
                        End If
                        FindItemMenuChild(itChild)

                    End If

                Next
            Next
        End If

        If Not arrExplorer Is Nothing Then
            For Each it As UltraExplorerBar In arrExplorer
                For Each gr As UltraExplorerBarGroup In it.Groups

                    DF = tbControl.Select("LangID=" & iLang.ToString & " and FormName='" & frmParent.Name.Replace("'", "''") & "' and CtrName='" & gr.Key.Replace("'", "''") & "'")
                    If DF.Length > 0 Then
                        If IsNull(DF(0)("Caption"), "") <> "" Then
                            gr.Text = IsNull(DF(0)("Caption"), "")
                        End If
                        gr.ToolTipText = IsNull(DF(0)("Tooltip"), "")
                    End If


                    For Each itChild As UltraExplorerBarItem In gr.Items
                        DF = tbControl.Select("LangID=" & iLang.ToString & " and FormName='" & frmParent.Name.Replace("'", "''") & "' and CtrName='" & itChild.Key.Replace("'", "''") & "'")
                        If DF.Length > 0 Then
                            If IsNull(DF(0)("Caption"), "") <> "" Then
                                itChild.Text = IsNull(DF(0)("Caption"), "")
                            End If
                            itChild.ToolTipText = IsNull(DF(0)("Tooltip"), "")
                        End If

                    Next
                Next
            Next
        End If

        If Not arrToolbar Is Nothing Then
            For Each it As UltraToolbarsManager In arrToolbar
                For Each rb As RibbonTab In it.Ribbon.Tabs

                    DF = tbControl.Select("LangID=" & iLang.ToString & " and FormName='" & frmParent.Name.Replace("'", "''") & "' and CtrName='" & rb.Key.Replace("'", "''") & "'")
                    If DF.Length > 0 Then
                        If IsNull(DF(0)("Caption"), "") <> "" Then
                            rb.Caption = IsNull(DF(0)("Caption"), "")
                        End If
                    End If

                    For Each gr As RibbonGroup In rb.Groups
                        DF = tbControl.Select("LangID=" & iLang.ToString & " and FormName='" & frmParent.Name.Replace("'", "''") & "' and CtrName='" & (rb.Key & ";" & gr.Key).Replace("'", "''") & "'")
                        If DF.Length > 0 Then
                            If IsNull(DF(0)("Caption"), "") <> "" Then
                                gr.Caption = IsNull(DF(0)("Caption"), "")
                            End If
                        End If
                    Next
                Next

                For i As Integer = 0 To it.Tools.Count - 1
                    DF = tbControl.Select("LangID=" & iLang.ToString & " and FormName='" & frmParent.Name.Replace("'", "''") & "' and CtrName='" & it.Tools(i).Key.Replace("'", "''") & "'")
                    If DF.Length > 0 Then
                        If IsNull(DF(0)("Caption"), "") <> "" Then
                            it.Tools(i).SharedProps.Caption = IsNull(DF(0)("Caption"), "")
                        End If
                    End If
                Next
            Next
        End If
        If Not arrUltraStatusBar Is Nothing Then
            For Each it As UltraStatusBar In arrUltraStatusBar
                For Each itChild As UltraStatusPanel In it.Panels
                    DF = tbControl.Select("LangID=" & iLang.ToString & " and FormName='" & frmParent.Name.Replace("'", "''") & "' and CtrName='" & itChild.Key.Replace("'", "''") & "'")
                    If DF.Length > 0 Then
                        If IsNull(DF(0)("Caption"), "") <> "" Then
                            itChild.Text = IsNull(DF(0)("Caption"), "")
                        End If
                        itChild.ToolTipText = IsNull(DF(0)("Tooltip"), "")
                    End If

                Next
            Next
        End If


        FindAllControl(frmParent)


    End Sub

    Private Sub FindItemMenuChild(ByVal it As ToolStripMenuItem)
        If it.DropDownItems Is Nothing OrElse it.DropDownItems.Count = 0 Then Exit Sub
        Dim DF() As DataRow
        For i As Integer = 0 To it.DropDownItems.Count - 1
            Dim obj As Object = it.DropDownItems(i)
            If obj.GetType.ToString = "System.Windows.Forms.ToolStripMenuItem" Then
                Dim itChild As ToolStripMenuItem = it.DropDownItems(i)
                DF = tbControl.Select("LangID=" & iLang.ToString & " and FormName='" & frmParent.Name.Replace("'", "''") & "' and CtrName='" & itChild.Name.Replace("'", "''") & "'")
                If DF.Length > 0 Then
                    If IsNull(DF(0)("Caption"), "") <> "" Then
                        itChild.Text = IsNull(DF(0)("Caption"), "")
                    End If
                    itChild.ToolTipText = IsNull(DF(0)("Tooltip"), "")
                End If
                FindItemMenuChild(itChild)

            End If
        Next

    End Sub
    Private Sub FindAllControl(ByVal frm As Form)
        For i As Integer = 0 To frm.Controls.Count - 1
            FindCtl(frm.Controls(i))
        Next
    End Sub


    Private Sub FindCtl(ByVal ctr As Control)
        Dim DF() As DataRow
        Try
            Dim sType As String = ctr.Name
            Dim obj As Object = ctr
            'btnHeThong
            If sType = "btnHeThong" Then
                Dim s123 As String = ""
            End If
            DF = tbControl.Select("LangID=" & iLang.ToString & " and FormName='" & frmParent.Name.Replace("'", "''") & "' and CtrName='" & ctr.Name.Replace("'", "''") & "'")
            If DF.Length > 0 Then
               
                sType = obj.GetType.ToString
                Dim sTextOri As String = IsNull(DF(0)("Caption"), "")
                Dim sToolTipOri As String = IsNull(DF(0)("Tooltip"), "")

                Select Case sType
                    Case "System.Windows.Forms.ComboBox"
                    Case "Infragistics.Win.UltraWinGrid.UltraCombo"
                        Dim cboInf As Infragistics.Win.UltraWinGrid.UltraCombo = ctr
                        cboInf.AlwaysInEditMode = True
                    Case "System.Windows.Forms.RadioButton"
                        Dim C As System.Windows.Forms.RadioButton = ctr
                        If sTextOri <> "" Then
                            C.Text = sTextOri
                        End If

                    Case "System.Windows.Forms.TextBox"
                    Case "System.Windows.Forms.TabPage"
                        Dim C As System.Windows.Forms.TabPage = ctr
                        If sTextOri <> "" Then
                            C.Text = sTextOri
                        End If
                    Case "System.Windows.Forms.TabControl"
                    Case "System.Windows.Forms.Panel"

                    Case "System.Windows.Forms.MenuStrip"

                    Case "System.Windows.Forms.Label"
                        Dim C As System.Windows.Forms.Label = ctr
                        If sTextOri <> "" Then
                            C.Text = sTextOri
                        End If
                    Case "System.Windows.Forms.GroupBox"
                        Dim C As System.Windows.Forms.GroupBox = ctr
                        If sTextOri <> "" Then
                            C.Text = sTextOri
                        End If
                    Case "System.Windows.Forms.DateTimePicker"

                    Case "System.Windows.Forms.CheckBox"
                        Dim C As System.Windows.Forms.CheckBox = ctr
                        If sTextOri <> "" Then
                            C.Text = sTextOri
                        End If
                    Case "Infragistics.Win.UltraWinEditors.UltraCheckEditor"
                        Dim C As Infragistics.Win.UltraWinEditors.UltraCheckEditor = ctr
                        If sTextOri <> "" Then
                            C.Text = sTextOri
                        End If

                    Case "System.Windows.Forms.Button"
                        Dim C As System.Windows.Forms.Button = ctr
                        If sTextOri <> "" Then
                            C.Text = sTextOri
                        End If
                    Case "System.Windows.Forms.LinkLabel"
                        Dim C As System.Windows.Forms.LinkLabel = ctr
                        If sTextOri <> "" Then
                            C.Text = sTextOri
                        End If

                    Case "Infragistics.Win.UltraWinTree.UltraTree"

                    Case "Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea"

                    Case "Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage"

                    Case "Infragistics.Win.UltraWinTabControl.UltraTabPageControl"
                    Case "Infragistics.Win.UltraWinTabControl.UltraTabControl"
                        Dim C As Infragistics.Win.UltraWinTabControl.UltraTabControl = ctr
                        For i As Integer = 0 To C.Tabs.Count - 1
                            DF = tbControl.Select("LangID=" & iLang.ToString & " and FormName='" & frmParent.Name.Replace("'", "''") & "' and CtrName='" & C.Tabs(i).Key.Replace("'", "''") & "'")
                            If DF.Length > 0 Then
                                C.Tabs(i).Text = DF(0)("Caption")
                                'C.Tabs(i).ToolTipText = DF(0)("Tooltip")
                            End If
                        Next

                    Case "Infragistics.Win.UltraWinStatusBar.UltraStatusBar"
                    Case "Infragistics.Win.UltraWinGrid.UltraGrid"
                    Case "Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar"
                    Case "Infragistics.Win.UltraWinEditors.UltraNumericEditor"
                    Case "Infragistics.Win.UltraWinEditors.UltraTextEditor"
                        Dim txtInf As Infragistics.Win.UltraWinEditors.UltraTextEditor = ctr
                        txtInf.AlwaysInEditMode = True
                    Case "Infragistics.Win.UltraWinEditors.UltraOptionSet"

                    Case "Infragistics.Win.Misc.UltraLabel"
                        Dim C As Infragistics.Win.Misc.UltraLabel = ctr
                        If sTextOri <> "" Then
                            C.Text = sTextOri
                        End If
                    Case "Infragistics.Win.Misc.UltraGroupBox"
                        Dim C As Infragistics.Win.Misc.UltraGroupBox = ctr
                        If sTextOri <> "" Then
                            C.Text = sTextOri
                        End If
                    Case "Infragistics.Win.Misc.UltraButton"
                        Dim C As Infragistics.Win.Misc.UltraButton = ctr
                        If sTextOri <> "" Then
                            C.Text = sTextOri
                        End If

                    Case "Infragistics.Win.UltraWinTabControl.UltraTabPageControl"
                        Dim C As Infragistics.Win.UltraWinTabControl.UltraTabPageControl = ctr
                        If sTextOri <> "" Then
                            C.Tab.Text = sTextOri
                        End If
                        C.Tab.ToolTipText = sToolTipOri
                End Select

                If Not arrToolTip Is Nothing Then
                    If arrToolTip.Length > 0 Then
                        'sToolTipOri = arrToolTip(0).GetToolTip(ctr)
                        arrToolTip(0).SetToolTip(ctr, sToolTipOri)
                    End If
                End If

            End If



        Catch ex As Exception

        End Try

        For i As Integer = 0 To ctr.Controls.Count - 1
            FindCtl(ctr.Controls(i))
        Next

    End Sub

    Public Function ExecuteSQLToAccess(ByVal strSQL As String) As Boolean
        Dim strCnn As String
        Dim fileName As String = sPathfile ' System.Windows.Forms.Application.StartupPath & "\Lang.mdb"
        If Not System.IO.File.Exists(fileName) Then
            MsgBox("Invalid file Lang.mdb", MsgBoxStyle.Critical)
            Return False
        End If
        strCnn = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" & fileName & ";Jet OLEDB:Database Password=2010;Mode=ReadWrite|Share Deny None;Persist Security Info=False"
        Dim cn As New System.Data.OleDb.OleDbConnection(strCnn)
        Dim cmd As System.Data.OleDb.OleDbCommand = New System.Data.OleDb.OleDbCommand(strSQL, cn)
        Try
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Public Function OpenDataSetAccess(ByVal strSQL As String) As DataSet

        Dim strCnn As String
        Dim fileName As String = sPathfile ' System.Windows.Forms.Application.StartupPath & "\Lang.mdb"

        If Not System.IO.File.Exists(fileName) Then
            MsgBox("Invalid file Lang.mdb", MsgBoxStyle.Critical)
            Return Nothing
        End If
        strCnn = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" & fileName & ";Jet OLEDB:Database Password=2010;Mode=ReadWrite|Share Deny None;Persist Security Info=False"
        Dim cn As New System.Data.OleDb.OleDbConnection(strCnn)
        Try
            cn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
        Dim da As New System.Data.OleDb.OleDbDataAdapter(strSQL, cn)
        da.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet
        Try
            da.Fill(ds)
            cn.Close()
        Catch e As Exception
            cn.Close()
            MsgBox(e.Message)
            Return Nothing
        End Try
        cn.Close()

        Return ds
    End Function

End Class
