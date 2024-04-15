using UnityEngine;

public class CameraControll : MonoSingleton<CameraControll>
{
    [Header ("Speed Var")]
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private GameObject[] comePoints;
    [SerializeField] private int index = 0;
    private void Awake()
    {
        comePoints = GameObject.FindGameObjectsWithTag("ComePoint");
    }

    void Update()
    {
        if (index <= comePoints.Length-1)
            transform.position = Vector3.Lerp(transform.position, comePoints[index].transform.position, moveSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        FinishEpisode.LevelIsOver += LevelIsOver_CameraControll;
    }
    private void OnDisable()
    {
        FinishEpisode.LevelIsOver -= LevelIsOver_CameraControll;
    }
    private void LevelIsOver_CameraControll()
    {
        index++;
    }
}
