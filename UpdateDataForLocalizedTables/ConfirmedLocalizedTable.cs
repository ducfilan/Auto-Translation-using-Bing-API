using System.Collections.Generic;

namespace UpdateDataForLocalizedTables
{
    public class ConfirmedLocalizedTable
    {
        public string TableName { get; set; }
        public List<string> ColumnsToLocalize { get; set; }

        /*
        public ConfirmedLocalizedTable()
        {
        }
        public ConfirmedLocalizedTable(string tableName, List<string> columnsToLocalize)
        {
            TableName = tableName;
            ColumnsToLocalize = columnsToLocalize;
        }
         */
    }
}
