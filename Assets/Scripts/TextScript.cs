using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    public string text;
    public GUIStyle style;
    public int textWidth = 300;
    public int textHeight = 20;
    public bool fadeOut = false;
    public float timeToFade = 1f;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeOut)
        {
            float alphasPerSecond = 1 / timeToFade;
            Color c = style.normal.textColor;
            c.a = Mathf.Max(0, c.a - Time.deltaTime * alphasPerSecond);
            style.normal.textColor = c;
            if (c.a == 0) // free up space
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnGUI()
    {
        Vector3 loc = cam.WorldToScreenPoint(transform.position);
        Rect r = new Rect(loc.x - textWidth/2, Screen.height - loc.y, textWidth, textHeight);
        UTIL.drawOutline(r, text, style, Color.black);
    }
}
