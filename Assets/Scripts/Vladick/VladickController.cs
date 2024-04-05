using Scripts.General.ColliderBased;
using Scripts.General.Utils;
using Scripts.Model;
using UnityEngine;

namespace Scripts.Vladick
{
    public class VladickController : MonoBehaviour
    {
        [Space]
        [Header("Attributes")]
        [SerializeField] private float _speed;
        [SerializeField] private Cooldown _attackCooldown;
        [SerializeField] private Cooldown _soundCooldown;

        [Space]
        [Header("Checkers")]
        [SerializeField] private CheckCircleOverlap _soundInteractChecker;
        [SerializeField] private CheckCircleOverlap _interactChecker;


        private string _currentSound;
        private Vector2 _direction;
        private Rigidbody2D _rigidBody;
        private PlayCurrentSound _sounds;

        public string CurrentSound => _currentSound;
        private Animator _animator;
        private GameSession _session;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
        }

        public void PlaySound(string soundName)
        {
            if (_session.Data.Collection.GetSound(soundName) != null)
            {
                if (_soundCooldown.IsReady)
                {
                    _currentSound = soundName;
                    switch (_currentSound)
                    {
                        default:

                            _sounds.Play(_currentSound);
                            _soundCooldown.Reset();
                            _soundInteractChecker.Check();
                            break;

                        case "Sound4":
                            if (_attackCooldown.IsReady)
                            {
                                _attackCooldown.Reset();
                                _sounds.Play(_currentSound);
                                _soundCooldown.Reset();
                                _soundInteractChecker.Check();
                            }
                            break;
                    }
                }
            }
        }
        public void InteractNoSound()
        {
            _interactChecker.Check();
        }

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _sounds = GetComponent<PlayCurrentSound>();
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        private void Update()
        {
            _animator.SetFloat("Horizontal", _direction.x);
            _animator.SetFloat("Vertical", _direction.y);
            _animator.SetFloat("Speed", _direction.sqrMagnitude);
        }

        private void FixedUpdate()
        {
            var directionVelocity = _direction * _speed;
            _rigidBody.velocity = directionVelocity;
        }
    }
}
