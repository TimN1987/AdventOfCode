import math

class Day6:
    def __init__(self):
        with open("../../Data/2025/day6.txt") as f:
            self.data = [line.rstrip('\n') for line in f]
            self.p1data = [line.split() for line in self.data]
            self.p2data = list(map(list, zip(*self.data)))


    def part_one(self):
        total = 0
        rows = self.p1data
    
        for i in range(len(rows[0])):
            col = [int(row[i]) for row in rows[:-1]]
            op = rows[-1][i] 
            if op == '+':
                total += sum(col)
            else:
                total += math.prod(col)
        return total

    def part_two(self):
        total = 0
        op = ' '
        nums = []
        for col in self.p2data:
            if col[-1] != ' ':
                op = col[-1]
            if all(x == ' ' for x in col):
                total += sum(nums) if op == '+' else math.prod(n for n in nums)
                nums.clear()
            else:
                nums.append(int("".join(col[:-1])))
        total += sum(nums) if op == '+' else math.prod(n for n in nums)
        return total

    def print_solution(self):
        print("Day 6:")
        print(f"Part 1: {self.part_one()}")
        print(f"Part 2: {self.part_two()}")