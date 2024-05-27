using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    //public Vector2 DefaultResolution = new Vector2(720, 1280);
    //[Range(0f, 1f)] public float WidthOrHeight = 0;

    //[SerializeField] private Camera componentCamera;

    //private float initialSize;
    //private float targetAspect;

    //private float initialFov;
    //private float horizontalFov = 120f;

    //private void Start()
    //{
    //    initialSize = componentCamera.orthographicSize;

    //    targetAspect = DefaultResolution.x / DefaultResolution.y;

    //    initialFov = componentCamera.fieldOfView;
    //    horizontalFov = CalcVerticalFov(initialFov, 1 / targetAspect);
    //}

    //private void Update()
    //{
    //    if (componentCamera.orthographic)
    //    {
    //        float constantWidthSize = initialSize * (targetAspect / componentCamera.aspect);
    //        componentCamera.orthographicSize = Mathf.Lerp(constantWidthSize, initialSize, WidthOrHeight);
    //    }
    //    else
    //    {
    //        float constantWidthFov = CalcVerticalFov(horizontalFov, componentCamera.aspect);
    //        componentCamera.fieldOfView = Mathf.Lerp(constantWidthFov, initialFov, WidthOrHeight);
    //    }
    //}

    //private float CalcVerticalFov(float hFovInDeg, float aspectRatio)
    //{
    //    float hFovInRads = hFovInDeg * Mathf.Deg2Rad;

    //    float vFovInRads = 2 * Mathf.Atan(Mathf.Tan(hFovInRads / 2) / aspectRatio);

    //    return vFovInRads * Mathf.Rad2Deg;
    //}


    // Второй способ


    //[SerializeField] private int widthAspect = 16;
    //[SerializeField] private int heightAspect = 9;
    //[SerializeField] private int updateAspectDelay = 100;
    //private int frame = 0;
    //private int lastWidth = 0;
    //private int lastHeight = 0;

    //private void Update()
    //{
    //    frame++;
    //    if (frame % updateAspectDelay != 0) { return; }

    //    var width = Screen.width;
    //    var height = Screen.height;

    //    if (lastWidth != width)
    //    {
    //        float heightAccordingToWidth = (float)width / widthAspect * heightAspect;
    //        Screen.SetResolution(width, (int)Mathf.Round(heightAccordingToWidth), false);
    //    }
    //    else if (lastHeight != height)
    //    {
    //        float widthAccordingToHeight = (float)height / heightAspect * widthAspect;
    //        Screen.SetResolution((int)Mathf.Round(widthAccordingToHeight), height, false);
    //    }

    //    lastWidth = width;
    //    lastHeight = height;
    //}

    // Третий споосб

    //public Camera myCamera;
    //public float targetAspectRatio = 16f / 9f; // Целевое соотношение сторон

    //void Update()
    //{
    //    float currentWidth = Screen.width;
    //    float currentHeight = Screen.height;

    //    // Расчитываем новый ортографический размер
    //    float newOrthoSize = (currentWidth > currentHeight) ?
    //        currentHeight * targetAspectRatio :
    //        currentWidth;

    //    // Применяем новый ортографический размер
    //    myCamera.orthographicSize = newOrthoSize;
    //}

    // ЛУЧШИЙ ВАРИАНТ РЕШЕНИЯ

    [SerializeField] private Camera cam;

    void Update()
    {
        // Получаем текущее соотношение сторон экрана
        float targetAspect = 16.0f / 9.0f; // Целевое соотношение сторон
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        // Настраиваем размер и положение области просмотра камеры
        Rect rect = cam.rect;

        if (scaleHeight < 1.0f)
        {
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
        }
        else
        {
            float scaleWidth = 2.0f / scaleHeight;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
        }

        //rect.width = Screen.width;
        //rect.height = Screen.height;
        //rect.x = 0.5f;
        //rect.y = 0.5f;

        cam.rect = rect;
    }
}
