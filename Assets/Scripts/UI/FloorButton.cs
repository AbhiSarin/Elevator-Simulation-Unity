using UnityEngine;

public class FloorButton : MonoBehaviour
{
    public int floor;
    public Direction direction;

    public ElevatorSystemManager system;

    public void Press()
    {
        system.RequestElevator(floor, direction);
    }
}