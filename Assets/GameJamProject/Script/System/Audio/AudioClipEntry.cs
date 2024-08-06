using UnityEngine;

namespace GameJamProject.Audio
{
    [global::System.Serializable]
    public class AudioClipEntry
    {
        public string _name;
        public AudioClip _clip;

        public AudioClipEntry(string name, AudioClip clip)
        {
            this._name = name;
            this._clip = clip;
        }
    }
}