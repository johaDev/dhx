using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace dhxMetaInfo
{
    /// <summary>
    /// Code model.
    /// 
    /// </summary>
    public class CodeModel
    {
        NamespaceList namespaceList = new NamespaceList();
        NamespaceModelMap namespaceMap = new NamespaceModelMap();
        ClassModelList classList = new ClassModelList();
        Fullname2ClassMap fullNameClassMap = new Fullname2ClassMap();

        public CodeModel() {
        }

        public NamespaceModelMap NamespaceMap {
            get {
                return namespaceMap;
            }
        }

        public ClassModelList ClassList {
            get {
                return classList;
            }
        }
        public NamespaceList NamespaceList {
            get {
                return namespaceList;
            }
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
                AddNamespace( classSchema.name, nm );
            }
            return namespaceMap[classSchema.name];
        }

        private void AddNamespace( string name, NamespaceModel nm ) {
            namespaceMap[name] = nm;
            namespaceList.Add( nm );

        }

        void ImportClassFields( SchemaType st, ClassModel cm ) {
            if (st.elements != null) {
                foreach (var typeElement in st.elements) {
                    ImportField( typeElement.Key, typeElement.Value, cm );
                }
            }
        }

        private void ImportField( String name, TypeElement typeElement, ClassModel cm ) {
            try {
                cm.Properties.Add( new PropertyModel {
                    PropertyType = new TypeModel( typeElement ),
                    Name = name
                } );
            } catch (Exception /*ex*/) {
                ;
            }
        }
    }


}
