using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public float clicks = 0;
    public Camera cam;
    public TextScript points;
    public TextScript plusOne;
    public float resizeWhenClick = .9f;
    public float resizeSeconds = .1f;
    public AudioClip click;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform) {
                    clicks++;
                    // draw + 1
                    TextScript textScript = Instantiate(plusOne);
                    textScript.transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
                    textScript.text = "+1";
                    textScript.fadeOut = true; // make it fade away
                    // make button appear to be clicked
                    StartCoroutine(resize());
                    // play click sound
                    source.PlayOneShot(click);


                }
            }
            
        }

        if (clicks >= 1000) {
            points.text = UTIL.formatNumber(Mathf.Floor(clicks), 2, true);
        } else
        {
            points.text = "" + Mathf.Floor(clicks);
        }

    }

    IEnumerator resize()
    {
        transform.localScale *= resizeWhenClick;
        yield return new WaitForSeconds(resizeSeconds);
        transform.localScale /= resizeWhenClick;
    }
    
}
