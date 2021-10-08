import SegmentCharacters
import pickle
from fuzzywuzzy import fuzz
import os
import time

ExpectedLicensePlate = "YourLicensePlateNumber" #your license plate number

while True:
    try: 
        print("Loading model")
        filename = './finalized_model.sav'
        model = pickle.load(open(filename, 'rb'))

        print('Model loaded. Predicting characters of number plate')
        classification_result = []
        
        SegmentCharacters.characters = []
        SegmentCharacters.column_list = []
        SegmentCharacters.run_segment_character()

        for each_character in SegmentCharacters.characters:
            # converts it to a 1D array
            each_character = each_character.reshape(1, -1)
            result = model.predict(each_character)
            classification_result.append(result)

        # print('Classification result')
        # print(classification_result)

        plate_string = ''
        for eachPredict in classification_result:
            plate_string += eachPredict[0]

        # print('Predicted license plate')
        # print(plate_string)

        # it's possible the characters are wrongly arranged
        # since that's a possibility, the column_list will be
        # used to sort the letters in the right order

        column_list_copy = SegmentCharacters.column_list[:]
        SegmentCharacters.column_list.sort()
        rightplate_string = ''
        for each in SegmentCharacters.column_list:
            rightplate_string += plate_string[column_list_copy.index(each)]

        print('License plate')
        print(rightplate_string)

        DetectedLicensePlate = rightplate_string
        
        Ratio = fuzz.ratio(ExpectedLicensePlate.lower(),DetectedLicensePlate.lower())
        print(Ratio)

        if (Ratio > 50):
            print("License Plate Found.")

            #open garage door by calling myQ API using this program below
            os.system('python3.8 ./GarageOpener.py')
        else:
            print("License Plate Not Found.")
        
        time.sleep(1)

    except KeyboardInterrupt:
        print("quit")
        break
    except IndexError:
        print("License Plate Not Found.")