using System.Collections.Generic;
using UnityEngine;

public class ElevatorSystemManager : MonoBehaviour
{
    public List<ElevatorController> elevators;

    private HashSet<int> activeRequests = new HashSet<int>();

    public void RequestElevator(int floor, Direction direction)
    {
        if (activeRequests.Contains(floor))
            return;

        activeRequests.Add(floor);

        ElevatorController best = FindBestElevator(floor, direction);

        if (best != null)
        {
            best.AddRequest(floor);
        }
    }

    ElevatorController FindBestElevator(int floor, Direction dir)
    {
        ElevatorController best = null;
        float bestScore = float.MaxValue;

        foreach (var elevator in elevators)
        {
            float score = CalculateScore(elevator, floor, dir);

            if (score < bestScore)
            {
                bestScore = score;
                best = elevator;
            }
        }

        return best;
    }

    float CalculateScore(ElevatorController e, int requestFloor, Direction requestDir)
    {
        float distance = Mathf.Abs(e.CurrentFloor - requestFloor);

        // Priority 1: Idle elevators
        if (e.IsIdle())
            return distance;

        // Priority 2: Moving in same direction and will pass floor
        if (e.CurrentDirection == requestDir)
        {
            if ((requestDir == Direction.Up && requestFloor >= e.CurrentFloor) ||
                (requestDir == Direction.Down && requestFloor <= e.CurrentFloor))
            {
                return distance * 0.5f; // highly preferred
            }
        }

        // Penalize wrong direction
        return distance + 10f;
    }
}