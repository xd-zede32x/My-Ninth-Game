using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speedPlayer;
    [SerializeField] private Text _textScore;

    private Rigidbody _rigidbody;
    private int _score = 0;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        _rigidbody.AddForce(movement * _speedPlayer);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bottle")
        {
            _score++;
            _textScore.text = _score.ToString();
            Destroy(other.gameObject);
        }
    }
}