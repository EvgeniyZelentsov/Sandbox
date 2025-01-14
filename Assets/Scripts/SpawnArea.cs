using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    private enum SpawnZone
    {
        Left,
        Right,
        Top,
        Bottom
    }

    [SerializeField] private float spawnOffsetFromBoarders;


    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    public Vector3 GetRandomSpawnPosition()
    {
        //var spawnPositionIndex = Random.Range(0, spawnAreas.Count);

        //var spawnArea = spawnAreas[spawnPositionIndex];
        var randomSpawnZone = (SpawnZone)Random.Range((int)SpawnZone.Left, (int)SpawnZone.Bottom + 1);

        switch (randomSpawnZone)
        {
            case SpawnZone.Left:
                return GetLeftZoneSpawnPosition();

            case SpawnZone.Right:
                return GetRightZoneSpawnPosition();

            case SpawnZone.Top:
                return GetTopZoneSpawnPosition();

            case SpawnZone.Bottom:
                return GetBottomZoneSpawnPosition();

            default: throw new System.Exception();
        }
    }

    private Vector3 GetLeftZoneSpawnPosition()
    {
        var center = transform.position;

        var leftBorder = center - transform.localScale / 2;

        var x = center.x - transform.localScale.x / 2 + spawnOffsetFromBoarders;
        var z = Random.Range(center.z - transform.localScale.z / 2 + spawnOffsetFromBoarders, center.z + transform.localScale.z / 2 - spawnOffsetFromBoarders);

        return new Vector3(x, 1, z);
    }

    private Vector3 GetRightZoneSpawnPosition()
    {
        var center = transform.position;

        var rightBorder = center + transform.localScale / 2;

        var x = center.x + transform.localScale.x / 2 - spawnOffsetFromBoarders;
        var z = Random.Range(center.z + transform.localScale.z / 2 - spawnOffsetFromBoarders, center.z - transform.localScale.z / 2 + spawnOffsetFromBoarders);

        return new Vector3(x, 1, z);
    }
    private Vector3 GetTopZoneSpawnPosition()
    {
        var center = transform.position;

        var rightBorder = center + transform.localScale / 2;

        var x = Random.Range(center.x + transform.localScale.x / 2 - spawnOffsetFromBoarders, center.x - transform.localScale.x / 2 + spawnOffsetFromBoarders);
        var z = center.z - transform.localScale.z / 2 + spawnOffsetFromBoarders;

        return new Vector3(x, 1, z);
    }
    private Vector3 GetBottomZoneSpawnPosition()
    {
        var center = transform.position;

        var rightBorder = center + transform.localScale / 2;

        var x = Random.Range(center.x + transform.localScale.x / 2 - spawnOffsetFromBoarders, center.x - transform.localScale.x / 2 + spawnOffsetFromBoarders);
        var z = center.z + transform.localScale.z / 2 - spawnOffsetFromBoarders;

        return new Vector3(x, 1, z);
    }
}
