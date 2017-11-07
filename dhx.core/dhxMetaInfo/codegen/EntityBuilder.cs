using System;
using System.Text;
namespace dhxMetaInfo
{
    public class EntityBuilder
    {
        private CodeModel _cm;
        private int indentDepth = 0;

        public EntityBuilder( CodeModel cm ) {
            this._cm = cm;
        }


        public String CreateNameSpacesCode() {

            var sb = new StringBuilder();

            foreach (NamespaceModel nsm in _cm.NamespaceList) {
                BeginNamespace( sb, nsm );
                CreateClassesCode( sb, nsm );
                EndNamespace( sb, nsm );
            }
            return sb.ToString();
        }

        private void BeginNamespace( StringBuilder sb, NamespaceModel ns ) {
            sb.AppendLine( $"namespace {ns.NameIdent} {{" );
        }
        private void EndNamespace( StringBuilder sb, NamespaceModel ns ) {
            sb.AppendLine( "}" );
        }

        private void CreateClassesCode( StringBuilder sb, NamespaceModel ns ) {

            Indent();
            foreach (ClassModel cm in ns.Classes) {
                CreateClassCode( sb, cm );
            }
            Dedent();
        }

        private void CreateClassCode( StringBuilder sb, ClassModel cs ) {
            string indentation = getIndentation();

            sb.AppendLine( $"{indentation}class {cs.Name} {{" );
            Indent();

            // constructor
            string cnstrcIndent = getIndentation();
            sb.AppendLine( $@"{cnstrcIndent}public {cs.Name}() {{" );
            sb.AppendLine( $@"{cnstrcIndent}}}
            " );

            sb.AppendLine( $@"{cnstrcIndent}public String __type {{ 
{cnstrcIndent}    get {{ return ""{cs.InternalTypeName}""; }}  
{cnstrcIndent}    set( String value ) {{}}
{cnstrcIndent}}}" );

            // properties
            foreach( PropertyModel pm in cs.Properties) {
                CreatePropertyCode( sb, pm );
            }

            Dedent();
            sb.AppendLine( $"{indentation}}}" );
            sb.AppendLine();
        }

        private void CreatePropertyCode( StringBuilder sb, PropertyModel pm ) {
            string indentation = getIndentation();
            string typeName = pm.PropertyType.TypeName();

            sb.AppendLine( $"{indentation}public {typeName} {pm.Name} {{ get; set; }}" );
        }

        private void Indent() {
            indentDepth++;
        }

        private void Dedent() {
            indentDepth--;  
        }

        private string getIndentation() {
            return _indentation[indentDepth];
        }
        static string[] _indentation = {
                "",
                "    ",
                "        ",
                "            ",
                "                ",
                "                    ",
                "                        ",
                "                            ",
                "                                ",
                "                                    "
            };


    }
}
