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
