using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private List<Vector3> clickPos = new List<Vector3>();

    private int currentClickPos = -1;

    private bool isFirstClick = true;
    private void Update()
    {
        MovePlayerToPoint();
    }
    private void MovePlayerToPoint()
    {
        if (currentClickPos != -1)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, clickPos[currentClickPos], 2 * Time.deltaTime);
            if (this.gameObject.transform.position == clickPos[currentClickPos])
            {
                if (currentClickPos != clickPos.Count - 1)
                {
                    currentClickPos++;
                }
                else
                {
                    isFirstClick = true;
                    currentClickPos = -1;
                    clickPos.Clear();

                }
            }
        }
    }

    public void AddPoint()
    {
        Vector3 newPosClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickPos.Add(newPosClick);
        if (isFirstClick)
        {
            currentClickPos++;
            isFirstClick = false;
        }
    }
}
