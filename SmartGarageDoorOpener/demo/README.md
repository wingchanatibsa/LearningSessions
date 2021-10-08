# Final Project: Garage Door Opener using Computer Vision
To combine my [smart home garage door opener](https://www.myq.com/smart-garage-control) (MyQ) and using the computer vision which can recorgnize either my car's license plate or hand gesture to open my garage door automatically.

# Software Requirement
- Python 3.8+ - required version for Pymyq library
- Open CV - library for processing the real-time computer vision
- Numpy - library for scientific computing
- MatPlotlib - library for interactive visualization
- PiCamera - library for camera module in Raspberry PI
- Scikit-image - library for image processing
- Scikit-Learn - library for predictive data analysis
- AioHttp - library for asynchronous HTTP client/server framework

# Installation
To install myQ python library
```
pip3 install pymyq
```

To install dependencies libraries
```
pip3 install -r requirements.txt
```

# Configure settings

1. Enter your license plate number in GarageDoorDetector.py

```
line 7:  ExpectedLicensePlate = "YourLicensePlateNumber" #your license plate number
```

2. Enter your myQ login credential in GarageOpener.py

```
line 12: EMAIL = "YourEmailAddress" #Your MyQ login email
line 13: PASSWORD = "YourPassword" #Your MyQ login password
```

3. Enter your secret hand gesture in HandGestureGarageOpener.py

```
line 14: myPassword = "123" # secret hand gesture - a series of fingers counting numbers
```

# Execute the programs

For executing the license plate detection program, you need to run the command line below.

```
python3 GarageDoorDetector.py
```

For executing the hand gesture recorgnition program, you need to run the command line below.
```
python3 HandGestureGarageOpener.py
```
