Public Class MLS_Employees
    Private m_s_ID As String = ""
    Private m_s_Employee_ID As String = ""
    Private m_s_FullName As String = ""
    Private m_s_Address As String = ""
    Private m_s_Phone1 As String = ""
    Private m_s_Phone2 As String = ""
    Private m_s_Note As String = ""
    Private m_i_Ordinal As Decimal = 0
    Private m_s_Email As String = "" '26.05.09
    Private m_i_Position As Decimal = 0
    Private m_b_Sex As Boolean = False
    Private m_im_Photo As Byte()
    Private m_dt_DOB As Date = Now
    Private m_dt_DaysToWork As Date = Now
    Private m_dt_Holidays As Date = CDate("1900-01-01")
    Private m_s_Reason As String = ""
    Private m_m_BasicSalary As Decimal = 0
    Private m_i_NofDay As Integer = 0
    Private m_m_SalaryOf As Decimal = 0
    Private m_s_Currency1 As String = ""
    Private m_s_Currency2 As String = ""
    Private m_s_UserCreate As String = ""
    Private m_dt_Create As Date = Now
    Private m_s_UserEdit As String = ""
    Private m_dt_LastUpdate As Date = Now
    Private m_b_IsActive As Boolean = False
    Private m_b_IsSales As Boolean = False
    Private m_s_Bank_ID As String = ""
    Private m_s_AccountID As String = ""
    Private m_IsCTV As Boolean = False
    Public Property IsCTV() As Boolean
        Get
            Return m_IsCTV
        End Get
        Set(ByVal value As Boolean)
            m_IsCTV = value
        End Set
    End Property

    Private m_ReferrerId As String = ""
    Public Property ReferrerId() As String
        Get
            Return m_ReferrerId
        End Get
        Set(ByVal value As String)
            m_ReferrerId = value
        End Set
    End Property

    Property s_ID() As String
        Get
            Return m_s_ID
        End Get
        Set(ByVal value As String)
            m_s_ID = value
        End Set
    End Property
    Property s_Employee_ID() As String
        Get
            Return m_s_Employee_ID
        End Get
        Set(ByVal value As String)
            m_s_Employee_ID = value
        End Set
    End Property
    Property s_Name() As String
        Get
            Return m_s_FullName
        End Get
        Set(ByVal value As String)
            m_s_FullName = value
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
    Property s_Note() As String
        Get
            Return m_s_Note
        End Get
        Set(ByVal value As String)
            m_s_Note = value
        End Set
    End Property
    Property i_Ordinal() As Decimal
        Get
            Return m_i_Ordinal
        End Get
        Set(ByVal value As Decimal)
            m_i_Ordinal = value
        End Set
    End Property
    Property s_Email() As String '26.05.09
        Get
            Return m_s_Email
        End Get
        Set(ByVal value As String)
            m_s_Email = value
        End Set
    End Property
    Property i_Position() As Decimal
        Get
            Return m_i_Position
        End Get
        Set(ByVal value As Decimal)
            m_i_Position = value
        End Set
    End Property
    Property b_Sex() As Boolean
        Get
            Return m_b_Sex
        End Get
        Set(ByVal value As Boolean)
            m_b_Sex = value
        End Set
    End Property
    Property im_Photo() As Byte()
        Get
            Return m_im_Photo
        End Get
        Set(ByVal value As Byte())
            m_im_Photo = value
        End Set
    End Property

    Property dt_DOB() As Date
        Get
            Return m_dt_DOB
        End Get
        Set(ByVal value As Date)
            m_dt_DOB = value
        End Set
    End Property
    Property dt_DaysToWork() As Date
        Get
            Return m_dt_DaysToWork
        End Get
        Set(ByVal value As Date)
            m_dt_DaysToWork = value
        End Set
    End Property
    Property dt_Holidays() As Date
        Get
            Return m_dt_Holidays
        End Get
        Set(ByVal value As Date)
            m_dt_Holidays = value
        End Set
    End Property
    Property s_Reason() As String
        Get
            Return m_s_Reason
        End Get
        Set(ByVal value As String)
            m_s_Reason = value
        End Set
    End Property
    Property m_BasicSalary() As Decimal
        Get
            Return m_m_BasicSalary
        End Get
        Set(ByVal value As Decimal)
            m_m_BasicSalary = value
        End Set
    End Property
    Property i_NofDay() As Integer
        Get
            Return m_i_NofDay
        End Get
        Set(ByVal value As Integer)
            m_i_NofDay = value
        End Set
    End Property
    Property m_SalaryOf() As Decimal
        Get
            Return m_m_SalaryOf
        End Get
        Set(ByVal value As Decimal)
            m_m_SalaryOf = value
        End Set
    End Property
    Property s_Currency1() As String
        Get
            Return m_s_Currency1
        End Get
        Set(ByVal value As String)
            m_s_Currency1 = value
        End Set
    End Property
    Property s_Currency2() As String
        Get
            Return m_s_Currency2
        End Get
        Set(ByVal value As String)
            m_s_Currency2 = value
        End Set
    End Property
    Property s_UserCreate() As String
        Get
            Return m_s_UserCreate
        End Get
        Set(ByVal value As String)
            m_s_UserCreate = value
        End Set
    End Property
    Property dt_Create() As Date
        Get
            Return m_dt_Create
        End Get
        Set(ByVal value As Date)
            m_dt_Create = value
        End Set
    End Property
    Property s_UserEdit() As String
        Get
            Return m_s_UserEdit
        End Get
        Set(ByVal value As String)
            m_s_UserEdit = value
        End Set
    End Property
    Property dt_LastUpdate() As Date
        Get
            Return m_dt_LastUpdate
        End Get
        Set(ByVal value As Date)
            m_dt_LastUpdate = value
        End Set
    End Property
    Property b_IsActive() As Boolean
        Get
            Return m_b_IsActive
        End Get
        Set(ByVal value As Boolean)
            m_b_IsActive = value
        End Set
    End Property
    Property b_IsSales() As Boolean
        Get
            Return m_b_IsSales
        End Get
        Set(ByVal value As Boolean)
            m_b_IsSales = value
        End Set
    End Property

    Property s_Bank_ID() As String
        Get
            Return m_s_Bank_ID
        End Get
        Set(ByVal value As String)
            m_s_Bank_ID = value
        End Set
    End Property
    Property s_AccountID() As String
        Get
            Return m_s_AccountID
        End Get
        Set(ByVal value As String)
            m_s_AccountID = value
        End Set
    End Property
End Class
