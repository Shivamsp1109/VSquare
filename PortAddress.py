import nmap
import ipaddress
import re

port_range_pattern = re.compile("([0-9]+)-([0-9]+)")
ip_entered = input("Enter the ip address")
try:
    ip_address_obj = ipaddress.ip_address(ip_entered)
    print('valid')
except:
    print('invalid')

port_range = input("Enter the port ranges")
port_range_valid = port_range_pattern.search(port_range.replace(" ", ""))
if port_range_valid:
    port_min = int(port_range_valid.group(1))
    port_max = int(port_range_valid.group(2))

nm = nmap.PortScanner()
for port in range(port_min,port_max):
    try:
        result  = nm.scan(ip_entered,str(port))
        port_status = (result['scan'][ip_entered]['tcp'][port]['state'])
        print(f"Port {port} is {port_status}")
    except:
        print(f"Cannot scan port {port}.")