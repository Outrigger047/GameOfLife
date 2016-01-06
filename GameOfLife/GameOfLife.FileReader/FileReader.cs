using GameOfLife;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GameOfLife
{
    /// <summary>
    /// Helper class to translate file data containing initial setups and cell configurations
    /// </summary>
    public static class FileReader
    {
        #region Fields

        private static Dictionary<string, EncodingTypes> HeaderLookup =
            new Dictionary<string, EncodingTypes>
        {
            { @"\#Life 1.06", EncodingTypes.Life106 },
            { @"\#Life 1.05", EncodingTypes.Life105 },
            { null, EncodingTypes.MCell },
            { @"^\!Name\: [A-Za-z ]+$", EncodingTypes.Plaintext },
            { @"^x = [0-9]+, y = [0-9]+$", EncodingTypes.RLE }, // TODO RLE header is more complex...
            { null, EncodingTypes.SOF }
        };

        private static Dictionary<EncodingTypes, string> CoordMatchByFileType = 
            new Dictionary<EncodingTypes, string>
        {
            { EncodingTypes.Life106, @"^\-{0,1}[0-9]+\s+\-{0,1}[0-9]+$" },
            { EncodingTypes.Life105, @"^#P\s+\-{0,1}[0-9]+\s+\-{0,1}[0-9]+$" },
            { EncodingTypes.Plaintext, @"" }
        };

        #endregion

        #region Enums

        public enum EncodingTypes
        {
            UnknownOrInvalid = -1,
            Life106, Life105, MCell, Plaintext, RLE, SOF
        }

        /// <summary>
        /// Used to set mode of operation when translating coordinates from file to Automaton.CoordSet.
        /// ScaleToZero indicates lowest negative value should be scaled to zero. RelativeToOrigin makes no chnages.
        /// </summary>
        public enum CoordExtractionOffsetModes
        {
            ScaleToZero, RelativeToOrigin
        }

        #endregion

        #region Public methods

        public static List<Automaton.CoordSet> ReadFile(ref string[] data, CoordExtractionOffsetModes offsetMode)
        {
            List<Automaton.CoordSet> initLiveCells = new List<Automaton.CoordSet>();
            Flags options = new Flags(DetermineEncoding(ref data), offsetMode);

            string coordLineMatchPattern;
            CoordMatchByFileType.TryGetValue(options.EncodingType, out coordLineMatchPattern);
            Match coordsMatch = Regex.Match(encodedText, pattern);

            foreach (var line in data)
            {
                if (Regex.IsMatch(line, coordLineMatchPattern))
                {
                    initLiveCells.Add(ExtractCoordinates(line, options));
                }
            }



            return initLiveCells;
        }

        public static List<Automaton.CoordSet> ReadFile(ref string[] data, CoordExtractionOffsetModes offsetMode, EncodingTypes readAsType)
        {
            List<Automaton.CoordSet> initLiveCells = new List<Automaton.CoordSet>();

            // TODO

            return initLiveCells;
        }

        #endregion

        #region Private methods - Other operations

        /// <summary>
        /// Determine file encoding scheme
        /// </summary>
        /// <param name="data">Reference to file data</param>
        /// <returns>Type of encoding</returns>
        private static EncodingTypes DetermineEncoding(ref string[] data)
        {
            foreach (var headerPattern in HeaderLookup)
            {
                if (Regex.Match(data[0], headerPattern.Key).Success)
                {
                    return headerPattern.Value;
                }
            }
            return EncodingTypes.UnknownOrInvalid;
        } 

        /// <summary>
        /// Extracts a valid set of coordinates from a line of encoded text
        /// </summary>
        /// <param name="encodedText">Text to search</param>
        /// <param name="fileType">File type of text</param>
        /// <returns>CoordSet object with any valid coordinates</returns>
        private static Automaton.CoordSet ExtractCoordinates(string encodedText, Flags options)
        {
            string pattern;
            CoordMatchByFileType.TryGetValue(options.EncodingType, out pattern);

            Match coordsMatch, xCoordMatch, yCoordMatch;

            switch (options.EncodingType)
            {
                case EncodingTypes.UnknownOrInvalid:
                    break;
                case EncodingTypes.Life106:

                    xCoordMatch = Regex.Match(Regex.Match(coordsMatch.Value, @"^.*?[0-9\-]+").Value, @"[0-9\-]+");
                    yCoordMatch = Regex.Match(Regex.Match(coordsMatch.Value, @"[0-9\-]+?$").Value, @"[0-9\-]+");
                    break;
                case EncodingTypes.Life105:
                    break;
                case EncodingTypes.MCell:
                    break;
                case EncodingTypes.Plaintext:
                    break;
                case EncodingTypes.RLE:
                    break;
                case EncodingTypes.SOF:
                    break;
                default:
                    break;
            }

            return new Automaton.CoordSet(Convert.ToInt32(xCoordMatch.Value), Convert.ToInt32(yCoordMatch.Value));
        }

        #endregion

        #region Nested classes

        private class Flags
        {
            public EncodingTypes EncodingType { get; private set; }
            public CoordExtractionOffsetModes OffsetMode { get; private set; }

            public Flags(EncodingTypes encodingType, CoordExtractionOffsetModes offsetMode)
            {
                EncodingType = encodingType;
                OffsetMode = offsetMode;
            }
        }

        #endregion
    }
}
