using System;
using System.Collections.Generic;

namespace dhxMetaInfo
{
    public class Schema
    {

        public Schema ()
        {
        }

        public String __definitionType { get; set; }
        public String name { get; set; }
        public Dictionary<String, SchemaType> types { get; set; }

    }

    public class SchemaType
    {
        public SchemaType ()
        {
        }

        public String name { get; set; }
        public String @base { get; set; }
        public String code { get; set; }
        public Boolean isArray { get; set; }
        public Object annotations { get; set; }
        public Boolean companyAware { get; set; }
        public Boolean customized { get; set; }
        public Boolean deleteLogicalEnabled { get; set; }
        public Boolean orgUnitAware { get; set; }
        public Boolean stampChanges { get; set; }
        public Boolean timeDependentEnabled { get; set; }

        public Dictionary<String, TypeElement> elements;

    }

    public class    TypeElement
    {

        public TypeElement ()
        {

        }
        public String name { get; set; }
        public String @base { get; set; }
        public String code { get; set; }
        public Boolean isArray { get; set; }
        public Dictionary<String, Object> annotations { get; set; }
        public String primitive { get; set; }
        public String defaultValue { get; set; }
        public Boolean mandatory { get; set; }
        public int decimals { get; set; }
        public int length { get; set; }
        public Boolean isResolved { get; set; }


        /*
                       "name": "/com/cgm/storm/generated/model/itemgroupbase/ItemGroupBase.code",
                        "base": "/String",
                        "code": "SIMPLE_TYPE",
                        "isArray": false,
                        "annotations": {},
                        "primitive": "String",
                        "defaultValue": null,
                        "mandatory": true,
                        "decimals": -1,
                        "length": 50,
                        "isResolved": true

        */


    }
}
