using System;
using System.Collections.Generic;
using System.Text;

namespace CommaBoard.Store.Class
{
    public class ResourceParam
    {

       public string value { get; set; }
       public string name { get; set; }
       public Guid id { get; set; }

    }

    public class ResourceType
    {

        public Guid id { get; set; }
        public string name { get; set; }
        public string vendor { get; set; }
        public string parentId { get; set; }
        public PropertyType[] propertyTypes { get; set; }

    }

    public class PropertyType
    {
        public Guid resourceTypeId { get; set; }
        public string name { get; set; }
        public string defaultValue { get; set; }
    }
}
