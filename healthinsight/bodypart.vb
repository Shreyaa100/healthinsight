Imports MySql.Data.MySqlClient

Public Class bodypart
    Private connectionString As String = "server=localhost;userid=root;password=Kanha*#0100;database=healthinsights"

    ' Declare LoggedInUserId as a private variable
    Private LoggedInUserId As Integer

    ' Constructor to accept user ID from the login form
    Public Sub New(userId As Integer)
        InitializeComponent()  ' Required for Windows Form Designer
        LoggedInUserId = userId ' Assign the user ID
    End Sub
    Private Function UserExists(userId As Integer) As Boolean
        Dim exists As Boolean = False
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT COUNT(*) FROM users WHERE userid = @userid"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userid", userId)
                    exists = Convert.ToInt32(cmd.ExecuteScalar()) > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking user existence: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return exists
    End Function


    ' Function to load body parts into ComboBox1 from database
    Private Sub LoadBodyParts()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT bodypart_name FROM bodypart"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            ComboBox1.Items.Add(reader("bodypart_name").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading body parts: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ' Button Click Event - Fetch Questions based on selected Body Part
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        ' Get selected body part
        Dim selectedBodyPart As String = ComboBox1.SelectedItem?.ToString()

        ' Check if a body part is selected
        If String.IsNullOrEmpty(selectedBodyPart) Then
            MessageBox.Show("Please select a body part!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' SQL query to get questions for selected body part
                Dim query As String = "SELECT q.question1, q.question2, q.question3, q.question4, b.bodypart_id
                                   FROM questionnaire q
                                   JOIN bodypart b ON q.bodypart_id = b.bodypart_id
                                   WHERE b.bodypart_name = @bodypart"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@bodypart", selectedBodyPart)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Assign questions to labels
                            Label3.Text = reader("question1").ToString()
                            Label4.Text = reader("question2").ToString()
                            Label5.Text = reader("question3").ToString()
                            Label6.Text = reader("question4").ToString()

                            ' Store the bodypart_id for further processing
                            Dim selectedBodyPartId As Integer = Convert.ToInt32(reader("bodypart_id"))

                            ' Show labels and checkboxes
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

    ' Function to get current logged-in user ID
    Private Function GetCurrentUserId() As Integer
        ' Assuming you store logged-in user ID in a global variable
        Return LoggedInUserId
    End Function

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        ' Ensure a body part is selected
        If String.IsNullOrEmpty(ComboBox1.SelectedItem?.ToString()) Then
            MessageBox.Show("Please select a body part before submitting!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get selected body part ID
        Dim bodypartId As Integer = GetBodyPartId(ComboBox1.SelectedItem.ToString())

        ' Get logged-in user ID
        Dim userId As Integer = GetCurrentUserId()

        ' Validate user ID
        If userId = -1 Then
            MessageBox.Show("Error: User not logged in!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Get Question ID (Assuming one questionnaire per body part)
        Dim questionId As Integer = GetQuestionnaireId(bodypartId)

        ' Check which checkboxes are selected (True/False)
        Dim quest1 As Boolean = CheckBox1.Checked ' True if checked, False if unchecked
        Dim quest2 As Boolean = CheckBox3.Checked
        Dim quest3 As Boolean = CheckBox5.Checked
        Dim quest4 As Boolean = CheckBox7.Checked

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Insert user answers into the database
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
    Private Sub MoveToDiagnosis()
        If String.IsNullOrEmpty(ComboBox1.SelectedItem?.ToString()) Then
            MessageBox.Show("Please select a body part!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get selected body part name
        Dim selectedBodyPart As String = ComboBox1.SelectedItem.ToString()

        ' Get logged-in user ID
        Dim userId As Integer = LoggedInUserId

        ' Get bodypart_id from the selected body part name
        Dim bodypartId As Integer = GetBodyPartId(selectedBodyPart)

        ' Get questions from the database
        Dim questions As List(Of String) = GetQuestionsByBodyPartId(bodypartId)

        If questions.Count < 4 Then
            MessageBox.Show("Not enough questions found for this body part!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim allQuestions As String = String.Join(vbCrLf, questions(0), questions(1), questions(2), questions(3))
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
