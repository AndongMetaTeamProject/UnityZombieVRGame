using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    public float speed = 5;  //������ ���ư� �ӵ� ���ϱ�
    public float destroyTime = 3.0f;  //������ ������ �ð�
    float currentTime; //��� �ð�

    void OnEnable()  //������Ʈ�� Ȱ��ȭ �� �� ȣ��Ǵ� �ݹ� �Լ�
    {
        currentTime = 0;
        Vector3 direction = Random.insideUnitSphere;  //������ ������ ã�´�
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = direction * speed;   //������ �������� ���ư��� �ӵ��� �ش�
    }

    void Update()
    {
        currentTime += Time.deltaTime;  //�ð��� ����

        if (currentTime > destroyTime)   //3�ʰ� �����ٸ�
        {
            gameObject.SetActive(false);  //Voxel�� ��Ȱ��ȭ
            VoxelMaker.voxelPool.Add(gameObject);   //������Ʈ Ǯ�� �ٽ� �־��ش�
        }
    }
}
