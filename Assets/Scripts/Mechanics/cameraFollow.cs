using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    public enum CameraState
    {
        None,
        Follow,
        Bound,
        Transition
    }
    public CameraState currentState;

    public float minXPos;
    public float maxXPos;
    public Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if(player == null)
            {
                Debug.LogError("No target assigned as player. Please include valid reference in the cameraFollow script");
                return;
            }
            target = player.transform;
        }
    }

    //regular update function is specifically linked to the computers tick rate - useful for input handling
    //fixed update runs on an exact fixed time (60FPS = 1/60 0.166666s) - this is useful for physics as a proper fixed update that is decoupled from rendering
    //allows for more consistent physics behaviour.
    //Late update is the last update in a frame after all fixed update and update cycles have run. Unity specifies that LateUpdate is generally useful for camera movement as it is the last thing that will happen in a frame.

    // Update is called once per frame
    void LateUpdate()
    {
        if (target == null) return;

        Vector3 currentPos = transform.position;
        currentPos.x = Mathf.Clamp(target.position.x, minXPos, maxXPos);
        transform.position = Vector3.MoveTowards(transform.position, currentPos, 5 * Time.deltaTime);
    }
}
