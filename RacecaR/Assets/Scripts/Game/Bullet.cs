using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject laser;
    public float speed;

    private void Start()
    {
        laser = gameObject;
    }

    private void Update()
    {
        laser.transform.Translate(Vector3.forward);
    }
}
