using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int obstacleCount = 0;
    public Vector3 obstalceLastPosition = Vector3.zero;
    public int numBgCount = 5;


    // Start is called before the first frame update
    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        obstalceLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for (int i = 0; i < obstacleCount; i++)
        {
            obstalceLastPosition = obstacles[i].SetRandomPlace(obstalceLastPosition, obstacleCount);//obstacle[i]�� ��ġ�� �޼��忡 ���� transform.position ���� ���� ������ ���� ��ȯ�Ͽ� obstaclelastposition ���ִ´� �̴� �ٽ� �Ű������� ���� ���� obstacle[i+1]�� ��ġ�Ѵ�.
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)// ontrigger �浹�� �ߵ�
    {
        if (collision.CompareTag("Background"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;//boxcollider2d�� size ������Ƽ�� �������� Collider2D�� ������ �����Ƿ� BoxCollider2D�� ĳ���� ������Ѵ�.���� square�� transform Scale������ �ݿ����������Ƿ� Transform.lossyScale.x�� ���� world scale�� ��ȯ ���Ѿ��Ѵ�.
            Vector3 pos = collision.transform.position;//���� �ε��� ������Ʈ�� ������

            pos.x += widthOfBgObject * numBgCount;//�ű⿡ ������Ʈ�ʺ�*������ ���ѵ�
            collision.transform.position = pos;//�浹�� ������Ʈ �ش� �����ǿ� ��ġ
            return;//collision�� Obstacle�� �ƴϹǷ� �����ؼ� ���ҽ� ����

        }//(BoxCollider2D)collision.size.x �� �������� ���� ��ȣ�� ���� ������ collision.size.x ���� ã�� �Ǵµ� ĳ������ ���� ���ְ� �ϹǷ� ����ó�� ���

        Obstacle obstacle = collision.GetComponent<Obstacle>();// �浹�� ������Ʈ�� Obstacle ��ũ��Ʈ ������Ʈ�� ������ �ִٸ�, �ش� ������Ʈ�� ������ �����Ѵ�
        if (obstacle)// null �� �ƴ϶�� �� ���� collision�� ������Ʈ�� Obstacle ������Ʈ�� ���ٸ� �۵���������
        {
            obstalceLastPosition = obstacle.SetRandomPlace(obstalceLastPosition, obstacleCount);//���� �ε��� obstacle ��ü�� setrandomplace ���ְ� obstalceLastPosition�� ���� ��ġ �ֱ� �ݺ�
        }
    }
}
