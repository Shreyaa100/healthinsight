Imports MySql.Data.MySqlClient

Public Class recommendation
    Dim connStr As String = "server=localhost;userid=root;password=Kanha*#0100;database=healthinsights"
    Dim conn As New MySqlConnection(connStr)

    Private Sub recommendation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDiagnosisResults()
    End Sub

    Private Sub LoadDiagnosisResults()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd As New MySqlCommand("SELECT result_id, disease_name FROM diagnosis_result", conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            Guna2ComboBox1.Items.Clear()

            While reader.Read()
                Dim item As String = reader("result_id").ToString() & " - " & reader("disease_name").ToString()
                Guna2ComboBox1.Items.Add(item)
            End While

            reader.Close()
            conn.Close()

            ' ✅ Automatically select the first item
            If Guna2ComboBox1.Items.Count > 0 Then
                Guna2ComboBox1.SelectedIndex = 0
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub Guna2ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Guna2ComboBox1.SelectedIndexChanged
        If Guna2ComboBox1.SelectedIndex <> -1 Then
            Dim selectedItem As String = Guna2ComboBox1.SelectedItem.ToString()
            Dim resultId As Integer = CInt(selectedItem.Split("-"c)(0).Trim())
            LoadRecommendations(resultId)
        End If
    End Sub

    Private Sub LoadRecommendations(resultId As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String = "SELECT recommendation_type AS 'Type', recommendation_text AS 'Details' FROM recommendations WHERE result_id = @result_id"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@result_id", resultId)

            ' Use a data adapter to fill a DataTable
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            ' Bind the result to the DataGridView
            Guna2DataGridView1.DataSource = dt

            ' ✅ Resize and style the DataGridView for clean display
            Guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Guna2DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            Guna2DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            Guna2DataGridView1.ReadOnly = True
            Guna2DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            Guna2DataGridView1.DefaultCellStyle.Font = New Font("Segoe UI", 10)

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim dash As New Dashboard()
        dash.Show()
        Me.Hide()
    End Sub
End Class
