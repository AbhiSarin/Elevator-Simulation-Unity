using System.Collections;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    public float openTime = 1f;
    public float waitTime = 1f;

    public IEnumerator OpenClose()
    {
        // TODO: Add animation here
        Debug.Log("Door Opening");

        yield return new WaitForSeconds(openTime);

        Debug.Log("Door Waiting");
        yield return new WaitForSeconds(waitTime);

        Debug.Log("Door Closing");
        yield return new WaitForSeconds(openTime);
    }
}