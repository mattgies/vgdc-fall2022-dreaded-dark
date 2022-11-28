using UnityEngine.Audio;
using UnityEngine;

[System.Serializable] // Necessary to actualize arrays as sliders
public class Sound 
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)] // Slider
    public float volume;
    [Range(.1f, 3f)]
    public float pitch; 
}
