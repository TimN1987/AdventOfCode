class Day11:
    def __init__(self):
        with open("../../Data/2025/day11.txt") as f:
            self.data = [line.rstrip('\n').split(' ') for line in f]
        self.connections = {x[0][0:-1] : x[1:] for x in self.data}
        self.cache = {}

    def part_one(self):
        return self.follow_path('you', 'out')
    
    def part_two(self):
        a = self.follow_path('svr', 'fft')
        b = self.follow_path('fft', 'dac')
        c = self.follow_path('dac', 'out')
        return a * b * c

    def follow_path(self, input, end):
        if input == end:
            return 1
        elif input == 'out':
            return 0
        if (input, end) in self.cache:
            return self.cache[(input, end)]
        total = 0
        for c in self.connections[input]:
            total += self.follow_path(c, end)
        self.cache[(input, end)] = total
        return total

    def print_solution(self):
        print("Day 11:")
        print(f"Part 1: {self.part_one()}")
        print(f"Part 2: {self.part_two()}")