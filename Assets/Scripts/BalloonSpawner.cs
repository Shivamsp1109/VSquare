using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject purpleBalloonPrefab;
    public GameObject yelllowBalloonPrefab;
    public GameObject redBalloonPrefab;

    void Start()
    {
        TcpClient client = new TcpClient("localhost", 34999);  // Connect to Python server
        // int port = ((IPEndPoint)client.Client.LocalEndPoint).Port;  // Get the port number assigned by the OS
        // client.Connect("localhost", port);  // Connect to the server using the port number
        NetworkStream stream = client.GetStream();

        byte[] data = new byte[1024];
        string responseData = "";

        while (true)
        {
            int bytes = stream.Read(data, 0, data.Length);
            responseData = Encoding.ASCII.GetString(data, 0, bytes);

            string[] parts = responseData.Split(',');
            float x = float.Parse(parts[0]);
            float z = float.Parse(parts[1]);
            string color = parts[2];
            float speed = float.Parse(parts[3]);

            GameObject balloonPrefab = null;
            if (color == "Purple")
            {
                balloonPrefab = purpleBalloonPrefab;
            }
            else if (color == "Yellow")
            {
                balloonPrefab = yellowBalloonPrefab;
            }
            else if (color == "red")
            {
                balloonPrefab = redBalloonPrefab;
            }

            if (balloonPrefab != null)
            {
                GameObject balloon = Instantiate(balloonPrefab, new Vector3(x, 0, z), Quaternion.identity);
                MovementController movController = balloon.GetComponent<MovementController>();
                if (movController != null)
                {
                    movController.speed = speed;  // Set the speed of the balloon
                }
            }
        }

        stream.Close();
        client.Close();
    }
}


