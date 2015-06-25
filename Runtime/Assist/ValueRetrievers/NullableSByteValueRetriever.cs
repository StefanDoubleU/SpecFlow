﻿using System;
using System.Collections.Generic;

namespace TechTalk.SpecFlow.Assist.ValueRetrievers
{
    public class NullableSByteValueRetriever : ValueRetrieverBase
    {
        private readonly Func<string, sbyte> sbyteValueRetriever = v => new SByteValueRetriever().GetValue(v);

        public NullableSByteValueRetriever(Func<string, sbyte> sbyteValueRetriever = null)
        {
            if (sbyteValueRetriever != null)
                this.sbyteValueRetriever = sbyteValueRetriever;
        }

        public sbyte? GetValue(string value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            return sbyteValueRetriever(value);
        }

        public override object ExtractValueFromRow(TableRow row, Type targetType)
        {
            return GetValue(row[1]);
        }

        public override IEnumerable<Type> TypesForWhichIRetrieveValues()
        {
            return new Type[]{ typeof(sbyte?) };
        }
    }
}