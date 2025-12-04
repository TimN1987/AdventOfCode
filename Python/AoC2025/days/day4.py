class Day4:
    def __init__(self):
        with open("../../Data/2025/day4.txt") as f:
            self.data = f.readlines()
        self.padded_data = self.pad_data()
        self.ADJACENT_DELTAS = [-1, 0, 1]

    def part_one(self):
        result = 0
        rows, cols = len(self.padded_data), len(self.padded_data[0])
        for i in range(rows):
            for j in range(cols):
                if self.padded_data[i][j] == '@':
                    result += 1 if self.count_adjacent(i, j) < 4 else 0
        return result
    
    def part_two(self):
        pass

    def count_adjacent(self, row, col):
        total = 0 if self.padded_data[row][col] == '.' else -1
        for i in self.ADJACENT_DELTAS:
            for j in self.ADJACENT_DELTAS:
                if self.padded_data[row + i][col + j] == '@':
                    total += 1
        return total

    def pad_data(self):
        new_grid = []
        length = len(self.data[0])
        new_grid.append(" " * (length + 2))
        for line in self.data:
            new_grid.append(" " + line + " ")
        new_grid.append(" " * (length + 2))
        return new_grid

    def print_solution(self):
        print("Day 4:")
        print(f"Part 1: {self.part_one()}")
        print(f"Part 2: {self.part_two()}")