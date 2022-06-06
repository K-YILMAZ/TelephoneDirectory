using System;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using ReportBackgroundService.Models;
using Range = Microsoft.Office.Interop.Excel.Range;
using IronXL;
using System.Drawing;

namespace ReportBackgroundService.Controls
{
    public static class CreateExcel
    {
        public static void DownloadCommaSeperatedFile(List<ReportEnity> reportEnities)
        {

            int StartRow = 2;

            WorkBook xlsWorkbook = WorkBook.Create(ExcelFileFormat.XLS);
            xlsWorkbook.Metadata.Author = "IronXL";
            WorkSheet xlsSheet = xlsWorkbook.CreateWorkSheet("new_sheet");
            xlsSheet["A1"].Value = "Konum";
            xlsSheet["B1"].Value = "Personel Sayısı";
            xlsSheet["C1"].Value = "Telefon Numara Sayısı";

            xlsSheet["A1"].Style.BackgroundColor = "#d3d3d3";
            xlsSheet["B1"].Style.BackgroundColor = "#d3d3d3";
            xlsSheet["C1"].Style.BackgroundColor = "#d3d3d3";
            foreach (var item in reportEnities)
            {

                xlsSheet["A"+StartRow].Value = item.LocationInformation;
                xlsSheet["B"+ StartRow].Value= item.recordedPerson;
                xlsSheet["C"+ StartRow].Value = item.recordedTelephoneNumber;
                StartRow++;
            }
            xlsWorkbook.SaveAs("ExcelFile/NewExcelFile.xls");
        }
    }
}
