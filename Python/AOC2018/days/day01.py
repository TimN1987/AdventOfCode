class Day1:
    def __init__(self):
        with open("../../Data/2018/day1.txt") as f:
            self.data = [line.strip() for line in f if line.strip()]

    def solve(self):
        print("Day 1 solutions:")
        self.part_one()
        self.part_two()

    def part_one(self):
        freq = 0
        for d in self.data:
            freq += int(d[1:]) if d[0] == '+' else 0 - int(d[1:])
        print(f"The final frequency is {freq}")

    def part_two(self):
        visited = set()
        freq, i = 0, 0
        while freq not in visited:
            visited.add(freq)
            freq += int(self.data[i][1:]) if self.data[i][0] == '+' else 0 - int(self.data[i][1:])
            i += 1
            if i == len(self.data):
                i = 0
        print(f"The first repeated frequency is {freq}")