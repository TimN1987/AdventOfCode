class Day1:
    def __init__(self):
        with open("../../Data/2025/day1.txt") as f:
            self.data = f.readlines()

    def parse_data(self):
        rotations = []
        for line in self.data:
            if line[0] == 'R':
                rotations.append(int(line[1:]))
            elif line[0] == 'L':
                rotations.append(0 - int(line[1:]))
        return rotations

    def part_one(self):
        count = 0
        dial = 50
        rotations = self.parse_data()
        for rotation in rotations:
            dial = (dial + rotation + 100) % 100
            if dial == 0:
                count += 1
        return count
    
    def part_two(self):
        count = 0
        dial = 50
        rotations = self.parse_data()
        for rotation in rotations:
            step = 1 if rotation > 0 else -1
            for _ in range(abs(rotation)):
                dial += step
                if dial == -1:
                    dial = 99
                elif dial == 100:
                    dial = 0
                if dial == 0:
                    count += 1
        return count
    
    def print_results(self):
        print("Day 1:")
        print(f"Part 1: {self.part_one()}")
        print(f"Part 2: {self.part_two()}")