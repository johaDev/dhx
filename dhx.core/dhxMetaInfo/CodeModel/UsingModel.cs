using System;
using System.Diagnostics.Contracts;
using System.Collections.Generic;

namespace dhxMetaInfo
{
    /// <summary>
    /// Using model.
    /// contains name of referenced namespace
    /// </summary>
    public class UsingModel
    {
        public UsingModel() {
        }
    }

    /// <summary>
    /// Using model list.
    /// </summary>
    public class UsingModelList : List<UsingModel>
    {
        public UsingModelList() {
        }
    }

}
