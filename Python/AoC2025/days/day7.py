import numpy as np

class Day7:
    def __init__(self):
        with open("../../Data/2025/day7.txt") as f:
            self.data = [line.rstrip('\n') for line in f]

    def part_one(self):
        grid = [[n for n in row] for row in self.data]
        row = 0
        col = grid[0].index('S')
        self.move_down(grid, row, col)
        return sum(row.count('X') for row in grid)
    
    def part_two(self):
        arr = np.array([list(row) for row in self.data])
        grid = np.zeros_like(arr, dtype=np.int64)
        grid[arr == 'S'] = 1
        height, width = len(arr), len(arr[0])
        for i in range(1, height):
            for j in range(width):
                if arr[i][j] == '.':
                    grid[i][j] += grid[i - 1][j]
            for j in range(width):
                if arr[i][j] == '^':
                    if j > 0:
                        grid[i][j - 1] += grid[i - 1][j]
                    if j < width - 1:
                        grid[i][j + 1] += grid[i - 1][j]

        return np.sum(grid[-1])

    def move_down(self, grid, row, col):
        if grid[row][col] in ['X', '^']:
            return
        if row == len(grid) - 1:
            return
        if grid[row + 1][col] == 'X':
            return
        if grid[row + 1][col] == '.':
            self.move_down(grid, row + 1, col)
            return
        if grid[row + 1][col] == '^':
            if col > 0:
                self.move_down(grid, row + 1, col - 1)
            if col < len(grid[0]):
                self.move_down(grid, row + 1, col + 1)
            grid[row + 1][col] = 'X'
            return
    
    def quantum_move_down(self, grid, row, col):
        total = 0
        if row == len(grid) - 1:
            return 1
        elif grid[row + 1][col] == '.':
            total += self.quantum_move_down(grid, row + 1, col)
        elif grid[row + 1][col] == '^':
            if col > 0:
                total += self.quantum_move_down(grid, row + 1, col - 1)
            if col < len(grid[0]) - 1:
                total += self.quantum_move_down(grid, row + 1, col + 1)
        return total
    
    def pass_beam(self, grid, row, col):
        beam_value = grid[row][col]
        while row < len(grid):
            if (row == len(grid) - 1) or (self.data[row][col] == '^'):
                grid[row][col] += beam_value
            row += 1

    def print_solution(self):
        print("Day 7:")
        print(f"Part 1: {self.part_one()}")
        print(f"Part 2: {self.part_two()}")