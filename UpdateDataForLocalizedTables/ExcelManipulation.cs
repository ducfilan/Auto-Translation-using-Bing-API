using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateDataForLocalizedTables
{
    public class ExcelManipulation
    {
        public static DataTable ExcelToDataTable(string pathName, string sheetName)
        {
            var tbContainer = new DataTable();
            string strConn;
            if (string.IsNullOrEmpty(sheetName)) { sheetName = "Sheet1"; }
            var file = new FileInfo(pathName);
            if (!file.Exists) { throw new Exception("Error, file doesn't exists!" + " Er 2"); }
            string extension = file.Extension;
            switch (extension)
            {
                case ".xls":
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                    break;
                case ".xlsx":
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                    break;
                default:
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                    break;
            }
            var cnnxls = new OleDbConnection(strConn);
            var oda = new OleDbDataAdapter(string.Format("select * from [{0}$]", sheetName), cnnxls);
            var ds = new DataSet();
            oda.Fill(tbContainer);
            return tbContainer;
        }
    }
}
