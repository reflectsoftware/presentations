using System;
using System.Collections.Generic;
using System.Linq;

using ReflectSoftware.Insight.Extensions.PostSharp;

namespace AOPDemo.Layers
{
    public class SomeClass
    {
        [RITraceField("tracer.fields", "MyFieldName")]
        public String Name { get; set; }

        [RITraceField("tracer.fields", "Address")]
        public String Address { get; set; }

        [RITraceField("tracer.fields", "Age", RITraceFieldDispatchType.Both)]
        public Int32 Age { get; set; }
    }
}
