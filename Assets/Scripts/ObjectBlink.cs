using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBlink : MonoBehaviour {

    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }
    // Update is called once per frame
    void Update () {
        InvokeRepeating("Blink", 0f, 1f);
    }

    IEnumerator Blink()
    {
        rend.enabled = false;
        yield return new WaitForSeconds(0.2f);
        rend.enabled = true;
    }
}
