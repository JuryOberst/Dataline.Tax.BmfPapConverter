﻿// <copyright file="ConstantExpressionConverter.cs" company="DATALINE GmbH &amp; Co. KG">
// Copyright (c) DATALINE GmbH &amp; Co. KG. All rights reserved.
// See LICENSE in the project root for license information.
// </copyright>

namespace Dataline.Tax.BmfPapConverter.CodeGen
{
    public static class ConstantExpressionConverter
    {
        public static string ToConstantString(System.Type type, string objText)
        {
            if (type == typeof(uint))
            {
                return $"{objText}U";
            }
            if (type == typeof(ulong))
            {
                return $"{objText}UL";
            }
            if (type == typeof(float))
            {
                return $"{objText}f";
            }
            if (type == typeof(decimal))
            {
                return $"{objText}m";
            }

            return objText;
        }
    }
}
