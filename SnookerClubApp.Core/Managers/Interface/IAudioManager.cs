using SnookerClubApp.Core.Enum;

namespace SnookerClubApp.Core.Managers.Interface
{
    public interface IAudioManager
    {
        #region Methods

        /// <summary>
        /// Plays the specified audio sound
        /// </summary>
        /// <param name="sound"></param>
        void Play(AudioSound sound);

        #endregion
    }
}
