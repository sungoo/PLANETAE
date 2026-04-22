using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private RawImage characterBodyStanding;
    [SerializeField] private RawImage characterFaceStanding;
    [SerializeField] private Character[] Characters;
    
    [SerializeField] private TMP_Text speakerName;

    private string lastSpeaker;

    private void Update()
    {
        if (speakerName == null || characterBodyStanding == null)
            return;

        if (speakerName.text == lastSpeaker)
            return;

        if(speakerName.text == "Narration")
            characterBodyStanding.gameObject.SetActive(false);

        //텍스트에 적힌 이름이 달라짐
        lastSpeaker = speakerName.text;
        Debug.Log("last speaker : "+lastSpeaker);
        foreach (var ch in Characters)
        {
            if (ch.characterName == lastSpeaker)
            {
                Debug.Log("get body");
                characterBodyStanding.texture = ch.GetBodySprite(0);
                characterBodyStanding.gameObject.SetActive(true);
                return;
            }
            Debug.Log("no body");
        }
        //스프라이트가 결국 없음 => 숨김
        characterBodyStanding.gameObject.SetActive(false);
    }
}
