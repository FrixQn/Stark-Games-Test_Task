using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    [SerializeField, Range(5f, 20f)] private float Speed;
    [SerializeField] private int Helth;
    private HelthValue HelthValue { get => FindObjectOfType<HelthValue>(); set => FindObjectOfType<HelthValue>();}
    public Score Score => FindObjectOfType<Score>();
    private SpriteRenderer PlayerSpriteRenderer => GetComponent<SpriteRenderer>();
    private Transform PlayerTransform => GetComponent<Transform>();


    private Border Border;
    private enum Direction {Left, Right};

    private void Awake()
    {
        Border = new Border(Camera.main, PlayerSpriteRenderer);
        HelthValue.UpdateValue(Helth);
        Score.RefreshValue();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Border.GetMouseScreenSide(Camera.main.ScreenToWorldPoint(Input.mousePosition)) == Vector3.left)
            {
                MoveDirection(Direction.Left);
            }else
            {
                MoveDirection(Direction.Right);
            }
        }
    }

    private void MoveDirection(Direction direction)
    {
        if (direction == Direction.Right)
        {
            if (PlayerTransform.position.x < Border.Right.x){
                PlayerTransform.position += Vector3.right * Speed * Time.deltaTime;
            }else
            {
                PlayerTransform.position = new Vector3(Border.Right.x, gameObject.transform.position.y , gameObject.transform.position.z);   
            }
        }

        if (direction == Direction.Left)
        {
            if (PlayerTransform.position.x > Border.Left.x){
                PlayerTransform.position -= Vector3.right * Speed * Time.deltaTime;
            }else
            {
                PlayerTransform.position = new Vector3(Border.Left.x, gameObject.transform.position.y , gameObject.transform.position.z);   
            }
        }
    }

    public void TakeDamage()
    {
        if (Helth - 1 > 0){
        Helth--;
        HelthValue.UpdateValue(Helth);
        }else
        {
            Score.ShowFinalResult();
            GameController gameController = FindObjectOfType<GameController>();
            HelthValue.Hide();
            gameController.RestartButton().SetActive(true);
            Destroy(gameObject);
        }
    }

    public Border GetBorder()
    {
        return Border;
    }
}
