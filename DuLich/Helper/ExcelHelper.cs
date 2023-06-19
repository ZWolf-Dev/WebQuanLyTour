using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace DuLich.Helper
{
    public static class ExcelHelper
    {
        public static string message = "";
        public static DataTable ReadFileExcel(HttpPostedFileBase FileUpload, string targetpath)
        {
            try
            {
                var ds = new DataSet();
                if (FileUpload.ContentType == "application/vnd.ms-excel"||FileUpload.ContentType == "application/vnd.openxmlformats-officedocument.speadsheetml.sheet")
                {
                    string filename = FileUpload.FileName;
                    FileUpload.SaveAs(targetpath + filename);
                    string pathToExcelFile = targetpath + filename;
                    var connectionString = "";
                    if (filename.EndsWith(".xls"))
                    {
                        connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.4.0; data Source={0}; Extended Properties=\"Excel 8.0;HDR=No;IMEX=1\";", pathToExcelFile);
                    }
                    else if (filename.EndsWith(".xlsx"))
                    {
                        connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=Yes;IMEX=1\";", pathToExcelFile);
                    }
                    var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);

                    adapter.Fill(ds, "ExcelTable");
                    DataTable dtable = ds.Tables["ExcelTable"];
                    if ((System.IO.File.Exists(pathToExcelFile)))
                    {
                        System.IO.File.Delete(pathToExcelFile);
                    }
                    return dtable;
                }
                else
                {
                    message = "Lỗi đọc file excel";
                    return null;
                }
            }
            catch (Exception ex)
            {
                message = ex.ToString();
                return null;
            }
        }
    }
}