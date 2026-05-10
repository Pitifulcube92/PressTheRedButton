using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Object : MonoBehaviour
{
    [SerializeField] private Transform[] _pointLocations;
    [SerializeField] private float _speed;
    [SerializeField] private int startPostion;
    [SerializeField] private GameObject _targetObject;

    private int i;
    // Start is called before the first frame update
    void Start()
    {
        _targetObject.transform.position = _pointLocations[startPostion].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(_targetObject.transform.position, _pointLocations[i].position) < 0.02f)
        {
            i++;
            if (i == _pointLocations.Length)
            {
                i = 0;
            }
        }
        _targetObject.transform.position = Vector2.MoveTowards(_targetObject.transform.position, _pointLocations[i].position, _speed * Time.deltaTime); ;
    }
    
}
