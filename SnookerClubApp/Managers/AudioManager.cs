using SnookerClubApp.Core.Enum;
using SnookerClubApp.Core.Managers.Interface;

using System.Collections.Generic;
using System.IO;
using System.Media;

namespace SnookerClubApp.Managers
{
    public class AudioManager : IAudioManager
    {

        #region Private Members

        /// <summary>
        /// The audio sounds to be used to play when needed
        /// </summary>
        private Dictionary<AudioSound, string> _audioSounds = new Dictionary<AudioSound, string>();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AudioManager(Dictionary<AudioSound, string> audioSounds)
        {
            _audioSounds = audioSounds;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Plays the specified audio sound
        /// </summary>
        /// <param name="sound">The sound which is to be played</param>
        public void Play(AudioSound sound)
        {
            //If the specified audio sound has not been registered then do not attempt to play
            if (!_audioSounds.ContainsKey(sound))
                return;

            if (!File.Exists(_audioSounds[sound]))
                return;

            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = _audioSounds[sound];
            player.Play();
        }

        #endregion

    }
}
