using UnityEngine;

public static class Util {
    public static Quaternion FacingDirection(Vector3 direction, float offset = 0) {
        // Get rotation of the direction in degrees (+ offset)
        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + offset;
        // Returns the representation of rotation
        return Quaternion.Euler(0, 0, rotation);
    }
}