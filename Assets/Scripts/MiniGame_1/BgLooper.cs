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
            obstalceLastPosition = obstacles[i].SetRandomPlace(obstalceLastPosition, obstacleCount);//obstacle[i]의 위치를 메서드에 의해 transform.position 한후 현재 포지션 값을 반환하여 obstaclelastposition 에넣는다 이는 다시 매개변수로 쓰여 다음 obstacle[i+1]을 배치한다.
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)// ontrigger 충돌시 발동
    {
        if (collision.CompareTag("Background"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;//boxcollider2d는 size 프로퍼티를 가지지만 Collider2D는 가지지 않으므로 BoxCollider2D로 캐스팅 해줘야한다.또한 square는 transform Scale배율은 반영하지않으므로 Transform.lossyScale.x를 통해 world scale을 반환 시켜야한다.
            Vector3 pos = collision.transform.position;//현재 부딪힌 오브젝트의 포지션

            pos.x += widthOfBgObject * numBgCount;//거기에 오브젝트너비*갯수를 더한뒤
            collision.transform.position = pos;//충돌한 오브젝트 해당 포지션에 배치
            return;//collision이 Obstacle이 아니므로 종료해서 리소스 절약

        }//(BoxCollider2D)collision.size.x 가 오류나는 이유 괄호가 없어 순서가 collision.size.x 값을 찾게 되는데 캐스팅을 먼저 해주게 하므로 본문처럼 사용

        Obstacle obstacle = collision.GetComponent<Obstacle>();// 충돌한 오브젝트가 Obstacle 스크립트 컴포넌트를 가지고 있다면, 해당 컴포넌트를 변수에 저장한다
        if (obstacle)// null 이 아니라는 뜻 만약 collision한 오브젝트에 Obstacle 컴포넌트가 없다면 작동하지않음
        {
            obstalceLastPosition = obstacle.SetRandomPlace(obstalceLastPosition, obstacleCount);//현재 부딪힌 obstacle 객체를 setrandomplace 해주고 obstalceLastPosition에 현재 위치 넣기 반복
        }
    }
}
