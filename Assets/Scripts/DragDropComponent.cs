using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropComponent : MonoBehaviour
{
    [SerializeField] Vector3 dragOffset;
    [SerializeField] private Sprite defaultBtnSprite_;
    [SerializeField] private Sprite pressedBtnSprite_;
    [SerializeField] private SpriteRenderer spriteRen;
    public void OnMouseDown()
    {

        dragOffset = transform.position - GetMousePos();
        GameManager.instance.GetSoundManager().PlaySFXClip("ButtonPress", false, GameManager.instance.GetSoundManager().GetSFXSource(1));
        spriteRen.sprite = pressedBtnSprite_;
    }
    public void OnMouseUp()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        GameManager.instance.GetSoundManager().PlaySFXClip("ButtonPress", false, GameManager.instance.GetSoundManager().GetSFXSource(1));
        spriteRen.sprite = defaultBtnSprite_;
    }
    public void OnMouseDrag()
    {
        transform.position = GetMousePos() + dragOffset;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    //public void OnMouseUp()
    //{

    //}
    public Vector3 GetMousePos()
    {
        Vector3 tmp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tmp.z = 0;
        return tmp;
    }
}
