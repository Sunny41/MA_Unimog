using UnityEngine.Audio;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioSource", menuName ="Audio", order = 1)]
public class Sound : ScriptableObject {

    public AudioClip clip;

    [HideInInspector]
    public AudioSource source;

    public string name;

    public bool loop;

    [Range(0, 1)]
    public int layer;
    [Range(0f, 1f)]
    public float volume;
    [Range(0f, 1f)]
    public float pitch;
    [Range(0f, 1f)]
    public float spatialBlend;
}
