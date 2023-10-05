namespace GrayHoodT.Inputs
{
    using GrayHoodT.Events;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public abstract class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        public enum AxisOptionType { Both, Horizontal, Vertical }
        
        #region Fields

        [SerializeField] private float _handleRange = 1;
        [SerializeField] private float _deadZone = 0;
        [SerializeField] private AxisOptionType _axisOptionType = AxisOptionType.Both;
        [SerializeField] private bool _snapX = false;
        [SerializeField] private bool _snapY = false;

        [SerializeField] protected RectTransform _background = null;
        [SerializeField] private RectTransform _handle = null;
        private RectTransform _baseRect = null;

        private Canvas _canvas;
        private Camera _cam;

        private Vector2 _input = Vector2.zero;

        [SerializeField] protected Vector2EventSO _onDirectionChanged;

        #endregion

        #region Properties

        public float Horizontal { get { return (_snapX) ? SnapFloat(_input.x, AxisOptionType.Horizontal) : _input.x; } }
        public float Vertical { get { return (_snapY) ? SnapFloat(_input.y, AxisOptionType.Vertical) : _input.y; } }
        public Vector2 Direction { get { return new Vector2(Horizontal, Vertical); } }

        public float HandleRange
        {
            get { return _handleRange; }
            set { _handleRange = Mathf.Abs(value); }
        }

        public float DeadZone
        {
            get { return _deadZone; }
            set { _deadZone = Mathf.Abs(value); }
        }

        public AxisOptionType AxisOptions { get { return AxisOptions; } set { _axisOptionType = value; } }
        public bool SnapX { get { return _snapX; } set { _snapX = value; } }
        public bool SnapY { get { return _snapY; } set { _snapY = value; } }

        #endregion

        #region Unity Lifycycles

        protected virtual void Start()
        {
            HandleRange = _handleRange;
            DeadZone = _deadZone;
            _baseRect = GetComponent<RectTransform>();
            _canvas = GetComponentInParent<Canvas>();
            if (_canvas == null)
                Debug.LogError("The Joystick is not placed inside a canvas");

            Vector2 center = new Vector2(0.5f, 0.5f);
            _background.pivot = center;
            _handle.anchorMin = center;
            _handle.anchorMax = center;
            _handle.pivot = center;
            _handle.anchoredPosition = Vector2.zero;
        }

        #endregion
        
        #region Public Funcs

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            _cam = null;
            if (_canvas.renderMode == RenderMode.ScreenSpaceCamera)
                _cam = _canvas.worldCamera;

            Vector2 position = RectTransformUtility.WorldToScreenPoint(_cam, _background.position);
            Vector2 radius = _background.sizeDelta / 2;
            _input = (eventData.position - position) / (radius * _canvas.scaleFactor);

            FormatInput();
            HandleInput(_input.magnitude, _input.normalized, radius, _cam);
            _handle.anchoredPosition = _input * radius * _handleRange;

            _onDirectionChanged?.Invoke(this, Direction);
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            _input = Vector2.zero;
            _handle.anchoredPosition = Vector2.zero;

            _onDirectionChanged?.Invoke(this, Direction);
        }

        #endregion

        #region Protected Funcs

        protected virtual void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
        {
            if (magnitude > _deadZone)
            {
                if (magnitude > 1)
                    _input = normalised;
            }
            else
                _input = Vector2.zero;
        }

        protected Vector2 ScreenPointToAnchoredPosition(Vector2 screenPosition)
        {
            Vector2 localPoint = Vector2.zero;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_baseRect, screenPosition, _cam, out localPoint))
            {
                Vector2 pivotOffset = _baseRect.pivot * _baseRect.sizeDelta;
                return localPoint - (_baseRect.anchorMax * _baseRect.sizeDelta) + pivotOffset;
            }
            return Vector2.zero;
        }

        #endregion

        #region Private Funcs

        private void FormatInput()
        {
            if (_axisOptionType == AxisOptionType.Horizontal)
                _input = new Vector2(_input.x, 0f);
            else if (_axisOptionType == AxisOptionType.Vertical)
                _input = new Vector2(0f, _input.y);
        }

        private float SnapFloat(float value, AxisOptionType snapAxis)
        {
            if (value == 0)
                return value;

            if (_axisOptionType == AxisOptionType.Both)
            {
                float angle = Vector2.Angle(_input, Vector2.up);
                if (snapAxis == AxisOptionType.Horizontal)
                {
                    if (angle < 22.5f || angle > 157.5f)
                        return 0;
                    else
                        return (value > 0) ? 1 : -1;
                }
                else if (snapAxis == AxisOptionType.Vertical)
                {
                    if (angle > 67.5f && angle < 112.5f)
                        return 0;
                    else
                        return (value > 0) ? 1 : -1;
                }
                return value;
            }
            else
            {
                if (value > 0)
                    return 1;
                if (value < 0)
                    return -1;
            }
            return 0;
        }

        #endregion
    }
}

