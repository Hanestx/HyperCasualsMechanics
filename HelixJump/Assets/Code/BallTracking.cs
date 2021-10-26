using UnityEngine;


public class BallTracking : MonoBehaviour
{
    [SerializeField] private Vector3 _directionOffset;
    [SerializeField] private float _lenght;
    
    private Ball _ball;
    private Shaft _shaft;
    private Vector3 _cameraPosition;
    private Vector3 _minBallPosition;


    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _shaft = FindObjectOfType<Shaft>();

        _cameraPosition = _ball.transform.position;
        _minBallPosition = _ball.transform.position;

        TrackBall();
    }

    private void Update()
    {
        if (_ball.transform.position.y < _minBallPosition.y)
        {
            TrackBall();
            _minBallPosition = _ball.transform.position;
        }
    }

    private void TrackBall()
    {
        Vector3 shaftPosition = _shaft.transform.position;
        shaftPosition.y = _ball.transform.position.y;
        _cameraPosition = _ball.transform.position;
        Vector3 direction = (shaftPosition - _ball.transform.position).normalized + _directionOffset;
        _cameraPosition -= direction * _lenght;
        transform.position = _cameraPosition;
        transform.LookAt(_ball.transform);
        _cameraPosition -= direction * _lenght;
        transform.position = _cameraPosition;
        transform.LookAt(_ball.transform);
    }
}