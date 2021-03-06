﻿namespace UglyToad.PdfPig.Fonts.CompactFontFormat.Dictionaries
{
    using System;
    using System.Collections.Generic;

    internal class CompactFontFormatPrivateDictionaryReader : CompactFontFormatDictionaryReader<CompactFontFormatPrivateDictionary>
    {
        public override CompactFontFormatPrivateDictionary Read(CompactFontFormatData data, string[] stringIndex)
        {
            var dictionary = new CompactFontFormatPrivateDictionary();

            ReadDictionary(dictionary, data, stringIndex);

            return dictionary;
        }

        protected override void ApplyOperation(CompactFontFormatPrivateDictionary dictionary, List<Operand> operands, OperandKey operandKey, string[] stringIndex)
        {
            switch (operandKey.Byte0)
            {
                case 6:
                    dictionary.BlueValues = ReadDeltaToArray(operands);
                    break;
                case 7:
                    dictionary.OtherBlues = ReadDeltaToArray(operands);
                    break;
                case 8:
                    dictionary.FamilyBlues = ReadDeltaToArray(operands);
                    break;
                case 9:
                    dictionary.FamilyOtherBlues = ReadDeltaToArray(operands);
                    break;
                case 10:
                    dictionary.StandardHorizontalWidth = operands[0].Decimal;
                    break;
                case 11:
                    dictionary.StandardVerticalWidth = operands[0].Decimal;
                    break;
                case 12:
                {
                    if (!operandKey.Byte1.HasValue)
                    {
                        throw new InvalidOperationException("In the CFF private dictionary, got the operation key 12 without a second byte.");
                    }

                    switch (operandKey.Byte1.Value)
                    {
                        case 9:
                            dictionary.BlueScale = operands[0].Decimal;
                            break;
                        case 10:
                            dictionary.BlueShift = operands[0].Decimal;
                            break;
                        case 11:
                            dictionary.BlueFuzz = operands[0].Decimal;
                            break;
                        case 12:
                            dictionary.StemSnapHorizontal = ReadDeltaToArray(operands);
                            break;
                        case 13:
                            dictionary.StemStapVertical = ReadDeltaToArray(operands);
                            break;
                        case 14:
                            dictionary.ForceBold = operands[0].Decimal == 1;
                            break;
                        case 17:
                            dictionary.LanguageGroup = operands[0].Decimal;
                            break;
                        case 18:
                            dictionary.ExpansionFactor = operands[0].Decimal;
                            break;
                        case 19:
                            dictionary.InitialRandomSeed = operands[0].Decimal;
                            break;
                    }
                }
                    break;
                case 19:
                    dictionary.LocalSubroutineLocalOffset = GetIntOrDefault(operands, -1);
                    break;
                case 20:
                    dictionary.DefaultWidthX = operands[0].Decimal;
                    break;
                case 21:
                    dictionary.NominalWidthX = operands[0].Decimal;
                    break;
            }
        }
    }
}