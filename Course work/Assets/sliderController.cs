using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderController : MonoBehaviour
{
    public Slider slider;
    public GameObject slider_show;
    public GameObject sphere;
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
            slider_show.transform.position = new Vector3(375, 252, 0);
        }
        else
        {
            slider_show.transform.position = new Vector3(375, 347, 0);
        }
        sphere.transform.localScale = new Vector3(slider.value + 1, slider.value + 1, slider.value + 1);
    }
}
