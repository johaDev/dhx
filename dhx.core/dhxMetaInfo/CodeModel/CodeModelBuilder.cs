using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace dhxMetaInfo
{
    /// <summary>
    /// Code model builder.
    /// 
    /// </summary>
    public class CodeModelBuilder
    {
        NamespaceModelMap namespaceMap = new NamespaceModelMap();
        ClassModelList classList = new ClassModelList();
        Fullname2ClassMap fullNameClassMap = new Fullname2ClassMap();

        public CodeModelBuilder() {
        }

        public void ImportSchema( List<Schema> schemas ) {
            foreach (var se in schemas) {
                ImportSchema( se );
            }
        }

        public void ImportSchema( Schema classSchema ) {
            NamespaceModel nm = CheckNamespace( classSchema );

            foreach (var entry in classSchema.types) {

                var classModel = new ClassModel();
                classModel.Name = entry.Key;
                classModel.InternalTypeName = entry.Value.name;

                nm.Classes.Add( classModel );
                classList.Add( classModel );
                fullNameClassMap[classModel.InternalTypeName] = classModel;

                ImportClassFields( entry.Value, classModel );
            }
        }

        private NamespaceModel CheckNamespace( Schema classSchema ) {
            if (!namespaceMap.ContainsKey( classSchema.name )) {
                var nm = new NamespaceModel() {
                    Name = classSchema.name
                };
                namespaceMap[classSchema.name] = nm;
            }
            return namespaceMap[classSchema.name];
        }

        void ImportClassFields( SchemaType st, ClassModel cm ) {
            if (st.elements != null) {
                foreach (var typeElement in st.elements) {
                    ImportField( typeElement.Value, cm );
                }
            }
        }

        private void ImportField( TypeElement typeElement, ClassModel cm ) {
            try {
                cm.Properties.Add( new PropertyModel {
                    PropertyType = new TypeModel( typeElement ),
                    Name = typeElement.name
                } );
            } catch (Exception ex) {
                ;
            }
        }
    }


}
