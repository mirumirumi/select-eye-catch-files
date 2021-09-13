Imports System.IO
Imports System.Text

Public Class Form1
    Private Sub go_Click(sender As Object, e As EventArgs) Handles go.Click
        Dim line As String = ""
        Dim al As New ArrayList

        Using sr As New StreamReader("[paths that eye catch file name list]", Encoding.GetEncoding("UTF-8"))
            line = sr.ReadLine()
            Do Until line Is Nothing
                al.Add(line)
                line = sr.ReadLine()
            Loop
        End Using

        For Each myfile As String In al
            Dim files As String() = Directory.GetFileSystemEntries("[directory to search from]", myfile, SearchOption.AllDirectories)
            If files.Length <> 0 Then
                For Each f In files
                    Try
                        File.Copy(f, "[directory to copy to]" & myfile)
                    Catch ex As System.IO.FileNotFoundException
                        Console.WriteLine(myfile)
                    Catch ex As System.IO.DirectoryNotFoundException
                        Console.WriteLine(myfile)
                    Catch ex As System.IO.IOException 'imifumei
                        Console.WriteLine("same files!!" & myfile)
                    End Try
                Next
            End If
        Next

        MessageBox.Show("complete")
    End Sub
End Class
