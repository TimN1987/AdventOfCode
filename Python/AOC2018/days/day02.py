from collections import Counter

class Day2:
    def __init__(self):
        with open("../../Data/2018/day2.txt") as f:
            self.data = [line.strip() for line in f if line.strip()]

    def solve(self):
        print("Day 2 solutions:")
        self.part_one()
        self.part_two()

    def part_one(self):
        has_two = 0
        has_three = 0
        for d in self.data:
            counts = Counter(d)
            has_two += 1 if 2 in counts.values() else 0
            has_three += 1 if 3 in counts.values() else 0
        print(f"The checksum is {has_two * has_three}")

    def part_two(self):
        for i in range(len(self.data) - 1):
            for j in range(i + 1, len(self.data)):
                if sum(1 for a, b in zip(self.data[i], self.data[j]) if a != b) == 1:
                    output = "".join(a for a, b in zip(self.data[i], self.data[j]) if a == b)
                    print(f"The common letters are: {output}")
                    return