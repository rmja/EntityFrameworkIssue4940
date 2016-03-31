using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkIssue4940
{
    public abstract class Value
    {
        public Guid Id { get; set; }
        public ValueDiscriminator Discriminator { get; set; }
        public DateTime Created { get; set; }
    }

    public class StringValue : Value
    {
        public string Value { get; set; }
    }

    public class IntegerValue : Value
    {
        public int Value { get; set; }
    }

    public enum ValueDiscriminator
    {
        String,
        Integer
    }
}
