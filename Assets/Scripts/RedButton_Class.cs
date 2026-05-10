using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton_Class : MonoBehaviour
{
    [SerializeField] private Sprite defaultBtnSprite_;
    [SerializeField] private Sprite pressedBtnSprite_;
    [SerializeField] private SpriteRenderer spriteRen;

    // Start is called before the first frame update
    void Start()
    {
        spriteRen = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        spriteRen.sprite = pressedBtnSprite_;
        WinLevel();
    }
    private void OnMouseUp()
    {
        spriteRen.sprite = defaultBtnSprite_;
    }

    private void WinLevel()
    {
        StartCoroutine(GameObject.FindFirstObjectByType<LevelScript>().LoadLevel());
       
        Debug.Log("Win Level!, GameManager switch to nextlevel");
    }

    //private void OnMouseEnter()
    //{
    //    spriteRen.sprite = pressedBtnSprite_;
    //}

    //private void OnMouseExit()
    //{
    //    spriteRen.sprite = defaultBtnSprite_;
    //}
}
