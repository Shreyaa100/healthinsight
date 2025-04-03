Imports MySql.Data.MySqlClient

Public Class RegisterForm
    Private connectionString As String = "server=localhost;userid=root;password=Kanha*#0100;database=healthinsights"

    Private Sub Guna2GradientTileButton2_Click(sender As Object, e As EventArgs) Handles Guna2GradientTileButton2.Click
        ' Get input values
        Dim username As String = Guna2TextBox1.Text.Trim()
        Dim email As String = Guna2TextBox3.Text.Trim()
        Dim phoneno As String = Guna2TextBox4.Text.Trim()
        Dim password As String = Guna2TextBox2.Text.Trim()
        Dim gender As String = If(RadioButton1.Checked, "Male", "Female")

        ' Validate inputs
        If username = "" OrElse email = "" OrElse phoneno = "" OrElse password = "" Then
            MessageBox.Show("All fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

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
End Class

