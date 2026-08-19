using UnityEngine;

public class BackExit : MonoBehaviour
{
    public Transform player;
    public Transform endPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        player.position = endPoint.position;

        if (GameManager.Instance.hasAnomaly)
        {
            // ˆÙ•Ï‚ª‚ ‚Á‚½‚Ì‚Å–ß‚é‚Ì‚ª³‰ğ
            GameManager.Instance.Correct();
        }
        else
        {
            // ˆÙ•Ï‚ª‚È‚¢‚Ì‚É–ß‚Á‚½‚Ì‚Å•s³‰ğ
            GameManager.Instance.Wrong();
        }

        GameManager.Instance.GenerateAnomaly();
    }
}
