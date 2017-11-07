using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;


namespace dhxMetaInfo
{
    /// <summary>
    /// Schema reader.
    /// </summary>
    public class MetaInfoReader
    {
        public MetaInfoReader() {
        }

        public List<Schema> ReadSchema( StreamReader sr) {
            Debug.Assert(sr != null);
           
	        var s  = sr.ReadToEnd();
	        var schema = JsonConvert.DeserializeObject<List<Schema>>(s);
	        return schema;
        }

    }
}
