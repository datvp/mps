﻿Public Class MSubContractor
    Private m_SubContractorId As String = ""
    Public Property SubContractorId() As String
        Get
            Return m_SubContractorId
        End Get
        Set(ByVal value As String)
            m_SubContractorId = value
        End Set
    End Property


    Private m_SubContractorName As String = ""
    Public Property SubContractorName() As String
        Get
            Return m_SubContractorName
        End Get
        Set(ByVal value As String)
            m_SubContractorName = value
        End Set
    End Property

    Private m_ShortName As String = ""
    Public Property ShortName() As String
        Get
            Return m_ShortName
        End Get
        Set(ByVal value As String)
            m_ShortName = value
        End Set
    End Property

    Private m_Address As String = ""
    Public Property Address() As String
        Get
            Return m_Address
        End Get
        Set(ByVal value As String)
            m_Address = value
        End Set
    End Property

    Private m_Phone As String = ""
    Public Property Phone() As String
        Get
            Return m_Phone
        End Get
        Set(ByVal value As String)
            m_Phone = value
        End Set
    End Property

    Private m_Email As String = ""
    Public Property Email() As String
        Get
            Return m_Email
        End Get
        Set(ByVal value As String)
            m_Email = value
        End Set
    End Property

    Private m_ContactName As String = ""
    Public Property ContactName() As String
        Get
            Return m_ContactName
        End Get
        Set(ByVal value As String)
            m_ContactName = value
        End Set
    End Property

    Private m_ContactPhone As String = ""
    Public Property ContactPhone() As String
        Get
            Return m_ContactPhone
        End Get
        Set(ByVal value As String)
            m_ContactPhone = value
        End Set
    End Property

    Private m_ContactEmail As String = ""
    Public Property ContactEmail() As String
        Get
            Return m_ContactEmail
        End Get
        Set(ByVal value As String)
            m_ContactEmail = value
        End Set
    End Property

    Private m_Note As String = ""
    Public Property Note() As String
        Get
            Return m_Note
        End Get
        Set(ByVal value As String)
            m_Note = value
        End Set
    End Property

    Private m_CreatedAt As Date = CDate("2000-1-1")
    Public Property CreatedAt() As Date
        Get
            Return m_CreatedAt
        End Get
        Set(ByVal value As Date)
            m_CreatedAt = value
        End Set
    End Property

    Private m_UpdatedAt As Date = CDate("2000-1-1")
    Public Property UpdatedAt() As Date
        Get
            Return m_UpdatedAt
        End Get
        Set(ByVal value As Date)
            m_UpdatedAt = value
        End Set
    End Property
End Class
