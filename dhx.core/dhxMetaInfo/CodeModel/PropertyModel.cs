using System;
using System.Collections.Generic;

namespace dhxMetaInfo
{
    /// <summary>
    /// Property model.
    /// </summary>
    public class PropertyModel
    {
        public string Name { get; set; }
        public TypeModel PropertyType { get; set; }

        public PropertyModel() {
        }
    }

    /// <summary>
    ///  
    /// </summary>
    public class PropertyModelList : List<PropertyModel>
    {
        public PropertyModelList() {
        }
    }
}
