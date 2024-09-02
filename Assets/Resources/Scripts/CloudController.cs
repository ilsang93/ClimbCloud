using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    private float speed;
    private CloudType cloudType;
    private float movingDistance = 0;
    // Start is called before the first frame update
    void Start()
    {
        movingDistance = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (cloudType == CloudType.MOVE)
        {
            movingDistance += speed * Time.deltaTime;
            transform.position = new Vector3(Mathf.Sin(movingDistance) * 1.6f, transform.position.y, 0);
        }
    }

    public void SetCloudProp(CloudType cloudType)
    {
        speed = Random.Range(0.2f, 0.5f);
        this.cloudType = cloudType;

        switch (cloudType)
        {
            case CloudType.SIDE:
                transform.position = new Vector3(Random.Range(0, 1) == 0 ? -1.6f : 1.6f, transform.position.y, 0);
                break;
            case CloudType.MIDDLE:
                transform.position = new Vector3(0, transform.position.y, 0);
                break;
            case CloudType.STOP:
                transform.position = new Vector3(Random.Range(-1.3f, 1.3f), transform.position.y, 0);
                break;
            case CloudType.MOVE:
                transform.position = new Vector3(Random.Range(-1.6f, 1.6f), transform.position.y, 0);
                movingDistance = transform.position.x;
                break;
        }
    }
}

public enum CloudType
{
    SIDE,
    MOVE,
    MIDDLE,
    STOP
}
