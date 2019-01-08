using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class Upgrade : MonoBehaviour
{
    public Camera cam;
    public Clicker clicker;
    public TextScript numberText;
    public TextScript costText;
    int number = 0;
    public int clicksPerSecond = 1;
    public float cost = 20;
    public float costMultiplier = 1.5f;
    public AudioSource source;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    if (clicker.clicks >= cost)
                    {
                        clicker.clicks -= cost;
                        cost *= costMultiplier;
                        number++;

                        source.PlayOneShot(clip);
                    }
                }
            }

        }

        clicker.clicks += clicksPerSecond * number * Time.deltaTime;
        numberText.text = "x" + number;
        if (cost >= 1000)
        {
            costText.text = UTIL.formatNumber(Mathf.Ceil(cost), 2, false) + "\nclicks";
        } else
        {
            costText.text = "" + Mathf.Ceil(cost) + "\nclicks";
        }
    }
}
