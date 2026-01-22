class Day1:
    def __init__(self):
        with open("../../Data/2015/day1.txt") as f:
            self.data = f.read()
    
    def find_floor(self):
        floor = 0
        index = 1
        not_printed = True
        for x in self.data:
            if x == '(':
                floor += 1
            else:
                floor -= 1
            if floor == -1 and not_printed:
                not_printed = False
                print(f"The basement is entered at index {index}.")
            index += 1
        print(f"The final floor number was {floor}.")