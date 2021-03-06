﻿// <copyright file="PapVariable.cs" company="DATALINE GmbH &amp; Co. KG">
// Copyright (c) DATALINE GmbH &amp; Co. KG. All rights reserved.
// See LICENSE in the project root for license information.
// </copyright>

using System.Xml.Linq;

namespace Dataline.Tax.BmfPapConverter
{
    public class PapVariable
    {
        public PapVariable(XElement element)
        {
            Name = element.Attribute("name")?.Value;
            Type = element.Attribute("type")?.Value;
            Default = element.Attribute("default")?.Value;
            Documentation = element.GetPreviousComment();

            if (string.IsNullOrEmpty(Name))
                throw new InvalidPapException("Der name einer Variable muss gesetzt sein.");
            if (string.IsNullOrEmpty(Type))
                throw new InvalidPapException("Der type einer Variable muss gesetzt sein.");
        }

        public PapVariable()
        {
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Default { get; set; }

        public string Documentation { get; set; }
    }
}
