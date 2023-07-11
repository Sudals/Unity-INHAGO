using UnityEngine;
using UnityEngine.UI;

public class GPSManagerScript : MonoBehaviour
{
    private bool hasGpsPermission = false;
    private float latitude;
    private float longitude;

    public Text latitudeText;
    public Text longitudeText;

    // Start is called before the first frame update
    void Start()
    {
        // GPS 권한 요청
        UnityEngine.Android.Permission.RequestUserPermission("android.permission.ACCESS_FINE_LOCATION");
    }

    // Update is called once per frame
    void Update()
    {
        // GPS 좌표 가져오기
        if (hasGpsPermission)
        {
            if (Input.location.isEnabledByUser && Input.location.status == LocationServiceStatus.Running)
            {
                latitude = Input.location.lastData.latitude;
                longitude = Input.location.lastData.longitude;

                // 좌표 텍스트 업데이트
                latitudeText.text = "Latitude: " + latitude.ToString();
                longitudeText.text = "Longitude: " + longitude.ToString();
            }
        }
    }

    // 권한 요청 결과 처리
    private void OnGUI()
    {
        if (!hasGpsPermission)
        {
            if (UnityEngine.Android.Permission.HasUserAuthorizedPermission("android.permission.ACCESS_FINE_LOCATION"))
            {
                hasGpsPermission = true;
                Input.location.Start();
            }
        }
    }
}
