using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Camera m_Camera;
    [SerializeField] private Transform Player;

    [Range(0.5f, 10)]
    [SerializeField] private float cameraSpeed = 2;

    [Range(0, 1)]
    [SerializeField] private float cameraOffset = 0.2f;

    private float fixedZ = -10;

    private void Awake()
    {
        m_Camera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        //플레이어로부터 n% 떨어진 위치로 보정되게끔 처리
        Vector3 offset = (transform.position - Player.position) * cameraOffset;

        Vector3 desire = new Vector3(
            Player.position.x + offset.x,
            Player.position.y + offset.y,
            fixedZ
        );
        //위치 보간
        Vector3 smooth = Vector3.Lerp(transform.position, desire, cameraSpeed*Time.deltaTime);
        //z고정
        smooth.z = fixedZ;
        //위치 업데이트
        transform.position = smooth;
    }

}
