class Day10:
    def __init__(self):
        with open("../../Data/2025/day10.txt") as f:
            self.data = [[x for x in line.rstrip("\n").split(",")] for line in f]

    def part_one(self):
        pass

    def part_two(self):
        pass

    def print_solution(self):
        print("Day 10:")
        print(f"Part 1: {self.part_one()}")
        print(f"Part 2: {self.part_two()}")