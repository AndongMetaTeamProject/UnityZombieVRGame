using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFactory : MonoBehaviour
{
   public GameObject characterPrefab;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 20f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CharacterSpawn", GetRandomSpawnInterval());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CharacterSpawn()
    {
        // characterPrefab을 인스턴스화하여 캐릭터 생성
        GameObject character = Instantiate(characterPrefab, transform.position, Quaternion.identity);

        // 다음 소환을 위한 Invoke 호출
        Invoke("CharacterSpawn", GetRandomSpawnInterval());
    }

    private float GetRandomSpawnInterval()
    {
        return Random.Range(minSpawnInterval, maxSpawnInterval);
    }
}
