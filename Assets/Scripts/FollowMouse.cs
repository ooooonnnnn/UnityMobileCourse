using System;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public bool isFollowing { get; private set; }

    private void Update()
    {
        if (isFollowing)
        {
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
        if (!isFollowing)
        {
            StartFollowing();
        }
    }

    public void StartFollowing()
    {
        isFollowing = true;
        transform.parent = null;
    }

    public void StopFollowing()
    {
        isFollowing = false;
    }
}
