using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Data;
using System.IO;



public static class NPOIHelper
{
    public static DataSet ExcelToDataSet(string excelPath)
    {
        return ExcelToDataSet(excelPath, true);
    }

    public static DataSet ExcelToDataSet(string excelPath, bool firstRowAsHeader)
    {
        int sheetCount;
        return ExcelToDataSet(excelPath, firstRowAsHeader, out sheetCount);
    }

    public static DataSet ExcelToDataSet(string excelPath, bool firstRowAsHeader, out int sheetCount)
    {
        using (DataSet ds = new DataSet())
        {
            using (FileStream fileStream = new FileStream(excelPath, FileMode.Open, FileAccess.Read))
            {
                string extName = System.IO.Path.GetExtension(excelPath);//扩展名
                if (extName.ToLower() == ".xls")//excel 2003
                {
                    HSSFWorkbook workbook = new HSSFWorkbook(fileStream);

                    HSSFFormulaEvaluator evaluator = new HSSFFormulaEvaluator(workbook);

                    sheetCount = workbook.NumberOfSheets;

                    for (int i = 0; i < sheetCount; ++i)
                    {
                        HSSFSheet sheet = workbook.GetSheetAt(i) as HSSFSheet;
                        DataTable dt = ExcelToDataTable(sheet, evaluator, firstRowAsHeader);
                        ds.Tables.Add(dt);
                    }
                }
                else
                {
                    XSSFWorkbook workbook = new XSSFWorkbook(fileStream);
                    XSSFFormulaEvaluator evaluator = new XSSFFormulaEvaluator(workbook);
                    sheetCount = workbook.NumberOfSheets;
                    for (int i = 0; i < sheetCount; ++i)
                    {
                        XSSFSheet sheet = workbook.GetSheetAt(i) as XSSFSheet;
                        DataTable dt = ExcelToDataTable(sheet, evaluator, firstRowAsHeader);
                        ds.Tables.Add(dt);
                    }
                }
                return ds;
            }
        }
    }

    public static DataTable ExcelToDataTable(string excelPath, string sheetName)
    {
        return ExcelToDataTable(excelPath, sheetName, true);
    }

    public static DataTable ExcelToDataTable(string excelPath, string sheetName, bool firstRowAsHeader)
    {
        using (FileStream fileStream = new FileStream(excelPath, FileMode.Open, FileAccess.Read))
        {
            string extName = System.IO.Path.GetExtension(excelPath);//扩展名
            if (extName.ToLower() == ".xls")//excel 2003
            {
                HSSFWorkbook workbook = new HSSFWorkbook(fileStream);

                HSSFFormulaEvaluator evaluator = new HSSFFormulaEvaluator(workbook);

                HSSFSheet sheet = workbook.GetSheet(sheetName) as HSSFSheet;

                return ExcelToDataTable(sheet, evaluator, firstRowAsHeader);
            }
            else//2007
            {
                XSSFWorkbook workbook = new XSSFWorkbook(fileStream);

                XSSFFormulaEvaluator evaluator = new XSSFFormulaEvaluator(workbook);

                XSSFSheet sheet = workbook.GetSheet(sheetName) as XSSFSheet;

                return ExcelToDataTable(sheet, evaluator, firstRowAsHeader);
            }
        }
    }

    //处理excel2003
    private static DataTable ExcelToDataTable(HSSFSheet sheet, HSSFFormulaEvaluator evaluator, bool firstRowAsHeader)
    {
        if (firstRowAsHeader)
        {
            return ExcelToDataTableFirstRowAsHeader(sheet, evaluator);
        }
        else
        {
            return ExcelToDataTable(sheet, evaluator);
        }
    }
    //处理excel2007
    private static DataTable ExcelToDataTable(XSSFSheet sheet, XSSFFormulaEvaluator evaluator, bool firstRowAsHeader)
    {
        if (firstRowAsHeader)
        {
            return ExcelToDataTableFirstRowAsHeader(sheet, evaluator);
        }
        else
        {
            return ExcelToDataTable(sheet, evaluator);
        }
    }

    //处理excel2003
    private static DataTable ExcelToDataTableFirstRowAsHeader(HSSFSheet sheet, HSSFFormulaEvaluator evaluator)
    {
        using (DataTable dt = new DataTable())
        {
            HSSFRow firstRow = sheet.GetRow(0) as HSSFRow;
            int cellCount = GetCellCount(sheet);

            for (int i = 0; i < cellCount; i++)
            {
                if (firstRow.GetCell(i) != null)
                {
                    dt.Columns.Add(firstRow.GetCell(i).StringCellValue ?? string.Format("F{0}", i + 1), typeof(string));
                }
                else
                {
                    dt.Columns.Add(string.Format("F{0}", i + 1), typeof(string));
                }
            }

            for (int i = 1; i <= sheet.LastRowNum; i++)
            {
                HSSFRow row = sheet.GetRow(i) as HSSFRow;
                DataRow dr = dt.NewRow();
                FillDataRowByHSSFRow(row, evaluator, ref dr);
                dt.Rows.Add(dr);
            }

            dt.TableName = sheet.SheetName;
            return dt;
        }
    }
    //处理excel2007
    private static DataTable ExcelToDataTableFirstRowAsHeader(XSSFSheet sheet, XSSFFormulaEvaluator evaluator)
    {
        using (DataTable dt = new DataTable())
        {
            XSSFRow firstRow = sheet.GetRow(0) as XSSFRow;
            int cellCount = GetCellCount(sheet);

            for (int i = 0; i < cellCount; i++)
            {
                if (firstRow.GetCell(i) != null)
                {
                    dt.Columns.Add(firstRow.GetCell(i).StringCellValue ?? string.Format("F{0}", i + 1), typeof(string));
                }
                else
                {
                    dt.Columns.Add(string.Format("F{0}", i + 1), typeof(string));
                }
            }

            for (int i = 1; i <= sheet.LastRowNum; i++)
            {
                XSSFRow row = sheet.GetRow(i) as XSSFRow;
                DataRow dr = dt.NewRow();
                FillDataRowByHSSFRow(row, evaluator, ref dr);
                dt.Rows.Add(dr);
            }

            dt.TableName = sheet.SheetName;
            return dt;
        }
    }

    //处理excel2003
    private static DataTable ExcelToDataTable(HSSFSheet sheet, HSSFFormulaEvaluator evaluator)
    {
        using (DataTable dt = new DataTable())
        {
            if (sheet.LastRowNum != 0)
            {
                int cellCount = GetCellCount(sheet);

                for (int i = 0; i < cellCount; i++)
                {
                    dt.Columns.Add(string.Format("F{0}", i), typeof(string));
                }

                for (int i = 0; i < sheet.FirstRowNum; ++i)
                {
                    DataRow dr = dt.NewRow();
                    dt.Rows.Add(dr);
                }

                for (int i = sheet.FirstRowNum; i <= sheet.LastRowNum; i++)
                {
                    HSSFRow row = sheet.GetRow(i) as HSSFRow;
                    DataRow dr = dt.NewRow();
                    FillDataRowByHSSFRow(row, evaluator, ref dr);
                    dt.Rows.Add(dr);
                }
            }

            dt.TableName = sheet.SheetName;
            return dt;
        }
    }
    //处理excel2007
    private static DataTable ExcelToDataTable(XSSFSheet sheet, XSSFFormulaEvaluator evaluator)
    {
        using (DataTable dt = new DataTable())
        {
            if (sheet.LastRowNum != 0)
            {
                int cellCount = GetCellCount(sheet);

                for (int i = 0; i < cellCount; i++)
                {
                    dt.Columns.Add(string.Format("F{0}", i), typeof(string));
                }

                for (int i = 0; i < sheet.FirstRowNum; ++i)
                {
                    DataRow dr = dt.NewRow();
                    dt.Rows.Add(dr);
                }

                for (int i = sheet.FirstRowNum; i <= sheet.LastRowNum; i++)
                {
                    XSSFRow row = sheet.GetRow(i) as XSSFRow;
                    DataRow dr = dt.NewRow();
                    FillDataRowByHSSFRow(row, evaluator, ref dr);
                    dt.Rows.Add(dr);
                }
            }

            dt.TableName = sheet.SheetName;
            return dt;
        }
    }

    //处理excel2003
    private static void FillDataRowByHSSFRow(HSSFRow row, HSSFFormulaEvaluator evaluator, ref DataRow dr)
    {
        if (row != null)
        {
            for (int j = 0; j < dr.Table.Columns.Count; j++)
            {
                HSSFCell cell = row.GetCell(j) as HSSFCell;

                if (cell != null)
                {
                    switch (cell.CellType)
                    {
                        case CellType.BLANK:
                            dr[j] = DBNull.Value;
                            break;
                        case CellType.BOOLEAN:
                            dr[j] = cell.BooleanCellValue;
                            break;
                        case CellType.NUMERIC:
                            if (DateUtil.IsCellDateFormatted(cell))
                            {
                                dr[j] = cell.DateCellValue;
                            }
                            else
                            {
                                dr[j] = cell.NumericCellValue;
                            }
                            break;
                        case CellType.STRING:
                            dr[j] = cell.StringCellValue;
                            break;
                        case CellType.ERROR:
                            dr[j] = cell.ErrorCellValue;
                            break;
                        case CellType.FORMULA:
                            cell = evaluator.EvaluateInCell(cell) as HSSFCell;
                            dr[j] = cell.ToString();
                            break;
                        default:
                            throw new NotSupportedException(string.Format("Catched unhandle CellType[{0}]", cell.CellType));
                    }
                }
            }
        }
    }
    //处理excel2007
    private static void FillDataRowByHSSFRow(XSSFRow row, XSSFFormulaEvaluator evaluator, ref DataRow dr)
    {
        if (row != null)
        {
            for (int j = 0; j < dr.Table.Columns.Count; j++)
            {
                XSSFCell cell = row.GetCell(j) as XSSFCell;

                if (cell != null)
                {
                    switch (cell.CellType)
                    {
                        case CellType.BLANK:
                            dr[j] = DBNull.Value;
                            break;
                        case CellType.BOOLEAN:
                            dr[j] = cell.BooleanCellValue;
                            break;
                        case CellType.NUMERIC:
                            if (DateUtil.IsCellDateFormatted(cell))
                            {
                                dr[j] = cell.DateCellValue;
                            }
                            else
                            {
                                dr[j] = cell.NumericCellValue;
                            }
                            break;
                        case CellType.STRING:
                            dr[j] = cell.StringCellValue;
                            break;
                        case CellType.ERROR:
                            dr[j] = cell.ErrorCellValue;
                            break;
                        case CellType.FORMULA:
                            cell = evaluator.EvaluateInCell(cell) as XSSFCell;
                            dr[j] = cell.ToString();
                            break;
                        default:
                            throw new NotSupportedException(string.Format("Catched unhandle CellType[{0}]", cell.CellType));
                    }
                }
            }
        }
    }

    //处理excel2003
    private static int GetCellCount(HSSFSheet sheet)
    {
        int firstRowNum = sheet.FirstRowNum;

        int cellCount = 0;

        for (int i = sheet.FirstRowNum; i <= sheet.LastRowNum; ++i)
        {
            HSSFRow row = sheet.GetRow(i) as HSSFRow;

            if (row != null && row.LastCellNum > cellCount)
            {
                cellCount = row.LastCellNum;
            }
        }

        return cellCount;
    }
    //处理excel2007
    private static int GetCellCount(XSSFSheet sheet)
    {
        int firstRowNum = sheet.FirstRowNum;

        int cellCount = 0;

        for (int i = sheet.FirstRowNum; i <= sheet.LastRowNum; ++i)
        {
            XSSFRow row = sheet.GetRow(i) as XSSFRow;

            if (row != null && row.LastCellNum > cellCount)
            {
                cellCount = row.LastCellNum;
            }
        }

        return cellCount;
    }


    //--------------------------生成excel----------------------

}

