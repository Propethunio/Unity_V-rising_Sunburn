using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour {

    [SerializeField] Image backgroundImage;
    [SerializeField] Transform handTransform;
    [SerializeField] Color nightColor;
    [SerializeField] Color dayColor;

    private void Update() {
        handTransform.eulerAngles = new Vector3(0, 0, -SunlightManager.instance.GetDayTimeNormalized() * 360);
        backgroundImage.color = SunlightManager.instance.isDayTime() ? dayColor : nightColor;
    }
}