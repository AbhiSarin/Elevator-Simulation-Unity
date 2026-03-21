using UnityEngine;

public class FloorConfig : MonoBehaviour
{
    public static FloorConfig Instance;

    public float floorHeight = 5f;
    public int totalFloors = 4;

    private void Awake()
    {
        Instance = this;
    }

    public float GetY(int floor)
    {
        return floor * floorHeight;
    }
}