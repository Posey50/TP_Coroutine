using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class AsyncScript : MonoBehaviour
{
    /// <summary>
    /// Speed of the rotation.
    /// </summary>
    [SerializeField]
    private float _rotationSpeed;

    /// <summary>
    /// Button to click to stop the rotation.
    /// </summary>
    [SerializeField]
    private Button _cancelButton;

    /// <summary>
    /// Value indicating that the cube has to rotate.
    /// </summary>
    private bool _isRotating;

    public void StartRotation()
    {
        if (!_isRotating)
        {
            Rotate();
        }
    }

    /// <summary>
    /// Waits 5 seconds before to stop the rotation, or even before if the cancel button is pressed.
    /// </summary>
    /// <returns></returns>
    private async UniTask Rotate()
    {
        CancellationTokenSource tokenSource = new ();

        _cancelButton.onClick.AddListener(() =>
        {
            tokenSource.Cancel();
        });

        _isRotating = true;
        await UniTask.Delay(5000, cancellationToken: tokenSource.Token).SuppressCancellationThrow();
        _isRotating = false;
    }

    /// <summary>
    /// Makes the cube rotate while the bool is true.
    /// </summary>
    private void FixedUpdate()
    {
        if (_isRotating)
        {
            Vector3 rotation = new(0f, _rotationSpeed * Time.deltaTime, 0f);
            transform.Rotate(rotation, Space.World);
        }
    }
}
