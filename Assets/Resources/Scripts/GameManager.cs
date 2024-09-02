using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cloudPrefabs;
    [SerializeField] private int cloudCount;
    [SerializeField] private GameObject goalCloud;

    private float cloudVerticalDistance = 2.3f;
    private float startCloudVerticalPosition = -5.1f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        goalCloud.transform.position = new Vector3(0, startCloudVerticalPosition + ((cloudCount + 1) * cloudVerticalDistance), 0);

        for (int i = 0; i < cloudCount; i++)
        {
            CloudController cloud = Instantiate(cloudPrefabs, new Vector3(0, startCloudVerticalPosition + ((i + 1) * cloudVerticalDistance), 0), Quaternion.identity, GameObject.Find("Clouds").transform).GetComponent<CloudController>();
            // 홀수번째 발판이면
            if (i % 2 == 1)
            {
                // 랜덤으로 둘 중 하나를 생성한다.
                if (Random.Range(0, 2) == 0)
                {
                    cloud.SetCloudProp(CloudType.MIDDLE);
                }
                else
                {
                    cloud.SetCloudProp(CloudType.MOVE);
                }
            }
            else
            {
                // 짝수번째 발판이면
                if (Random.Range(0, 2) == 0)
                {
                    cloud.SetCloudProp(CloudType.STOP);
                }
                else
                {
                    cloud.SetCloudProp(CloudType.SIDE);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
