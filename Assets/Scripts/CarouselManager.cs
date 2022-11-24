using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarouselManager : MonoBehaviour
{

    public float snapSpeed = 0.1f;
    public Transform snapPoint;
    public Transform panelsGroup;
    public int currentPanel = 0;
    public float snapDiff = 10;

    private Transform nearestPanel;

    void Update() {
        snapPoint.position = currentPanel * snapDiff * Vector2.left;
        panelsGroup.position = Vector2.Lerp(panelsGroup.position, snapPoint.position, snapSpeed);

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            UpdateCarousel(1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            UpdateCarousel(-1);
        }
    }

    public void UpdateCarousel(int num) {
        currentPanel += num;
        currentPanel = (int)Mathf.Repeat(currentPanel, panelsGroup.childCount);
    }

}
