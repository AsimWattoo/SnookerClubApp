using SnookerClubApp.Core.View_Model.Item;

using System.Collections.Generic;

namespace SnookerClubApp.Core.Application
{
    public class RuntimeStorage
    {
        #region Public Properties

        /// <summary>
        /// The list of extra items for each table
        /// </summary>
        public Dictionary<int, List<ExtraItem>> Extras { get; set; } = new Dictionary<int, List<ExtraItem>>();

        #endregion
    }
}
