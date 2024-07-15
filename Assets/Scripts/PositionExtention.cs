using UnityEngine;

public static class PositionExtention 
{
    public static Vector3 GetPosition(this GameObject gameObject)
    {
        return gameObject.transform.position;
    }
    public static Vector3 GetPosition(this Transform transform)
    {
        return transform.position;
    }
    public static Vector3 GetPosition(this MonoBehaviour behaviour)
    {
        return behaviour.transform.position;
    }
}
