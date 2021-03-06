﻿namespace UglyToad.PdfPig.Graphics
{
    using System;
    using PdfPig.Core;
    using Tokenization.Tokens;
    using Util.JetBrains.Annotations;
    using XObject;

    internal class XObjectContentRecord
    {
        public XObjectType Type { get; }

        [NotNull]
        public StreamToken Stream { get; }

        public TransformationMatrix AppliedTransformation { get; }

        public XObjectContentRecord(XObjectType type, StreamToken stream, TransformationMatrix appliedTransformation)
        {
            Type = type;
            Stream = stream ?? throw new ArgumentNullException(nameof(stream));
            AppliedTransformation = appliedTransformation;
        }
    }
}
