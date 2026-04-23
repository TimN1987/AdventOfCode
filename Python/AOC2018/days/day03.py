import numpy as np
import re

class Day3:
    def __init__(self):
        with open("../../Data/2018/day3.txt") as f:
            self.data = [[int(n) for n in re.findall(r"\d+", line)] for line in f if line.strip()]
        self.grid = np.zeros((1000, 1000), dtype=np.int32)

    def solve(self):
        for claim in self.data:
            self.mark_fabric(claim)
        print("Day 3 solutions:")
        self.part_one()
        self.part_two()

    def part_one(self):
        print(f"The total overlaps are: {np.count_nonzero(self.grid == -1)}")

    def part_two(self):
        for claim_id, x, y, w, h in self.data:
            if np.all(self.grid[y:y+h, x:x+w] == claim_id):
                print(f"The non-overlapping claim ID is: {claim_id}")

    def mark_fabric(self, claim):
        claim_id, x, y, w, h = claim
        y_end, x_end = y + h, x + w
        region = self.grid[y:y_end, x:x_end]
        self.grid[y:y_end, x:x_end] = np.where(region == 0, claim_id, -1)