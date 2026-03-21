public enum Direction { Up, Down }

public class ElevatorRequest
{
    public int Floor;
    public Direction Direction;

    public ElevatorRequest(int floor, Direction dir)
    {
        Floor = floor;
        Direction = dir;
    }
}