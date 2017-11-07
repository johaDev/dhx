using System;
using System.Collections.Generic;

namespace dhxMetaInfo
{
    /// <summary>
    /// Class model.
    /// </summary>
    public class ClassModel
    {
        public string Name { get; set; }
        public string InternalTypeName { get; set; }
        public bool IsPublic { get; set; }
        public bool IsPartial { get; set; }
        public List<PropertyModel> Properties { get; set; }

        public ClassModel() {
            Properties = new List<PropertyModel>();
        }
    }

    public class ClassModelList : List<ClassModel> { }
    public class Name2ClassMap : Dictionary<String, ClassModel> { }
    public class Fullname2ClassMap : Dictionary<String, ClassModel> { }

}
