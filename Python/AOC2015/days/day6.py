import re

class Day6:
    def __init__(self):
        with open("../../Data/2015/day6.txt") as f:
            self.data = f.readlines()
        self.grid = [[False] * 1000 for _ in range(1000)]
        self.grid2 = [[0] * 1000 for _ in range(1000)]

    def run_light_display(self):
        for line in self.data:
            positions = re.findall(r"\d+", line)
            start, end = [int(positions[0]), int(positions[1])], [int(positions[2]), int(positions[3])]
            if line.startswith('toggle'):
                self.toggle(start, end)
            elif line.startswith('turn on'):
                self.turn_on(start, end)
            else:
                self.turn_off(start, end)
        total_on, total_brightness = 0, 0
        for i in range(1000):
            for j in range(1000):
                total_on += 1 if self.grid[i][j] else 0
                total_brightness += self.grid2[i][j]
        print(f"At the end, there were {total_on} lights on. The total brightness was {total_brightness}.")

    def toggle(self, start, end):
        for i in range(start[0], end[0] + 1):
            for j in range(start[1], end[1] + 1):
                self.grid[i][j] = not self.grid[i][j]
                self.grid2[i][j] += 2

    def turn_on(self, start, end):
        for i in range(start[0], end[0] + 1):
            for j in range(start[1], end[1] + 1):
                self.grid[i][j] = True
                self.grid2[i][j] += 1

    def turn_off(self, start, end):
        for i in range(start[0], end[0] + 1):
            for j in range(start[1], end[1] + 1):
                self.grid[i][j] = False
                self.grid2[i][j] = max(self.grid2[i][j] - 1, 0)