﻿Public Class frmProjectTypeDetail
    Private WithEvents b As BLL.BProjectTypes = BLL.BProjectTypes.Instance
    Private Sub b__errorRaise(ByVal messege As String) Handles b._errorRaise
        ShowMsg(messege)
    End Sub

    Private ProjectTypeId As String = ""
    Public Overloads Function ShowDialog(ByVal ProjectTypeId As String) As String
        Me.ProjectTypeId = ProjectTypeId
        Me.ShowDialog()
        Return Me.ProjectTypeId
    End Function
    Private Sub frm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.S Then
                Me.Save()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End If
    End Sub
    Private Sub frmProjectTypeDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me, lblTitle.Text)
        ModMain.BlueButton(btnSave, ModMain.m_SaveIcon)
        ModMain.GreenButton(btnExit, ModMain.m_CancelIcon)
        Me.LoadInfo(ProjectTypeId)
    End Sub
    Private Sub ClearInfo()
        Dim m As New Model.MProjectType
        txtProjectTypeId.Text = m.ProjectTypeId
        txtProjectTypeId.Enabled = True
        txtProjectTypeName.Text = m.ProjectTypeName
        txtNote.Text = m.Note
    End Sub
    Private Sub LoadInfo(ByVal ProjectTypeId As String)
        Dim m = b.getProjectTypeDetailById(ProjectTypeId)
        If m.ProjectTypeId = "" Then Exit Sub
        txtProjectTypeId.Text = m.ProjectTypeId
        txtProjectTypeId.Enabled = False
        txtProjectTypeName.Text = m.ProjectTypeName
        txtNote.Text = m.Note
    End Sub
    Private Function setInfo() As Model.MProjectType
        Dim m As New Model.MProjectType
        m.ProjectTypeId = txtProjectTypeId.Text
        m.ProjectTypeName = txtProjectTypeName.Text
        m.Note = txtNote.Text
        Return m
    End Function
    Private Function CheckOK(ByVal m As Model.MProjectType) As Boolean
        If m.ProjectTypeId = "" Then
            ShowMsg("Nhập mã loại dự án")
            txtProjectTypeId.Focus()
            Return False
        End If

        'Add new -> check duplicate id
        If Me.ProjectTypeId = "" Then
            If b.isExist(m.ProjectTypeId) Then
                ShowMsg("Mã bị trùng, vui lòng nhập mã khác.")
                txtProjectTypeId.Focus()
                Return False
            End If
        End If

        If m.ProjectTypeName = "" Then
            ShowMsg("Nhập tên loại dự án")
            txtProjectTypeName.Focus()
            Return False
        End If

        Return True
    End Function
    Public Sub Save()
        Dim m = Me.setInfo()
        If Not CheckOK(m) Then Exit Sub

        If b.updateDB(m) Then
            If Me.ProjectTypeId <> "" Then
                Me.Close()
            Else
                Me.ProjectTypeId = m.ProjectTypeId
                Me.ClearInfo()
            End If
            ShowMsgInfo(m_MsgSaveSuccess)
        Else
            ShowMsg(m_SaveDataError)
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Me.Save()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class