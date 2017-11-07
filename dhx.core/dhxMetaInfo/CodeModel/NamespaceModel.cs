using System;
using System.Collections.Generic;

namespace dhxMetaInfo
{
    /// <summary>
    /// 
    /// </summary>  
    public class NamespaceModel
    {
        public string Name { get; set; }
        public List<UsingModel> Usings { get; set; }
        public List<ClassModel> Classes { get; set; }

        public NamespaceModel() {
            Usings = new List<UsingModel>();
            Classes = new List<ClassModel>();
        }

        public string NameIdent {
            get {
                return this.Name.Replace( '/', '.' ).TrimStart( '.' );
            }
        }

    }

    public class NamespaceModelMap : Dictionary<string, NamespaceModel> { 
    }
    public class NamespaceList: List<NamespaceModel> { 
    }

}
