using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelApp
{
    public partial class ExcelApplication : Form
    {
        public ExcelApplication()
        {
            InitializeComponent();
        }

        private void Export_Click(object sender, System.EventArgs e)
        {
            //two line to be inserted in between the header and footer of the excel file
            var listDate = new List<TaskData>();
            listDate.Add(new TaskData() { TaskName = txtTask1.Text, Hours = 9 });
            listDate.Add(new TaskData() { TaskName = txtTask2.Text, Hours = 9 });
            listDate.Add(new TaskData() { TaskName = txtTask3.Text, Hours = 9 });
            listDate.Add(new TaskData() { TaskName = txtTask4.Text, Hours = 9 });
            //listDate.Add(new TaskData() { TaskName = "hi", Hours = 9 });
            //listDate.Add(new TaskData() { TaskName = "hello", Hours = 9 });
            //listDate.Add(new TaskData() { TaskName = "good", Hours = 9 });
            //listDate.Add(new TaskData() { TaskName = "morning", Hours = 9 });

            Excel.Application xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            //xlApp.Visible = true;

            try
            {
                //get save location
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Excel Workbook (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
                saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

                if (saveFile.ShowDialog() != DialogResult.OK) return;


                //get template file path
                var templateFileName = "Template.xlsx";
                var templateFolderName = "Template";
                var templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, templateFolderName, templateFileName);


                Excel.Workbook xlBook = xlApp.Workbooks.Open(templatePath, Missing.Value, false, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                xlApp.Calculation = Excel.XlCalculation.xlCalculationManual;

                Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);


                //set header and footer data
                ((Excel.Range)xlSheet.Cells[2, 10]).Value2 = DateTime.Now.ToShortTimeString();
                ((Excel.Range)xlSheet.Cells[5, 10]).Value2 = DateTime.Now.ToShortDateString();


                var taskCount = listDate.Count;// > 0 ? listDate.Count - 1 : 0;
                //insert new rows
                for (int i = 0; i < taskCount - 1; i++)
                {
                    xlSheet.Select(Missing.Value);
                    ((Excel.Range)xlSheet.Cells[4, 1]).EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown, Missing.Value);
                }

                //delete last row (initially created one extra row for excel to execute formula)
                if (taskCount > 1)
                {
                    ((Excel.Range)xlSheet.Cells[taskCount, 1]).EntireRow.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                }

                //insert data
                for (int i = 0; i < taskCount; i++)
                {
                    ((Excel.Range)xlSheet.Cells[3 + i, 1]).Value2 = listDate[i].TaskName;
                    ((Excel.Range)xlSheet.Cells[3 + i, 2]).Value2 = listDate[i].Hours;
                }


                //save and close
                xlApp.Calculation = Excel.XlCalculation.xlCalculationAutomatic;

                xlBook.SaveAs(saveFile.FileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                xlBook.Close(false, Missing.Value, Missing.Value);

                xlSheet = null;
                xlBook = null;

                xlApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                xlApp = null;

                GC.Collect();

                MessageBox.Show("Report has been exported successfully!", "Export Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                xlApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                xlApp = null;
                GC.Collect();
            }

        }

        public class TaskData
        {
            public string TaskName { get; set; }
            public int Hours { get; set; }
        }
    }
}
