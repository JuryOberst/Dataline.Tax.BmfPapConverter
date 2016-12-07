﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Dataline.Tax.BmfPapConverter
{
    internal static class StaticCodeLoader
    {
        public const string PapOperationalClassStaticCodeName = "Dataline.Tax.BmfPapConverter.Resources.PapOperationalClassStaticCode.cs";
        public const string ProjectSkeletonStaticCodeName = "Dataline.Tax.BmfPapConverter.Resources.ProjectSkeleton.json";
        public const string GlobalSkeletonStaticCodeName = "Dataline.Tax.BmfPapConverter.Resources.GlobalSkeleton.json";
        public const string TestSkeletonStaticCodeName = "Dataline.Tax.BmfPapConverter.Resources.TestSkeleton.cs";
        public const string TestProjectSkeletonStaticCodeName = "Dataline.Tax.BmfPapConverter.Resources.TestProjectSkeleton.json";

        public static string Load(string name)
        {
            var asm = typeof(StaticCodeLoader).GetTypeInfo().Assembly;
            var stream = asm.GetManifestResourceStream(name);

            if (stream == null)
                throw new InvalidOperationException($"Die statische Ressource {name} wurde nicht gefunden.");

            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static string ExtensionStaticCodeName(string extension)
            => $"Dataline.Tax.BmfPapConverter.Resources.Extension_{extension}.cs";
    }
}