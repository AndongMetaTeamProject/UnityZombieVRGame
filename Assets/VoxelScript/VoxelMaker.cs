using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    public GameObject voxelFactory;  //���� ����
    public int voxelPoolSize = 20;   //������Ʈ Ǯ�� ũ��
    public static List<GameObject> voxelPool = new List<GameObject>();   //������Ʈ Ǯ
    public float createTime = 0.1f;   //���� �ð�
    float currentTime = 0;  //��� �ð�
    public Transform crosshair;   //  ũ�ν����(������) ����
    public ParticleSystem particleSystem;

    void Start()
    {
        for (int i = 0; i < voxelPoolSize; i++)   //������Ʈ Ǯ�� ��Ȱ��ȭ �� ������ ��´�
        {
            GameObject voxel = Instantiate(voxelFactory);   //���� ���忡�� ���� ����
            voxel.SetActive(false);   //���� ��Ȱ��ȭ�ϱ�
            voxelPool.Add(voxel);   //������ ������Ʈ Ǯ�� ��´�
        }
    }

    void Update()
    {
        ARAVRInput.DrawCrosshair(crosshair);  //ũ�ν����(������) �׸���
        if (ARAVRInput.Get(ARAVRInput.Button.One))  //VR ��Ʈ�ѷ��� �߻� ��ư�� ������
        {
            currentTime += Time.deltaTime;  //�����ð� ���� ������ �����
            if (currentTime > createTime)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  //pc �� �� ���콺
                //��Ʈ�ѷ��� ���ϴ� �������� �ü� �����
                //Ray ray = new Ray(ARAVRInput.RHandPosition, ARAVRInput.RHandDirection);
                RaycastHit hitInfo = new RaycastHit();
                if (Physics.Raycast(ray, out hitInfo))   //�ü��� �ٴ� ���� ��ġ�� �ִٸ�
                {
                    if (voxelPool.Count > 0)
                    {
                        currentTime = 0;   //������ �������� ���� ��� �ð��� �ʱ�ȭ ���ش�
                        GameObject voxel = voxelPool[0];   //������Ʈ Ǯ���� ���� �ϳ��� �����´�
                        voxel.SetActive(true);   //������ Ȱ��ȭ�Ѵ�
                        voxel.transform.position = hitInfo.point;   //������ ��ġ�Ѵ�
                        voxelPool.RemoveAt(0);   //������Ʈ Ǯ���� ������ �����Ѵ�
                    }
                }
            }
        }
        /*
        if (ARAVRInput.Get(ARAVRInput.Button.Two))  //VR ��Ʈ�ѷ��� �߻� ��ư�� ������
        {
            currentTime += Time.deltaTime;  //�����ð� ���� ������ �����
            if (currentTime > createTime)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  //pc �� �� ���콺
                //��Ʈ�ѷ��� ���ϴ� �������� �ü� �����
                //Ray ray = new Ray(ARAVRInput.RHandPosition, ARAVRInput.RHandDirection);
                RaycastHit hitInfo = new RaycastHit();
                if (Physics.Raycast(ray, out hitInfo))   //�ü��� �ٴ� ���� ��ġ�� �ִٸ�
                {
                    particleSystem.Play();
                }
            }
        }
        */
    }
}
