Public Class Main
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        RichTextBox1.Multiline = True
        RichTextBox1.WordWrap = True

        Dim result = ""
        Dim first = True
        Dim counter = 1

        For Each tempTest As String In RichTextBox1.Lines
            If tempTest.Length > 50 Then
                Dim test = "Zeile " + CStr(counter) + " ist zu lange"
                MessageBox.Show(test)
                GoTo out
            Else
                counter = counter + 1
                If first Then
                    result = tempTest
                    first = False
                Else
                    result = result + Environment.NewLine + tempTest
                End If
            End If
        Next

        If Not result = Nothing Then
            If result.Length > 255 Then
                MessageBox.Show("Gesamtnachricht ist länger als 255 Zeichen")
            Else
                DataGridView1.Rows.Add(result)
                DataGridView1.AutoResizeRows()
                DataGridView1.AutoResizeColumns()
            End If
        End If
out:
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        DataGridView2.Rows.Clear()
        Dim first = True
        Dim result = ""
        For Each tempTest As String In RichTextBox1.Lines
            If tempTest.Length > 50 Then
                If first Then
                    result = tempTest
                    first = False
                Else
                    result = result + Environment.NewLine + tempTest
                End If
                DataGridView2.Rows.Add(New String() {CStr(tempTest.Length), "Zeile zu lang!"})
            Else
                If first Then
                    result = tempTest
                    first = False
                Else
                    result = result + Environment.NewLine + tempTest
                End If
                DataGridView2.Rows.Add(CStr(tempTest.Length))
            End If
        Next
        If result.Length > 255 Then
            TextBox2.Text = "Maximale Länge von 255 überschritten"
        Else
            TextBox2.Text = ""
        End If
        TextBox1.Text = result.Length
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.ColumnCount = 1
        DataGridView1.Columns(0).Name = "Test"
        DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DataGridView1.Columns(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True

        DataGridView2.ColumnCount = 2
        DataGridView2.Columns(0).Name = "Wert"
        DataGridView2.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DataGridView2.Columns(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridView2.Columns(1).Name = "Warnung"
        DataGridView2.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DataGridView2.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
    End Sub
End Class