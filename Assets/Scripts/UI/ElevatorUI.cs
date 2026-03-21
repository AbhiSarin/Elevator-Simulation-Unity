using UnityEngine;
using UnityEngine.UI;

public class ElevatorUI : MonoBehaviour
{
    public ElevatorController elevator;
    public Text floorText;
    public Text stateText;

    void Update()
    {
        floorText.text = "Floor: " + elevator.CurrentFloor;
        stateText.text = elevator.State.ToString();
    }
}