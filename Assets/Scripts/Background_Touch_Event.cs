using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Background_Touch_Event : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        GameObject.FindObjectOfType<LevelScript>().LostChance();
    }
}
