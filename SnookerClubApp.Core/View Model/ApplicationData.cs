using SnookerClubApp.Core.View_Model.Item;

using System.Collections.Generic;

namespace SnookerClubApp.Core.View_Model
{
    /// <summary>
    /// Class responsible for storing data while running
    /// </summary>
    public class ApplicationData
    {
        #region Public Properties

        /// <summary>
        /// The list of tables in the application
        /// </summary>
        public List<Table> Tables { get; set; } = new List<Table>();

        /// <summary>
        /// The list of extra items for each table
        /// </summary>
        public Dictionary<int, List<ExtraItem>> Extras { get; set; } = new Dictionary<int, List<ExtraItem>>();

        #endregion
    }
}
