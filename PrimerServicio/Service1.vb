Public Class Service1
    Public TimerServicio As New Timers.Timer

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Agregue el código aquí para iniciar el servicio. Este método debería poner
        ' en movimiento los elementos para que el servicio pueda funcionar.
        TimerServicio = New Timers.Timer
        AddHandler TimerServicio.Elapsed, AddressOf EjecutaUnaAccion
        TimerServicio.Interval = 6000
        TimerServicio.Start()
    End Sub

    Public Function EjecutaUnaAccion()
        Dim i As Integer
        For i = 1 To 1000
            My.Computer.FileSystem.WriteAllText("D:\INFORME.TXT", "LINEA: " & i & vbCrLf,
           True)
        Next
    End Function
    Protected Overrides Sub OnStop()
        TimerServicio.Close()
    End Sub
    Protected Overrides Sub OnPause()
        TimerServicio.Stop()
    End Sub

    Protected Overrides Sub OnContinue()
        TimerServicio.Start()
    End Sub

End Class
