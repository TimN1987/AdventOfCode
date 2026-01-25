from hashlib import md5

class Day4:
    def __init__(self):
        with open("../../Data/2015/day4.txt") as f:
            self.data = f.read().strip()

    def get_hash(self, num):
        message = self.data + str(num)
        return md5(message.encode()).hexdigest()
    
    def find_answers(self):
        num = 0
        five_found = False
        while True:
            output = self.get_hash(num)
            if not five_found and output.startswith('00000'):
                print(f"The secret number that produces five zeros is {num}.")
                five_found = True
            if output.startswith('000000'):
                print(f"The secret number that produces six zeros is {num}.")
                break
            num += 1