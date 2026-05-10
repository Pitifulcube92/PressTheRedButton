using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;

public class UI_MainMenu : BaseUIScript
{
    [SerializeField] private List<Button> menuButtons;
   
    ///[SerializeField] private float rotationspeed;
    [SerializeField] private List<Text> menuText;
    [SerializeField] private RawImage backgroundImg;
    [SerializeField] private float y, x;
    // Start is called before the first frame update
    void Start()
    {
        //I'm lazy to find a proper section for pitch change...
        GameManager.instance.GetSoundManager().GetBGMSource().pitch = 1;
        //GM = GameObject.FindGameObjectWithTag("Game Manager");
        foreach(Button x in GameObject.FindObjectsOfType<Button>())
        {
            menuButtons.Add(x);
        }
        foreach(Text x in GameObject.FindObjectsOfType<Text>())
        {
            menuText.Add(x);
        }
        if (menuButtons == null)
        {
            Debug.LogError("No UI buttons where found!");
        }
        SetUIConfigure();
    }
    private void Update()
    {
        //backgroundImg.uvRect = new Rect(backgroundImg.uvRect.position + new Vector2(x,y) * Time.deltaTime,backgroundImg.uvRect.size);
        //Vector3 angles = imageRectTransformScarling.eulerAngles;
        //angles.y = angles.y - rotationspeed * Time.deltaTime; // + rotationSpeed for right button
        //imageRectTransformScarling.eulerAngles = angles;
    }
    public override void SetUIConfigure()
    {
        foreach (Button x in menuButtons)
        {
            switch (x.gameObject.name)
            {
                case "Play Btn":
                    x.onClick.AddListener(delegate { GameManager.instance.GetLevelManager().NextLevel(); });
                    break;
                case "Quit Btn":
                    x.onClick.AddListener(delegate {GameManager.instance.QuiteGame();});
                   
                    break;
            }
            //x.onClick.AddListener(delegate { GameManager.instance.GetSoundManager().PlaySFXClip("Retro_Blop_18",false, GameManager.instance.GetSoundManager().GetSFXSource(1)); });
        }
        //gameObject.GetComponent<Canvas>().worldCamera = GameObject.FindObjectOfType<Camera>();
        //GameObject.FindAnyObjectByType<Camera>();
    }
}
