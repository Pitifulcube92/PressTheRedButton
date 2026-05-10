using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongButton_Class : MonoBehaviour
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
        lossChance();
    }
    private void OnMouseUp()
    {
        spriteRen.sprite = defaultBtnSprite_;
    }

    private void lossChance()
    {
        GameObject.FindObjectOfType<LevelScript>().LostChance();
        GameObject.FindObjectOfType<Camera_Shake_Component>().ShakeCamera(1, 1);
        Debug.Log("Wrong! Loss a chance");

    }
}
