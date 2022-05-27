using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderController : MonoBehaviour
{
    public Slider slider;
    public GameObject slider_show;
    public Button button;

    public void reverseSetActive()
    {
        slider_show.SetActive(!this.slider.IsActive());
    }

    void Start()
    {
        slider_show.SetActive(false);
    }

    void Update()
    {
        if (button.IsActive())
        {
            slider_show.transform.position = new Vector3(375, 618, 0);
        }
        else
        {
            slider_show.transform.position = new Vector3(375, 718, 0);
        }
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("changePoint");
        foreach (GameObject i in gameObjects)
        {
            i.transform.localScale = new Vector3(slider.value * 10 + 1, slider.value * 10 + 1, slider.value * 10 + 1);
        }
    }
}
