using System;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public bool isFollowing { get; private set; }

    private void Update()
    {
        if (isFollowing)
        {
            print(3);
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = 0f;
            transform.position = mousepos;

            if (Input.GetMouseButtonUp(0))
            {
                StopFollowing();
            }
        }
    }

    private void OnMouseDown()
    {
        print(1);
        if (!isFollowing)
        {
            StartFollowing();
        }
    }

    public void StartFollowing()
    {
        isFollowing = true;
        transform.parent = null;
        print(2);
    }

    public void StopFollowing()
    {
        isFollowing = false;
    }
}
