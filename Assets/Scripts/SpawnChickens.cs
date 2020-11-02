using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChickens : MonoBehaviour
{
    public Vector3 Min;
    public Vector3 Max;
    private float _xAxis;
    private float _yAxis;
    private float _zAxis; //If you need this, use it
    private Vector3 _randomPosition;
    private Vector3 _spawnPositionDown;
    public GameObject chicken;
    public GameObject[] chickens;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<10; i++)
        {
            _xAxis = UnityEngine.Random.Range(Min.x, Max.x);
            _yAxis = UnityEngine.Random.Range(Min.y, Max.y);
            _zAxis = UnityEngine.Random.Range(Min.z, Max.z);
            _randomPosition = new Vector3(_xAxis, _yAxis, _zAxis);
            Instantiate(chicken, _randomPosition, Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
