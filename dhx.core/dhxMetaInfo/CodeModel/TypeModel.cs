using System;
namespace dhxMetaInfo
{
    public class TypeModel
    {
        TypeElement te;

        public TypeModel( TypeElement te ) {
            this.te = te;
        }

        public string TypeName() {
            string name;
            if( te.isArray) {
                name =  $"List<{ToDottedName(te.@base)}>";
            } else {
                name = te.primitive;
            }
            if (!te.mandatory) {
                name += "?"; // Nullable
            }
            return name;
        }

        private string ToDottedName( string name) {
            name = name.Replace( "/", "." );
            return name.TrimStart( '.' );
        }
    }   
}
