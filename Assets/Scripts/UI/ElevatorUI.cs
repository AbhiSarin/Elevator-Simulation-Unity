using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ElevatorUI : MonoBehaviour
{
    public ElevatorController elevator;
    public TextMeshProUGUI floorText;
    public TextMeshProUGUI stateText;

    void Update()
    {
        floorText.text = "Floor: " + elevator.CurrentFloor;
        stateText.text = elevator.State.ToString();
    }
}