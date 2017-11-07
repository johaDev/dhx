using System;

namespace dhxMetaInfo
{
    public class CodeModel
    {

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
    }
}
