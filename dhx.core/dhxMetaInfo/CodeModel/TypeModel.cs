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
            if( te.isArray) {
                return $"List<{ToDottedName(te.@base)}>";
            }
            return te.primitive;
        }

        private string ToDottedName( string name) {
            name = name.Replace( "/", "." );
            return name.TrimStart( '.' );
        }
    }   
}
