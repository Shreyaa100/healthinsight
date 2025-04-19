Imports MySql.Data.MySqlClient

Public Class bodypart
    Private connectionString As String = "server=localhost;userid=root;password=Kanha*#0100;database=healthinsights"
    Private LoggedInUserId As Integer
    Private selectedBodyPart As String = ""

    Public Sub New(userId As Integer)
        InitializeComponent()
        LoggedInUserId = userId
    End Sub

    Private Sub HighlightSelectedButton(selectedBtn As Guna.UI2.WinForms.Guna2Button)
        Dim allButtons As Guna.UI2.WinForms.Guna2Button() = {
            Guna2Button3, Guna2Button4, Guna2Button5,
            Guna2Button6, Guna2Button7, Guna2Button8
        }

        For Each btn In allButtons
            btn.FillColor = Color.LightGray
            btn.ForeColor = Color.White
        Next

        selectedBtn.FillColor = Color.DeepSkyBlue
        selectedBtn.ForeColor = Color.White
    End Sub

    Private Sub LoadQuestionsByBodyPart(bodypartName As String)
        selectedBodyPart = bodypartName
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "
                    SELECT q.question1, q.question2, q.question3, q.question4, b.bodypart_id
                    FROM questionnaire q
                    JOIN bodypart b ON q.bodypart_id = b.bodypart_id
                    WHERE b.bodypart_name = @bodypart"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@bodypart", bodypartName)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Label3.Text = reader("question1").ToString()
                            Label4.Text = reader("question2").ToString()
                            Label5.Text = reader("question3").ToString()
                            Label6.Text = reader("question4").ToString()

                            Label2.Visible = True
                            Label3.Visible = True
                            Label4.Visible = True
                            Label5.Visible = True
                            Label6.Visible = True

                            CheckBox1.Visible = True
                            CheckBox2.Visible = True
                            CheckBox3.Visible = True
                            CheckBox4.Visible = True
                            CheckBox5.Visible = True
                            CheckBox6.Visible = True
                            CheckBox7.Visible = True
                            CheckBox8.Visible = True
                        Else
                            MessageBox.Show("No questions found for this body part.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching questions: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Guna2Button_BodyPart_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click, Guna2Button4.Click, Guna2Button5.Click, Guna2Button6.Click, Guna2Button7.Click, Guna2Button8.Click
        Dim clickedButton As Guna.UI2.WinForms.Guna2Button = DirectCast(sender, Guna.UI2.WinForms.Guna2Button)
        Dim bodyPartName As String = clickedButton.Text.Trim()

        HighlightSelectedButton(clickedButton)
        LoadQuestionsByBodyPart(bodyPartName)
    End Sub

    Private Function GetBodyPartId(bodypartName As String) As Integer
        Dim bodypartId As Integer = -1
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT bodypart_id FROM bodypart WHERE bodypart_name = @name"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@name", bodypartName)
                    bodypartId = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching body part ID: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return bodypartId
    End Function

    Private Function GetQuestionnaireId(bodypartId As Integer) As Integer
        Dim questionId As Integer = -1
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT question_id FROM questionnaire WHERE bodypart_id = @bodypart_id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@bodypart_id", bodypartId)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        questionId = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching question ID: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return questionId
    End Function

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        If String.IsNullOrEmpty(selectedBodyPart) Then
            MessageBox.Show("Please select a body part before submitting!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim bodypartId As Integer = GetBodyPartId(selectedBodyPart)
        Dim userId As Integer = LoggedInUserId
        Dim questionId As Integer = GetQuestionnaireId(bodypartId)

        Dim quest1 As Boolean = CheckBox1.Checked
        Dim quest2 As Boolean = CheckBox3.Checked
        Dim quest3 As Boolean = CheckBox5.Checked
        Dim quest4 As Boolean = CheckBox7.Checked

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "INSERT INTO user_answer (userid, question_id, quest1, quest2, quest3, quest4) 
                                       VALUES (@userid, @question_id, @quest1, @quest2, @quest3, @quest4)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userid", userId)
                    cmd.Parameters.AddWithValue("@question_id", questionId)
                    cmd.Parameters.AddWithValue("@quest1", quest1)
                    cmd.Parameters.AddWithValue("@quest2", quest2)
                    cmd.Parameters.AddWithValue("@quest3", quest3)
                    cmd.Parameters.AddWithValue("@quest4", quest4)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Responses saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MoveToDiagnosis()
        Catch ex As Exception
            MessageBox.Show("Error saving responses: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MoveToDiagnosis()
        If String.IsNullOrEmpty(selectedBodyPart) Then
            MessageBox.Show("Please select a body part!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim userId As Integer = LoggedInUserId
        Dim bodypartId As Integer = GetBodyPartId(selectedBodyPart)
        Dim questions As List(Of String) = GetQuestionsByBodyPartId(bodypartId)

        If questions.Count < 4 Then
            MessageBox.Show("Not enough questions found for this body part!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim diagForm As New diagnosis(userId, selectedBodyPart)
        diagForm.Show()
        Me.Hide()
    End Sub

    Private Function GetQuestionsByBodyPartId(bodypartId As Integer) As List(Of String)
        Dim questions As New List(Of String)
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT question1, question2, question3, question4 FROM questionnaire WHERE bodypart_id = @bodypart_id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@bodypart_id", bodypartId)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            questions.Add(reader("question1").ToString())
                            questions.Add(reader("question2").ToString())
                            questions.Add(reader("question3").ToString())
                            questions.Add(reader("question4").ToString())
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching questions: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return questions
    End Function
End Class
