using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smithsonian.Models;

namespace Smithsonian.Models
{

    public class Rootobject
    {
        public Jsonapi jsonapi { get; set; }
        public Datum[] data { get; set; }
        public Meta1 meta { get; set; }
        public Links1 links { get; set; }
        public Description[] desc { get; set; }
    }

    public class Jsonapi
    {
        public string version { get; set; }
        public Meta meta { get; set; }
    }

    public class Meta
    {
        public Links links { get; set; }
    }

    public class Links
    {
        public Self self { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Meta1
    {
        public string count { get; set; }
    }

    public class Links1
    {
        public Last last { get; set; }
        public Next next { get; set; }
        public Self1 self { get; set; }
    }

    public class Last
    {
        public string href { get; set; }
    }

    public class Next
    {
        public string href { get; set; }
    }

    public class Self1
    {
        public string href { get; set; }
    }

    public class Datum
    {
        public string type { get; set; }
        public string id { get; set; }
        public Attributes attributes { get; set; }
        public Relationships relationships { get; set; }
        public Links5 links { get; set; }
    }

    public class Attributes
    {
        public string title { get; set; }
        public DateTime changed { get; set; }
        public Path path { get; set; }
        public string author { get; set; }
        public string author_for_display { get; set; }
        public Description description { get; set; }
        public string book_title_display { get; set; }
        public string dimensions { get; set; }
        public string isbn_hardcover { get; set; }
        public string isbn_softcover { get; set; }
        public string pages { get; set; }
        public string publisher { get; set; }
        public int year_published { get; set; }
    }

    public class Path
    {
        public string alias { get; set; }
        public int pid { get; set; }
        public string langcode { get; set; }
    }

    public class Description
    {
        public string value { get; set; }
        public string format { get; set; }
        public string processed { get; set; }
        public string summary { get; set; }

        public Description() { 
        
        }
    }

    public class Relationships
    {
        public Field_Curators field_curators { get; set; }
        public Exhibition_Codes exhibition_codes { get; set; }
        public Images images { get; set; }
    }

    public class Field_Curators
    {
        public object[] data { get; set; }
        public Links2 links { get; set; }
    }

    public class Links2
    {
        public Self2 self { get; set; }
    }

    public class Self2
    {
        public string href { get; set; }
    }

    public class Exhibition_Codes
    {
        public Datum1[] data { get; set; }
        public Links3 links { get; set; }
    }

    public class Links3
    {
        public Self3 self { get; set; }
        public Related related { get; set; }
    }

    public class Self3
    {
        public string href { get; set; }
    }

    public class Related
    {
        public string href { get; set; }
    }

    public class Datum1
    {
        public string type { get; set; }
        public string id { get; set; }
    }

    public class Images
    {
        public Datum2[] data { get; set; }
        public Links4 links { get; set; }
    }

    public class Links4
    {
        public Self4 self { get; set; }
        public Related1 related { get; set; }
    }

    public class Self4
    {
        public string href { get; set; }
    }

    public class Related1
    {
        public string href { get; set; }
    }

    public class Datum2
    {
        public string type { get; set; }
        public string id { get; set; }
    }

    public class Links5
    {
        public Self5 self { get; set; }
    }

    public class Self5
    {
        public string href { get; set; }
    }


}

