
using System;
using System.Text;
using System.Collections.Generic;

using dhxMetaInfo;



public class TemplateSnippets
{
    public const string NamespaceTemplate =
@"
namespace ${NamespaceName} {

    ${ClassSequence}    
}
";

    public const string ClassTemplate =
@"
    //
    class ${ClassName} {

        public ${ClassName}() {
        }
        ${PropertyList}
    }
";


    public const string PropertyTemplate = "public ${PropertyDataType} ${PropertyName} { get; set; }";
    /* public string GetProperty( string dataType, string propertyName) {
         return PropertyTemplate
             .Replace("${PropertyDataType}", dataType)
             .Replace("${PropertyName}", propertyName);
     }
     */

    public string GetProperty( string dataType, string propertyName )
    {
        return $"public {dataType} {propertyName} {{ get; set; }}";
    }


    public string GetArrayProperty( string dataType, string propertyName )
    {
        string stat = $"public List<{dataType}> {propertyName} {{ get; set; }}";

        return stat;
        // TODO init empty array?
    }

    public string GetProperty( string name, TypeElement te )
    {

        if (te.isArray)
        {
            return GetArrayProperty( te.@base, name );
        }
        else
        {
            return GetProperty( te.primitive, name );
        }
    }

    public string GetClassSequence( Schema classSchema )
    {

        var classes = new StringBuilder();

        foreach (var entry in classSchema.types)
        {
            var className = entry.Key;
            classes.Append( GetClass( className, entry.Value.elements ) );
            classes.AppendLine();

        }
        return classes.ToString();
    }

    public string GetClass( string className, IDictionary<String, TypeElement> elements )
    {
        var properties = new StringBuilder();
        foreach (var typeElement in elements)
        {
            properties.Append( GetProperty( typeElement.Key, typeElement.Value ) );
            properties.AppendLine();
            properties.Append( "        " );
        }

        return ClassTemplate
            .Replace( "${ClassName}", className )
            .Replace( "${PropertyList}", properties.ToString() );
    }

}