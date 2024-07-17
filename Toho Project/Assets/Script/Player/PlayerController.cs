using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _dashSpeed;
     private float _dashTime;
     private float _cdTimer;
    [SerializeField] private float _dashCdTime;

    [SerializeField] private Rigidbody2D _Rb2D;
    [SerializeField] private Animator _animator;

    [HideInInspector] public Vector2 moveDir;

    private bool _dash = false;

    private void Update()
    {
        _cdTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_cdTimer < 0 && moveDir.sqrMagnitude != 0)
            {
                _cdTimer = _dashCdTime;
                _dash = true;
                Dash();
            }
        }
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");

        _animator.SetFloat("MoveX", moveDir.x);
        _animator.SetFloat("MoveY", moveDir.y);
        _animator.SetFloat("MoveSpeed", moveDir.sqrMagnitude);
        _animator.SetBool("Dash",_dash);

            if (_dashTime > 0)
            {
                _Rb2D.MovePosition(_Rb2D.position + moveDir.normalized * _dashSpeed * Time.fixedDeltaTime);
                _dashTime -= Time.deltaTime;
                _dash = false;
            }
            else
            {
                _Rb2D.MovePosition(_Rb2D.position + moveDir.normalized * _speed * Time.fixedDeltaTime);
            }
    }
    void Dash()
    {
        _dashTime = 0.5f;
    }
}
