using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform[] wayPoints;
    public float speed;
    public float turnSpeed;

    private int currentIndex = 1;


    void Update()
    {
        Vector3 dir = (wayPoints[currentIndex].position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;

        if (dir.sqrMagnitude > 0.0001f)
        {
            Quaternion targetRot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, turnSpeed * Time.deltaTime);
        }

        float distance = Vector3.Distance(transform.position, wayPoints[currentIndex].position);

        if (distance < 0.1f)
        {
            if (++currentIndex >= wayPoints.Length)
            {
                currentIndex = 1;
                transform.position = wayPoints[0].position;
            }
        }
    }
}
