using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunlightUI : MonoBehaviour {

    [SerializeField] Image image;
    [SerializeField] Color nightColor;
    [SerializeField] Color dayColor;

    private void Update() {
        image.color = SunlightManager.instance.isDayTime() ? dayColor : nightColor;
        image.enabled = SunlightCamera.instance.IsInSunlight();
    }
}