using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {
    public GameObject logo;
    private void Start()
    {
        StartCoroutine(FadeOut());
        StartCoroutine(Disable());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(2.0f);
        this.gameObject.GetComponent<Image>().CrossFadeAlpha(0f, 3.0f, false);
        logo.gameObject.GetComponent<Image>().CrossFadeAlpha(0f, 3.0f, false);
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(5.0f);
        this.gameObject.SetActive(false);
    }
}
