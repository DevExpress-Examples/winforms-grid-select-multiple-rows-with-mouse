Imports System.Data

Namespace DXApplication3

    Public Partial Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

        Public Sub New()
            InitializeComponent()
            customGrid1.DataSource = CreateTable(42)
            customGridView1.OptionsSelection.MultiSelect = True
        End Sub

        Private Function CreateTable(ByVal RowCount As Integer) As DataTable
            Dim tbl As DataTable = New DataTable()
            tbl.Columns.Add("Name", GetType(String))
            tbl.Columns.Add("ID", GetType(Integer))
            tbl.Columns.Add("Number", GetType(Integer))
            tbl.Columns.Add("Date", GetType(Date))
            For i As Integer = 0 To RowCount - 1
                tbl.Rows.Add(New Object() {String.Format("Name{0}", i), i, i Mod 4, Date.Now.AddDays(i)})
            Next

            Return tbl
        End Function
    End Class
End Namespace
