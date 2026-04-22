using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Scriptable Objects/Character")]
public class Character : ScriptableObject
{
    public enum Feel {
        None,
        Happy,
        Sad,
        Angry,
        Fear,
        Disgust,
    }

    public string characterName;

    [Header("Texture")]
    [SerializeField] private Texture2D[] characterBody;
    [SerializeField] private Texture2D[] characterFace;

    public Texture2D GetBodySprite(int index) {  return characterBody[index]; }
    public Texture2D GetFaceSprite(Feel feel) { return characterFace[(int)feel]; }
}
