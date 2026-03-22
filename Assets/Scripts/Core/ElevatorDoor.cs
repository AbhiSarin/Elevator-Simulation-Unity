using System.Collections;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    public Animator animator;

    private bool isOpenComplete;
    private bool isCloseComplete;

    public IEnumerator OpenDoor()
    {
        isOpenComplete = false;

        animator.ResetTrigger("Close");
        animator.SetTrigger("Open");

        yield return new WaitUntil(() => isOpenComplete);
    }

    public IEnumerator CloseDoor()
    {
        isCloseComplete = false;

        animator.ResetTrigger("Open");
        animator.SetTrigger("Close");

        yield return new WaitUntil(() => isCloseComplete);
    }

    //  Called via Animation Events
    public void OnDoorOpened()
    {
        Debug.Log("Door Opened Event Triggered");
        isOpenComplete = true;
    }

    public void OnDoorClosed()
    {
        Debug.Log("Door Clossed Event Triggered");
        isCloseComplete = true;
    }
}