Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class RegisterForm
    Private connectionString As String = "server=localhost;userid=root;password=Kanha*#0100;database=healthinsights"
    Private passwordVisible As Boolean = False
    Private confirmPasswordVisible As Boolean = False

    ' Declare ErrorProvider
    Private Sub RegisterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set default password masking
        Guna2TextBox2.PasswordChar = "*"c
        Guna2TextBox5.PasswordChar = "*"c

        ' Initial visibility of icons
        PictureBox2.Visible = False ' eye off for password
        PictureBox3.Visible = False ' eye off for confirm password
    End Sub

    Private Sub Guna2GradientTileButton2_Click(sender As Object, e As EventArgs) Handles Guna2GradientTileButton2.Click
        ' Get input values
        Dim username As String = Guna2TextBox1.Text.Trim()
        Dim email As String = Guna2TextBox3.Text.Trim()
        Dim phoneno As String = Guna2TextBox4.Text.Trim()
        Dim password As String = Guna2TextBox2.Text.Trim()
        Dim confirmPassword As String = Guna2TextBox5.Text.Trim()
        Dim gender As String = If(RadioButton1.Checked, "Male", "Female")

        ' Inline ErrorProvider
        ErrorProvider1.Clear()
        Dim hasError As Boolean = False

        If username = "" Then
            ErrorProvider1.SetError(Guna2TextBox1, "Username is required.")
            hasError = True
        End If

        If email = "" OrElse Not Regex.IsMatch(email, "^[^@\s]+@[^@\s]+\.[^@\s]+$") Then
            ErrorProvider1.SetError(Guna2TextBox3, "Enter a valid email.")
            hasError = True
        End If

        If Not Regex.IsMatch(phoneno, "^\d{10}$") Then
            ErrorProvider1.SetError(Guna2TextBox4, "Enter a valid 10-digit phone number.")
            hasError = True
        End If

        If Not Regex.IsMatch(password, "^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$") Then
            ErrorProvider1.SetError(Guna2TextBox2, "Password must be 6+ chars, include number and special character.")
            hasError = True
        End If

        If password <> confirmPassword Then
            ErrorProvider1.SetError(Guna2TextBox5, "Passwords do not match.")
            hasError = True
        End If

        If hasError Then Return

        ' Insert into database
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "INSERT INTO users (username, email, phoneno, password, gender) VALUES (@username, @email, @phoneno, @password, @gender)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@email", email)
                    cmd.Parameters.AddWithValue("@phoneno", phoneno)
                    cmd.Parameters.AddWithValue("@password", password)
                    cmd.Parameters.AddWithValue("@gender", gender)

                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Navigate to Login Form
                    Me.Hide()
                    Dim loginForm As New LoginForm()
                    loginForm.Show()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Guna2GradientTileButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientTileButton1.Click
        Dim loginForm As New LoginForm()
        loginForm.Show()
        Me.Hide()
    End Sub

    ' Show password
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Guna2TextBox2.PasswordChar = ControlChars.NullChar
        PictureBox4.Visible = False
        PictureBox2.Visible = True
    End Sub

    ' Hide password
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Guna2TextBox2.PasswordChar = "*"c
        PictureBox2.Visible = False
        PictureBox4.Visible = True
    End Sub

    ' Show confirm password
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Guna2TextBox5.PasswordChar = ControlChars.NullChar
        PictureBox5.Visible = False
        PictureBox3.Visible = True
    End Sub

    ' Hide confirm password
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Guna2TextBox5.PasswordChar = "*"c
        PictureBox3.Visible = False
        PictureBox5.Visible = True
    End Sub
End Class

