using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private RawImage characterBodyStanding;
    [SerializeField] private RawImage characterFaceStanding;
    [SerializeField] private Character[] Characters;
    
    [SerializeField] private TMP_Text speakerName;
    [SerializeField] private RawImage NameSpace;

    [SerializeField] private LinePresenter linePresenter;

    private string lastSpeaker;

    private bool autoCharacterStanding = true;

    private void Update()
    {
        if (!autoCharacterStanding)
            return;
        if (speakerName == null || characterBodyStanding == null)
            return;

        if (speakerName.text == lastSpeaker)
            return;

        if(speakerName.text == "Narration")
        {
            //HideSpeakerName();
            characterBodyStanding.gameObject.SetActive(false);
        }
        //else
            //ShowSpeakerName();

        //텍스트에 적힌 이름이 달라짐
        lastSpeaker = speakerName.text;
        Debug.Log("last speaker : "+lastSpeaker);
        foreach (var ch in Characters)
        {
            if (ch.characterName == lastSpeaker)
            {
                characterBodyStanding.texture = ch.GetBodySprite(0);
                characterBodyStanding.gameObject.SetActive(true);
                return;
            }
        }
        //스프라이트가 결국 없음 => 숨김
        characterBodyStanding.gameObject.SetActive(false);
    }

    public void HideSpeakerName()
    {
        linePresenter.showCharacterNameInLine = false;
        NameSpace.gameObject.SetActive(false);
    }

    public void ShowSpeakerName()
    {
        linePresenter.showCharacterNameInLine= true;
        NameSpace.gameObject.SetActive(true);
    }

    public void AutoSpeakerChange(bool istrue)
    {
        autoCharacterStanding = istrue;
        characterBodyStanding.gameObject.SetActive(istrue);
    }
}
