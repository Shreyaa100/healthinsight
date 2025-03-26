Public Class SplashScreen
    Private progress As Integer = 0

    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set initial properties for the picture box
        Guna2PictureBox1.Visible = True

        ' Start Guna2ProgressIndicator animation
        ProgressBar1.Start()

        ' Configure the Timer
        Timer1.Interval = 30 ' 30 milliseconds for animation
        Timer1.Enabled = True
        Timer1.Start()

        ' Ensure the splash screen is shown centered
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Increment our counter
        progress += 1

        ' When progress reaches 100, move to login form (about 3 seconds)
        If progress >= 100 Then
            ' Stop the timer
            Timer1.Stop()
            Timer1.Enabled = False

            ' Stop the progress indicator animation
            ProgressBar1.Stop()

            ' Create and show the login form
            Dim loginForm As New LoginForm()
            loginForm.Show()

            ' Hide the splash screen
            Me.Hide()
        End If
    End Sub
End Class
