using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travelling : MonoBehaviour {
    private float length, startpos, startposclone;
    public GameObject cam;
    public float parallaxEffect;
    public Transform _clone;

    void Start() {
        startpos = transform.position.x;
        startposclone = _clone.transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update() {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        _clone.position = new Vector3(startposclone + dist, _clone.transform.position.y, _clone.transform.position.z);

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;

        if (temp > startposclone + length) startposclone += length;
        else if (temp < startposclone - length) startposclone -= length;
    }

}
