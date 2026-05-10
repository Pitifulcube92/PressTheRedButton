using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movebackground : MonoBehaviour
{
    [SerializeField] private RawImage backgroundImg;
    [SerializeField] private float y, x;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        backgroundImg.uvRect = new Rect(backgroundImg.uvRect.position + new Vector2(x, y) * Time.deltaTime, backgroundImg.uvRect.size);
    }
}
