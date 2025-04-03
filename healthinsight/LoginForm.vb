Imports MySql.Data.MySqlClient

Public Class LoginForm
    Private connectionString As String = "server=localhost;userid=root;password=Kanha*#0100;database=healthinsights"

    ' Function to retrieve user ID from database
    Private Function GetUserIdFromDatabase(username As String, password As String) As Integer
        Dim userId As Integer = -1 ' Default if user not found
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT userid FROM users WHERE email = @username AND password = @password"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@password", password)

                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        userId = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching user ID: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return userId
    End Function

    ' Login Button Click Event
    Private Sub Guna2GradientTileButton2_Click(sender As Object, e As EventArgs) Handles Guna2GradientTileButton2.Click
        ' Get input values
        Dim username As String = Guna2TextBox1.Text.Trim()
        Dim password As String = Guna2TextBox2.Text.Trim()

        ' Validate inputs
        If username = "" OrElse password = "" Then
            MessageBox.Show("Please enter both username and password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT userid FROM users WHERE username = @username AND password = @password"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@password", password)

                    Dim reader As MySqlDataReader = cmd.ExecuteReader()

                    If reader.Read() Then
                        ' Retrieve and store the logged-in user ID globally
                        LoggedInUserId = Convert.ToInt32(reader("userid"))
                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Open the Body Part selection form
                        Dim bodypartForm As New bodypart(LoggedInUserId)
                        bodypartForm.Show()
                        Me.Hide()
                    Else
                        MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Guna2GradientTileButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientTileButton1.Click
        Dim reg As New RegisterForm()
        reg.Show()
        Me.Hide()
    End Sub

    Private Sub LinkLabel1_Click(sender As Object, e As EventArgs) Handles LinkLabel1.Click
        ' Step 1: Get the user's email
        Dim email As String = InputBox("Enter your registered email:", "Forgot Password")

        ' Validate email input
        If String.IsNullOrWhiteSpace(email) Then
            MessageBox.Show("Email cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Step 2: Check if the email exists
                Dim checkQuery As String = "SELECT userid FROM users WHERE email = @Email"
                Using checkCmd As New MySqlCommand(checkQuery, conn)
                    checkCmd.Parameters.AddWithValue("@Email", email)

                    Dim result = checkCmd.ExecuteScalar()
                    If result Is Nothing Then
                        MessageBox.Show("Email not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                End Using

                ' Step 3: Get new password from user
                Dim newPassword As String = InputBox("Enter your new password:", "Reset Password")

                ' Validate password input
                If String.IsNullOrWhiteSpace(newPassword) Then
                    MessageBox.Show("Password cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                ' Step 4: Update the password in the database
                Dim updateQuery As String = "UPDATE users SET password = @NewPassword WHERE email = @Email"
                Using updateCmd As New MySqlCommand(updateQuery, conn)
                    updateCmd.Parameters.AddWithValue("@NewPassword", newPassword)
                    updateCmd.Parameters.AddWithValue("@Email", email)

                    Dim rowsAffected As Integer = updateCmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Failed to update password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class

