using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combinebuttons : MonoBehaviour
{
    [SerializeField] private GameObject _redbutton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Other_Button_Part")
        {
            StartCoroutine(SpawnRedbutton(collision));
        }
    }

    public IEnumerator SpawnRedbutton(Collider2D tmpColl_)
    {
        Instantiate(_redbutton, gameObject.transform);

        yield return new WaitForSeconds(0.5f);

        Destroy(tmpColl_.gameObject);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
