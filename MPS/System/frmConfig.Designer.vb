<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfig
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim EditorButton1 As Infragistics.Win.UltraWinEditors.EditorButton = New Infragistics.Win.UltraWinEditors.EditorButton
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.grpBottom = New Infragistics.Win.Misc.UltraGroupBox
        Me.btnSave = New Infragistics.Win.Misc.UltraButton
        Me.btnExit = New Infragistics.Win.Misc.UltraButton
        Me.lblTitle = New Infragistics.Win.Misc.UltraLabel
        Me.grpMain = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtWebsite = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtEmail = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtPhone = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtAddress = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtAlias = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtCompanyName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtTaxNo = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtPhone2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.grpContact = New Infragistics.Win.Misc.UltraGroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtPathToSave = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.pic1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        CType(Me.grpBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBottom.SuspendLayout()
        CType(Me.grpMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMain.SuspendLayout()
        CType(Me.txtWebsite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPhone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAlias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompanyName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPhone2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpContact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpContact.SuspendLayout()
        CType(Me.txtPathToSave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpBottom
        '
        Me.grpBottom.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.HeaderSolid
        Me.grpBottom.Controls.Add(Me.btnSave)
        Me.grpBottom.Controls.Add(Me.btnExit)
        Me.grpBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpBottom.Location = New System.Drawing.Point(0, 461)
        Me.grpBottom.Margin = New System.Windows.Forms.Padding(0)
        Me.grpBottom.Name = "grpBottom"
        Me.grpBottom.Size = New System.Drawing.Size(583, 58)
        Me.grpBottom.TabIndex = 11
        Me.grpBottom.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'btnSave
        '
        Appearance17.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance17.BackColor2 = System.Drawing.Color.White
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.HorizontalBump
        Appearance17.BorderColor = System.Drawing.Color.LightSteelBlue
        Appearance17.FontData.BoldAsString = "True"
        Appearance17.ForeColor = System.Drawing.Color.Black
        Appearance17.Image = Global.MPS.My.Resources.Resources.Luu_Thoat
        Me.btnSave.Appearance = Appearance17
        Me.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance18.BackColor = System.Drawing.Color.Yellow
        Appearance18.BackColor2 = System.Drawing.Color.White
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom37
        Me.btnSave.HotTrackAppearance = Appearance18
        Me.btnSave.Location = New System.Drawing.Point(295, 13)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.btnSave.Name = "btnSave"
        Appearance19.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance19.BackColor2 = System.Drawing.Color.White
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.btnSave.PressedAppearance = Appearance19
        Me.btnSave.Size = New System.Drawing.Size(117, 38)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Cập nhật"
        Me.btnSave.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnSave.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnExit
        '
        Appearance66.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance66.BackColor2 = System.Drawing.Color.White
        Appearance66.BackGradientStyle = Infragistics.Win.GradientStyle.HorizontalBump
        Appearance66.BorderColor = System.Drawing.Color.LightSteelBlue
        Appearance66.FontData.BoldAsString = "True"
        Appearance66.ForeColor = System.Drawing.Color.Black
        Appearance66.Image = Global.MPS.My.Resources.Resources.cancl_32
        Me.btnExit.Appearance = Appearance66
        Me.btnExit.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance67.BackColor = System.Drawing.Color.Yellow
        Appearance67.BackColor2 = System.Drawing.Color.White
        Appearance67.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom37
        Me.btnExit.HotTrackAppearance = Appearance67
        Me.btnExit.Location = New System.Drawing.Point(422, 13)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.btnExit.Name = "btnExit"
        Appearance68.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance68.BackColor2 = System.Drawing.Color.White
        Appearance68.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.btnExit.PressedAppearance = Appearance68
        Me.btnExit.Size = New System.Drawing.Size(125, 38)
        Me.btnExit.TabIndex = 12
        Me.btnExit.Text = "Thoát (Esc)"
        Me.btnExit.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnExit.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'lblTitle
        '
        Appearance12.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(250, Byte), Integer))
        Appearance12.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance12.FontData.BoldAsString = "True"
        Appearance12.FontData.SizeInPoints = 14.0!
        Appearance12.ForeColor = System.Drawing.Color.Black
        Appearance12.Image = Global.MPS.My.Resources.Resources.document_new
        Appearance12.TextHAlignAsString = "Left"
        Appearance12.TextVAlignAsString = "Middle"
        Me.lblTitle.Appearance = Appearance12
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ImageSize = New System.Drawing.Size(32, 32)
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(583, 47)
        Me.lblTitle.TabIndex = 13
        Me.lblTitle.Text = "THIẾT LẬP CẤU HÌNH"
        '
        'grpMain
        '
        Me.grpMain.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.HeaderSolid
        Me.grpMain.Controls.Add(Me.LinkLabel2)
        Me.grpMain.Controls.Add(Me.LinkLabel1)
        Me.grpMain.Controls.Add(Me.pic1)
        Me.grpMain.Controls.Add(Me.txtWebsite)
        Me.grpMain.Controls.Add(Me.txtEmail)
        Me.grpMain.Controls.Add(Me.txtPhone)
        Me.grpMain.Controls.Add(Me.txtAddress)
        Me.grpMain.Controls.Add(Me.txtAlias)
        Me.grpMain.Controls.Add(Me.txtCompanyName)
        Me.grpMain.Controls.Add(Me.txtTaxNo)
        Me.grpMain.Controls.Add(Me.txtPhone2)
        Me.grpMain.Controls.Add(Me.Label7)
        Me.grpMain.Controls.Add(Me.Label6)
        Me.grpMain.Controls.Add(Me.Label8)
        Me.grpMain.Controls.Add(Me.Label5)
        Me.grpMain.Controls.Add(Me.Label4)
        Me.grpMain.Controls.Add(Me.Label1)
        Me.grpMain.Controls.Add(Me.Label3)
        Me.grpMain.Controls.Add(Me.Label2)
        Appearance16.BorderColor = System.Drawing.Color.Green
        Appearance16.FontData.BoldAsString = "True"
        Me.grpMain.HeaderAppearance = Appearance16
        Me.grpMain.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOutsideBorder
        Me.grpMain.Location = New System.Drawing.Point(12, 65)
        Me.grpMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpMain.Name = "grpMain"
        Me.grpMain.Size = New System.Drawing.Size(553, 311)
        Me.grpMain.TabIndex = 0
        Me.grpMain.Text = "THÔNG TIN CHÍNH"
        Me.grpMain.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'txtWebsite
        '
        Me.txtWebsite.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtWebsite.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWebsite.Location = New System.Drawing.Point(113, 239)
        Me.txtWebsite.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtWebsite.MaxLength = 50
        Me.txtWebsite.Name = "txtWebsite"
        Me.txtWebsite.Size = New System.Drawing.Size(270, 25)
        Me.txtWebsite.TabIndex = 6
        '
        'txtEmail
        '
        Me.txtEmail.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtEmail.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(113, 206)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(270, 25)
        Me.txtEmail.TabIndex = 5
        '
        'txtPhone
        '
        Me.txtPhone.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtPhone.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhone.Location = New System.Drawing.Point(113, 107)
        Me.txtPhone.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPhone.MaxLength = 50
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(270, 25)
        Me.txtPhone.TabIndex = 2
        '
        'txtAddress
        '
        Me.txtAddress.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtAddress.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(113, 272)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAddress.MaxLength = 500
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(422, 25)
        Me.txtAddress.TabIndex = 7
        '
        'txtAlias
        '
        Me.txtAlias.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtAlias.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlias.Location = New System.Drawing.Point(113, 74)
        Me.txtAlias.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAlias.MaxLength = 50
        Me.txtAlias.Name = "txtAlias"
        Me.txtAlias.Size = New System.Drawing.Size(270, 25)
        Me.txtAlias.TabIndex = 1
        '
        'txtCompanyName
        '
        Me.txtCompanyName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtCompanyName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompanyName.Location = New System.Drawing.Point(113, 41)
        Me.txtCompanyName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCompanyName.MaxLength = 255
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.Size = New System.Drawing.Size(422, 25)
        Me.txtCompanyName.TabIndex = 0
        '
        'txtTaxNo
        '
        Me.txtTaxNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtTaxNo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTaxNo.Location = New System.Drawing.Point(113, 173)
        Me.txtTaxNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTaxNo.MaxLength = 50
        Me.txtTaxNo.Name = "txtTaxNo"
        Me.txtTaxNo.Size = New System.Drawing.Size(270, 25)
        Me.txtTaxNo.TabIndex = 4
        '
        'txtPhone2
        '
        Me.txtPhone2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtPhone2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhone2.Location = New System.Drawing.Point(113, 140)
        Me.txtPhone2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPhone2.MaxLength = 50
        Me.txtPhone2.Name = "txtPhone2"
        Me.txtPhone2.Size = New System.Drawing.Size(270, 25)
        Me.txtPhone2.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 241)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 16)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Website"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 209)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Email"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 140)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 16)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Điện thoại 2"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Điện thoại"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 273)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Địa chỉ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Tên viết tắt"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Tên công ty"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 174)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Mã số thuế"
        '
        'grpContact
        '
        Me.grpContact.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.HeaderSolid
        Me.grpContact.Controls.Add(Me.Label10)
        Me.grpContact.Controls.Add(Me.txtPathToSave)
        Appearance4.BorderColor = System.Drawing.Color.Green
        Appearance4.FontData.BoldAsString = "True"
        Me.grpContact.HeaderAppearance = Appearance4
        Me.grpContact.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOutsideBorder
        Me.grpContact.Location = New System.Drawing.Point(12, 384)
        Me.grpContact.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpContact.Name = "grpContact"
        Me.grpContact.Size = New System.Drawing.Size(553, 73)
        Me.grpContact.TabIndex = 10
        Me.grpContact.Text = "Nơi lưu File đính kèm"
        Me.grpContact.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 16)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Đường dẫn:"
        '
        'txtPathToSave
        '
        Appearance1.TextHAlignAsString = "Center"
        EditorButton1.Appearance = Appearance1
        EditorButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button
        EditorButton1.Text = "..."
        EditorButton1.Width = 30
        Me.txtPathToSave.ButtonsRight.Add(EditorButton1)
        Me.txtPathToSave.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtPathToSave.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPathToSave.Location = New System.Drawing.Point(113, 39)
        Me.txtPathToSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPathToSave.MaxLength = 255
        Me.txtPathToSave.Name = "txtPathToSave"
        Me.txtPathToSave.Size = New System.Drawing.Size(422, 25)
        Me.txtPathToSave.TabIndex = 10
        '
        'pic1
        '
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance2.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched
        Me.pic1.Appearance = Appearance2
        Me.pic1.BorderShadowColor = System.Drawing.Color.Empty
        Me.pic1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.pic1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pic1.Location = New System.Drawing.Point(407, 74)
        Me.pic1.Name = "pic1"
        Me.pic1.Size = New System.Drawing.Size(128, 125)
        Me.pic1.TabIndex = 8
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.Location = New System.Drawing.Point(496, 211)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(25, 13)
        Me.LinkLabel2.TabIndex = 9
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Xóa"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(417, 211)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(55, 13)
        Me.LinkLabel1.TabIndex = 8
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Chọn hình"
        '
        'frmConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(583, 519)
        Me.Controls.Add(Me.grpContact)
        Me.Controls.Add(Me.grpMain)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.grpBottom)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfig"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmConfig"
        CType(Me.grpBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBottom.ResumeLayout(False)
        CType(Me.grpMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMain.ResumeLayout(False)
        Me.grpMain.PerformLayout()
        CType(Me.txtWebsite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPhone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAddress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAlias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompanyName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPhone2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpContact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpContact.ResumeLayout(False)
        Me.grpContact.PerformLayout()
        CType(Me.txtPathToSave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpBottom As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnExit As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblTitle As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents grpMain As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPhone As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtAddress As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtAlias As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtCompanyName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtPhone2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtWebsite As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtEmail As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpContact As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPathToSave As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTaxNo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents pic1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
End Class
