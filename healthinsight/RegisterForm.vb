Public Class RegisterForm
    Inherits System.Windows.Forms.Form

    Private Sub RegisterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set up form
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Set password TextBox to use password char initially
        If Guna2TextBox2 IsNot Nothing Then
            Guna2TextBox2.UseSystemPasswordChar = True
        End If

        ' Set initial focus to username field
        If Guna2TextBox1 IsNot Nothing Then
            Guna2TextBox1.Focus()
        End If
    End Sub
    Private Sub Guna2GradientTileButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientTileButton1.Click
        ' Go back to login page
        Try
            Dim loginForm As New LoginForm()
            loginForm.Show()
            Me.Hide() ' Hide instead of closing
        Catch ex As Exception
            MessageBox.Show("Error opening Login Form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Guna2GradientTileButton2_Click(sender As Object, e As EventArgs) Handles Guna2GradientTileButton2.Click
        ' Save registration details to database

        ' Get values from form controls
        Dim username As String = If(Guna2TextBox1 IsNot Nothing, Guna2TextBox1.Text.Trim(), "")
        Dim password As String = If(Guna2TextBox2 IsNot Nothing, Guna2TextBox2.Text, "")
        Dim email As String = If(Guna2TextBox3 IsNot Nothing, Guna2TextBox3.Text.Trim(), "")
        Dim phoneNumber As String = If(Guna2TextBox4 IsNot Nothing, Guna2TextBox4.Text.Trim(), "")

        ' Get gender selection
        Dim gender As String = ""
        If RadioButton1 IsNot Nothing AndAlso RadioButton1.Checked Then
            gender = "Male"
        ElseIf RadioButton2 IsNot Nothing AndAlso RadioButton2.Checked Then
            gender = "Female"
        End If

        ' Validate inputs
        If String.IsNullOrEmpty(username) OrElse
           String.IsNullOrEmpty(password) OrElse
           String.IsNullOrEmpty(email) OrElse
           String.IsNullOrEmpty(phoneNumber) OrElse
           String.IsNullOrEmpty(gender) Then

            MessageBox.Show("All fields are required.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate email format
        If Not IsValidEmail(email) Then
            MessageBox.Show("Please enter a valid email address.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If Guna2TextBox3 IsNot Nothing Then
                Guna2TextBox3.Focus()
            End If
            Return
        End If

        ' Validate phone number format (basic check)
        If Not IsValidPhoneNumber(phoneNumber) Then
            MessageBox.Show("Please enter a valid phone number.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If Guna2TextBox4 IsNot Nothing Then
                Guna2TextBox4.Focus()
            End If
            Return
        End If

        ' Store user in database
        If RegisterUser(username, password, email, phoneNumber, gender) Then
            MessageBox.Show("Registration successful! You can now login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Navigate to login form
            Try
                Dim loginForm As Form = New LoginForm()
                loginForm.Show()
                Me.Close()
            Catch ex As Exception
                MessageBox.Show("Error opening Login Form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' Email validation function
    Private Function IsValidEmail(email As String) As Boolean
        If String.IsNullOrEmpty(email) Then Return False

        Try
            Dim addr As New System.Net.Mail.MailAddress(email)
            Return addr.Address = email
        Catch
            Return False
        End Try
    End Function

    ' Basic phone number validation
    Private Function IsValidPhoneNumber(phoneNumber As String) As Boolean
        If String.IsNullOrEmpty(phoneNumber) Then Return False

        ' This is a basic check - modify as needed for your specific requirements
        Return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, "^\d{10}$")
    End Function

    ' This is a placeholder method until you create your database
    Private Function RegisterUser(username As String, password As String, email As String, phoneNumber As String, gender As String) As Boolean
        ' TEMPORARY: For testing purposes only
        ' Replace this with actual database registration later
        MessageBox.Show("User would be registered in database with:" & vbCrLf &
                       "Username: " & username & vbCrLf &
                       "Email: " & email & vbCrLf &
                       "Phone: " & phoneNumber & vbCrLf &
                       "Gender: " & gender, "Database Registration", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Return True
    End Function
End Class

