﻿namespace UglyToad.PdfPig.Fonts.CompactFontFormat
{
    using Dictionaries;

    internal class CompactFontFormatIndividualFontParser
    {
        private readonly CompactFontFormatIndexReader indexReader;
        private readonly CompactFontFormatTopLevelDictionaryReader topLevelDictionaryReader;
        private readonly CompactFontFormatPrivateDictionaryReader privateDictionaryReader;

        public CompactFontFormatIndividualFontParser(CompactFontFormatIndexReader indexReader,
            CompactFontFormatTopLevelDictionaryReader topLevelDictionaryReader,
            CompactFontFormatPrivateDictionaryReader privateDictionaryReader)
        {
            this.indexReader = indexReader;
            this.topLevelDictionaryReader = topLevelDictionaryReader;
            this.privateDictionaryReader = privateDictionaryReader;
        }

        public void Parse(CompactFontFormatData data, string name, byte[] topDictionaryIndex, string[] stringIndex)
        {
            var individualData = new CompactFontFormatData(topDictionaryIndex);

            var dictionary = topLevelDictionaryReader.Read(individualData, stringIndex);

            var privateDictionary = new CompactFontFormatPrivateDictionary();

            if (dictionary.PrivateDictionarySizeAndOffset.Item2 >= 0)
            {
                data.Seek(dictionary.PrivateDictionarySizeAndOffset.Item2);

                privateDictionary = privateDictionaryReader.Read(data, stringIndex);
            }

            if (dictionary.CharSetOffset >= 0)
            {

            }

            if (dictionary.CharStringsOffset >= 0)
            {
                data.Seek(dictionary.CharStringsOffset);

                var index = indexReader.ReadDictionaryData(data);
            }
        }
    }
}
