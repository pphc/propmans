Imports ExceptionHandler

Module Main
    Public Sub Main()
        UnhandledExceptionManager.AddHandler()
        Dim frm As New UserLoginFOrm
        Application.Run(frm)

    End Sub
End Module


