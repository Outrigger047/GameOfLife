using GameOfLife;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameOfLife
{
    /// <summary>
    /// Helper class to translate file data containing initial setups and cell configurations
    /// </summary>
    public class FileReader
    {
        #region Fields

        private List<string> data;
        private Flags options;

        private Dictionary<string, EncodingTypes> headerLookup = new Dictionary<string, EncodingTypes>();
        private Dictionary<EncodingTypes, string> coordLineMatchByFileType = new Dictionary<EncodingTypes, string>();
        private Dictionary<EncodingTypes, string> coordSetMatchByFileType = new Dictionary<EncodingTypes, string>();

        #endregion

        #region Properties

        public FileExtract Extract { get; private set; }

        #endregion

        #region Enums

        public enum EncodingTypes
        {
            UnknownOrInvalid = -1,
            Life106, Life105, MCell, Plaintext, RLE, SOF, MyCommaFormat
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

        #region Constructor

        public FileReader(List<string> data, CoordExtractionOffsetModes offsetMode)
        {
            // Dictionaries
            headerLookup.Add(@"\#Life 1.06", EncodingTypes.Life106);
            headerLookup.Add(@"\#Life 1.05", EncodingTypes.Life105);
            headerLookup.Add(@"^\!Name\: [A-Za-z ]+$", EncodingTypes.Plaintext);
            headerLookup.Add(@"^x = [0-9]+, y = [0-9]+$", EncodingTypes.RLE);
            //headerLookup.Add(@"", EncodingTypes.SOF);
            headerLookup.Add(@"#MyCommaSeparatedFormat", EncodingTypes.MyCommaFormat);

            coordLineMatchByFileType.Add(EncodingTypes.Life106, @"^\-{0,1}[0-9]+\s+\-{0,1}[0-9]+$");
            coordLineMatchByFileType.Add(EncodingTypes.Life105, @"^#P\s+\-{0,1}[0-9]+\s+\-{0,1}[0-9]+$");
            coordLineMatchByFileType.Add(EncodingTypes.Plaintext, @"");
            coordLineMatchByFileType.Add(EncodingTypes.MyCommaFormat, @"^[0-9]+\,[0-9]+$");

            coordSetMatchByFileType.Add(EncodingTypes.Life106, @"\-{0,1}[0-9]+");
            coordSetMatchByFileType.Add(EncodingTypes.Life105, @"\-{0,1}[0-9]+");
            coordSetMatchByFileType.Add(EncodingTypes.Plaintext, @"");
            coordSetMatchByFileType.Add(EncodingTypes.MyCommaFormat, @"\-{0,1}[0-9]+");

            // Everything else
            this.data = data;
            options = new Flags(DetermineEncoding(this.data), offsetMode);
            Extract = new FileExtract();

            ReadFile();
        }

        #endregion

        #region Public methods

        private FileExtract ReadFile()
        {
            List<Automaton.CoordSet> liveCellsFromFile = new List<Automaton.CoordSet>();

            string coordLineMatchPattern;
            coordLineMatchByFileType.TryGetValue(options.EncodingType, out coordLineMatchPattern);
            string coordSetMatchPattern;
            coordSetMatchByFileType.TryGetValue(options.EncodingType, out coordSetMatchPattern);

            if (coordLineMatchPattern == null | coordSetMatchPattern == null)
            {
                if (options.EncodingType == EncodingTypes.UnknownOrInvalid)
                {
                    throw new Exception("File encoding type is unknown or invalid");
                }
            }

            if (options.OffsetMode == CoordExtractionOffsetModes.ScaleToZero)
            {
                List<int> allX = new List<int>();
                List<int> allY = new List<int>();
                int xMin, yMin;
                List<int[]> tempPreShiftCells = new List<int[]>();

                foreach (var line in data)
                {
                    if (Regex.IsMatch(line, coordLineMatchPattern))
                    {
                        Match currentLineMatch = Regex.Match(line, coordLineMatchPattern);
                        MatchCollection currentLineCoordsMatches = Regex.Matches(currentLineMatch.Value, coordSetMatchPattern);

                        string[] currentCoords = currentLineCoordsMatches.Cast<Match>().Select(m => m.Value).ToArray();
                        string xCoord = currentCoords[0];
                        string yCoord = currentCoords[1];

                        allX.Add(Convert.ToInt32(xCoord));
                        allY.Add(Convert.ToInt32(yCoord));

                        int[] tempIntPair = { Convert.ToInt32(xCoord), Convert.ToInt32(yCoord) };

                        tempPreShiftCells.Add(tempIntPair);
                    }
                }

                allX.Sort();
                allY.Sort();
                xMin = Enumerable.Last(allX) + 1;
                yMin = Enumerable.Last(allY) + 1;

                foreach (var tempCoord in tempPreShiftCells)
                {
                    liveCellsFromFile.Add(new Automaton.CoordSet(tempCoord[0] + xMin, tempCoord[1] + yMin));
                }

                //fe = new FileExtract(liveCellsFromFile, xMin, yMin);
                Extract.LiveCells = liveCellsFromFile;
                Extract.XMin = xMin;
                Extract.YMin = yMin;
            }
            else if (options.OffsetMode == CoordExtractionOffsetModes.RelativeToOrigin)
            {
                foreach (var line in data)
                {
                    if (Regex.IsMatch(line, coordLineMatchPattern))
                    {
                        Match currentLineMatch = Regex.Match(line, coordLineMatchPattern);
                        MatchCollection currentLineCoordsMatches = Regex.Matches(currentLineMatch.Value, coordSetMatchPattern);

                        string[] currentCoords = currentLineCoordsMatches.Cast<Match>().Select(m => m.Value).ToArray();
                        string xCoord = currentCoords[0];
                        string yCoord = currentCoords[1];

                        liveCellsFromFile.Add(new Automaton.CoordSet(Convert.ToInt32(xCoord), Convert.ToInt32(yCoord)));
                    }
                }

                //fe = new FileExtract(liveCellsFromFile);
                Extract.LiveCells = liveCellsFromFile;
            }
            /*
            else
            {
                fe = new FileExtract();
            }
            */
            return Extract;

        }

        /*
        public static List<Automaton.CoordSet> ReadFile(ref string[] data, CoordExtractionOffsetModes offsetMode, EncodingTypes readAsType)
        {
            List<Automaton.CoordSet> initLiveCells = new List<Automaton.CoordSet>();

            // TODO

            return initLiveCells;
        }
        */

        #endregion

        #region Private methods - Other operations

        /// <summary>
        /// Determine file encoding scheme
        /// </summary>
        /// <param name="data">Reference to file data</param>
        /// <returns>Type of encoding</returns>
        private EncodingTypes DetermineEncoding(List<string> data)
        {
            foreach (var headerPattern in headerLookup)
            {
                if (Regex.Match(data.First(), headerPattern.Key).Success)
                {
                    return headerPattern.Value;
                }
            }
            return EncodingTypes.UnknownOrInvalid;
        }

        /// <summary>
        /// DEPRECATED: Extracts a valid set of coordinates from a line of encoded text
        /// </summary>
        /// <param name="encodedText">Text to search</param>
        /// <param name="fileType">File type of text</param>
        /// <returns>CoordSet object with any valid coordinates</returns>
        private Automaton.CoordSet _ExtractCoordinates(Match currentMatch, string pattern, Flags options)
        {
            string[] coordinateMatches = new string[2];

            switch (options.EncodingType)
            {
                case EncodingTypes.UnknownOrInvalid:
                    break;
                case EncodingTypes.Life106:
                    string coordSetPattern;
                    coordSetMatchByFileType.TryGetValue(options.EncodingType, out coordSetPattern);
                    Regex.Matches(currentMatch.Value, coordSetPattern).CopyTo(coordinateMatches, 0);
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
                    coordinateMatches = null;
                    break;
            }

            if (options.OffsetMode == CoordExtractionOffsetModes.RelativeToOrigin)
            {
                return new Automaton.CoordSet(Convert.ToInt32(coordinateMatches[0]), Convert.ToInt32(coordinateMatches[1]));
            }
            else if (options.OffsetMode == CoordExtractionOffsetModes.ScaleToZero)
            {
                // Handle rescaling coordinates
                return new Automaton.CoordSet(Convert.ToInt32(coordinateMatches[0]), Convert.ToInt32(coordinateMatches[1]));
            }
            else
            {
                return new Automaton.CoordSet(Convert.ToInt32(coordinateMatches[0]), Convert.ToInt32(coordinateMatches[1]));
            }
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

        public class FileExtract
        {
            public List<Automaton.CoordSet> LiveCells { get; set; }
            public int? XMin { get; set; }
            public int? YMin { get; set; }

            public FileExtract()
            {
                LiveCells = null;
                XMin = null;
                YMin = null;
            }
        }

        #endregion
    }
}
