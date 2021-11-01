using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int Value;
    private PlayerContoller Player => FindObjectOfType<PlayerContoller>();
    private Rigidbody2D Rigidbody2D => GetComponent<Rigidbody2D>();

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Ground>() && Player != null)
        {
            Player.TakeDamage();
            Destroy(gameObject);
        }
        if (col.gameObject.GetComponent<PlayerContoller>())
        {
            Player.Score.AddScore(Value);
            Destroy(gameObject);
        }
    }

    public void SetSpeedByScore(int score)
    {
        Rigidbody2D.gravityScale += score / 10f;
    }


}
