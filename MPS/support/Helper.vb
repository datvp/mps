Imports System
Imports System.Security.Cryptography
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Data.OleDb

Public NotInheritable Class Helper
    'Private Const KEY_SIZE As Integer = 2048
    'Private fOAEP As Boolean = False
    'Private rsaProvider As RSACryptoServiceProvider = Nothing
    'Public Const PUBLIC_KEY As String = "-----BEGIN PUBLIC KEY-----" & _
    '                                    "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAuzWwSWWMQ0H/KP8EWJRe" & _
    '                                    "MoA0K1N9s218chymcvACXtwAynPbekNlFPMybvbei4aDXJvslXvsT0+he0exr/ql" & _
    '                                    "48XAzYlt8mcsG6F09ty5ArNOALOSglgxC763RCDR+7qIcVDhZge4nbJcSBhK8DAu" & _
    '                                    "gfDo+eV0wQTE5Iry/useacvMKTuJ0f2ezfurob6FsZkEenCfanMUtTGt0v8dL5qe" & _
    '                                    "yqk4fBS58UixA/eOMRqMnyubr3OfJLoE/APguGbEjhZUj1hN5QbUBLCRbZIA1kFI" & _
    '                                    "gOuRRykekWIEeAjRNILbql6fS6Qv3o172Ze1dd+ZSpVs9U4wk/TLRClEKHLwNYKB" & _
    '                                    "zQIDAQAB" & _
    '                                    "-----END PUBLIC KEY-----"
    Private Const PRIVATE_KEY As String = "-----BEGIN RSA PRIVATE KEY-----" & _
                                        "Proc-Type: 4,ENCRYPTED" & _
                                        "DEK-Info: DES-EDE3-CBC,72BBB69B7C2FC7D5" & _
                                        "n6anwXafqslDW6JCh1mcrxVQKxOvclzTRc7+YVPFA5jeNLUKsZGVLajV03bgZdoz" & _
                                        "NNEGqdeUnlKiX7LAabf5MfzKXzfucMgdWRNRtQEpl3EKBUreyXw4K4OL8gMNqUKL" & _
                                        "7irnKjCUS9gGQWA+lhkGOCcFspLyKLmySJW+JPBXXQJsTYGYjY9FeHC9JWWKNl44" & _
                                        "A+q9SZCKG+G1nQ1SRgOJdTb61wONlOhHPByZRAuXL+E8i/8d1FyOvIBIjp0ZDwt6" & _
                                        "dJBq96SCbrc926hZMnoHutqLJjjf5VfTuLH1nLb8KTepRmgMASuHul8xLKa7TF4t" & _
                                        "0oWgzkBSUSQjScC60dK3lhdX3Yu2vhrSXAl5g29f282p4wxFmxCnqAdMfaKMsbBO" & _
                                        "7dl/5xwp6c8oWoL7oaPT3FgcoKMgBir124WihadPNlvNKmVUEDeYZqHGWi9Mk6sf" & _
                                        "sIrILzBHZUqJzzW8ZVCSi/MFvjckHojS8jPkJ7veyxGBeAIL7Jw3hx1IxSg6p/8U" & _
                                        "OBf7OG/p6wY22ktpGQAg2dDvJl7U18Nxa0rm3JMlFCNa6sbfZBKlRxvVCvStIZV2" & _
                                        "hCvh4YGZDWwELBvjZccSRD3Wma5ZU2ANpSN+10GKSzeZxmBAZjRvYjUfDExv4LRd" & _
                                        "B3uGFKhtJC8L6WgKB+OzpllGIDNvr0NwOcd6C9JTqYf0f1Uz4a2ErrsKn9FnF7kO" & _
                                        "40xYn5awFzfdYqFKH3bpcK8u9Ce5PYLOvYFHzeGKVgcq4FTBAzkYoRBEB5e16swR" & _
                                        "p8rpAgBuCFqCG6cOD9Rg7mzs3h4shEmqp3+3/D7+udc+mCESW0GlOZ4EfQbVqdQk" & _
                                        "NWwTJV3QzCqF359FgDuQASRGcgiUyliFAr9/iQceoPhR6YHmuaHgpljuWHR7HyEe" & _
                                        "aprxFzcbDBNpptWPEgNnLG7ZUCemFGVAukF6oXaUyhEJ3cQijB6tKgeVAiV5p/jw" & _
                                        "9GV0X0aiYvWmjcRwfokLW3dTyMJs7Rkfp0i0ysrav2l5Aw9qi2ZiqQzp206dcSPI" & _
                                        "nzoC6i3ASO7BkgXC13t9icvONVLAzPgoAUyONAX7KHihaS6ui4jwDynokFz69nsK" & _
                                        "g/2h6pa2wfF8Pl1NOim4k3QFZfNE3a9LNcmi8aJ2/BOhBIqbeFxk6UF+NJ/WcKDh" & _
                                        "JmLzBwkoJ9sNKMwBdzylbhdyWZA/8tSeTCnxxQQxI+i8Ldqk8jMysB9oZYOxrFYw" & _
                                        "W3+Xk3dSCzH06XrbiEIM5J1iXMwLCB/ZiyYgTHRAfmLq9iiqd7nlY/7vpyEEB6fD" & _
                                        "+QO5iRg6EB/4GWqlsnN/0JAOa6tQkCd9+eCtNBmV/9s27TpKsDx+wcJnK7pQ2+bF" & _
                                        "CWg54RV023Ohhaom5Eib3mpB0vO7dSMu28I0vj4veIpcP45TQOdU1s52dQ2K8vRn" & _
                                        "3OMSQdGkrM6JAZInMlKyqSEv0i4dLiaXvDn/0OEwr5h1NIMXqiEvaozDTGRbDo5Z" & _
                                        "r65Ne3ZkaGeRta4V51GYBlVgsNWSy7n5uW7tTGXbTcVfJMOROoNtMIg43ajiLwW5" & _
                                        "HQdjEe01JEsSqKxYmcg79RQC3LjGWVr5h+aprUDeAPtr3k1HKN7uKw==" & _
                                        "-----END RSA PRIVATE KEY-----"

    Public Sub New()
    End Sub
    'Private Function GetCspParameters() As CspParameters
    '    Dim cspParams As CspParameters = New CspParameters()
    '    cspParams.ProviderType = 1
    '    cspParams.KeyNumber = CInt(KeyNumber.Exchange)
    '    Return cspParams
    'End Function

    'Public Function GetMaxDataLength() As Integer
    '    If fOAEP Then Return ((KEY_SIZE - 384) / 8) + 7
    '    Return ((KEY_SIZE - 384) / 8) + 37
    'End Function
    'Public Shared Function IsKeySizeValid() As Boolean
    '    Return KEY_SIZE >= 384 AndAlso KEY_SIZE <= 16384 AndAlso KEY_SIZE Mod 8 = 0
    'End Function

    'Public Sub GenerateKeys(<Out()> ByRef publicKey As String, <Out()> ByRef privateKey As String)
    '    Try
    '        Dim cspParams As CspParameters = GetCspParameters()
    '        cspParams.Flags = CspProviderFlags.UseArchivableKey
    '        rsaProvider = New RSACryptoServiceProvider(KEY_SIZE, cspParams)
    '        publicKey = rsaProvider.ToXmlString(False)
    '        privateKey = rsaProvider.ToXmlString(True)
    '    Catch ex As Exception
    '        Throw New Exception("Exception generating a new RSA key pair! More info: " & ex.Message)
    '    Finally
    '    End Try
    'End Sub
    'Public Function Encrypt(ByVal publicKey As String, ByVal plainText As String) As String
    '    If plainText = "" Then Throw New ArgumentException("Data are empty")
    '    Dim maxLength As Integer = GetMaxDataLength()
    '    If Encoding.Unicode.GetBytes(plainText).Length > maxLength Then Throw New ArgumentException("Maximum data length is " & maxLength / 2)
    '    If Not IsKeySizeValid() Then Throw New ArgumentException("Key size is not valid")
    '    If publicKey = "" Then Throw New ArgumentException("Key is null or empty")
    '    Dim plainBytes As Byte() = Nothing
    '    Dim encryptedBytes As Byte() = Nothing
    '    Dim encryptedText As String = ""
    '    Dim keyXml = "<RSAKeyValue><Modulus>" + publicKey + "</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"
    '    Try
    '        Dim cspParams As CspParameters = GetCspParameters()
    '        cspParams.Flags = CspProviderFlags.NoFlags
    '        rsaProvider = New RSACryptoServiceProvider(KEY_SIZE, cspParams)
    '        rsaProvider.FromXmlString(keyXml)
    '        plainBytes = Encoding.Unicode.GetBytes(plainText)
    '        encryptedBytes = rsaProvider.Encrypt(plainBytes, False)
    '        encryptedText = Convert.ToBase64String(encryptedBytes)
    '    Catch ex As Exception
    '        Throw New Exception("Exception encrypting file! More info: " & ex.Message)
    '    Finally
    '    End Try

    '    Return encryptedText
    'End Function

    'Public Function Decrypt(ByVal privateKey As String, ByVal encryptedText As String) As String
    '    If encryptedText = "" Then Throw New ArgumentException("Data are empty")
    '    If Not IsKeySizeValid() Then Throw New ArgumentException("Key size is not valid")
    '    If privateKey = "" Then Throw New ArgumentException("Key is null or empty")
    '    Dim encryptedBytes As Byte() = Nothing
    '    Dim plainBytes As Byte() = Nothing
    '    Dim plainText As String = ""

    '    Try
    '        Dim cspParams As CspParameters = GetCspParameters()
    '        cspParams.Flags = CspProviderFlags.NoFlags
    '        rsaProvider = New RSACryptoServiceProvider(KEY_SIZE, cspParams)
    '        rsaProvider.FromXmlString(privateKey)
    '        encryptedBytes = Convert.FromBase64String(encryptedText)
    '        plainBytes = rsaProvider.Decrypt(encryptedBytes, False)
    '        plainText = Encoding.Unicode.GetString(plainBytes)
    '    Catch ex As Exception
    '        Throw New Exception("Exception decrypting file! More info: " & ex.Message)
    '    Finally
    '    End Try

    '    Return plainText
    'End Function

    'Public Function GenerateKeys() As String
    '    Dim RSA As RSACryptography = New RSACryptography()
    '    Dim publicKey, privateKey As String
    '    RSA.GenerateKeys(publicKey, privateKey)
    '    Dim plainText As String = "93f99709-ce56-42a9-af7e-1d72c011c2dd"
    '    Dim encryptedText As String = RSA.Encrypt(publicKey, plainText)
    '    Dim decryptedText As String = RSA.Decrypt(privateKey, encryptedText)
    '    Return "Encrypt:" & encryptedText & " | Decrypt: " & decryptedText
    'End Function
    Private Const KEY_SIZE As Integer = 256
    Private Const KEY_SALT As String = "@v0$pH@t!D@T%iYc"

    Public Shared Function Encrypt(ByVal plainText As String) As String
        Try
            Dim plainTextBytes As Byte() = Encoding.UTF8.GetBytes(plainText)
            'Dim password As PasswordDeriveBytes = New PasswordDeriveBytes(passPhrase, Nothing)
            Dim salt As Byte() = Encoding.UTF8.GetBytes(KEY_SALT)
            Dim password As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(PRIVATE_KEY, salt)
            Dim keyBytes As Byte() = password.GetBytes(KEY_SIZE / 8)

            Dim symmetricKey As RijndaelManaged = New RijndaelManaged()
            symmetricKey.Mode = CipherMode.CBC
            Dim encryptor As ICryptoTransform = symmetricKey.CreateEncryptor(keyBytes, salt)
            Dim memoryStream As IO.MemoryStream = New IO.MemoryStream()
            Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)
            cryptoStream.FlushFinalBlock()
            Dim cipherTextBytes As Byte() = memoryStream.ToArray()
            memoryStream.Close()
            cryptoStream.Close()
            Return Convert.ToBase64String(cipherTextBytes)
        Catch ex As Exception
            ShowMsg(ex.Message)
            Return ""
        End Try
    End Function

    Public Shared Function Decrypt(ByVal cipherText As String) As String
        Try
            Dim cipherTextBytes As Byte() = Convert.FromBase64String(cipherText)
            'Dim password As PasswordDeriveBytes = New PasswordDeriveBytes(passPhrase, Nothing)
            Dim salt As Byte() = Encoding.UTF8.GetBytes(KEY_SALT)
            Dim password As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(PRIVATE_KEY, salt)
            Dim keyBytes As Byte() = password.GetBytes(KEY_SIZE / 8)

            Dim symmetricKey As RijndaelManaged = New RijndaelManaged()
            symmetricKey.Mode = CipherMode.CBC
            Dim decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(keyBytes, salt)
            Dim memoryStream As IO.MemoryStream = New IO.MemoryStream(cipherTextBytes)
            Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
            Dim plainTextBytes As Byte() = New Byte(cipherTextBytes.Length - 1) {}
            Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
            memoryStream.Close()
            cryptoStream.Close()
            Return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount)
        Catch ex As Exception
            ShowMsg("Decrypt error: " & ex.Message)
            Return ""
        End Try
    End Function
    ''' <summary>
    ''' Nhập từ Excel
    ''' </summary>
    ''' <param name="path"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ImportFromExcel(ByVal path As String) As DataTable
        Dim tb As DataTable = Nothing

        Dim strCon = "provider=microsoft.ace.oledb.12.0;data source=" + path + ";extended properties=""excel 12.0;hdr=yes;"" "

        Try
            Using con As New OleDbConnection(strCon)
                con.Open()
                Dim dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    Dim sheetName = dt.Rows(0)("TABLE_NAME").ToString
                    Dim cmd = New OleDbCommand("SELECT * FROM [" + sheetName + "]", con)
                    Using da As New OleDbDataAdapter(cmd)
                        tb = New DataTable
                        da.Fill(tb)
                    End Using
                End If
                con.Close()
            End Using
        Catch ex As Exception
            ShowMsg(ex.Message)
        End Try

        Return tb
    End Function
End Class
