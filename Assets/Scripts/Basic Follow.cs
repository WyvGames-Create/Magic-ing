using UnityEngine;

public class Follow_player : MonoBehaviour {

    public Transform player;
    public Vector3 locationOffset;

    // Update is called once per frame
    void Update () {
        transform.position = player.transform.position + locationOffset;
    }
}