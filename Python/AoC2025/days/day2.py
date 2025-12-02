import re

class Day2:
    def __init__(self):
        with open("../../Data/2025/day2.txt") as f:
            self.data = f.readlines()
        self.ranges = self.parse_input()
        self.double_regex = r"^(\d+)\1$"
        self.multiple_regex = r"^(\d+)\1+$"

    def solution(self):
        total1 = 0
        total2 = 0
        for r in self.ranges:
            boundaries = r.split("-")
            start, end = int(boundaries[0]), int(boundaries[1])
            for num in range(start, end + 1):
                if re.fullmatch(self.double_regex, str(num)):
                    total1 += num
                if re.fullmatch(self.multiple_regex, str(num)):
                    total2 += num
        print("Day 2:")
        print(f"Part 1: {total1}")
        print(f"Part 2: {total2}")

    def parse_input(self):
        ranges = self.data[0].split(",")
        return ranges
