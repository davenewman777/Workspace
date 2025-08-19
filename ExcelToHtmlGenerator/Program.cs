
using System;
using System.IO;
using ClosedXML.Excel;
using System.Text;

partial class Program
{
	static void Main(string[] args)
	{
		string excelPath = "../ExcelFile/WAF Assessment for Customer's Azure Integration to RISE v2 Customer Ready.xlsx";
		string outputDir = "./HtmlOutput";
		Directory.CreateDirectory(outputDir);

		using (var workbook = new XLWorkbook(excelPath))
		{
			foreach (var worksheet in workbook.Worksheets)
			{
				var sb = new StringBuilder();
				sb.AppendLine("<table class='table table-bordered'>");
				var range = worksheet.RangeUsed();
				if (range == null) continue;
				var rows = range.RowsUsed();
				bool isHeader = true;
				foreach (var row in rows)
				{
					sb.AppendLine("<tr>");
					int colCount = row.Cells().Count();
					for (int i = 1; i <= colCount; i++)
					{
						var cell = row.Cell(i);
						if (isHeader)
						{
							sb.Append("<th>").Append(cell.GetValue<string>()).AppendLine("</th>");
						}
						else if (i == colCount)
						{
							sb.Append("<td>");
							sb.Append("<select><option value='Yes'" + (cell.GetValue<string>().Trim().Equals("Yes", StringComparison.OrdinalIgnoreCase) ? " selected" : "") + ">Yes</option><option value='No'" + (cell.GetValue<string>().Trim().Equals("No", StringComparison.OrdinalIgnoreCase) ? " selected" : "") + ">No</option></select>");
							sb.AppendLine("</td>");
						}
						else
						{
							sb.Append("<td>").Append(cell.GetValue<string>()).AppendLine("</td>");
						}
					}
					sb.AppendLine("</tr>");
					isHeader = false;
				}
				sb.AppendLine("</table>");
				string outPath = Path.Combine(outputDir, worksheet.Name + ".html");
				File.WriteAllText(outPath, sb.ToString());
				Console.WriteLine($"Generated HTML for worksheet: {worksheet.Name}");
			}
		}
		Console.WriteLine("Done. Check the HtmlOutput folder for results.");
	}
}
