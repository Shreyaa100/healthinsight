Public Class LoginForm
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set up form
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Set password TextBox to use password char
        Guna2TextBox2.UseSystemPasswordChar = True

        ' Set initial focus to username field
        Guna2TextBox1.Focus()
    End Sub

    Private Sub Guna2GradientTileButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientTileButton1.Click
        ' Open registration form when "Don't have an account? Register" button is clicked
        ' Make sure RegistrationForm exists first
        Try
            ' Fix: Make sure RegistrationForm is properly referenced
            ' The error likely comes from the RegistrationForm instantiation
            If GetType(RegisterForm) IsNot Nothing Then
                Dim registrationForm As Form = New RegisterForm()
                registrationForm.Show()
                Me.Hide()
            Else
                MessageBox.Show("Registration Form class not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Could not open Registration Form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' If you don't have a btnLogin control on your form, create one or modify this to match your control
    ' Remove the "Handles btnLogin.Click" if you don't have a btnLogin control
    Private Sub btnLogin_Click(sender As Object, e As EventArgs)
        ' Get values from text boxes
        Dim username As String = Guna2TextBox1.Text.Trim()
        Dim password As String = Guna2TextBox2.Text

        ' Basic validation
        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Call verification method
        If VerifyUser(username, password) Then
            ' Successful login
            MessageBox.Show("Login successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Since MainForm doesn't exist yet, we'll just display a message
            MessageBox.Show("Login successful! MainForm would open here.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' When you create MainForm, uncomment these lines:
            ' Dim mainForm As New MainForm()
            ' mainForm.Show()
            ' Me.Hide()
        Else
            ' Failed login
            MessageBox.Show("Invalid username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Guna2TextBox2.Clear()
            Guna2TextBox2.Focus()
        End If
    End Sub

    ' This is a placeholder method until you create your database
    Private Function VerifyUser(username As String, password As String) As Boolean
        ' TEMPORARY: For testing purposes only
        ' Replace this with actual database verification later
        ' For now, accept "admin" / "password" as valid credentials
        Return (username = "admin" And password = "password")
    End Function

    ' Optional: Add this if you want to press Enter key to login
    Private Sub Guna2TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Guna2TextBox2.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True ' Prevent the ding sound
            btnLogin_Click(sender, New EventArgs())
        End If
    End Sub
End Class