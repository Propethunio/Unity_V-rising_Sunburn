using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunlightCamera : MonoBehaviour {

    public static SunlightCamera instance;

    [SerializeField] Light sunLight;

    RenderTexture renderTexture;

    private void Awake() {
        instance = this;
        renderTexture = GetComponent<Camera>().targetTexture;
    }

    public bool IsInSunlight() {
        transform.forward = -sunLight.transform.forward;
        RenderTexture.active = renderTexture;
        Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
        Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
        texture2D.ReadPixels(rect, 0, 0);
        Color skyColor = texture2D.GetPixel(0, 0);
        RenderTexture.active = null;
        return skyColor.a < .1f;
    }
}