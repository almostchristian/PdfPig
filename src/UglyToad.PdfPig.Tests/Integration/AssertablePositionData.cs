﻿namespace UglyToad.PdfPig.Tests.Integration
{
    using System;

    public class AssertablePositionData
    {
        public decimal X { get; set; }

        public decimal Y { get; set; }

        public decimal Width { get; set; }

        public string Text { get; set; }

        public decimal FontSize { get; set; }

        public string FontName { get; set; }

        public decimal Height { get; set; }

        public static AssertablePositionData Parse(string line)
        {
            var parts = line.Split('\t');

            if (parts.Length < 6)
            {
                throw new ArgumentException($"Expected 6 parts to the line, instead got {parts.Length}");
            }

            var height = parts.Length < 7 ? 0 : decimal.Parse(parts[6]);

            return new AssertablePositionData
            {
                X = decimal.Parse(parts[0]),
                Y = decimal.Parse(parts[1]),
                Width = decimal.Parse(parts[2]),
                Text = parts[3],
                FontSize = decimal.Parse(parts[4]),
                FontName = parts[5],
                Height = height
            };
        }
    }
}