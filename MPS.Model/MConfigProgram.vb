Public Class MConfigProgram
    Private m_i_ID As Integer = 0
    Private m_s_CompanyName As String = ""
    Private m_im_Logo As Byte()
    Private m_s_TaxNo As String = ""
    Private m_s_Account As String = ""
    Private m_s_Address As String = ""
    Private m_s_Phone1 As String = ""
    Private m_s_Phone2 As String = ""
    Private m_s_Fax As String = ""
    Private m_s_Email As String = ""
    Private m_s_Website As String = ""
    Private m_i_FormatCur As Integer = 0
    Private m_i_FormatNum As Integer = 0

    Property i_ID() As Integer
        Get
            Return m_i_ID
        End Get
        Set(ByVal value As Integer)
            m_i_ID = value
        End Set
    End Property
    Property s_CompanyName() As String
        Get
            Return m_s_CompanyName
        End Get
        Set(ByVal value As String)
            m_s_CompanyName = value
        End Set
    End Property
   
    Property im_Logo() As Byte()
        Get
            Return m_im_Logo
        End Get
        Set(ByVal value As Byte())
            m_im_Logo = value
        End Set
    End Property
    Property s_TaxNo() As String
        Get
            Return m_s_TaxNo
        End Get
        Set(ByVal value As String)
            m_s_TaxNo = value
        End Set
    End Property
    Property s_Account() As String
        Get
            Return m_s_Account
        End Get
        Set(ByVal value As String)
            m_s_Account = value
        End Set
    End Property
    Property s_Address() As String
        Get
            Return m_s_Address
        End Get
        Set(ByVal value As String)
            m_s_Address = value
        End Set
    End Property
    Property s_Phone1() As String
        Get
            Return m_s_Phone1
        End Get
        Set(ByVal value As String)
            m_s_Phone1 = value
        End Set
    End Property
    Property s_Phone2() As String
        Get
            Return m_s_Phone2
        End Get
        Set(ByVal value As String)
            m_s_Phone2 = value
        End Set
    End Property
    Property s_Fax() As String
        Get
            Return m_s_Fax
        End Get
        Set(ByVal value As String)
            m_s_Fax = value
        End Set
    End Property
    Property s_Email() As String
        Get
            Return m_s_Email
        End Get
        Set(ByVal value As String)
            m_s_Email = value
        End Set
    End Property
    Property s_Website() As String
        Get
            Return m_s_Website
        End Get
        Set(ByVal value As String)
            m_s_Website = value
        End Set
    End Property
   
    Property i_FormatCur() As Integer
        Get
            Return m_i_FormatCur
        End Get
        Set(ByVal value As Integer)
            m_i_FormatCur = value
        End Set
    End Property
    Property i_FormatNum() As Integer
        Get
            Return m_i_FormatNum
        End Get
        Set(ByVal value As Integer)
            m_i_FormatNum = value
        End Set
    End Property

    Private m_PathToSave As String = ""
    ''' <summary>
    ''' Path tai server de luu file
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PathToSave() As String
        Get
            Return m_PathToSave
        End Get
        Set(ByVal value As String)
            m_PathToSave = value
        End Set
    End Property


    Private m_s_Alias As String = ""
    Public Property s_Alias() As String
        Get
            Return m_s_Alias
        End Get
        Set(ByVal value As String)
            m_s_Alias = value
        End Set
    End Property
End Class
