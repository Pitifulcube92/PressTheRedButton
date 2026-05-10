using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_uI : BaseUIScript
{
    [SerializeField] public List<Text> gameplayTexts;
    [SerializeField] private RawImage backgroundImg;
    [SerializeField] private float y, x;
    public override void SetUIConfigure()
    {
        foreach (Text x in gameplayTexts)
        {
            switch (x.gameObject.name)
            {
                case "Life_Text_variable":
                    x.text = GameManager.instance.GetNumberofChances().ToString();
                    break;
            }
        }
        GameObject.FindAnyObjectByType<LevelScript>().StartLevelSequence(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (Text x in GameObject.FindObjectsOfType<Text>())
        {
            //if (x.tag == "TargetUI")
            gameplayTexts.Add(x);
            Debug.Log(x.name);

        }
        gameObject.GetComponent<Canvas>().worldCamera = GameObject.FindObjectOfType<Camera>();
        SetUIConfigure();
    }

    public void UpdateChanceUI(int tmp_)
    {
        gameplayTexts.Find(x => x.name == "Life_Text_variable").text = tmp_.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        backgroundImg.uvRect = new Rect(backgroundImg.uvRect.position + new Vector2(x, y) * Time.deltaTime, backgroundImg.uvRect.size);
    }
}
