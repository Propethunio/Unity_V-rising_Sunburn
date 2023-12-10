using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunlightManager : MonoBehaviour {

    public static SunlightManager instance;

    [SerializeField] Animator lightAnimator;
    [SerializeField] float dayLength;

    float dayTime;


    private void Awake() {
        instance = this;
    }

    private void Start() {
        float multiplier = 24 / dayLength;
        lightAnimator.SetFloat("Multiplier", multiplier);
    }

    private void Update() {
        dayTime = (dayTime + Time.deltaTime) % dayLength;
    }

    private int GetHour() {
        return Mathf.FloorToInt(GetDayTimeNormalized() * 24);
    }

    public float GetDayTimeNormalized() {
        return dayTime / dayLength;
    }

    public bool isDayTime() {
        int hour = GetHour();
        return hour >= 10 && hour <= 17;
    }
}