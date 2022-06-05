
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using ReportBackgroundService.Models;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelToCreate
{
    public class CreateExcel
    {
        public void DownloadCommaSeperatedFile(List<ReportEnity> reportEnities)
        {

            Application excel = new Application();
            excel.Visible = true;
            object Missing = Type.Missing;
            Workbook workbook = excel.Workbooks.Add(Missing);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            int StartRow = 1;

            foreach (var item in reportEnities)
            {
                Range oneRange = (Range)sheet1.Cells[StartRow, 1];
                Range twoRange = (Range)sheet1.Cells[StartRow, 2];
                Range threeRange = (Range)sheet1.Cells[StartRow, 3];

                oneRange.Value2 = item.LocationInformation;
                twoRange.Value2 = item.recordedPerson;
                threeRange.Value2 = item.recordedTelephoneNumber;

                StartRow++;
            }
        }
    }
}
