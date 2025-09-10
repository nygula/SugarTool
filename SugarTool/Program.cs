using SqlSugar;
using System.Text;
using System.Xml.Linq;


var dic = Directory.GetCurrentDirectory();
var files = Directory.GetFiles(dic, "*.xml", SearchOption.TopDirectoryOnly);
try
{


    if (files.Length == 0)
    {
        var xml = File.ReadAllText("model.xml");
        GenerateEntities(xml);

    }
    else
    {

        var fileName = Path.GetFileName(files[0]);
        var xml = File.ReadAllText(fileName);
        GenerateEntities(xml);
    }



}
catch (Exception ex)
{
    Console.WriteLine($"错误: {ex.Message}");
}







static void GenerateEntities(string xml)
{
    XNamespace ns = "https://newlifex.com/Model2022.xsd";
    var doc = XDocument.Parse(xml);
    var tables = doc.Descendants(ns + "Table");
    var output = doc.Root?.Attribute("Output")?.Value;
    if (string.IsNullOrWhiteSpace(output) )
        throw new Exception("Output  not found in XML.");

    foreach (var table in tables)
    {
        var sb = new StringBuilder();
        var root = doc.Root;

        // Header
        sb.AppendLine("using SqlSugar;");
        sb.AppendLine($"namespace {root.Attribute("NameSpace").Value}");
        sb.AppendLine("{");
        var description = table.Attribute("Description").Value;

        // Class header
        sb.AppendLine($"    [SugarTable(\"{table.Attribute("Name").Value}\",TableDescription = \"{description}\")]");
        foreach (var index in table.Descendants(ns + "Index"))
        {
            var indexAttr = GenerateIndex(index);
            sb.AppendLine(indexAttr);
        }
        sb.AppendLine($"    public partial class {table.Attribute("Name").Value} : {root.Attribute("BaseClass").Value}");
        sb.AppendLine("    {");

        // Columns
        foreach (var column in table.Descendants(ns + "Column"))
        {
            var prop = GenerateProperty(column);
            sb.AppendLine(prop);
        }

       

        sb.AppendLine("    }");
        // Indexes
     
        sb.AppendLine("}");

        if (!Directory.Exists(output))
            Directory.CreateDirectory(output);
       
        {
            var classname = table.Attribute("Name").Value;

            var filename = Path.Combine(output, $"{classname}.cs");
            File.WriteAllText(filename, sb.ToString());
            Console.WriteLine($"生成成功: {filename}");
        }
      
       
    }



}

static string GenerateProperty(XElement column)
{
    var sb = new StringBuilder();
    var attributes = new List<string>();

    // SugarColumn attributes
    var colAttrs = new List<string>();
    if (column.Attribute("PrimaryKey")?.Value == "True")
        colAttrs.Add("IsPrimaryKey = true");
    if (column.Attribute("Identity")?.Value == "True")
        colAttrs.Add("IsIdentity = true");
    if (column.Attribute("Nullable")?.Value == "False")
        colAttrs.Add("IsNullable = false");
    if (column.Attribute("Length") != null)
    {
        if(column.Attribute("Length").Value == "-1")
        {
            colAttrs.Add($"Length = 3000");

        }
        else
        {
            colAttrs.Add($"Length = {column.Attribute("Length").Value}");

        }

    }
    sb.AppendLine($"        /// <summary>");
    sb.AppendLine($"        /// {column.Attribute("Description").Value}");
    sb.AppendLine($"        /// </summary>");
    if (colAttrs.Count > 0)
        sb.AppendLine($"        [SugarColumn({string.Join(", ", colAttrs)})]");

    // Property
    var dataType = MapDataType(column.Attribute("DataType").Value);
    var type = column.Attribute("Type")?.Value ?? dataType;
    sb.AppendLine($"        public {type} {column.Attribute("Name").Value} {{ get; set; }}");

    return sb.ToString();
}

static string GenerateIndex(XElement index)
{
    var columns = index.Attribute("Columns").Value.Split(',');
    var indexName = $"IX_{index.Parent.Parent.Attribute("Name").Value}_{string.Join("_", columns)}";

    return $@"        [SugarIndex(""{indexName}"", nameof({string.Join("),  OrderByType.Asc,nameof(", columns)}), OrderByType.Asc,IsUnique = {(index.Attribute("Unique")?.Value ?? "false").ToLower()})]";
}

static string MapDataType(string xmlType) => xmlType switch
{
    "Int64" => "long",
    "Int32" => "int",
    "String" => "string",
    "DateTime" => "DateTime",
    "Double" => "Double",
    "Boolean" => "Boolean",
    "Decimal" => "Decimal",

    _ => "object"
};