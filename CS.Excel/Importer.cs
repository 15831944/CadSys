﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CS.Data.DTO.Excel;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace CS.Excel
{
    public static class Importer
    {
        public static Task<List<OutputProprietar>> Persoane(MemoryStream stream, ImportConfig config)
        {

            return Task.Run(() =>
            {
                stream.Position = 0;
                HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read 2007 Excel format  
                var sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook 

                IRow headerRow = sheet.GetRow(0); //Get Header Row 

                var columnNames = Utils.GetColumnNames(headerRow);

                var result = new List<OutputProprietar>();

                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                {
                    var row = sheet.GetRow(i);

                    if (row == null && config.IgnoreNullRows) continue;

                    result.Add(GetDTO<OutputProprietar>(row, columnNames.ToList(), i));
                }

                return result;
            });
        }

        public static Task<List<T>> GetDTOs<T>(MemoryStream stream, ImportConfig config) where T:Output, new()
        {
            return Task.Run(() =>
            {
                stream.Position = 0;
                HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read 2007 Excel format  
                var sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook 

                IRow headerRow = sheet.GetRow(0); //Get Header Row 

                var columnNames = Utils.GetColumnNames(headerRow);

                var result = new List<T>();

                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                {
                    var row = sheet.GetRow(i);

                    if (row == null && config.IgnoreNullRows) continue;
                    try
                    {
                        if (row.All(x => x == null || string.IsNullOrEmpty(x.ToString()))) continue;
                    }
                    catch
                    {
                        System.Diagnostics.Debugger.Break();
                    }
                    result.Add(GetDTO<T>(row, columnNames.ToList(), i));

                }

                return result;
            });
        }

        public static Task<List<List<T>>> GetGroupedDTOs<T>(MemoryStream stream, ImportConfig config) where T : Output, new()
        {
            return Task.Run(() =>
            {
                stream.Position = 0;
                HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read 2007 Excel format  
                var sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook 

                IRow headerRow = sheet.GetRow(0); //Get Header Row 

                var columnNames = Utils.GetColumnNames(headerRow);

                var result = new List<List<T>>();

                var miniResult = new List<T>();

                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                {
                    var row = sheet.GetRow(i);

                    if (row == null || row.All(x => x == null || string.IsNullOrEmpty(x.ToString())))
                    {
                        if (miniResult.Count > 0)
                        {
                            result.Add(miniResult);
                            miniResult = new List<T>();
                        }
                    }
                    else
                    {
                        miniResult.Add(GetDTO<T>(row, columnNames.ToList(), i));                        
                    }
                }

                if (miniResult.Count>0) result.Add(miniResult);

                return result;
            });
        }

        private static T GetDTO<T>(IRow row, List<string> columnNames, int rowIndex = 0) where T : Output, new()
        {
            var result = new T
            {
                RowIndex = rowIndex
            };
            if (row == null) return result;

            var kvp = new Dictionary<string, string>();


            for (var i = 0; i < columnNames.Count(); i++)
            {
                var cell = row.GetCell(i);

                if (cell == null) continue;

                string value = cell.ToString();

                if (cell.CellType == CellType.Numeric && DateUtil.IsCellDateFormatted(cell))
                {
                    value = cell.DateCellValue.ToString("dd/MM/yyyy");
                }

                kvp.Add(columnNames[i], value);
            }

            Caly.Common.Reflection.FillInstanceFromDictionary(kvp, result, true);
            return result;
        }

    }

    public class ImportConfig
    {
        public bool IgnoreNullRows
        {
            get;
            set;
        } = true;

        public bool UppercaseColumnsCompare
        {
            get;
            set;
        } = true;
    }
}
