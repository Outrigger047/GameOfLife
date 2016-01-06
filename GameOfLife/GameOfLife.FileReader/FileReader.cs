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

        #endregion

        #region Enums

        public enum EncodingTypes
        {
            UnknownOrInvalid = -1,
            Life106, Life105, MCell, Plaintext, RLE, SOF
        }

        #endregion

        #region Public methods

        public static List<Automaton.CoordSet> ReadFile(ref string[] data)
        {
            List<Automaton.CoordSet> initLiveCells = new List<Automaton.CoordSet>();

            switch (DetermineEncoding(ref data))
            {
                case EncodingTypes.UnknownOrInvalid:
                    break;
                case EncodingTypes.Life106:
                    ReadLife106(ref data, initLiveCells);
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

            return initLiveCells;
        }

        public static List<Automaton.CoordSet> ReadFile(ref string[] data, EncodingTypes readAsType)
        {
            List<Automaton.CoordSet> initLiveCells = new List<Automaton.CoordSet>();

            switch (readAsType)
            {
                case EncodingTypes.UnknownOrInvalid:
                    break;
                case EncodingTypes.Life106:
                    ReadLife106(ref data, initLiveCells);
                    break;
                case EncodingTypes.Life105:
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

            return initLiveCells;
        }

        #endregion

        #region Private methods
        
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
        /// Read Life 1.06 file data.
        /// Used on http://www.conwaylife.com/wiki
        /// </summary>
        /// <param name="data">Data from external file</param>
        /// <returns>List of CoordSet objects indicating live cells</returns>
        private static List<Automaton.CoordSet> ReadLife106(ref string[] data, List<Automaton.CoordSet> initLiveCells)
        {


            return initLiveCells;
        }

        /// <summary>
        /// Read Run Length Encoded file data.
        /// Used on http://www.conwaylife.com/wiki
        /// </summary>
        /// <param name="data">Data from external file</param>
        /// <returns>List of CoordSet objects indicating live cells</returns>
        private static List<Automaton.CoordSet> ReadRunLengthEncoding(ref string[] data, List<Automaton.CoordSet> initLiveCells)
        {


            return initLiveCells;
        } 

        #endregion
    }
}
