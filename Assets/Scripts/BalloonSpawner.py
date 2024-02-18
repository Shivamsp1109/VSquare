import socket
import time
import random

HOST = "localhost"  # IP address of the machine running Unity
PORT = 34999        # Port to listen on

colors = ['Purple', 'Yellow', 'Red']
speeds = [0.5, 0.8, 1.0]  # Speeds for Purple, Yellow, and Red balloons

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    s.bind((HOST, PORT))
    s.listen()
    client, addr = s.accept()
    with client:
        print('Connected by', addr)
        while True:
            x_position = random.uniform(-2.2, 2.2)  # Random x position within a range
            z_position = -10  # Position at the bottom of the screen
            color = random.choice(colors)  # Randomly choose a color
            speed = speeds[colors.index(color)]  # Get speed corresponding to the color
            data = f"{x_position},{z_position},{color},{speed}"
            client.sendall(data.encode())
            time.sleep(random.uniform(0.5, 2.0))  # Wait for a short time before spawning the next balloon
