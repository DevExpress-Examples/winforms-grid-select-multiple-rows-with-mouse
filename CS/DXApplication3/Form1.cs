using System;
using System.Data;

namespace DXApplication3
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            customGrid1.DataSource = CreateTable(42);
            customGridView1.OptionsSelection.MultiSelect = true;
        }
        private DataTable CreateTable(int RowCount)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("ID", typeof(int));
            tbl.Columns.Add("Number", typeof(int));
            tbl.Columns.Add("Date", typeof(DateTime));
            for (int i = 0; i < RowCount; i++)
                tbl.Rows.Add(new object[] { String.Format("Name{0}", i), i, i % 4, DateTime.Now.AddDays(i) });
            return tbl;
        }
    }
}
