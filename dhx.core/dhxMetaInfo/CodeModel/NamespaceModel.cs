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

    }

    public class NamespaceModelMap : Dictionary<string, NamespaceModel> { }

}
