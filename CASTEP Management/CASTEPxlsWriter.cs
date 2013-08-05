using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.IO;

namespace CASTEP_Management
{
    static class CASTEPxlsWriter
    {
        private static ExcelWorksheet CreateSheet(ExcelPackage p, string sheetName)
        {
            p.Workbook.Worksheets.Add(sheetName);
            ExcelWorksheet ws = p.Workbook.Worksheets[1];
            ws.Name = sheetName; //Setting Sheet's name
            ws.Cells.Style.Font.Size = 11; //Default font size for whole sheet
            ws.Cells.Style.Font.Name = "Calibri"; //Default Font name for whole sheet

            return ws;
        }

        public static void WriteXLS(CASTEPinfo info, string outputFilename)
        {
            using(ExcelPackage p = new ExcelPackage())
            {
                ExcelWorksheet ws = CreateSheet(p, "CASTEP data");
                ws.Cells["A1"].Value = info.substance;
                ws.Cells["A2"].Value = "Task";
                ws.Cells["B2"].Value = info.task;
                ws.Cells["A3"].Value = "Quality";
                ws.Cells["B3"].Value = info.quality0;
                ws.Cells["C3"].Value = info.quality1+" eV";
                ws.Cells["A4"].Value = "Space group";
                ws.Cells["B4"].Value = info.space;
                ws.Cells["C4"].Value = "Cell Contents=";
                ws.Cells["D4"].Value = info.content;
                ws.Cells["A5"].Value = "Functional";
                ws.Cells["B5"].Value = info.functional;

                String[] header = new String[] { "Stress", "Pressure", "Final bulk modulus", "Final Enthalpy", "Current cell volumn", "A", "Angle", "Energy", "V", "E"};
                for (int i = 1; i <= header.Length; i++)
                {
                    ws.Cells[6, i].Value = header[i - 1];
                }
                int r = 7;
                foreach (CASTEPsubObj s in info.record)
                {
                    ws.Cells[r, 1].Value = s.stress;
                    ws.Cells[r, 2].Value = s.pressure;
                    ws.Cells[r, 3].Value = s.bulkModulus;
                    ws.Cells[r, 4].Value = s.enthalpy;
                    ws.Cells[r, 5].Value = s.cellVolumn;
                    ws.Cells[r, 6].Value = s.a;
                    ws.Cells[r, 7].Value = s.angle;
                    ws.Cells[r, 8].Value = s.energy;
                    ws.Cells[r, 9].Value = s.V;
                    ws.Cells[r, 10].Value = s.E;
                    r += 1;
                }
                Stream stream = File.Create(outputFilename);
                p.SaveAs(stream);
                stream.Close();
            }
        }
    }
}
