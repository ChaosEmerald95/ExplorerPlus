Imports System.Runtime.InteropServices
Imports System.Text

Public Module StringResource
    'Dieses Modul ist nur solange von Nöten, bis eine Lösung unter C# existiert, die funktioniert

    Friend Declare Auto Function LoadLibrary Lib "kernel32.dll" (<MarshalAs(UnmanagedType.LPTStr), [In]()> ByVal lpFileName As String) As IntPtr
    Friend Declare Auto Function LoadString Lib "user32.dll" (ByVal hInstance As IntPtr, ByVal uID As Integer, <MarshalAs(UnmanagedType.LPTStr)> ByVal lpBuffer As System.Text.StringBuilder, ByVal nBufferMax As Integer) As Integer
    Friend Declare Function FreeLibrary Lib "kernel32.dll" (ByVal hModule As IntPtr) As Boolean
#Region "StringResourceLoad"
    Public Function GetStringResourceFromFile(dec As String) As String
        'Dateipfad ermitteln und alle Kommas entfernen
        dec = dec.Replace("@", "") 'Da manche ein @-Zeichen haben, muss es entfernt werden
        Dim np As String = dec.Substring(0, dec.LastIndexOf(","))
        Dim komman As Integer = Convert.ToInt32(dec.Substring(dec.LastIndexOf(",") + 1).Trim())
        Debug.Print(np)
        Debug.Print(komman.ToString())
        'Kein File.Exists, da auch Kommas im Pfad drin stecken
        Dim desc As String = ""
        Try
            Dim [lib] As IntPtr = LoadLibrary(np)
            Dim realnb As UInteger = CUInt(Math.Abs(komman))
            desc = GetStringResource([lib], realnb)
            Dim result As Integer = FreeLibrary([lib])
        Catch
        End Try
        Return desc
    End Function

    Private Function GetStringResource(handle As IntPtr, resourceId As UInteger) As String
        Dim buffer As New StringBuilder(8192)
        'Buffer for output from LoadString()
        Dim length As Integer = LoadString(handle, resourceId, buffer, buffer.Capacity)

        Return buffer.ToString(0, length)
        'Return the part of the buffer that was used.
    End Function
#End Region
End Module
