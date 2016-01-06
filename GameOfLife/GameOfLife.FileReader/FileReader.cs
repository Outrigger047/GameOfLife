using GameOfLife;
using System;
using System.Collections.Generic;

namespace GameOfLife
{
    /// <summary>
    /// Helper class to translate file data containing initial setups and cell configurations
    /// </summary>
    public static class FileReader
    {
        #region Enums

        public enum EncodingTypes
        {
            UnknownOrInvalid = -1,
            Life105, Life106, Plaintext, RLE, SOF
        }

        #endregion

        #region Public methods

        public static List<Automaton.CoordSet> ReadFile(ref byte[] data)
        {
            List<Automaton.CoordSet> initLiveCells = new List<Automaton.CoordSet>();



            return initLiveCells;
        }

        public static List<Automaton.CoordSet> ReadFile(ref byte[] data, EncodingTypes readAsType)
        {
            List<Automaton.CoordSet> initLiveCells = new List<Automaton.CoordSet>();



            return initLiveCells;
        }

        #endregion

        #region Private methods
        
        /// <summary>
        /// Determine file encoding scheme
        /// </summary>
        /// <param name="data">Reference to file data</param>
        /// <returns>Type of encoding</returns>
        private static EncodingTypes DetermineEncoding(ref byte[] data)
        {
            EncodingTypes fileType = EncodingTypes.UnknownOrInvalid;



            return fileType;
        }

        /// <summary>
        /// Read Run Length Encoded file data.
        /// Used on http://www.conwaylife.com/wiki
        /// </summary>
        /// <param name="data">Data from external file</param>
        /// <returns>List of CoordSet objects indicating live cells</returns>
        private static List<Automaton.CoordSet> ReadRunLengthEncoding(ref byte[] data, List<Automaton.CoordSet> initLiveCells)
        {


            return initLiveCells;
        } 

        #endregion
    }
}
